namespace ShomreiTorah.Billing.Forms {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
			DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
			DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
			this.addPledge = new DevExpress.XtraBars.BarButtonItem();
			this.viewPledges = new DevExpress.XtraBars.BarButtonItem();
			this.saveDb = new DevExpress.XtraBars.BarButtonItem();
			this.showCalendar = new DevExpress.XtraBars.BarButtonItem();
			this.addPayment = new DevExpress.XtraBars.BarButtonItem();
			this.viewPayments = new DevExpress.XtraBars.BarButtonItem();
			this.showMasterDirectoryGrid = new DevExpress.XtraBars.BarButtonItem();
			this.importYK = new DevExpress.XtraBars.BarButtonItem();
			this.refreshData = new DevExpress.XtraBars.BarButtonItem();
			this.viewDeposits = new DevExpress.XtraBars.BarButtonItem();
			this.addDeposit = new DevExpress.XtraBars.BarListItem();
			this.checkUpdate = new DevExpress.XtraBars.BarButtonItem();
			this.importJournal = new DevExpress.XtraBars.BarButtonItem();
			this.emailAll = new DevExpress.XtraBars.BarButtonItem();
			this.emailModified = new DevExpress.XtraBars.BarButtonItem();
			this.wordAll = new DevExpress.XtraBars.BarButtonItem();
			this.wordModified = new DevExpress.XtraBars.BarButtonItem();
			this.importRaffle = new DevExpress.XtraBars.BarButtonItem();
			this.showShalachManos = new DevExpress.XtraBars.BarButtonItem();
			this.shalachManosExport = new DevExpress.XtraBars.BarButtonItem();
			this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
			this.lookup = new ShomreiTorah.WinForms.Controls.Lookup();
			this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
			this.addPledgePanel = new DevExpress.XtraBars.Docking.DockPanel();
			this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
			this.modifiedPledgesGrid = new ShomreiTorah.Billing.Controls.ModifiedPledgesGrid();
			this.pledgeEdit = new ShomreiTorah.Billing.Controls.PledgeEdit();
			this.addPaymentPanel = new DevExpress.XtraBars.Docking.DockPanel();
			this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
			this.modifiedPaymentsGrid = new ShomreiTorah.Billing.Controls.ModifiedPaymentsGrid();
			this.paymentEdit = new ShomreiTorah.Billing.Controls.PaymentEdit();
			this.mdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
			this.showEmailList = new DevExpress.XtraBars.BarButtonItem();
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
			this.addPledgePanel.SuspendLayout();
			this.dockPanel1_Container.SuspendLayout();
			this.addPaymentPanel.SuspendLayout();
			this.controlContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mdiManager)).BeginInit();
			this.SuspendLayout();
			// 
			// ribbon
			// 
			this.ribbon.ApplicationCaption = "Shomrei Torah Billing";
			this.ribbon.ApplicationIcon = global::ShomreiTorah.Billing.Properties.Resources.RibbonIcon;
			this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.addPledge,
            this.viewPledges,
            this.saveDb,
            this.showCalendar,
            this.addPayment,
            this.viewPayments,
            this.showMasterDirectoryGrid,
            this.importYK,
            this.refreshData,
            this.viewDeposits,
            this.addDeposit,
            this.checkUpdate,
            this.importJournal,
            this.emailAll,
            this.emailModified,
            this.wordAll,
            this.wordModified,
            this.importRaffle,
            this.showShalachManos,
            this.shalachManosExport,
            this.showEmailList});
			this.ribbon.Location = new System.Drawing.Point(0, 0);
			this.ribbon.MaxItemId = 23;
			this.ribbon.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
			this.ribbon.Name = "ribbon";
			this.ribbon.PageHeaderItemLinks.Add(this.checkUpdate);
			this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage3,
            this.ribbonPage4,
            this.ribbonPage2});
			this.ribbon.SelectedPage = this.ribbonPage1;
			this.ribbon.Size = new System.Drawing.Size(858, 148);
			this.ribbon.StatusBar = this.ribbonStatusBar;
			this.ribbon.Toolbar.ItemLinks.Add(this.saveDb);
			this.ribbon.Toolbar.ItemLinks.Add(this.refreshData);
			this.ribbon.Toolbar.ItemLinks.Add(this.showCalendar, true);
			// 
			// addPledge
			// 
			this.addPledge.Caption = "Add pledge";
			this.addPledge.Id = 0;
			this.addPledge.Name = "addPledge";
			this.addPledge.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addPledge_ItemClick);
			// 
			// viewPledges
			// 
			this.viewPledges.Caption = "Show all pledges";
			this.viewPledges.Id = 1;
			this.viewPledges.Name = "viewPledges";
			this.viewPledges.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.viewPledges_ItemClick);
			// 
			// saveDb
			// 
			this.saveDb.Caption = "Save to database";
			this.saveDb.Glyph = global::ShomreiTorah.Billing.Properties.Resources.Save16;
			this.saveDb.Id = 2;
			this.saveDb.Name = "saveDb";
			toolTipTitleItem1.Text = "Save";
			toolTipItem1.LeftIndent = 6;
			toolTipItem1.Text = "Saves your changes to SQL Server.";
			superToolTip1.Items.Add(toolTipTitleItem1);
			superToolTip1.Items.Add(toolTipItem1);
			this.saveDb.SuperTip = superToolTip1;
			this.saveDb.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.saveDb_ItemClick);
			// 
			// showCalendar
			// 
			this.showCalendar.Caption = "Show Calendar";
			this.showCalendar.Glyph = global::ShomreiTorah.Billing.Properties.Resources.Calendar16;
			this.showCalendar.Id = 3;
			this.showCalendar.Name = "showCalendar";
			toolTipTitleItem2.Text = "Show Calendar";
			toolTipItem2.LeftIndent = 6;
			toolTipItem2.Text = "Displays a Hebrew calendar";
			superToolTip2.Items.Add(toolTipTitleItem2);
			superToolTip2.Items.Add(toolTipItem2);
			this.showCalendar.SuperTip = superToolTip2;
			this.showCalendar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.showCalendar_ItemClick);
			// 
			// addPayment
			// 
			this.addPayment.Caption = "Add payment";
			this.addPayment.Id = 4;
			this.addPayment.Name = "addPayment";
			this.addPayment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addPayment_ItemClick);
			// 
			// viewPayments
			// 
			this.viewPayments.Caption = "Show all payments";
			this.viewPayments.Id = 5;
			this.viewPayments.Name = "viewPayments";
			this.viewPayments.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.viewPayments_ItemClick);
			// 
			// showMasterDirectoryGrid
			// 
			this.showMasterDirectoryGrid.Caption = "Show all people";
			this.showMasterDirectoryGrid.Id = 6;
			this.showMasterDirectoryGrid.Name = "showMasterDirectoryGrid";
			this.showMasterDirectoryGrid.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.showMasterDirectoryGrid_ItemClick);
			// 
			// importYK
			// 
			this.importYK.Caption = "Import YK Directory";
			this.importYK.Id = 7;
			this.importYK.LargeGlyph = global::ShomreiTorah.Billing.Properties.Resources.ImportExcel32;
			this.importYK.Name = "importYK";
			this.importYK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.importYK_ItemClick);
			// 
			// refreshData
			// 
			this.refreshData.Caption = "Reload from database";
			this.refreshData.Glyph = global::ShomreiTorah.Billing.Properties.Resources.Refresh16;
			this.refreshData.Id = 8;
			this.refreshData.Name = "refreshData";
			toolTipTitleItem3.Text = "Reload From Database";
			toolTipItem3.LeftIndent = 6;
			toolTipItem3.Text = "Saves your changes, then reloads the data from the SQL Server.";
			superToolTip3.Items.Add(toolTipTitleItem3);
			superToolTip3.Items.Add(toolTipItem3);
			this.refreshData.SuperTip = superToolTip3;
			this.refreshData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.refreshData_ItemClick);
			// 
			// viewDeposits
			// 
			this.viewDeposits.Caption = "Show all deposits";
			this.viewDeposits.Id = 9;
			this.viewDeposits.Name = "viewDeposits";
			this.viewDeposits.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.viewDeposits_ItemClick);
			// 
			// addDeposit
			// 
			this.addDeposit.Caption = "Add deposit";
			this.addDeposit.Id = 11;
			this.addDeposit.Name = "addDeposit";
			this.addDeposit.ListItemClick += new DevExpress.XtraBars.ListItemClickEventHandler(this.addDeposit_ListItemClick);
			// 
			// checkUpdate
			// 
			this.checkUpdate.Caption = "Check for updates";
			this.checkUpdate.Glyph = global::ShomreiTorah.Billing.Properties.Resources.Update16;
			this.checkUpdate.Id = 12;
			this.checkUpdate.Name = "checkUpdate";
			this.checkUpdate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.checkUpdate_ItemClick);
			// 
			// importJournal
			// 
			this.importJournal.Caption = "Import Journal";
			this.importJournal.Id = 14;
			this.importJournal.LargeGlyph = global::ShomreiTorah.Billing.Properties.Resources.ImportJournal32;
			this.importJournal.Name = "importJournal";
			this.importJournal.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.importJournal_ItemClick);
			// 
			// emailAll
			// 
			this.emailAll.Caption = "Everyone";
			this.emailAll.Id = 15;
			this.emailAll.Name = "emailAll";
			this.emailAll.SmallWithTextWidth = 150;
			this.emailAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.emailAll_ItemClick);
			// 
			// emailModified
			// 
			this.emailModified.Caption = "Recently updated people";
			this.emailModified.Id = 16;
			this.emailModified.Name = "emailModified";
			this.emailModified.SmallWithTextWidth = 150;
			this.emailModified.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.emailModified_ItemClick);
			// 
			// wordAll
			// 
			this.wordAll.Caption = "Everyone";
			this.wordAll.Id = 17;
			this.wordAll.Name = "wordAll";
			this.wordAll.SmallWithTextWidth = 150;
			this.wordAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.wordAll_ItemClick);
			// 
			// wordModified
			// 
			this.wordModified.Caption = "Recently updated people";
			this.wordModified.Id = 18;
			this.wordModified.Name = "wordModified";
			this.wordModified.SmallWithTextWidth = 150;
			this.wordModified.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.wordModified_ItemClick);
			// 
			// importRaffle
			// 
			this.importRaffle.Caption = "Import Raffle";
			this.importRaffle.Id = 19;
			this.importRaffle.LargeGlyph = global::ShomreiTorah.Billing.Properties.Resources.ImportRaffle32;
			this.importRaffle.Name = "importRaffle";
			this.importRaffle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.importRaffle_ItemClick);
			// 
			// showShalachManos
			// 
			this.showShalachManos.Caption = "Shalach Manos";
			this.showShalachManos.Id = 20;
			this.showShalachManos.LargeGlyph = global::ShomreiTorah.Billing.Properties.Resources.ShalachManosList32;
			this.showShalachManos.Name = "showShalachManos";
			this.showShalachManos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.showShalachManos_ItemClick);
			// 
			// shalachManosExport
			// 
			this.shalachManosExport.Caption = "Create Scroll";
			this.shalachManosExport.Id = 21;
			this.shalachManosExport.LargeGlyph = global::ShomreiTorah.Billing.Properties.Resources.ExportScroll32;
			this.shalachManosExport.Name = "shalachManosExport";
			this.shalachManosExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.shalachManosExport_ItemClick);
			// 
			// ribbonPage1
			// 
			this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
			this.ribbonPage1.Name = "ribbonPage1";
			this.ribbonPage1.Text = "Data";
			// 
			// ribbonPageGroup1
			// 
			this.ribbonPageGroup1.ItemLinks.Add(this.addPledge);
			this.ribbonPageGroup1.ItemLinks.Add(this.viewPledges);
			this.ribbonPageGroup1.Name = "ribbonPageGroup1";
			this.ribbonPageGroup1.ShowCaptionButton = false;
			this.ribbonPageGroup1.Text = "Pledges";
			// 
			// ribbonPageGroup2
			// 
			this.ribbonPageGroup2.ItemLinks.Add(this.addPayment);
			this.ribbonPageGroup2.ItemLinks.Add(this.viewPayments);
			this.ribbonPageGroup2.ItemLinks.Add(this.addDeposit, true);
			this.ribbonPageGroup2.ItemLinks.Add(this.viewDeposits);
			this.ribbonPageGroup2.Name = "ribbonPageGroup2";
			this.ribbonPageGroup2.ShowCaptionButton = false;
			this.ribbonPageGroup2.Text = "Payments";
			// 
			// ribbonPageGroup3
			// 
			this.ribbonPageGroup3.ItemLinks.Add(this.showMasterDirectoryGrid);
			this.ribbonPageGroup3.ItemLinks.Add(this.showEmailList);
			this.ribbonPageGroup3.Name = "ribbonPageGroup3";
			this.ribbonPageGroup3.ShowCaptionButton = false;
			this.ribbonPageGroup3.Text = "People";
			// 
			// ribbonPage3
			// 
			this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup6,
            this.ribbonPageGroup7});
			this.ribbonPage3.Name = "ribbonPage3";
			this.ribbonPage3.Text = "Statements";
			// 
			// ribbonPageGroup6
			// 
			this.ribbonPageGroup6.ItemLinks.Add(this.emailAll);
			this.ribbonPageGroup6.ItemLinks.Add(this.emailModified);
			this.ribbonPageGroup6.Name = "ribbonPageGroup6";
			this.ribbonPageGroup6.ShowCaptionButton = false;
			this.ribbonPageGroup6.Text = "Send Emails to";
			// 
			// ribbonPageGroup7
			// 
			this.ribbonPageGroup7.ItemLinks.Add(this.wordAll);
			this.ribbonPageGroup7.ItemLinks.Add(this.wordModified);
			this.ribbonPageGroup7.Name = "ribbonPageGroup7";
			this.ribbonPageGroup7.ShowCaptionButton = false;
			this.ribbonPageGroup7.Text = "Create Word Documents for";
			// 
			// ribbonPage4
			// 
			this.ribbonPage4.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5,
            this.ribbonPageGroup8});
			this.ribbonPage4.Name = "ribbonPage4";
			this.ribbonPage4.Text = "Events";
			// 
			// ribbonPageGroup5
			// 
			this.ribbonPageGroup5.ItemLinks.Add(this.importJournal);
			this.ribbonPageGroup5.ItemLinks.Add(this.importRaffle);
			this.ribbonPageGroup5.Name = "ribbonPageGroup5";
			this.ribbonPageGroup5.ShowCaptionButton = false;
			this.ribbonPageGroup5.Text = "Melave Malka";
			// 
			// ribbonPageGroup8
			// 
			this.ribbonPageGroup8.ItemLinks.Add(this.showShalachManos);
			this.ribbonPageGroup8.ItemLinks.Add(this.shalachManosExport);
			this.ribbonPageGroup8.Name = "ribbonPageGroup8";
			this.ribbonPageGroup8.ShowCaptionButton = false;
			this.ribbonPageGroup8.Text = "Purim";
			// 
			// ribbonPage2
			// 
			this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
			this.ribbonPage2.Name = "ribbonPage2";
			this.ribbonPage2.Text = "Import";
			// 
			// ribbonPageGroup4
			// 
			this.ribbonPageGroup4.ItemLinks.Add(this.importYK);
			this.ribbonPageGroup4.Name = "ribbonPageGroup4";
			this.ribbonPageGroup4.ShowCaptionButton = false;
			this.ribbonPageGroup4.Text = "People";
			// 
			// ribbonStatusBar
			// 
			this.ribbonStatusBar.Location = new System.Drawing.Point(0, 603);
			this.ribbonStatusBar.Name = "ribbonStatusBar";
			this.ribbonStatusBar.Ribbon = this.ribbon;
			this.ribbonStatusBar.Size = new System.Drawing.Size(858, 23);
			// 
			// lookup
			// 
			this.lookup.Caption = "Type name:";
			this.lookup.DefaultText = "Click here to search the YK Directory";
			this.lookup.Dock = System.Windows.Forms.DockStyle.Top;
			this.lookup.Location = new System.Drawing.Point(0, 148);
			this.lookup.MaxPopupHeight = 200;
			this.lookup.Name = "lookup";
			this.lookup.PopupOpen = false;
			this.lookup.ResultsLocation = ShomreiTorah.WinForms.Controls.ResultsLocation.Bottom;
			this.lookup.ScrollPosition = 0;
			this.lookup.SearchTable = null;
			this.lookup.SelectedIndex = -1;
			this.lookup.Size = new System.Drawing.Size(858, 20);
			this.lookup.TabIndex = 5;
			this.lookup.TabStop = false;
			this.lookup.ItemSelected += new System.EventHandler<ShomreiTorah.WinForms.Controls.ItemSelectionEventArgs>(this.lookup_ItemSelected);
			// 
			// dockManager
			// 
			this.dockManager.Form = this;
			this.dockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.addPledgePanel,
            this.addPaymentPanel});
			this.dockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
			// 
			// addPledgePanel
			// 
			this.addPledgePanel.Controls.Add(this.dockPanel1_Container);
			this.addPledgePanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
			this.addPledgePanel.FloatLocation = new System.Drawing.Point(34, 434);
			this.addPledgePanel.FloatSize = new System.Drawing.Size(668, 521);
			this.addPledgePanel.FloatVertical = true;
			this.addPledgePanel.ID = new System.Guid("ef70c184-c124-40ca-840c-8acd0208251f");
			this.addPledgePanel.Location = new System.Drawing.Point(0, 0);
			this.addPledgePanel.Name = "addPledgePanel";
			this.addPledgePanel.OriginalSize = new System.Drawing.Size(200, 367);
			this.addPledgePanel.Size = new System.Drawing.Size(668, 521);
			this.addPledgePanel.Text = "Add Pledge";
			// 
			// dockPanel1_Container
			// 
			this.dockPanel1_Container.Controls.Add(this.modifiedPledgesGrid);
			this.dockPanel1_Container.Controls.Add(this.pledgeEdit);
			this.dockPanel1_Container.Location = new System.Drawing.Point(2, 22);
			this.dockPanel1_Container.Name = "dockPanel1_Container";
			this.dockPanel1_Container.Size = new System.Drawing.Size(664, 497);
			this.dockPanel1_Container.TabIndex = 0;
			// 
			// modifiedPledgesGrid
			// 
			this.modifiedPledgesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.modifiedPledgesGrid.Location = new System.Drawing.Point(0, 203);
			this.modifiedPledgesGrid.MainForm = this;
			this.modifiedPledgesGrid.Name = "modifiedPledgesGrid";
			this.modifiedPledgesGrid.Size = new System.Drawing.Size(664, 294);
			this.modifiedPledgesGrid.TabIndex = 1;
			// 
			// pledgeEdit
			// 
			this.pledgeEdit.Dock = System.Windows.Forms.DockStyle.Top;
			this.pledgeEdit.Location = new System.Drawing.Point(0, 0);
			this.pledgeEdit.MinimumSize = new System.Drawing.Size(480, 123);
			this.pledgeEdit.Name = "pledgeEdit";
			this.pledgeEdit.Size = new System.Drawing.Size(664, 203);
			this.pledgeEdit.TabIndex = 0;
			// 
			// addPaymentPanel
			// 
			this.addPaymentPanel.Controls.Add(this.controlContainer1);
			this.addPaymentPanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Float;
			this.addPaymentPanel.FloatLocation = new System.Drawing.Point(702, 434);
			this.addPaymentPanel.FloatSize = new System.Drawing.Size(673, 521);
			this.addPaymentPanel.ID = new System.Guid("600e06f2-9c0f-4dd9-8edf-3a67b0468999");
			this.addPaymentPanel.Location = new System.Drawing.Point(0, 0);
			this.addPaymentPanel.Name = "addPaymentPanel";
			this.addPaymentPanel.OriginalSize = new System.Drawing.Size(433, 199);
			this.addPaymentPanel.Size = new System.Drawing.Size(673, 521);
			this.addPaymentPanel.Text = "Add Payment";
			// 
			// controlContainer1
			// 
			this.controlContainer1.Controls.Add(this.modifiedPaymentsGrid);
			this.controlContainer1.Controls.Add(this.paymentEdit);
			this.controlContainer1.Location = new System.Drawing.Point(2, 22);
			this.controlContainer1.Name = "controlContainer1";
			this.controlContainer1.Size = new System.Drawing.Size(669, 497);
			this.controlContainer1.TabIndex = 0;
			// 
			// modifiedPaymentsGrid
			// 
			this.modifiedPaymentsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.modifiedPaymentsGrid.Location = new System.Drawing.Point(0, 175);
			this.modifiedPaymentsGrid.MainForm = this;
			this.modifiedPaymentsGrid.Name = "modifiedPaymentsGrid";
			this.modifiedPaymentsGrid.Size = new System.Drawing.Size(669, 322);
			this.modifiedPaymentsGrid.TabIndex = 1;
			// 
			// paymentEdit
			// 
			this.paymentEdit.Dock = System.Windows.Forms.DockStyle.Top;
			this.paymentEdit.Location = new System.Drawing.Point(0, 0);
			this.paymentEdit.MinimumSize = new System.Drawing.Size(347, 149);
			this.paymentEdit.Name = "paymentEdit";
			this.paymentEdit.Size = new System.Drawing.Size(669, 175);
			this.paymentEdit.TabIndex = 0;
			// 
			// mdiManager
			// 
			this.mdiManager.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPagesAndTabControlHeader;
			this.mdiManager.MdiParent = this;
			this.mdiManager.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mdiManager_MouseDown);
			// 
			// showEmailList
			// 
			this.showEmailList.Caption = "Show email list";
			this.showEmailList.Id = 22;
			this.showEmailList.Name = "showEmailList";
			this.showEmailList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.showEmailList_ItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(858, 626);
			this.Controls.Add(this.lookup);
			this.Controls.Add(this.ribbonStatusBar);
			this.Controls.Add(this.ribbon);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.Name = "MainForm";
			this.Ribbon = this.ribbon;
			this.StatusBar = this.ribbonStatusBar;
			this.Text = "Shomrei Torah Billing";
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
			this.addPledgePanel.ResumeLayout(false);
			this.dockPanel1_Container.ResumeLayout(false);
			this.addPaymentPanel.ResumeLayout(false);
			this.controlContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mdiManager)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
		private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
		private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
		private ShomreiTorah.WinForms.Controls.Lookup lookup;
		private DevExpress.XtraBars.Docking.DockManager dockManager;
		private DevExpress.XtraBars.Docking.DockPanel addPledgePanel;
		private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
		private ShomreiTorah.Billing.Controls.PledgeEdit pledgeEdit;
		private DevExpress.XtraBars.BarButtonItem addPledge;
		private DevExpress.XtraBars.BarButtonItem viewPledges;
		private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager mdiManager;
		private DevExpress.XtraBars.BarButtonItem saveDb;
		private DevExpress.XtraBars.BarButtonItem showCalendar;
		private DevExpress.XtraBars.BarButtonItem addPayment;
		private DevExpress.XtraBars.BarButtonItem viewPayments;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
		private DevExpress.XtraBars.Docking.DockPanel addPaymentPanel;
		private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
		private ShomreiTorah.Billing.Controls.PaymentEdit paymentEdit;
		private DevExpress.XtraBars.BarButtonItem showMasterDirectoryGrid;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
		private DevExpress.XtraBars.BarButtonItem importYK;
		private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
		private DevExpress.XtraBars.BarButtonItem refreshData;
		private DevExpress.XtraBars.BarButtonItem viewDeposits;
		private DevExpress.XtraBars.BarListItem addDeposit;
		private DevExpress.XtraBars.BarButtonItem checkUpdate;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
		private DevExpress.XtraBars.BarButtonItem importJournal;
		private DevExpress.XtraBars.BarButtonItem emailAll;
		private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
		private DevExpress.XtraBars.BarButtonItem emailModified;
		private DevExpress.XtraBars.BarButtonItem wordAll;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
		private DevExpress.XtraBars.BarButtonItem wordModified;
		private DevExpress.XtraBars.BarButtonItem importRaffle;
		private DevExpress.XtraBars.BarButtonItem showShalachManos;
		private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
		private DevExpress.XtraBars.BarButtonItem shalachManosExport;
		private ShomreiTorah.Billing.Controls.ModifiedPledgesGrid modifiedPledgesGrid;
		private ShomreiTorah.Billing.Controls.ModifiedPaymentsGrid modifiedPaymentsGrid;
		private DevExpress.XtraBars.BarButtonItem showEmailList;
	}
}