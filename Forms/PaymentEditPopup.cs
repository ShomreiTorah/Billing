using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ShomreiTorah.Billing.Forms {
	partial class PaymentEditPopup : DevExpress.XtraEditors.XtraForm {
		readonly BillingData.PaymentsRow payment;
		public PaymentEditPopup(BillingData.PaymentsRow payment) {
			InitializeComponent();
			paymentEdit.CurrentPayment = this.payment = payment;
			Program.Data.Payments.PaymentsRowDeleted += Payments_PaymentsRowDeleted;
			ClientSize = paymentEdit.Size;
		}

		void Payments_PaymentsRowDeleted(object sender, BillingData.PaymentsRowChangeEvent e) {
			if (e.Row == payment)
				Close();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
			if (keyData == Keys.Escape) {
				Close();
				return false;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}
		protected override void Dispose(bool disposing) {
			if (disposing) {
				Program.Data.Payments.PaymentsRowDeleted -= Payments_PaymentsRowDeleted;
				if (components != null) components.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}