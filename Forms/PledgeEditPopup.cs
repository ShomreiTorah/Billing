using System.Windows.Forms;
using DevExpress.XtraEditors;
using ShomreiTorah.Data;
using ShomreiTorah.Singularity;

namespace ShomreiTorah.Billing.Forms {
	partial class PledgeEditPopup : XtraForm {
		readonly Pledge pledge;
		public PledgeEditPopup(Pledge pledge) {
			InitializeComponent();
			ClientSize = pledgeEdit.Size;

			pledgeEdit.CurrentPledge = this.pledge = pledge;
			Program.Table<Pledge>().RowRemoved += PledgeEditPopup_RowRemoved;
		}

		void PledgeEditPopup_RowRemoved(object sender, RowListEventArgs<Pledge> e) {
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
				Program.Table<Pledge>().RowRemoved -= PledgeEditPopup_RowRemoved;
				if (components != null) components.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}