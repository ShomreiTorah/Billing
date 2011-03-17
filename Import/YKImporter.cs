using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using ShomreiTorah.Common;
using ShomreiTorah.Data;
using ShomreiTorah.WinForms;
using ShomreiTorah.WinForms.Forms;

namespace ShomreiTorah.Billing.Import {
	partial class YKImporter : XtraForm {
		#region Read data
		enum MatchState {
			Identical,
			Added,
			Deleted,
			Updated,
			NonYK
		}

		enum ImportAction {
			Ignore,
			Update,
			Add,
			Delete
		}
		static readonly Dictionary<MatchState, ImportAction> DefaultActions = new Dictionary<MatchState, ImportAction>{
			{ MatchState.Identical, ImportAction.Ignore	},
			{ MatchState.Added,		ImportAction.Add	},
			{ MatchState.Deleted,	ImportAction.Delete	},
			{ MatchState.Updated,	ImportAction.Update	},
			{ MatchState.NonYK,		ImportAction.Ignore	},
		};
		static readonly Dictionary<MatchState, string> MatchStateNames = new Dictionary<MatchState, string>{
			{ MatchState.Identical, "Identical People"	},
			{ MatchState.Added,		"New People"		},
			{ MatchState.Deleted,	"Deleted People"	},
			{ MatchState.Updated,	"Updated People"	},
			{ MatchState.NonYK,		"People not in YK"	},
		};

		public static void Execute() {
			Program.Current.RefreshDatabase();
			using (var fileDialog = new OpenFileDialog {
				Filter = "Excel Files (*.xls, *.xlsx)|*.xls;*.xlsx|All Files|*.*",
				Title = "Open YK Directory"
			}) {
				if (fileDialog.ShowDialog() == DialogResult.Cancel) return;

				bool workerSucceeded = false;
				DataTable ykData;
				#region Initialize processedRows
				DataTable processedRows = new DataTable { Locale = CultureInfo.InvariantCulture };
				processedRows.Columns.Add("PersonId", typeof(Guid));
				processedRows.Columns.Add("YKID", typeof(int));
				processedRows.Columns.Add("FullName", typeof(string));
				processedRows.Columns.Add("HisName", typeof(string));
				processedRows.Columns.Add("HerName", typeof(string));
				processedRows.Columns.Add("LastName", typeof(string));
				processedRows.Columns.Add("Address", typeof(string));
				processedRows.Columns.Add("City", typeof(string));
				processedRows.Columns.Add("State", typeof(string));
				processedRows.Columns.Add("Zip", typeof(string));
				processedRows.Columns.Add("Phone", typeof(string));
				processedRows.Columns.Add("TotalPledged", typeof(decimal));
				processedRows.Columns.Add("Action", typeof(ImportAction));
				processedRows.Columns.Add("MatchState", typeof(MatchState));
				#endregion
				try {
					ProgressWorker.Execute(ui => {
						ui.Caption = "Opening " + Path.GetFileName(fileDialog.FileName);
						ykData = OpenFile(fileDialog.FileName);

						ui.Caption = "Processing " + ykData.TableName;

						var masterDirectory = Program.Current.DataContext.Table<Person>();

						ui.Maximum = ykData.Rows.Count;
						for (int i = 0; i < ykData.Rows.Count; i++) {
							if (ui.WasCanceled) return;
							ui.Progress = i;
							var ykRow = ykData.Rows[i];
							var ykid = Convert.ToInt32(ykRow["IDNUM"], CultureInfo.InvariantCulture);

							#region Populate ykPerson
							var ykPerson = new PersonData {
								FullName = ykRow.Field<string>("Address1MM").Cleanup(),
								HisName = ykRow.Field<string>("HIS_FIRST").Cleanup(),
								HerName = ykRow.Field<string>("HER_FIRST").Cleanup(),
								LastName = ykRow.Field<string>("Company").Cleanup(),
								Address = ykRow.Field<string>("Address").Cleanup(),
								City = ykRow.Field<string>("City").Cleanup(),
								State = ykRow.Field<string>("State").Cleanup(),
								Zip = ykRow.Field<string>("Zip").Cleanup(),
								Phone = ykRow.Field<string>("Telephone").Cleanup().FormatPhoneNumber()
							};
							#endregion
							if (ykPerson.Address == null)
								ykPerson.City = ykPerson.State = ykPerson.Zip = null;

							var mdRow = masterDirectory.Rows.FirstOrDefault(p => p.YKID == ykid);

							if (mdRow != null && mdRow.LastName != ykPerson.LastName) {
								var candidates = masterDirectory.Rows
									.Where(md => md.LastName == ykPerson.LastName
											  && md.YKID != null
											  && ykData.Select("IDNUM=" + md.YKID).Length == 0
									).ToArray();
								if (candidates.Length == 1)
									mdRow = candidates[0];
								else if (candidates.Length > 1) {
									candidates = candidates.Where(md => md.Phone == ykPerson.Phone).ToArray();
									if (candidates.Length == 1)
										mdRow = candidates[0];
								}
							}

							Guid? personId;
							MatchState state;
							if (mdRow == null) {
								personId = null;
								state = MatchState.Added;
								//TODO: Match manually added people.
							} else if (ykPerson.IsUnequal(mdRow)) {
								personId = mdRow.Id;
								state = MatchState.Updated;
							} else {
								personId = mdRow.Id;
								state = MatchState.Identical;
							}

							processedRows.Rows.Add(
								(object)personId ?? DBNull.Value, ykid,
								ykPerson.FullName, ykPerson.HisName, ykPerson.HerName, ykPerson.LastName,
								ykPerson.Address, ykPerson.City, ykPerson.State, ykPerson.Zip, ykPerson.Phone,
								mdRow == null ? null : mdRow["TotalPledged"],
								DefaultActions[state], state
							);
						}

						ui.Caption = "Scanning for deleted people";
						ui.Maximum = masterDirectory.Rows.Count;
						for (int i = 0; i < masterDirectory.Rows.Count; i++) {
							if (ui.WasCanceled) return;
							ui.Progress = i;
							var mdRow = masterDirectory.Rows[i];

							if (processedRows.Select("PersonId = '" + mdRow.Id + "'").Length > 0)
								continue;		//Skip people we've already added.

							var state = mdRow.YKID.HasValue ? MatchState.Deleted : MatchState.NonYK;
							var action = DefaultActions[state];

							//Don't delete people who have any kind of child records
							if (action == ImportAction.Delete
							 && Person.Schema.ChildRelations.Any(
									cr => Program.Current.DataContext.Tables[cr.ChildSchema] != null	//Skip tables that haven't been loaded
									   && mdRow.ChildRows(cr).Any()
								))
								action = ImportAction.Ignore;

							//TODO: Try to match custom people
							processedRows.Rows.Add(
								mdRow.Id, null,	//YKID here is new YKID; thereisn't any
								mdRow.FullName, mdRow.HisName, mdRow.HerName, mdRow.LastName,
								mdRow.Address, mdRow.City, mdRow.State, mdRow.Zip, mdRow.Phone,
								mdRow["TotalPledged"],
								action, state
							);
						}

						ui.Caption = "Displaying grid";
						workerSucceeded = !ui.WasCanceled;
					}, true);
				} catch (TargetInvocationException ex) {
					XtraMessageBox.Show("Couldn't open " + Path.GetFileName(fileDialog.FileName) + ".\r\n" + ex.InnerException,
										"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				if (!workerSucceeded)
					return;
				new YKImporter(processedRows).ShowDisposingDialog();
			}
		}

		static DataTable OpenFile(string fileName) {
			var file = DB.OpenFile(fileName);

			using (var connection = (OleDbConnection)file.OpenConnection()) {
				var tableName =
					connection.GetSchema("Tables").AsEnumerable()
						.Select(r => new { Name = r.Field<string>("TABLE_NAME"), Count = GetCount(r.Field<string>("TABLE_NAME"), connection) })
						.Where(t => t.Count > 0)
						.Aggregate((t1, t2) => t1.Count > t2.Count ? t1 : t2)
						.Name;

				DataTable table = new DataTable { TableName = tableName, Locale = CultureInfo.InvariantCulture };
				using (var adapter = file.Factory.CreateDataAdapter(connection, "SELECT * FROM [" + tableName.Replace("]", "]]") + "]"))
					adapter.Fill(table);
				return table;
			}
		}
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Hide errors")]
		static int GetCount(string tableName, DbConnection connection) {
			try {
				return connection.ExecuteScalar<int>("SELECT COUNT(*) FROM [" + tableName.Replace("]", "]]") + "]");
			} catch { return -1; }
		}

		readonly DataTable processedRows;
		YKImporter(DataTable processedRows) {
			InitializeComponent();
			this.processedRows = processedRows;
			grid.DataSource = processedRows;
		}
		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			gridView.BestFitColumns();
		}
		#endregion

		private void doImport_Click(object sender, EventArgs e) {
			foreach (DataRow ykRow in processedRows.Rows) {
				switch (ykRow.Field<ImportAction>("Action")) {
					case ImportAction.Ignore:
						break;
					case ImportAction.Update:
						var ykPerson = new PersonData(ykRow);
						var mdRow = Program.Table<Person>().Rows.First(p => p.Id == ykRow.Field<Guid>("PersonId"));

						if (!ykRow.IsNull("YKID"))
							mdRow.YKID = ykRow.Field<int>("YKID");
						if (!string.IsNullOrEmpty(ykPerson.FullName)) mdRow.FullName = ykPerson.FullName;
						if (!string.IsNullOrEmpty(ykPerson.HisName)) mdRow.HisName = ykPerson.HisName;
						if (!string.IsNullOrEmpty(ykPerson.HerName)) mdRow.HerName = ykPerson.HerName;
						if (!string.IsNullOrEmpty(ykPerson.LastName)) mdRow.LastName = ykPerson.LastName;
						if (!string.IsNullOrEmpty(ykPerson.Address)) mdRow.Address = ykPerson.Address;
						if (!string.IsNullOrEmpty(ykPerson.City)) mdRow.City = ykPerson.City;
						if (!string.IsNullOrEmpty(ykPerson.State)) mdRow.State = ykPerson.State;
						if (!string.IsNullOrEmpty(ykPerson.Zip)) mdRow.Zip = ykPerson.Zip;
						if (!string.IsNullOrEmpty(ykPerson.Phone)) mdRow.Phone = ykPerson.Phone;

						mdRow.Source = "YK Directory";
						break;
					case ImportAction.Add:
						var row = Program.Table<Person>().AddPerson(new PersonData(ykRow), "YK Directory");
						row.YKID = ykRow.Field<int>("YKID");
						break;
					case ImportAction.Delete:
						Program.Table<Person>().Rows.First(p => p.Id == ykRow.Field<Guid>("PersonId")).RemoveRow();
						break;
				}
			}
			Close();
		}

		private void gridView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e) {
			if (e.Column == colMatchState)
				e.DisplayText = MatchStateNames[(MatchState)e.Value];
			else if (e.Column == colAction) {
				if (e.RowHandle < 0)
					e.DisplayText = ((ImportAction)e.Value).ToString();
				else
					e.DisplayText = GetActionName(gridView.GetDataRow(e.RowHandle).Field<MatchState>("MatchState"), (ImportAction)e.Value);
			}
		}
		static string GetActionName(MatchState state, ImportAction action) {
			switch (state) {
				case MatchState.Added:
					if (action == ImportAction.Ignore)
						return "Don't Add";
					if (action == ImportAction.Update)
						return "Update existing person";
					break;
				case MatchState.Deleted:
					if (action == ImportAction.Ignore)
						return "Keep";
					break;
				case MatchState.Updated:
					if (action == ImportAction.Add)
						return "Create new person";
					break;
			}
			return action.ToString();
		}

		private void gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e) {
			var ykRow = gridView.GetFocusedDataRow();
			if (ykRow == null) {
				mdDetails.Text = ykDetails.Text = "Please select a person in the grid.";
			} else {
				var mdRow = ykRow.IsNull("PersonId") ? null : Program.Table<Person>().Rows.FirstOrDefault(p => p.Id == ykRow.Field<Guid>("PersonId"));

				switch (ykRow.Field<MatchState>("MatchState")) {
					case MatchState.Identical:
					case MatchState.Updated:
						ykDetails.Text = new PersonData(ykRow).ToFullString();
						mdDetails.Text = new PersonData(mdRow).ToFullString();
						break;
					case MatchState.Added:
						ykDetails.Text = new PersonData(ykRow).ToFullString();
						mdDetails.Text = "This person is not yet in the master directory and will be added by the import.";
						break;
					case MatchState.Deleted:
						ykDetails.Text = "This person has been removed from the YK directory and will be deleted by the import.";
						mdDetails.Text = new PersonData(mdRow).ToFullString();
						break;
					case MatchState.NonYK:
						ykDetails.Text = "This person is not in the YK directory and will be ignored by the import.";
						mdDetails.Text = new PersonData(mdRow).ToFullString();
						break;
				}
			}
		}
	}
	static class Extensions {
		public static string Cleanup(this string str) {
			if (str == null) return null;
			str = str.Trim();
			return string.IsNullOrEmpty(str) ? null : str;
		}
	}
}