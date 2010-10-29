using System;
using System.Globalization;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ShomreiTorah.Data;

namespace ShomreiTorah.Billing.Forms {
	partial class PersonDetails : XtraForm {
		readonly Person person;

		public PersonDetails(Person person) {
			InitializeComponent();
			this.person = person;

			exportEmail.Caption = exportWord.Caption = (person.FullName ?? person.VeryFullName).Replace("&", "&&");

			emailGrid.DataSource = statementsGrid.DataSource = paymentsGrid.DataSource = pledgeGrid.DataSource = personBindingSource;
			SetPerson();
		}

		void SetPerson() {
			Text = person.VeryFullName;

			personBindingSource.DataSource = Program.Table<Person>();
			personBindingSource.Position = Program.Table<Person>().Rows.IndexOf(person);

			UpdateDetails();
		}
		private void personBindingSource_CurrentItemChanged(object sender, EventArgs e) { UpdateDetails(); }
		void UpdateDetails() {
			if (person == null) return;
			map.Text = person.FullName;
			map.AddressString = person.Address + Environment.NewLine + person.City + ", " + person.State + "  " + person.Zip;
			details.Text = new PersonData(person).ToFullString()
						 + "\r\n\r\nBalance Due: " + person.Field<decimal>("BalanceDue").ToString("c", CultureInfo.CurrentCulture);
		}

		private void exportEmail_ItemClick(object sender, ItemClickEventArgs e) { Statements.Email.EmailExporter.Execute(this, person); }
		private void exportWord_ItemClick(object sender, ItemClickEventArgs e) { Statements.Word.WordExporter.Execute(this, person); }
	}
}