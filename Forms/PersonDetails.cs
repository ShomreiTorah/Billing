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

			//In the designer, grids are bound to the dataset itself.
			//I need to rebind them to the person's detail views. The
			//EmailAddresses and StatementLog tables' relation names 
			//are not the same as their table names, so I also change
			//their DataMembers.
			emailGrid.DataSource = null;
			emailGrid.DataMember = "EmailAddresses";

			statementsGrid.DataSource = null;
			statementsGrid.DataMember = "Statements";

			emailGrid.DataSource = statementsGrid.DataSource = paymentsGrid.DataSource = pledgeGrid.DataSource = personBindingSource;
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
			map.Text = person.FullName;
			map.AddressString = person.Address + Environment.NewLine + person.City + ", " + person.State + "  " + person.Zip;
			details.Text = new PersonData(person).ToFullString()
						 + "\r\n\r\nBalance Due: " + person.BalanceDue.ToString("c", CultureInfo.CurrentUICulture);
		}

		private void exportEmail_ItemClick(object sender, ItemClickEventArgs e) { Statements.Email.EmailExporter.Execute(this, person); }
		private void exportWord_ItemClick(object sender, ItemClickEventArgs e) { Statements.Word.WordExporter.Execute(this, person); }
	}
}