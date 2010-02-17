using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout.Utils;
using ShomreiTorah.Billing.Controls;
using ShomreiTorah.WinForms.Controls;

namespace ShomreiTorah.Billing.Events.Purim {
	partial class ShalachManosForm : XtraForm {
		public const string PledgeType = "Shalach Manos";
		const string Account = "Operating Fund";
		readonly int year;
		public ShalachManosForm(int year) {
			InitializeComponent();
			this.year = year;

			Program.Data.Pledges.AddLookupColumns();

			var filterString = "Date > #1/1/" + year + "# AND Date < #12/31/" + year + "# AND Type='" + PledgeType + "'";

			addPanel.Hide();
			grid.DataMember = null;
			grid.DataSource = new DataView(Program.Data.Pledges, filterString, "LastName", DataViewRowState.CurrentRows);


			searchLookup.SearchTable = Program.Data.Pledges;
			searchLookup.PresetFilter = filterString;
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

		private void personRefEdit_ButtonClick(object sender, ButtonPressedEventArgs e) {
			var row = gridView.GetFocusedDataRow() as BillingData.PledgesRow;
			new Forms.PersonDetails(row.MasterDirectoryRow) { MdiParent = MdiParent }.Show();
		}

		private void personSelector_SelectingPerson(object sender, SelectingPersonEventArgs e) {
			if (Program.Data.Pledges.Any(p => p.PersonId == e.Person.Id && p.Date.Year == year && p.Type == PledgeType)) {
				XtraMessageBox.Show(e.Person.FullName + " are already on the Shalach Manos list",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				e.Cancel = true;
			}
		}
	}
}