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

		void Pledges_RowChanged(object sender, DataRowChangeEventArgs e) {
			//if (e.Action != DataRowAction.Add) return;

			gridView.BestFitColumns();
			Program.Data.Pledges.RowChanged -= Pledges_RowChanged;
		}
	}
}
