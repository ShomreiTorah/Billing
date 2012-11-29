namespace ShomreiTorah.Billing.Events.MelaveMalka {
	partial class MMInfoForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MMInfoForm));
			this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
			this.bar1 = new DevExpress.XtraBars.Bar();
			this.showAddForm = new DevExpress.XtraBars.BarButtonItem();
			this.uploadAdBlank = new DevExpress.XtraBars.BarButtonItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.grid = new ShomreiTorah.Data.UI.Grid.SmartGrid(this.components);
			this.gridView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colYear = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAdDeadline = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.hebrewCalendarEdit = new ShomreiTorah.Billing.Controls.RepositoryItemHebrewCalendarEdit();
			this.colMelaveMalkaDate = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colHonoree = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colSpeaker = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colMelaveMalkaDateTime = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.repositoryItemTimeEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
			this.colRowId = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colHonoreeTitle = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colHonoree2 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colHonoree2Title = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.hebrewCalendarEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
			this.SuspendLayout();
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
            this.showAddForm,
            this.uploadAdBlank});
			this.barManager1.MaxItemId = 2;
			// 
			// bar1
			// 
			this.bar1.BarName = "Tools";
			this.bar1.DockCol = 0;
			this.bar1.DockRow = 0;
			this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.showAddForm),
            new DevExpress.XtraBars.LinkPersistInfo(this.uploadAdBlank, true)});
			this.bar1.OptionsBar.AllowQuickCustomization = false;
			this.bar1.OptionsBar.DisableClose = true;
			this.bar1.OptionsBar.DisableCustomization = true;
			this.bar1.OptionsBar.DrawDragBorder = false;
			this.bar1.OptionsBar.UseWholeRow = true;
			this.bar1.Text = "Tools";
			// 
			// showAddForm
			// 
			this.showAddForm.Caption = "Add Melave Malka";
			this.showAddForm.Glyph = global::ShomreiTorah.Billing.Properties.Resources.Add16;
			this.showAddForm.Id = 0;
			this.showAddForm.Name = "showAddForm";
			this.showAddForm.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
			this.showAddForm.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.showAddForm_ItemClick);
			// 
			// uploadAdBlank
			// 
			this.uploadAdBlank.Caption = "Upload Ad Blank";
			this.uploadAdBlank.Id = 1;
			this.uploadAdBlank.Name = "uploadAdBlank";
			this.uploadAdBlank.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.uploadAdBlank_ItemClick);
			// 
			// barDockControlTop
			// 
			this.barDockControlTop.CausesValidation = false;
			this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
			this.barDockControlTop.Size = new System.Drawing.Size(760, 29);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 361);
			this.barDockControlBottom.Size = new System.Drawing.Size(760, 0);
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.barDockControlLeft.Location = new System.Drawing.Point(0, 29);
			this.barDockControlLeft.Size = new System.Drawing.Size(0, 332);
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.barDockControlRight.Location = new System.Drawing.Point(760, 29);
			this.barDockControlRight.Size = new System.Drawing.Size(0, 332);
			// 
			// grid
			// 
			this.grid.DataMember = "MelaveMalkaInfo";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 29);
			this.grid.MainView = this.gridView;
			this.grid.MenuManager = this.barManager1;
			this.grid.Name = "grid";
			this.grid.RegistrationCount = 53;
			this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.hebrewCalendarEdit,
            this.repositoryItemTimeEdit1});
			this.grid.Size = new System.Drawing.Size(760, 332);
			this.grid.TabIndex = 4;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colYear,
            this.colAdDeadline,
            this.colMelaveMalkaDate,
            this.colHonoree,
            this.colHonoreeTitle,
            this.colHonoree2,
            this.colHonoree2Title,
            this.colSpeaker,
            this.colMelaveMalkaDateTime});
			this.gridView.GridControl = this.grid;
			this.gridView.Name = "gridView";
			this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colYear, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.gridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
			// 
			// colYear
			// 
			this.colYear.FieldName = "Year";
			this.colYear.MaxWidth = 60;
			this.colYear.Name = "colYear";
			this.colYear.OptionsColumn.AllowEdit = false;
			this.colYear.OptionsColumn.ReadOnly = true;
			this.colYear.Visible = true;
			this.colYear.VisibleIndex = 0;
			this.colYear.Width = 54;
			// 
			// colAdDeadline
			// 
			this.colAdDeadline.ColumnEditor = this.hebrewCalendarEdit;
			this.colAdDeadline.FieldName = "AdDeadline";
			this.colAdDeadline.Name = "colAdDeadline";
			this.colAdDeadline.Visible = true;
			this.colAdDeadline.VisibleIndex = 1;
			this.colAdDeadline.Width = 114;
			// 
			// hebrewCalendarEdit
			// 
			this.hebrewCalendarEdit.AutoHeight = false;
			this.hebrewCalendarEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.hebrewCalendarEdit.DisplayFormat.FormatString = "dddd, MMMM d";
			this.hebrewCalendarEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.hebrewCalendarEdit.EditFormat.FormatString = "dddd, MMMM d";
			this.hebrewCalendarEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.hebrewCalendarEdit.Mask.EditMask = "dddd, MMMM d";
			this.hebrewCalendarEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.hebrewCalendarEdit.Name = "hebrewCalendarEdit";
			// 
			// colMelaveMalkaDate
			// 
			this.colMelaveMalkaDate.ColumnEditor = this.hebrewCalendarEdit;
			this.colMelaveMalkaDate.FieldName = "MelaveMalkaDate";
			this.colMelaveMalkaDate.Name = "colMelaveMalkaDate";
			this.colMelaveMalkaDate.Visible = true;
			this.colMelaveMalkaDate.VisibleIndex = 2;
			this.colMelaveMalkaDate.Width = 114;
			// 
			// colHonoree
			// 
			this.colHonoree.AllowKeyboardActivation = false;
			this.colHonoree.Caption = "Honoree";
			this.colHonoree.FieldName = "Honoree";
			this.colHonoree.Name = "colHonoree";
			this.colHonoree.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
			this.colHonoree.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.colHonoree.OptionsColumn.ReadOnly = true;
			this.colHonoree.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colHonoree.ShowEditorOnMouseDown = true;
			this.colHonoree.Visible = true;
			this.colHonoree.VisibleIndex = 4;
			this.colHonoree.Width = 60;
			// 
			// colSpeaker
			// 
			this.colSpeaker.Caption = "Guest Speaker";
			this.colSpeaker.FieldName = "Speaker";
			this.colSpeaker.Name = "colSpeaker";
			this.colSpeaker.Visible = true;
			this.colSpeaker.VisibleIndex = 8;
			this.colSpeaker.Width = 89;
			// 
			// colMelaveMalkaDateTime
			// 
			this.colMelaveMalkaDateTime.Caption = "Time";
			this.colMelaveMalkaDateTime.ColumnEditor = this.repositoryItemTimeEdit1;
			this.colMelaveMalkaDateTime.FieldName = "MelaveMalkaDate";
			this.colMelaveMalkaDateTime.Name = "colMelaveMalkaDateTime";
			this.colMelaveMalkaDateTime.Visible = true;
			this.colMelaveMalkaDateTime.VisibleIndex = 3;
			this.colMelaveMalkaDateTime.Width = 53;
			// 
			// repositoryItemTimeEdit1
			// 
			this.repositoryItemTimeEdit1.AutoHeight = false;
			this.repositoryItemTimeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.repositoryItemTimeEdit1.Mask.EditMask = "h:mm tt";
			this.repositoryItemTimeEdit1.Name = "repositoryItemTimeEdit1";
			// 
			// colRowId
			// 
			this.colRowId.FieldName = "RowId";
			this.colRowId.Name = "colRowId";
			this.colRowId.Visible = true;
			this.colRowId.VisibleIndex = 0;
			// 
			// colHonoreeTitle
			// 
			this.colHonoreeTitle.FieldName = "HonoreeTitle";
			this.colHonoreeTitle.Name = "colHonoreeTitle";
			this.colHonoreeTitle.Visible = true;
			this.colHonoreeTitle.VisibleIndex = 5;
			// 
			// colHonoree2
			// 
			this.colHonoree2.AllowKeyboardActivation = false;
			this.colHonoree2.Caption = "Secondary Honoree";
			this.colHonoree2.FieldName = "Honoree2";
			this.colHonoree2.Name = "colHonoree2";
			this.colHonoree2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
			this.colHonoree2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.colHonoree2.OptionsColumn.ReadOnly = true;
			this.colHonoree2.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colHonoree2.ShowEditorOnMouseDown = true;
			this.colHonoree2.Visible = true;
			this.colHonoree2.VisibleIndex = 6;
			// 
			// colHonoree2Title
			// 
			this.colHonoree2Title.Caption = "Secondary Honoree Title";
			this.colHonoree2Title.FieldName = "Honoree2Title";
			this.colHonoree2Title.Name = "colHonoree2Title";
			this.colHonoree2Title.Visible = true;
			this.colHonoree2Title.VisibleIndex = 7;
			// 
			// MMInfoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(760, 361);
			this.Controls.Add(this.grid);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MMInfoForm";
			this.Text = "Melave Malka Info";
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.hebrewCalendarEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraBars.BarManager barManager1;
		private DevExpress.XtraBars.Bar bar1;
		private DevExpress.XtraBars.BarButtonItem showAddForm;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private Data.UI.Grid.SmartGrid grid;
		private Data.UI.Grid.SmartGridView gridView;
		private Data.UI.Grid.SmartGridColumn colYear;
		private Data.UI.Grid.SmartGridColumn colAdDeadline;
		private Data.UI.Grid.SmartGridColumn colMelaveMalkaDate;
		private Data.UI.Grid.SmartGridColumn colHonoree;
		private Data.UI.Grid.SmartGridColumn colSpeaker;
		private Data.UI.Grid.SmartGridColumn colRowId;
		private Controls.RepositoryItemHebrewCalendarEdit hebrewCalendarEdit;
		private Data.UI.Grid.SmartGridColumn colMelaveMalkaDateTime;
		private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit1;
		private DevExpress.XtraBars.BarButtonItem uploadAdBlank;
		private Data.UI.Grid.SmartGridColumn colHonoreeTitle;
		private Data.UI.Grid.SmartGridColumn colHonoree2;
		private Data.UI.Grid.SmartGridColumn colHonoree2Title;
	}
}