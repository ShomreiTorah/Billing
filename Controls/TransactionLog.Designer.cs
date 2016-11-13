namespace ShomreiTorah.Billing.Controls {
	partial class TransactionLog {
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
			DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
			DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
			DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
			DevExpress.XtraCharts.AreaSeriesView areaSeriesView1 = new DevExpress.XtraCharts.AreaSeriesView();
			DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel2 = new DevExpress.XtraCharts.PointSeriesLabel();
			DevExpress.XtraCharts.AreaSeriesView areaSeriesView2 = new DevExpress.XtraCharts.AreaSeriesView();
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.chartControl = new DevExpress.XtraCharts.ChartControl();
			this.gridControl = new DevExpress.XtraGrid.GridControl();
			this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chartControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(areaSeriesView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(areaSeriesView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
			this.splitContainerControl1.Horizontal = false;
			this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.Controls.Add(this.chartControl);
			this.splitContainerControl1.Panel1.Text = "Panel1";
			this.splitContainerControl1.Panel2.Controls.Add(this.gridControl);
			this.splitContainerControl1.Panel2.Text = "Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(591, 620);
			this.splitContainerControl1.SplitterPosition = 201;
			this.splitContainerControl1.TabIndex = 0;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// chartControl
			// 
			xyDiagram1.AxisX.WholeRange.AutoSideMargins = false;
			xyDiagram1.AxisX.VisualRange.AutoSideMargins = false;
			xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
			xyDiagram1.AxisY.Label.TextPattern = "{V:C}";
			xyDiagram1.AxisY.WholeRange.AutoSideMargins = true;
			xyDiagram1.AxisY.VisualRange.AutoSideMargins = true;
			xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
			this.chartControl.Diagram = xyDiagram1;
			this.chartControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chartControl.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
			this.chartControl.Location = new System.Drawing.Point(0, 0);
			this.chartControl.Name = "chartControl";
			series1.ArgumentDataMember = "Date";
			series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.DateTime;
			series1.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.True;
			series1.CrosshairLabelPattern = "{A:D} {HINT}\r\nBalance: {V:c}\r\n";
			pointSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
			pointSeriesLabel1.TextPattern = "{A} {V:C}";
			series1.Label = pointSeriesLabel1;
			series1.Name = "Balance";
			series1.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;
			series1.ToolTipHintDataMember = "Description";
			series1.ToolTipPointPattern = "{A:D}\r\n{HINT}\r\nBalance: {V:c}";
			series1.ValueDataMembersSerializable = "RunningBalance";
			series1.View = areaSeriesView1;
			this.chartControl.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
		series1};
			pointSeriesLabel2.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
			this.chartControl.SeriesTemplate.Label = pointSeriesLabel2;
			areaSeriesView2.Transparency = ((byte)(0));
			this.chartControl.SeriesTemplate.View = areaSeriesView2;
			this.chartControl.Size = new System.Drawing.Size(591, 201);
			this.chartControl.TabIndex = 0;
			// 
			// gridControl
			// 
			this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridControl.Location = new System.Drawing.Point(0, 0);
			this.gridControl.MainView = this.gridView;
			this.gridControl.Name = "gridControl";
			this.gridControl.Size = new System.Drawing.Size(591, 413);
			this.gridControl.TabIndex = 0;
			this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
			this.gridView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
			this.gridColumn1,
			this.gridColumn2,
			this.gridColumn3,
			this.gridColumn4});
			this.gridView.GridControl = this.gridControl;
			this.gridView.Name = "gridView";
			this.gridView.OptionsBehavior.Editable = false;
			this.gridView.OptionsBehavior.ReadOnly = true;
			this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Date";
			this.gridColumn1.FieldName = "Date";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Description";
			this.gridColumn2.FieldName = "Description";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Transaction Amount";
			this.gridColumn3.DisplayFormat.FormatString = "c";
			this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn3.FieldName = "Amount";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			// 
			// gridColumn4
			// 
			this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.gridColumn4.AppearanceCell.Options.UseFont = true;
			this.gridColumn4.Caption = "Balance";
			this.gridColumn4.DisplayFormat.FormatString = "c";
			this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn4.FieldName = "RunningBalance";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 3;
			// 
			// TransactionLog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainerControl1);
			this.Name = "TransactionLog";
			this.Size = new System.Drawing.Size(591, 620);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(areaSeriesView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(areaSeriesView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chartControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
		private DevExpress.XtraCharts.ChartControl chartControl;
		private DevExpress.XtraGrid.GridControl gridControl;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
	}
}
