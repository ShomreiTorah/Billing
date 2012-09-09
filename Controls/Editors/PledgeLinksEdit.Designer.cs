namespace ShomreiTorah.Billing.Controls.Editors {
	partial class PledgeLinksEdit {
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
			this.pledgesGrid = new ShomreiTorah.Data.UI.Grid.SmartGrid(this.components);
			this.pledgesView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colDate = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colType = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colSubType = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAmount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colNote = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colComments = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colModified = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colModifier = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colLinkAmount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colPledgeId = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colExternalSource = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colExternalId = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			((System.ComponentModel.ISupportInitialize)(this.pledgesGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgesView)).BeginInit();
			this.SuspendLayout();
			// 
			// pledgesGrid
			// 
			this.pledgesGrid.DataMember = "Pledges";
			this.pledgesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pledgesGrid.Location = new System.Drawing.Point(0, 0);
			this.pledgesGrid.MainView = this.pledgesView;
			this.pledgesGrid.Name = "pledgesGrid";
			this.pledgesGrid.RegistrationCount = 52;
			this.pledgesGrid.ShowOnlyPredefinedDetails = true;
			this.pledgesGrid.Size = new System.Drawing.Size(493, 284);
			this.pledgesGrid.TabIndex = 0;
			this.pledgesGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.pledgesView});
			// 
			// pledgesView
			// 
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
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colAmount, DevExpress.Data.ColumnSortOrder.Descending)});
			this.pledgesView.CustomSuperTip += new System.EventHandler<ShomreiTorah.Data.UI.Grid.CustomToolTipEventArgs>(this.pledgesView_CustomSuperTip);
			this.pledgesView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.pledgesView_CustomUnboundColumnData);
			this.pledgesView.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.pledgesView_CustomColumnDisplayText);
			// 
			// colDate
			// 
			this.colDate.FieldName = "Date";
			this.colDate.Name = "colDate";
			this.colDate.Visible = true;
			this.colDate.VisibleIndex = 0;
			this.colDate.Width = 51;
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
			this.colSubType.Caption = "Subtype";
			this.colSubType.FieldName = "SubType";
			this.colSubType.Name = "colSubType";
			this.colSubType.Visible = true;
			this.colSubType.VisibleIndex = 2;
			this.colSubType.Width = 59;
			// 
			// colAmount
			// 
			this.colAmount.Caption = "Unpaid";
			this.colAmount.MaxWidth = 85;
			this.colAmount.Name = "colAmount";
			this.colAmount.OptionsColumn.ReadOnly = true;
			this.colAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:c} Total unpaid pledges")});
			this.colAmount.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
			this.colAmount.Visible = true;
			this.colAmount.VisibleIndex = 3;
			this.colAmount.Width = 65;
			// 
			// colNote
			// 
			this.colNote.FieldName = "Note";
			this.colNote.Name = "colNote";
			this.colNote.Visible = true;
			this.colNote.VisibleIndex = 4;
			this.colNote.Width = 42;
			// 
			// colComments
			// 
			this.colComments.FieldName = "Comments";
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
			this.colModified.Width = 100;
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
			this.colLinkAmount.MaxWidth = 85;
			this.colLinkAmount.Name = "colLinkAmount";
			this.colLinkAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "", "{0:c} Total Pledged")});
			this.colLinkAmount.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
			this.colLinkAmount.Visible = true;
			this.colLinkAmount.VisibleIndex = 6;
			this.colLinkAmount.Width = 42;
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
			// PledgeLinksEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pledgesGrid);
			this.Name = "PledgeLinksEdit";
			this.Size = new System.Drawing.Size(493, 284);
			((System.ComponentModel.ISupportInitialize)(this.pledgesGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgesView)).EndInit();
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

	}
}
