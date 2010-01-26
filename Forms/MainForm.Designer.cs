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
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
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
			this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
			this.lookup = new ShomreiTorah.WinForms.Controls.Lookup();
			this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
			this.addPledgePanel = new DevExpress.XtraBars.Docking.DockPanel();
			this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
			this.pledgeGrid = new ShomreiTorah.Billing.Controls.BaseGrid(this.components);
			this.pledgeView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colFullName1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.personRefEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			this.colDate1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSubType = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAccount1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAmount1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colComments1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colModified1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colModifier1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.pledgeEdit = new ShomreiTorah.Billing.Controls.PledgeEdit();
			this.addPaymentPanel = new DevExpress.XtraBars.Docking.DockPanel();
			this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
			this.paymentGrid = new ShomreiTorah.Billing.Controls.BaseGrid(this.components);
			this.paymentView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colMethod = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCheckNumber = new DevExpress.XtraGrid.Columns.GridColumn();
			this.checkNumberEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.colAccount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDepositDateSql = new DevExpress.XtraGrid.Columns.GridColumn();
			this.depositEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			this.colComments = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colModified = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colModifier = new DevExpress.XtraGrid.Columns.GridColumn();
			this.paymentEdit = new ShomreiTorah.Billing.Controls.PaymentEdit();
			this.mdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
			this.addPledgePanel.SuspendLayout();
			this.dockPanel1_Container.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pledgeGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgeView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.personRefEdit)).BeginInit();
			this.addPaymentPanel.SuspendLayout();
			this.controlContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.paymentGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkNumberEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.depositEdit)).BeginInit();
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
            this.importRaffle});
			this.ribbon.Location = new System.Drawing.Point(0, 0);
			this.ribbon.MaxItemId = 20;
			this.ribbon.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
			this.ribbon.Name = "ribbon";
			this.ribbon.PageHeaderItemLinks.Add(this.checkUpdate);
			this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage3,
            this.ribbonPage2});
			this.ribbon.SelectedPage = this.ribbonPage2;
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
			this.ribbonPageGroup3.Name = "ribbonPageGroup3";
			this.ribbonPageGroup3.ShowCaptionButton = false;
			this.ribbonPageGroup3.Text = "People";
			// 
			// ribbonPage2
			// 
			this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4,
            this.ribbonPageGroup5});
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
			// ribbonPageGroup5
			// 
			this.ribbonPageGroup5.ItemLinks.Add(this.importJournal);
			this.ribbonPageGroup5.ItemLinks.Add(this.importRaffle);
			this.ribbonPageGroup5.Name = "ribbonPageGroup5";
			this.ribbonPageGroup5.ShowCaptionButton = false;
			this.ribbonPageGroup5.Text = "Transactions";
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
			this.dockPanel1_Container.Controls.Add(this.pledgeGrid);
			this.dockPanel1_Container.Controls.Add(this.pledgeEdit);
			this.dockPanel1_Container.Location = new System.Drawing.Point(2, 22);
			this.dockPanel1_Container.Name = "dockPanel1_Container";
			this.dockPanel1_Container.Size = new System.Drawing.Size(664, 497);
			this.dockPanel1_Container.TabIndex = 0;
			// 
			// pledgeGrid
			// 
			this.pledgeGrid.DataMember = "Pledges";
			this.pledgeGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pledgeGrid.Location = new System.Drawing.Point(0, 203);
			this.pledgeGrid.MainView = this.pledgeView;
			this.pledgeGrid.MenuManager = this.ribbon;
			this.pledgeGrid.Name = "pledgeGrid";
			this.pledgeGrid.Size = new System.Drawing.Size(664, 294);
			this.pledgeGrid.TabIndex = 1;
			this.pledgeGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.pledgeView});
			// 
			// pledgeView
			// 
			this.pledgeView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFullName1,
            this.colDate1,
            this.colType,
            this.colSubType,
            this.colAccount1,
            this.colAmount1,
            this.colNote,
            this.colComments1,
            this.colModified1,
            this.colModifier1});
			this.pledgeView.GridControl = this.pledgeGrid;
			this.pledgeView.Name = "pledgeView";
			this.pledgeView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
			this.pledgeView.OptionsView.ShowFooter = true;
			this.pledgeView.OptionsView.ShowGroupPanel = false;
			this.pledgeView.OptionsView.ShowIndicator = false;
			this.pledgeView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
			this.pledgeView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colModified1, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.pledgeView.DoubleClick += new System.EventHandler(this.gridView_DoubleClick);
			// 
			// colFullName1
			// 
			this.colFullName1.ColumnEdit = this.personRefEdit;
			this.colFullName1.FieldName = "FullName";
			this.colFullName1.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical;
			this.colFullName1.Name = "colFullName1";
			this.colFullName1.OptionsColumn.ReadOnly = true;
			this.colFullName1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colFullName1.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
			this.colFullName1.SummaryItem.DisplayFormat = "{0} Pledges";
			this.colFullName1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
			this.colFullName1.Visible = true;
			this.colFullName1.VisibleIndex = 0;
			// 
			// personRefEdit
			// 
			this.personRefEdit.AutoHeight = false;
			this.personRefEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("personRefEdit.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Show Person", null, null, true)});
			this.personRefEdit.Name = "personRefEdit";
			this.personRefEdit.ReadOnly = true;
			this.personRefEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.personRefEdit.DoubleClick += new System.EventHandler(this.gridView_DoubleClick);
			this.personRefEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.personRefEdit_ButtonPressed);
			// 
			// colDate1
			// 
			this.colDate1.FieldName = "Date";
			this.colDate1.Name = "colDate1";
			this.colDate1.OptionsColumn.AllowEdit = false;
			this.colDate1.OptionsColumn.AllowFocus = false;
			this.colDate1.OptionsColumn.ReadOnly = true;
			this.colDate1.Visible = true;
			this.colDate1.VisibleIndex = 1;
			// 
			// colType
			// 
			this.colType.FieldName = "Type";
			this.colType.Name = "colType";
			this.colType.OptionsColumn.AllowEdit = false;
			this.colType.OptionsColumn.AllowFocus = false;
			this.colType.OptionsColumn.ReadOnly = true;
			this.colType.Visible = true;
			this.colType.VisibleIndex = 2;
			// 
			// colSubType
			// 
			this.colSubType.FieldName = "SubType";
			this.colSubType.Name = "colSubType";
			this.colSubType.OptionsColumn.AllowEdit = false;
			this.colSubType.OptionsColumn.AllowFocus = false;
			this.colSubType.OptionsColumn.ReadOnly = true;
			this.colSubType.Visible = true;
			this.colSubType.VisibleIndex = 3;
			// 
			// colAccount1
			// 
			this.colAccount1.FieldName = "Account";
			this.colAccount1.Name = "colAccount1";
			this.colAccount1.OptionsColumn.AllowEdit = false;
			this.colAccount1.OptionsColumn.AllowFocus = false;
			this.colAccount1.OptionsColumn.ReadOnly = true;
			this.colAccount1.Visible = true;
			this.colAccount1.VisibleIndex = 4;
			// 
			// colAmount1
			// 
			this.colAmount1.DisplayFormat.FormatString = "c";
			this.colAmount1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colAmount1.FieldName = "Amount";
			this.colAmount1.Name = "colAmount1";
			this.colAmount1.OptionsColumn.AllowEdit = false;
			this.colAmount1.OptionsColumn.AllowFocus = false;
			this.colAmount1.OptionsColumn.ReadOnly = true;
			this.colAmount1.SummaryItem.DisplayFormat = "{0:c} Pledged Added";
			this.colAmount1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.colAmount1.Visible = true;
			this.colAmount1.VisibleIndex = 5;
			// 
			// colNote
			// 
			this.colNote.FieldName = "Note";
			this.colNote.Name = "colNote";
			this.colNote.OptionsColumn.AllowEdit = false;
			this.colNote.OptionsColumn.AllowFocus = false;
			this.colNote.OptionsColumn.ReadOnly = true;
			this.colNote.Visible = true;
			this.colNote.VisibleIndex = 6;
			// 
			// colComments1
			// 
			this.colComments1.FieldName = "Comments";
			this.colComments1.Name = "colComments1";
			this.colComments1.OptionsColumn.AllowEdit = false;
			this.colComments1.OptionsColumn.AllowFocus = false;
			this.colComments1.OptionsColumn.ReadOnly = true;
			this.colComments1.Visible = true;
			this.colComments1.VisibleIndex = 7;
			// 
			// colModified1
			// 
			this.colModified1.DisplayFormat.FormatString = "g";
			this.colModified1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colModified1.FieldName = "Modified";
			this.colModified1.Name = "colModified1";
			this.colModified1.OptionsColumn.AllowEdit = false;
			this.colModified1.OptionsColumn.AllowFocus = false;
			this.colModified1.OptionsColumn.ReadOnly = true;
			// 
			// colModifier1
			// 
			this.colModifier1.FieldName = "Modifier";
			this.colModifier1.Name = "colModifier1";
			this.colModifier1.OptionsColumn.AllowEdit = false;
			this.colModifier1.OptionsColumn.AllowFocus = false;
			this.colModifier1.OptionsColumn.ReadOnly = true;
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
			this.controlContainer1.Controls.Add(this.paymentGrid);
			this.controlContainer1.Controls.Add(this.paymentEdit);
			this.controlContainer1.Location = new System.Drawing.Point(2, 22);
			this.controlContainer1.Name = "controlContainer1";
			this.controlContainer1.Size = new System.Drawing.Size(669, 497);
			this.controlContainer1.TabIndex = 0;
			// 
			// paymentGrid
			// 
			this.paymentGrid.DataMember = "Payments";
			this.paymentGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.paymentGrid.Location = new System.Drawing.Point(0, 175);
			this.paymentGrid.MainView = this.paymentView;
			this.paymentGrid.MenuManager = this.ribbon;
			this.paymentGrid.Name = "paymentGrid";
			this.paymentGrid.Size = new System.Drawing.Size(669, 322);
			this.paymentGrid.TabIndex = 1;
			this.paymentGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.paymentView});
			// 
			// paymentView
			// 
			this.paymentView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFullName,
            this.colDate,
            this.colMethod,
            this.colCheckNumber,
            this.colAccount,
            this.colAmount,
            this.colDepositDateSql,
            this.colComments,
            this.colModified,
            this.colModifier});
			this.paymentView.GridControl = this.paymentGrid;
			this.paymentView.Name = "paymentView";
			this.paymentView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
			this.paymentView.OptionsView.ShowFooter = true;
			this.paymentView.OptionsView.ShowGroupPanel = false;
			this.paymentView.OptionsView.ShowIndicator = false;
			this.paymentView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
			this.paymentView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colModified, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.paymentView.DoubleClick += new System.EventHandler(this.gridView_DoubleClick);
			// 
			// colFullName
			// 
			this.colFullName.ColumnEdit = this.personRefEdit;
			this.colFullName.FieldName = "FullName";
			this.colFullName.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical;
			this.colFullName.Name = "colFullName";
			this.colFullName.OptionsColumn.ReadOnly = true;
			this.colFullName.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colFullName.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
			this.colFullName.SummaryItem.DisplayFormat = "{0} Payments";
			this.colFullName.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
			this.colFullName.Visible = true;
			this.colFullName.VisibleIndex = 0;
			// 
			// colDate
			// 
			this.colDate.FieldName = "Date";
			this.colDate.Name = "colDate";
			this.colDate.OptionsColumn.AllowEdit = false;
			this.colDate.OptionsColumn.AllowFocus = false;
			this.colDate.OptionsColumn.ReadOnly = true;
			this.colDate.Visible = true;
			this.colDate.VisibleIndex = 1;
			// 
			// colMethod
			// 
			this.colMethod.FieldName = "Method";
			this.colMethod.Name = "colMethod";
			this.colMethod.OptionsColumn.AllowEdit = false;
			this.colMethod.OptionsColumn.AllowFocus = false;
			this.colMethod.OptionsColumn.ReadOnly = true;
			this.colMethod.Visible = true;
			this.colMethod.VisibleIndex = 2;
			// 
			// colCheckNumber
			// 
			this.colCheckNumber.ColumnEdit = this.checkNumberEdit;
			this.colCheckNumber.FieldName = "CheckNumber";
			this.colCheckNumber.Name = "colCheckNumber";
			this.colCheckNumber.OptionsColumn.AllowEdit = false;
			this.colCheckNumber.OptionsColumn.AllowFocus = false;
			this.colCheckNumber.OptionsColumn.ReadOnly = true;
			this.colCheckNumber.Visible = true;
			this.colCheckNumber.VisibleIndex = 3;
			// 
			// checkNumberEdit
			// 
			this.checkNumberEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.checkNumberEdit.DisplayFormat.FormatString = "f0";
			this.checkNumberEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.checkNumberEdit.EditFormat.FormatString = "f0";
			this.checkNumberEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.checkNumberEdit.IsFloatValue = false;
			this.checkNumberEdit.Mask.EditMask = "f0";
			this.checkNumberEdit.Name = "checkNumberEdit";
			this.checkNumberEdit.NullText = "N/A";
			// 
			// colAccount
			// 
			this.colAccount.FieldName = "Account";
			this.colAccount.Name = "colAccount";
			this.colAccount.OptionsColumn.AllowEdit = false;
			this.colAccount.OptionsColumn.AllowFocus = false;
			this.colAccount.OptionsColumn.ReadOnly = true;
			this.colAccount.Visible = true;
			this.colAccount.VisibleIndex = 4;
			// 
			// colAmount
			// 
			this.colAmount.DisplayFormat.FormatString = "c";
			this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colAmount.FieldName = "Amount";
			this.colAmount.Name = "colAmount";
			this.colAmount.OptionsColumn.AllowEdit = false;
			this.colAmount.OptionsColumn.AllowFocus = false;
			this.colAmount.OptionsColumn.ReadOnly = true;
			this.colAmount.SummaryItem.DisplayFormat = "{0:c} Paid Added";
			this.colAmount.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.colAmount.Visible = true;
			this.colAmount.VisibleIndex = 5;
			// 
			// colDepositDateSql
			// 
			this.colDepositDateSql.Caption = "Deposited?";
			this.colDepositDateSql.ColumnEdit = this.depositEdit;
			this.colDepositDateSql.FieldName = "Deposit";
			this.colDepositDateSql.Name = "colDepositDateSql";
			this.colDepositDateSql.OptionsColumn.AllowEdit = false;
			this.colDepositDateSql.OptionsColumn.AllowFocus = false;
			this.colDepositDateSql.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.colDepositDateSql.OptionsColumn.ReadOnly = true;
			this.colDepositDateSql.UnboundType = DevExpress.Data.UnboundColumnType.Object;
			this.colDepositDateSql.Visible = true;
			this.colDepositDateSql.VisibleIndex = 6;
			// 
			// depositEdit
			// 
			this.depositEdit.AutoHeight = false;
			this.depositEdit.Name = "depositEdit";
			this.depositEdit.NullText = "Undeposited";
			this.depositEdit.ReadOnly = true;
			// 
			// colComments
			// 
			this.colComments.FieldName = "Comments";
			this.colComments.Name = "colComments";
			this.colComments.OptionsColumn.AllowEdit = false;
			this.colComments.OptionsColumn.AllowFocus = false;
			this.colComments.OptionsColumn.ReadOnly = true;
			this.colComments.Visible = true;
			this.colComments.VisibleIndex = 7;
			// 
			// colModified
			// 
			this.colModified.DisplayFormat.FormatString = "g";
			this.colModified.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colModified.FieldName = "Modified";
			this.colModified.Name = "colModified";
			this.colModified.OptionsColumn.AllowEdit = false;
			this.colModified.OptionsColumn.AllowFocus = false;
			this.colModified.OptionsColumn.ReadOnly = true;
			// 
			// colModifier
			// 
			this.colModifier.FieldName = "Modifier";
			this.colModifier.Name = "colModifier";
			this.colModifier.OptionsColumn.AllowEdit = false;
			this.colModifier.OptionsColumn.AllowFocus = false;
			this.colModifier.OptionsColumn.ReadOnly = true;
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
			((System.ComponentModel.ISupportInitialize)(this.pledgeGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgeView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.personRefEdit)).EndInit();
			this.addPaymentPanel.ResumeLayout(false);
			this.controlContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.paymentGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkNumberEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.depositEdit)).EndInit();
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
		private Controls.BaseGrid pledgeGrid;
		private DevExpress.XtraGrid.Views.Grid.GridView pledgeView;
		private Controls.BaseGrid paymentGrid;
		private DevExpress.XtraGrid.Views.Grid.GridView paymentView;
		private DevExpress.XtraGrid.Columns.GridColumn colFullName;
		private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit personRefEdit;
		private DevExpress.XtraGrid.Columns.GridColumn colDate;
		private DevExpress.XtraGrid.Columns.GridColumn colMethod;
		private DevExpress.XtraGrid.Columns.GridColumn colCheckNumber;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit checkNumberEdit;
		private DevExpress.XtraGrid.Columns.GridColumn colAccount;
		private DevExpress.XtraGrid.Columns.GridColumn colAmount;
		private DevExpress.XtraGrid.Columns.GridColumn colComments;
		private DevExpress.XtraGrid.Columns.GridColumn colModified;
		private DevExpress.XtraGrid.Columns.GridColumn colModifier;
		private DevExpress.XtraGrid.Columns.GridColumn colFullName1;
		private DevExpress.XtraGrid.Columns.GridColumn colDate1;
		private DevExpress.XtraGrid.Columns.GridColumn colType;
		private DevExpress.XtraGrid.Columns.GridColumn colSubType;
		private DevExpress.XtraGrid.Columns.GridColumn colAccount1;
		private DevExpress.XtraGrid.Columns.GridColumn colAmount1;
		private DevExpress.XtraGrid.Columns.GridColumn colNote;
		private DevExpress.XtraGrid.Columns.GridColumn colComments1;
		private DevExpress.XtraGrid.Columns.GridColumn colModified1;
		private DevExpress.XtraGrid.Columns.GridColumn colModifier1;
		private DevExpress.XtraBars.BarButtonItem viewDeposits;
		private DevExpress.XtraBars.BarListItem addDeposit;
		private DevExpress.XtraGrid.Columns.GridColumn colDepositDateSql;
		private DevExpress.XtraBars.BarButtonItem checkUpdate;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
		private DevExpress.XtraBars.BarButtonItem importJournal;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit depositEdit;
		private DevExpress.XtraBars.BarButtonItem emailAll;
		private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
		private DevExpress.XtraBars.BarButtonItem emailModified;
		private DevExpress.XtraBars.BarButtonItem wordAll;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
		private DevExpress.XtraBars.BarButtonItem wordModified;
		private DevExpress.XtraBars.BarButtonItem importRaffle;
	}
}