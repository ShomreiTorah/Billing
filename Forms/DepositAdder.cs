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
				.Where(p => p.Account == account && p.Deposit == null && p.NeedsDeposit)
				.OrderBy(p => p.Person.LastName)
				.ToList();

			if (payments.Count == 0) {
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
		DepositAdder(IList<Payment> payments) {
			InitializeComponent();

			this.payments = payments;
			account = (string)payments[0]["Account"];

			selectedPayments = new bool[payments.Count];
			for (int i = 0; i < 16; i++)
				selectedPayments[i] = true;

			Text = "Add " + account + " Deposit";
			grid.DataSource = new RowListBinder(Program.Table<Payment>(), (Row[])payments);
			gridView.BestFitColumns();

			depositNumber.EditValue = null;

			totalSummary = String.Format(CultureInfo.CurrentCulture, "Total: {0:#,0} undeposited payment{1}, {2:c}\r\n",
										 payments.Count, payments.Count == 1 ? "" : "s", payments.Sum(p => p.Amount));

			UpdateSummary();
			CheckableGridController.Handle(colCheck);
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

		private void gridView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
			if (e.Column == colCheck) {
				if (e.IsGetData)
					e.Value = selectedPayments[e.ListSourceRowIndex];
				else {
					selectedPayments[e.ListSourceRowIndex] = (bool)e.Value;
					UpdateSummary();
					SetEnabled();
				}
			}
		}
		private void gridView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e) {
			if (e.Column == colFullName) {
				var person = e.Value as Person;
				if (person != null)
					e.DisplayText = person.FullName;
			}
		}

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
	}
}