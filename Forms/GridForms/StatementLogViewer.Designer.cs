namespace ShomreiTorah.Billing.Forms.GridForms {
	partial class StatementLogViewer {
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
			this.grid = new ShomreiTorah.Data.UI.Grid.SmartGrid(this.components);
			this.gridView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colFullName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colDateGenerated = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colMedia = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colStatementKind = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colStartDate = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colEndDate = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colUserName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
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
			// 
			// grid
			// 
			this.grid.DataMember = "StatementLog";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 114);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.RegistrationCount = 38;
			this.grid.Size = new System.Drawing.Size(515, 308);
			this.grid.TabIndex = 1;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFullName,
            this.colDateGenerated,
            this.colMedia,
            this.colStatementKind,
            this.colStartDate,
            this.colEndDate,
            this.colUserName});
			this.gridView.GridControl = this.grid;
			this.gridView.Name = "gridView";
			this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDateGenerated, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFullName, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// colFullName
			// 
			this.colFullName.Caption = "Full Name";
			this.colFullName.FieldName = "Person";
			this.colFullName.Name = "colFullName";
			this.colFullName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
			this.colFullName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.colFullName.OptionsColumn.ReadOnly = true;
			this.colFullName.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colFullName.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
			this.colFullName.Visible = true;
			this.colFullName.VisibleIndex = 0;
			this.colFullName.Width = 78;
			// 
			// colDateGenerated
			// 
			this.colDateGenerated.DisplayFormat.FormatString = "MMMM d, yyyy, h:mm:ss tt";
			this.colDateGenerated.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colDateGenerated.FieldName = "DateGenerated";
			this.colDateGenerated.Name = "colDateGenerated";
			this.colDateGenerated.OptionsColumn.AllowEdit = false;
			this.colDateGenerated.OptionsColumn.AllowFocus = false;
			this.colDateGenerated.Visible = true;
			this.colDateGenerated.VisibleIndex = 1;
			this.colDateGenerated.Width = 161;
			// 
			// colMedia
			// 
			this.colMedia.FieldName = "Media";
			this.colMedia.Name = "colMedia";
			this.colMedia.OptionsColumn.AllowEdit = false;
			this.colMedia.OptionsColumn.AllowFocus = false;
			this.colMedia.Width = 37;
			// 
			// colStatementKind
			// 
			this.colStatementKind.FieldName = "StatementKind";
			this.colStatementKind.Name = "colStatementKind";
			this.colStatementKind.OptionsColumn.AllowEdit = false;
			this.colStatementKind.OptionsColumn.AllowFocus = false;
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
			this.colEndDate.Visible = true;
			this.colEndDate.VisibleIndex = 4;
			this.colEndDate.Width = 63;
			// 
			// colUserName
			// 
			this.colUserName.Caption = "Generator";
			this.colUserName.FieldName = "UserName";
			this.colUserName.Name = "colUserName";
			this.colUserName.OptionsColumn.AllowEdit = false;
			this.colUserName.OptionsColumn.AllowFocus = false;
			this.colUserName.Visible = true;
			this.colUserName.VisibleIndex = 5;
			this.colUserName.Width = 68;
			// 
			// StatementLogViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(515, 422);
			this.Controls.Add(this.grid);
			this.MainView = this.gridView;
			this.Name = "StatementLogViewer";
			this.Text = "StatementLogViewer";
			this.Controls.SetChildIndex(this.ribbon, 0);
			this.Controls.SetChildIndex(this.grid, 0);
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Data.UI.Grid.SmartGrid grid;
		private Data.UI.Grid.SmartGridView gridView;
		private Data.UI.Grid.SmartGridColumn colFullName;
		
		private Data.UI.Grid.SmartGridColumn colDateGenerated;
		private Data.UI.Grid.SmartGridColumn colMedia;
		private Data.UI.Grid.SmartGridColumn colStatementKind;
		private Data.UI.Grid.SmartGridColumn colStartDate;
		private Data.UI.Grid.SmartGridColumn colEndDate;
		private Data.UI.Grid.SmartGridColumn colUserName;
	}
}