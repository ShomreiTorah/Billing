using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Controls;

namespace ShomreiTorah.Billing.Forms {
	partial class PaymentViewer : XtraForm {
		public PaymentViewer() { InitializeComponent(); }

		private void personRefEdit_ButtonPressed(object sender, ButtonPressedEventArgs e) {
			var row = gridView.GetFocusedDataRow() as BillingData.PaymentsRow;
			new PersonDetails(row.MasterDirectoryRow) { MdiParent = MdiParent }.Show();
		}

		private void gridView_DoubleClick(object sender, EventArgs e) {
			var row = gridView.GetFocusedDataRow() as BillingData.PaymentsRow;
			if (row != null) new PaymentEditPopup(row).Show(MdiParent);
		}
	}
}