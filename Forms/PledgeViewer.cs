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
	partial class PledgeViewer : XtraForm {
		public PledgeViewer() { InitializeComponent(); }

		private void personRefEdit_ButtonPressed(object sender, ButtonPressedEventArgs e) {
			var row = gridView.GetFocusedDataRow() as BillingData.PledgesRow;
			new PersonDetails(row.MasterDirectoryRow) { MdiParent = MdiParent }.Show();
		}
	}
}