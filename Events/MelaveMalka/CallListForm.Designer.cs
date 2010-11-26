namespace ShomreiTorah.Billing.Events.MelaveMalka {
	partial class CallListForm {
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
			DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
			DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
			DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
			this.grid = new ShomreiTorah.Data.UI.Grid.SmartGrid(this.components);
			this.gridView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colShouldCall = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colPerson = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colSource = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colCaller = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.callerEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.colCallerNote = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAdAmount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.listSearch = new ShomreiTorah.WinForms.Controls.Lookup.ItemSelector();
			this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
			this.showCallers = new DevExpress.XtraBars.BarButtonItem();
			this.autoAssign = new DevExpress.XtraBars.BarButtonItem();
			this.exportGlobalList = new DevExpress.XtraBars.BarButtonItem();
			this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.colRowId = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colRowId1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.clearCallers = new DevExpress.XtraBars.BarButtonItem();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.callerEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.listSearch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
			this.SuspendLayout();
			// 
			// grid
			// 
			this.grid.DataMember = "Invitees";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 114);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.RegistrationCount = 48;
			this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.callerEdit});
			this.grid.ShowOnlyPredefinedDetails = true;
			this.grid.Size = new System.Drawing.Size(712, 286);
			this.grid.TabIndex = 0;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colShouldCall,
            this.colPerson,
            this.colSource,
            this.colCaller,
            this.colCallerNote,
            this.colAdAmount});
			this.gridView.GridControl = this.grid;
			this.gridView.Name = "gridView";
			this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
			this.gridView.OptionsSelection.MultiSelect = true;
			this.gridView.OptionsView.ShowFooter = true;
			this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPerson, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.gridView.InvalidValueException += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.gridView_InvalidValueException);
			// 
			// colShouldCall
			// 
			this.colShouldCall.Caption = " ";
			this.colShouldCall.FieldName = "ShouldCall";
			this.colShouldCall.MaxWidth = 20;
			this.colShouldCall.Name = "colShouldCall";
			this.colShouldCall.OptionsColumn.AllowSize = false;
			this.colShouldCall.OptionsColumn.FixedWidth = true;
			this.colShouldCall.ToolTip = "Should Call?";
			this.colShouldCall.Visible = true;
			this.colShouldCall.VisibleIndex = 0;
			this.colShouldCall.Width = 20;
			// 
			// colPerson
			// 
			this.colPerson.AllowKeyboardActivation = false;
			this.colPerson.Caption = "Full Name";
			this.colPerson.FieldName = "Person";
			this.colPerson.Name = "colPerson";
			this.colPerson.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
			this.colPerson.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.colPerson.OptionsColumn.ReadOnly = true;
			this.colPerson.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colPerson.ShowEditorOnMouseDown = true;
			this.colPerson.SummaryItem.DisplayFormat = "{0} People";
			this.colPerson.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
			this.colPerson.Visible = true;
			this.colPerson.VisibleIndex = 1;
			this.colPerson.Width = 78;
			// 
			// colSource
			// 
			this.colSource.FieldName = "Source";
			this.colSource.Name = "colSource";
			this.colSource.OptionsColumn.AllowEdit = false;
			this.colSource.OptionsColumn.ReadOnly = true;
			this.colSource.Visible = true;
			this.colSource.VisibleIndex = 2;
			this.colSource.Width = 52;
			// 
			// colCaller
			// 
			this.colCaller.ColumnEditor = this.callerEdit;
			this.colCaller.FieldName = "Caller";
			this.colCaller.Name = "colCaller";
			this.colCaller.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colCaller.ShowEditorOnMouseDown = true;
			this.colCaller.Visible = true;
			this.colCaller.VisibleIndex = 3;
			this.colCaller.Width = 55;
			// 
			// callerEdit
			// 
			this.callerEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
			this.callerEdit.AutoHeight = false;
			this.callerEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.callerEdit.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
			this.callerEdit.Name = "callerEdit";
			this.callerEdit.NullText = "(none)";
			// 
			// colCallerNote
			// 
			this.colCallerNote.FieldName = "CallerNote";
			this.colCallerNote.Name = "colCallerNote";
			this.colCallerNote.Visible = true;
			this.colCallerNote.VisibleIndex = 4;
			this.colCallerNote.Width = 72;
			// 
			// colAdAmount
			// 
			this.colAdAmount.DisplayFormat.FormatString = "c";
			this.colAdAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colAdAmount.FieldName = "AdAmount";
			this.colAdAmount.Name = "colAdAmount";
			this.colAdAmount.OptionsColumn.AllowEdit = false;
			this.colAdAmount.OptionsColumn.ReadOnly = true;
			this.colAdAmount.Width = 62;
			// 
			// listSearch
			// 
			this.listSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.listSearch.Location = new System.Drawing.Point(0, 400);
			this.listSearch.Name = "listSearch";
			this.listSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.listSearch.Properties.NullValuePrompt = "Click here to search the list";
			this.listSearch.Size = new System.Drawing.Size(712, 20);
			this.listSearch.TabIndex = 1;
			this.listSearch.EditValueChanged += new System.EventHandler(this.listSearch_EditValueChanged);
			// 
			// ribbonControl1
			// 
			this.ribbonControl1.ApplicationButtonText = null;
			// 
			// 
			// 
			this.ribbonControl1.ExpandCollapseItem.Id = 0;
			this.ribbonControl1.ExpandCollapseItem.Name = "";
			this.ribbonControl1.ExpandCollapseItem.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
			this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.showCallers,
            this.autoAssign,
            this.exportGlobalList,
            this.clearCallers});
			this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
			this.ribbonControl1.MaxItemId = 5;
			this.ribbonControl1.Name = "ribbonControl1";
			this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
			this.ribbonControl1.SelectedPage = this.ribbonPage1;
			this.ribbonControl1.Size = new System.Drawing.Size(712, 114);
			this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
			// 
			// showCallers
			// 
			this.showCallers.Caption = "Callers";
			this.showCallers.Glyph = global::ShomreiTorah.Billing.Properties.Resources.Phone16;
			this.showCallers.Id = 1;
			this.showCallers.Name = "showCallers";
			this.showCallers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.showCallers_ItemClick);
			// 
			// autoAssign
			// 
			this.autoAssign.Caption = "Assign Callers";
			this.autoAssign.Id = 2;
			this.autoAssign.Name = "autoAssign";
			toolTipTitleItem1.Text = "Assign Callers";
			toolTipItem1.LeftIndent = 6;
			toolTipItem1.Text = "Automatically distributes checked invitees who have not been assigned a caller to" +
				" the callers.";
			superToolTip1.Items.Add(toolTipTitleItem1);
			superToolTip1.Items.Add(toolTipItem1);
			this.autoAssign.SuperTip = superToolTip1;
			this.autoAssign.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.autoAssign_ItemClick);
			// 
			// exportGlobalList
			// 
			this.exportGlobalList.Caption = "Export to Excel";
			this.exportGlobalList.Id = 3;
			this.exportGlobalList.LargeGlyph = global::ShomreiTorah.Billing.Properties.Resources.ExportExcel32;
			this.exportGlobalList.Name = "exportGlobalList";
			toolTipTitleItem2.Text = "Export To Excel";
			toolTipItem2.LeftIndent = 6;
			toolTipItem2.Text = "Creates an Excel spreadsheet containing everyone who stil needs to be called.\r\n\r\n" +
				"To export lists for specific callers, use the Callers form.";
			superToolTip2.Items.Add(toolTipTitleItem2);
			superToolTip2.Items.Add(toolTipItem2);
			this.exportGlobalList.SuperTip = superToolTip2;
			this.exportGlobalList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.exportGlobalList_ItemClick);
			// 
			// ribbonPage1
			// 
			this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
			this.ribbonPage1.Name = "ribbonPage1";
			this.ribbonPage1.Text = "Melave Malka";
			// 
			// ribbonPageGroup1
			// 
			this.ribbonPageGroup1.ItemLinks.Add(this.showCallers);
			this.ribbonPageGroup1.ItemLinks.Add(this.autoAssign);
			this.ribbonPageGroup1.ItemLinks.Add(this.clearCallers);
			this.ribbonPageGroup1.ItemLinks.Add(this.exportGlobalList);
			this.ribbonPageGroup1.Name = "ribbonPageGroup1";
			this.ribbonPageGroup1.ShowCaptionButton = false;
			this.ribbonPageGroup1.Text = "Call List";
			// 
			// colRowId
			// 
			this.colRowId.FieldName = "RowId";
			this.colRowId.Name = "colRowId";
			this.colRowId.Visible = true;
			this.colRowId.VisibleIndex = 0;
			// 
			// colRowId1
			// 
			this.colRowId1.FieldName = "RowId";
			this.colRowId1.Name = "colRowId1";
			this.colRowId1.Visible = true;
			this.colRowId1.VisibleIndex = 0;
			// 
			// clearCallers
			// 
			this.clearCallers.Caption = "Clear Callers";
			this.clearCallers.Id = 4;
			this.clearCallers.Name = "clearCallers";
			toolTipTitleItem3.Text = "Clear Callers";
			toolTipItem3.LeftIndent = 6;
			toolTipItem3.Text = "Clears the Caller field for the selected people.";
			superToolTip3.Items.Add(toolTipTitleItem3);
			superToolTip3.Items.Add(toolTipItem3);
			this.clearCallers.SuperTip = superToolTip3;
			this.clearCallers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.clearCallers_ItemClick);
			// 
			// CallListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(712, 420);
			this.Controls.Add(this.grid);
			this.Controls.Add(this.ribbonControl1);
			this.Controls.Add(this.listSearch);
			this.Name = "CallListForm";
			this.Text = "CallListForm";
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.callerEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.listSearch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Data.UI.Grid.SmartGrid grid;
		private Data.UI.Grid.SmartGridView gridView;
		private WinForms.Controls.Lookup.ItemSelector listSearch;
		private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
		private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
		private Data.UI.Grid.SmartGridColumn colShouldCall;
		private Data.UI.Grid.SmartGridColumn colPerson;
		private Data.UI.Grid.SmartGridColumn colSource;
		private Data.UI.Grid.SmartGridColumn colCaller;
		private Data.UI.Grid.SmartGridColumn colCallerNote;
		private Data.UI.Grid.SmartGridColumn colAdAmount;
		private Data.UI.Grid.SmartGridColumn colRowId;
		private Data.UI.Grid.SmartGridColumn colRowId1;
		private DevExpress.XtraBars.BarButtonItem showCallers;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox callerEdit;
		private DevExpress.XtraBars.BarButtonItem autoAssign;
		private DevExpress.XtraBars.BarButtonItem exportGlobalList;
		private DevExpress.XtraBars.BarButtonItem clearCallers;
	}
}