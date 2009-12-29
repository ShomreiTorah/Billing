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

namespace ShomreiTorah.Billing.Forms {
	partial class MasterDirectoryGridForm : XtraForm {
		public MasterDirectoryGridForm() {
			InitializeComponent();
			gridView.ActiveFilterString = "TotalPledged <> 0 OR TotalPaid <> 0";
			SetSelectionButtonsState();
		}

		private void gridView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			SetSelectionButtonsState();
		}

		void SetSelectionButtonsState() {
			emailSelected.Enabled = gridView.SelectedRowsCount > 0;
			emailSelected.Caption = gridView.SelectedRowsCount == 1 ? "Email Selected Person" : "Email Selected People";

			exportWordSelected.Enabled = gridView.SelectedRowsCount > 0;
			exportWordSelected.Caption = gridView.SelectedRowsCount == 1 ? "Selected Person" : "Selected People";
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
	}
}