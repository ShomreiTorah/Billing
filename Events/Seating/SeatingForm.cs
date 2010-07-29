using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Globalization;
using ShomreiTorah.Billing.Controls;

namespace ShomreiTorah.Billing.Events.Seating {
	partial class SeatingForm : Forms.GridFormBase {
		readonly int year;
		public SeatingForm(int year) {
			InitializeComponent();

			this.year = year;
			var filterString = "Parent(Seat).Date > #1/1/" + year + "# AND Parent(Seat).Date < #12/31/" + year + "#";

			grid.DataMember = null;
			grid.DataSource = new DataView(Program.Data.SeatingReservations, filterString, "LastName", DataViewRowState.CurrentRows);

			Text = year.ToString(CultureInfo.CurrentCulture) + " Seating Reservations";
		}

		private void personSelector_SelectedPersonChanged(object sender, EventArgs e) {
			if (personSelector.SelectedPerson == null) return;
			addNewEdit.BeginAddNew(personSelector.SelectedPerson);
			addNewPanel.Show();
		}

		private void personSelector_SelectingPerson(object sender, SelectingPersonEventArgs e) {
			if (e.Person != null && addNewPanel.Visible) {
				if (DialogResult.Yes == XtraMessageBox.Show("Are you sure you want to start adding a new reservation?\r\nYou haven't added the reservation you're currently editing yet!",
															"Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
					e.Cancel = true;
			}
		}

		private void addEntry_Click(object sender, EventArgs e) {
			if (!addNewEdit.CommitNew())
				return;

			addNewPanel.Hide();
			personSelector.SelectedPerson = null;
		}
	}
}