using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ShomreiTorah.Billing.Forms {
	partial class PledgeEditPopup : XtraForm {
		readonly BillingData.PledgesRow pledge;
		public PledgeEditPopup(BillingData.PledgesRow pledge) {
			InitializeComponent();
			ClientSize = pledgeEdit.Size;

			pledgeEdit.CurrentPledge = this.pledge = pledge;
			Program.Data.Pledges.PledgesRowDeleted += Pledges_PledgesRowDeleted;
		}

		void Pledges_PledgesRowDeleted(object sender, BillingData.PledgesRowChangeEvent e) {
			if (e.Row == pledge)
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
				Program.Data.Pledges.PledgesRowDeleted -= Pledges_PledgesRowDeleted;
				if (components != null) components.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}