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

namespace ShomreiTorah.Billing.PaymentImport {
	[Export]
	public partial class ImportForm : XtraForm {
		readonly ViewModel viewModel;

		[ImportingConstructor]
		public ImportForm(ViewModel viewModel) {
			InitializeComponent();
			startDate.EditValue = DateTime.Today.AddDays(-14);
			this.viewModel = viewModel;
			viewModelBindingSource.DataSource = viewModel;
			viewModel.PropertyChanged += ViewModel_PropertyChanged;
		}

		private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e) {
			switch (e.PropertyName) {
				case nameof(viewModel.Person):
					peopleView.FocusedRowHandle = peopleView.GetRowHandle(
						viewModel.MatchingPeople.IndexOf(viewModel.Person));
					break;
			}
			import.Enabled = viewModel.CurrentPayment != null && viewModel.Person != null;
		}

		private void availablePaymentsView_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e) {
			viewModel.CurrentPayment = (PaymentInfo)e.Row;
		}

		private void peopleView_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e) {
			viewModel.Person = (Person)e.Row;
		}

		private void refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
			LoadPayments();
		}

		private void import_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
			viewModel.Import();
		}
		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			LoadPayments();
		}
		void LoadPayments() {
			var date = (DateTime)startDate.EditValue;
			viewModel.LoadPayments(date);
		}

		private void availablePaymentsView_CustomDrawCardCaption(object sender, LayoutViewCustomDrawCardCaptionEventArgs e) {
			if (e.RowHandle == availablePaymentsView.FocusedRowHandle)
				e.Appearance.Font = e.Cache.GetFont(e.Appearance.Font, FontStyle.Bold);
		}
	}
}