namespace ShomreiTorah.Billing.Controls {
	partial class ModifiedPledgesGrid {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifiedPledgesGrid));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
			this.grid = new ShomreiTorah.Billing.Controls.BaseGrid(this.components);
			this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.personRefEdit = new Controls.Editors.RepositoryItemPersonRefEdit();
			this.colDate1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSubType = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAccount1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAmount1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colComments1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colModified1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colModifier1 = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.personRefEdit)).BeginInit();
			this.SuspendLayout();
			// 
			// grid
			// 
			this.grid.DataMember = "Pledges";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 0);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.Size = new System.Drawing.Size(669, 406);
			this.grid.TabIndex = 2;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFullName,
            this.colDate1,
            this.colType,
            this.colSubType,
            this.colAccount1,
            this.colAmount1,
            this.colNote,
            this.colComments1,
            this.colModified1,
            this.colModifier1});
			this.gridView.GridControl = this.grid;
			this.gridView.Name = "gridView";
			this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
			this.gridView.OptionsView.ShowFooter = true;
			this.gridView.OptionsView.ShowGroupPanel = false;
			this.gridView.OptionsView.ShowIndicator = false;
			this.gridView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
			this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colModified1, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// colFullName
			// 
			this.colFullName.ColumnEdit = this.personRefEdit;
			this.colFullName.FieldName = "Person";
			this.colFullName.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical;
			this.colFullName.Name = "colFullName";
			this.colFullName.OptionsColumn.ReadOnly = true;
			this.colFullName.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colFullName.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
			this.colFullName.SummaryItem.DisplayFormat = "{0} Pledges";
			this.colFullName.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
			this.colFullName.Visible = true;
			this.colFullName.VisibleIndex = 0;
			// 
			// personRefEdit
			// 
			this.personRefEdit.AutoHeight = false;
			this.personRefEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("personRefEdit.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Show Person", null, null, true)});
			this.personRefEdit.Name = "personRefEdit";
			this.personRefEdit.ReadOnly = true;
			this.personRefEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			// 
			// colDate1
			// 
			this.colDate1.FieldName = "Date";
			this.colDate1.Name = "colDate1";
			this.colDate1.OptionsColumn.AllowEdit = false;
			this.colDate1.OptionsColumn.AllowFocus = false;
			this.colDate1.OptionsColumn.ReadOnly = true;
			this.colDate1.Visible = true;
			this.colDate1.VisibleIndex = 1;
			// 
			// colType
			// 
			this.colType.FieldName = "Type";
			this.colType.Name = "colType";
			this.colType.OptionsColumn.AllowEdit = false;
			this.colType.OptionsColumn.AllowFocus = false;
			this.colType.OptionsColumn.ReadOnly = true;
			this.colType.Visible = true;
			this.colType.VisibleIndex = 2;
			// 
			// colSubType
			// 
			this.colSubType.FieldName = "SubType";
			this.colSubType.Name = "colSubType";
			this.colSubType.OptionsColumn.AllowEdit = false;
			this.colSubType.OptionsColumn.AllowFocus = false;
			this.colSubType.OptionsColumn.ReadOnly = true;
			this.colSubType.Visible = true;
			this.colSubType.VisibleIndex = 3;
			// 
			// colAccount1
			// 
			this.colAccount1.FieldName = "Account";
			this.colAccount1.Name = "colAccount1";
			this.colAccount1.OptionsColumn.AllowEdit = false;
			this.colAccount1.OptionsColumn.AllowFocus = false;
			this.colAccount1.OptionsColumn.ReadOnly = true;
			this.colAccount1.Visible = true;
			this.colAccount1.VisibleIndex = 4;
			// 
			// colAmount1
			// 
			this.colAmount1.DisplayFormat.FormatString = "c";
			this.colAmount1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colAmount1.FieldName = "Amount";
			this.colAmount1.Name = "colAmount1";
			this.colAmount1.OptionsColumn.AllowEdit = false;
			this.colAmount1.OptionsColumn.AllowFocus = false;
			this.colAmount1.OptionsColumn.ReadOnly = true;
			this.colAmount1.SummaryItem.DisplayFormat = "{0:c} Pledged Added";
			this.colAmount1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.colAmount1.Visible = true;
			this.colAmount1.VisibleIndex = 5;
			// 
			// colNote
			// 
			this.colNote.FieldName = "Note";
			this.colNote.Name = "colNote";
			this.colNote.OptionsColumn.AllowEdit = false;
			this.colNote.OptionsColumn.AllowFocus = false;
			this.colNote.OptionsColumn.ReadOnly = true;
			this.colNote.Visible = true;
			this.colNote.VisibleIndex = 6;
			// 
			// colComments1
			// 
			this.colComments1.FieldName = "Comments";
			this.colComments1.Name = "colComments1";
			this.colComments1.OptionsColumn.AllowEdit = false;
			this.colComments1.OptionsColumn.AllowFocus = false;
			this.colComments1.OptionsColumn.ReadOnly = true;
			this.colComments1.Visible = true;
			this.colComments1.VisibleIndex = 7;
			// 
			// colModified1
			// 
			this.colModified1.DisplayFormat.FormatString = "g";
			this.colModified1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colModified1.FieldName = "Modified";
			this.colModified1.Name = "colModified1";
			this.colModified1.OptionsColumn.AllowEdit = false;
			this.colModified1.OptionsColumn.AllowFocus = false;
			this.colModified1.OptionsColumn.ReadOnly = true;
			// 
			// colModifier1
			// 
			this.colModifier1.FieldName = "Modifier";
			this.colModifier1.Name = "colModifier1";
			this.colModifier1.OptionsColumn.AllowEdit = false;
			this.colModifier1.OptionsColumn.AllowFocus = false;
			this.colModifier1.OptionsColumn.ReadOnly = true;
			// 
			// ModifiedPledgesGrid
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.grid);
			this.Name = "ModifiedPledgesGrid";
			this.Size = new System.Drawing.Size(669, 406);
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.personRefEdit)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private BaseGrid grid;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView;
		private DevExpress.XtraGrid.Columns.GridColumn colFullName;
		private DevExpress.XtraGrid.Columns.GridColumn colDate1;
		private DevExpress.XtraGrid.Columns.GridColumn colType;
		private DevExpress.XtraGrid.Columns.GridColumn colSubType;
		private DevExpress.XtraGrid.Columns.GridColumn colAccount1;
		private DevExpress.XtraGrid.Columns.GridColumn colAmount1;
		private DevExpress.XtraGrid.Columns.GridColumn colNote;
		private DevExpress.XtraGrid.Columns.GridColumn colComments1;
		private DevExpress.XtraGrid.Columns.GridColumn colModified1;
		private DevExpress.XtraGrid.Columns.GridColumn colModifier1;
		private Controls.Editors.RepositoryItemPersonRefEdit personRefEdit;
	}
}
