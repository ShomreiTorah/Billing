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
			DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
			this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
			this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.smartGrid1 = new ShomreiTorah.Data.UI.Grid.SmartGrid();
			this.peopleView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.designerBinder1 = new ShomreiTorah.Billing.Migrator.Forms.DesignerBinder();
			this.colStagedPersonId = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colPerson = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colHisName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colHerName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colLastName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colFullName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAddress = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colCity = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colState = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colZip = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colPhone = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.paymentsView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colStagedPaymentId = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colStagedPerson = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colDate = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colMethod = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colCheckNumber = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAccount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAmount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colComments = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colCompany = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.smartGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.peopleView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentsView)).BeginInit();
			this.SuspendLayout();
			// 
			// ribbonControl1
			// 
			this.ribbonControl1.ExpandCollapseItem.Id = 0;
			this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem});
			this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
			this.ribbonControl1.MaxItemId = 1;
			this.ribbonControl1.Name = "ribbonControl1";
			this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
			this.ribbonControl1.Size = new System.Drawing.Size(845, 139);
			// 
			// ribbonPage1
			// 
			this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
			this.ribbonPage1.Name = "ribbonPage1";
			this.ribbonPage1.Text = "ribbonPage1";
			// 
			// ribbonPageGroup1
			// 
			this.ribbonPageGroup1.Name = "ribbonPageGroup1";
			this.ribbonPageGroup1.Text = "ribbonPageGroup1";
			// 
			// smartGrid1
			// 
			this.smartGrid1.DataMember = "StagedPeople";
			this.smartGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			gridLevelNode1.LevelTemplate = this.paymentsView;
			gridLevelNode1.RelationName = "StagedPayments";
			this.smartGrid1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
			this.smartGrid1.Location = new System.Drawing.Point(0, 139);
			this.smartGrid1.MainView = this.peopleView;
			this.smartGrid1.Name = "smartGrid1";
			this.smartGrid1.RegistrationCount = 56;
			this.smartGrid1.Size = new System.Drawing.Size(845, 333);
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
			// colStagedPersonId
			// 
			this.colStagedPersonId.FieldName = "StagedPersonId";
			this.colStagedPersonId.Name = "colStagedPersonId";
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
			// 
			// colHisName
			// 
			this.colHisName.FieldName = "HisName";
			this.colHisName.Name = "colHisName";
			this.colHisName.Visible = true;
			this.colHisName.VisibleIndex = 0;
			// 
			// colHerName
			// 
			this.colHerName.FieldName = "HerName";
			this.colHerName.Name = "colHerName";
			this.colHerName.Visible = true;
			this.colHerName.VisibleIndex = 1;
			// 
			// colLastName
			// 
			this.colLastName.FieldName = "LastName";
			this.colLastName.Name = "colLastName";
			this.colLastName.Visible = true;
			this.colLastName.VisibleIndex = 2;
			// 
			// colFullName
			// 
			this.colFullName.FieldName = "FullName";
			this.colFullName.Name = "colFullName";
			this.colFullName.Visible = true;
			this.colFullName.VisibleIndex = 3;
			// 
			// colAddress
			// 
			this.colAddress.FieldName = "Address";
			this.colAddress.Name = "colAddress";
			this.colAddress.Visible = true;
			this.colAddress.VisibleIndex = 4;
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
			// ImportForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(845, 472);
			this.Controls.Add(this.smartGrid1);
			this.Controls.Add(this.ribbonControl1);
			this.Name = "ImportForm";
			this.Text = "ImportForm";
			((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.smartGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.peopleView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentsView)).EndInit();
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
	}
}