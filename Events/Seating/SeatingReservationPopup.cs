using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ShomreiTorah.Billing.Events.Seating {
	public partial class SeatingReservationPopup : XtraForm {
		readonly BillingData.SeatingReservationsRow row;
		public SeatingReservationPopup(BillingData.SeatingReservationsRow row) {
			InitializeComponent();

			Text = "Seating Reservation Editor - " + row.FullName;
			this.row = row;
			editor.EditRow(row);
			ClientSize = editor.Size;

			Program.Data.SeatingReservations.SeatingReservationsRowDeleted += SeatingReservations_SeatingReservationsRowDeleted;
		}

		void SeatingReservations_SeatingReservationsRowDeleted(object sender, BillingData.SeatingReservationsRowChangeEvent e) {
			if (e.Row == row)
				Close();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
			if (keyData == Keys.Escape) {
				Close();
				return false;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}
		protected override void Dispose(bool disposing) {
			if (disposing) {
				Program.Data.SeatingReservations.SeatingReservationsRowDeleted -= SeatingReservations_SeatingReservationsRowDeleted;
				if (components != null) components.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}