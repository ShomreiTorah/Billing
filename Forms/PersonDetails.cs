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

		private void addRLAsMember_ItemClick(object sender, ItemClickEventArgs e) { RelationCreator.Execute(member: person); }
		private void addRLAsRelative_ItemClick(object sender, ItemClickEventArgs e) { RelationCreator.Execute(relative: person); }

		private void showPersonEdit_Click(object sender, EventArgs e) { ShowPersonEdit(true); }
		private void closePersonEdit_Click(object sender, EventArgs e) { ShowPersonEdit(false); }

		void ShowPersonEdit(bool visible) {
			if (visible) {
				details.Hide();
				personEditor.Person = person;
				personEditPanel.Show();
				if (splitContainerControl1.SplitterPosition < 256)
					splitContainerControl1.SplitterPosition = 256;
				AcceptButton = closePersonEdit;
			} else {
				UpdateDetails();
				personEditPanel.Hide();
				details.Show();
				AcceptButton = null;
			}
		}
	}
}