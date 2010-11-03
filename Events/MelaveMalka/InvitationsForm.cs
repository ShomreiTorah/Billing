using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ShomreiTorah.Singularity;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI.DisplaySettings;
using ShomreiTorah.WinForms;

namespace ShomreiTorah.Billing.Events.MelaveMalka {
	partial class InvitationsForm : XtraForm {
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
		}

		private void listSearch_EditValueChanged(object sender, EventArgs e) {
			var row = listSearch.EditValue as MelaveMalkaInvitation;
			if (row == null) return;
			gridView.FocusedRowHandle = gridView.GetRowHandle(dataSource.Rows.IndexOf(row));
			gridView.MakeRowVisible(gridView.FocusedRowHandle, false);
			listSearch.EditValue = null;
		}
	}
}