using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using ShomreiTorah.Common;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI.Controls;
using ShomreiTorah.Data.UI.DisplaySettings;
using ShomreiTorah.Singularity;
using ShomreiTorah.WinForms;
using ShomreiTorah.WinForms.Controls.Lookup;
using ShomreiTorah.WinForms.Forms;

namespace ShomreiTorah.Billing.Events.MelaveMalka {
	public partial class SeatingForm : DevExpress.XtraEditors.XtraForm {
		readonly int year;
		readonly FilteredTable<MelaveMalkaSeat> dataSource;

		public SeatingForm(int year) {
			//Load tables before DataMember is set in InitializeComponent
			//Invitations are required for validation
			Program.LoadTables(MelaveMalkaSeat.Schema, MelaveMalkaInvitation.Schema);

			InitializeComponent();
			this.year = year;
			Text = "Melave Malka " + year + " Seating Reservations";

			dataSource = Program.Table<MelaveMalkaSeat>().Filter(mms => mms.Year == year);
			grid.DataMember = null;
			grid.DataSource = searchLookup.Properties.DataSource = dataSource;

			mensSeatsItem.Text = MelaveMalkaSeat.MensSeatsCaption + ":";
			womensSeatsItem.Text = MelaveMalkaSeat.WomensSeatsCaption + ":";

			Program.SuppressValidation(personSelector.Properties);

			EditorRepository.OptionalSeatEditor.Apply(addWomensSeats.Properties);
			EditorRepository.OptionalSeatEditor.Apply(addMensSeats.Properties);

			EditorRepository.PersonOwnedLookup.Apply(searchLookup.Properties);
			searchLookup.Properties.Columns.Add(new CustomColumn<MelaveMalkaSeat>(
				s => s.MensSeats == null ? "Not Sure" : s.MensSeats.Value.ToString(CultureInfo.CurrentCulture)
			) { Caption = MelaveMalkaSeat.MensSeatsCaption, Width = 50 });
			searchLookup.Properties.Columns.Add(new CustomColumn<MelaveMalkaSeat>(
				s => s.WomensSeats == null ? "Not Sure" : s.WomensSeats.Value.ToString(CultureInfo.CurrentCulture)
			) { Caption = MelaveMalkaSeat.WomensSeatsCaption, Width = 50 });
		}

		///<summary>Releases the unmanaged resources used by the SeatingForm and optionally releases the managed resources.</summary>
		///<param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				dataSource.Dispose();
				if (components != null) components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void searchLookup_EditValueChanged(object sender, EventArgs e) {
			var row = searchLookup.EditValue as MelaveMalkaSeat;
			if (row == null) return;
			gridView.SetSelection(gridView.GetRowHandle(dataSource.Rows.IndexOf(row)), makeVisible: true);
			searchLookup.EditValue = null;
		}

		#region Add Entry
		private void personSelector_PersonSelecting(object sender, PersonSelectingEventArgs e) {
			if (!e.Person.Invitees.Any(i => i.Year == year)) {
				if (!Dialog.Warn(e.Person.VeryFullName + " has not been invited to the Melave Malka.\r\nAre you sure you selected the correct person?"))
					e.Cancel = true;
			}
		}
		private void personSelector_EditValueChanged(object sender, EventArgs e) {
			if (personSelector.EditValue == null) return;
			if (year != MelaveMalkaInfo.CurrentYear
			 && !Dialog.Warn("You're trying to add a seating reservation for the " + year + " Melave Malka.\nAre you sure you want to do that?")) {
				personSelector.SelectedPerson = null;
				return;
			}

			var person = personSelector.SelectedPerson;
			var existingRow = dataSource.Rows.FindIndex(r => r.Person == person);
			if (existingRow >= 0) {
				personSelector.EditValue = null;
				gridView.SetSelection(gridView.GetRowHandle(existingRow), makeVisible: true);
				Dialog.Inform(person.VeryFullName + " have already reserved seats");
				return;
			}

			addMensSeats.EditValue = addWomensSeats.EditValue = null;
			addPanel.Show();
			addMensSeats.Focus();
		}

		private void cancelAdd_Click(object sender, EventArgs e) {
			addPanel.Hide();
			personSelector.EditValue = null;
		}

		private void AddEditor_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyData == Keys.Enter)
				addButton.PerformClick();
		}

		private void addButton_Click(object sender, EventArgs e) {
			if (addMensSeats.EditValue == null && addWomensSeats.EditValue == null) {
				Dialog.ShowError("Please reserve at least one seat");
				return;
			}

			var row = new MelaveMalkaSeat {
				DateAdded = DateTime.Now,
				Year = year,
				Person = personSelector.SelectedPerson,
				MensSeats = addMensSeats.EditValue == null ? new int?() : (int)addMensSeats.Value,
				WomensSeats = addWomensSeats.EditValue == null ? new int?() : (int)addWomensSeats.Value
			};

			Program.Table<MelaveMalkaSeat>().Rows.Add(row);
			var totalSeats = (row.MensSeats ?? 0) + (row.WomensSeats ?? 0);
			if (totalSeats == 1)
				InfoMessage.Show(MdiParent, "One seat has been reserved for " + row.Person.VeryFullName);
			else
				InfoMessage.Show(MdiParent, totalSeats + " seats have been reserved for " + row.Person.VeryFullName);

			addPanel.Hide();
			personSelector.EditValue = null;
		}
		#endregion

		private void gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e) {
			if (e.PrevFocusedRowHandle < 0) return;
			var prevRow = (MelaveMalkaSeat)gridView.GetRow(e.PrevFocusedRowHandle);
			if (prevRow != null && prevRow.MensSeats == null && prevRow.WomensSeats == null)
				prevRow.RemoveRow();
		}
	}
}