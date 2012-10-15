namespace ShomreiTorah.Billing.Forms.GridForms {
	partial class MasterDirectoryGridForm {
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
			DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
			DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
			DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
			this.paymentsView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colDate = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colMethod = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.paymentMethodEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.colCheckNumber = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.checkNumberEdit = new ShomreiTorah.Data.UI.Controls.RepositoryItemCheckNumberEdit();
			this.colAccount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.accountEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.colAmount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.currencyEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.colDepositDateSql = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.depositEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			this.colComments = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colModified = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colModifier = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.grid = new ShomreiTorah.Data.UI.Grid.SmartGrid(this.components);
			this.pledgesView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colPledgeId = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colPersonId1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colDate1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colType = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colSubType = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAmount1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colNote = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.repositoryItemAliyahNoteEdit1 = new ShomreiTorah.Billing.Controls.Editors.RepositoryItemAliyahNoteEdit();
			this.colComments1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAccount1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colModified1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colModifier1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.emailView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colID1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colEmail = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colRandomCode = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colActive = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colJoinDate = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colPersonId2 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.gridView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colId = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colYKID = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colLastName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colHisName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colHerName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colFullName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAddress = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colCity = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colState = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.stateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.colZip = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colPhone = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colSource = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.personSourceEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.colTotalPledged = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colTotalPaid = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colBalanceDue = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colSalutation = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colUnlinkedAmount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentsView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentMethodEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkNumberEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.accountEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.currencyEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.depositEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgesView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemAliyahNoteEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emailView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stateEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.personSourceEdit)).BeginInit();
			this.SuspendLayout();
			// 
			// ribbon
			// 
			this.ribbon.ExpandCollapseItem.Id = 0;
			this.ribbon.ExpandCollapseItem.Name = "";
			this.ribbon.Size = new System.Drawing.Size(1067, 115);
			// 
			// paymentsView
			// 
			this.paymentsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDate,
            this.colMethod,
            this.colCheckNumber,
            this.colAccount,
            this.colAmount,
            this.colDepositDateSql,
            this.colComments,
            this.colModified,
            this.colModifier});
			this.paymentsView.GridControl = this.grid;
			this.paymentsView.Name = "paymentsView";
			this.paymentsView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
			this.paymentsView.OptionsSelection.MultiSelect = true;
			this.paymentsView.OptionsView.ShowFooter = true;
			this.paymentsView.OptionsView.ShowGroupPanel = false;
			// 
			// colDate
			// 
			this.colDate.FieldName = "Date";
			this.colDate.Name = "colDate";
			this.colDate.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Date", "{0} Payments")});
			this.colDate.Visible = true;
			this.colDate.VisibleIndex = 0;
			// 
			// colMethod
			// 
			this.colMethod.ColumnEditor = this.paymentMethodEdit;
			this.colMethod.FieldName = "Method";
			this.colMethod.Name = "colMethod";
			this.colMethod.Visible = true;
			this.colMethod.VisibleIndex = 2;
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
			this.colCheckNumber.VisibleIndex = 3;
			// 
			// checkNumberEdit
			// 
			this.checkNumberEdit.Name = "checkNumberEdit";
			// 
			// colAccount
			// 
			this.colAccount.ColumnEditor = this.accountEdit;
			this.colAccount.FieldName = "Account";
			this.colAccount.Name = "colAccount";
			this.colAccount.Visible = true;
			this.colAccount.VisibleIndex = 1;
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
			this.colAmount.FieldName = "Amount";
			this.colAmount.Name = "colAmount";
			this.colAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "Total Paid: {0:c}")});
			this.colAmount.Visible = true;
			this.colAmount.VisibleIndex = 4;
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
			// colDepositDateSql
			// 
			this.colDepositDateSql.Caption = "Deposited?";
			this.colDepositDateSql.ColumnEditor = this.depositEdit;
			this.colDepositDateSql.FieldName = "Deposit";
			this.colDepositDateSql.Name = "colDepositDateSql";
			this.colDepositDateSql.OptionsColumn.AllowEdit = false;
			this.colDepositDateSql.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.colDepositDateSql.OptionsColumn.ReadOnly = true;
			this.colDepositDateSql.UnboundType = DevExpress.Data.UnboundColumnType.Object;
			this.colDepositDateSql.Visible = true;
			this.colDepositDateSql.VisibleIndex = 5;
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
			this.colComments.VisibleIndex = 6;
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
			// grid
			// 
			this.grid.DataMember = "MasterDirectory";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			gridLevelNode1.LevelTemplate = this.paymentsView;
			gridLevelNode1.RelationName = "Payments";
			gridLevelNode2.LevelTemplate = this.pledgesView;
			gridLevelNode2.RelationName = "Pledges";
			gridLevelNode3.LevelTemplate = this.emailView;
			gridLevelNode3.RelationName = "EmailAddresses";
			this.grid.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2,
            gridLevelNode3});
			this.grid.Location = new System.Drawing.Point(0, 115);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.RegistrationCount = 53;
			this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemAliyahNoteEdit1});
			this.grid.ShowOnlyPredefinedDetails = true;
			this.grid.Size = new System.Drawing.Size(1067, 426);
			this.grid.TabIndex = 0;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.pledgesView,
            this.emailView,
            this.gridView,
            this.paymentsView});
			// 
			// pledgesView
			// 
			this.pledgesView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPledgeId,
            this.colPersonId1,
            this.colDate1,
            this.colType,
            this.colSubType,
            this.colAmount1,
            this.colNote,
            this.colComments1,
            this.colAccount1,
            this.colModified1,
            this.colModifier1,
            this.colUnlinkedAmount});
			this.pledgesView.GridControl = this.grid;
			this.pledgesView.Name = "pledgesView";
			this.pledgesView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
			this.pledgesView.OptionsSelection.MultiSelect = true;
			this.pledgesView.OptionsView.ShowFooter = true;
			this.pledgesView.OptionsView.ShowGroupPanel = false;
			// 
			// colPledgeId
			// 
			this.colPledgeId.FieldName = "PledgeId";
			this.colPledgeId.Name = "colPledgeId";
			// 
			// colPersonId1
			// 
			this.colPersonId1.FieldName = "PersonId";
			this.colPersonId1.Name = "colPersonId1";
			// 
			// colDate1
			// 
			this.colDate1.FieldName = "Date";
			this.colDate1.Name = "colDate1";
			this.colDate1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
			this.colDate1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Date", "{0} Pledges")});
			this.colDate1.Visible = true;
			this.colDate1.VisibleIndex = 0;
			// 
			// colType
			// 
			this.colType.FieldName = "Type";
			this.colType.Name = "colType";
			this.colType.Visible = true;
			this.colType.VisibleIndex = 1;
			// 
			// colSubType
			// 
			this.colSubType.FieldName = "SubType";
			this.colSubType.Name = "colSubType";
			this.colSubType.Visible = true;
			this.colSubType.VisibleIndex = 2;
			// 
			// colAmount1
			// 
			this.colAmount1.ColumnEditor = this.currencyEdit;
			this.colAmount1.FieldName = "Amount";
			this.colAmount1.Name = "colAmount1";
			this.colAmount1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "Total Pledged: {0:c}")});
			this.colAmount1.Visible = true;
			this.colAmount1.VisibleIndex = 4;
			// 
			// colNote
			// 
			this.colNote.ColumnEditor = this.repositoryItemAliyahNoteEdit1;
			this.colNote.FieldName = "Note";
			this.colNote.Name = "colNote";
			this.colNote.Visible = true;
			this.colNote.VisibleIndex = 6;
			// 
			// repositoryItemAliyahNoteEdit1
			// 
			this.repositoryItemAliyahNoteEdit1.AutoHeight = false;
			this.repositoryItemAliyahNoteEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.repositoryItemAliyahNoteEdit1.Name = "repositoryItemAliyahNoteEdit1";
			// 
			// colComments1
			// 
			this.colComments1.FieldName = "Comments";
			this.colComments1.Name = "colComments1";
			this.colComments1.Visible = true;
			this.colComments1.VisibleIndex = 7;
			// 
			// colAccount1
			// 
			this.colAccount1.ColumnEditor = this.accountEdit;
			this.colAccount1.FieldName = "Account";
			this.colAccount1.Name = "colAccount1";
			this.colAccount1.Visible = true;
			this.colAccount1.VisibleIndex = 3;
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
			// emailView
			// 
			this.emailView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID1,
            this.colName,
            this.colEmail,
            this.colRandomCode,
            this.colActive,
            this.colJoinDate,
            this.colPersonId2});
			this.emailView.GridControl = this.grid;
			this.emailView.Name = "emailView";
			this.emailView.NewItemRowText = "Click here to add an email address";
			this.emailView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
			this.emailView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
			this.emailView.OptionsView.ShowGroupPanel = false;
			// 
			// colID1
			// 
			this.colID1.FieldName = "ID";
			this.colID1.Name = "colID1";
			this.colID1.OptionsColumn.ReadOnly = true;
			// 
			// colName
			// 
			this.colName.FieldName = "Name";
			this.colName.Name = "colName";
			this.colName.Visible = true;
			this.colName.VisibleIndex = 0;
			// 
			// colEmail
			// 
			this.colEmail.FieldName = "Email";
			this.colEmail.Name = "colEmail";
			this.colEmail.Visible = true;
			this.colEmail.VisibleIndex = 1;
			// 
			// colRandomCode
			// 
			this.colRandomCode.FieldName = "RandomCode";
			this.colRandomCode.Name = "colRandomCode";
			// 
			// colActive
			// 
			this.colActive.FieldName = "Active";
			this.colActive.Name = "colActive";
			// 
			// colJoinDate
			// 
			this.colJoinDate.Caption = "Join Date";
			this.colJoinDate.DisplayFormat.FormatString = "D";
			this.colJoinDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colJoinDate.FieldName = "JoinDate";
			this.colJoinDate.Name = "colJoinDate";
			this.colJoinDate.OptionsColumn.AllowEdit = false;
			this.colJoinDate.Visible = true;
			this.colJoinDate.VisibleIndex = 2;
			// 
			// colPersonId2
			// 
			this.colPersonId2.FieldName = "PersonId";
			this.colPersonId2.Name = "colPersonId2";
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
            this.colSource,
            this.colTotalPledged,
            this.colTotalPaid,
            this.colBalanceDue,
            this.colSalutation});
			this.gridView.GridControl = this.grid;
			this.gridView.GroupFormat = "{0}: [#image]{1}                   {2}";
			this.gridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "LastName", null, "People: {0:#,0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BalanceDue", null, "Total Dues: {0:c}")});
			this.gridView.Name = "gridView";
			this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
			this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
			this.gridView.OptionsDetail.AllowExpandEmptyDetails = true;
			this.gridView.OptionsDetail.EnableDetailToolTip = true;
			this.gridView.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled;
			this.gridView.OptionsFilter.UseNewCustomFilterDialog = true;
			this.gridView.OptionsSelection.MultiSelect = true;
			this.gridView.OptionsView.ShowFooter = true;
			this.gridView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
			this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLastName, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// colId
			// 
			this.colId.FieldName = "Id";
			this.colId.Name = "colId";
			this.colId.Width = 23;
			// 
			// colYKID
			// 
			this.colYKID.FieldName = "YKID";
			this.colYKID.Name = "colYKID";
			this.colYKID.Width = 32;
			// 
			// colLastName
			// 
			this.colLastName.FieldName = "LastName";
			this.colLastName.Name = "colLastName";
			this.colLastName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "LastName", "{0} People")});
			this.colLastName.Visible = true;
			this.colLastName.VisibleIndex = 0;
			this.colLastName.Width = 82;
			// 
			// colHisName
			// 
			this.colHisName.FieldName = "HisName";
			this.colHisName.Name = "colHisName";
			this.colHisName.Visible = true;
			this.colHisName.VisibleIndex = 2;
			this.colHisName.Width = 63;
			// 
			// colHerName
			// 
			this.colHerName.FieldName = "HerName";
			this.colHerName.Name = "colHerName";
			this.colHerName.Visible = true;
			this.colHerName.VisibleIndex = 1;
			this.colHerName.Width = 66;
			// 
			// colFullName
			// 
			this.colFullName.FieldName = "FullName";
			this.colFullName.Name = "colFullName";
			this.colFullName.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
			this.colFullName.Visible = true;
			this.colFullName.VisibleIndex = 3;
			this.colFullName.Width = 65;
			// 
			// colAddress
			// 
			this.colAddress.FieldName = "Address";
			this.colAddress.Name = "colAddress";
			this.colAddress.Visible = true;
			this.colAddress.VisibleIndex = 5;
			this.colAddress.Width = 58;
			// 
			// colCity
			// 
			this.colCity.FieldName = "City";
			this.colCity.Name = "colCity";
			this.colCity.Visible = true;
			this.colCity.VisibleIndex = 6;
			this.colCity.Width = 38;
			// 
			// colState
			// 
			this.colState.ColumnEditor = this.stateEdit;
			this.colState.FieldName = "State";
			this.colState.MaxWidth = 50;
			this.colState.Name = "colState";
			this.colState.Visible = true;
			this.colState.VisibleIndex = 7;
			this.colState.Width = 45;
			// 
			// stateEdit
			// 
			this.stateEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.stateEdit.DropDownRows = 16;
			this.stateEdit.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
			this.stateEdit.Items.AddRange(new object[] {
            "NJ",
            "NY",
            "",
            "AL",
            "AK",
            "AZ",
            "AR",
            "CA",
            "CO",
            "CT",
            "DE",
            "DC",
            "FL",
            "GA",
            "HI",
            "ID",
            "IL",
            "IN",
            "IA",
            "KS",
            "KY",
            "LA",
            "ME",
            "MD",
            "MA",
            "MI",
            "MN",
            "MS",
            "MO",
            "MT",
            "NE",
            "NV",
            "NH",
            "NM",
            "NC",
            "ND",
            "OH",
            "OK",
            "OR",
            "PA",
            "RI",
            "SC",
            "SD",
            "TN",
            "TX",
            "UT",
            "VT",
            "VA",
            "WA",
            "WV",
            "WI",
            "WY"});
			this.stateEdit.Name = "stateEdit";
			// 
			// colZip
			// 
			this.colZip.FieldName = "Zip";
			this.colZip.MaxWidth = 40;
			this.colZip.Name = "colZip";
			this.colZip.Visible = true;
			this.colZip.VisibleIndex = 8;
			this.colZip.Width = 34;
			// 
			// colPhone
			// 
			this.colPhone.FieldName = "Phone";
			this.colPhone.MaxWidth = 95;
			this.colPhone.Name = "colPhone";
			this.colPhone.Visible = true;
			this.colPhone.VisibleIndex = 9;
			this.colPhone.Width = 49;
			// 
			// colSource
			// 
			this.colSource.ColumnEditor = this.personSourceEdit;
			this.colSource.FieldName = "Source";
			this.colSource.Name = "colSource";
			this.colSource.Visible = true;
			this.colSource.VisibleIndex = 10;
			this.colSource.Width = 52;
			// 
			// personSourceEdit
			// 
			this.personSourceEdit.AutoHeight = false;
			this.personSourceEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.personSourceEdit.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
			this.personSourceEdit.Items.AddRange(new object[] {
            "YK Directory",
            "Manually Added"});
			this.personSourceEdit.Name = "personSourceEdit";
			// 
			// colTotalPledged
			// 
			this.colTotalPledged.ColumnEditor = this.currencyEdit;
			this.colTotalPledged.DisplayFormat.FormatString = "c";
			this.colTotalPledged.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colTotalPledged.FieldName = "TotalPledged";
			this.colTotalPledged.Name = "colTotalPledged";
			this.colTotalPledged.OptionsColumn.ReadOnly = true;
			this.colTotalPledged.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
			this.colTotalPledged.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPledged", "All Pledges: {0:c}")});
			this.colTotalPledged.Visible = true;
			this.colTotalPledged.VisibleIndex = 11;
			this.colTotalPledged.Width = 133;
			// 
			// colTotalPaid
			// 
			this.colTotalPaid.ColumnEditor = this.currencyEdit;
			this.colTotalPaid.DisplayFormat.FormatString = "c";
			this.colTotalPaid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colTotalPaid.FieldName = "TotalPaid";
			this.colTotalPaid.Name = "colTotalPaid";
			this.colTotalPaid.OptionsColumn.ReadOnly = true;
			this.colTotalPaid.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
			this.colTotalPaid.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPaid", "Total Paid: {0:c}")});
			this.colTotalPaid.Visible = true;
			this.colTotalPaid.VisibleIndex = 12;
			this.colTotalPaid.Width = 129;
			// 
			// colBalanceDue
			// 
			this.colBalanceDue.ColumnEditor = this.currencyEdit;
			this.colBalanceDue.DisplayFormat.FormatString = "c";
			this.colBalanceDue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colBalanceDue.FieldName = "BalanceDue";
			this.colBalanceDue.Name = "colBalanceDue";
			this.colBalanceDue.OptionsColumn.ReadOnly = true;
			this.colBalanceDue.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
			this.colBalanceDue.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BalanceDue", "Total Dues: {0:c}")});
			this.colBalanceDue.Visible = true;
			this.colBalanceDue.VisibleIndex = 13;
			this.colBalanceDue.Width = 127;
			// 
			// colSalutation
			// 
			this.colSalutation.FieldName = "Salutation";
			this.colSalutation.Name = "colSalutation";
			this.colSalutation.Visible = true;
			this.colSalutation.VisibleIndex = 4;
			this.colSalutation.Width = 67;
			// 
			// colUnlinkedAmount
			// 
			this.colUnlinkedAmount.DisplayFormat.FormatString = "c";
			this.colUnlinkedAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colUnlinkedAmount.FieldName = "UnlinkedAmount";
			this.colUnlinkedAmount.MaxWidth = 85;
			this.colUnlinkedAmount.Name = "colUnlinkedAmount";
			this.colUnlinkedAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UnlinkedAmount", "{0:c} Total Unpaid-for")});
			this.colUnlinkedAmount.Visible = true;
			this.colUnlinkedAmount.VisibleIndex = 5;
			// 
			// MasterDirectoryGridForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1067, 541);
			this.Controls.Add(this.grid);
			this.MainView = this.gridView;
			this.Name = "MasterDirectoryGridForm";
			this.Text = "All People";
			this.Controls.SetChildIndex(this.ribbon, 0);
			this.Controls.SetChildIndex(this.grid, 0);
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentsView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentMethodEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkNumberEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.accountEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.currencyEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.depositEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgesView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemAliyahNoteEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emailView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stateEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.personSourceEdit)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Data.UI.Grid.SmartGrid grid;
		private Data.UI.Grid.SmartGridView gridView;
		private Data.UI.Grid.SmartGridView pledgesView;
		private Data.UI.Grid.SmartGridColumn colId;
		private Data.UI.Grid.SmartGridColumn colYKID;
		private Data.UI.Grid.SmartGridColumn colLastName;
		private Data.UI.Grid.SmartGridColumn colHisName;
		private Data.UI.Grid.SmartGridColumn colHerName;
		private Data.UI.Grid.SmartGridColumn colFullName;
		private Data.UI.Grid.SmartGridColumn colAddress;
		private Data.UI.Grid.SmartGridColumn colCity;
		private Data.UI.Grid.SmartGridColumn colState;
		private Data.UI.Grid.SmartGridColumn colZip;
		private Data.UI.Grid.SmartGridColumn colPhone;
		private Data.UI.Grid.SmartGridColumn colBalanceDue;
		private Data.UI.Grid.SmartGridView paymentsView;
		private Data.UI.Grid.SmartGridColumn colDate;
		private Data.UI.Grid.SmartGridColumn colMethod;
		private Data.UI.Grid.SmartGridColumn colCheckNumber;
		private Data.UI.Grid.SmartGridColumn colAmount;
		private Data.UI.Grid.SmartGridColumn colComments;
		private Data.UI.Grid.SmartGridColumn colPledgeId;
		private Data.UI.Grid.SmartGridColumn colPersonId1;
		private Data.UI.Grid.SmartGridColumn colDate1;
		private Data.UI.Grid.SmartGridColumn colType;
		private Data.UI.Grid.SmartGridColumn colSubType;
		private Data.UI.Grid.SmartGridColumn colAmount1;
		private Data.UI.Grid.SmartGridColumn colNote;
		private Data.UI.Grid.SmartGridColumn colComments1;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox stateEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox paymentMethodEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit currencyEdit;
		private Data.UI.Grid.SmartGridColumn colTotalPledged;
		private Data.UI.Grid.SmartGridColumn colTotalPaid;
		private Data.UI.Grid.SmartGridView emailView;
		private Data.UI.Grid.SmartGridColumn colID1;
		private Data.UI.Grid.SmartGridColumn colName;
		private Data.UI.Grid.SmartGridColumn colEmail;
		private Data.UI.Grid.SmartGridColumn colRandomCode;
		private Data.UI.Grid.SmartGridColumn colActive;
		private Data.UI.Grid.SmartGridColumn colJoinDate;
		private Data.UI.Grid.SmartGridColumn colPersonId2;
		private Data.UI.Grid.SmartGridColumn colAccount;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox accountEdit;
		private Data.UI.Grid.SmartGridColumn colAccount1;
		private Data.UI.Grid.SmartGridColumn colSource;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox personSourceEdit;
		private Data.UI.Grid.SmartGridColumn colDepositDateSql;
		private Data.UI.Grid.SmartGridColumn colModified;
		private Data.UI.Grid.SmartGridColumn colModifier;
		private Data.UI.Grid.SmartGridColumn colModified1;
		private Data.UI.Grid.SmartGridColumn colModifier1;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit depositEdit;
		private Data.UI.Controls.RepositoryItemCheckNumberEdit checkNumberEdit;
		private ShomreiTorah.Billing.Controls.Editors.RepositoryItemAliyahNoteEdit repositoryItemAliyahNoteEdit1;
		private Data.UI.Grid.SmartGridColumn colSalutation;
		private Data.UI.Grid.SmartGridColumn colUnlinkedAmount;
	}
}