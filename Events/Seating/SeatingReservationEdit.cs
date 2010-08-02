using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace ShomreiTorah.Billing.Events.Seating {
	public partial class SeatingReservationEdit : XtraUserControl {
		public SeatingReservationEdit() {
			InitializeComponent();
			pledgeTypeEditor.Properties.Assign(SeatingInfo.PledgeTypeEdit);

			if (Program.Data != null) {//Bugfix for nested designer
				pledgesBindingSource.DataSource = Program.Data;
				seatingReservationsBindingSource.DataSource = Program.Data;
			}
		}

		decimal? oldCalculatedPrice;
		public void BeginAddNew(BillingData.MasterDirectoryRow person) {
			pledgesBindingSource.CancelEdit();
			seatingReservationsBindingSource.CancelEdit();
			var pledge = (BillingData.PledgesRow)((DataRowView)pledgesBindingSource.AddNew()).Row;
			var seatRes = (BillingData.SeatingReservationsRow)((DataRowView)seatingReservationsBindingSource.AddNew()).Row;

			pledge.PledgeId = Guid.NewGuid();
			pledge.Account = "Operating Fund";
			pledge.Date = DateTime.Now;
			pledge.MasterDirectoryRow = person;
			seatRes.Id = Guid.NewGuid();
			seatRes.PledgesRow = pledge;
			pledgeTypeEditor.Focus();

			oldCalculatedPrice = CalculatePrice();
		}

		BillingData.SeatingReservationsRow Seat {
			get { return seatingReservationsBindingSource.Current == null ? null : (BillingData.SeatingReservationsRow)((DataRowView)seatingReservationsBindingSource.Current).Row; }
		}
		BillingData.PledgesRow Pledge {
			get { return pledgesBindingSource.Current == null ? null : (BillingData.PledgesRow)((DataRowView)pledgesBindingSource.Current).Row; }
		}

		public void EditRow(BillingData.SeatingReservationsRow row) {
			pledgesBindingSource.Position = pledgesBindingSource.Find("PledgeId", row.PledgeId);
			seatingReservationsBindingSource.Position = seatingReservationsBindingSource.Find("Id", row.Id);
			oldCalculatedPrice = CalculatePrice();
		}

		public bool CommitNew() {
			try {
				pledgesBindingSource.EndEdit();
				seatingReservationsBindingSource.EndEdit();
			} catch (Exception ex) {
				XtraMessageBox.Show("Couldn't add seating reservation.\r\n" + ex.Message, "Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}

		#region Amount calculations
		void UpdatePrice() {
			if (Seat == null) return;
			var newPrice = CalculatePrice();

			if (newPrice != null
			&& (oldCalculatedPrice == amountEditor.Value || amountEditor.EditValue == null || amountEditor.Value == 0))
				amountEditor.EditValue = newPrice;
			oldCalculatedPrice = newPrice ?? oldCalculatedPrice;
		}

		private void Edit_EditValueChanged(object sender, EventArgs e) { UpdatePrice(); }

		const int MembershipFee = 500;

		///<summary>Calculates the default price of the current seating reservation.</summary>
		decimal? CalculatePrice() {
			switch (pledgeTypeEditor.Text) {
				case "ימים נוראים Seating":
					var price = (MensSeatsSpinEdit.Value + WomensSeatsSpinEdit.Value) * 120
							  + (BoysSeatsSpinEdit.Value + GirlsSeatsSpinEdit.Value) * 60;
					if (price == 0) return null;

					return Math.Min(MembershipFee, price);
				case "Membership":
					return MembershipFee;
				case "Associate Membership":
					return 300;
				default:
					return null;
			}
		}
		#endregion

		private void amountEditor_ButtonClick(object sender, ButtonPressedEventArgs e) {
			if (e.Button.Index == 1) {
				pledgeTypeEditor.Focus();
				amountEditor.EditValue = CalculatePrice();
			}
		}
	}
}
