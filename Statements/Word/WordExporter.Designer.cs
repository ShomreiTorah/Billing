namespace ShomreiTorah.Billing.Statements.Word {
	partial class WordExporter {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WordExporter));
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
			this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.grid = new DevExpress.XtraGrid.GridControl();
			this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colIsChecked = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colHisName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colHerName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTotalPaid = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colBalanceDue = new DevExpress.XtraGrid.Columns.GridColumn();
			this.cancel = new DevExpress.XtraEditors.SimpleButton();
			this.createDoc = new DevExpress.XtraEditors.DropDownButton();
			this.mailingDocuments = new DevExpress.XtraBars.PopupMenu(this.components);
			this.barManager = new DevExpress.XtraBars.BarManager(this.components);
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.duplexMode = new DevExpress.XtraEditors.CheckEdit();
			this.label = new DevExpress.XtraEditors.LabelControl();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mailingDocuments)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.duplexMode.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// repositoryItemCheckEdit1
			// 
			this.repositoryItemCheckEdit1.AutoHeight = false;
			this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
			this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// grid
			// 
			this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grid.Location = new System.Drawing.Point(12, 31);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.ShowOnlyPredefinedDetails = true;
			this.grid.Size = new System.Drawing.Size(563, 271);
			this.grid.TabIndex = 16;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIsChecked,
            this.colLastName,
            this.colHisName,
            this.colHerName,
            this.colAddress,
            this.colTotalPaid,
            this.colBalanceDue});
			this.gridView.GridControl = this.grid;
			this.gridView.Name = "gridView";
			this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView.OptionsSelection.MultiSelect = true;
			this.gridView.OptionsView.ShowGroupPanel = false;
			this.gridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLastName, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.gridView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView_CustomUnboundColumnData);
			// 
			// colIsChecked
			// 
			this.colIsChecked.Caption = " ";
			this.colIsChecked.ColumnEdit = this.repositoryItemCheckEdit1;
			this.colIsChecked.FieldName = "IsChecked";
			this.colIsChecked.MaxWidth = 22;
			this.colIsChecked.MinWidth = 22;
			this.colIsChecked.Name = "colIsChecked";
			this.colIsChecked.OptionsColumn.AllowMove = false;
			this.colIsChecked.OptionsColumn.AllowShowHide = false;
			this.colIsChecked.OptionsColumn.AllowSize = false;
			this.colIsChecked.OptionsColumn.FixedWidth = true;
			this.colIsChecked.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colIsChecked.ToolTip = "Generate?";
			this.colIsChecked.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
			this.colIsChecked.Visible = true;
			this.colIsChecked.VisibleIndex = 0;
			this.colIsChecked.Width = 22;
			// 
			// colLastName
			// 
			this.colLastName.FieldName = "LastName";
			this.colLastName.Name = "colLastName";
			this.colLastName.OptionsColumn.AllowEdit = false;
			this.colLastName.OptionsColumn.ReadOnly = true;
			this.colLastName.Visible = true;
			this.colLastName.VisibleIndex = 1;
			this.colLastName.Width = 87;
			// 
			// colHisName
			// 
			this.colHisName.FieldName = "HisName";
			this.colHisName.Name = "colHisName";
			this.colHisName.OptionsColumn.AllowEdit = false;
			this.colHisName.OptionsColumn.ReadOnly = true;
			this.colHisName.Visible = true;
			this.colHisName.VisibleIndex = 2;
			this.colHisName.Width = 87;
			// 
			// colHerName
			// 
			this.colHerName.FieldName = "HerName";
			this.colHerName.Name = "colHerName";
			this.colHerName.OptionsColumn.AllowEdit = false;
			this.colHerName.OptionsColumn.ReadOnly = true;
			this.colHerName.Visible = true;
			this.colHerName.VisibleIndex = 3;
			this.colHerName.Width = 87;
			// 
			// colAddress
			// 
			this.colAddress.FieldName = "Address";
			this.colAddress.Name = "colAddress";
			this.colAddress.OptionsColumn.AllowEdit = false;
			this.colAddress.OptionsColumn.ReadOnly = true;
			this.colAddress.Visible = true;
			this.colAddress.VisibleIndex = 4;
			this.colAddress.Width = 87;
			// 
			// colTotalPaid
			// 
			this.colTotalPaid.DisplayFormat.FormatString = "c";
			this.colTotalPaid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colTotalPaid.FieldName = "TotalPaid";
			this.colTotalPaid.Name = "colTotalPaid";
			this.colTotalPaid.OptionsColumn.AllowEdit = false;
			this.colTotalPaid.OptionsColumn.ReadOnly = true;
			this.colTotalPaid.Visible = true;
			this.colTotalPaid.VisibleIndex = 5;
			this.colTotalPaid.Width = 87;
			// 
			// colBalanceDue
			// 
			this.colBalanceDue.DisplayFormat.FormatString = "c";
			this.colBalanceDue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colBalanceDue.FieldName = "BalanceDue";
			this.colBalanceDue.Name = "colBalanceDue";
			this.colBalanceDue.OptionsColumn.AllowEdit = false;
			this.colBalanceDue.OptionsColumn.ReadOnly = true;
			this.colBalanceDue.Visible = true;
			this.colBalanceDue.VisibleIndex = 6;
			this.colBalanceDue.Width = 109;
			// 
			// cancel
			// 
			this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(501, 308);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 15;
			this.cancel.Text = "Cancel";
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// createDoc
			// 
			this.createDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.createDoc.DropDownControl = this.mailingDocuments;
			this.createDoc.Location = new System.Drawing.Point(360, 308);
			this.createDoc.Name = "createDoc";
			this.createDoc.Size = new System.Drawing.Size(135, 23);
			this.createDoc.TabIndex = 17;
			this.createDoc.Text = "&Create Document";
			this.createDoc.Click += new System.EventHandler(this.createDoc_Click);
			// 
			// mailingDocuments
			// 
			this.mailingDocuments.Manager = this.barManager;
			this.mailingDocuments.Name = "mailingDocuments";
			// 
			// barManager
			// 
			this.barManager.DockControls.Add(this.barDockControlTop);
			this.barManager.DockControls.Add(this.barDockControlBottom);
			this.barManager.DockControls.Add(this.barDockControlLeft);
			this.barManager.DockControls.Add(this.barDockControlRight);
			this.barManager.Form = this;
			this.barManager.MaxItemId = 0;
			// 
			// barDockControlTop
			// 
			this.barDockControlTop.CausesValidation = false;
			this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
			this.barDockControlTop.Size = new System.Drawing.Size(588, 0);
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.barDockControlBottom.Location = new System.Drawing.Point(0, 343);
			this.barDockControlBottom.Size = new System.Drawing.Size(588, 0);
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
			this.barDockControlLeft.Size = new System.Drawing.Size(0, 343);
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.barDockControlRight.Location = new System.Drawing.Point(588, 0);
			this.barDockControlRight.Size = new System.Drawing.Size(0, 343);
			// 
			// duplexMode
			// 
			this.duplexMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.duplexMode.EditValue = true;
			this.duplexMode.Location = new System.Drawing.Point(166, 309);
			this.duplexMode.Name = "duplexMode";
			this.duplexMode.Properties.AutoWidth = true;
			this.duplexMode.Properties.Caption = "Generate for &double-sided printing";
			this.duplexMode.Size = new System.Drawing.Size(188, 19);
			toolTipTitleItem1.Text = "Duplex Mode";
			toolTipItem1.LeftIndent = 6;
			toolTipItem1.Text = resources.GetString("toolTipItem1.Text");
			toolTipTitleItem2.LeftIndent = 6;
			toolTipTitleItem2.Text = "This does not affect envelopes or labels";
			superToolTip1.Items.Add(toolTipTitleItem1);
			superToolTip1.Items.Add(toolTipItem1);
			superToolTip1.Items.Add(toolTipTitleItem2);
			this.duplexMode.SuperTip = superToolTip1;
			this.duplexMode.TabIndex = 22;
			// 
			// label
			// 
			this.label.AutoEllipsis = true;
			this.label.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
			this.label.Location = new System.Drawing.Point(12, 12);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(63, 13);
			this.label.TabIndex = 27;
			this.label.Text = "labelControl1";
			// 
			// WordExporter
			// 
			this.AcceptButton = this.createDoc;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(588, 343);
			this.Controls.Add(this.label);
			this.Controls.Add(this.duplexMode);
			this.Controls.Add(this.createDoc);
			this.Controls.Add(this.grid);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "WordExporter";
			this.Text = "Create Word Statements";
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mailingDocuments)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.duplexMode.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraGrid.Columns.GridColumn colHerName;
		private DevExpress.XtraGrid.Columns.GridColumn colAddress;
		private DevExpress.XtraGrid.Columns.GridColumn colHisName;
		private DevExpress.XtraGrid.Columns.GridColumn colTotalPaid;
		private DevExpress.XtraGrid.Columns.GridColumn colBalanceDue;
		private DevExpress.XtraGrid.Columns.GridColumn colLastName;
		private DevExpress.XtraGrid.GridControl grid;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView;
		private DevExpress.XtraEditors.SimpleButton cancel;
		private DevExpress.XtraEditors.DropDownButton createDoc;
		private DevExpress.XtraBars.PopupMenu mailingDocuments;
		private DevExpress.XtraBars.BarManager barManager;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private DevExpress.XtraEditors.CheckEdit duplexMode;
		private DevExpress.XtraGrid.Columns.GridColumn colIsChecked;
		private DevExpress.XtraEditors.LabelControl label;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
	}
}