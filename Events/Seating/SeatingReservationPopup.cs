using System.Windows.Forms;
using DevExpress.XtraEditors;
using ShomreiTorah.Data;
using ShomreiTorah.Singularity;

namespace ShomreiTorah.Billing.Events.Seating {
	public partial class SeatingReservationPopup : XtraForm {
		readonly SeatingReservation row;
		public SeatingReservationPopup(SeatingReservation row) {
			InitializeComponent();

			Text = "Seating Reservation Editor - " + row.Person.FullName;
			this.row = row;
			editor.EditRow(row);
			ClientSize = editor.Size;

			Program.Table<SeatingReservation>().RowRemoved += SeatingReservations_RowRemoved;
		}

		void SeatingReservations_RowRemoved(object sender, RowListEventArgs<SeatingReservation> e) {
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
				Program.Table<SeatingReservation>().RowRemoved -= SeatingReservations_RowRemoved;
				if (components != null) components.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}