using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI;
using ShomreiTorah.Data.UI.Controls;
using ShomreiTorah.Data.UI.DisplaySettings;
using ShomreiTorah.Singularity;
using ShomreiTorah.WinForms;
using Microsoft.Win32;

namespace ShomreiTorah.Billing.Events.MelaveMalka {
	partial class InvitationsForm : XtraForm {
		static string defaultSource = Registry.GetValue(Program.SettingsPath, "DefaultMelaveMalkaSource", null) as string;
		public static string DefaultSource {
			get { return defaultSource; }
			set {
				defaultSource = value;
				Registry.SetValue(Program.SettingsPath, "DefaultMelaveMalkaSource", value);
			}
		}


		readonly int year;
		readonly FilteredTable<MelaveMalkaInvitation> dataSource;
		public InvitationsForm(int year) {
			Program.LoadTable<MelaveMalkaInvitation>();	//Before DataMember is set in InitializeComponent
			InitializeComponent();
			this.year = year;
			Text = "Melave Malka " + year + " Invitations";

			dataSource = new FilteredTable<MelaveMalkaInvitation>(
				Program.Table<MelaveMalkaInvitation>(),
				mmi => mmi.Year == year
			);
			grid.DataMember = null;
			grid.DataSource = listSearch.Properties.DataSource = dataSource;

			EditorRepository.MelaveMalkaSourceEditor.Apply(source.Properties);
			EditorRepository.PersonOwnedLookup.Apply(listSearch.Properties);
			Program.SuppressValidation(personSelector.Properties);

			if (Names.MelaveMalkaSources.Contains(DefaultSource))
				source.Text = DefaultSource;
		}

		///<summary>Releases the unmanaged resources used by the InvitationsForm and optionally releases the managed resources.</summary>
		///<param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (dataSource != null) dataSource.Dispose();
				if (components != null) components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void personSelector_PersonSelecting(object sender, PersonSelectingEventArgs e) {
			if (e.Method == PersonSelectionReason.Created)
				e.Person.Source = "Melave Malka " + year;
			else {
				var otherInvite = e.Person.Invitees.FirstOrDefault(i => i.Year == year);
				if (otherInvite != null) {
					e.Cancel = true;
					Dialog.ShowError(e.Person.VeryFullName + " are already invited by the " + otherInvite.Source + ".");
				}
			}
		}
		private void personSelector_EditValueChanged(object sender, EventArgs e) {
			if (personSelector.SelectedPerson == null) return;
			if (String.IsNullOrWhiteSpace(source.Text)) {
				Dialog.ShowError("Please select a source");
				personSelector.SelectedPerson = null;
				return;
			}
			Program.Table<MelaveMalkaInvitation>().Rows.Add(new MelaveMalkaInvitation {
				Person = personSelector.SelectedPerson,
				DateAdded = DateTime.Now,
				Year = year,
				Source = source.Text
			});
			personSelector.SelectedPerson = null;
			DefaultSource = source.Text;
		}

		private void listSearch_EditValueChanged(object sender, EventArgs e) {
			var row = listSearch.EditValue as MelaveMalkaInvitation;
			if (row == null) return;
			gridView.SetSelection(gridView.GetRowHandle(dataSource.Rows.IndexOf(row)), makeVisible: true);
			listSearch.EditValue = null;
		}

		private void saveExcel_ItemClick(object sender, ItemClickEventArgs e) {
			string path;
			using (var dialog = new SaveFileDialog {
				Filter = "Excel 2003 Spreadsheet|*.xls|Excel 2007 Spreadsheet (*.xlsx)|*.xlsx",
				FileName = "Melave Malka " + year + " Invites",
				Title = "Save Melave Malka Invitations"
			}) {
				if (dialog.ShowDialog(MdiParent) != DialogResult.OK) return;
				path = dialog.FileName;
			}
			dataSource.Rows.ExportExcel(path);
			Process.Start(path);
		}
	}
}