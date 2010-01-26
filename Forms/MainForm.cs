using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTabbedMdi;
using ShomreiTorah.WinForms.Controls;

namespace ShomreiTorah.Billing.Forms {
	partial class MainForm : RibbonForm {
		public MainForm() {
			InitializeComponent();
			lookup.SearchTable = Program.Data.MasterDirectory;
			lookup.Columns.Add(new ColumnInfo("BalanceDue", lookup.Columns.Last().Right + 10, 200, "Dues: {0:c}"));

			addDeposit.Strings.AddRange(BillingData.AccountNames.ToArray());

			pledgeEdit.AddNew();
			addPledgePanel.Hide();

			paymentEdit.AddNew();
			addPaymentPanel.Hide();

			pledgeView.ActiveFilterCriteria = new OperandProperty("Modified") > Program.LaunchTime.ToUniversalTime();
			paymentView.ActiveFilterCriteria = new OperandProperty("Modified") > Program.LaunchTime.ToUniversalTime();
			Program.Data.Payments.RowChanged += Payments_RowChanged;
			Program.Data.Pledges.RowChanged += Pledges_RowChanged;

			ribbon.SelectedPage = ribbon.Pages[0];
		}
		#region Modified grids
		void Pledges_RowChanged(object sender, DataRowChangeEventArgs e) {
			if (e.Action != DataRowAction.Add) return;

			pledgeView.BestFitColumns();
			Program.Data.Pledges.RowChanged -= Pledges_RowChanged;
		}
		void Payments_RowChanged(object sender, DataRowChangeEventArgs e) {
			if (e.Action != DataRowAction.Add) return;

			paymentView.BestFitColumns();
			Program.Data.Payments.RowChanged -= Payments_RowChanged;
		}
		private void personRefEdit_ButtonPressed(object sender, ButtonPressedEventArgs e) {
			var edit = sender as ButtonEdit;
			var grid = (Controls.BaseGrid)edit.Parent;
			var view = (GridView)grid.MainView;
			var row = view.GetFocusedDataRow();
			new PersonDetails((BillingData.MasterDirectoryRow)row.GetParentRow(row.Table.ParentRelations[0])) { MdiParent = this }.Show();
		}
		private void gridView_DoubleClick(object sender, EventArgs e) {
			var view = (sender as GridView) ?? (GridView)((Controls.BaseGrid)((BaseEdit)sender).Parent).MainView;

			var row = view.GetFocusedDataRow();

			var payment = row as BillingData.PaymentsRow;
			if (payment != null) new PaymentEditPopup(payment).Show(this);
			var pledge = row as BillingData.PledgesRow;
			if (pledge != null) new PledgeEditPopup(pledge).Show(this);
		}
		#endregion

		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			Program.CloseSplash();
			Program.UIInvoker = this;
			Updater.RunBackground();
			if (Environment.GetCommandLineArgs().Contains("Updated"))
				XtraMessageBox.Show("Congratulations!\r\nYou have successfully updated to version " + Updater.Checker.CurrentVersion,
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void refreshData_ItemClick(object sender, ItemClickEventArgs e) { Program.DoReload(); }
		private void saveDb_ItemClick(object sender, ItemClickEventArgs e) { Program.Data.Save(); }

		protected override void OnClosing(CancelEventArgs e) {
			if (Program.Data.HasChanges()) {
				switch (XtraMessageBox.Show("You have not saved your changes to the database.\r\nWould you like to save before exiting?",
											"Shomrei Torah Billing", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)) {
					case DialogResult.Yes:
						Program.Data.Save();
						break;
					case DialogResult.No:
						break;
					case DialogResult.Cancel:
						e.Cancel = true;
						break;
				}
			}
			base.OnClosing(e);
		}

		private void lookup_ItemSelected(object sender, ItemSelectionEventArgs e) {
			lookup.PopupOpen = false;
			new PersonDetails((BillingData.MasterDirectoryRow)e.SelectedRow) { MdiParent = this }.Show();
		}

		private void mdiManager_MouseDown(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Middle) {
				var hitInfo = mdiManager.CalcHitInfo(e.Location);
				if (hitInfo.InPageCloseButton) return;

				var tab = hitInfo.Page as XtraMdiTabPage;
				if (tab == null) return;
				tab.MdiChild.Close();
			}
		}

		private void checkUpdate_ItemClick(object sender, ItemClickEventArgs e) {
			if (Updater.RestartPending) {
				if (DialogResult.Yes == XtraMessageBox.Show("An update has already been downloaded.\r\nDo you want to restart the program and apply the update?",
															"Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
					Application.Exit();
				return;
			}
			ThreadPool.QueueUserWorkItem(delegate { Updater.RunCheck(); });
		}

		#region Show other forms
		private void showCalendar_ItemClick(object sender, ItemClickEventArgs e) { new CalendarForm().Show(this); }
		private void viewDeposits_ItemClick(object sender, ItemClickEventArgs e) { new DepositViewer { MdiParent = this }.Show(); }
		private void addDeposit_ListItemClick(object sender, ListItemClickEventArgs e) { DepositAdder.Execute(addDeposit.Strings[e.Index]); }

		private void importYK_ItemClick(object sender, ItemClickEventArgs e) { Import.YKImporter.Execute(); }
		private void importJournal_ItemClick(object sender, ItemClickEventArgs e) { Import.Journal.JournalImporter.Execute(); }
		private void importRaffle_ItemClick(object sender, ItemClickEventArgs e) { Import.Raffle.RaffleImporter.Execute(); }

		private void viewPayments_ItemClick(object sender, ItemClickEventArgs e) { new PaymentViewer { MdiParent = this }.Show(); }
		private void viewPledges_ItemClick(object sender, ItemClickEventArgs e) { new PledgeViewer { MdiParent = this }.Show(); }
		private void showMasterDirectoryGrid_ItemClick(object sender, ItemClickEventArgs e) { new MasterDirectoryGridForm { MdiParent = this }.Show(); }

		private void addPayment_ItemClick(object sender, ItemClickEventArgs e) {
			addPaymentPanel.Show();
			paymentEdit.Focus();
		}

		private void addPledge_ItemClick(object sender, ItemClickEventArgs e) {
			addPledgePanel.Show();
			pledgeEdit.Focus();
		}
		#endregion

		#region Statements
		static IEnumerable<BillingData.MasterDirectoryRow> StatementsAll {
			get { return Program.Data.MasterDirectory.Where(p => p.TotalPledged != 0 || p.TotalPaid != 0); }
		}
		static IEnumerable<BillingData.MasterDirectoryRow> StatementsModified {
			get {
				return Program.Data.MasterDirectory.Where(p => p.GetPaymentsRows().Any(t => t.Modified >= Program.LaunchTime.ToUniversalTime())
															|| p.GetPledgesRows().Any(t => t.Modified >= Program.LaunchTime.ToUniversalTime())
														  );
			}
		}
		static void ExportModified(Action<BillingData.MasterDirectoryRow[]> exporter) {
			var people = StatementsModified.ToArray();
			if (people.Any())
				exporter(people);
			else
				XtraMessageBox.Show("You have not created or modified any payments or pledges yet.\r\nWould you like to?",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		private void emailAll_ItemClick(object sender, ItemClickEventArgs e) { Export.EmailExporter.Execute(StatementsAll.ToArray()); }
		private void emailModified_ItemClick(object sender, ItemClickEventArgs e) { ExportModified(Export.EmailExporter.Execute); }

		private void wordAll_ItemClick(object sender, ItemClickEventArgs e) { Export.WordExporter.Execute(StatementsAll.ToArray()); }
		private void wordModified_ItemClick(object sender, ItemClickEventArgs e) { ExportModified(Export.WordExporter.Execute); }
		#endregion

	}
}