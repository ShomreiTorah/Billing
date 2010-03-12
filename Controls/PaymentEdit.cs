using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ShomreiTorah.Common;
using ShomreiTorah.WinForms.Controls;
using ShomreiTorah.WinForms.Forms;

namespace ShomreiTorah.Billing.Controls {
	partial class PaymentEdit : XtraUserControl {
		public PaymentEdit() {
			InitializeComponent();

			account.Properties.Items.Clear();
			account.Properties.Items.AddRange(BillingData.AccountNames);
			method.Properties.Items.Clear();
			method.Properties.Items.AddRange(BillingData.PaymentMethods);

			if (Program.Data != null)	//Bugfix for nested designer
				paymentsBindingSource.DataSource = Program.Data;
		}

		protected override void OnLayout(LayoutEventArgs e) {
			base.OnLayout(e);
			person.MaxPopupHeight = Height - person.Bottom;
		}
		void SetCommentsHeight() {
			if (commit.Visible)
				comments.Height = method.Bottom - comments.Top;
			else
				comments.Height = checkNumber.Bottom - comments.Top;
		}
		private void commit_VisibleChanged(object sender, EventArgs e) { SetCommentsHeight(); }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public BillingData.PaymentsRow CurrentPayment {
			get { return paymentsBindingSource.Current == null ? null : (BillingData.PaymentsRow)((DataRowView)paymentsBindingSource.Current).Row; }
			set {
				if (value == null) return;
				paymentsBindingSource.Position = paymentsBindingSource.Find("PaymentId", value.PaymentId);
				commit.Hide();
				SetCommentsHeight();	//For some reason, VisibleChanged doesn't fire.
			}
		}

		public void AddNew() {
			commit.CommitType = CommitType.Create;
			commit.Show();
			paymentsBindingSource.AddNew();
			person.Focus();
		}

		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Error message")]
		private void commit_Click(object sender, EventArgs e) {
			if (!commit.Visible) {
				Debug.Assert(false, "How was commit clicked?");
				return;
			}
			var payment = CurrentPayment;
			if (payment == null) {
				XtraMessageBox.Show("Something's wrong.");
				return;
			}
			#region Check for errors
			if (person.SelectedPerson == null) {
				XtraMessageBox.Show("Please select the person who made the payment.",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (payment.IsNull("Date")) {
				XtraMessageBox.Show("Please enter a date.",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (payment.IsNull("Amount")) {
				XtraMessageBox.Show("Please enter the amount paid.",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (payment.IsNull("Account")) {
				XtraMessageBox.Show("Please select the account.",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (payment.IsNull("Method")) {
				XtraMessageBox.Show("Please enter select the payment method.",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			string message = CurrentPayment.CheckDuplicateWarning(checkNumber.Text, true);
			if (!string.IsNullOrEmpty(message)
			 && DialogResult.No == XtraMessageBox.Show(message, "Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
				return;

			#endregion
			if (payment.Amount <= 0) {
				XtraMessageBox.Show("Amount must be positive",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			decimal autoPledgeAmount = 0;
			decimal currentBalance = person.SelectedPerson.GetBalance(account.Text);
			if (payment.Amount > currentBalance) {
				using (var prompt = new Forms.AutoPledgePrompt(payment)) {
					switch (prompt.ShowDialog()) {
						case DialogResult.Cancel: return;
						case DialogResult.Ignore:	//Do nothing, and keep a negative balance
							Email.Notify("Negative balance for " + person.SelectedPerson.FullName,
								String.Format(CultureInfo.CurrentCulture, @"Added by {0}\{1}
{2}

Current balance:	{3:c}
Payment:	{4:c} {5} for {6} on {7:d}
{8}", Environment.MachineName, Environment.UserName,
 new PersonData(person.SelectedPerson).ToFullString(),
 currentBalance,
 payment.Amount, payment.Method.ToLower(CultureInfo.CurrentUICulture), payment.Account.ToLower(CultureInfo.CurrentUICulture), payment.Date, payment.Comments));
							break;
						case DialogResult.Yes:				//Add pledge
							var newRow = Program.Data.Pledges.NewPledgesRow();

							newRow.PledgeId = Guid.NewGuid();
							newRow.PersonId = person.SelectedPerson.Id;
							newRow.Date = date.DateTime;
							newRow.Type = "Donation";
							newRow.Account = account.Text;
							autoPledgeAmount = newRow.Amount = payment.Amount - currentBalance;
							newRow.Comments = ("Automatically added donation pledge\r\n\r\n" + comments.Text).Trim();

							Program.Data.Pledges.AddPledgesRow(newRow);
							break;
					}
				}
			}

			if (payment.IsNull("PaymentId"))
				payment.PaymentId = Guid.NewGuid();

			try {
				paymentsBindingSource.EndEdit();
			} catch (Exception ex) {
				XtraMessageBox.Show("Couldn't add payment.\r\n" + ex.Message, "Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (commit.CommitType == CommitType.Create) {
				if (autoPledgeAmount > 0)
					InfoMessage.Show(String.Format(CultureInfo.CurrentUICulture, "A {0:c} payment and a {1:c} donation pledge have been added for {2}", payment.Amount, autoPledgeAmount, payment.MasterDirectoryRow.FullName));
				else
					InfoMessage.Show(String.Format(CultureInfo.CurrentUICulture, "A {0:c} payment has been added for {1}", payment.Amount, payment.MasterDirectoryRow.FullName));
				AddNew();
			}
		}

		private void method_EditValueChanged(object sender, EventArgs e) {
			//It can be DBNull
			checkNumber.Visible = checkNumberLabel.Visible = method.EditValue as string == "Check";
			checkNumber.EditValue = null;
		}

		private void person_ItemSelected(object sender, ItemSelectionEventArgs e) {
			date.Focus();
		}

		private void Input_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyData == Keys.Enter && commit.Visible)
				commit.PerformClick();
		}

		private void person_SelectingPerson(object sender, SelectingPersonEventArgs e) {
			if (e.Person != person.SelectedPerson
			 && !commit.Visible
			 && DialogResult.No == XtraMessageBox.Show("Are you sure you want to change this payment to be associated with " + e.Person.VeryFullName + "?",
													   "Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
				e.Cancel = true;
		}

		private void checkNumber_Validating(object sender, CancelEventArgs e) {
			string message = CurrentPayment.CheckDuplicateWarning(checkNumber.Text, false);
			e.Cancel = !string.IsNullOrEmpty(message)
					&& DialogResult.No == XtraMessageBox.Show(message, "Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
		}
	}
}
