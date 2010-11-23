using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using ShomreiTorah.Common;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI.DisplaySettings;
using ShomreiTorah.Singularity;
using ShomreiTorah.WinForms;
using ShomreiTorah.WinForms.Forms;

namespace ShomreiTorah.Billing.Events.MelaveMalka {
	partial class CallerList : XtraForm {
		const string templateSubfolder = "Caller Emails";

		readonly FilteredTable<Caller> dataSource;
		readonly int year;
		public CallerList(int year) {
			Program.LoadTable<Caller>();
			InitializeComponent();
			this.Text = "Melave Malka " + year + " Callers";
			this.year = year;

			addCaller.Properties.DataSource = Program.Table<Person>();
			EditorRepository.PersonLookup.Apply(addCaller.Properties);

			grid.DataMember = null;
			grid.DataSource = dataSource = new FilteredTable<Caller>(
				Program.Table<Caller>(),
				c => c.Year == year
			);

			colCallerPerson.ColumnEdit.DoubleClick += CallerPersonEdit_DoubleClick;
			UpdateButtons();

			emailTemplateList.Strings.AddRange(
				Array.ConvertAll<string, string>(Directory.GetFiles(Path.Combine(Program.AspxPath, templateSubfolder), "*.aspx"), Path.GetFileNameWithoutExtension)
			);
		}
		///<summary>Releases the unmanaged resources used by the CallerList and optionally releases the managed resources.</summary>
		///<param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				dataSource.Dispose();
				if (components != null) components.Dispose();
			}
			base.Dispose(disposing);
		}

		void CallerPersonEdit_DoubleClick(object sender, EventArgs e) { ToggleRow(gridView.FocusedRowHandle); }
		private void gridView_DoubleClick(object sender, EventArgs e) {
			var info = gridView.CalcHitInfo(grid.PointToClient(MousePosition));

			if (info.RowHandle >= 0 && info.InRow) {
				ToggleRow(info.RowHandle);
				var dx = e as DXMouseEventArgs;
				if (dx != null) dx.Handled = true;
			}
		}
		void ToggleRow(int handle) {
			gridView.SetMasterRowExpanded(handle, !gridView.GetMasterRowExpanded(handle));
		}

		private void addCaller_EditValueChanged(object sender, EventArgs e) {
			var person = addCaller.EditValue as Person;
			if (person == null) return;
			addCaller.EditValue = null;

			if (person.Callers.Any(c => c.Year == year)) {
				Dialog.ShowError(person.FullName + " is already a caller for the " + year + " Melave Malka");
				return;
			}

			Program.Table<Caller>().Rows.Add(new Caller {
				Person = person,
				Year = year,
				DateAdded = DateTime.Now,
			});

			InfoMessage.Show(person.FullName + " has been added as a caller for the " + year + " Melave Malka");
		}

		private void emailLinkEdit_OpenLink(object sender, OpenLinkEventArgs e) {
			e.Handled = true;
			if (!String.IsNullOrWhiteSpace(e.EditValue as string))
				Process.Start("mailto: " + e.EditValue);
		}

		private void gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e) { UpdateButtons(); }
		void UpdateButtons() {
			var caller = gridView.GetFocusedRow() as Caller;
			if (caller == null)
				sendSingleEmail.Visibility = exportCallList.Visibility = BarItemVisibility.OnlyInCustomizing;
			else {
				sendSingleEmail.Visibility = exportCallList.Visibility = BarItemVisibility.Always;

				sendSingleEmail.Caption = "Email " + caller.Person.HisName + " " + caller.Person.LastName;
				exportCallList.Caption = "Export list for " + caller.Person.HisName + " " + caller.Person.LastName;
			}
		}

		private void exportCallList_ItemClick(object sender, ItemClickEventArgs e) {
			var caller = (Caller)gridView.GetFocusedRow();
			if (caller == null)
				Dialog.ShowError("Please select a caller");
			else if (caller.Callees.All(i => i.AdAmount > 0))
				Dialog.ShowError(caller.Person.HisName + " " + caller.Person.LastName + " doesn't have anyone to call.");
			else {
				string path;
				using (var dialog = new SaveFileDialog {
					Filter = "Excel 2003 Spreadsheet|*.xls|Excel 2007 Spreadsheet (*.xlsx)|*.xlsx",
					FileName = "Call List for " + caller.Person.HisName + " " + caller.Person.LastName + ".xls",
					Title = "Save Call List"
				}) {
					if (dialog.ShowDialog(MdiParent) != DialogResult.OK) return;
					path = dialog.FileName;
				}
				caller.CreateCallList(path);
				Process.Start(path);
			}
		}

		///<summary>The callers that the email menu was invoked for.</summary>
		IList<Caller> clickedCallers;
		private void sendSingleEmail_Popup(object sender, EventArgs e) {
			clickedCallers = new[] { (Caller)gridView.GetFocusedRow() };
		}

		private void sendAllEmails_Popup(object sender, EventArgs e) {
			clickedCallers = (IList<Caller>)dataSource.Rows;
		}

		private void emailTemplateList_ListItemClick(object sender, ListItemClickEventArgs e) {
			#region Validation / Confirmation
			if (clickedCallers.Count == 0) {
				Dialog.ShowError("Please select a caller");
				return;
			}
			var emptyCallers = clickedCallers.Where(c => c.Callees.All(i => i.AdAmount > 0)).ToList();
			if (emptyCallers.Any()) {
				Dialog.Show(emptyCallers.Join(", ", c => c.Person.FullName)
						  + " do not have anyone to call and will not be emailed", MessageBoxIcon.Warning);
			}
			var actualCallers = clickedCallers.Where(c => c.Callees.Any(i => i.AdAmount == 0)).ToList();
			if (actualCallers.Count == 0) return;	//We already displayed an error

			if (actualCallers.Count == 1) {
				if (!Dialog.Confirm("Would you like to send an email to " + actualCallers[0].Person.HisName + " " + actualCallers[0].Person.LastName + "?"))
					return;
			} else {
				if (!Dialog.Confirm("Would you like to send emails to " + actualCallers.Count + " callers?"))
					return;
			}
			#endregion

			var virtualPath = "/" + templateSubfolder + "/" + emailTemplateList.Strings[e.Index] + ".aspx";
			Dialog.Inform("Sending " + virtualPath + " to " + actualCallers.Join(", ", c => c.Person.FullName));
		}
	}
}