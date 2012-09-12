using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ShomreiTorah.Common;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI;
using ShomreiTorah.Data.UI.Controls;
using ShomreiTorah.WinForms;
using ShomreiTorah.WinForms.Forms;

namespace ShomreiTorah.Billing.Controls {
	partial class PaymentEdit : XtraUserControl {
		public PaymentEdit() {
			InitializeComponent();

			//TODO: Replace with ESA
			account.Properties.Items.Clear();
			account.Properties.Items.AddRange(Names.AccountNames);
			method.Properties.Items.Clear();
			method.Properties.Items.AddRange(Names.PaymentMethods);

			paymentsBindingSource.DataSource = Program.Current.DataContext;
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
		public Payment CurrentPayment {
			get { return (Payment)paymentsBindingSource.Current; ; }
			set {
				if (value == null) return;
				paymentsBindingSource.Position = paymentsBindingSource.IndexOf(value);
				commit.Hide();
				SetCommentsHeight();	//For some reason, VisibleChanged doesn't fire.
			}
		}

		public void AddNew() {
			if (CurrentPayment.Table == null)
				RemoveLinks();
			paymentsBindingSource.CancelEdit();

			commit.CommitType = CommitType.Create;
			commit.Show();
			paymentsBindingSource.AddNew();
			person.Focus();
		}


		///<summary>Removes all PledgeLinks created by the user when creating an uncommitted payment.</summary>
		///<remarks>This method should not be called for payments that are already in the table; the Payment class will handle those automatically.</remarks>
		public void RemoveLinks() {
			//If there is no current payment, this will be null.
			if (pledgeLinks.Links != null)
				pledgeLinks.Links.Clear();
		}

		#region Creation
		private bool ValidateCreation() {
			var payment = CurrentPayment;

			if (person.SelectedPerson == null) {
				XtraMessageBox.Show("Please select the person who made the payment.",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			//The strongly-typed properties aren't nullable, so I can't use them
			if (payment["Date"] == null) {
				XtraMessageBox.Show("Please enter a date.",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (payment["Amount"] == null) {
				XtraMessageBox.Show("Please enter the amount paid.",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (payment["Account"] == null) {
				XtraMessageBox.Show("Please select the account.",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (payment["Method"] == null) {
				XtraMessageBox.Show("Please enter select the payment method.",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (payment.Amount <= 0) {
				XtraMessageBox.Show("Amount must be positive",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			Payment duplicate = CurrentPayment.FindDuplicate(checkNumber.Text);
			if (duplicate != null
			 && !Dialog.Warn(String.Format(CultureInfo.CurrentCulture, "{0} #{1} for {2} has already been entered ({3:d}, {4:c}).\r\nIs that correct?",
																	  duplicate.Method, duplicate.CheckNumber, duplicate.Person.FullName, duplicate.Date, duplicate.Amount)))
				return false;

			return true;
		}

		[SuppressMessage("Microsoft.Globalization", "CA1304:SpecifyCultureInfo", MessageId = "System.String.ToLower", Justification = "UI casing")]
		private bool CheckMigration() {
			var memberPledges = person.SelectedPerson.RelatedMembers
				.SelectMany(r => r.Member.Pledges.Where(p => new AliyahNote(p.Note).Relative == r.RelationType))
				.ToList();
			if (memberPledges.Any()) {
				using (var dialog = new Forms.PledgeMigrator(person.SelectedPerson, memberPledges)) {
					if (dialog.ShowDialog() != DialogResult.OK)
						return false;
					foreach (var pledge in dialog.SelectedPledges) {	//This query is based purely on the dialog and isn't modified by the loop.
						//Move the relative from the Note to the Comments
						var note = new AliyahNote(pledge.Note);

						pledge.Comments = ("Moved from " + pledge.Person.FullName + " to his " + note.Relative.ToLower() + "\r\n" + pledge.Comments).Trim();

						note.Relative = null;
						pledge.Note = note.Text;	//Without the relative

						pledge.Person = person.SelectedPerson;
					}
				}
			}
			return true;
		}

		decimal? CheckAutoPledge() {
			var payment = CurrentPayment;
			decimal autoPledgeAmount = 0;
			decimal currentBalance = person.SelectedPerson.GetBalance(account.Text);
			if (payment.Amount > currentBalance) {
				using (var prompt = new Forms.AutoPledgePrompt(payment)) {
					switch (prompt.ShowDialog()) {
						case DialogResult.Cancel: return null;
						case DialogResult.Ignore:	//Do nothing, and keep a negative balance
							Email.Notify("Negative balance for " + person.SelectedPerson.FullName,
								String.Format(CultureInfo.CurrentCulture, @"Added by {0}\{1}
{2}

Current balance:	{3:c}
Payment:	{4:c} {5} for {6} on {7:d}
{8}", Environment.MachineName, Environment.UserName,
 new PersonData(person.SelectedPerson).ToFullString(),
 currentBalance,
 payment.Amount, payment.Method.ToLower(CultureInfo.CurrentCulture), payment.Account.ToLower(CultureInfo.CurrentCulture), payment.Date, payment.Comments));
							break;
						case DialogResult.Yes:				//Add pledge
							Program.Table<Pledge>().Rows.Add(new Pledge {
								Person = person.SelectedPerson,
								Date = date.DateTime,
								Type = "Donation",
								Account = account.Text,
								Amount = autoPledgeAmount = payment.Amount - currentBalance,
								Comments = ("Automatically added donation pledge\r\n\r\n" + comments.Text).Trim()
							});
							break;
					}
				}
			}
			return autoPledgeAmount;
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
			if (!ValidateCreation())
				return;
			if (!CheckMigration())
				return;


			decimal? autoPledgeAmount = CheckAutoPledge();
			if (autoPledgeAmount == null)
				return;
			try {
				paymentsBindingSource.EndEdit();
			} catch (Exception ex) {
				XtraMessageBox.Show("Couldn't add payment.\r\n" + ex.Message, "Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (commit.CommitType == CommitType.Create) {
				Program.Table<PledgeLink>().Rows.AddRange(pledgeLinks.Links);

				if (autoPledgeAmount > 0)
					InfoMessage.Show(String.Format(CultureInfo.CurrentCulture, "A {0:c} payment and a {1:c} donation pledge have been added for {2}", payment.Amount, autoPledgeAmount, payment.Person.FullName));
				else
					InfoMessage.Show(String.Format(CultureInfo.CurrentCulture, "A {0:c} payment has been added for {1}", payment.Amount, payment.Person.FullName));
				AddNew();
			}
		}
		#endregion

		private void method_EditValueChanged(object sender, EventArgs e) {
			//EditValue can be DBNull
			checkNumber.Visible = checkNumberLabel.Visible = method.EditValue as string == "Check";
			checkNumber.EditValue = null;
		}

		private void account_TextChanged(object sender, EventArgs e) {
			if (CurrentPayment.Table == null)
				RemoveLinks();
		}
		private void person_EditValueChanged(object sender, EventArgs e) {
			if (CurrentPayment.Table == null)
				RemoveLinks();

			date.Focus();
		}

		private void Input_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyData == Keys.Enter && commit.Visible)
				commit.PerformClick();
		}

		//TODO: Remove
		private void person_PersonSelecting(object sender, PersonSelectingEventArgs e) {
			if (e.Person != person.SelectedPerson
			 && !commit.Visible
			 && DialogResult.No == XtraMessageBox.Show("Are you sure you want to change this payment to be associated with " + e.Person.VeryFullName + "?",
													   "Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
				e.Cancel = true;
		}

		private void date_EditValueChanging(object sender, ChangingEventArgs e) {
			if (!(e.NewValue is DateTime)) return;
			var newDate = (DateTime)e.NewValue;
			if (newDate.Date == DateTime.Today.AddDays(1))
				e.Cancel = !Dialog.Warn("Are you sure you want to enter a payment dated tomorrow?");
			else if (newDate.Date > DateTime.Now)
				e.Cancel = !Dialog.Warn("Are you sure you want to enter a payment dated " + (newDate.Date - DateTime.Today).Days + " days in the future?");
		}

		private void linkDropDownEdit_QueryPopUp(object sender, CancelEventArgs e) {
			if (person.SelectedPerson == null || String.IsNullOrEmpty(account.Text)) {
				Dialog.ShowError("You must select a person and account before you can link pledges");
				e.Cancel = true;
				return;
			}

			//The grid depends on the account and person. I only bind it
			//when the popup is open so that I don't need to worry about
			//changes in the payment.
			pledgeLinks.HostPayment = CurrentPayment;
		}
		private void linkDropDownEdit_Closed(object sender, ClosedEventArgs e) {
			pledgeLinks.HostPayment = null;
		}
	}
}
