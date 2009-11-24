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
		#endregion

		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			Program.CloseSplash();
			Program.SyncContext = SynchronizationContext.Current;
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

		private void addDeposit_ListItemClick(object sender, ListItemClickEventArgs e) { DepositAdder.Execute(addDeposit.Strings[e.Index]); }

		private void showCalendar_ItemClick(object sender, ItemClickEventArgs e) {
			new CalendarForm().Show(this);
			if (ModifierKeys == (Keys.Alt | Keys.Control))
				throw new InvalidExpressionException("This is a test crash!");
		}
		private void importYK_ItemClick(object sender, ItemClickEventArgs e) { Import.YKImporter.Execute(); }

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


		private void mdiManager_MouseDown(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Middle) {
				var hitInfo = mdiManager.CalcHitInfo(e.Location);
				if (hitInfo.InPageCloseButton) return;

				var tab = hitInfo.Page as XtraMdiTabPage;
				if (tab == null) return;
				tab.MdiChild.Close();
			}
		}

		private void viewDeposits_ItemClick(object sender, ItemClickEventArgs e) { new DepositViewer { MdiParent = this }.Show(); }
	}
}