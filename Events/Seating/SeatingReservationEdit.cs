using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ShomreiTorah.Data;

namespace ShomreiTorah.Billing.Events.Seating {
	public partial class SeatingReservationEdit : XtraUserControl {
		public SeatingReservationEdit() {
			InitializeComponent();
			pledgeTypeEditor.Properties.Assign(SeatingInfo.PledgeTypeEdit);

			if (Program.Current.DataContext != null) {//Bugfix for nested designer
				pledgesBindingSource.DataSource = Program.Table<Pledge>();
				seatingReservationsBindingSource.DataSource = Program.Table<SeatingReservation>();
			}
		}

		decimal? oldCalculatedPrice;
		public void BeginAddNew(Person person) {
			pledgesBindingSource.CancelEdit();
			seatingReservationsBindingSource.CancelEdit();
			var pledge = (Pledge)pledgesBindingSource.AddNew();
			var seatRes = (SeatingReservation)seatingReservationsBindingSource.AddNew();

			pledge.Account = "Operating Fund";
			pledge.Date = DateTime.Now;
			pledge.Person = person;
			seatRes.Pledge = pledge;
			pledgeTypeEditor.Focus();

			oldCalculatedPrice = CalculatePrice();
		}

		SeatingReservation Seat { get { return (SeatingReservation)seatingReservationsBindingSource.Current; } }
		Pledge Pledge { get { return (Pledge)pledgesBindingSource.Current; } }

		public void EditRow(SeatingReservation row) {
			pledgesBindingSource.Position = pledgesBindingSource.IndexOf(row.Pledge);
			seatingReservationsBindingSource.Position = seatingReservationsBindingSource.IndexOf(row);
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
		private void amountEditor_ButtonClick(object sender, ButtonPressedEventArgs e) {
			if (e.Button.Index == 1) {
				layoutControl.SelectNextControl(amountEditor, true, true, false, true);
				amountEditor.EditValue = CalculatePrice();
			}
		}

		private void Edit_EditValueChanged(object sender, EventArgs e) { UpdatePrice(); }
		void UpdatePrice() {
			if (Seat == null) return;
			var newPrice = CalculatePrice();

			if (newPrice != null
			&& (oldCalculatedPrice == amountEditor.Value || amountEditor.EditValue == null || amountEditor.Value == 0))
				amountEditor.EditValue = newPrice;
			oldCalculatedPrice = newPrice ?? oldCalculatedPrice;
		}


		const int MembershipFee = 850;
		///<summary>Calculates the default price of the current seating reservation.</summary>
		decimal? CalculatePrice() {
			switch (pledgeTypeEditor.Text) {
				case "ימים נוראים Seating":
					var price = (MensSeatsSpinEdit.Value + WomensSeatsSpinEdit.Value) * 150
							  + (BoysSeatsSpinEdit.Value + GirlsSeatsSpinEdit.Value) * 100;
					if (price == 0) return null;

					return Math.Min(MembershipFee, price);
				case "Membership":
					return MembershipFee;
				case "Associate Membership":
					return 400;
				default:
					return null;
			}
		}
		#endregion


		private void Input_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				if (Seat.Table != null) {
					var edit = (BaseEdit)sender;
					layoutControl.SelectNextControl(edit, true, true, false, true);

					pledgesBindingSource.EndEdit();
					seatingReservationsBindingSource.EndEdit();
				}
				OnEnterPressed();
			}
		}
		///<summary>Occurs when the enter key is pressed.</summary>
		public event EventHandler EnterPressed;
		///<summary>Raises the EnterPressed event.</summary>
		internal protected virtual void OnEnterPressed() { OnEnterPressed(EventArgs.Empty); }
		///<summary>Raises the EnterPressed event.</summary>
		///<param name="e">An EventArgs object that provides the event data.</param>
		internal protected virtual void OnEnterPressed(EventArgs e) {
			if (EnterPressed != null)
				EnterPressed(this, e);
		}
	}
}
