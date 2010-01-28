using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace ShomreiTorah.Billing.Controls {
	partial class ModifiedPledgesGrid : XtraUserControl {
		public ModifiedPledgesGrid() {
			InitializeComponent();
			gridView.ActiveFilterCriteria = new OperandProperty("Modified") > Program.LaunchTime.ToUniversalTime();
			if (Program.Data != null)
				Program.Data.Pledges.RowChanged += Pledges_RowChanged;
		}

		///<summary>Gets or sets the main form, which all MDI child forms will be shown in.</summary>
		[Description("Gets or sets the main form, which all MDI child forms will be shown in.")]
		[Category("Behavior")]
		public Form MainForm { get; set; }

		private void gridView_DoubleClick(object sender, EventArgs e) {
			var row = (BillingData.PledgesRow)gridView.GetFocusedDataRow();
			new Forms.PledgeEditPopup(row).Show(MainForm);
		}

		private void personRefEdit_ButtonClick(object sender, ButtonPressedEventArgs e) {
			var row = (BillingData.PledgesRow)gridView.GetFocusedDataRow();
			new Forms.PersonDetails(row.MasterDirectoryRow) { MdiParent = MainForm }.Show();
		}

		void Pledges_RowChanged(object sender, DataRowChangeEventArgs e) {
			//if (e.Action != DataRowAction.Add) return;

			gridView.BestFitColumns();
			Program.Data.Pledges.RowChanged -= Pledges_RowChanged;
		}
	}
}
