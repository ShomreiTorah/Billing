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
	partial class ModifiedPaymentsGrid : XtraUserControl {
		public ModifiedPaymentsGrid() {
			InitializeComponent();
			gridView.ActiveFilterCriteria = new OperandProperty("Modified") > Program.LaunchTime.ToUniversalTime();
			if (Program.Data != null)
				Program.Data.Payments.RowChanged += Payments_RowChanged;
		}

		void Payments_RowChanged(object sender, DataRowChangeEventArgs e) {
			//if (e.Action != DataRowAction.Add) return;

			gridView.BestFitColumns();
			Program.Data.Payments.RowChanged -= Payments_RowChanged;
		}
	}
}
