using System;
using System.Globalization;
using ShomreiTorah.Data;

namespace ShomreiTorah.Billing.Events.Seating {
	partial class SeatingReservationDeleter : DevExpress.XtraEditors.XtraForm {
		readonly SeatingReservation seat;
		public SeatingReservationDeleter(SeatingReservation row) {
			InitializeComponent();
			seat = row;

			message.Text = String.Format(CultureInfo.CurrentCulture,
										 "Are you sure you want to delete this {0:c} reservation for {1} for {2}?",
										 seat.Pledge.Amount,
										 seat.TotalSeats == 1 ? "one seat" : seat.TotalSeats + " seats",
										 seat.Person.VeryFullName);
		}

		private void cancel_Click(object sender, EventArgs e) { Close(); }

		private void deleteSeat_Click(object sender, EventArgs e) {
			seat.RemoveRow();
			Close();
		}

		private void deleteBoth_Click(object sender, EventArgs e) {
			seat.RemoveRow();
			seat.Pledge.RemoveRow();
			//TODO: The seat is not cascaded.
			Close();
		}
	}
}