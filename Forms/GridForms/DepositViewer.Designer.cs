namespace ShomreiTorah.Billing.Forms.GridForms {
	partial class DepositViewer {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepositViewer));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
			this.paymentsView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colFullName1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.personRefEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colMethod = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCheckNumber = new DevExpress.XtraGrid.Columns.GridColumn();
			this.checkNumberEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colComments = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colModified = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colModifier = new DevExpress.XtraGrid.Columns.GridColumn();
			this.grid = new ShomreiTorah.Billing.Controls.BaseGrid(this.components);
			this.depositsView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colAccount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDepositDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDepositAmount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPaymentCount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.masterDirectoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.billingData = new ShomreiTorah.Billing.BillingData();
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
			this.colSource = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTotalPledged = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTotalPaid = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colBalanceDue = new DevExpress.XtraGrid.Columns.GridColumn();
			this.masterDirectoryTableAdapter = new ShomreiTorah.Billing.BillingDataTableAdapters.MasterDirectoryTableAdapter();
			this.pledgesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.pledgesTableAdapter = new ShomreiTorah.Billing.BillingDataTableAdapters.PledgesTableAdapter();
			((System.ComponentModel.ISupportInitialize)(this.paymentsView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.personRefEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkNumberEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.depositsView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.masterDirectoryBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.billingData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgesBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// paymentsView
			// 
			this.paymentsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFullName1,
            this.colDate,
            this.colMethod,
            this.colCheckNumber,
            this.colAmount,
            this.colComments,
            this.colModified,
            this.colModifier});
			this.paymentsView.GridControl = this.grid;
			this.paymentsView.Name = "paymentsView";
			this.paymentsView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
			this.paymentsView.OptionsSelection.MultiSelect = true;
			this.paymentsView.OptionsView.ShowGroupPanel = false;
			this.paymentsView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFullName1, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.paymentsView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.paymentsView_KeyUp);
			// 
			// colFullName1
			// 
			this.colFullName1.ColumnEdit = this.personRefEdit;
			this.colFullName1.FieldName = "FullName";
			this.colFullName1.Name = "colFullName1";
			this.colFullName1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colFullName1.Visible = true;
			this.colFullName1.VisibleIndex = 0;
			// 
			// personRefEdit
			// 
			this.personRefEdit.AutoHeight = false;
			this.personRefEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("personRefEdit.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Show Person", null, null, true)});
			this.personRefEdit.Name = "personRefEdit";
			this.personRefEdit.ReadOnly = true;
			this.personRefEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.personRefEdit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.paymentsView_KeyUp);
			this.personRefEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.personRefEdit_ButtonClick);
			// 
			// colDate
			// 
			this.colDate.FieldName = "Date";
			this.colDate.Name = "colDate";
			this.colDate.OptionsColumn.AllowEdit = false;
			this.colDate.OptionsColumn.AllowFocus = false;
			this.colDate.OptionsColumn.ReadOnly = true;
			this.colDate.Visible = true;
			this.colDate.VisibleIndex = 1;
			// 
			// colMethod
			// 
			this.colMethod.FieldName = "Method";
			this.colMethod.Name = "colMethod";
			this.colMethod.OptionsColumn.AllowEdit = false;
			this.colMethod.OptionsColumn.AllowFocus = false;
			this.colMethod.OptionsColumn.ReadOnly = true;
			this.colMethod.Visible = true;
			this.colMethod.VisibleIndex = 2;
			// 
			// colCheckNumber
			// 
			this.colCheckNumber.ColumnEdit = this.checkNumberEdit;
			this.colCheckNumber.FieldName = "CheckNumber";
			this.colCheckNumber.Name = "colCheckNumber";
			this.colCheckNumber.OptionsColumn.AllowEdit = false;
			this.colCheckNumber.OptionsColumn.AllowFocus = false;
			this.colCheckNumber.OptionsColumn.ReadOnly = true;
			this.colCheckNumber.Visible = true;
			this.colCheckNumber.VisibleIndex = 3;
			// 
			// checkNumberEdit
			// 
			this.checkNumberEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.checkNumberEdit.DisplayFormat.FormatString = "f0";
			this.checkNumberEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.checkNumberEdit.EditFormat.FormatString = "f0";
			this.checkNumberEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.checkNumberEdit.IsFloatValue = false;
			this.checkNumberEdit.Mask.EditMask = "f0";
			this.checkNumberEdit.Name = "checkNumberEdit";
			this.checkNumberEdit.NullText = "N/A";
			// 
			// colAmount
			// 
			this.colAmount.DisplayFormat.FormatString = "c";
			this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colAmount.FieldName = "Amount";
			this.colAmount.Name = "colAmount";
			this.colAmount.OptionsColumn.AllowEdit = false;
			this.colAmount.OptionsColumn.AllowFocus = false;
			this.colAmount.OptionsColumn.ReadOnly = true;
			this.colAmount.Visible = true;
			this.colAmount.VisibleIndex = 4;
			// 
			// colComments
			// 
			this.colComments.FieldName = "Comments";
			this.colComments.Name = "colComments";
			this.colComments.OptionsColumn.AllowEdit = false;
			this.colComments.OptionsColumn.AllowFocus = false;
			this.colComments.OptionsColumn.ReadOnly = true;
			this.colComments.Visible = true;
			this.colComments.VisibleIndex = 5;
			// 
			// colModified
			// 
			this.colModified.DisplayFormat.FormatString = "f";
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
			// grid
			// 
			this.grid.DataMember = "Deposits";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			gridLevelNode1.LevelTemplate = this.paymentsView;
			gridLevelNode1.RelationName = "Deposit";
			this.grid.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
			this.grid.Location = new System.Drawing.Point(0, 0);
			this.grid.MainView = this.depositsView;
			this.grid.Name = "grid";
			this.grid.ShowOnlyPredefinedDetails = true;
			this.grid.Size = new System.Drawing.Size(578, 366);
			this.grid.TabIndex = 0;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.depositsView,
            this.paymentsView});
			// 
			// depositsView
			// 
			this.depositsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAccount,
            this.colDepositDate,
            this.colNumber,
            this.colDepositAmount,
            this.colPaymentCount});
			this.depositsView.GridControl = this.grid;
			this.depositsView.GroupCount = 1;
			this.depositsView.GroupFormat = "{1} ({2})";
			this.depositsView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", null, "{0} Deposits"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", null, "Total deposited: {0:c}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "", null, "Undeposited: {0:c}")});
			this.depositsView.Name = "depositsView";
			this.depositsView.OptionsBehavior.AutoExpandAllGroups = true;
			this.depositsView.OptionsDetail.ShowDetailTabs = false;
			this.depositsView.OptionsView.ColumnAutoWidth = false;
			this.depositsView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colAccount, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDepositDate, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNumber, DevExpress.Data.ColumnSortOrder.Descending)});
			this.depositsView.DoubleClick += new System.EventHandler(this.depositsView_DoubleClick);
			this.depositsView.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.depositsView_CustomSummaryCalculate);
			// 
			// colAccount
			// 
			this.colAccount.Caption = "Account";
			this.colAccount.FieldName = "Account";
			this.colAccount.Name = "colAccount";
			this.colAccount.OptionsColumn.AllowEdit = false;
			this.colAccount.OptionsColumn.AllowFocus = false;
			this.colAccount.OptionsColumn.ReadOnly = true;
			// 
			// colDepositDate
			// 
			this.colDepositDate.Caption = "Date Deposited";
			this.colDepositDate.DisplayFormat.FormatString = "D";
			this.colDepositDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colDepositDate.FieldName = "Date";
			this.colDepositDate.Name = "colDepositDate";
			this.colDepositDate.OptionsColumn.AllowEdit = false;
			this.colDepositDate.OptionsColumn.AllowFocus = false;
			this.colDepositDate.OptionsColumn.ReadOnly = true;
			this.colDepositDate.Visible = true;
			this.colDepositDate.VisibleIndex = 0;
			this.colDepositDate.Width = 107;
			// 
			// colNumber
			// 
			this.colNumber.DisplayFormat.FormatString = "#{0}";
			this.colNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.colNumber.FieldName = "Number";
			this.colNumber.Name = "colNumber";
			this.colNumber.OptionsColumn.AllowEdit = false;
			this.colNumber.OptionsColumn.AllowFocus = false;
			this.colNumber.OptionsColumn.ReadOnly = true;
			this.colNumber.Visible = true;
			this.colNumber.VisibleIndex = 1;
			this.colNumber.Width = 76;
			// 
			// colDepositAmount
			// 
			this.colDepositAmount.Caption = "Amount Deposited";
			this.colDepositAmount.DisplayFormat.FormatString = "c";
			this.colDepositAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colDepositAmount.FieldName = "Amount";
			this.colDepositAmount.Name = "colDepositAmount";
			this.colDepositAmount.OptionsColumn.AllowEdit = false;
			this.colDepositAmount.OptionsColumn.AllowFocus = false;
			this.colDepositAmount.OptionsColumn.ReadOnly = true;
			this.colDepositAmount.Visible = true;
			this.colDepositAmount.VisibleIndex = 2;
			this.colDepositAmount.Width = 129;
			// 
			// colPaymentCount
			// 
			this.colPaymentCount.Caption = " ";
			this.colPaymentCount.CustomizationCaption = "Count";
			this.colPaymentCount.DisplayFormat.FormatString = "{0} Payments";
			this.colPaymentCount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.colPaymentCount.FieldName = "Count";
			this.colPaymentCount.Name = "colPaymentCount";
			this.colPaymentCount.OptionsColumn.AllowEdit = false;
			this.colPaymentCount.OptionsColumn.AllowFocus = false;
			this.colPaymentCount.OptionsColumn.ReadOnly = true;
			this.colPaymentCount.Visible = true;
			this.colPaymentCount.VisibleIndex = 3;
			this.colPaymentCount.Width = 245;
			// 
			// masterDirectoryBindingSource
			// 
			this.masterDirectoryBindingSource.DataMember = "MasterDirectory";
			this.masterDirectoryBindingSource.DataSource = this.billingData;
			// 
			// billingData
			// 
			this.billingData.DataSetName = "BillingData";
			this.billingData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// colId
			// 
			this.colId.FieldName = "Id";
			this.colId.Name = "colId";
			this.colId.Visible = true;
			this.colId.VisibleIndex = 0;
			// 
			// colYKID
			// 
			this.colYKID.FieldName = "YKID";
			this.colYKID.Name = "colYKID";
			this.colYKID.Visible = true;
			this.colYKID.VisibleIndex = 1;
			// 
			// colLastName
			// 
			this.colLastName.FieldName = "LastName";
			this.colLastName.Name = "colLastName";
			this.colLastName.Visible = true;
			this.colLastName.VisibleIndex = 2;
			// 
			// colHisName
			// 
			this.colHisName.FieldName = "HisName";
			this.colHisName.Name = "colHisName";
			this.colHisName.Visible = true;
			this.colHisName.VisibleIndex = 3;
			// 
			// colHerName
			// 
			this.colHerName.FieldName = "HerName";
			this.colHerName.Name = "colHerName";
			this.colHerName.Visible = true;
			this.colHerName.VisibleIndex = 4;
			// 
			// colFullName
			// 
			this.colFullName.FieldName = "FullName";
			this.colFullName.Name = "colFullName";
			this.colFullName.Visible = true;
			this.colFullName.VisibleIndex = 5;
			// 
			// colAddress
			// 
			this.colAddress.FieldName = "Address";
			this.colAddress.Name = "colAddress";
			this.colAddress.Visible = true;
			this.colAddress.VisibleIndex = 6;
			// 
			// colCity
			// 
			this.colCity.FieldName = "City";
			this.colCity.Name = "colCity";
			this.colCity.Visible = true;
			this.colCity.VisibleIndex = 7;
			// 
			// colState
			// 
			this.colState.FieldName = "State";
			this.colState.Name = "colState";
			this.colState.Visible = true;
			this.colState.VisibleIndex = 8;
			// 
			// colZip
			// 
			this.colZip.FieldName = "Zip";
			this.colZip.Name = "colZip";
			this.colZip.Visible = true;
			this.colZip.VisibleIndex = 9;
			// 
			// colPhone
			// 
			this.colPhone.FieldName = "Phone";
			this.colPhone.Name = "colPhone";
			this.colPhone.Visible = true;
			this.colPhone.VisibleIndex = 10;
			// 
			// colSource
			// 
			this.colSource.FieldName = "Source";
			this.colSource.Name = "colSource";
			this.colSource.Visible = true;
			this.colSource.VisibleIndex = 11;
			// 
			// colTotalPledged
			// 
			this.colTotalPledged.FieldName = "TotalPledged";
			this.colTotalPledged.Name = "colTotalPledged";
			this.colTotalPledged.OptionsColumn.ReadOnly = true;
			this.colTotalPledged.Visible = true;
			this.colTotalPledged.VisibleIndex = 12;
			// 
			// colTotalPaid
			// 
			this.colTotalPaid.FieldName = "TotalPaid";
			this.colTotalPaid.Name = "colTotalPaid";
			this.colTotalPaid.OptionsColumn.ReadOnly = true;
			this.colTotalPaid.Visible = true;
			this.colTotalPaid.VisibleIndex = 13;
			// 
			// colBalanceDue
			// 
			this.colBalanceDue.FieldName = "BalanceDue";
			this.colBalanceDue.Name = "colBalanceDue";
			this.colBalanceDue.OptionsColumn.ReadOnly = true;
			this.colBalanceDue.Visible = true;
			this.colBalanceDue.VisibleIndex = 14;
			// 
			// masterDirectoryTableAdapter
			// 
			this.masterDirectoryTableAdapter.ClearBeforeFill = true;
			// 
			// pledgesBindingSource
			// 
			this.pledgesBindingSource.DataMember = "Pledges";
			this.pledgesBindingSource.DataSource = this.masterDirectoryBindingSource;
			// 
			// pledgesTableAdapter
			// 
			this.pledgesTableAdapter.ClearBeforeFill = true;
			// 
			// DepositViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(578, 366);
			this.Controls.Add(this.grid);
			this.Name = "DepositViewer";
			this.Text = "All Deposits";
			((System.ComponentModel.ISupportInitialize)(this.paymentsView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.personRefEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkNumberEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.depositsView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.masterDirectoryBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.billingData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgesBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

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
		private DevExpress.XtraGrid.Columns.GridColumn colSource;
		private DevExpress.XtraGrid.Columns.GridColumn colTotalPledged;
		private DevExpress.XtraGrid.Columns.GridColumn colTotalPaid;
		private DevExpress.XtraGrid.Columns.GridColumn colBalanceDue;
		private System.Windows.Forms.BindingSource masterDirectoryBindingSource;
		private BillingData billingData;
		private ShomreiTorah.Billing.BillingDataTableAdapters.MasterDirectoryTableAdapter masterDirectoryTableAdapter;
		private ShomreiTorah.Billing.Controls.BaseGrid grid;
		private System.Windows.Forms.BindingSource pledgesBindingSource;
		private ShomreiTorah.Billing.BillingDataTableAdapters.PledgesTableAdapter pledgesTableAdapter;
		private DevExpress.XtraGrid.Views.Grid.GridView paymentsView;
		private DevExpress.XtraGrid.Views.Grid.GridView depositsView;
		private DevExpress.XtraGrid.Columns.GridColumn colFullName1;
		private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit personRefEdit;
		private DevExpress.XtraGrid.Columns.GridColumn colDate;
		private DevExpress.XtraGrid.Columns.GridColumn colAmount;
		private DevExpress.XtraGrid.Columns.GridColumn colComments;
		private DevExpress.XtraGrid.Columns.GridColumn colModified;
		private DevExpress.XtraGrid.Columns.GridColumn colModifier;
		private DevExpress.XtraGrid.Columns.GridColumn colAccount;
		private DevExpress.XtraGrid.Columns.GridColumn colDepositDate;
		private DevExpress.XtraGrid.Columns.GridColumn colDepositAmount;
		private DevExpress.XtraGrid.Columns.GridColumn colMethod;
		private DevExpress.XtraGrid.Columns.GridColumn colCheckNumber;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit checkNumberEdit;
		private DevExpress.XtraGrid.Columns.GridColumn colPaymentCount;
		private DevExpress.XtraGrid.Columns.GridColumn colNumber;
	}
}