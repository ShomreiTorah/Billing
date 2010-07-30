using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ShomreiTorah.Billing.Events.Seating {
	public partial class SeatingReservationEdit : XtraUserControl {
		public SeatingReservationEdit() {
			InitializeComponent();
			if (Program.Data != null) {//Bugfix for nested designer
				pledgesBindingSource.DataSource = Program.Data;
				seatingReservationsBindingSource.DataSource = Program.Data;
			}
		}

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
			pledgeTypeEdit.Focus();
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
	}
}
