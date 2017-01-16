using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Composition;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraGrid.Views.Layout.Events;
using DevExpress.XtraLayout.Utils;
using ShomreiTorah.Data;
using ShomreiTorah.WinForms;
using ShomreiTorah.WinForms.Forms;

namespace ShomreiTorah.Billing.PaymentImport {
	[Export]
	public partial class ImportForm : XtraForm {
		readonly ViewModel viewModel;
		bool isJournalMode;

		[ImportingConstructor]
		public ImportForm(ViewModel viewModel) {
			InitializeComponent();
			this.viewModel = viewModel;
			// Don't reset focused row when list changes.  We bind FocusedRow ourselves.
			peopleView.DataController.AllowCurrentControllerRow = false;
			viewModelBindingSource.DataSource = viewModel;
			viewModel.PropertyChanged += ViewModel_PropertyChanged;
			startDate.EditValue = DateTime.Today.AddDays(-14);
			personSelector.Properties.NewPersonTemplate = e => Genderizer.Create().SetFirstName(viewModel.CurrentPayment.FirstName, new Person {
				Address = viewModel.CurrentPayment.Address,
				City = viewModel.CurrentPayment.City,
				FullName = viewModel.CurrentPayment.FirstName + " " + viewModel.CurrentPayment.LastName,
				LastName = viewModel.CurrentPayment.LastName,
				Phone = viewModel.CurrentPayment.Phone,
				Source = "Credit Card Import",
				State = viewModel.CurrentPayment.State,
				Zip = viewModel.CurrentPayment.Zip
			});

			viewModel.ImportCallback = (info, payment, pledge) => {
				var pledgeMessage = pledge == null ? "" : $"and {pledge.Type} pledge ";
				InfoMessage.Show($"A {payment.Amount:C} payment {pledgeMessage}has been imported to {payment.Person.FullName}.");
			};
		}

		///<summary>Filters the PledgeTypeTree to allow a limited set of pledge types.  Also disables the textboxes to force the user to pick one of those.</summary>
		public ImportForm SetPledgeTypes(params PledgeType[] types) => SetPledgeTypes((IReadOnlyCollection<PledgeType>)types);
		///<summary>Filters the PledgeTypeTree to allow a limited set of pledge types.  Also disables the textboxes to force the user to pick one of those.</summary>
		public ImportForm SetPledgeTypes(IReadOnlyCollection<PledgeType> types) {
			if (types == null) throw new ArgumentNullException(nameof(types));
			viewModel.PledgeTypes = types;
			pledgeTypeTree.PledgeTypes = types;
			PledgeTypeTextEdit.DataBindings.Remove(PledgeTypeTextEdit.DataBindings[nameof(PledgeTypeTextEdit.Enabled)]);
			PledgeSubTypeTextEdit.DataBindings.Remove(PledgeSubTypeTextEdit.DataBindings[nameof(PledgeSubTypeTextEdit.Enabled)]);
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
			PledgeTypeTextEdit.DataBindings.Remove(PledgeTypeTextEdit.DataBindings[nameof(PledgeTypeTextEdit.Enabled)]);
			PledgeSubTypeTextEdit.DataBindings.Remove(PledgeSubTypeTextEdit.DataBindings[nameof(PledgeSubTypeTextEdit.Enabled)]);
			PledgeTypeTextEdit.Enabled = false;
			PledgeSubTypeTextEdit.Enabled = false;
			pledgeTypeTreeItem.Visibility = LayoutVisibility.Never;
			return this;
		}

		///<summary>Filters the payments grid to only show journal payments, and hides the warning for them.</summary>
		public ImportForm SetJournalMode(int year) {
			Text = "Import Ads";
			import.Caption = "Create Ad";
			isJournalMode = true;
			viewModel.PaymentFilter = payment => JournalAd.InferYear(payment.Date) == year
											  && !string.IsNullOrWhiteSpace(payment.JournalInfo?.AdText);
			return this;
		}

		///<summary>Forces the UI to always create a pledge.</summary>
		public ImportForm RequirePledge() {
			CreatePledgeCheckEdit.Enabled = false;
			viewModel.NewPaymentSelected += (s, e) => viewModel.CreatePledge = true;
			return this;
		}

		///<summary>Sets a single callback to run after each payment is imported.  This should call <see cref="InfoMessage.Show(string)"/>.</summary>
		public ImportForm SetCreationCallback(Action<PaymentInfo, Payment, Pledge> callback) {
			viewModel.ImportCallback = callback;
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

			if (viewModel.CurrentPayment == null && viewModel.AvailablePayments.Any()) {
				viewModel.CurrentPayment = viewModel.AvailablePayments.First();
			}
			importUI.Visible = viewModel.CurrentPayment != null;
			if (viewModel.CurrentPayment == null) {
				var date = ((DateTime)startDate.EditValue).ToLongDateString();
				var importType = isJournalMode ? "journal ad payment" : "payment";
				emptyState.Text =
					viewModel.PaymentsExist ? $"Congratulations!\r\nYou've already imported every {importType} since {date}."
											: $"There were no {importType}s since {date}.\r\nTry selecting an earlier date.";
				if (isJournalMode)
					emptyState.Text += "\n\nOr use the billing to see & import non-journal payments.";
			}
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
		private async void startDate_EditValueChanged(Object sender, EventArgs e) {
			if (Visible) await LoadPaymentsAsync();
		}

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
			// DevExpress bug: Won't exist in PowerPoint addon.
			SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());

			try {
				await viewModel.LoadPayments((DateTime)startDate.EditValue);
			} catch (Exception ex) {
				Dialog.ShowError("An error occurred while loading payments.\r\n" + ex.GetBaseException().Message);
			}
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

		private void availablePaymentsView_CustomCardLayout(object sender, LayoutViewCustomCardLayoutEventArgs e) {
			var payment = (PaymentInfo)availablePaymentsView.GetRow(e.RowHandle);
			e.CardDifferences.AddItemDifference(fieldWarning.Name,
				LayoutItemDifferenceType.ItemVisibility,
				!isJournalMode && payment.JournalInfo != null
			);
		}

		// I cannot easily make the ViewModel use RowListBinder
		// so the grid can only provide properties.
		private void peopleView_CustomUnboundColumnData(Object sender, CustomColumnDataEventArgs e) {
			if (e.Column == colBalanceDue)
				e.Value = ((Singularity.Row)e.Row).Field<decimal>("BalanceDue");
		}
	}
}