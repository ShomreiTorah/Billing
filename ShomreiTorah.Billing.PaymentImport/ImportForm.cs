using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Composition;
using DevExpress.XtraGrid.Views.Base;
using ShomreiTorah.WinForms.Controls;
using ShomreiTorah.Data;
using ShomreiTorah.WinForms.Forms;
using DevExpress.XtraGrid.Views.Layout.Events;
using DevExpress.XtraBars;
using ShomreiTorah.WinForms;
using DevExpress.XtraGrid.Views.Grid;

namespace ShomreiTorah.Billing.PaymentImport {
	[Export]
	public partial class ImportForm : XtraForm {
		readonly ViewModel viewModel;

		[ImportingConstructor]
		public ImportForm(ViewModel viewModel) {
			InitializeComponent();
			this.viewModel = viewModel;
			viewModelBindingSource.DataSource = viewModel;
			viewModel.PropertyChanged += ViewModel_PropertyChanged;
			startDate.EditValue = DateTime.Today.AddDays(-14);
			personSelector.Properties.NewPersonTemplate = e => new Person {
				Address = viewModel.CurrentPayment.Address,
				City = viewModel.CurrentPayment.City,
				FullName = viewModel.CurrentPayment.FirstName + " " + viewModel.CurrentPayment.LastName,
				LastName = viewModel.CurrentPayment.LastName,
				HisName = viewModel.CurrentPayment.FirstName,
				Phone = viewModel.CurrentPayment.Phone,
				Source = "Credit Card Import",
				State = viewModel.CurrentPayment.State,
				Zip = viewModel.CurrentPayment.Zip
			};
		}

		private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e) {
			switch (e.PropertyName) {
				case nameof(viewModel.CurrentPayment):
					availablePaymentsView.VisibleRecordIndex =
						availablePaymentsView.GetVisibleIndex(
							availablePaymentsView.GetRowHandle(
								viewModel.AvailablePayments.IndexOf(
									viewModel.CurrentPayment)));
					break;
				case nameof(viewModel.MatchingPeople):
					peopleView.BestFitColumns();
					break;
				case nameof(viewModel.Person):
					peopleView.FocusedRowHandle = peopleView.GetRowHandle(
						viewModel.MatchingPeople.IndexOf(viewModel.Person));
					break;
			}
			import.Enabled = viewModel.CurrentPayment != null && viewModel.Person != null
				&& !viewModel.CreatePledge || !string.IsNullOrWhiteSpace(viewModel.PledgeType);
		}

		private void availablePaymentsView_VisibleRecordIndexChanged(Object sender, LayoutViewVisibleRecordIndexChangedEventArgs e) => SetCurrentPayment();

		private void peopleView_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e) {
			viewModel.Person = (Person)e.Row;
		}

		private void peopleView_RowClick(Object sender, RowClickEventArgs e) {
			// This is necessary if the user selects null via the Lookup
			// when the grid only has one row; no other event will fire.
			viewModel.Person = (Person)peopleView.GetRow(e.RowHandle);
		}

		private void refresh_ItemClick(object sender, ItemClickEventArgs e) => LoadPayments();
		private void startDate_EditValueChanged(Object sender, EventArgs e) => LoadPayments();

		private void import_ItemClick(object sender, ItemClickEventArgs e) {
			try {
				viewModel.Import();
			} catch (Exception ex) {
				Dialog.ShowError("An error occurred while importing the payment:\r\n" + ex.Message);
			}
			SetCurrentPayment();
		}

		private void SetCurrentPayment() {
			viewModel.CurrentPayment = (PaymentInfo)availablePaymentsView.GetRow(
				availablePaymentsView.GetVisibleRowHandle(
					availablePaymentsView.VisibleRecordIndex));
		}

		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			LoadPayments();
		}
		void LoadPayments() {
			viewModel.LoadPayments((DateTime)startDate.EditValue);
			SetCurrentPayment();
		}

		private void availablePaymentsView_CustomDrawCardCaption(object sender, LayoutViewCustomDrawCardCaptionEventArgs e) {
			e.Appearance.Font = e.Cache.GetFont(e.Appearance.Font,
				e.RowHandle == availablePaymentsView.FocusedRowHandle ? FontStyle.Bold : FontStyle.Regular);
		}

		Color[] matchColors = { Color.LightGreen, Color.Yellow, Color.Red };
		private void peopleView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e) {
			var person = (Person)peopleView.GetRow(e.RowHandle);
			if (person != null)
				e.Appearance.BackColor = Color.FromArgb(128, 
					matchColors[Matcher.GetMatchScore(viewModel.CurrentPayment, person)]);
		}
	}
}