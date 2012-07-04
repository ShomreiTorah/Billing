using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraTabbedMdi;
using ShomreiTorah.Billing.Events.Purim;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI;
using ShomreiTorah.Data.UI.DisplaySettings;
using ShomreiTorah.Singularity;
using ShomreiTorah.WinForms;

namespace ShomreiTorah.Billing.Forms {
	partial class MainForm : RibbonForm {
		public MainForm() {
			InitializeComponent();

			checkUpdate.Visibility = Updater.Checker == null ? BarItemVisibility.Never : BarItemVisibility.Always;

			EditorRepository.PersonLookup.Apply(lookup.Properties);
			addDeposit.Strings.AddRange(Names.AccountNames.ToArray());

			shalachManosColumnsItem.EditValue = ShalachManosExport.ColumnCount;

			pledgeEdit.AddNew();
			addPledgePanel.Hide();

			paymentEdit.AddNew();
			addPaymentPanel.Hide();

			ribbon.SelectedPage = ribbon.Pages[0];
			SetupYearlyButtons();
		}
		#region Yearly Buttons
		void SetupYearlyButtons() {
			showShalachManos.SetupYearlyButton<Pledge>(
				p => p.Type == ShalachManosForm.PledgeType ? p.Date.Year : new int?(),	//Only count Shalach Manos pledges; don't show years that only have other types
				year => new ShalachManosForm(year) { MdiParent = this }.Show()
			);
			shalachManosExport.SetupYearlyButton<Pledge>(
				p => p.Type == ShalachManosForm.PledgeType ? p.Date.Year : new int?(),
				year => ShalachManosExport.CreateDocument(year)
			);
			showSeatingForm.SetupYearlyButton<SeatingReservation>(
				sr => sr.Pledge.Date.Year,
				year => new Events.Seating.SeatingForm(year) { MdiParent = this }.Show()
			);
			#region Melave Malka
			showInvites.SetupYearlyButton<MelaveMalkaInvitation>(
				mmi => mmi.Year,
				year => new Events.MelaveMalka.InvitationsForm(year) { MdiParent = this }.Show(),
				defaultYear: MelaveMalkaInfo.CurrentYear
			);
			showMMSeating.SetupYearlyButton<MelaveMalkaSeat>(
				mms => mms.Year,
				year => new Events.MelaveMalka.SeatingForm(year) { MdiParent = this }.Show(),
				defaultYear: MelaveMalkaInfo.CurrentYear
			);
			showCallList.SetupYearlyButton<MelaveMalkaInvitation>(
				mmi => mmi.Year,
				year => new Events.MelaveMalka.CallListForm(year) { MdiParent = this }.Show(),
				defaultYear: MelaveMalkaInfo.CurrentYear
			);
			showReminderEmailsForm.SetupYearlyButton<MelaveMalkaInvitation>(
				mmi => mmi.Year,
				year => new Events.MelaveMalka.ReminderEmailsForm(year) { MdiParent = this }.Show(),
				defaultYear: MelaveMalkaInfo.CurrentYear
			);
			importRaffle.SetupYearlyButton<RaffleTicket>(
				t => t.Year,
				year => new Import.Raffle.RaffleImporter(year).Show(this),
				defaultYear: MelaveMalkaInfo.CurrentYear
			);
			#endregion
		}
		#endregion

		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			Program.UIInvoker = this;
			Updater.RunBackground();
			if (Environment.GetCommandLineArgs().Contains("Updated"))
				Dialog.Inform("Congratulations!\r\nYou have successfully updated to version " + Updater.Checker.CurrentVersion);
		}

		private void refreshData_ItemClick(object sender, ItemClickEventArgs e) { Program.Current.RefreshDatabase(); }
		private void saveDb_ItemClick(object sender, ItemClickEventArgs e) { Program.Current.SaveDatabase(); }

		protected override void OnClosing(CancelEventArgs e) {
			if (Program.Current.HasDataChanged) {
				switch (XtraMessageBox.Show("You have not saved your changes to the database.\r\nWould you like to save before exiting?",
											"Shomrei Torah Billing", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)) {
					case DialogResult.Yes:
						Program.Current.SaveDatabase();
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

		private void lookup_EditValueChanged(object sender, EventArgs e) {
			var row = lookup.EditValue as Row;
			if (row == null) return;	//eg, DBNull
			lookup.EditValue = null;
			Program.Current.ShowDetails(row);
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
		private void addDeposit_ListItemClick(object sender, ListItemClickEventArgs e) { DepositAdder.Execute(addDeposit.Strings[e.Index]); }

		private void ribbonPageGroup7_CaptionButtonClick(object sender, RibbonPageGroupEventArgs e) { new Events.MelaveMalka.MMInfoForm().Show(this); }

		private void importYK_ItemClick(object sender, ItemClickEventArgs e) { Import.YKImporter.Execute(); }

		private void viewPayments_ItemClick(object sender, ItemClickEventArgs e) { new GridForms.PaymentViewer { MdiParent = this }.Show(); }
		private void viewPledges_ItemClick(object sender, ItemClickEventArgs e) { new GridForms.PledgeViewer { MdiParent = this }.Show(); }
		private void viewDeposits_ItemClick(object sender, ItemClickEventArgs e) { new GridForms.DepositViewer { MdiParent = this }.Show(); }
		private void showMasterDirectoryGrid_ItemClick(object sender, ItemClickEventArgs e) { new GridForms.MasterDirectoryGridForm { MdiParent = this }.Show(); }
		private void showEmailList_ItemClick(object sender, ItemClickEventArgs e) { new GridForms.EmailListForm { MdiParent = this }.Show(); }

		private void wordGroup_CaptionButtonClick(object sender, RibbonPageGroupEventArgs e) { new GridForms.StatementLogViewer("Word") { MdiParent = this }.Show(); }
		private void emailGroup_CaptionButtonClick(object sender, RibbonPageGroupEventArgs e) { new GridForms.StatementLogViewer("Email") { MdiParent = this }.Show(); }

		private void addRelativeLink_ItemClick(object sender, ItemClickEventArgs e) { RelationCreator.Execute(); }

		private void showAuctionForm_ItemClick(object sender, ItemClickEventArgs e) { new Events.Auctions.EntryForm().Show(this); }

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
		static IEnumerable<Person> StatementsAll {
			get { return Program.Table<Person>().Rows.Where(p => p.Pledges.Any() || p.Payments.Any()); }
		}
		static IEnumerable<Person> StatementsModified {
			get {
				return Program.Table<Person>().Rows.Where(p => p.Pledges.Any(t => t.Modified >= Program.LaunchTime.ToUniversalTime())
															|| p.Payments.Any(t => t.Modified >= Program.LaunchTime.ToUniversalTime())
														  );
			}
		}
		void ExportModified(Action<Form, Person[]> exporter) {
			var people = StatementsModified.ToArray();
			if (people.Any())
				exporter(this, people);
			else
				Dialog.Inform("You have not created or modified any payments or pledges yet.\r\nWould you like to?");
		}
		private void emailAll_ItemClick(object sender, ItemClickEventArgs e) { Statements.Email.EmailExporter.Execute(this, StatementsAll.ToArray()); }
		private void emailModified_ItemClick(object sender, ItemClickEventArgs e) { ExportModified(Statements.Email.EmailExporter.Execute); }

		private void wordAll_ItemClick(object sender, ItemClickEventArgs e) { Statements.Word.WordExporter.Execute(this, StatementsAll.ToArray()); }
		private void wordModified_ItemClick(object sender, ItemClickEventArgs e) { ExportModified(Statements.Word.WordExporter.Execute); }
		#endregion

		private void shalachManosColumnsItem_EditValueChanged(object sender, EventArgs e) {
			ShalachManosExport.ColumnCount = Convert.ToInt32(shalachManosColumnsItem.EditValue, CultureInfo.CurrentCulture);
		}

		private void ribbon_Merge(object sender, RibbonMergeEventArgs e) {
			var childBar = e.MergedChild.StatusBar;
			if (childBar != null)
				ribbonStatusBar.MergeStatusBar(childBar);
		}
		private void ribbon_UnMerge(object sender, RibbonMergeEventArgs e) {
			var childBar = e.MergedChild.StatusBar;
			if (childBar != null)
				ribbonStatusBar.UnMergeStatusBar();
		}
	}
}