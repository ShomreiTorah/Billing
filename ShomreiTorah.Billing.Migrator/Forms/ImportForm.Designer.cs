namespace ShomreiTorah.Billing.Migrator.Forms {
	partial class ImportForm {
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
			DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
			DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
			this.paymentsView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colDate = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colMethod = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colCheckNumber = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAccount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAmount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colComments = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colCompany = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.smartGrid1 = new ShomreiTorah.Data.UI.Grid.SmartGrid(this.components);
			this.peopleView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colHisName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colHerName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colLastName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colFullName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAddress = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colCity = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colState = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colZip = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colPhone = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colPerson = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.designerBinder1 = new ShomreiTorah.Billing.Migrator.Forms.DesignerBinder();
			this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
			this.importSources = new DevExpress.XtraBars.BarListItem();
			this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.colStagedPersonId = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colStagedPaymentId = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colStagedPerson = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.clearStaging = new DevExpress.XtraBars.BarButtonItem();
			((System.ComponentModel.ISupportInitialize)(this.paymentsView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.smartGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.peopleView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
			this.SuspendLayout();
			//
			// paymentsView
			//
			this.paymentsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDate,
            this.colMethod,
            this.colCheckNumber,
            this.colAccount,
            this.colAmount,
            this.colComments,
            this.colCompany});
			this.paymentsView.GridControl = this.smartGrid1;
			this.paymentsView.Name = "paymentsView";
			//
			// colDate
			//
			this.colDate.FieldName = "Date";
			this.colDate.Name = "colDate";
			this.colDate.Visible = true;
			this.colDate.VisibleIndex = 0;
			//
			// colMethod
			//
			this.colMethod.FieldName = "Method";
			this.colMethod.Name = "colMethod";
			this.colMethod.Visible = true;
			this.colMethod.VisibleIndex = 1;
			//
			// colCheckNumber
			//
			this.colCheckNumber.FieldName = "CheckNumber";
			this.colCheckNumber.Name = "colCheckNumber";
			this.colCheckNumber.Visible = true;
			this.colCheckNumber.VisibleIndex = 2;
			//
			// colAccount
			//
			this.colAccount.FieldName = "Account";
			this.colAccount.Name = "colAccount";
			this.colAccount.Visible = true;
			this.colAccount.VisibleIndex = 3;
			//
			// colAmount
			//
			this.colAmount.FieldName = "Amount";
			this.colAmount.Name = "colAmount";
			this.colAmount.Visible = true;
			this.colAmount.VisibleIndex = 4;
			//
			// colComments
			//
			this.colComments.FieldName = "Comments";
			this.colComments.Name = "colComments";
			this.colComments.Visible = true;
			this.colComments.VisibleIndex = 5;
			//
			// colCompany
			//
			this.colCompany.FieldName = "Company";
			this.colCompany.Name = "colCompany";
			this.colCompany.Visible = true;
			this.colCompany.VisibleIndex = 6;
			//
			// smartGrid1
			//
			this.smartGrid1.DataMember = "StagedPeople";
			this.smartGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.smartGrid1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			gridLevelNode1.LevelTemplate = this.paymentsView;
			gridLevelNode1.RelationName = "StagedPayments";
			this.smartGrid1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
			this.smartGrid1.Location = new System.Drawing.Point(0, 213);
			this.smartGrid1.MainView = this.peopleView;
			this.smartGrid1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.smartGrid1.Name = "smartGrid1";
			this.smartGrid1.RegistrationCount = 56;
			this.smartGrid1.Size = new System.Drawing.Size(1268, 513);
			this.smartGrid1.Source = this.designerBinder1;
			this.smartGrid1.TabIndex = 3;
			this.smartGrid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.peopleView,
            this.paymentsView});
			//
			// peopleView
			//
			this.peopleView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHisName,
            this.colHerName,
            this.colLastName,
            this.colFullName,
            this.colAddress,
            this.colCity,
            this.colState,
            this.colZip,
            this.colPhone,
            this.colPerson});
			this.peopleView.GridControl = this.smartGrid1;
			this.peopleView.GroupFormat = "{0}: [#image]{1}: {2}";
			this.peopleView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", null, "{0} Payments"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", null, "{0:c}")});
			this.peopleView.Name = "peopleView";
			this.peopleView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
			this.peopleView.OptionsSelection.MultiSelect = true;
			this.peopleView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
			this.peopleView.OptionsView.ShowFooter = true;
			//
			// colHisName
			//
			this.colHisName.FieldName = "HisName";
			this.colHisName.Name = "colHisName";
			this.colHisName.Visible = true;
			this.colHisName.VisibleIndex = 0;
			this.colHisName.Width = 97;
			//
			// colHerName
			//
			this.colHerName.FieldName = "HerName";
			this.colHerName.Name = "colHerName";
			this.colHerName.Visible = true;
			this.colHerName.VisibleIndex = 1;
			this.colHerName.Width = 100;
			//
			// colLastName
			//
			this.colLastName.FieldName = "LastName";
			this.colLastName.Name = "colLastName";
			this.colLastName.Visible = true;
			this.colLastName.VisibleIndex = 2;
			this.colLastName.Width = 103;
			//
			// colFullName
			//
			this.colFullName.FieldName = "FullName";
			this.colFullName.Name = "colFullName";
			this.colFullName.Visible = true;
			this.colFullName.VisibleIndex = 3;
			this.colFullName.Width = 100;
			//
			// colAddress
			//
			this.colAddress.FieldName = "Address";
			this.colAddress.Name = "colAddress";
			this.colAddress.Visible = true;
			this.colAddress.VisibleIndex = 4;
			this.colAddress.Width = 86;
			//
			// colCity
			//
			this.colCity.FieldName = "City";
			this.colCity.Name = "colCity";
			this.colCity.Visible = true;
			this.colCity.VisibleIndex = 5;
			//
			// colState
			//
			this.colState.FieldName = "State";
			this.colState.Name = "colState";
			this.colState.Visible = true;
			this.colState.VisibleIndex = 6;
			//
			// colZip
			//
			this.colZip.FieldName = "Zip";
			this.colZip.Name = "colZip";
			this.colZip.Visible = true;
			this.colZip.VisibleIndex = 7;
			//
			// colPhone
			//
			this.colPhone.FieldName = "Phone";
			this.colPhone.Name = "colPhone";
			this.colPhone.Visible = true;
			this.colPhone.VisibleIndex = 8;
			//
			// colPerson
			//
			this.colPerson.AllowKeyboardActivation = false;
			this.colPerson.FieldName = "Person";
			this.colPerson.Name = "colPerson";
			this.colPerson.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
			this.colPerson.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.colPerson.OptionsColumn.ReadOnly = true;
			this.colPerson.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colPerson.ShowEditorOnMouseDown = true;
			this.colPerson.Visible = true;
			this.colPerson.VisibleIndex = 9;
			this.colPerson.Width = 77;
			//
			// ribbonControl1
			//
			this.ribbonControl1.ExpandCollapseItem.Id = 0;
			this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.importSources,
            this.clearStaging});
			this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
			this.ribbonControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.ribbonControl1.MaxItemId = 3;
			this.ribbonControl1.Name = "ribbonControl1";
			this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
			this.ribbonControl1.Size = new System.Drawing.Size(1268, 213);
			//
			// importSources
			//
			this.importSources.Caption = "Load Data From";
			this.importSources.Id = 1;
			this.importSources.Name = "importSources";
			toolTipTitleItem1.Text = "Load Data From";
			toolTipItem1.LeftIndent = 6;
			toolTipItem1.Text = "Use this menu to read data from an external file into the import staging area.\r\n\r" +
    "\nNo actual people or payments will be created until finalize the import.";
			superToolTip1.Items.Add(toolTipTitleItem1);
			superToolTip1.Items.Add(toolTipItem1);
			this.importSources.SuperTip = superToolTip1;
			this.importSources.ListItemClick += new DevExpress.XtraBars.ListItemClickEventHandler(this.importSources_ListItemClick);
			//
			// ribbonPage1
			//
			this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
			this.ribbonPage1.Name = "ribbonPage1";
			this.ribbonPage1.Text = "Admin";
			//
			// ribbonPageGroup1
			//
			this.ribbonPageGroup1.ItemLinks.Add(this.importSources);
			this.ribbonPageGroup1.ItemLinks.Add(this.clearStaging);
			this.ribbonPageGroup1.Name = "ribbonPageGroup1";
			this.ribbonPageGroup1.Text = "Import";
			//
			// colStagedPersonId
			//
			this.colStagedPersonId.FieldName = "StagedPersonId";
			this.colStagedPersonId.Name = "colStagedPersonId";
			//
			// colStagedPaymentId
			//
			this.colStagedPaymentId.FieldName = "StagedPaymentId";
			this.colStagedPaymentId.Name = "colStagedPaymentId";
			//
			// colStagedPerson
			//
			this.colStagedPerson.FieldName = "StagedPerson";
			this.colStagedPerson.Name = "colStagedPerson";
			//
			// clearStaging
			//
			this.clearStaging.Caption = "Clear Import";
			this.clearStaging.Id = 2;
			this.clearStaging.Name = "clearStaging";
			toolTipTitleItem2.Text = "Clear Import";
			toolTipItem2.LeftIndent = 6;
			toolTipItem2.Text = "Empties the staging area so that you can start again from scratch.\r\n\r\nDestroys al" +
    "l items in this grid, but does not affect any actual people or payments.";
			superToolTip2.Items.Add(toolTipTitleItem2);
			superToolTip2.Items.Add(toolTipItem2);
			this.clearStaging.SuperTip = superToolTip2;
			this.clearStaging.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.clearStaging_ItemClick);
			//
			// ImportForm
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1268, 726);
			this.Controls.Add(this.smartGrid1);
			this.Controls.Add(this.ribbonControl1);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "ImportForm";
			this.Text = "ImportForm";
			((System.ComponentModel.ISupportInitialize)(this.paymentsView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.smartGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.peopleView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
		private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
		private Data.UI.Grid.SmartGrid smartGrid1;
		private Data.UI.Grid.SmartGridView peopleView;
		private DesignerBinder designerBinder1;
		private Data.UI.Grid.SmartGridColumn colHisName;
		private Data.UI.Grid.SmartGridColumn colHerName;
		private Data.UI.Grid.SmartGridColumn colLastName;
		private Data.UI.Grid.SmartGridColumn colFullName;
		private Data.UI.Grid.SmartGridColumn colAddress;
		private Data.UI.Grid.SmartGridColumn colCity;
		private Data.UI.Grid.SmartGridColumn colState;
		private Data.UI.Grid.SmartGridColumn colZip;
		private Data.UI.Grid.SmartGridColumn colPhone;
		private Data.UI.Grid.SmartGridColumn colPerson;
		private Data.UI.Grid.SmartGridColumn colStagedPersonId;
		private Data.UI.Grid.SmartGridView paymentsView;
		private Data.UI.Grid.SmartGridColumn colDate;
		private Data.UI.Grid.SmartGridColumn colMethod;
		private Data.UI.Grid.SmartGridColumn colCheckNumber;
		private Data.UI.Grid.SmartGridColumn colAccount;
		private Data.UI.Grid.SmartGridColumn colAmount;
		private Data.UI.Grid.SmartGridColumn colComments;
		private Data.UI.Grid.SmartGridColumn colCompany;
		private Data.UI.Grid.SmartGridColumn colStagedPaymentId;
		private Data.UI.Grid.SmartGridColumn colStagedPerson;
		private DevExpress.XtraBars.BarListItem importSources;
		private DevExpress.XtraBars.BarButtonItem clearStaging;
	}
}