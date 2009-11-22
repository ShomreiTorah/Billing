namespace ShomreiTorah.Billing.Forms {
	partial class PledgeViewer {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PledgeViewer));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
			this.grid = new ShomreiTorah.Billing.Controls.BaseGrid(this.components);
			this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.personRefEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSubType = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAccount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.accountEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.currencyEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colComments = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colModified = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colModifier = new DevExpress.XtraGrid.Columns.GridColumn();
			this.pledgesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.billingData = new ShomreiTorah.Billing.BillingData();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.personRefEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.accountEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.currencyEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.billingData)).BeginInit();
			this.SuspendLayout();
			// 
			// grid
			// 
			this.grid.DataMember = "Pledges";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 0);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.Size = new System.Drawing.Size(772, 559);
			this.grid.TabIndex = 0;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFullName,
            this.colDate,
            this.colType,
            this.colSubType,
            this.colAccount,
            this.colAmount,
            this.colNote,
            this.colComments,
            this.colModified,
            this.colModifier});
			this.gridView.GridControl = this.grid;
			this.gridView.GroupFormat = "{0}: [#image]{1}: {2}";
			this.gridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", null, "{0} Pledges"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", null, "{0:c}")});
			this.gridView.Name = "gridView";
			this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
			this.gridView.OptionsSelection.MultiSelect = true;
			this.gridView.OptionsView.ShowFooter = true;
			this.gridView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
			// 
			// colFullName
			// 
			this.colFullName.ColumnEdit = this.personRefEdit;
			this.colFullName.FieldName = "FullName";
			this.colFullName.Name = "colFullName";
			this.colFullName.OptionsColumn.ReadOnly = true;
			this.colFullName.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colFullName.SummaryItem.DisplayFormat = "{0:#,0} Pledges";
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
			this.personRefEdit.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.personRefEdit_ButtonPressed);
			// 
			// colDate
			// 
			this.colDate.FieldName = "Date";
			this.colDate.Name = "colDate";
			this.colDate.Visible = true;
			this.colDate.VisibleIndex = 1;
			// 
			// colType
			// 
			this.colType.FieldName = "Type";
			this.colType.Name = "colType";
			this.colType.Visible = true;
			this.colType.VisibleIndex = 2;
			// 
			// colSubType
			// 
			this.colSubType.FieldName = "SubType";
			this.colSubType.Name = "colSubType";
			this.colSubType.Visible = true;
			this.colSubType.VisibleIndex = 3;
			// 
			// colAccount
			// 
			this.colAccount.ColumnEdit = this.accountEdit;
			this.colAccount.FieldName = "Account";
			this.colAccount.Name = "colAccount";
			this.colAccount.Visible = true;
			this.colAccount.VisibleIndex = 4;
			// 
			// accountEdit
			// 
			this.accountEdit.AutoHeight = false;
			this.accountEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.accountEdit.DropDownRows = 2;
			this.accountEdit.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Standard;
			this.accountEdit.Items.AddRange(new object[] {
            "Operating Fund",
            "Building Fund"});
			this.accountEdit.Name = "accountEdit";
			// 
			// colAmount
			// 
			this.colAmount.ColumnEdit = this.currencyEdit;
			this.colAmount.FieldName = "Amount";
			this.colAmount.Name = "colAmount";
			this.colAmount.SummaryItem.DisplayFormat = "Total Pledged: {0:c}";
			this.colAmount.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.colAmount.Visible = true;
			this.colAmount.VisibleIndex = 5;
			// 
			// currencyEdit
			// 
			this.currencyEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.currencyEdit.DisplayFormat.FormatString = "c";
			this.currencyEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.currencyEdit.EditFormat.FormatString = "c";
			this.currencyEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.currencyEdit.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.currencyEdit.Mask.EditMask = "c";
			this.currencyEdit.Name = "currencyEdit";
			// 
			// colNote
			// 
			this.colNote.FieldName = "Note";
			this.colNote.Name = "colNote";
			this.colNote.Visible = true;
			this.colNote.VisibleIndex = 6;
			// 
			// colComments
			// 
			this.colComments.FieldName = "Comments";
			this.colComments.Name = "colComments";
			this.colComments.Visible = true;
			this.colComments.VisibleIndex = 7;
			// 
			// colModified
			// 
			this.colModified.DisplayFormat.FormatString = "g";
			this.colModified.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colModified.FieldName = "Modified";
			this.colModified.Name = "colModified";
			this.colModified.OptionsColumn.AllowEdit = false;
			this.colModified.OptionsColumn.AllowFocus = false;
			this.colModified.OptionsColumn.ReadOnly = true;
			// 
			// colModifier
			// 
			this.colModifier.FieldName = "Modifier";
			this.colModifier.Name = "colModifier";
			this.colModifier.OptionsColumn.AllowEdit = false;
			this.colModifier.OptionsColumn.AllowFocus = false;
			this.colModifier.OptionsColumn.ReadOnly = true;
			// 
			// pledgesBindingSource
			// 
			this.pledgesBindingSource.DataMember = "Pledges";
			this.pledgesBindingSource.DataSource = this.billingData;
			// 
			// billingData
			// 
			this.billingData.DataSetName = "BillingData";
			this.billingData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// PledgeViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(772, 559);
			this.Controls.Add(this.grid);
			this.Name = "PledgeViewer";
			this.Text = "All Pledges";
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.personRefEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.accountEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.currencyEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.billingData)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.BaseGrid grid;
		private BillingData billingData;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView;
		private System.Windows.Forms.BindingSource pledgesBindingSource;
		private DevExpress.XtraGrid.Columns.GridColumn colDate;
		private DevExpress.XtraGrid.Columns.GridColumn colType;
		private DevExpress.XtraGrid.Columns.GridColumn colSubType;
		private DevExpress.XtraGrid.Columns.GridColumn colAmount;
		private DevExpress.XtraGrid.Columns.GridColumn colNote;
		private DevExpress.XtraGrid.Columns.GridColumn colComments;
		private DevExpress.XtraGrid.Columns.GridColumn colFullName;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit currencyEdit;
		private DevExpress.XtraGrid.Columns.GridColumn colAccount;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox accountEdit;
		private DevExpress.XtraGrid.Columns.GridColumn colModified;
		private DevExpress.XtraGrid.Columns.GridColumn colModifier;
		private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit personRefEdit;
	}
}