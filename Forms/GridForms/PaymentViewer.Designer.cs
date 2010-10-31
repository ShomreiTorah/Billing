namespace ShomreiTorah.Billing.Forms.GridForms {
	partial class PaymentViewer {
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
			this.colMethod = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.paymentMethodEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.colCheckNumber = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.checkNumberEdit = new Data.UI.Controls.RepositoryItemCheckNumberEdit();
			this.colAccount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.accountEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.colAmount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.currencyEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.colDepositDate = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.depositEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			this.colComments = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colModified = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colModifier = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.paymentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.billingData = new ShomreiTorah.Data.UI.FrameworkBindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentMethodEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkNumberEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.accountEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.currencyEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.depositEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentsBindingSource)).BeginInit();
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
			this.ribbon.Size = new System.Drawing.Size(695, 114);
			// 
			// grid
			// 
			this.grid.DataMember = "Payments";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 114);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.RegistrationCount = 38;
			this.grid.Size = new System.Drawing.Size(695, 323);
			this.grid.TabIndex = 0;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFullName,
            this.colDate,
            this.colMethod,
            this.colCheckNumber,
            this.colAccount,
            this.colAmount,
            this.colDepositDate,
            this.colComments,
            this.colModified,
            this.colModifier});
			this.gridView.GridControl = this.grid;
			this.gridView.GroupFormat = "{0}: [#image]{1}: {2}";
			this.gridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", null, "{0} Payments"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", null, "{0:c}")});
			this.gridView.Name = "gridView";
			this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
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
			this.colFullName.SummaryItem.DisplayFormat = "{0:#,0} Payments";
			this.colFullName.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
			this.colFullName.Visible = true;
			this.colFullName.VisibleIndex = 0;
			this.colFullName.Width = 81;
			// 
			// colDate
			// 
			this.colDate.FieldName = "Date";
			this.colDate.Name = "colDate";
			this.colDate.Visible = true;
			this.colDate.VisibleIndex = 1;
			this.colDate.Width = 63;
			// 
			// colMethod
			// 
			this.colMethod.ColumnEditor = this.paymentMethodEdit;
			this.colMethod.FieldName = "Method";
			this.colMethod.MaxWidth = 70;
			this.colMethod.Name = "colMethod";
			this.colMethod.Visible = true;
			this.colMethod.VisibleIndex = 3;
			this.colMethod.Width = 55;
			// 
			// paymentMethodEdit
			// 
			this.paymentMethodEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.paymentMethodEdit.DropDownRows = 2;
			this.paymentMethodEdit.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
			this.paymentMethodEdit.Items.AddRange(new object[] {
            "Cash",
            "Check"});
			this.paymentMethodEdit.Name = "paymentMethodEdit";
			// 
			// colCheckNumber
			// 
			this.colCheckNumber.ColumnEditor = this.checkNumberEdit;
			this.colCheckNumber.FieldName = "CheckNumber";
			this.colCheckNumber.Name = "colCheckNumber";
			this.colCheckNumber.Visible = true;
			this.colCheckNumber.VisibleIndex = 4;
			this.colCheckNumber.Width = 88;
			// 
			// checkNumberEdit
			// 
			this.checkNumberEdit.Name = "checkNumberEdit";
			// 
			// colAccount
			// 
			this.colAccount.ColumnEditor = this.accountEdit;
			this.colAccount.FieldName = "Account";
			this.colAccount.MaxWidth = 100;
			this.colAccount.Name = "colAccount";
			this.colAccount.Visible = true;
			this.colAccount.VisibleIndex = 2;
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
			this.colAmount.SummaryItem.DisplayFormat = "{0:c} Total Paid";
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
			// colDepositDate
			// 
			this.colDepositDate.Caption = "Deposited";
			this.colDepositDate.ColumnEditor = this.depositEdit;
			this.colDepositDate.FieldName = "Deposit";
			this.colDepositDate.MaxWidth = 90;
			this.colDepositDate.Name = "colDepositDate";
			this.colDepositDate.OptionsColumn.AllowEdit = false;
			this.colDepositDate.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
			this.colDepositDate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.colDepositDate.OptionsColumn.ReadOnly = true;
			this.colDepositDate.UnboundType = DevExpress.Data.UnboundColumnType.Object;
			this.colDepositDate.Visible = true;
			this.colDepositDate.VisibleIndex = 6;
			this.colDepositDate.Width = 67;
			// 
			// depositEdit
			// 
			this.depositEdit.AutoHeight = false;
			this.depositEdit.Name = "depositEdit";
			this.depositEdit.NullText = "Undeposited";
			this.depositEdit.ReadOnly = true;
			// 
			// colComments
			// 
			this.colComments.FieldName = "Comments";
			this.colComments.Name = "colComments";
			this.colComments.Visible = true;
			this.colComments.VisibleIndex = 7;
			this.colComments.Width = 69;
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
			// paymentsBindingSource
			// 
			this.paymentsBindingSource.DataMember = "Payments";
			this.paymentsBindingSource.DataSource = this.billingData;
			this.paymentsBindingSource.Position = 0;
			// 
			// billingData
			// 
			this.billingData.Position = 0;
			// 
			// PaymentViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(695, 437);
			this.Controls.Add(this.grid);
			this.MainView = this.gridView;
			this.Name = "PaymentViewer";
			this.Text = "All Payments";
			this.Controls.SetChildIndex(this.ribbon, 0);
			this.Controls.SetChildIndex(this.grid, 0);
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentMethodEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkNumberEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.accountEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.currencyEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.depositEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.billingData)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Data.UI.Grid.SmartGrid grid;
		private Data.UI.Grid.SmartGridView gridView;
		private ShomreiTorah.Data.UI.FrameworkBindingSource billingData;
		private System.Windows.Forms.BindingSource paymentsBindingSource;
		private Data.UI.Grid.SmartGridColumn colFullName;
		private Data.UI.Grid.SmartGridColumn colDate;
		private Data.UI.Grid.SmartGridColumn colMethod;
		private Data.UI.Grid.SmartGridColumn colCheckNumber;
		private Data.UI.Grid.SmartGridColumn colAmount;
		private Data.UI.Grid.SmartGridColumn colComments;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox paymentMethodEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit currencyEdit;
		private Data.UI.Grid.SmartGridColumn colAccount;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox accountEdit;
		private Data.UI.Grid.SmartGridColumn colModified;
		private Data.UI.Grid.SmartGridColumn colModifier;
		
		private Data.UI.Grid.SmartGridColumn colDepositDate;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit depositEdit;
		private Data.UI.Controls.RepositoryItemCheckNumberEdit checkNumberEdit;
	}
}