using System;
using System.Globalization;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ShomreiTorah.Data;
using ShomreiTorah.Singularity;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using System.Linq;

namespace ShomreiTorah.Billing.Forms {
	partial class PersonDetails : XtraForm {
		readonly Person person;

		public PersonDetails(Person person) {
			InitializeComponent();
			this.person = person;

			exportEmail.Caption = exportWord.Caption = (person.FullName ?? person.VeryFullName).Replace("&", "&&");

			relativesGrid.DataMember = null;
			SetPerson();
		}

		void SetPerson() {
			Text = person.VeryFullName;

			personBindingSource.DataSource = Program.Table<Person>();
			personBindingSource.Position = Program.Table<Person>().Rows.IndexOf(person);

			relativesGrid.DataSource = Program.Table<RelativeLink>().Filter(r => r.Member == person || r.Relative == person);

			UpdateDetails();
		}
		private void personBindingSource_CurrentItemChanged(object sender, EventArgs e) { UpdateDetails(); }
		void UpdateDetails() {
			if (person == null)
				return;
			map.Text = person.FullName;
			map.AddressString = person.Address + Environment.NewLine + person.City + ", " + person.State + "  " + person.Zip;
			details.Text = new PersonData(person).ToFullString()
						 + "\r\n\r\nBalance Due: " + person.Field<decimal>("BalanceDue").ToString("c", CultureInfo.CurrentCulture);
			SetTransactionsLog();
		}

		private void exportEmail_ItemClick(object sender, ItemClickEventArgs e) { Statements.Email.EmailExporter.Execute(this, person); }
		private void exportWord_ItemClick(object sender, ItemClickEventArgs e) { Statements.Word.WordExporter.Execute(this, person); }

		#region Relatives
		private void addRLAsMember_ItemClick(object sender, ItemClickEventArgs e) { RelationCreator.Execute(member: person); relativesView.BestFitColumns(); }
		private void addRLAsRelative_ItemClick(object sender, ItemClickEventArgs e) { RelationCreator.Execute(relative: person); relativesView.BestFitColumns(); }

		private void relativesView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e) {
			if (e.Column == colRelative || e.Column == colMember) {
				if (e.CellValue == person)
					e.RepositoryItem = labelLikeEdit;
			}
		}
		private void relativesView_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e) {
			if (relativesView.FocusedColumn == colRelative || relativesView.FocusedColumn == colMember) {
				if (relativesView.GetFocusedValue() == person)
					e.Cancel = true;
			}
		}
		#endregion

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

		private void xtraTabControl1_SelectedPageChanging(object sender, TabPageChangingEventArgs e) {
			if (e.Page == transactionsTab) {
				SetTransactionsLog();
			}
		}
		protected override void OnActivated(EventArgs e) {
			base.OnActivated(e);
			SetTransactionsLog();
        }

		void SetTransactionsLog() {
			transactionsControl.SetData(
				person.Transactions,
				person.LoggedStatements.Where(s => s.StatementKind.Contains("Bill"))
									   .Select(s => Tuple.Create(s.DateGenerated, s.StatementKind))
			);
		}
	}
}