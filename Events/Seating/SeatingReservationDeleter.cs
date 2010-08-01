using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;
using System.Globalization;

namespace ShomreiTorah.Billing.Events.Seating {
	public partial class SeatingReservationDeleter : DevExpress.XtraEditors.XtraForm {
		readonly BillingData.SeatingReservationsRow seat;
		public SeatingReservationDeleter(BillingData.SeatingReservationsRow row) {
			InitializeComponent();
			seat = row;

			message.Text = String.Format(CultureInfo.CurrentCulture,
										 "Are you sure you want to delete this {0:c} reservation for {1} for {2}?",
										 seat.PledgesRow.Amount,
										 seat.TotalSeats == 1 ? "one seat" : seat.TotalSeats + " seats",
										 seat.Person.VeryFullName);
		}

		private void cancel_Click(object sender, EventArgs e) { Close(); }

		private void deleteSeat_Click(object sender, EventArgs e) {
			seat.Delete();
			Close();
		}

		private void deleteBoth_Click(object sender, EventArgs e) {
			seat.PledgesRow.Delete();
			//The seat is cascaded.
			Debug.Assert(seat.RowState == DataRowState.Deleted);
			Close();
		}
	}
}