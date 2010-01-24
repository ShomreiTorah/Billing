using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using System.Globalization;

namespace ShomreiTorah.Billing.Forms {
	partial class PersonDetails : XtraForm {
		readonly BillingData.MasterDirectoryRow person;

		public PersonDetails(BillingData.MasterDirectoryRow person) {
			InitializeComponent();
			this.person = person;

			exportEmail.Caption = exportWord.Caption = (person.FullName ?? person.VeryFullName).Replace("&", "&&");

			emailGrid.DataSource = null;
			emailGrid.DataMember = "EmailAddresses";		//In the designer, grids are bound to the dataset itself.
			emailGrid.DataSource = paymentsGrid.DataSource = pledgeGrid.DataSource = personBindingSource;
			SetPerson();
		}

		void SetPerson() {
			Text = person.VeryFullName;

			personBindingSource.DataSource = Program.Data.MasterDirectory;
			personBindingSource.Position = Program.Data.MasterDirectory.Rows.IndexOf(person);

			UpdateDetails();
		}
		private void personBindingSource_CurrentItemChanged(object sender, EventArgs e) { UpdateDetails(); }
		void UpdateDetails() {
			map.AddressString = person.Address + ", " + person.City + ", " + person.State + ", " + person.Zip;
			details.Text = new PersonData(person).ToFullString()
						 + "\r\n\r\nBalance Due: " + person.BalanceDue.ToString("c", CultureInfo.CurrentUICulture);
		}

		private void exportEmail_ItemClick(object sender, ItemClickEventArgs e) { Export.EmailExporter.Execute(person); }
		private void exportWord_ItemClick(object sender, ItemClickEventArgs e) { Export.WordExporter.Execute(person); }

		private void pledgeView_DoubleClick(object sender, EventArgs e) {
			var row = pledgeView.GetFocusedDataRow() as BillingData.PledgesRow;
			if (row != null) new PledgeEditPopup(row).Show(MdiParent);
		}
		private void paymentsView_DoubleClick(object sender, EventArgs e) {
			var row = paymentsView.GetFocusedDataRow() as BillingData.PaymentsRow;
			if (row != null) new PaymentEditPopup(row).Show(MdiParent);
		}
	}
}