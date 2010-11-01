using ShomreiTorah.Data.UI.Controls;
namespace ShomreiTorah.Billing.Events.Seating {
	partial class SeatingForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeatingForm));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
			DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
			this.grid = new ShomreiTorah.Data.UI.Grid.SmartGrid(this.components);
			this.gridView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colDate = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colFullName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colPledgeType = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAmount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.currencyEditor = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.colMensSeats = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.seatCountEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.colWomensSeats = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colBoysSeats = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colGirlsSeats = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colNotes = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colChartStatus = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.gridLoadingEdit = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
			this.personSelector = new ShomreiTorah.Data.UI.Controls.PersonSelector();
			this.addNewPanel = new DevExpress.XtraEditors.PanelControl();
			this.cancelAddEntry = new DevExpress.XtraEditors.SimpleButton();
			this.addNewEdit = new ShomreiTorah.Billing.Events.Seating.SeatingReservationEdit();
			this.addEntry = new DevExpress.XtraEditors.SimpleButton();
			this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.wordButton = new DevExpress.XtraBars.BarButtonItem();
			this.wordDocsMenu = new DevExpress.XtraBars.PopupMenu(this.components);
			this.wordDocList = new DevExpress.XtraBars.BarListItem();
			this.openWordDoc = new DevExpress.XtraBars.BarButtonItem();
			this.showChartInfo = new DevExpress.XtraBars.BarButtonItem();
			this.excelMenu = new DevExpress.XtraBars.BarSubItem();
			this.exportLadiesInfo = new DevExpress.XtraBars.BarButtonItem();
			this.exportAllInfo = new DevExpress.XtraBars.BarButtonItem();
			this.statusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
			this.loadingIconItem = new DevExpress.XtraBars.BarEditItem();
			this.loadingIconEdit = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
			this.mensTotal = new DevExpress.XtraBars.BarStaticItem();
			this.womensTotal = new DevExpress.XtraBars.BarStaticItem();
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.currencyEditor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.seatCountEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridLoadingEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.personSelector.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.addNewPanel)).BeginInit();
			this.addNewPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.wordDocsMenu)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.loadingIconEdit)).BeginInit();
			this.SuspendLayout();
			// 
			// ribbon
			// 
			// 
			// 
			// 
			this.ribbon.ExpandCollapseItem.Id = 0;
			this.ribbon.ExpandCollapseItem.Name = "";
			this.ribbon.ExpandCollapseItem.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
			this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.wordButton,
            this.openWordDoc,
            this.wordDocList,
            this.loadingIconItem,
            this.exportLadiesInfo,
            this.showChartInfo,
            this.mensTotal,
            this.womensTotal,
            this.excelMenu,
            this.exportAllInfo});
			this.ribbon.MaxItemId = 20;
			this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
			this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.loadingIconEdit});
			this.ribbon.SelectedPage = this.ribbonPage1;
			this.ribbon.Size = new System.Drawing.Size(1011, 114);
			this.ribbon.StatusBar = this.statusBar;
			// 
			// grid
			// 
			this.grid.DataMember = "SeatingReservations";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 206);
			this.grid.MainView = this.gridView;
			this.grid.MenuManager = this.ribbon;
			this.grid.Name = "grid";
			this.grid.RegistrationCount = 37;
			this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.seatCountEdit,
            this.currencyEditor,
            this.gridLoadingEdit});
			this.grid.Size = new System.Drawing.Size(1011, 495);
			this.grid.TabIndex = 2;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDate,
            this.colFullName,
            this.colPledgeType,
            this.colAmount,
            this.colMensSeats,
            this.colWomensSeats,
            this.colBoysSeats,
            this.colGirlsSeats,
            this.colNotes,
            this.colChartStatus});
			this.gridView.GridControl = this.grid;
			this.gridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "FullName", null, "({0} Reservations)")});
			this.gridView.Name = "gridView";
			this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
			this.gridView.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
			this.gridView.OptionsView.ShowFooter = true;
			this.gridView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
			this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFullName, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.gridView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView_CustomUnboundColumnData);
			this.gridView.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView_CustomColumnDisplayText);
			this.gridView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyUp);
			// 
			// colDate
			// 
			this.colDate.Caption = "Date";
			this.colDate.FieldName = "Pledge/Date";
			this.colDate.Name = "colDate";
			this.colDate.OptionsColumn.AllowEdit = false;
			this.colDate.OptionsColumn.ReadOnly = true;
			this.colDate.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
			this.colDate.Visible = true;
			this.colDate.VisibleIndex = 2;
			this.colDate.Width = 63;
			// 
			// colFullName
			// 
			this.colFullName.FieldName = "Person";
			this.colFullName.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical;
			this.colFullName.Name = "colFullName";
			this.colFullName.OptionsColumn.ReadOnly = true;
			this.colFullName.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colFullName.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
			this.colFullName.SummaryItem.DisplayFormat = "{0} Reservations";
			this.colFullName.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
			this.colFullName.Visible = true;
			this.colFullName.VisibleIndex = 0;
			this.colFullName.Width = 85;
			// 
			// colPledgeType
			// 
			this.colPledgeType.Caption = "Pledge Type";
			this.colPledgeType.FieldName = "Pledge/Type";
			this.colPledgeType.Name = "colPledgeType";
			this.colPledgeType.UnboundType = DevExpress.Data.UnboundColumnType.String;
			this.colPledgeType.Visible = true;
			this.colPledgeType.VisibleIndex = 3;
			this.colPledgeType.Width = 78;
			// 
			// colAmount
			// 
			this.colAmount.Caption = "Amount";
			this.colAmount.ColumnEditor = this.currencyEditor;
			this.colAmount.FieldName = "Pledge/Amount";
			this.colAmount.Name = "colAmount";
			this.colAmount.SummaryItem.DisplayFormat = "Total: {0:c}";
			this.colAmount.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.colAmount.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
			this.colAmount.Visible = true;
			this.colAmount.VisibleIndex = 4;
			this.colAmount.Width = 72;
			// 
			// currencyEditor
			// 
			this.currencyEditor.AutoHeight = false;
			this.currencyEditor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.currencyEditor.DisplayFormat.FormatString = "c";
			this.currencyEditor.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.currencyEditor.EditFormat.FormatString = "c";
			this.currencyEditor.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.currencyEditor.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.currencyEditor.Mask.EditMask = "c";
			this.currencyEditor.Name = "currencyEditor";
			// 
			// colMensSeats
			// 
			this.colMensSeats.ColumnEditor = this.seatCountEdit;
			this.colMensSeats.FieldName = "MensSeats";
			this.colMensSeats.Name = "colMensSeats";
			this.colMensSeats.SummaryItem.DisplayFormat = "{0} Men";
			this.colMensSeats.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.colMensSeats.Visible = true;
			this.colMensSeats.VisibleIndex = 5;
			this.colMensSeats.Width = 74;
			// 
			// seatCountEdit
			// 
			this.seatCountEdit.AutoHeight = false;
			this.seatCountEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.seatCountEdit.IsFloatValue = false;
			this.seatCountEdit.Mask.EditMask = "N00";
			this.seatCountEdit.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.seatCountEdit.Name = "seatCountEdit";
			// 
			// colWomensSeats
			// 
			this.colWomensSeats.ColumnEditor = this.seatCountEdit;
			this.colWomensSeats.FieldName = "WomensSeats";
			this.colWomensSeats.Name = "colWomensSeats";
			this.colWomensSeats.SummaryItem.DisplayFormat = "{0} Women";
			this.colWomensSeats.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.colWomensSeats.Visible = true;
			this.colWomensSeats.VisibleIndex = 6;
			this.colWomensSeats.Width = 90;
			// 
			// colBoysSeats
			// 
			this.colBoysSeats.ColumnEditor = this.seatCountEdit;
			this.colBoysSeats.FieldName = "BoysSeats";
			this.colBoysSeats.Name = "colBoysSeats";
			this.colBoysSeats.SummaryItem.DisplayFormat = "{0} Boys";
			this.colBoysSeats.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.colBoysSeats.Visible = true;
			this.colBoysSeats.VisibleIndex = 7;
			this.colBoysSeats.Width = 72;
			// 
			// colGirlsSeats
			// 
			this.colGirlsSeats.ColumnEditor = this.seatCountEdit;
			this.colGirlsSeats.FieldName = "GirlsSeats";
			this.colGirlsSeats.Name = "colGirlsSeats";
			this.colGirlsSeats.SummaryItem.DisplayFormat = "{0} Girls";
			this.colGirlsSeats.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.colGirlsSeats.Visible = true;
			this.colGirlsSeats.VisibleIndex = 8;
			this.colGirlsSeats.Width = 69;
			// 
			// colNotes
			// 
			this.colNotes.FieldName = "Notes";
			this.colNotes.MaxWidth = 150;
			this.colNotes.Name = "colNotes";
			this.colNotes.Visible = true;
			this.colNotes.VisibleIndex = 9;
			this.colNotes.Width = 47;
			// 
			// colChartStatus
			// 
			this.colChartStatus.Caption = "Chart Status";
			this.colChartStatus.ColumnEditor = this.gridLoadingEdit;
			this.colChartStatus.FieldName = "ChartStatus";
			this.colChartStatus.Name = "colChartStatus";
			this.colChartStatus.OptionsColumn.AllowEdit = false;
			this.colChartStatus.OptionsColumn.AllowFocus = false;
			this.colChartStatus.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
			this.colChartStatus.Visible = true;
			this.colChartStatus.VisibleIndex = 1;
			this.colChartStatus.Width = 80;
			// 
			// gridLoadingEdit
			// 
			this.gridLoadingEdit.Name = "gridLoadingEdit";
			this.gridLoadingEdit.ReadOnly = true;
			this.gridLoadingEdit.ShowMenu = false;
			this.gridLoadingEdit.UseParentBackground = true;
			// 
			// personSelector
			// 
			this.personSelector.Dock = System.Windows.Forms.DockStyle.Top;
			this.personSelector.Location = new System.Drawing.Point(0, 114);
			this.personSelector.Name = "personSelector";
			toolTipItem2.Text = "Click to select a person";
			superToolTip2.Items.Add(toolTipItem2);
			toolTipTitleItem2.Text = "New Person...";
			toolTipItem3.Text = "Adds a new person to the master directory";
			superToolTip3.Items.Add(toolTipTitleItem2);
			superToolTip3.Items.Add(toolTipItem3);
			this.personSelector.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, superToolTip2, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "New person...", 90, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleLeft, ((System.Drawing.Image)(resources.GetObject("personSelector.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, superToolTip3, true)});
			this.personSelector.Size = new System.Drawing.Size(1011, 20);
			this.personSelector.TabIndex = 0;
			this.personSelector.TabStop = false;
			this.personSelector.PersonSelecting += new System.EventHandler<ShomreiTorah.Data.UI.Controls.PersonSelectingEventArgs>(this.personSelector_PersonSelecting);
			this.personSelector.EditValueChanged += new System.EventHandler(this.personSelector_EditValueChanged);
			// 
			// addNewPanel
			// 
			this.addNewPanel.Controls.Add(this.cancelAddEntry);
			this.addNewPanel.Controls.Add(this.addNewEdit);
			this.addNewPanel.Controls.Add(this.addEntry);
			this.addNewPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.addNewPanel.Location = new System.Drawing.Point(0, 134);
			this.addNewPanel.Name = "addNewPanel";
			this.addNewPanel.Size = new System.Drawing.Size(1011, 72);
			this.addNewPanel.TabIndex = 1;
			this.addNewPanel.Visible = false;
			// 
			// cancelAddEntry
			// 
			this.cancelAddEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelAddEntry.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.cancelAddEntry.Appearance.Options.UseBackColor = true;
			this.cancelAddEntry.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.cancelAddEntry.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelAddEntry.Image = global::ShomreiTorah.Billing.Properties.Resources.Close;
			this.cancelAddEntry.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
			this.cancelAddEntry.Location = new System.Drawing.Point(913, 0);
			this.cancelAddEntry.Name = "cancelAddEntry";
			this.cancelAddEntry.Size = new System.Drawing.Size(13, 13);
			this.cancelAddEntry.TabIndex = 2;
			this.cancelAddEntry.Text = "Close";
			this.cancelAddEntry.ToolTip = "Close";
			this.cancelAddEntry.Click += new System.EventHandler(this.cancelAddEntry_Click);
			// 
			// addNewEdit
			// 
			this.addNewEdit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.addNewEdit.Location = new System.Drawing.Point(2, 2);
			this.addNewEdit.Name = "addNewEdit";
			this.addNewEdit.Size = new System.Drawing.Size(924, 68);
			this.addNewEdit.TabIndex = 0;
			this.addNewEdit.EnterPressed += new System.EventHandler(this.addNewEdit_EnterPressed);
			// 
			// addEntry
			// 
			this.addEntry.Appearance.Options.UseTextOptions = true;
			this.addEntry.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.addEntry.Dock = System.Windows.Forms.DockStyle.Right;
			this.addEntry.Image = global::ShomreiTorah.Billing.Properties.Resources.Add32;
			this.addEntry.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
			this.addEntry.Location = new System.Drawing.Point(926, 2);
			this.addEntry.Name = "addEntry";
			this.addEntry.Size = new System.Drawing.Size(83, 68);
			this.addEntry.TabIndex = 1;
			this.addEntry.Text = "Add Reservation";
			this.addEntry.Click += new System.EventHandler(this.addEntry_Click);
			// 
			// ribbonPage1
			// 
			this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
			this.ribbonPage1.Name = "ribbonPage1";
			this.ribbonPage1.Text = "Events";
			// 
			// ribbonPageGroup1
			// 
			this.ribbonPageGroup1.ItemLinks.Add(this.wordButton);
			this.ribbonPageGroup1.ItemLinks.Add(this.showChartInfo);
			this.ribbonPageGroup1.ItemLinks.Add(this.excelMenu, true);
			this.ribbonPageGroup1.Name = "ribbonPageGroup1";
			this.ribbonPageGroup1.ShowCaptionButton = false;
			this.ribbonPageGroup1.Text = "ימים נוראים";
			// 
			// wordButton
			// 
			this.wordButton.ActAsDropDown = true;
			this.wordButton.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
			this.wordButton.Caption = "Seating Chart";
			this.wordButton.DropDownControl = this.wordDocsMenu;
			this.wordButton.Id = 4;
			this.wordButton.LargeGlyph = global::ShomreiTorah.Billing.Properties.Resources.WordDocuments32;
			this.wordButton.Name = "wordButton";
			// 
			// wordDocsMenu
			// 
			this.wordDocsMenu.ItemLinks.Add(this.wordDocList, true);
			this.wordDocsMenu.ItemLinks.Add(this.openWordDoc, true);
			this.wordDocsMenu.MenuCaption = "Open Documents";
			this.wordDocsMenu.Name = "wordDocsMenu";
			this.wordDocsMenu.Ribbon = this.ribbon;
			this.wordDocsMenu.ShowCaption = true;
			this.wordDocsMenu.BeforePopup += new System.ComponentModel.CancelEventHandler(this.wordDocsMenu_BeforePopup);
			// 
			// wordDocList
			// 
			this.wordDocList.Caption = "Documents";
			this.wordDocList.Id = 7;
			this.wordDocList.Name = "wordDocList";
			this.wordDocList.ListItemClick += new DevExpress.XtraBars.ListItemClickEventHandler(this.wordDocList_ListItemClick);
			// 
			// openWordDoc
			// 
			this.openWordDoc.Caption = "&Open...";
			this.openWordDoc.Glyph = global::ShomreiTorah.Billing.Properties.Resources.Open16;
			this.openWordDoc.Id = 6;
			this.openWordDoc.Name = "openWordDoc";
			this.openWordDoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.openWordDoc_ItemClick);
			// 
			// showChartInfo
			// 
			this.showChartInfo.Caption = "Analyze Chart";
			this.showChartInfo.Enabled = false;
			this.showChartInfo.Id = 14;
			this.showChartInfo.LargeGlyph = global::ShomreiTorah.Billing.Properties.Resources.WordWarning32;
			this.showChartInfo.Name = "showChartInfo";
			toolTipTitleItem1.Text = "Analyze Seating Chart";
			toolTipItem1.LeftIndent = 6;
			toolTipItem1.Text = "Analyzes the selected seating chart and displays any problems found.";
			superToolTip1.Items.Add(toolTipTitleItem1);
			superToolTip1.Items.Add(toolTipItem1);
			this.showChartInfo.SuperTip = superToolTip1;
			this.showChartInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.showChartInfo_ItemClick);
			// 
			// excelMenu
			// 
			this.excelMenu.Caption = "Export";
			this.excelMenu.Id = 18;
			this.excelMenu.LargeGlyph = global::ShomreiTorah.Billing.Properties.Resources.ExportExcel32;
			this.excelMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.exportLadiesInfo),
            new DevExpress.XtraBars.LinkPersistInfo(this.exportAllInfo)});
			this.excelMenu.Name = "excelMenu";
			// 
			// exportLadiesInfo
			// 
			this.exportLadiesInfo.Caption = "Ladies\' Info";
			this.exportLadiesInfo.Id = 13;
			this.exportLadiesInfo.Name = "exportLadiesInfo";
			this.exportLadiesInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.exportLadiesInfo_ItemClick);
			// 
			// exportAllInfo
			// 
			this.exportAllInfo.Caption = "Seating Info";
			this.exportAllInfo.Id = 19;
			this.exportAllInfo.Name = "exportAllInfo";
			this.exportAllInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.exportAllInfo_ItemClick);
			// 
			// statusBar
			// 
			this.statusBar.ItemLinks.Add(this.loadingIconItem);
			this.statusBar.ItemLinks.Add(this.mensTotal);
			this.statusBar.ItemLinks.Add(this.womensTotal, true);
			this.statusBar.Location = new System.Drawing.Point(0, 701);
			this.statusBar.Name = "statusBar";
			this.statusBar.Ribbon = this.ribbon;
			this.statusBar.Size = new System.Drawing.Size(1011, 25);
			// 
			// loadingIconItem
			// 
			this.loadingIconItem.CanOpenEdit = false;
			this.loadingIconItem.Caption = "Please wait";
			this.loadingIconItem.CaptionAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.loadingIconItem.Edit = this.loadingIconEdit;
			this.loadingIconItem.Id = 10;
			this.loadingIconItem.Name = "loadingIconItem";
			this.loadingIconItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
			this.loadingIconItem.Width = 16;
			// 
			// loadingIconEdit
			// 
			this.loadingIconEdit.AllowFocused = false;
			this.loadingIconEdit.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.loadingIconEdit.Appearance.Options.UseBackColor = true;
			this.loadingIconEdit.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.loadingIconEdit.InitialImage = global::ShomreiTorah.Billing.Properties.Resources.Loading16;
			this.loadingIconEdit.Name = "loadingIconEdit";
			this.loadingIconEdit.ReadOnly = true;
			this.loadingIconEdit.ShowMenu = false;
			// 
			// mensTotal
			// 
			this.mensTotal.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
			this.mensTotal.Caption = "Men\'s Section: 90 Seats";
			this.mensTotal.Id = 15;
			this.mensTotal.Name = "mensTotal";
			this.mensTotal.TextAlignment = System.Drawing.StringAlignment.Near;
			// 
			// womensTotal
			// 
			this.womensTotal.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
			this.womensTotal.Caption = "Women\'s Section: 60 Seats";
			this.womensTotal.Id = 16;
			this.womensTotal.Name = "womensTotal";
			this.womensTotal.TextAlignment = System.Drawing.StringAlignment.Near;
			// 
			// SeatingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1011, 726);
			this.Controls.Add(this.grid);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.addNewPanel);
			this.Controls.Add(this.personSelector);
			this.MainView = this.gridView;
			this.Name = "SeatingForm";
			this.Text = "Seating Reservations";
			this.Controls.SetChildIndex(this.ribbon, 0);
			this.Controls.SetChildIndex(this.personSelector, 0);
			this.Controls.SetChildIndex(this.addNewPanel, 0);
			this.Controls.SetChildIndex(this.statusBar, 0);
			this.Controls.SetChildIndex(this.grid, 0);
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.currencyEditor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.seatCountEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridLoadingEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.personSelector.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.addNewPanel)).EndInit();
			this.addNewPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.wordDocsMenu)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.loadingIconEdit)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private Data.UI.Grid.SmartGrid grid;
		private Data.UI.Grid.SmartGridView gridView;
		private PersonSelector personSelector;
		private DevExpress.XtraEditors.PanelControl addNewPanel;
		private DevExpress.XtraEditors.SimpleButton addEntry;
		private SeatingReservationEdit addNewEdit;
		private Data.UI.Grid.SmartGridColumn colFullName;
		private Data.UI.Grid.SmartGridColumn colMensSeats;
		private Data.UI.Grid.SmartGridColumn colWomensSeats;
		private Data.UI.Grid.SmartGridColumn colBoysSeats;
		private Data.UI.Grid.SmartGridColumn colGirlsSeats;
		private Data.UI.Grid.SmartGridColumn colNotes;
		private Data.UI.Grid.SmartGridColumn colChartStatus;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit seatCountEdit;
		private DevExpress.XtraEditors.SimpleButton cancelAddEntry;
		private Data.UI.Grid.SmartGridColumn colDate;
		private Data.UI.Grid.SmartGridColumn colPledgeType;
		private Data.UI.Grid.SmartGridColumn colAmount;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit currencyEditor;
		private DevExpress.XtraBars.BarButtonItem wordButton;
		private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
		private DevExpress.XtraBars.BarButtonItem openWordDoc;
		private DevExpress.XtraBars.BarListItem wordDocList;
		private DevExpress.XtraBars.PopupMenu wordDocsMenu;
		private DevExpress.XtraBars.BarEditItem loadingIconItem;
		private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit loadingIconEdit;
		private DevExpress.XtraBars.Ribbon.RibbonStatusBar statusBar;
		private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit gridLoadingEdit;
		private DevExpress.XtraBars.BarButtonItem exportLadiesInfo;
		private DevExpress.XtraBars.BarButtonItem showChartInfo;
		private DevExpress.XtraBars.BarStaticItem mensTotal;
		private DevExpress.XtraBars.BarStaticItem womensTotal;
		private DevExpress.XtraBars.BarSubItem excelMenu;
		private DevExpress.XtraBars.BarButtonItem exportAllInfo;
	}
}