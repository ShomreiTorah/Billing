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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatementLogViewer));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
			this.grid = new ShomreiTorah.Billing.Controls.BaseGrid(this.components);
			this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.personRefEdit = new Controls.Editors.RepositoryItemPersonRefEdit();
			this.colDateGenerated = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colMedia = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colStatementKind = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.personRefEdit)).BeginInit();
			this.SuspendLayout();
			// 
			// grid
			// 
			this.grid.DataMember = "StatementLog";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 142);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.Size = new System.Drawing.Size(515, 280);
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
			this.colFullName.ColumnEdit = this.personRefEdit;
			this.colFullName.FieldName = "FullName";
			this.colFullName.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical;
			this.colFullName.Name = "colFullName";
			this.colFullName.OptionsColumn.ReadOnly = true;
			this.colFullName.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colFullName.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
			this.colFullName.Visible = true;
			this.colFullName.VisibleIndex = 0;
			this.colFullName.Width = 63;
			// 
			// personRefEdit
			// 
			this.personRefEdit.AutoHeight = false;
			this.personRefEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("personRefEdit.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Show Person", null, null, true)});
			this.personRefEdit.Name = "personRefEdit";
			this.personRefEdit.ReadOnly = true;
			this.personRefEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
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
			this.colDateGenerated.Width = 195;
			// 
			// colMedia
			// 
			this.colMedia.FieldName = "Media";
			this.colMedia.Name = "colMedia";
			this.colMedia.OptionsColumn.AllowEdit = false;
			this.colMedia.OptionsColumn.AllowFocus = false;
			this.colMedia.Width = 40;
			// 
			// colStatementKind
			// 
			this.colStatementKind.FieldName = "StatementKind";
			this.colStatementKind.Name = "colStatementKind";
			this.colStatementKind.OptionsColumn.AllowEdit = false;
			this.colStatementKind.OptionsColumn.AllowFocus = false;
			this.colStatementKind.Visible = true;
			this.colStatementKind.VisibleIndex = 2;
			this.colStatementKind.Width = 88;
			// 
			// colStartDate
			// 
			this.colStartDate.FieldName = "StartDate";
			this.colStartDate.Name = "colStartDate";
			this.colStartDate.OptionsColumn.AllowEdit = false;
			this.colStartDate.OptionsColumn.AllowFocus = false;
			this.colStartDate.Visible = true;
			this.colStartDate.VisibleIndex = 3;
			this.colStartDate.Width = 66;
			// 
			// colEndDate
			// 
			this.colEndDate.FieldName = "EndDate";
			this.colEndDate.Name = "colEndDate";
			this.colEndDate.OptionsColumn.AllowEdit = false;
			this.colEndDate.OptionsColumn.AllowFocus = false;
			this.colEndDate.Visible = true;
			this.colEndDate.VisibleIndex = 4;
			this.colEndDate.Width = 61;
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
			this.colUserName.Width = 71;
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
			this.Controls.SetChildIndex(this.grid, 0);
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.personRefEdit)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.BaseGrid grid;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView;
		private DevExpress.XtraGrid.Columns.GridColumn colFullName;
		private Controls.Editors.RepositoryItemPersonRefEdit personRefEdit;
		private DevExpress.XtraGrid.Columns.GridColumn colDateGenerated;
		private DevExpress.XtraGrid.Columns.GridColumn colMedia;
		private DevExpress.XtraGrid.Columns.GridColumn colStatementKind;
		private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
		private DevExpress.XtraGrid.Columns.GridColumn colEndDate;
		private DevExpress.XtraGrid.Columns.GridColumn colUserName;
	}
}