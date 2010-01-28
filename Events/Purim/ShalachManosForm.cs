using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Data.Filtering;
using DevExpress.XtraLayout.Utils;
using System.Globalization;
using ShomreiTorah.WinForms.Controls;

namespace ShomreiTorah.Billing.Events.Purim {
	partial class ShalachManosForm : XtraForm {
		const string PledgeType = "Shalach Manos";
		const string Account = "Operating Fund";
		public ShalachManosForm(int year) {
			InitializeComponent();

			addPanel.Hide();
			gridView.ActiveFilterCriteria = (new OperandProperty("Type") == PledgeType) & (new FunctionOperator(FunctionOperatorType.GetYear, new OperandProperty("Date")) == year);

			Program.Data.Pledges.AddLookupColumns();

			searchLookup.SearchTable = Program.Data.Pledges;
			searchLookup.PresetFilter = "Date > #1/1/" + year + "# AND Date < #12/31/" + year + "# AND Type='" + PledgeType + "'";
		}

		private void personSelector_SelectedPersonChanged(object sender, EventArgs e) {
			addPanel.Visible = personSelector.SelectedPerson != null;
			if (addPanel.Visible) {
				amount.Value = 72;
				amount.Focus();
				paymentMethod.SelectedIndex = -1;
				checkDate.EditValue = checkNumber.EditValue = null;
			}
		}
		private void paymentMethod_SelectedIndexChanged(object sender, EventArgs e) {
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
			}
			#endregion

			Program.Data.Pledges.AddPledgesRow(personSelector.SelectedPerson, DateTime.Now, PledgeType, "", null, Account,
											   amount.Value, String.IsNullOrEmpty(comments.Text) ? null : comments.Text);
			switch (paymentMethod.Text) {
				case "Unpaid": break;
				case "Cash":
					Program.Data.Payments.AddPaymentsRow(personSelector.SelectedPerson, DateTime.Now, "Cash", null, Account, amount.Value, comments.Text);
					break;
				case "Check":
					Program.Data.Payments.AddPaymentsRow(personSelector.SelectedPerson, checkDate.DateTime, "Check",
								checkNumber.EditValue == null ? new int?() : Convert.ToInt32(checkNumber.EditValue, CultureInfo.CurrentUICulture),
								Account, amount.Value, comments.Text);
					break;

			}

			personSelector.SelectedPerson = null;
		}

		private void searchLookup_ItemSelected(object sender, ItemSelectionEventArgs e) {
			gridView.FocusedRowHandle = gridView.LocateByValue(0, colPledgeId, (e.SelectedRow.Field<Guid>("PledgeId")));
			gridView.Focus();
		}
	}
}