namespace ShomreiTorah.Billing.Events.Auctions {
	partial class EntryGrid {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
			this.grid = new ShomreiTorah.Data.UI.Grid.SmartGrid(this.components);
			this.gridView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colAuction = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colItemName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colBidAmount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.normalAmountEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			this.colBidNote = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.noteEdit = new ShomreiTorah.Billing.Controls.Editors.RepositoryItemAliyahNoteEdit();
			this.smartGridColumn1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colMBAmount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.amountEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			this.colMBNote = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.emptyEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.normalAmountEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.noteEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.amountEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptyEdit)).BeginInit();
			this.SuspendLayout();
			// 
			// grid
			// 
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 0);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.RegistrationCount = 52;
			this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.noteEdit,
            this.amountEdit,
            this.emptyEdit,
            this.normalAmountEdit});
			this.grid.Size = new System.Drawing.Size(492, 525);
			this.grid.TabIndex = 0;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
			// 
			// gridView
			// 
			this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAuction,
            this.colItemName,
            this.colBidAmount,
            this.colBidNote,
            this.smartGridColumn1,
            this.colMBAmount,
            this.colMBNote});
			this.gridView.GridControl = this.grid;
			this.gridView.GroupCount = 1;
			this.gridView.GroupFormat = "[#image]{1} {2}";
			this.gridView.Name = "gridView";
			this.gridView.OptionsView.ColumnAutoWidth = false;
			this.gridView.OptionsView.ShowGroupPanel = false;
			this.gridView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colAuction, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colItemName, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.gridView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView_RowCellStyle);
			this.gridView.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView_CustomRowCellEdit);
			this.gridView.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView_ShowingEditor);
			this.gridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
			this.gridView.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gridView_FocusedColumnChanged);
			// 
			// colAuction
			// 
			this.colAuction.Caption = "Auction";
			this.colAuction.FieldName = "AuctionName";
			this.colAuction.FieldNameSortGroup = "Date";
			this.colAuction.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Value;
			this.colAuction.Name = "colAuction";
			this.colAuction.OptionsColumn.AllowEdit = false;
			this.colAuction.OptionsColumn.AllowFocus = false;
			this.colAuction.OptionsColumn.ReadOnly = true;
			this.colAuction.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
			this.colAuction.Width = 74;
			// 
			// colItemName
			// 
			this.colItemName.Caption = "Item";
			this.colItemName.FieldName = "ItemName";
			this.colItemName.FieldNameSortGroup = "ItemIndex";
			this.colItemName.MinWidth = 111;
			this.colItemName.Name = "colItemName";
			this.colItemName.OptionsColumn.AllowEdit = false;
			this.colItemName.OptionsColumn.AllowFocus = false;
			this.colItemName.OptionsColumn.ReadOnly = true;
			this.colItemName.Visible = true;
			this.colItemName.VisibleIndex = 0;
			this.colItemName.Width = 145;
			// 
			// colBidAmount
			// 
			this.colBidAmount.AppearanceCell.Options.UseTextOptions = true;
			this.colBidAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.colBidAmount.Caption = "Auction Amount";
			this.colBidAmount.ColumnEditor = this.normalAmountEdit;
			this.colBidAmount.FieldName = "BidAmount";
			this.colBidAmount.Name = "colBidAmount";
			this.colBidAmount.Visible = true;
			this.colBidAmount.VisibleIndex = 1;
			this.colBidAmount.Width = 108;
			// 
			// normalAmountEdit
			// 
			this.normalAmountEdit.Appearance.Options.UseTextOptions = true;
			this.normalAmountEdit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.normalAmountEdit.AutoHeight = false;
			this.normalAmountEdit.DisplayFormat.FormatString = "c0";
			this.normalAmountEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.normalAmountEdit.EditFormat.FormatString = "c0";
			this.normalAmountEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.normalAmountEdit.Mask.EditMask = "c0";
			this.normalAmountEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.normalAmountEdit.Name = "normalAmountEdit";
			// 
			// colBidNote
			// 
			this.colBidNote.Caption = "Auction Note";
			this.colBidNote.ColumnEditor = this.noteEdit;
			this.colBidNote.FieldName = "BidNote";
			this.colBidNote.Name = "colBidNote";
			this.colBidNote.Visible = true;
			this.colBidNote.VisibleIndex = 2;
			this.colBidNote.Width = 90;
			// 
			// noteEdit
			// 
			this.noteEdit.AutoHeight = false;
			this.noteEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.noteEdit.Name = "noteEdit";
			// 
			// smartGridColumn1
			// 
			this.smartGridColumn1.Caption = "Spacer";
			this.smartGridColumn1.Name = "smartGridColumn1";
			this.smartGridColumn1.OptionsColumn.AllowEdit = false;
			this.smartGridColumn1.OptionsColumn.AllowFocus = false;
			this.smartGridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.smartGridColumn1.OptionsColumn.AllowMove = false;
			this.smartGridColumn1.OptionsColumn.AllowSize = false;
			this.smartGridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.smartGridColumn1.OptionsColumn.FixedWidth = true;
			this.smartGridColumn1.OptionsColumn.ReadOnly = true;
			this.smartGridColumn1.OptionsColumn.ShowCaption = false;
			this.smartGridColumn1.OptionsColumn.TabStop = false;
			this.smartGridColumn1.Visible = true;
			this.smartGridColumn1.VisibleIndex = 3;
			this.smartGridColumn1.Width = 24;
			// 
			// colMBAmount
			// 
			this.colMBAmount.AppearanceCell.Options.UseTextOptions = true;
			this.colMBAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.colMBAmount.Caption = "מי שברך Amount";
			this.colMBAmount.ColumnEditor = this.amountEdit;
			this.colMBAmount.FieldName = "MBAmount";
			this.colMBAmount.Name = "colMBAmount";
			this.colMBAmount.Visible = true;
			this.colMBAmount.VisibleIndex = 4;
			this.colMBAmount.Width = 114;
			// 
			// amountEdit
			// 
			this.amountEdit.Appearance.Options.UseTextOptions = true;
			this.amountEdit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.amountEdit.AutoHeight = false;
			toolTipTitleItem1.Text = "מתנה";
			toolTipItem1.LeftIndent = 6;
			toolTipItem1.Text = "Mark this pledge as a מתנה, setting the amount to $0";
			superToolTip1.Items.Add(toolTipTitleItem1);
			superToolTip1.Items.Add(toolTipItem1);
			this.amountEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "מ", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)), serializableAppearanceObject1, "", null, superToolTip1, true)});
			this.amountEdit.DisplayFormat.FormatString = "c0";
			this.amountEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.amountEdit.EditFormat.FormatString = "c0";
			this.amountEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.amountEdit.Mask.EditMask = "c0";
			this.amountEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.amountEdit.Name = "amountEdit";
			this.amountEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.amountEdit_ButtonClick);
			// 
			// colMBNote
			// 
			this.colMBNote.Caption = "מי שברך Note";
			this.colMBNote.ColumnEditor = this.noteEdit;
			this.colMBNote.FieldName = "MBNote";
			this.colMBNote.Name = "colMBNote";
			this.colMBNote.Visible = true;
			this.colMBNote.VisibleIndex = 5;
			this.colMBNote.Width = 96;
			// 
			// emptyEdit
			// 
			this.emptyEdit.AllowFocused = false;
			this.emptyEdit.Appearance.Options.UseTextOptions = true;
			this.emptyEdit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.emptyEdit.AutoHeight = false;
			this.emptyEdit.Name = "emptyEdit";
			this.emptyEdit.NullText = "N/A";
			this.emptyEdit.ReadOnly = true;
			this.emptyEdit.UseParentBackground = true;
			// 
			// EntryGrid
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.grid);
			this.Name = "EntryGrid";
			this.Size = new System.Drawing.Size(492, 525);
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.normalAmountEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.noteEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.amountEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptyEdit)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Data.UI.Grid.SmartGrid grid;
		private Data.UI.Grid.SmartGridView gridView;
		private Data.UI.Grid.SmartGridColumn colAuction;
		private Data.UI.Grid.SmartGridColumn colItemName;
		private Data.UI.Grid.SmartGridColumn colBidAmount;
		private Data.UI.Grid.SmartGridColumn colBidNote;
		private Data.UI.Grid.SmartGridColumn colMBAmount;
		private Data.UI.Grid.SmartGridColumn colMBNote;
		private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit amountEdit;
		private Controls.Editors.RepositoryItemAliyahNoteEdit noteEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit emptyEdit;
		private Data.UI.Grid.SmartGridColumn smartGridColumn1;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit normalAmountEdit;
	}
}
