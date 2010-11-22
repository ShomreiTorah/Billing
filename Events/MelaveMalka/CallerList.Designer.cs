namespace ShomreiTorah.Billing.Events.MelaveMalka {
	partial class CallerList {
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
			DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CallerList));
			this.calleesView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colPerson1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colDateAdded1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAdAmount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.grid = new ShomreiTorah.Data.UI.Grid.SmartGrid(this.components);
			this.gridView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colCallerPerson = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colDateAdded = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colCalleeCount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colEmailAddresses = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.emailLinkEdit = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
			this.addCaller = new ShomreiTorah.WinForms.Controls.Lookup.ItemSelector();
			this.colRowId = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colRowId1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colCaller = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
			this.bar1 = new DevExpress.XtraBars.Bar();
			this.sendAllEmails = new DevExpress.XtraBars.BarButtonItem();
			this.sendSingleEmail = new DevExpress.XtraBars.BarButtonItem();
			this.exportCallList = new DevExpress.XtraBars.BarButtonItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			((System.ComponentModel.ISupportInitialize)(this.calleesView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emailLinkEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.addCaller.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
			this.SuspendLayout();
			// 
			// calleesView
			// 
			this.calleesView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPerson1,
            this.colDateAdded1,
            this.colAdAmount});
			this.calleesView.GridControl = this.grid;
			this.calleesView.Name = "calleesView";
			this.calleesView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
			this.calleesView.OptionsView.ShowFooter = true;
			this.calleesView.OptionsView.ShowGroupPanel = false;
			// 
			// colPerson1
			// 
			this.colPerson1.Caption = "Full Name";
			this.colPerson1.FieldName = "Person";
			this.colPerson1.Name = "colPerson1";
			this.colPerson1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
			this.colPerson1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.colPerson1.OptionsColumn.ReadOnly = true;
			this.colPerson1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colPerson1.ShowEditorOnMouseDown = true;
			this.colPerson1.SummaryItem.DisplayFormat = "{0} Callees";
			this.colPerson1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
			this.colPerson1.Visible = true;
			this.colPerson1.VisibleIndex = 0;
			this.colPerson1.Width = 65;
			// 
			// colDateAdded1
			// 
			this.colDateAdded1.FieldName = "DateAdded";
			this.colDateAdded1.Name = "colDateAdded1";
			this.colDateAdded1.OptionsColumn.AllowEdit = false;
			this.colDateAdded1.OptionsColumn.AllowFocus = false;
			this.colDateAdded1.Visible = true;
			this.colDateAdded1.VisibleIndex = 1;
			this.colDateAdded1.Width = 76;
			// 
			// colAdAmount
			// 
			this.colAdAmount.DisplayFormat.FormatString = "c";
			this.colAdAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colAdAmount.FieldName = "AdAmount";
			this.colAdAmount.Name = "colAdAmount";
			this.colAdAmount.OptionsColumn.AllowEdit = false;
			this.colAdAmount.OptionsColumn.AllowFocus = false;
			this.colAdAmount.OptionsColumn.ReadOnly = true;
			this.colAdAmount.SummaryItem.DisplayFormat = "{0:c} in ads";
			this.colAdAmount.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.colAdAmount.Visible = true;
			this.colAdAmount.VisibleIndex = 2;
			this.colAdAmount.Width = 72;
			// 
			// grid
			// 
			this.grid.DataMember = "Callers";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			gridLevelNode1.LevelTemplate = this.calleesView;
			gridLevelNode1.RelationName = "Callees";
			this.grid.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
			this.grid.Location = new System.Drawing.Point(0, 49);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.RegistrationCount = 48;
			this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.emailLinkEdit});
			this.grid.Size = new System.Drawing.Size(514, 329);
			this.grid.TabIndex = 1;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.calleesView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCallerPerson,
            this.colDateAdded,
            this.colCalleeCount,
            this.colEmailAddresses});
			this.gridView.GridControl = this.grid;
			this.gridView.Name = "gridView";
			this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
			this.gridView.OptionsView.ShowFooter = true;
			this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCallerPerson, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.gridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
			this.gridView.DoubleClick += new System.EventHandler(this.gridView_DoubleClick);
			// 
			// colCallerPerson
			// 
			this.colCallerPerson.AllowKeyboardActivation = false;
			this.colCallerPerson.Caption = "Full Name";
			this.colCallerPerson.FieldName = "Person";
			this.colCallerPerson.Name = "colCallerPerson";
			this.colCallerPerson.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
			this.colCallerPerson.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.colCallerPerson.OptionsColumn.ReadOnly = true;
			this.colCallerPerson.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colCallerPerson.ShowEditorOnMouseDown = true;
			this.colCallerPerson.SummaryItem.DisplayFormat = "{0} callers";
			this.colCallerPerson.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
			this.colCallerPerson.Visible = true;
			this.colCallerPerson.VisibleIndex = 0;
			this.colCallerPerson.Width = 78;
			// 
			// colDateAdded
			// 
			this.colDateAdded.FieldName = "DateAdded";
			this.colDateAdded.Name = "colDateAdded";
			this.colDateAdded.OptionsColumn.AllowEdit = false;
			this.colDateAdded.OptionsColumn.ReadOnly = true;
			this.colDateAdded.Width = 66;
			// 
			// colCalleeCount
			// 
			this.colCalleeCount.Caption = "Callees";
			this.colCalleeCount.FieldName = "CalleeCount";
			this.colCalleeCount.Name = "colCalleeCount";
			this.colCalleeCount.OptionsColumn.AllowEdit = false;
			this.colCalleeCount.OptionsColumn.ReadOnly = true;
			this.colCalleeCount.SummaryItem.DisplayFormat = "{0} assigned callees";
			this.colCalleeCount.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.colCalleeCount.Visible = true;
			this.colCalleeCount.VisibleIndex = 1;
			this.colCalleeCount.Width = 111;
			// 
			// colEmailAddresses
			// 
			this.colEmailAddresses.ColumnEditor = this.emailLinkEdit;
			this.colEmailAddresses.FieldName = "EmailAddresses";
			this.colEmailAddresses.Name = "colEmailAddresses";
			this.colEmailAddresses.OptionsColumn.ReadOnly = true;
			this.colEmailAddresses.Visible = true;
			this.colEmailAddresses.VisibleIndex = 2;
			this.colEmailAddresses.Width = 96;
			// 
			// emailLinkEdit
			// 
			this.emailLinkEdit.AutoHeight = false;
			this.emailLinkEdit.Name = "emailLinkEdit";
			this.emailLinkEdit.ReadOnly = true;
			this.emailLinkEdit.SingleClick = true;
			this.emailLinkEdit.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.emailLinkEdit_OpenLink);
			// 
			// addCaller
			// 
			this.addCaller.Dock = System.Windows.Forms.DockStyle.Top;
			this.addCaller.Location = new System.Drawing.Point(0, 29);
			this.addCaller.Name = "addCaller";
			this.addCaller.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.addCaller.Properties.NullValuePrompt = "Click here to add a caller";
			this.addCaller.Size = new System.Drawing.Size(514, 20);
			this.addCaller.TabIndex = 0;
			this.addCaller.EditValueChanged += new System.EventHandler(this.addCaller_EditValueChanged);
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
			// colCaller
			// 
			this.colCaller.FieldName = "Caller";
			this.colCaller.Name = "colCaller";
			this.colCaller.Visible = true;
			this.colCaller.VisibleIndex = 6;
			// 
			// barManager1
			// 
			this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
			this.barManager1.DockControls.Add(this.barDockControlTop);
			this.barManager1.DockControls.Add(this.barDockControlBottom);
			this.barManager1.DockControls.Add(this.barDockControlLeft);
			this.barManager1.DockControls.Add(this.barDockControlRight);
			this.barManager1.Form = this;
			this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.exportCallList,
            this.sendSingleEmail,
            this.sendAllEmails});
			this.barManager1.MaxItemId = 3;
			// 
			// bar1
			// 
			this.bar1.BarName = "Tools";
			this.bar1.DockCol = 0;
			this.bar1.DockRow = 0;
			this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.sendAllEmails),
            new DevExpress.XtraBars.LinkPersistInfo(this.sendSingleEmail, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.exportCallList)});
			this.bar1.OptionsBar.AllowQuickCustomization = false;
			this.bar1.OptionsBar.DisableClose = true;
			this.bar1.OptionsBar.DrawDragBorder = false;
			this.bar1.OptionsBar.UseWholeRow = true;
			this.bar1.Text = "Tools";
			// 
			// sendAllEmails
			// 
			this.sendAllEmails.Caption = "Email Everyone";
			this.sendAllEmails.Glyph = global::ShomreiTorah.Billing.Properties.Resources.SendMails16;
			this.sendAllEmails.Id = 2;
			this.sendAllEmails.Name = "sendAllEmails";
			this.sendAllEmails.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
			// 
			// sendSingleEmail
			// 
			this.sendSingleEmail.Caption = "Email ";
			this.sendSingleEmail.Glyph = global::ShomreiTorah.Billing.Properties.Resources.SendMail16;
			this.sendSingleEmail.Id = 1;
			this.sendSingleEmail.Name = "sendSingleEmail";
			this.sendSingleEmail.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
			// 
			// exportCallList
			// 
			this.exportCallList.Caption = "Create Personalized List";
			this.exportCallList.Glyph = global::ShomreiTorah.Billing.Properties.Resources.ExportExcel16;
			this.exportCallList.Id = 0;
			this.exportCallList.Name = "exportCallList";
			this.exportCallList.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
			this.exportCallList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.exportCallList_ItemClick);
			// 
			// barDockControlTop
			// 
			this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
			this.barDockControlTop.Size = new System.Drawing.Size(514, 29);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 378);
			this.barDockControlBottom.Size = new System.Drawing.Size(514, 0);
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.barDockControlLeft.Location = new System.Drawing.Point(0, 29);
			this.barDockControlLeft.Size = new System.Drawing.Size(0, 349);
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.barDockControlRight.Location = new System.Drawing.Point(514, 29);
			this.barDockControlRight.Size = new System.Drawing.Size(0, 349);
			// 
			// CallerList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(514, 378);
			this.Controls.Add(this.grid);
			this.Controls.Add(this.addCaller);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CallerList";
			this.Text = "CallerList";
			((System.ComponentModel.ISupportInitialize)(this.calleesView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emailLinkEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.addCaller.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private WinForms.Controls.Lookup.ItemSelector addCaller;
		private Data.UI.Grid.SmartGrid grid;
		private Data.UI.Grid.SmartGridView gridView;
		private Data.UI.Grid.SmartGridColumn colCallerPerson;
		private Data.UI.Grid.SmartGridColumn colDateAdded;
		private Data.UI.Grid.SmartGridColumn colEmailAddresses;
		private Data.UI.Grid.SmartGridColumn colRowId;
		private Data.UI.Grid.SmartGridView calleesView;
		private Data.UI.Grid.SmartGridColumn colPerson1;
		private Data.UI.Grid.SmartGridColumn colDateAdded1;
		private Data.UI.Grid.SmartGridColumn colAdAmount;
		private Data.UI.Grid.SmartGridColumn colRowId1;
		private Data.UI.Grid.SmartGridColumn colCaller;
		private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit emailLinkEdit;
		private Data.UI.Grid.SmartGridColumn colCalleeCount;
		private DevExpress.XtraBars.BarManager barManager1;
		private DevExpress.XtraBars.Bar bar1;
		private DevExpress.XtraBars.BarButtonItem exportCallList;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private DevExpress.XtraBars.BarButtonItem sendSingleEmail;
		private DevExpress.XtraBars.BarButtonItem sendAllEmails;
	}
}