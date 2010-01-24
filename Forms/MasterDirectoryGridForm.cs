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
using DevExpress.XtraGrid.Views.Grid;

namespace ShomreiTorah.Billing.Forms {
	partial class MasterDirectoryGridForm : XtraForm {
		public MasterDirectoryGridForm() {
			InitializeComponent();
			gridView.ActiveFilterString = "TotalPledged <> 0 OR TotalPaid <> 0";
			SetSelectionButtonsState();
		}

		private void gridView_SelectionChanged(object sender, SelectionChangedEventArgs e) { SetSelectionButtonsState(); }
		void SetSelectionButtonsState() {
			exportWordSelected.Enabled = emailSelected.Enabled = gridView.SelectedRowsCount > 0;
			exportWordSelected.Caption = emailSelected.Caption = gridView.SelectedRowsCount == 1 ? "Selected person" : "Selected people";
		}

		private void emailSelected_ItemClick(object sender, ItemClickEventArgs e) {
			Export.EmailExporter.Execute(Array.ConvertAll(gridView.GetSelectedRows(), h => (BillingData.MasterDirectoryRow)gridView.GetDataRow(h)));
		}
		private void emailVisible_ItemClick(object sender, ItemClickEventArgs e) {
			Export.EmailExporter.Execute(GetVisibleRows());
		}
		private void exportWordSelected_ItemClick(object sender, ItemClickEventArgs e) {
			Export.WordExporter.Execute(Array.ConvertAll(gridView.GetSelectedRows(), h => (BillingData.MasterDirectoryRow)gridView.GetDataRow(h)));
		}
		private void exportWordVisible_ItemClick(object sender, ItemClickEventArgs e) {
			Export.WordExporter.Execute(GetVisibleRows());
		}

		BillingData.MasterDirectoryRow[] GetVisibleRows() {
			if (!gridView.ActiveFilterEnabled || gridView.ActiveFilter.IsEmpty)
				return (BillingData.MasterDirectoryRow[])Program.Data.MasterDirectory.Select();
			else
				return Enumerable.Range(0, gridView.DataRowCount).Select(i => (BillingData.MasterDirectoryRow)gridView.GetDataRow(i)).ToArray();
			//DevExpress grid filter strings aren't completely compatible with DataTable.Select
		}

		private void gridView_DoubleClick(object sender, EventArgs e) {
			var rowHandle = gridView.CalcHitInfo(grid.PointToClient(MousePosition)).RowHandle;
			if (rowHandle >= 0)
				new PersonDetails((BillingData.MasterDirectoryRow)gridView.GetDataRow(rowHandle)) { MdiParent = MdiParent }.Show();
		}

		private void paymentsView_DoubleClick(object sender, EventArgs e) {
			var row = ((GridView)sender).GetFocusedDataRow() as BillingData.PaymentsRow;
			if (row != null) new PaymentEditPopup(row).Show(MdiParent);
		}
		private void pledgesView_DoubleClick(object sender, EventArgs e) {
			var row = ((GridView)sender).GetFocusedDataRow() as BillingData.PledgesRow;
			if (row != null) new PledgeEditPopup(row).Show(MdiParent);
		}
	}
}