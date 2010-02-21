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
using System.Globalization;
using ShomreiTorah.Common;

namespace ShomreiTorah.Billing.Forms {
	partial class DepositViewer : XtraForm {
		public DepositViewer() {
			InitializeComponent();
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null) components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void depositsView_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e) {
			if (e.SummaryProcess == CustomSummaryProcess.Finalize) {
				var account = (string)depositsView.GetGroupRowValue(e.GroupRowHandle);
				e.TotalValue = Program.Data.Payments.CurrentRows().Where(p => p.Account == account && p.IsDepositIdNull()).Sum(p => p.Amount);
			}
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

		private void paymentsView_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyData == Keys.Delete) {
				var view = (sender as GridView) ?? (GridView)((Controls.BaseGrid)((BaseEdit)sender).Parent).FocusedView;
				var rows = view.GetSelectedRows().Select<int, DataRow>(view.GetDataRow).Cast<BillingData.PaymentsRow>().ToArray();

				string message;
				if (rows.Length == 1)
					message = "Are you sure you want to mark this " + rows[0].Amount.ToString("c", CultureInfo.CurrentUICulture) + " payment as undeposited?";
				else
					message = "Are you sure you want to mark " + rows.Length + " payments totaling " + rows.Sum(p => p.Amount).ToString("c", CultureInfo.CurrentUICulture) + " as undeposited?";

				if (DialogResult.Yes == XtraMessageBox.Show(message, "Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) {
					foreach (var payment in rows) {
						payment.SetDepositIdNull();
					}

					depositsView.RefreshData();
				}
			}
		}
	}
}