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
using DevExpress.XtraGrid.Views.Base;
using System.IO;

namespace ShomreiTorah.Billing.Events.Seating {
	partial class SeatingForm : Forms.GridFormBase {
		readonly int year;
		readonly DataView dataSource;
		public SeatingForm(int year) {
			InitializeComponent();

			this.year = year;
			var filterString = "Parent(Seat).Date > #1/1/" + year + "# AND Parent(Seat).Date < #12/31/" + year + "#";

			grid.DataMember = null;
			grid.DataSource = dataSource = new DataView(Program.Data.SeatingReservations, filterString, null, DataViewRowState.CurrentRows);

			Text = year.ToString(CultureInfo.CurrentCulture) + " Seating Reservations";
		}

		#region AddEntry Panel
		private void personSelector_SelectedPersonChanged(object sender, EventArgs e) {
			if (personSelector.SelectedPerson == null) return;
			addNewPanel.Show();
			addNewEdit.BeginAddNew(personSelector.SelectedPerson);
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
			CloseAddEndtryPanel();
		}
		void CloseAddEndtryPanel(bool confirm = false) {
			if (!addNewPanel.Visible) return;
			if (confirm && DialogResult.No == XtraMessageBox.Show("Are you sure you wish to cancel adding this seating reservation?",
																  "Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
				return;
			addNewPanel.Hide();
			personSelector.SelectedPerson = null;
		}
		private void cancelAddEntry_Click(object sender, EventArgs e) { CloseAddEndtryPanel(confirm: true); }
		#endregion

		private void gridView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
			if (e.Column.FieldName.StartsWith("Pledge/")) {
				var columnName = Path.GetFileName(e.Column.FieldName);
				var row = (BillingData.SeatingReservationsRow)dataSource[e.ListSourceRowIndex].Row;

				if (e.IsGetData)
					e.Value = row.PledgesRow[columnName];
				else
					row.PledgesRow[columnName] = e.Value;
			}
		}
	}
}