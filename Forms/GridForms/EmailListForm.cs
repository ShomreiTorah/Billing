using System;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using ShomreiTorah.Data;

namespace ShomreiTorah.Billing.Forms.GridForms {
	partial class EmailListForm : GridFormBase {
		public EmailListForm() {
			InitializeComponent();
		}

		EmailAddress SelectedRow { get { return (EmailAddress)gridView.GetFocusedRow(); } }

		bool changingRow;
		private void gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e) {
			if (SelectedRow == null)
				personSelector.Hide();
			else {
				try {
					changingRow = true;
					personSelector.SelectedPerson = SelectedRow.Person;
				} finally { changingRow = false; }

				personSelector.Show();
			}
		}

		private void personSelector_EditValueChanged(object sender, EventArgs e) {
			if (changingRow) return;

			// Unless the current row already has no person (eg, if the
			// grid is filtered to only show unlinked rows), advance to
			// the next row.
			
			//The grid might be sorted by FullName
			var nextRow = (gridView.GetNextVisibleRow(gridView.GetVisibleIndex(gridView.FocusedRowHandle)));

			SelectedRow.Person = personSelector.SelectedPerson;
			if (nextRow > 0 && ModifierKeys == 0 && SelectedRow?.Person != null) {
				gridView.FocusedRowHandle = gridView.GetVisibleRowHandle(nextRow);
				gridView.TopRowIndex = Math.Max(nextRow - 2, 0);
			} else
				gridView_FocusedRowChanged(null, null);	// Update the lookup on focus change via filter.
		}

		private void personEdit_ButtonClick(object sender, ButtonPressedEventArgs e) {
			if (e.Button.Caption == "Clear") {
				SelectedRow.Person = null;
				gridView.RefreshRow(gridView.FocusedRowHandle);
				gridView.FocusedColumn = null;
				try {
					changingRow = true;
					personSelector.SelectedPerson = null;
				} finally { changingRow = false; }
			} else if (SelectedRow.Person != null)
				new PersonDetails(SelectedRow.Person) { MdiParent = MdiParent }.Show();
		}

		private void gridView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e) {
			if (e.Column == colFullName) {
				e.RepositoryItem = (e.CellValue == null) ? emptyPersonEdit : personEdit;
			}
		}

		private void personEdit_CustomDisplayText(object sender, CustomDisplayTextEventArgs e) {
			var person = e.Value as Person;
			if (person != null) e.DisplayText = person.FullName;
		}
	}
}