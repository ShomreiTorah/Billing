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

namespace ShomreiTorah.Billing.Forms.GridForms {
	partial class PledgeViewer : GridFormBase {
		public PledgeViewer() { InitializeComponent(); }

		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			colNote.Width = 150;
			colComments.Width = 120;
		}
		private void personRefEdit_ButtonPressed(object sender, ButtonPressedEventArgs e) {
			var row = gridView.GetFocusedDataRow() as BillingData.PledgesRow;
			new PersonDetails(row.MasterDirectoryRow) { MdiParent = MdiParent }.Show();
		}

		private void gridView_DoubleClick(object sender, EventArgs e) {
			var row = gridView.GetFocusedDataRow() as BillingData.PledgesRow;
			if (row != null) new PledgeEditPopup(row).Show(MdiParent);
		}
	}
}