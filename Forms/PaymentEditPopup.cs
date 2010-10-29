using System.Windows.Forms;
using DevExpress.XtraEditors;
using ShomreiTorah.Data;
using ShomreiTorah.Singularity;

namespace ShomreiTorah.Billing.Forms {
	partial class PaymentEditPopup : XtraForm {
		readonly Payment payment;
		public PaymentEditPopup(Payment payment) {
			InitializeComponent();
			paymentEdit.CurrentPayment = this.payment = payment;
			Program.Table<Payment>().RowRemoved += Paymens_RowRemoved;
			ClientSize = paymentEdit.Size;
		}

		void Paymens_RowRemoved(object sender, RowListEventArgs<Payment> e) {
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
				Program.Table<Payment>().RowRemoved -= Paymens_RowRemoved;
				if (components != null) components.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}