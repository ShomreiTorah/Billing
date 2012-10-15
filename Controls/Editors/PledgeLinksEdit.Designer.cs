namespace ShomreiTorah.Billing.Controls.Editors {
	partial class PledgeLinksEdit {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
			DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PledgeLinksEdit));
			DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
			DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
			this.pledgesGrid = new ShomreiTorah.Data.UI.Grid.SmartGrid();
			this.pledgesView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colDate = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colType = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colSubType = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAmount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.htmlDisplay = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			this.colNote = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colComments = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colModified = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colModifier = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colLinkAmount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colPledgeId = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colExternalSource = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colExternalId = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.barManager1 = new DevExpress.XtraBars.BarManager();
			this.bar1 = new DevExpress.XtraBars.Bar();
			this.paymentSummary = new DevExpress.XtraBars.BarStaticItem();
			this.clearLinks = new DevExpress.XtraBars.BarButtonItem();
			this.fillLinks = new DevExpress.XtraBars.BarButtonItem();
			this.addDonation = new DevExpress.XtraBars.BarButtonItem();
			this.migratePledges = new DevExpress.XtraBars.BarButtonItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			((System.ComponentModel.ISupportInitialize)(this.pledgesGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgesView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.htmlDisplay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
			this.SuspendLayout();
			// 
			// pledgesGrid
			// 
			this.pledgesGrid.DataMember = "Pledges";
			this.pledgesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pledgesGrid.Location = new System.Drawing.Point(0, 31);
			this.pledgesGrid.MainView = this.pledgesView;
			this.pledgesGrid.Name = "pledgesGrid";
			this.pledgesGrid.RegistrationCount = 53;
			this.pledgesGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.htmlDisplay});
			this.pledgesGrid.ShowOnlyPredefinedDetails = true;
			this.pledgesGrid.Size = new System.Drawing.Size(614, 253);
			this.pledgesGrid.TabIndex = 0;
			this.pledgesGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.pledgesView});
			// 
			// pledgesView
			// 
			this.pledgesView.ActiveFilterString = "[Unlinked] <> 0.0m";
			this.pledgesView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDate,
            this.colType,
            this.colSubType,
            this.colAmount,
            this.colNote,
            this.colComments,
            this.colModified,
            this.colModifier,
            this.colLinkAmount});
			this.pledgesView.GridControl = this.pledgesGrid;
			this.pledgesView.Name = "pledgesView";
			this.pledgesView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDate, DevExpress.Data.ColumnSortOrder.Descending)});
			this.pledgesView.CustomSuperTip += new System.EventHandler<ShomreiTorah.Data.UI.Grid.CustomToolTipEventArgs>(this.pledgesView_CustomSuperTip);
			this.pledgesView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.pledgesView_RowStyle);
			this.pledgesView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.pledgesView_ValidateRow);
			this.pledgesView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.pledgesView_CustomUnboundColumnData);
			this.pledgesView.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.pledgesView_CustomColumnDisplayText);
			this.pledgesView.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.pledgesView_ValidatingEditor);
			// 
			// colDate
			// 
			this.colDate.FieldName = "Date";
			this.colDate.Name = "colDate";
			this.colDate.OptionsColumn.AllowEdit = false;
			this.colDate.OptionsColumn.ReadOnly = true;
			this.colDate.Visible = true;
			this.colDate.VisibleIndex = 0;
			this.colDate.Width = 57;
			// 
			// colType
			// 
			this.colType.FieldName = "Type";
			this.colType.Name = "colType";
			this.colType.OptionsColumn.AllowEdit = false;
			this.colType.OptionsColumn.ReadOnly = true;
			this.colType.Visible = true;
			this.colType.VisibleIndex = 1;
			this.colType.Width = 43;
			// 
			// colSubType
			// 
			this.colSubType.Caption = "Subtype";
			this.colSubType.FieldName = "SubType";
			this.colSubType.Name = "colSubType";
			this.colSubType.OptionsColumn.AllowEdit = false;
			this.colSubType.OptionsColumn.ReadOnly = true;
			this.colSubType.Visible = true;
			this.colSubType.VisibleIndex = 2;
			this.colSubType.Width = 59;
			// 
			// colAmount
			// 
			this.colAmount.AppearanceCell.Options.UseTextOptions = true;
			this.colAmount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.colAmount.Caption = "Unpaid";
			this.colAmount.ColumnEditor = this.htmlDisplay;
			this.colAmount.DisplayFormat.FormatString = "c";
			this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colAmount.FieldName = "Unlinked";
			this.colAmount.MinWidth = 100;
			this.colAmount.Name = "colAmount";
			this.colAmount.OptionsColumn.AllowEdit = false;
			this.colAmount.OptionsColumn.ReadOnly = true;
			this.colAmount.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UnlinkedAmount", "{0:c} Total Unpaid-for")});
			this.colAmount.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
			this.colAmount.Visible = true;
			this.colAmount.VisibleIndex = 3;
			this.colAmount.Width = 100;
			// 
			// htmlDisplay
			// 
			this.htmlDisplay.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
			this.htmlDisplay.AutoHeight = false;
			this.htmlDisplay.Name = "htmlDisplay";
			this.htmlDisplay.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			// 
			// colNote
			// 
			this.colNote.FieldName = "Note";
			this.colNote.MaxWidth = 200;
			this.colNote.Name = "colNote";
			this.colNote.Visible = true;
			this.colNote.VisibleIndex = 4;
			this.colNote.Width = 42;
			// 
			// colComments
			// 
			this.colComments.FieldName = "Comments";
			this.colComments.MaxWidth = 200;
			this.colComments.Name = "colComments";
			this.colComments.Visible = true;
			this.colComments.VisibleIndex = 5;
			this.colComments.Width = 69;
			// 
			// colModified
			// 
			this.colModified.DisplayFormat.FormatString = "g";
			this.colModified.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colModified.FieldName = "Modified";
			this.colModified.Name = "colModified";
			this.colModified.Width = 106;
			// 
			// colModifier
			// 
			this.colModifier.FieldName = "Modifier";
			this.colModifier.Name = "colModifier";
			this.colModifier.Width = 47;
			// 
			// colLinkAmount
			// 
			this.colLinkAmount.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.colLinkAmount.AppearanceCell.Options.UseFont = true;
			this.colLinkAmount.Caption = "Link?";
			this.colLinkAmount.DisplayFormat.FormatString = "c";
			this.colLinkAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colLinkAmount.FieldName = "AmountToLink";
			this.colLinkAmount.MaxWidth = 85;
			this.colLinkAmount.MinWidth = 65;
			this.colLinkAmount.Name = "colLinkAmount";
			this.colLinkAmount.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colLinkAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountToLink", "{0:c} Total Pledged")});
			this.colLinkAmount.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
			this.colLinkAmount.Visible = true;
			this.colLinkAmount.VisibleIndex = 6;
			this.colLinkAmount.Width = 65;
			// 
			// colPledgeId
			// 
			this.colPledgeId.FieldName = "PledgeId";
			this.colPledgeId.Name = "colPledgeId";
			// 
			// colExternalSource
			// 
			this.colExternalSource.FieldName = "ExternalSource";
			this.colExternalSource.Name = "colExternalSource";
			// 
			// colExternalId
			// 
			this.colExternalId.FieldName = "ExternalId";
			this.colExternalId.Name = "colExternalId";
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
            this.paymentSummary,
            this.clearLinks,
            this.fillLinks,
            this.addDonation,
            this.migratePledges});
			this.barManager1.MaxItemId = 5;
			// 
			// bar1
			// 
			this.bar1.BarName = "Tools";
			this.bar1.DockCol = 0;
			this.bar1.DockRow = 0;
			this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.paymentSummary),
            new DevExpress.XtraBars.LinkPersistInfo(this.clearLinks),
            new DevExpress.XtraBars.LinkPersistInfo(this.fillLinks),
            new DevExpress.XtraBars.LinkPersistInfo(this.addDonation, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.migratePledges)});
			this.bar1.OptionsBar.AllowQuickCustomization = false;
			this.bar1.OptionsBar.DisableClose = true;
			this.bar1.OptionsBar.DisableCustomization = true;
			this.bar1.OptionsBar.DrawDragBorder = false;
			this.bar1.OptionsBar.UseWholeRow = true;
			this.bar1.Text = "Tools";
			// 
			// paymentSummary
			// 
			this.paymentSummary.Caption = "$456 − $123 = $333";
			this.paymentSummary.Glyph = global::ShomreiTorah.Billing.Properties.Resources.StatusGreen16;
			this.paymentSummary.Id = 0;
			this.paymentSummary.Name = "paymentSummary";
			this.paymentSummary.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
			this.paymentSummary.TextAlignment = System.Drawing.StringAlignment.Near;
			// 
			// clearLinks
			// 
			this.clearLinks.Caption = "Clear";
			this.clearLinks.Id = 1;
			this.clearLinks.Name = "clearLinks";
			toolTipTitleItem1.Text = "Clear";
			toolTipItem1.LeftIndent = 6;
			toolTipItem1.Text = "Resets the links for this payment, unlinking it from all pledges.";
			superToolTip1.Items.Add(toolTipTitleItem1);
			superToolTip1.Items.Add(toolTipItem1);
			this.clearLinks.SuperTip = superToolTip1;
			this.clearLinks.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.clearLinks_ItemClick);
			// 
			// fillLinks
			// 
			this.fillLinks.Caption = "Fill Down";
			this.fillLinks.Id = 2;
			this.fillLinks.Name = "fillLinks";
			toolTipTitleItem2.Text = "Fill Down";
			toolTipItem2.LeftIndent = 6;
			toolTipItem2.Text = resources.GetString("toolTipItem2.Text");
			superToolTip2.Items.Add(toolTipTitleItem2);
			superToolTip2.Items.Add(toolTipItem2);
			this.fillLinks.SuperTip = superToolTip2;
			this.fillLinks.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.fillLinks_ItemClick);
			// 
			// addDonation
			// 
			this.addDonation.Caption = "Add donation pledge";
			this.addDonation.Id = 3;
			this.addDonation.Name = "addDonation";
			toolTipTitleItem3.Text = "Add Donation Pledge";
			toolTipItem3.LeftIndent = 6;
			toolTipItem3.Text = resources.GetString("toolTipItem3.Text");
			superToolTip3.Items.Add(toolTipTitleItem3);
			superToolTip3.Items.Add(toolTipItem3);
			this.addDonation.SuperTip = superToolTip3;
			this.addDonation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addDonation_ItemClick);
			// 
			// migratePledges
			// 
			this.migratePledges.Caption = "Migrate pledges from member";
			this.migratePledges.Id = 4;
			this.migratePledges.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.migratePledges.ItemAppearance.Normal.Options.UseFont = true;
			this.migratePledges.Name = "migratePledges";
			toolTipTitleItem4.Text = "Migrate pledges from member";
			toolTipItem4.LeftIndent = 6;
			toolTipItem4.Text = resources.GetString("toolTipItem4.Text");
			superToolTip4.Items.Add(toolTipTitleItem4);
			superToolTip4.Items.Add(toolTipItem4);
			this.migratePledges.SuperTip = superToolTip4;
			this.migratePledges.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.migratePledges_ItemClick);
			// 
			// barDockControlTop
			// 
			this.barDockControlTop.CausesValidation = false;
			this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
			this.barDockControlTop.Size = new System.Drawing.Size(614, 31);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 284);
			this.barDockControlBottom.Size = new System.Drawing.Size(614, 0);
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
			this.barDockControlLeft.Size = new System.Drawing.Size(0, 253);
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.barDockControlRight.Location = new System.Drawing.Point(614, 31);
			this.barDockControlRight.Size = new System.Drawing.Size(0, 253);
			// 
			// PledgeLinksEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pledgesGrid);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Name = "PledgeLinksEdit";
			this.Size = new System.Drawing.Size(614, 284);
			((System.ComponentModel.ISupportInitialize)(this.pledgesGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgesView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.htmlDisplay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Data.UI.Grid.SmartGrid pledgesGrid;
		private Data.UI.Grid.SmartGridView pledgesView;
		private Data.UI.Grid.SmartGridColumn colDate;
		private Data.UI.Grid.SmartGridColumn colType;
		private Data.UI.Grid.SmartGridColumn colSubType;
		private Data.UI.Grid.SmartGridColumn colAmount;
		private Data.UI.Grid.SmartGridColumn colNote;
		private Data.UI.Grid.SmartGridColumn colComments;
		private Data.UI.Grid.SmartGridColumn colModified;
		private Data.UI.Grid.SmartGridColumn colModifier;
		private Data.UI.Grid.SmartGridColumn colPledgeId;
		private Data.UI.Grid.SmartGridColumn colExternalSource;
		private Data.UI.Grid.SmartGridColumn colExternalId;
		private Data.UI.Grid.SmartGridColumn colLinkAmount;
		private DevExpress.XtraBars.BarManager barManager1;
		private DevExpress.XtraBars.Bar bar1;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private DevExpress.XtraBars.BarStaticItem paymentSummary;
		private DevExpress.XtraBars.BarButtonItem clearLinks;
		private DevExpress.XtraBars.BarButtonItem fillLinks;
		private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit htmlDisplay;
		private DevExpress.XtraBars.BarButtonItem addDonation;
		private DevExpress.XtraBars.BarButtonItem migratePledges;

	}
}
