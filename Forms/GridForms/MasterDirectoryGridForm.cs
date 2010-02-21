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

namespace ShomreiTorah.Billing.Forms.GridForms {
	partial class MasterDirectoryGridForm : GridFormBase {
		public MasterDirectoryGridForm() {
			InitializeComponent();
			gridView.ActiveFilterString = "TotalPledged <> 0 OR TotalPaid <> 0";
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