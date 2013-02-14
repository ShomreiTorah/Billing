using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI.Controls;
using ShomreiTorah.Data.UI.DisplaySettings;
using ShomreiTorah.Singularity;
using ShomreiTorah.WinForms;
using ShomreiTorah.WinForms.Forms;

namespace ShomreiTorah.Billing.Events.Purim {
	partial class ShalachManosForm : Forms.GridFormBase {
		public const string PledgeType = "Shalach Manos";
		static readonly string Account = Names.DefaultAccount;
		readonly int year;
		readonly FilteredTable<Pledge> pledges;
		public ShalachManosForm(int year) {
			InitializeComponent();
			this.year = year;
			Text = "Shalach Manos " + year;

			addPanel.Hide();
			grid.DataMember = null;

			pledges = Program.Table<Pledge>().Filter(p => p.Date.Year == year && p.Type == PledgeType);
			searchLookup.Properties.DataSource = grid.DataSource = pledges;
			EditorRepository.PersonOwnedLookup.Apply(searchLookup.Properties);

			ShowHideCheckGroup();
		}

		///<summary>Releases the unmanaged resources used by the ShalachManosForm and optionally releases the managed resources.</summary>
		///<param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				pledges.Dispose();
				if (components != null) components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void personSelector_EditValueChanged(object sender, EventArgs e) {
			addPanel.Visible = personSelector.SelectedPerson != null;
			if (addPanel.Visible) {
				if (year != DateTime.Now.Year
				 && !Dialog.Warn("You're trying to add someone to the " + year + " Shalach Manos list.\nAre you sure you want to do that?")) {
					personSelector.SelectedPerson = null;
					return;
				}

				amount.Value = 100;
				amount.Focus();
				paymentMethod.SelectedIndex = -1;
				comments.EditValue = checkDate.EditValue = checkNumber.EditValue = null;
			}
		}
		private void paymentMethod_SelectedIndexChanged(object sender, EventArgs e) { ShowHideCheckGroup(); }
		void ShowHideCheckGroup() {
			checkGroup.Visibility = paymentMethod.Text == "Check" ? LayoutVisibility.Always : LayoutVisibility.Never;
		}

		private void Input_KeyDown(object sender, KeyEventArgs e) { if (e.KeyData == Keys.Enter) add.PerformClick(); }

		private void add_Click(object sender, EventArgs e) {
			#region Validation
			if (amount.Value <= 0) {
				XtraMessageBox.Show("Please select an amount to bill.",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (paymentMethod.SelectedIndex < 0) {
				XtraMessageBox.Show("Please select a payment method.",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (paymentMethod.Text == "Check") {
				if (!(checkDate.EditValue is DateTime)) {
					XtraMessageBox.Show("Please enter the date on the check.",
										"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				if (!String.IsNullOrWhiteSpace(checkNumber.Text)) {
					Payment duplicate = personSelector.SelectedPerson.Payments
							.FirstOrDefault(p => String.Equals(p.CheckNumber, checkNumber.Text, StringComparison.CurrentCultureIgnoreCase));

					if (duplicate != null
					 && !Dialog.Warn(String.Format(CultureInfo.CurrentCulture, "{0} #{1} for {2} has already been entered ({3:d}, {4:c}).\r\nIs that correct?",
																			   duplicate.Method, duplicate.CheckNumber, duplicate.Person.FullName, duplicate.Date, duplicate.Amount)))
						return;
				}
			}
			#endregion

			var actualComments = String.IsNullOrWhiteSpace(this.comments.Text) ? null : this.comments.Text;
			Pledge pledge = new Pledge {
				Person = personSelector.SelectedPerson,
				Date = DateTime.Now,
				Type = PledgeType,
				SubType = "",
				Account = Account,
				Amount = amount.Value,
				Comments = actualComments
			};
			Program.Table<Pledge>().Rows.Add(pledge);

			string messagePrefix = personSelector.SelectedPerson.FullName + " have been added to the Shalach Manos list with a " + amount.Value.ToString("c0", CultureInfo.CurrentCulture);

			Payment payment = null;
			switch (paymentMethod.Text) {
				case "Unpaid":
					InfoMessage.Show(messagePrefix + " unpaid pledge.");
					break;
				case "Cash":
					Program.Table<Payment>().Rows.Add(payment = new Payment {
						Person = personSelector.SelectedPerson,
						Date = DateTime.Now,
						Method = paymentMethod.Text,
						Account = Account,
						Amount = amount.Value,
						Comments = actualComments
					});
					InfoMessage.Show(messagePrefix + " cash payment.");
					break;
				case "Check":
					Program.Table<Payment>().Rows.Add(payment = new Payment {
						Person = personSelector.SelectedPerson,
						Date = checkDate.DateTime,
						Method = paymentMethod.Text,
						CheckNumber = checkNumber.Text,
						Account = Account,
						Amount = amount.Value,
						Comments = actualComments
					});
					InfoMessage.Show(messagePrefix + " check.");
					break;
			}
			if (payment != null)
				Program.Table<PledgeLink>().Rows.Add(new PledgeLink {
					Amount = amount.Value,
					Payment = payment,
					Pledge = pledge
				});

			personSelector.SelectedPerson = null;
			personSelector.Focus();
		}

		private void searchLookup_EditValueChanged(object sender, EventArgs e) {
			gridView.FocusedRowHandle = gridView.GetRowHandle(pledges.Rows.IndexOf((Pledge)searchLookup.EditValue));
			gridView.Focus();
			searchLookup.EditValue = null;
		}

		private void personSelector_PersonSelecting(object sender, PersonSelectingEventArgs e) {
			if (e.Person.Pledges.Any(p => p.Date.Year == year && p.Type == PledgeType)) {
				Dialog.ShowError(e.Person.FullName + " are already on the Shalach Manos list");
				e.Cancel = true;
			}
		}
	}
}