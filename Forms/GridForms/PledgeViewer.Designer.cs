namespace ShomreiTorah.Billing.Forms.GridForms {
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
			this.grid = new ShomreiTorah.Data.UI.Grid.SmartGrid(this.components);
			this.gridView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colFullName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colDate = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colType = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colSubType = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAccount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.accountEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.colAmount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.currencyEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.colNote = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.repositoryItemAliyahNoteEdit1 = new ShomreiTorah.Billing.Controls.Editors.RepositoryItemAliyahNoteEdit();
			this.colComments = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
			this.colModified = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colModifier = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.pledgesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.billingData = new ShomreiTorah.Data.UI.FrameworkBindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.accountEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.currencyEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemAliyahNoteEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.billingData)).BeginInit();
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
			this.ribbon.Size = new System.Drawing.Size(772, 114);
			// 
			// grid
			// 
			this.grid.DataMember = "Pledges";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 114);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.RegistrationCount = 38;
			this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoExEdit1,
            this.repositoryItemAliyahNoteEdit1});
			this.grid.Size = new System.Drawing.Size(772, 445);
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
			this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
			this.gridView.OptionsSelection.MultiSelect = true;
			this.gridView.OptionsView.ShowFooter = true;
			this.gridView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
			this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colModified, DevExpress.Data.ColumnSortOrder.Descending)});
			// 
			// colFullName
			// 
			this.colFullName.Caption = "Full Name";
			this.colFullName.FieldName = "Person";
			this.colFullName.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical;
			this.colFullName.Name = "colFullName";
			this.colFullName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
			this.colFullName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.colFullName.OptionsColumn.ReadOnly = true;
			this.colFullName.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colFullName.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
			this.colFullName.SummaryItem.DisplayFormat = "{0:#,0} Pledges";
			this.colFullName.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
			this.colFullName.Visible = true;
			this.colFullName.VisibleIndex = 0;
			this.colFullName.Width = 71;
			// 
			// colDate
			// 
			this.colDate.FieldName = "Date";
			this.colDate.Name = "colDate";
			this.colDate.Visible = true;
			this.colDate.VisibleIndex = 1;
			this.colDate.Width = 63;
			// 
			// colType
			// 
			this.colType.FieldName = "Type";
			this.colType.Name = "colType";
			this.colType.Visible = true;
			this.colType.VisibleIndex = 2;
			this.colType.Width = 43;
			// 
			// colSubType
			// 
			this.colSubType.FieldName = "SubType";
			this.colSubType.Name = "colSubType";
			this.colSubType.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
			this.colSubType.Visible = true;
			this.colSubType.VisibleIndex = 3;
			this.colSubType.Width = 64;
			// 
			// colAccount
			// 
			this.colAccount.ColumnEditor = this.accountEdit;
			this.colAccount.FieldName = "Account";
			this.colAccount.MaxWidth = 100;
			this.colAccount.Name = "colAccount";
			this.colAccount.Visible = true;
			this.colAccount.VisibleIndex = 4;
			this.colAccount.Width = 58;
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
			this.colAmount.ColumnEditor = this.currencyEdit;
			this.colAmount.DisplayFormat.FormatString = "c";
			this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colAmount.FieldName = "Amount";
			this.colAmount.MaxWidth = 85;
			this.colAmount.Name = "colAmount";
			this.colAmount.SummaryItem.DisplayFormat = "{0:c} Total Pledged";
			this.colAmount.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.colAmount.Visible = true;
			this.colAmount.VisibleIndex = 5;
			this.colAmount.Width = 85;
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
			this.colNote.ColumnEditor = this.repositoryItemAliyahNoteEdit1;
			this.colNote.FieldName = "Note";
			this.colNote.MaxWidth = 300;
			this.colNote.Name = "colNote";
			this.colNote.Visible = true;
			this.colNote.VisibleIndex = 6;
			this.colNote.Width = 42;
			// 
			// repositoryItemAliyahNoteEdit1
			// 
			this.repositoryItemAliyahNoteEdit1.AutoHeight = false;
			this.repositoryItemAliyahNoteEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.repositoryItemAliyahNoteEdit1.Name = "repositoryItemAliyahNoteEdit1";
			// 
			// colComments
			// 
			this.colComments.ColumnEditor = this.repositoryItemMemoExEdit1;
			this.colComments.FieldName = "Comments";
			this.colComments.Name = "colComments";
			this.colComments.Visible = true;
			this.colComments.VisibleIndex = 7;
			this.colComments.Width = 69;
			// 
			// repositoryItemMemoExEdit1
			// 
			this.repositoryItemMemoExEdit1.AutoHeight = false;
			this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
			this.repositoryItemMemoExEdit1.ShowIcon = false;
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
			this.colModified.Width = 112;
			// 
			// colModifier
			// 
			this.colModifier.FieldName = "Modifier";
			this.colModifier.Name = "colModifier";
			this.colModifier.OptionsColumn.AllowEdit = false;
			this.colModifier.OptionsColumn.AllowFocus = false;
			this.colModifier.OptionsColumn.ReadOnly = true;
			this.colModifier.Width = 47;
			// 
			// pledgesBindingSource
			// 
			this.pledgesBindingSource.DataMember = "Pledges";
			this.pledgesBindingSource.DataSource = this.billingData;
			this.pledgesBindingSource.Position = 0;
			// 
			// billingData
			// 
			this.billingData.Position = 0;
			// 
			// PledgeViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(772, 559);
			this.Controls.Add(this.grid);
			this.MainView = this.gridView;
			this.Name = "PledgeViewer";
			this.Text = "All Pledges";
			this.Controls.SetChildIndex(this.ribbon, 0);
			this.Controls.SetChildIndex(this.grid, 0);
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.accountEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.currencyEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemAliyahNoteEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.billingData)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Data.UI.Grid.SmartGrid grid;
		private ShomreiTorah.Data.UI.FrameworkBindingSource billingData;
		private Data.UI.Grid.SmartGridView gridView;
		private System.Windows.Forms.BindingSource pledgesBindingSource;
		private Data.UI.Grid.SmartGridColumn colDate;
		private Data.UI.Grid.SmartGridColumn colType;
		private Data.UI.Grid.SmartGridColumn colSubType;
		private Data.UI.Grid.SmartGridColumn colAmount;
		private Data.UI.Grid.SmartGridColumn colNote;
		private Data.UI.Grid.SmartGridColumn colComments;
		private Data.UI.Grid.SmartGridColumn colFullName;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit currencyEdit;
		private Data.UI.Grid.SmartGridColumn colAccount;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox accountEdit;
		private Data.UI.Grid.SmartGridColumn colModified;
		private Data.UI.Grid.SmartGridColumn colModifier;
		
		private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
		private ShomreiTorah.Billing.Controls.Editors.RepositoryItemAliyahNoteEdit repositoryItemAliyahNoteEdit1;
	}
}