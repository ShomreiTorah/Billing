using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;

namespace ShomreiTorah.Billing.Forms {
	partial class DepositViewer : XtraForm {
		public DepositViewer() {
			InitializeComponent();
			Program.Data.Payments.ColumnChanged += Payments_ColumnChanged;
			BindGrid();
		}

		void Payments_ColumnChanged(object sender, DataColumnChangeEventArgs e) {
			if (e.Column == Program.Data.Payments.DepositDateSqlColumn
			 || e.Column == Program.Data.Payments.AmountColumn
			 || e.Column == Program.Data.Payments.AccountColumn)
				BindGrid();
		}

		void BindGrid() {
			grid.DataMember = "";
			grid.DataSource = (from payment in Program.Data.Payments
							   where payment.DepositDate.HasValue
							   group payment by new { payment.Account, Date = payment.DepositDate.Value } into g
							   select new {
								   g.Key.Account,
								   g.Key.Date,
								   Amount = g.Sum(p => p.Amount),
								   Count = g.Count(),
								   Payments = Program.Data.Payments.Where(p => p.Account == g.Key.Account && p.DepositDate == g.Key.Date).AsDataView()
							   }).ToArray();
		}
		private void depositsView_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e) {
			if (e.SummaryProcess == CustomSummaryProcess.Finalize) {
				var account = (string)depositsView.GetGroupRowValue(e.GroupRowHandle);
				e.TotalValue = Program.Data.Payments.Where(p => p.Account == account && p.DepositDate == null).Sum(p => p.Amount);
			}
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null) components.Dispose();
				Program.Data.Payments.ColumnChanged -= Payments_ColumnChanged;
			}
			base.Dispose(disposing);
		}

		private void personRefEdit_ButtonClick(object sender, ButtonPressedEventArgs e) {
			var view = (GridView)grid.FocusedView;
			var row = view.GetFocusedDataRow();
			new PersonDetails((BillingData.MasterDirectoryRow)row.GetParentRow(row.Table.ParentRelations[0])) { MdiParent = MdiParent }.Show();
		}

		private void depositsView_DoubleClick(object sender, EventArgs e) {
			var hitInfo = depositsView.CalcHitInfo(grid.PointToClient(MousePosition));
			if (hitInfo.InRow && hitInfo.RowHandle >= 0)
				depositsView.SetMasterRowExpanded(hitInfo.RowHandle, !depositsView.GetMasterRowExpanded(hitInfo.RowHandle));
		}
	}
}