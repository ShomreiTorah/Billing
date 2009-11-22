namespace ShomreiTorah.Billing.Import {
	partial class YKImporter {
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
			DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
			DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
			DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
			DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition4 = new DevExpress.XtraGrid.StyleFormatCondition();
			DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition5 = new DevExpress.XtraGrid.StyleFormatCondition();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YKImporter));
			this.colMatchState = new DevExpress.XtraGrid.Columns.GridColumn();
			this.grid = new DevExpress.XtraGrid.GridControl();
			this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colYKID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colHisName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colHerName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCity = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colState = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colZip = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPhone = new DevExpress.XtraGrid.Columns.GridColumn();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.ykDetails = new DevExpress.XtraEditors.MemoEdit();
			this.mdDetails = new DevExpress.XtraEditors.MemoEdit();
			this.doImport = new DevExpress.XtraEditors.SimpleButton();
			this.cancel = new DevExpress.XtraEditors.SimpleButton();
			this.colAction = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ykDetails.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mdDetails.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// colMatchState
			// 
			this.colMatchState.Caption = "Match State";
			this.colMatchState.FieldName = "MatchState";
			this.colMatchState.Name = "colMatchState";
			this.colMatchState.OptionsColumn.AllowEdit = false;
			// 
			// grid
			// 
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 0);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.Size = new System.Drawing.Size(779, 538);
			this.grid.TabIndex = 0;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colYKID,
            this.colLastName,
            this.colHisName,
            this.colHerName,
            this.colFullName,
            this.colAddress,
            this.colCity,
            this.colState,
            this.colZip,
            this.colPhone,
            this.colAction,
            this.colMatchState});
			styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			styleFormatCondition1.Appearance.Options.UseBackColor = true;
			styleFormatCondition1.ApplyToRow = true;
			styleFormatCondition1.Column = this.colMatchState;
			styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
			styleFormatCondition1.Value1 = 0;
			styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			styleFormatCondition2.Appearance.Options.UseBackColor = true;
			styleFormatCondition2.ApplyToRow = true;
			styleFormatCondition2.Column = this.colMatchState;
			styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
			styleFormatCondition2.Value1 = 1;
			styleFormatCondition3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			styleFormatCondition3.Appearance.Options.UseBackColor = true;
			styleFormatCondition3.ApplyToRow = true;
			styleFormatCondition3.Column = this.colMatchState;
			styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
			styleFormatCondition3.Value1 = 2;
			styleFormatCondition4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			styleFormatCondition4.Appearance.Options.UseBackColor = true;
			styleFormatCondition4.ApplyToRow = true;
			styleFormatCondition4.Column = this.colMatchState;
			styleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
			styleFormatCondition4.Value1 = 3;
			styleFormatCondition5.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			styleFormatCondition5.Appearance.Options.UseBackColor = true;
			styleFormatCondition5.ApplyToRow = true;
			styleFormatCondition5.Column = this.colMatchState;
			styleFormatCondition5.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
			styleFormatCondition5.Value1 = 4;
			this.gridView.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2,
            styleFormatCondition3,
            styleFormatCondition4,
            styleFormatCondition5});
			this.gridView.GridControl = this.grid;
			this.gridView.GroupCount = 1;
			this.gridView.GroupFormat = "[#image]{1} ({2})";
			this.gridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", null, "{0} people")});
			this.gridView.Name = "gridView";
			this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
			this.gridView.OptionsView.ShowGroupPanel = false;
			this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMatchState, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.gridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
			this.gridView.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView_CustomColumnDisplayText);
			// 
			// colId
			// 
			this.colId.FieldName = "Id";
			this.colId.Name = "colId";
			// 
			// colYKID
			// 
			this.colYKID.FieldName = "YKID";
			this.colYKID.Name = "colYKID";
			this.colYKID.OptionsColumn.AllowEdit = false;
			this.colYKID.Visible = true;
			this.colYKID.VisibleIndex = 0;
			// 
			// colLastName
			// 
			this.colLastName.FieldName = "LastName";
			this.colLastName.Name = "colLastName";
			this.colLastName.Visible = true;
			this.colLastName.VisibleIndex = 1;
			// 
			// colHisName
			// 
			this.colHisName.FieldName = "HisName";
			this.colHisName.Name = "colHisName";
			this.colHisName.Visible = true;
			this.colHisName.VisibleIndex = 2;
			// 
			// colHerName
			// 
			this.colHerName.FieldName = "HerName";
			this.colHerName.Name = "colHerName";
			this.colHerName.Visible = true;
			this.colHerName.VisibleIndex = 3;
			// 
			// colFullName
			// 
			this.colFullName.FieldName = "FullName";
			this.colFullName.Name = "colFullName";
			this.colFullName.Visible = true;
			this.colFullName.VisibleIndex = 4;
			// 
			// colAddress
			// 
			this.colAddress.FieldName = "Address";
			this.colAddress.Name = "colAddress";
			this.colAddress.Visible = true;
			this.colAddress.VisibleIndex = 5;
			// 
			// colCity
			// 
			this.colCity.FieldName = "City";
			this.colCity.Name = "colCity";
			this.colCity.Visible = true;
			this.colCity.VisibleIndex = 6;
			// 
			// colState
			// 
			this.colState.FieldName = "State";
			this.colState.Name = "colState";
			this.colState.Visible = true;
			this.colState.VisibleIndex = 7;
			// 
			// colZip
			// 
			this.colZip.FieldName = "Zip";
			this.colZip.Name = "colZip";
			this.colZip.Visible = true;
			this.colZip.VisibleIndex = 8;
			// 
			// colPhone
			// 
			this.colPhone.FieldName = "Phone";
			this.colPhone.Name = "colPhone";
			this.colPhone.Visible = true;
			this.colPhone.VisibleIndex = 9;
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.labelControl2);
			this.panelControl1.Controls.Add(this.labelControl1);
			this.panelControl1.Controls.Add(this.ykDetails);
			this.panelControl1.Controls.Add(this.mdDetails);
			this.panelControl1.Controls.Add(this.doImport);
			this.panelControl1.Controls.Add(this.cancel);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panelControl1.Location = new System.Drawing.Point(779, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(243, 538);
			this.panelControl1.TabIndex = 1;
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(7, 158);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(99, 13);
			this.labelControl2.TabIndex = 4;
			this.labelControl2.Text = "New details from YK:";
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(6, 13);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(75, 13);
			this.labelControl1.TabIndex = 3;
			this.labelControl1.Text = "Current details:";
			// 
			// ykDetails
			// 
			this.ykDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ykDetails.Location = new System.Drawing.Point(6, 177);
			this.ykDetails.Name = "ykDetails";
			this.ykDetails.Properties.ReadOnly = true;
			this.ykDetails.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.ykDetails.Size = new System.Drawing.Size(225, 110);
			this.ykDetails.TabIndex = 2;
			// 
			// mdDetails
			// 
			this.mdDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.mdDetails.Location = new System.Drawing.Point(6, 32);
			this.mdDetails.Name = "mdDetails";
			this.mdDetails.Properties.ReadOnly = true;
			this.mdDetails.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.mdDetails.Size = new System.Drawing.Size(225, 110);
			this.mdDetails.TabIndex = 2;
			// 
			// doImport
			// 
			this.doImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.doImport.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.doImport.Location = new System.Drawing.Point(15, 503);
			this.doImport.Name = "doImport";
			this.doImport.Size = new System.Drawing.Size(135, 23);
			this.doImport.TabIndex = 1;
			this.doImport.Text = "Update Master Directory";
			this.doImport.Click += new System.EventHandler(this.doImport_Click);
			// 
			// cancel
			// 
			this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(156, 503);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 0;
			this.cancel.Text = "Cancel";
			// 
			// colAction
			// 
			this.colAction.Caption = "Action";
			this.colAction.FieldName = "Action";
			this.colAction.Name = "colAction";
			this.colAction.Visible = true;
			this.colAction.VisibleIndex = 10;
			// 
			// YKImporter
			// 
			this.AcceptButton = this.cancel;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.doImport;
			this.ClientSize = new System.Drawing.Size(1022, 538);
			this.Controls.Add(this.grid);
			this.Controls.Add(this.panelControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "YKImporter";
			this.Text = "YK Directory Importer";
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			this.panelControl1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ykDetails.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mdDetails.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraGrid.GridControl grid;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView;
		private DevExpress.XtraGrid.Columns.GridColumn colId;
		private DevExpress.XtraGrid.Columns.GridColumn colYKID;
		private DevExpress.XtraGrid.Columns.GridColumn colLastName;
		private DevExpress.XtraGrid.Columns.GridColumn colHisName;
		private DevExpress.XtraGrid.Columns.GridColumn colHerName;
		private DevExpress.XtraGrid.Columns.GridColumn colFullName;
		private DevExpress.XtraGrid.Columns.GridColumn colAddress;
		private DevExpress.XtraGrid.Columns.GridColumn colCity;
		private DevExpress.XtraGrid.Columns.GridColumn colState;
		private DevExpress.XtraGrid.Columns.GridColumn colZip;
		private DevExpress.XtraGrid.Columns.GridColumn colPhone;
		private DevExpress.XtraGrid.Columns.GridColumn colMatchState;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.SimpleButton doImport;
		private DevExpress.XtraEditors.SimpleButton cancel;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.MemoEdit ykDetails;
		private DevExpress.XtraEditors.MemoEdit mdDetails;
		private DevExpress.XtraGrid.Columns.GridColumn colAction;
	}
}