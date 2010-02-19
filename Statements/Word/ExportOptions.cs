using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace ShomreiTorah.Billing.Export {
	partial class ExportOptions : XtraForm {
		public ExportOptions() {
			InitializeComponent();
			startDate.DateTime = new DateTime(DateTime.Today.AddDays(-80).Year, 1, 1);
			startDate.Properties.MaxValue = DateTime.Today;

			docTypes.Items.Add(BillKind.Bill);
			docTypes.Items.Add(BillKind.Receipt);
		}
		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			MinimumSize = Size;
		}

		private void docTypes_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e) {
			ok.Enabled = docTypes.CheckedItems.Count > 0;
		}

		public DateTime StartDate { get { return startDate.DateTime.Date; } }
		public IEnumerable<BillKind> Kinds { get { return docTypes.CheckedItems.Cast<CheckedListBoxItem>().Select(i => (BillKind)i.Value); } }
	}
}