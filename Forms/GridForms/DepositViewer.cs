using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI.DisplaySettings;
using ShomreiTorah.WinForms;

namespace ShomreiTorah.Billing.Forms.GridForms {
	partial class DepositViewer : XtraForm {
		public DepositViewer() {
			InitializeComponent();
			ToggleRowsBehavior.Instance.Apply(depositsView);
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null) components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void depositsView_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e) {
			if (depositsView.GroupedColumns[e.GroupLevel].FieldName == "Account") {
				if (e.SummaryProcess == CustomSummaryProcess.Finalize) {
					var account = (string)depositsView.GetGroupRowValue(e.GroupRowHandle);
					e.TotalValue = Program.Table<Payment>().Rows.Where(p => p.Account == account && p.Deposit == null && p.NeedsDeposit).Sum(p => p.Amount);
				}
			}
		}

		private void paymentsView_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyData == Keys.Delete) {
				var view = (sender as GridView) ?? (ColumnView)((GridControl)((BaseEdit)sender).Parent).FocusedView;
				var rows = view.GetSelectedRows().Select<int, object>(view.GetRow)
							   .DefaultIfEmpty(view.GetFocusedRow())
							   .Cast<Payment>()
							   .ToArray();

				string message;
				if (rows.Length == 1)
					message = "Are you sure you want to mark this " + rows[0].Amount.ToString("c", CultureInfo.CurrentCulture) + " payment as undeposited?";
				else
					message = "Are you sure you want to mark " + rows.Length + " payments totaling " + rows.Sum(p => p.Amount).ToString("c", CultureInfo.CurrentCulture) + " as undeposited?";

				if (Dialog.Warn(message)) {
					//This code can end up deleting the child 
					//view (if the last payment in the deposit
					//is deleted), which will break the grid's
					//keyboard code.
					BeginInvoke(new Action(delegate {
						foreach (var payment in rows)
							payment.Deposit = null;
						depositsView.RefreshData();
					}));
				}
			}
		}
	}
}