using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Calendar;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using ShomreiTorah.Common;

namespace ShomreiTorah.Billing.Forms {
	partial class DepositAdder : XtraForm {
		public static void Execute(string account) {
			var payments = Program.Data.Payments
				.Where(p => p.Account == account && p.DepositDate == null)
				.OrderBy(p => p.Modified)
				.AsDataView();

			if (payments.Count == 0) {
				XtraMessageBox.Show("There are no undeposited " + account.ToLower(CultureInfo.CurrentUICulture) + " payments.",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			new DepositAdder(payments).ShowDialog();
		}

		IEnumerable<BillingData.PaymentsRow> PaymentRows { get { return payments.Rows<BillingData.PaymentsRow>(); } }

		readonly string account;
		readonly DataView payments;
		readonly bool[] selectedPayments;
		readonly string totalSummary;
		DepositAdder(DataView payments) {
			InitializeComponent();

			this.payments = payments;
			account = (string)payments[0]["Account"];
			selectedPayments = Enumerable.Repeat(true, payments.Count).ToArray();
			Text = "Add " + account + " Deposit";
			grid.DataSource = payments;
			gridView.BestFitColumns();

			totalSummary = String.Format(CultureInfo.CurrentUICulture, "Total: {0:#,0} undeposited payment{1}, {2:c}\r\n",
										 payments.Count, payments.Count == 1 ? "" : "s", PaymentRows.Sum(p => p.Amount));

			UpdateSummary();
		}
		#region DateEdit
		private void depositDate_DrawItem(object sender, CustomDrawDayNumberCellEventArgs e) {
			var hasDeposits = Program.Data.Payments.Any(p => p.DepositDate == e.Date.Date);
			if (hasDeposits)
				e.Style.Font = new Font(e.Style.Font, FontStyle.Bold);
		}

		private void depositDate_Validating(object sender, CancelEventArgs e) {
			if (depositDate.EditValue is DateTime) {
				var depositAmount = Program.Data.Payments.Where(p => p.DepositDate == depositDate.DateTime.Date && p.Account == account).Sum(p => p.Amount);
				if (depositAmount != 0) {
					XtraMessageBox.Show("There is an existing " + account.ToLower(CultureInfo.CurrentUICulture) + " deposit of " + depositAmount.ToString("c", CultureInfo.CurrentUICulture) + " on " + depositDate.DateTime.Date.ToLongDateString() + ".",
										"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
					e.Cancel = true;
				}
			}
		}
		#endregion
		private void depositDate_EditValueChanged(object sender, EventArgs e) {
			SetEnabled();
		}
		void SetEnabled() {
			add.Enabled = depositDate.EditValue is DateTime && selectedPayments.Any(b => b);
		}
		void UpdateSummary() {
			var selPayments = PaymentRows.Where((p, i) => selectedPayments[i]).ToArray();
			summary.Text = totalSummary + String.Format(CultureInfo.CurrentUICulture, "{0:#,0} payment{1} checked, {2:c}",
														selPayments.Length, selPayments.Length == 1 ? "" : "s", selPayments.Sum(p => p.Amount));
		}

		#region Grid
		private void gridView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
			if (e.IsGetData)
				e.Value = selectedPayments[e.ListSourceRowIndex];
			else
				selectedPayments[e.ListSourceRowIndex] = (bool)e.Value;
			UpdateSummary();
			SetEnabled();
		}

		private void gridView_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyData == Keys.Space) {
				foreach (var handle in gridView.GetSelectedRows())
					Invert(handle);
			}
		}
		private void gridView_MouseUp(object sender, MouseEventArgs e) {
			var hitInfo = gridView.CalcHitInfo(e.Location);
			if (hitInfo.InRowCell && hitInfo.Column == colCheck && hitInfo.RowHandle >= 0)
				Invert(hitInfo.RowHandle);
		}

		private void gridView_BeforeLeaveRow(object sender, RowAllowEventArgs e) {
			if (MouseButtons == MouseButtons.Left) {	//Don't change focus when a checkbox is clickedde
				var hitInfo = gridView.CalcHitInfo(grid.PointToClient(MousePosition));
				if (hitInfo.Column == colCheck)
					e.Allow = false;
			}
		}
		void Invert(int rowHandle) {
			gridView.SetRowCellValue(rowHandle, colCheck, !(bool)gridView.GetRowCellValue(rowHandle, colCheck));
		}
		#endregion

		private void add_Click(object sender, EventArgs e) {
			foreach (var payment in PaymentRows.Where((p, i) => selectedPayments[i])) {
				payment.DepositDate = depositDate.DateTime.Date;
			}
			Close();
		}
	}
}