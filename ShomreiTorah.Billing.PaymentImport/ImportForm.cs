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
using DevExpress.XtraLayout.Utils;

namespace ShomreiTorah.Billing.PaymentImport {
	[Export]
	public partial class ImportForm : XtraForm {
		readonly ViewModel viewModel;

		[ImportingConstructor]
		public ImportForm(ViewModel viewModel) {
			InitializeComponent();
			this.viewModel = viewModel;
			// Don't reset focused row when list changes.  We bind FocusedRow ourselves.
			peopleView.DataController.AllowCurrentControllerRow = false;
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

		///<summary>Filters the PledgeTypeTree to allow a limited set of pledge types.  Also disables the textboxes to force the user to pick one of those.</summary>
		public ImportForm SetPledgeTypes(params PledgeType[] types) => SetPledgeTypes((IReadOnlyCollection<PledgeType>)types);
		///<summary>Filters the PledgeTypeTree to allow a limited set of pledge types.  Also disables the textboxes to force the user to pick one of those.</summary>
		public ImportForm SetPledgeTypes(IReadOnlyCollection<PledgeType> types) {
			if (types == null) throw new ArgumentNullException(nameof(types));
			// TODO: Filter the ViewModel inference.
			pledgeTypeTree.PledgeTypes = types;
			PledgeTypeTextEdit.Enabled = false;
			PledgeSubTypeTextEdit.Enabled = false;
			return this;
		}

		///<summary>Forces created pledges (if any) to use a specific type and subtype, disabling textboxes and hiding the tree.</summary>
		public ImportForm FixPledgeType(string type, string subType) {
			viewModel.NewPaymentSelected += delegate {
				viewModel.PledgeType = type;
				viewModel.PledgeSubType = subType;
			};
			PledgeTypeTextEdit.Enabled = false;
			PledgeSubTypeTextEdit.Enabled = false;
			pledgeTypeTreeItem.Visibility = LayoutVisibility.Never;
			return this;
		}

		///<summary>Forces the UI to always create a pledge.</summary>
		public ImportForm RequirePledge() {
			CreatePledgeCheckEdit.Enabled = false;
			viewModel.NewPaymentSelected += (s, e) => viewModel.CreatePledge = true;
			return this;
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

		private async void refresh_ItemClick(object sender, ItemClickEventArgs e) => await LoadPaymentsAsync();
		private async void startDate_EditValueChanged(Object sender, EventArgs e) => await LoadPaymentsAsync();

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

		protected override async void OnShown(EventArgs e) {
			base.OnShown(e);
			await LoadPaymentsAsync();
		}
		async Task LoadPaymentsAsync() {
			await viewModel.LoadPayments((DateTime)startDate.EditValue);
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