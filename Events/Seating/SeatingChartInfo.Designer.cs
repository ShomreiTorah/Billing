namespace ShomreiTorah.Billing.Events.Seating {
	partial class SeatingChartInfo {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeatingChartInfo));
			this.grid = new DevExpress.XtraGrid.GridControl();
			this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSeatCount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colMessage = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			this.SuspendLayout();
			// 
			// grid
			// 
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 0);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.Size = new System.Drawing.Size(690, 401);
			this.grid.TabIndex = 0;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colSeatCount,
            this.colMessage});
			this.gridView.GridControl = this.grid;
			this.gridView.GroupCount = 1;
			this.gridView.Name = "gridView";
			this.gridView.OptionsBehavior.AutoExpandAllGroups = true;
			this.gridView.OptionsView.ShowGroupedColumns = true;
			this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMessage, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colName, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.gridView.CustomColumnSort += new DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler(this.gridView_CustomColumnSort);
			// 
			// colName
			// 
			this.colName.Caption = "Name";
			this.colName.FieldName = "Name";
			this.colName.Name = "colName";
			this.colName.OptionsColumn.AllowEdit = false;
			this.colName.OptionsColumn.AllowFocus = false;
			this.colName.OptionsColumn.ReadOnly = true;
			this.colName.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
			this.colName.Visible = true;
			this.colName.VisibleIndex = 0;
			this.colName.Width = 73;
			// 
			// colSeatCount
			// 
			this.colSeatCount.Caption = "# Seats";
			this.colSeatCount.FieldName = "SeatCount";
			this.colSeatCount.MinWidth = 45;
			this.colSeatCount.Name = "colSeatCount";
			this.colSeatCount.OptionsColumn.AllowEdit = false;
			this.colSeatCount.OptionsColumn.AllowFocus = false;
			this.colSeatCount.OptionsColumn.ReadOnly = true;
			this.colSeatCount.Visible = true;
			this.colSeatCount.VisibleIndex = 1;
			this.colSeatCount.Width = 53;
			// 
			// colMessage
			// 
			this.colMessage.Caption = "Problem";
			this.colMessage.FieldName = "Message";
			this.colMessage.Name = "colMessage";
			this.colMessage.OptionsColumn.AllowEdit = false;
			this.colMessage.OptionsColumn.AllowFocus = false;
			this.colMessage.OptionsColumn.ReadOnly = true;
			this.colMessage.Visible = true;
			this.colMessage.VisibleIndex = 2;
			this.colMessage.Width = 543;
			// 
			// SeatingChartInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(690, 401);
			this.Controls.Add(this.grid);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SeatingChartInfo";
			this.Text = "Seating Chart Warnings";
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraGrid.GridControl grid;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView;
		private DevExpress.XtraGrid.Columns.GridColumn colName;
		private DevExpress.XtraGrid.Columns.GridColumn colSeatCount;
		private DevExpress.XtraGrid.Columns.GridColumn colMessage;
	}
}