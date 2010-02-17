using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using ShomreiTorah.Common;

namespace ShomreiTorah.Billing.Forms {
	partial class PaymentViewer : XtraForm {
		public PaymentViewer() {
			InitializeComponent(); 
			SetSelectionButtonsState();
		}

		private void gridView_SelectionChanged(object sender, SelectionChangedEventArgs e) { SetSelectionButtonsState(); }
		void SetSelectionButtonsState() {
			exportWordSelected.Enabled = emailSelected.Enabled = gridView.SelectedRowsCount > 0;
			exportWordSelected.Caption = emailSelected.Caption = gridView.SelectedRowsCount == 1 ? "Selected person" : "Selected people";
		}


		private void personRefEdit_ButtonPressed(object sender, ButtonPressedEventArgs e) {
			var row = gridView.GetFocusedDataRow() as BillingData.PaymentsRow;
			new PersonDetails(row.MasterDirectoryRow) { MdiParent = MdiParent }.Show();
		}

		private void gridView_DoubleClick(object sender, EventArgs e) {
			var row = gridView.GetFocusedDataRow() as BillingData.PaymentsRow;
			if (row != null) new PaymentEditPopup(row).Show(MdiParent);
		}

		private void emailVisible_ItemClick(object sender, ItemClickEventArgs e) { Export.EmailExporter.Execute(GetVisiblePeople()); }
		private void exportWordVisible_ItemClick(object sender, ItemClickEventArgs e) { Export.WordExporter.Execute(GetVisiblePeople()); }

		private void emailSelected_ItemClick(object sender, ItemClickEventArgs e) { Export.EmailExporter.Execute(GetSelectedPeople()); }
		private void exportWordSelected_ItemClick(object sender, ItemClickEventArgs e) { Export.WordExporter.Execute(GetSelectedPeople()); }

		BillingData.MasterDirectoryRow GetPerson(int rowHandle) { return ((BillingData.PaymentsRow)gridView.GetDataRow(rowHandle)).MasterDirectoryRow; }
		BillingData.MasterDirectoryRow[] GetSelectedPeople() { return Array.ConvertAll<int, BillingData.MasterDirectoryRow>(gridView.GetSelectedRows(), GetPerson); }
		//DevExpress grid filter strings aren't completely compatible with DataTable.Select
		BillingData.MasterDirectoryRow[] GetVisiblePeople() {
			if (!gridView.ActiveFilterEnabled || gridView.ActiveFilter.IsEmpty)
				return Program.Data.Pledges.CurrentRows().Select(p => p.MasterDirectoryRow).ToArray();
			else
				return Enumerable.Range(0, gridView.DataRowCount).Select<int, BillingData.MasterDirectoryRow>(GetPerson).ToArray();
		}
	}
}