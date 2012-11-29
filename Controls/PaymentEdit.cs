using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ShomreiTorah.Billing.Controls.Editors;
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

			pledgeLinks.DataChanged += delegate { RefreshStatus(); };

			paymentsBindingSource.DataSource = Program.Current.DataContext;
		}

		///<summary>Indicates whether the user has clicked the Pledges dropdown yet.</summary>
		///<remarks>This is used to prompt for relative pledges when the dialog is first shown.</remarks>
		private bool hasShownPledgeLinks;

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
				pledgeLinks.HostPayment = value;
				commit.Hide();
				RefreshStatus();
				SetCommentsHeight();	//For some reason, VisibleChanged doesn't fire.
			}
		}

		public void AddNew() {
			if (CurrentPayment != null && CurrentPayment.Table == null)
				RemoveLinks();
			paymentsBindingSource.CancelEdit();

			hasShownPledgeLinks = false;
			commit.CommitType = CommitType.Create;
			commit.Show();
			paymentsBindingSource.AddNew();
			pledgeLinks.HostPayment = CurrentPayment;
			RefreshStatus();
			person.Focus();
		}


		///<summary>Removes all PledgeLinks created by the user when creating an uncommitted payment.</summary>
		///<remarks>This method should not be called for payments that are already in the table; the Payment class will handle those automatically.</remarks>
		public void RemoveLinks() {
			if (pledgeLinks.HostPayment == null)
				return;
			pledgeLinks.Links.Clear();
			pledgeLinks.RefreshAll();
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

			switch (pledgeLinks.Status) {
				case PledgeLinksStatus.Empty:
					return Dialog.Warn("Are you sure you want to add a payment without linking it to any pledges?");
				case PledgeLinksStatus.Partial:
					var unlinked = CurrentPayment.Amount - pledgeLinks.Links.Sum(o => o.Amount);
					string message = String.Format(CultureInfo.CurrentCulture, "{0:c} of this payment have not been linked to any pledges.\r\nAre you sure you want to add it anyway?", unlinked);
					if (!pledgeLinks.HasUnlinkedPledges)
						message += "\r\n\r\nThere are no more pledges to compensate for, so you may want to go back to the Pledges dropdown and add a donation pledge to cover the rest.";
					return Dialog.Warn(message);
				case PledgeLinksStatus.Error:
					Dialog.ShowError("The pledge links are invalid.  Please click the Pledges button and correct any red rows.");
					return false;
				case PledgeLinksStatus.Complete:
					break;	//Fine
			}

			return true;
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

			try {
				paymentsBindingSource.EndEdit();
			} catch (Exception ex) {
				XtraMessageBox.Show("Couldn't add payment.\r\n" + ex.Message, "Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (commit.CommitType == CommitType.Create) {
				Program.Table<PledgeLink>().Rows.AddRange(pledgeLinks.Links);

				InfoMessage.Show(String.Format(CultureInfo.CurrentCulture, "A {0:c} payment has been added for {1}", payment.Amount, payment.Person.FullName));
				AddNew();
			}
		}
		#endregion

		static readonly Dictionary<PledgeLinksStatus, Color> statusColors = new Dictionary<PledgeLinksStatus, Color> {
			{ PledgeLinksStatus.Empty,		Color.Red		},
			{ PledgeLinksStatus.Partial,	Color.Yellow	},
			{ PledgeLinksStatus.Complete,	Color.Green		},
			{ PledgeLinksStatus.Error,		Color.DarkRed	},
		};
		private void RefreshStatus() {
			//Changing the button while the dropdown is open closes the dropdown.
			//Therefore, I reset it to black while the dropdown is open.
			if (linkDropDownEdit.IsPopupOpen)
				return;

			if (person.SelectedPerson == null || String.IsNullOrEmpty(account.Text) || amount.Value <= 0) {
				linkDropDownEdit.Properties.Buttons[0].Appearance.Options.UseForeColor = false;
				return;
			}
			linkDropDownEdit.Properties.Buttons[0].Appearance.ForeColor = statusColors[pledgeLinks.Status];
			linkDropDownEdit.Properties.Buttons[0].Appearance.Options.UseForeColor = true;
		}

		private void method_EditValueChanged(object sender, EventArgs e) {
			//EditValue can be DBNull
			checkNumber.Visible = checkNumberLabel.Visible = method.EditValue as string == "Check";
			checkNumber.EditValue = null;
		}

		private void person_EditValueChanged(object sender, EventArgs e) {
			if (CurrentPayment == null) return;
			if (CurrentPayment.Table == null)
				RemoveLinks();
			else
				pledgeLinks.RefreshAll();	//Reload the pledges grid (RemoveLinks() already does this)

			hasShownPledgeLinks = false;
			date.Focus();
		}
		private void LinksField_Leave(object sender, System.EventArgs e) {
			BeginInvoke(new Action(delegate {
				//This event fires before data-binding, so I need to wait until the payment changes.
				if (pledgeLinks.HostPayment != null)
					pledgeLinks.RefreshAll();
			}));
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
			if (person.SelectedPerson == null || String.IsNullOrEmpty(account.Text) || amount.Value <= 0) {
				Dialog.ShowError("You must select a person and account, and enter the payment amount, before you can link pledges.");
				e.Cancel = true;
			} else {
				if (!hasShownPledgeLinks)
					pledgeLinks.ShowMigrationDialog(FindForm());
				hasShownPledgeLinks = true;

				linkDropDownEdit.Properties.Buttons[0].Appearance.Options.UseForeColor = false;
			}
		}

		private void linkDropDownEdit_CloseUp(object sender, CloseUpEventArgs e) {
			RefreshStatus();
		}
	}
}
