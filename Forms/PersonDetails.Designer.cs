namespace ShomreiTorah.Billing.Forms {
	partial class PersonDetails {
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
			DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
			DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
			DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
			this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
			this.exportEmail = new DevExpress.XtraBars.BarButtonItem();
			this.exportWord = new DevExpress.XtraBars.BarButtonItem();
			this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.personBindingSource = new ShomreiTorah.Data.UI.FrameworkBindingSource(this.components);
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.emailGrid = new ShomreiTorah.Data.UI.Grid.SmartGrid(this.components);
			this.emailView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colEmail = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colActive = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.personEditPanel = new DevExpress.XtraEditors.PanelControl();
			this.closePersonEdit = new DevExpress.XtraEditors.SimpleButton();
			this.personEditor = new ShomreiTorah.Data.UI.Controls.PersonEditor();
			this.showPersonEdit = new DevExpress.XtraEditors.SimpleButton();
			this.details = new DevExpress.XtraEditors.MemoEdit();
			this.map = new ShomreiTorah.WinForms.Controls.GoogleMapControl();
			this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
			this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
			this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
			this.pledgeGrid = new ShomreiTorah.Data.UI.Grid.SmartGrid(this.components);
			this.pledgeView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colDate = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colType = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colSubType = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAccount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.accountEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.colAmount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.currencyEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.colNote = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.repositoryItemAliyahNoteEdit1 = new ShomreiTorah.Billing.Controls.Editors.RepositoryItemAliyahNoteEdit();
			this.colComments = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colModified = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colModifier = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.paymentsGrid = new ShomreiTorah.Data.UI.Grid.SmartGrid(this.components);
			this.paymentsView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colDate1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAccount2 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colMethod = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.paymentMethodEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.colCheckNumber = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.checkNumberEdit = new ShomreiTorah.Data.UI.Controls.RepositoryItemCheckNumberEdit();
			this.colAmount1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colDeposit = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.depositEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			this.colComments1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colModified1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colModifier1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
			this.statementsGrid = new ShomreiTorah.Data.UI.Grid.SmartGrid(this.components);
			this.statementsView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colDateGenerated = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colMedia = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colStatementKind = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colStartDate = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colEndDate = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colUserName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.addRLAsMember = new DevExpress.XtraBars.BarButtonItem();
			this.addRLAsRelative = new DevExpress.XtraBars.BarButtonItem();
			((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.emailGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emailView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.personEditPanel)).BeginInit();
			this.personEditPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.details.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
			this.xtraTabControl1.SuspendLayout();
			this.xtraTabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
			this.splitContainerControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pledgeGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgeView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.accountEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.currencyEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemAliyahNoteEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentsGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentsView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentMethodEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkNumberEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.depositEdit)).BeginInit();
			this.xtraTabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.statementsGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statementsView)).BeginInit();
			this.SuspendLayout();
			// 
			// ribbonControl1
			// 
			this.ribbonControl1.ApplicationButtonText = null;
			// 
			// 
			// 
			this.ribbonControl1.ExpandCollapseItem.Id = 0;
			this.ribbonControl1.ExpandCollapseItem.Name = "";
			this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.exportEmail,
            this.exportWord,
            this.addRLAsMember,
            this.addRLAsRelative});
			this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
			this.ribbonControl1.MaxItemId = 4;
			this.ribbonControl1.Name = "ribbonControl1";
			this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2,
            this.ribbonPage1});
			this.ribbonControl1.SelectedPage = this.ribbonPage2;
			this.ribbonControl1.Size = new System.Drawing.Size(954, 114);
			this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
			// 
			// exportEmail
			// 
			this.exportEmail.Caption = "This Person";
			this.exportEmail.Id = 0;
			this.exportEmail.Name = "exportEmail";
			this.exportEmail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.exportEmail_ItemClick);
			// 
			// exportWord
			// 
			this.exportWord.Caption = "This Person";
			this.exportWord.Id = 1;
			this.exportWord.Name = "exportWord";
			this.exportWord.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.exportWord_ItemClick);
			// 
			// ribbonPage1
			// 
			this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
			this.ribbonPage1.Name = "ribbonPage1";
			this.ribbonPage1.Text = "Statements";
			// 
			// ribbonPageGroup2
			// 
			this.ribbonPageGroup2.ItemLinks.Add(this.exportEmail);
			this.ribbonPageGroup2.Name = "ribbonPageGroup2";
			this.ribbonPageGroup2.ShowCaptionButton = false;
			this.ribbonPageGroup2.Text = "Send Emails to";
			// 
			// ribbonPageGroup3
			// 
			this.ribbonPageGroup3.ItemLinks.Add(this.exportWord);
			this.ribbonPageGroup3.Name = "ribbonPageGroup3";
			this.ribbonPageGroup3.ShowCaptionButton = false;
			this.ribbonPageGroup3.Text = "Create Word Documents for";
			// 
			// personBindingSource
			// 
			this.personBindingSource.AllowNew = false;
			this.personBindingSource.DataMember = "MasterDirectory";
			this.personBindingSource.Position = 0;
			this.personBindingSource.CurrentItemChanged += new System.EventHandler(this.personBindingSource_CurrentItemChanged);
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl1.Location = new System.Drawing.Point(0, 114);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.Controls.Add(this.emailGrid);
			this.splitContainerControl1.Panel1.Controls.Add(this.personEditPanel);
			this.splitContainerControl1.Panel1.Controls.Add(this.showPersonEdit);
			this.splitContainerControl1.Panel1.Controls.Add(this.details);
			this.splitContainerControl1.Panel1.Controls.Add(this.map);
			this.splitContainerControl1.Panel1.MinSize = 200;
			this.splitContainerControl1.Panel1.Text = "Panel1";
			this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControl1);
			this.splitContainerControl1.Panel2.Text = "Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(954, 664);
			this.splitContainerControl1.SplitterPosition = 200;
			this.splitContainerControl1.TabIndex = 2;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// emailGrid
			// 
			this.emailGrid.DataMember = "EmailAddresses";
			this.emailGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.emailGrid.Location = new System.Drawing.Point(0, 527);
			this.emailGrid.MainView = this.emailView;
			this.emailGrid.MenuManager = this.ribbonControl1;
			this.emailGrid.Name = "emailGrid";
			this.emailGrid.RegistrationCount = 50;
			this.emailGrid.Size = new System.Drawing.Size(200, 137);
			this.emailGrid.Source = this.personBindingSource;
			this.emailGrid.TabIndex = 5;
			this.emailGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.emailView});
			// 
			// emailView
			// 
			this.emailView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colEmail,
            this.colActive});
			this.emailView.GridControl = this.emailGrid;
			this.emailView.Name = "emailView";
			this.emailView.NewItemRowText = "Click to add an email address";
			this.emailView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
			this.emailView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
			this.emailView.OptionsView.ShowGroupPanel = false;
			this.emailView.OptionsView.ShowIndicator = false;
			// 
			// colName
			// 
			this.colName.FieldName = "Name";
			this.colName.Name = "colName";
			this.colName.Visible = true;
			this.colName.VisibleIndex = 0;
			// 
			// colEmail
			// 
			this.colEmail.FieldName = "Email";
			this.colEmail.Name = "colEmail";
			this.colEmail.Visible = true;
			this.colEmail.VisibleIndex = 1;
			// 
			// colActive
			// 
			this.colActive.FieldName = "Active";
			this.colActive.MaxWidth = 50;
			this.colActive.Name = "colActive";
			this.colActive.ShowEditorOnMouseDown = true;
			this.colActive.ToolTip = "Shul emails will only be sent to checked email addresses.";
			this.colActive.Visible = true;
			this.colActive.VisibleIndex = 2;
			this.colActive.Width = 50;
			// 
			// personEditPanel
			// 
			this.personEditPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.personEditPanel.Controls.Add(this.closePersonEdit);
			this.personEditPanel.Controls.Add(this.personEditor);
			this.personEditPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.personEditPanel.Location = new System.Drawing.Point(0, 315);
			this.personEditPanel.Name = "personEditPanel";
			this.personEditPanel.Size = new System.Drawing.Size(200, 212);
			this.personEditPanel.TabIndex = 7;
			this.personEditPanel.Visible = false;
			// 
			// closePersonEdit
			// 
			this.closePersonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.closePersonEdit.Location = new System.Drawing.Point(122, 186);
			this.closePersonEdit.Name = "closePersonEdit";
			this.closePersonEdit.Size = new System.Drawing.Size(75, 23);
			this.closePersonEdit.TabIndex = 1;
			this.closePersonEdit.Text = "Done";
			this.closePersonEdit.Click += new System.EventHandler(this.closePersonEdit_Click);
			// 
			// personEditor
			// 
			this.personEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.personEditor.HeaderVisible = false;
			this.personEditor.Location = new System.Drawing.Point(0, 0);
			this.personEditor.Name = "personEditor";
			this.personEditor.Size = new System.Drawing.Size(199, 180);
			this.personEditor.TabIndex = 0;
			// 
			// showPersonEdit
			// 
			this.showPersonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.showPersonEdit.Image = global::ShomreiTorah.Billing.Properties.Resources.Edit16;
			this.showPersonEdit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
			this.showPersonEdit.Location = new System.Drawing.Point(177, 292);
			this.showPersonEdit.Name = "showPersonEdit";
			this.showPersonEdit.Size = new System.Drawing.Size(23, 23);
			toolTipTitleItem3.Text = "Edit";
			toolTipItem3.LeftIndent = 6;
			toolTipItem3.Text = "Edits the person\'s name or address";
			superToolTip3.Items.Add(toolTipTitleItem3);
			superToolTip3.Items.Add(toolTipItem3);
			this.showPersonEdit.SuperTip = superToolTip3;
			this.showPersonEdit.TabIndex = 6;
			this.showPersonEdit.Text = "Edit";
			this.showPersonEdit.Click += new System.EventHandler(this.showPersonEdit_Click);
			// 
			// details
			// 
			this.details.Dock = System.Windows.Forms.DockStyle.Top;
			this.details.Location = new System.Drawing.Point(0, 200);
			this.details.MenuManager = this.ribbonControl1;
			this.details.Name = "details";
			this.details.Properties.ReadOnly = true;
			this.details.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.details.Size = new System.Drawing.Size(200, 115);
			this.details.TabIndex = 4;
			// 
			// map
			// 
			this.map.AddressString = null;
			this.map.Dock = System.Windows.Forms.DockStyle.Top;
			this.map.Location = new System.Drawing.Point(0, 0);
			this.map.Name = "map";
			this.map.Size = new System.Drawing.Size(200, 200);
			this.map.TabIndex = 3;
			// 
			// xtraTabControl1
			// 
			this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
			this.xtraTabControl1.Name = "xtraTabControl1";
			this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
			this.xtraTabControl1.Size = new System.Drawing.Size(748, 664);
			this.xtraTabControl1.TabIndex = 0;
			this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
			// 
			// xtraTabPage1
			// 
			this.xtraTabPage1.Controls.Add(this.splitContainerControl2);
			this.xtraTabPage1.Name = "xtraTabPage1";
			this.xtraTabPage1.Size = new System.Drawing.Size(742, 637);
			this.xtraTabPage1.Text = "Payments && Pledges";
			// 
			// splitContainerControl2
			// 
			this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
			this.splitContainerControl2.Horizontal = false;
			this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl2.Name = "splitContainerControl2";
			this.splitContainerControl2.Panel1.Controls.Add(this.pledgeGrid);
			this.splitContainerControl2.Panel1.Text = "Panel1";
			this.splitContainerControl2.Panel2.Controls.Add(this.paymentsGrid);
			this.splitContainerControl2.Panel2.Text = "Panel2";
			this.splitContainerControl2.Size = new System.Drawing.Size(742, 637);
			this.splitContainerControl2.SplitterPosition = 295;
			this.splitContainerControl2.TabIndex = 0;
			this.splitContainerControl2.Text = "splitContainerControl2";
			// 
			// pledgeGrid
			// 
			this.pledgeGrid.DataMember = "Pledges";
			this.pledgeGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pledgeGrid.Location = new System.Drawing.Point(0, 0);
			this.pledgeGrid.MainView = this.pledgeView;
			this.pledgeGrid.MenuManager = this.ribbonControl1;
			this.pledgeGrid.Name = "pledgeGrid";
			this.pledgeGrid.RegistrationCount = 50;
			this.pledgeGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemAliyahNoteEdit1});
			this.pledgeGrid.ShowOnlyPredefinedDetails = true;
			this.pledgeGrid.Size = new System.Drawing.Size(742, 295);
			this.pledgeGrid.Source = this.personBindingSource;
			this.pledgeGrid.TabIndex = 0;
			this.pledgeGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.pledgeView});
			// 
			// pledgeView
			// 
			this.pledgeView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDate,
            this.colType,
            this.colSubType,
            this.colAccount,
            this.colAmount,
            this.colNote,
            this.colComments,
            this.colModified,
            this.colModifier});
			this.pledgeView.GridControl = this.pledgeGrid;
			this.pledgeView.Name = "pledgeView";
			this.pledgeView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
			this.pledgeView.OptionsSelection.MultiSelect = true;
			this.pledgeView.OptionsView.ShowFooter = true;
			this.pledgeView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
			this.pledgeView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDate, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// colDate
			// 
			this.colDate.FieldName = "Date";
			this.colDate.Name = "colDate";
			this.colDate.SummaryItem.DisplayFormat = "{0} Pledges";
			this.colDate.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
			this.colDate.Visible = true;
			this.colDate.VisibleIndex = 0;
			this.colDate.Width = 59;
			// 
			// colType
			// 
			this.colType.FieldName = "Type";
			this.colType.Name = "colType";
			this.colType.Visible = true;
			this.colType.VisibleIndex = 1;
			this.colType.Width = 43;
			// 
			// colSubType
			// 
			this.colSubType.FieldName = "SubType";
			this.colSubType.Name = "colSubType";
			this.colSubType.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
			this.colSubType.Visible = true;
			this.colSubType.VisibleIndex = 2;
			this.colSubType.Width = 64;
			// 
			// colAccount
			// 
			this.colAccount.ColumnEditor = this.accountEdit;
			this.colAccount.FieldName = "Account";
			this.colAccount.MaxWidth = 100;
			this.colAccount.Name = "colAccount";
			this.colAccount.Visible = true;
			this.colAccount.VisibleIndex = 3;
			this.colAccount.Width = 58;
			// 
			// accountEdit
			// 
			this.accountEdit.AutoHeight = false;
			this.accountEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.accountEdit.DropDownRows = 2;
			this.accountEdit.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Standard;
			this.accountEdit.Items.AddRange(new object[] {
            "Operating Fund",
            "Building Fund"});
			this.accountEdit.Name = "accountEdit";
			// 
			// colAmount
			// 
			this.colAmount.ColumnEditor = this.currencyEdit;
			this.colAmount.DisplayFormat.FormatString = "c";
			this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colAmount.FieldName = "Amount";
			this.colAmount.MaxWidth = 85;
			this.colAmount.Name = "colAmount";
			this.colAmount.SummaryItem.DisplayFormat = "{0:c} Total Pledged";
			this.colAmount.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.colAmount.Visible = true;
			this.colAmount.VisibleIndex = 4;
			this.colAmount.Width = 85;
			// 
			// currencyEdit
			// 
			this.currencyEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.currencyEdit.DisplayFormat.FormatString = "c";
			this.currencyEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.currencyEdit.EditFormat.FormatString = "c";
			this.currencyEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.currencyEdit.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.currencyEdit.Mask.EditMask = "c";
			this.currencyEdit.Name = "currencyEdit";
			// 
			// colNote
			// 
			this.colNote.ColumnEditor = this.repositoryItemAliyahNoteEdit1;
			this.colNote.FieldName = "Note";
			this.colNote.Name = "colNote";
			this.colNote.Visible = true;
			this.colNote.VisibleIndex = 5;
			this.colNote.Width = 42;
			// 
			// repositoryItemAliyahNoteEdit1
			// 
			this.repositoryItemAliyahNoteEdit1.AutoHeight = false;
			this.repositoryItemAliyahNoteEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.repositoryItemAliyahNoteEdit1.Name = "repositoryItemAliyahNoteEdit1";
			// 
			// colComments
			// 
			this.colComments.FieldName = "Comments";
			this.colComments.Name = "colComments";
			this.colComments.Visible = true;
			this.colComments.VisibleIndex = 6;
			this.colComments.Width = 69;
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
			this.colModified.Width = 49;
			// 
			// colModifier
			// 
			this.colModifier.FieldName = "Modifier";
			this.colModifier.Name = "colModifier";
			this.colModifier.OptionsColumn.AllowEdit = false;
			this.colModifier.OptionsColumn.AllowFocus = false;
			this.colModifier.OptionsColumn.ReadOnly = true;
			this.colModifier.Width = 47;
			// 
			// paymentsGrid
			// 
			this.paymentsGrid.DataMember = "Payments";
			this.paymentsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.paymentsGrid.Location = new System.Drawing.Point(0, 0);
			this.paymentsGrid.MainView = this.paymentsView;
			this.paymentsGrid.MenuManager = this.ribbonControl1;
			this.paymentsGrid.Name = "paymentsGrid";
			this.paymentsGrid.RegistrationCount = 50;
			this.paymentsGrid.Size = new System.Drawing.Size(742, 336);
			this.paymentsGrid.Source = this.personBindingSource;
			this.paymentsGrid.TabIndex = 0;
			this.paymentsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.paymentsView});
			// 
			// paymentsView
			// 
			this.paymentsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDate1,
            this.colAccount2,
            this.colMethod,
            this.colCheckNumber,
            this.colAmount1,
            this.colDeposit,
            this.colComments1,
            this.colModified1,
            this.colModifier1});
			this.paymentsView.GridControl = this.paymentsGrid;
			this.paymentsView.Name = "paymentsView";
			this.paymentsView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
			this.paymentsView.OptionsSelection.MultiSelect = true;
			this.paymentsView.OptionsView.ShowFooter = true;
			this.paymentsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
			// 
			// colDate1
			// 
			this.colDate1.FieldName = "Date";
			this.colDate1.Name = "colDate1";
			this.colDate1.SummaryItem.DisplayFormat = "{0} Payments";
			this.colDate1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
			this.colDate1.Visible = true;
			this.colDate1.VisibleIndex = 0;
			this.colDate1.Width = 69;
			// 
			// colAccount2
			// 
			this.colAccount2.ColumnEditor = this.accountEdit;
			this.colAccount2.FieldName = "Account";
			this.colAccount2.MaxWidth = 100;
			this.colAccount2.Name = "colAccount2";
			this.colAccount2.Visible = true;
			this.colAccount2.VisibleIndex = 1;
			this.colAccount2.Width = 58;
			// 
			// colMethod
			// 
			this.colMethod.ColumnEditor = this.paymentMethodEdit;
			this.colMethod.FieldName = "Method";
			this.colMethod.MaxWidth = 70;
			this.colMethod.Name = "colMethod";
			this.colMethod.Visible = true;
			this.colMethod.VisibleIndex = 2;
			this.colMethod.Width = 55;
			// 
			// paymentMethodEdit
			// 
			this.paymentMethodEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.paymentMethodEdit.DropDownRows = 2;
			this.paymentMethodEdit.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
			this.paymentMethodEdit.Items.AddRange(new object[] {
            "Cash",
            "Check"});
			this.paymentMethodEdit.Name = "paymentMethodEdit";
			// 
			// colCheckNumber
			// 
			this.colCheckNumber.ColumnEditor = this.checkNumberEdit;
			this.colCheckNumber.FieldName = "CheckNumber";
			this.colCheckNumber.Name = "colCheckNumber";
			this.colCheckNumber.Visible = true;
			this.colCheckNumber.VisibleIndex = 3;
			this.colCheckNumber.Width = 88;
			// 
			// checkNumberEdit
			// 
			this.checkNumberEdit.Name = "checkNumberEdit";
			// 
			// colAmount1
			// 
			this.colAmount1.ColumnEditor = this.currencyEdit;
			this.colAmount1.DisplayFormat.FormatString = "c";
			this.colAmount1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colAmount1.FieldName = "Amount";
			this.colAmount1.MaxWidth = 85;
			this.colAmount1.Name = "colAmount1";
			this.colAmount1.SummaryItem.DisplayFormat = "{0:c} Total Paid";
			this.colAmount1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.colAmount1.Visible = true;
			this.colAmount1.VisibleIndex = 4;
			this.colAmount1.Width = 85;
			// 
			// colDeposit
			// 
			this.colDeposit.Caption = "Deposited";
			this.colDeposit.ColumnEditor = this.depositEdit;
			this.colDeposit.FieldName = "Deposit";
			this.colDeposit.MaxWidth = 90;
			this.colDeposit.Name = "colDeposit";
			this.colDeposit.OptionsColumn.AllowEdit = false;
			this.colDeposit.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
			this.colDeposit.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.colDeposit.OptionsColumn.ReadOnly = true;
			this.colDeposit.UnboundType = DevExpress.Data.UnboundColumnType.Object;
			this.colDeposit.Visible = true;
			this.colDeposit.VisibleIndex = 5;
			this.colDeposit.Width = 67;
			// 
			// depositEdit
			// 
			this.depositEdit.AutoHeight = false;
			this.depositEdit.Name = "depositEdit";
			this.depositEdit.NullText = "Undeposited";
			this.depositEdit.ReadOnly = true;
			// 
			// colComments1
			// 
			this.colComments1.FieldName = "Comments";
			this.colComments1.Name = "colComments1";
			this.colComments1.Visible = true;
			this.colComments1.VisibleIndex = 6;
			this.colComments1.Width = 69;
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
			this.colModified1.Width = 49;
			// 
			// colModifier1
			// 
			this.colModifier1.DisplayFormat.FormatString = "g";
			this.colModifier1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colModifier1.FieldName = "Modifier";
			this.colModifier1.Name = "colModifier1";
			this.colModifier1.OptionsColumn.AllowEdit = false;
			this.colModifier1.OptionsColumn.AllowFocus = false;
			this.colModifier1.OptionsColumn.ReadOnly = true;
			this.colModifier1.Width = 47;
			// 
			// xtraTabPage2
			// 
			this.xtraTabPage2.Controls.Add(this.statementsGrid);
			this.xtraTabPage2.Name = "xtraTabPage2";
			this.xtraTabPage2.Size = new System.Drawing.Size(742, 637);
			this.xtraTabPage2.Text = "Statements Received";
			// 
			// statementsGrid
			// 
			this.statementsGrid.DataMember = "LoggedStatements";
			this.statementsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.statementsGrid.Location = new System.Drawing.Point(0, 0);
			this.statementsGrid.MainView = this.statementsView;
			this.statementsGrid.MenuManager = this.ribbonControl1;
			this.statementsGrid.Name = "statementsGrid";
			this.statementsGrid.RegistrationCount = 50;
			this.statementsGrid.Size = new System.Drawing.Size(742, 637);
			this.statementsGrid.Source = this.personBindingSource;
			this.statementsGrid.TabIndex = 0;
			this.statementsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.statementsView});
			// 
			// statementsView
			// 
			this.statementsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDateGenerated,
            this.colMedia,
            this.colStatementKind,
            this.colStartDate,
            this.colEndDate,
            this.colUserName});
			this.statementsView.GridControl = this.statementsGrid;
			this.statementsView.Name = "statementsView";
			this.statementsView.OptionsBehavior.Editable = false;
			this.statementsView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDateGenerated, DevExpress.Data.ColumnSortOrder.Descending)});
			// 
			// colDateGenerated
			// 
			this.colDateGenerated.DisplayFormat.FormatString = "MMMM d, yyyy, h:mm:ss tt";
			this.colDateGenerated.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colDateGenerated.FieldName = "DateGenerated";
			this.colDateGenerated.Name = "colDateGenerated";
			this.colDateGenerated.OptionsColumn.AllowEdit = false;
			this.colDateGenerated.OptionsColumn.AllowFocus = false;
			this.colDateGenerated.OptionsColumn.ReadOnly = true;
			this.colDateGenerated.Visible = true;
			this.colDateGenerated.VisibleIndex = 0;
			this.colDateGenerated.Width = 109;
			// 
			// colMedia
			// 
			this.colMedia.FieldName = "Media";
			this.colMedia.Name = "colMedia";
			this.colMedia.OptionsColumn.AllowEdit = false;
			this.colMedia.OptionsColumn.AllowFocus = false;
			this.colMedia.OptionsColumn.ReadOnly = true;
			this.colMedia.Visible = true;
			this.colMedia.VisibleIndex = 1;
			this.colMedia.Width = 47;
			// 
			// colStatementKind
			// 
			this.colStatementKind.FieldName = "StatementKind";
			this.colStatementKind.Name = "colStatementKind";
			this.colStatementKind.OptionsColumn.AllowEdit = false;
			this.colStatementKind.OptionsColumn.AllowFocus = false;
			this.colStatementKind.OptionsColumn.ReadOnly = true;
			this.colStatementKind.Visible = true;
			this.colStatementKind.VisibleIndex = 2;
			this.colStatementKind.Width = 92;
			// 
			// colStartDate
			// 
			this.colStartDate.FieldName = "StartDate";
			this.colStartDate.Name = "colStartDate";
			this.colStartDate.OptionsColumn.AllowEdit = false;
			this.colStartDate.OptionsColumn.AllowFocus = false;
			this.colStartDate.OptionsColumn.ReadOnly = true;
			this.colStartDate.Visible = true;
			this.colStartDate.VisibleIndex = 3;
			this.colStartDate.Width = 69;
			// 
			// colEndDate
			// 
			this.colEndDate.FieldName = "EndDate";
			this.colEndDate.Name = "colEndDate";
			this.colEndDate.OptionsColumn.AllowEdit = false;
			this.colEndDate.OptionsColumn.AllowFocus = false;
			this.colEndDate.OptionsColumn.ReadOnly = true;
			this.colEndDate.Visible = true;
			this.colEndDate.VisibleIndex = 4;
			this.colEndDate.Width = 63;
			// 
			// colUserName
			// 
			this.colUserName.FieldName = "UserName";
			this.colUserName.Name = "colUserName";
			this.colUserName.OptionsColumn.AllowEdit = false;
			this.colUserName.OptionsColumn.AllowFocus = false;
			this.colUserName.OptionsColumn.ReadOnly = true;
			this.colUserName.Visible = true;
			this.colUserName.VisibleIndex = 5;
			this.colUserName.Width = 71;
			// 
			// ribbonPage2
			// 
			this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
			this.ribbonPage2.Name = "ribbonPage2";
			this.ribbonPage2.Text = "Data";
			// 
			// ribbonPageGroup1
			// 
			this.ribbonPageGroup1.ItemLinks.Add(this.addRLAsMember);
			this.ribbonPageGroup1.ItemLinks.Add(this.addRLAsRelative);
			this.ribbonPageGroup1.Name = "ribbonPageGroup1";
			this.ribbonPageGroup1.ShowCaptionButton = false;
			this.ribbonPageGroup1.Text = "People";
			// 
			// addRLAsMember
			// 
			this.addRLAsMember.Caption = "Link to Relative";
			this.addRLAsMember.Id = 2;
			this.addRLAsMember.Name = "addRLAsMember";
			toolTipTitleItem1.Text = "Link to Relative";
			toolTipItem1.LeftIndent = 6;
			toolTipItem1.Text = "Links to member to a relative";
			superToolTip1.Items.Add(toolTipTitleItem1);
			superToolTip1.Items.Add(toolTipItem1);
			this.addRLAsMember.SuperTip = superToolTip1;
			this.addRLAsMember.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addRLAsMember_ItemClick);
			// 
			// addRLAsRelative
			// 
			this.addRLAsRelative.Caption = "Link to Member";
			this.addRLAsRelative.Id = 3;
			this.addRLAsRelative.Name = "addRLAsRelative";
			toolTipTitleItem2.Text = "Link to Member";
			toolTipItem2.LeftIndent = 6;
			toolTipItem2.Text = "Links this relative to an existing member";
			superToolTip2.Items.Add(toolTipTitleItem2);
			superToolTip2.Items.Add(toolTipItem2);
			this.addRLAsRelative.SuperTip = superToolTip2;
			this.addRLAsRelative.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addRLAsRelative_ItemClick);
			// 
			// PersonDetails
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(954, 778);
			this.Controls.Add(this.splitContainerControl1);
			this.Controls.Add(this.ribbonControl1);
			this.Name = "PersonDetails";
			this.Text = "PersonDetails";
			((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.emailGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emailView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.personEditPanel)).EndInit();
			this.personEditPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.details.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
			this.xtraTabControl1.ResumeLayout(false);
			this.xtraTabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
			this.splitContainerControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pledgeGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgeView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.accountEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.currencyEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemAliyahNoteEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentsGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentsView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentMethodEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkNumberEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.depositEdit)).EndInit();
			this.xtraTabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.statementsGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statementsView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
		private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
		private DevExpress.XtraBars.BarButtonItem exportEmail;
		private DevExpress.XtraBars.BarButtonItem exportWord;
		private ShomreiTorah.Data.UI.FrameworkBindingSource personBindingSource;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
		private Data.UI.Grid.SmartGrid emailGrid;
		private Data.UI.Grid.SmartGridView emailView;
		private Data.UI.Grid.SmartGridColumn colName;
		private Data.UI.Grid.SmartGridColumn colEmail;
		private DevExpress.XtraEditors.MemoEdit details;
		private ShomreiTorah.WinForms.Controls.GoogleMapControl map;
		private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
		private Data.UI.Grid.SmartGrid pledgeGrid;
		private Data.UI.Grid.SmartGridView pledgeView;
		private Data.UI.Grid.SmartGridColumn colDate;
		private Data.UI.Grid.SmartGridColumn colType;
		private Data.UI.Grid.SmartGridColumn colSubType;
		private Data.UI.Grid.SmartGridColumn colAccount;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox accountEdit;
		private Data.UI.Grid.SmartGridColumn colAmount;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit currencyEdit;
		private Data.UI.Grid.SmartGridColumn colNote;
		private Data.UI.Grid.SmartGridColumn colComments;
		private Data.UI.Grid.SmartGrid paymentsGrid;
		private Data.UI.Grid.SmartGridView paymentsView;
		private Data.UI.Grid.SmartGridColumn colDate1;
		private Data.UI.Grid.SmartGridColumn colMethod;
		private Data.UI.Grid.SmartGridColumn colCheckNumber;
		private Data.UI.Grid.SmartGridColumn colAmount1;
		private Data.UI.Grid.SmartGridColumn colComments1;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox paymentMethodEdit;
		private Data.UI.Grid.SmartGridColumn colAccount2;
		private Data.UI.Grid.SmartGridColumn colModified;
		private Data.UI.Grid.SmartGridColumn colModifier;
		private Data.UI.Grid.SmartGridColumn colModified1;
		private Data.UI.Grid.SmartGridColumn colModifier1;
		private Data.UI.Grid.SmartGridColumn colDeposit;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit depositEdit;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
		private Data.UI.Grid.SmartGrid statementsGrid;
		private Data.UI.Grid.SmartGridView statementsView;
		private Data.UI.Grid.SmartGridColumn colDateGenerated;
		private Data.UI.Grid.SmartGridColumn colMedia;
		private Data.UI.Grid.SmartGridColumn colStatementKind;
		private Data.UI.Grid.SmartGridColumn colStartDate;
		private Data.UI.Grid.SmartGridColumn colEndDate;
		private Data.UI.Grid.SmartGridColumn colUserName;
		private Data.UI.Controls.RepositoryItemCheckNumberEdit checkNumberEdit;
		private ShomreiTorah.Billing.Controls.Editors.RepositoryItemAliyahNoteEdit repositoryItemAliyahNoteEdit1;
		private DevExpress.XtraEditors.SimpleButton showPersonEdit;
		private DevExpress.XtraEditors.PanelControl personEditPanel;
		private DevExpress.XtraEditors.SimpleButton closePersonEdit;
		private Data.UI.Controls.PersonEditor personEditor;
		private Data.UI.Grid.SmartGridColumn colActive;
		private DevExpress.XtraBars.BarButtonItem addRLAsMember;
		private DevExpress.XtraBars.BarButtonItem addRLAsRelative;
		private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
	}
}