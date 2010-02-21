using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace ShomreiTorah.Billing.Forms.GridForms {
	partial class EmailListForm : GridFormBase {
		public EmailListForm() {
			InitializeComponent();
		}

		BillingData.EmailListRow SelectedRow { get { return gridView.GetFocusedDataRow() as BillingData.EmailListRow; } }

		bool changingRow;
		private void gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e) {
			if (SelectedRow == null)
				personSelector.Hide();
			else {
				try {
					changingRow = true;
					personSelector.SelectedPerson = SelectedRow.MasterDirectoryRow;
				} finally { changingRow = false; }

				personSelector.Show();
			}
		}

		private void personSelector_SelectedPersonChanged(object sender, EventArgs e) {
			if (changingRow) return;

			//The grid might be sorted by FullName
			var nextRow = (gridView.GetNextVisibleRow(gridView.GetVisibleIndex(gridView.FocusedRowHandle)));

			SelectedRow.MasterDirectoryRow = personSelector.SelectedPerson;
			if (nextRow > 0 && ModifierKeys == 0) {
				gridView.FocusedRowHandle = gridView.GetVisibleRowHandle(nextRow);
				gridView.TopRowIndex = Math.Max(nextRow - 2, 0);
			}
		}

		private void personEdit_ButtonClick(object sender, ButtonPressedEventArgs e) {
			if (e.Button.Caption == "Clear") {
				SelectedRow.SetPersonIdNull();
				gridView.RefreshRow(gridView.FocusedRowHandle);
				gridView.FocusedColumn = null;
				try {
					changingRow = true;
					personSelector.SelectedPerson = null;
				} finally { changingRow = false; }
			} else
				new PersonDetails(SelectedRow.MasterDirectoryRow) { MdiParent = MdiParent }.Show();
		}

		private void gridView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e) {
			if (e.Column == colFullName) {
				e.RepositoryItem = (e.CellValue == DBNull.Value) ? emptyPersonEdit : personEdit;
			}
		}
	}
}