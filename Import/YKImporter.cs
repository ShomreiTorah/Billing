using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using ShomreiTorah.Common;
using ShomreiTorah.Data;
using ShomreiTorah.Singularity;
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

		private static DataTable CreateProcessedTable() {
			DataTable table = new DataTable { Locale = CultureInfo.InvariantCulture };
			table.Columns.Add("PersonId", typeof(Guid));
			table.Columns.Add("YKID", typeof(int));
			table.Columns.Add("FullName", typeof(string));
			table.Columns.Add("HisName", typeof(string));
			table.Columns.Add("HerName", typeof(string));
			table.Columns.Add("LastName", typeof(string));
			table.Columns.Add("Address", typeof(string));
			table.Columns.Add("City", typeof(string));
			table.Columns.Add("State", typeof(string));
			table.Columns.Add("Zip", typeof(string));
			table.Columns.Add("Phone", typeof(string));
			table.Columns.Add("TotalPledged", typeof(decimal));
			table.Columns.Add("Action", typeof(ImportAction));
			table.Columns.Add("MatchState", typeof(MatchState));
			return table;
		}
		static PersonData ImportRow(DataRow ykRow) {
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

			if (ykPerson.Address == null)
				ykPerson.City = ykPerson.State = ykPerson.Zip = null;
			return ykPerson;
		}
		static Person FindPerson(TypedTable<Person> masterDirectory, DataTable ykData, PersonData ykPerson, int ykid) {
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
			return mdRow;
		}
		public static void Execute() {
			//Before deleting people,  we need to check that
			//they aren't used by any child tables, to avoid
			//violating foreign key constraints.  Therefore,
			//I load all child tables here.
			var missingTables = Person.Schema.ChildRelations.Select(cr => cr.ChildSchema);
			if (missingTables.Any())
				Program.LoadTables(missingTables);
			else
				Program.Current.RefreshDatabase();

			using (var fileDialog = new OpenFileDialog {
				Filter = "Excel Files (*.xls, *.xlsx)|*.xls;*.xlsx|All Files|*.*",
				Title = "Open YK Directory"
			}) {
				if (fileDialog.ShowDialog() == DialogResult.Cancel) return;

				bool workerSucceeded = false;
				DataTable ykData;
				var processedRows = CreateProcessedTable();
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
							var ykPerson = ImportRow(ykRow);
							var mdRow = FindPerson(masterDirectory, ykData, ykPerson, ykid);

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

							var row = processedRows.Rows.Add(
								(object)personId ?? DBNull.Value, ykid,
								ykPerson.FullName, ykPerson.HisName, ykPerson.HerName, ykPerson.LastName,
								ykPerson.Address, ykPerson.City, ykPerson.State, ykPerson.Zip, ykPerson.Phone,
								mdRow == null ? null : mdRow["TotalPledged"],
								DefaultActions[state], state
							);
							if (mdRow != null && mdRow.LastName != ykPerson.LastName)
								row["Action"] = ImportAction.Add;
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
								mdRow.Id, null,	//YKID here is new YKID; there isn't any
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
			mdSelector.Properties.Buttons.RemoveAt(1);	//Delete the Add Person button; it doesn't make sense to add a new member here
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
						var newRow = Program.Table<Person>().AddPerson(new PersonData(ykRow), "YK Directory");
						newRow.YKID = ykRow.Field<int>("YKID");

						if (!ykRow.IsNull("PersonId")) {
							var oldRow = Program.Table<Person>().Rows.First(p => p.Id == ykRow.Field<Guid>("PersonId"));
							if (oldRow.YKID == newRow.YKID)
								oldRow.YKID = null;
						}
						break;
					case ImportAction.Delete:
						Program.Table<Person>().Rows.First(p => p.Id == ykRow.Field<Guid>("PersonId")).RemoveRow();
						break;
				}
			}
			Close();
		}

		#region Action DropDown
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

		void actionDropDown_CustomDisplayText(object sender, CustomDisplayTextEventArgs e) {
			var ykRow = gridView.GetFocusedDataRow();
			e.DisplayText = GetActionName(ykRow.Field<MatchState>("MatchState"), (ImportAction)e.Value);
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
			UpdateDisplay();
		}
		private void gridView_RowUpdated(object sender, RowObjectEventArgs e) {
			UpdateDisplay();
		}

		void UpdateDisplay() {
			var ykRow = gridView.GetFocusedDataRow();
			if (ykRow == null) {
				mdDetails.Text = ykDetails.Text = "Please select a person in the grid.";
				mdSelector.SelectedPerson = null;
				mdSelector.Enabled = false;
			} else {
				var mdRow = ykRow.IsNull("PersonId") ? null : Program.Table<Person>().Rows.FirstOrDefault(p => p.Id == ykRow.Field<Guid>("PersonId"));
				mdSelector.SelectedPerson = mdRow;
				mdSelector.Enabled = true;

				if (mdRow != null)
					mdDetails.Text = new PersonData(mdRow).ToFullString();
				if (ykRow != null)
					ykDetails.Text = new PersonData(ykRow).ToFullString();
				switch (ykRow.Field<ImportAction>("Action")) {
					case ImportAction.Ignore:
						switch (ykRow.Field<MatchState>("MatchState")) {
							case MatchState.Identical:
								ykDetails.Text = "This person already matches and will not be changed.";
								break;
							case MatchState.Updated:
								ykDetails.Text = "This person has been updated in the YK directory, but will not be changed by the import.";
								break;
							case MatchState.Added:
								ykDetails.Text = "This person is not in the master directory, but will not be added.";
								break;
							case MatchState.Deleted:
								ykDetails.Text = "This person has been removed from the YK directory, but will be kept by the import.";
								break;
							case MatchState.NonYK:
								ykDetails.Text = "This person is not in the YK directory and will be ignored by the import.";
								break;
						}
						break;
					case ImportAction.Update:
						break;	//Texts were already set above
					case ImportAction.Add:
						switch (ykRow.Field<MatchState>("MatchState")) {
							case MatchState.Added:
								mdDetails.Text = "This person is not yet in the master directory and will be added by the import.";
								break;
							case MatchState.Updated:
								mdDetails.Text = "This person matches someone in the master directory, but will be added as separate person by the import.\r\nThe matching person, displayed below, will not be changed:\r\n\r\n" + mdDetails.Text;
								break;
						}
						break;
					case ImportAction.Delete:
						ykDetails.Text = "This person has been removed from the YK directory, but will be kept by the import.";
						break;
				}
			}
		}

		private void gridView_ShowingEditor(object sender, CancelEventArgs e) {
			if (gridView.FocusedColumn != colAction)
				return;
			var ykRow = gridView.GetFocusedDataRow();

			actionDropDown.Items.Clear();
			switch (ykRow.Field<MatchState>("MatchState")) {
				case MatchState.NonYK:
				case MatchState.Identical:
					e.Cancel = true;
					break;
				case MatchState.Added:
					actionDropDown.Items.Add(ImportAction.Add);
					actionDropDown.Items.Add(ImportAction.Ignore);
					if (!ykRow.IsNull("PersonId"))
						actionDropDown.Items.Add(ImportAction.Update);
					break;
				case MatchState.Deleted:
					actionDropDown.Items.Add(ImportAction.Delete);
					actionDropDown.Items.Add(ImportAction.Ignore);
					break;
				case MatchState.Updated:
					actionDropDown.Items.Add(ImportAction.Add);
					actionDropDown.Items.Add(ImportAction.Ignore);
					actionDropDown.Items.Add(ImportAction.Update);
					break;
			}
			actionDropDown.DropDownRows = actionDropDown.Items.Count;

		}
		private void actionDropDown_EditValueChanged(object sender, EventArgs e) {
			gridView.CloseEditor();
			UpdateDisplay();
		}
		#endregion

		private void mdSelector_EditValueChanged(object sender, EventArgs e) {
			var ykRow = gridView.GetFocusedDataRow();
			var personId = mdSelector.SelectedPerson == null ? new Guid?() : mdSelector.SelectedPerson.Id;

			if (ykRow.Field<Guid?>("PersonId") == personId)
				return;

			ykRow.SetField("PersonId", personId);
			if (mdSelector.SelectedPerson != null) {
				ykRow["Action"] = ImportAction.Update;
				UpdateDisplay();
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