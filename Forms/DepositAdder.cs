using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Calendar;
using DevExpress.XtraGrid.Views.Base;
using ShomreiTorah.Data;
using ShomreiTorah.Singularity;
using ShomreiTorah.Singularity.DataBinding;
using ShomreiTorah.WinForms;

namespace ShomreiTorah.Billing.Forms {
	partial class DepositAdder : XtraForm {
		public static void Execute(string account) {
			var payments = Program.Table<Payment>().Rows
				.Where(p => p.Account == account && p.Deposit == null)
				.OrderBy(p => p.Person.LastName)
				.ToArray();

			if (payments.Length == 0) {
				XtraMessageBox.Show("There are no undeposited " + account.ToLower(CultureInfo.CurrentCulture) + " payments.",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			new DepositAdder(payments).ShowDisposingDialog();
		}

		readonly string account;
		readonly IList<Payment> payments;
		readonly bool[] selectedPayments;
		readonly string totalSummary;
		DepositAdder(Payment[] payments) {
			InitializeComponent();

			this.payments = payments;
			account = (string)payments[0]["Account"];

			selectedPayments = Enumerable.Repeat(true, payments.Length).ToArray();
			for (int i = 16; i < selectedPayments.Length; i++)
				selectedPayments[i] = false;

			Text = "Add " + account + " Deposit";
			grid.DataSource = new RowListBinder(Program.Table<Payment>(), (Row[])payments);
			gridView.BestFitColumns();

			depositNumber.EditValue = null;

			totalSummary = String.Format(CultureInfo.CurrentCulture, "Total: {0:#,0} undeposited payment{1}, {2:c}\r\n",
										 payments.Length, payments.Length == 1 ? "" : "s", payments.Sum(p => p.Amount));

			UpdateSummary();
		}
		#region DateEdit
		private void depositDate_DrawItem(object sender, CustomDrawDayNumberCellEventArgs e) {
			var hasDeposits = Program.Table<Deposit>().Rows.Any(d => d.Date == e.Date);
			if (hasDeposits)
				e.Style.Font = new Font(e.Style.Font, FontStyle.Bold);
		}

		private void depositDate_EditValueChanged(object sender, EventArgs e) {
			if (depositDate.EditValue is DateTime) {
				depositNumber.Value = Program.Table<Deposit>().Rows
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
			var selPayments = payments.Where((p, i) => selectedPayments[i]).ToArray();
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
			if (MouseButtons == MouseButtons.Left) {	//Don't change focus when a checkbox is clicked
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
			var depositRow = Program.Table<Deposit>().Rows.FirstOrDefault(d => d.Date == depositDate.DateTime.Date && d.Account == account && d.Number == depositNumber.Value);

			if (depositRow == null) {
				depositRow = new Deposit {
					Date = depositDate.DateTime.Date,
					Number = (int)depositNumber.Value,
					Account = account
				};
				Program.Table<Deposit>().Rows.Add(depositRow);
			} else {
				var count = selectedPayments.Count(b => b);
				if (count > 1
				 && DialogResult.No == XtraMessageBox.Show("Are you sure you want to add " + count + " payments to the existing deposit #" + depositNumber.Value + " on " + depositDate.DateTime.ToLongDateString() + "?",
														   "Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
					return;
			}
			foreach (var payment in payments.Where((p, i) => selectedPayments[i])) {
				payment.Deposit = depositRow;
			}
			Close();
		}

		private void gridView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e) {
			if (e.Column == colFullName) {
				var person = e.Value as Person;
				if (person != null)
					e.DisplayText = person.FullName;
			}
		}
	}
}