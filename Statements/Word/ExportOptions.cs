using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout.Utils;
using ShomreiTorah.Statements;

namespace ShomreiTorah.Billing.Statements.Word {
	partial class ExportOptions : XtraForm {
		public ExportOptions() {
			InitializeComponent();
			startDate.DateTime = new DateTime(DateTime.Today.AddDays(-80).Year, 1, 1);
			startDate.Properties.MaxValue = DateTime.Today;

			docTypes.Items.Add(StatementKind.Bill);
			docTypes.Items.Add(StatementKind.Receipt);
		}
		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			MinimumSize = Size;
		}

		private void docTypes_ItemCheck(object sender, ItemCheckEventArgs e) {
			skipNonStaleReceiptsItem.Visibility = Kinds.Contains(StatementKind.Receipt) ? LayoutVisibility.Always : LayoutVisibility.Never;
			ok.Enabled = docTypes.CheckedItems.Count > 0;
		}

		public bool SkipEmail => skipEmail.Checked;
		public bool ResendExistingReceipts => !skipNonStaleReceipts.Checked;
		public DateTime StartDate { get { return startDate.DateTime.Date; } }
		public IEnumerable<StatementKind> Kinds { get { return docTypes.CheckedItems.Cast<CheckedListBoxItem>().Select(i => (StatementKind)i.Value); } }
	}
}