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
			var payments = Program.Data.Payments.CurrentRows()
				.Where(p => p.Account == account && p.IsDepositIdNull())
				.OrderBy(p => p.MasterDirectoryRow.LastName)
				.AsDataView();

			if (payments.Count == 0) {
				XtraMessageBox.Show("There are no undeposited " + account.ToLower(CultureInfo.CurrentCulture) + " payments.",
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
			for (int i = 16; i < selectedPayments.Length; i++)
				selectedPayments[i] = false;

			Text = "Add " + account + " Deposit";
			grid.DataSource = payments;
			gridView.BestFitColumns();

			depositNumber.EditValue = null;

			totalSummary = String.Format(CultureInfo.CurrentCulture, "Total: {0:#,0} undeposited payment{1}, {2:c}\r\n",
										 payments.Count, payments.Count == 1 ? "" : "s", PaymentRows.Sum(p => p.Amount));

			UpdateSummary();
		}
		#region DateEdit
		private void depositDate_DrawItem(object sender, CustomDrawDayNumberCellEventArgs e) {
			var hasDeposits = Program.Data.Deposits.CurrentRows().Any(d => d.Date == e.Date);
			if (hasDeposits)
				e.Style.Font = new Font(e.Style.Font, FontStyle.Bold);
		}

		private void depositDate_EditValueChanged(object sender, EventArgs e) {
			if (depositDate.EditValue is DateTime) {
				depositNumber.Value = Program.Data.Deposits.CurrentRows()
					.Where(d => d.Date == depositDate.DateTime.Date && d.Account == account)
					.Select(d => d.Number)
					.DefaultIfEmpty(0).Max() + 1;
			}
			SetEnabled();
		}
		#endregion
		void SetEnabled() {
			add.Enabled = depositDate.EditValue is DateTime && selectedPayments.Any(b => b);
		}
		void UpdateSummary() {
			var selPayments = PaymentRows.Where((p, i) => selectedPayments[i]).ToArray();
			summary.Text = totalSummary + String.Format(CultureInfo.CurrentCulture, "{0:#,0} payment{1} checked, {2:c}",
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
			var depositRow = Program.Data.Deposits.CurrentRows().FirstOrDefault(d => d.Date == depositDate.DateTime.Date && d.Account == account && d.Number == depositNumber.Value);
			if (depositRow == null)
				depositRow = Program.Data.Deposits.AddDepositsRow(Guid.NewGuid(), depositDate.DateTime.Date, (int)depositNumber.Value, account);
			else {
				var count = selectedPayments.Count(b => b);
				if (count > 1
				 && DialogResult.No == XtraMessageBox.Show("Are you sure you want to add " + count + " payments to the existing deposit #" + depositNumber.Value + " on " + depositDate.DateTime.ToLongDateString() + "?",
														   "Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
					return;
			}
			foreach (var payment in PaymentRows.Where((p, i) => selectedPayments[i])) {
				payment.DepositId = depositRow.DepositId;
			}
			Close();
		}

		private void gridView_CustomColumnSort(object sender, CustomColumnSortEventArgs e) {
			if (e.Column.FieldName == "FullName") {
				var row1 = gridView.GetDataRow(gridView.GetRowHandle(e.ListSourceRowIndex1));
				var row2 = gridView.GetDataRow(gridView.GetRowHandle(e.ListSourceRowIndex2));

				var relation = row1.Table.ParentRelations[0];

				row1 = row1.GetParentRow(relation);
				row2 = row2.GetParentRow(relation);

				e.Result = StringComparer.CurrentCultureIgnoreCase.Compare(row1.Field<string>("LastName"), row2.Field<string>("LastName"));
				if (e.Result == 0)
					e.Result = StringComparer.CurrentCultureIgnoreCase.Compare(row1.Field<string>("HisName"), row2.Field<string>("HisName"));
				if (e.Result == 0)
					e.Result = StringComparer.CurrentCultureIgnoreCase.Compare(row1.Field<string>("HerName"), row2.Field<string>("HerName"));
				e.Handled = true;
			}
		}
	}
}