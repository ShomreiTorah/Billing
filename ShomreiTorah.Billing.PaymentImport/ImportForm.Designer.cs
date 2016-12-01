using ShomreiTorah.Data.UI.Controls;
using ShomreiTorah.Data.UI.Grid;
using ShomreiTorah.WinForms.Controls.Lookup;

namespace ShomreiTorah.Billing.PaymentImport {
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
			DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
			DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipItem toolTipItem7 = new DevExpress.Utils.ToolTipItem();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportForm));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip8 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem8 = new DevExpress.Utils.ToolTipItem();
			this.refresh = new DevExpress.XtraBars.BarButtonItem();
			this.importUI = new DevExpress.XtraDataLayout.DataLayoutControl();
			this.pledgeTypeTree = new ShomreiTorah.Data.UI.Controls.PledgeTypeTree();
			this.viewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.PledgeSubTypeTextEdit = new DevExpress.XtraEditors.TextEdit();
			this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
			this.startDate = new DevExpress.XtraBars.BarEditItem();
			this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
			this.import = new DevExpress.XtraBars.BarButtonItem();
			this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.PledgeTypeTextEdit = new DevExpress.XtraEditors.TextEdit();
			this.peopleGrid = new ShomreiTorah.Data.UI.Grid.SmartGrid(this.components);
			this.peopleView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colLastName1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colHisName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colHerName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colFullName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAddress1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colCity1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colState1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colZip1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colPhone1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colSource = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.availablePayments = new DevExpress.XtraGrid.GridControl();
			this.availablePaymentsView = new DevExpress.XtraGrid.Views.Layout.LayoutView();
			this.colFirstName = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
			this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
			this.layoutViewField_colFirstName = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
			this.colLastName = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
			this.layoutViewField_colLastName = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
			this.colDate = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
			this.layoutViewField_colDate = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
			this.colAmount = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
			this.layoutViewField_colAmount = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
			this.colFinalFour = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
			this.layoutViewField_colFinalFour = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
			this.colCardIssuer = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
			this.layoutViewField_colCardIssuer = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
			this.colPledgeType = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
			this.layoutViewField_colPledgeType = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
			this.colComments = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
			this.layoutViewField_colComments = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
			this.colCompany = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
			this.layoutViewField_colCompany = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
			this.colAddress = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
			this.layoutViewField_colAddress = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
			this.colCity = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
			this.layoutViewField_colCity = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
			this.colState = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
			this.layoutViewField_colState = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
			this.colZip = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
			this.layoutViewField_colZip = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
			this.colCountry = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
			this.layoutViewField_colCountry = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
			this.colPhone = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
			this.layoutViewField_colPhone = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
			this.colEmail = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
			this.layoutViewField_colEmail = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
			this.colWarning = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
			this.fieldWarning = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
			this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
			this.Group1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.CommentsMemoEdit = new DevExpress.XtraEditors.MemoEdit();
			this.CreatePledgeCheckEdit = new DevExpress.XtraEditors.CheckEdit();
			this.PledgeAmountSpinEdit = new DevExpress.XtraEditors.SpinEdit();
			this.pledgeNote = new DevExpress.XtraEditors.TextEdit();
			this.personSelector = new ShomreiTorah.Data.UI.Controls.PersonSelector();
			this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
			this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.ItemForCreatePledge = new DevExpress.XtraLayout.LayoutControlItem();
			this.ItemForPledgeAmount = new DevExpress.XtraLayout.LayoutControlItem();
			this.ItemForPledgeType = new DevExpress.XtraLayout.LayoutControlItem();
			this.ItemForPledgeSubType = new DevExpress.XtraLayout.LayoutControlItem();
			this.pledgeTypeTreeItem = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.pledgeNoteItem = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.ItemForPerson = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.ItemForComments = new DevExpress.XtraLayout.LayoutControlItem();
			this.splitterItem3 = new DevExpress.XtraLayout.SplitterItem();
			this.splitterItem2 = new DevExpress.XtraLayout.SplitterItem();
			this.emptyState = new DevExpress.XtraEditors.LabelControl();
			((System.ComponentModel.ISupportInitialize)(this.importUI)).BeginInit();
			this.importUI.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.viewModelBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PledgeSubTypeTextEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PledgeTypeTextEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.peopleGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.peopleView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.availablePayments)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.availablePaymentsView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colFirstName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colLastName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colAmount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colFinalFour)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCardIssuer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPledgeType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colComments)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCompany)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colAddress)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colState)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colZip)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCountry)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPhone)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colEmail)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.fieldWarning)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Group1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CommentsMemoEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CreatePledgeCheckEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PledgeAmountSpinEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgeNote.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.personSelector.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForCreatePledge)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForPledgeAmount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForPledgeType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForPledgeSubType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgeTypeTreeItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgeNoteItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForPerson)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForComments)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem2)).BeginInit();
			this.SuspendLayout();
			// 
			// refresh
			// 
			this.refresh.Caption = "Refresh";
			this.refresh.Glyph = global::ShomreiTorah.Billing.PaymentImport.Properties.Resources.Refresh16;
			this.refresh.Id = 2;
			this.refresh.Name = "refresh";
			toolTipTitleItem4.Text = "Refresh";
			toolTipItem5.LeftIndent = 6;
			toolTipItem5.Text = "Loads all available payments from the external source.";
			superToolTip5.Items.Add(toolTipTitleItem4);
			superToolTip5.Items.Add(toolTipItem5);
			this.refresh.SuperTip = superToolTip5;
			this.refresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.refresh_ItemClick);
			// 
			// importUI
			// 
			this.importUI.Controls.Add(this.pledgeTypeTree);
			this.importUI.Controls.Add(this.peopleGrid);
			this.importUI.Controls.Add(this.availablePayments);
			this.importUI.Controls.Add(this.CommentsMemoEdit);
			this.importUI.Controls.Add(this.CreatePledgeCheckEdit);
			this.importUI.Controls.Add(this.PledgeAmountSpinEdit);
			this.importUI.Controls.Add(this.pledgeNote);
			this.importUI.Controls.Add(this.PledgeTypeTextEdit);
			this.importUI.Controls.Add(this.PledgeSubTypeTextEdit);
			this.importUI.Controls.Add(this.personSelector);
			this.importUI.DataSource = this.viewModelBindingSource;
			this.importUI.Dock = System.Windows.Forms.DockStyle.Fill;
			this.importUI.Location = new System.Drawing.Point(0, 117);
			this.importUI.Name = "importUI";
			this.importUI.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(996, 859, 1019, 889);
			this.importUI.Root = this.layoutControlGroup1;
			this.importUI.Size = new System.Drawing.Size(1593, 739);
			this.importUI.TabIndex = 1;
			this.importUI.Text = "dataLayoutControl1";
			// 
			// pledgeTypeTree
			// 
			this.pledgeTypeTree.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.viewModelBindingSource, "CreatePledge", true));
			this.pledgeTypeTree.HideSelection = false;
			this.pledgeTypeTree.Location = new System.Drawing.Point(952, 487);
			this.pledgeTypeTree.Margin = new System.Windows.Forms.Padding(4);
			this.pledgeTypeTree.Name = "pledgeTypeTree";
			this.pledgeTypeTree.Size = new System.Drawing.Size(251, 215);
			this.pledgeTypeTree.SubTypeField = this.PledgeSubTypeTextEdit;
			this.pledgeTypeTree.TabIndex = 13;
			this.pledgeTypeTree.TypeField = this.PledgeTypeTextEdit;
			// 
			// viewModelBindingSource
			// 
			this.viewModelBindingSource.DataSource = typeof(ShomreiTorah.Billing.PaymentImport.ViewModel);
			// 
			// PledgeSubTypeTextEdit
			// 
			this.PledgeSubTypeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.viewModelBindingSource, "PledgeSubType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.PledgeSubTypeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.viewModelBindingSource, "CreatePledge", true));
			this.PledgeSubTypeTextEdit.Location = new System.Drawing.Point(1383, 644);
			this.PledgeSubTypeTextEdit.MenuManager = this.ribbonControl1;
			this.PledgeSubTypeTextEdit.Name = "PledgeSubTypeTextEdit";
			this.PledgeSubTypeTextEdit.Size = new System.Drawing.Size(173, 26);
			this.PledgeSubTypeTextEdit.StyleController = this.importUI;
			this.PledgeSubTypeTextEdit.TabIndex = 8;
			// 
			// ribbonControl1
			// 
			this.ribbonControl1.AllowMinimizeRibbon = false;
			this.ribbonControl1.DrawGroupCaptions = DevExpress.Utils.DefaultBoolean.False;
			this.ribbonControl1.ExpandCollapseItem.Id = 0;
			this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
			this.ribbonControl1.ExpandCollapseItem,
			this.startDate,
			this.refresh,
			this.import});
			this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
			this.ribbonControl1.MaxItemId = 2;
			this.ribbonControl1.Name = "ribbonControl1";
			this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
			this.ribbonPage1});
			this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
			this.repositoryItemDateEdit1});
			this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
			this.ribbonControl1.Size = new System.Drawing.Size(1593, 117);
			this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
			// 
			// startDate
			// 
			this.startDate.Caption = "Import payments after:";
			this.startDate.Edit = this.repositoryItemDateEdit1;
			this.startDate.EditWidth = 150;
			this.startDate.Id = 1;
			this.startDate.Name = "startDate";
			this.startDate.EditValueChanged += new System.EventHandler(this.startDate_EditValueChanged);
			// 
			// repositoryItemDateEdit1
			// 
			this.repositoryItemDateEdit1.AutoHeight = false;
			this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
			// 
			// import
			// 
			this.import.Caption = "Import";
			this.import.Enabled = false;
			this.import.Id = 3;
			this.import.LargeGlyph = global::ShomreiTorah.Billing.PaymentImport.Properties.Resources.ImportRaffle32;
			this.import.Name = "import";
			toolTipTitleItem5.Text = "Import";
			toolTipItem6.LeftIndent = 6;
			toolTipItem6.Text = "Imports this payment into the database.";
			superToolTip6.Items.Add(toolTipTitleItem5);
			superToolTip6.Items.Add(toolTipItem6);
			this.import.SuperTip = superToolTip6;
			this.import.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.import_ItemClick);
			// 
			// ribbonPage1
			// 
			this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
			this.ribbonPageGroup1});
			this.ribbonPage1.Name = "ribbonPage1";
			this.ribbonPage1.Text = "Data";
			// 
			// ribbonPageGroup1
			// 
			this.ribbonPageGroup1.ItemLinks.Add(this.startDate);
			this.ribbonPageGroup1.ItemLinks.Add(this.refresh);
			this.ribbonPageGroup1.ItemLinks.Add(this.import, true);
			this.ribbonPageGroup1.Name = "ribbonPageGroup1";
			this.ribbonPageGroup1.ShowCaptionButton = false;
			this.ribbonPageGroup1.Text = "Payments";
			// 
			// PledgeTypeTextEdit
			// 
			this.PledgeTypeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.viewModelBindingSource, "PledgeType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.PledgeTypeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.viewModelBindingSource, "CreatePledge", true));
			this.PledgeTypeTextEdit.Location = new System.Drawing.Point(1383, 612);
			this.PledgeTypeTextEdit.MenuManager = this.ribbonControl1;
			this.PledgeTypeTextEdit.Name = "PledgeTypeTextEdit";
			this.PledgeTypeTextEdit.Size = new System.Drawing.Size(173, 26);
			this.PledgeTypeTextEdit.StyleController = this.importUI;
			this.PledgeTypeTextEdit.TabIndex = 7;
			// 
			// peopleGrid
			// 
			this.peopleGrid.DataMember = "MatchingPeople";
			this.peopleGrid.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.peopleGrid.Location = new System.Drawing.Point(598, 65);
			this.peopleGrid.MainView = this.peopleView;
			this.peopleGrid.MenuManager = this.ribbonControl1;
			this.peopleGrid.Name = "peopleGrid";
			this.peopleGrid.RegistrationCount = 56;
			this.peopleGrid.Size = new System.Drawing.Size(958, 307);
			this.peopleGrid.Source = this.viewModelBindingSource;
			this.peopleGrid.TabIndex = 11;
			this.peopleGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
			this.peopleView});
			// 
			// peopleView
			// 
			this.peopleView.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.peopleView.Appearance.FocusedRow.Options.UseFont = true;
			this.peopleView.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.peopleView.Appearance.HideSelectionRow.Options.UseFont = true;
			this.peopleView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
			this.colLastName1,
			this.colHisName,
			this.colHerName,
			this.colFullName,
			this.colAddress1,
			this.colCity1,
			this.colState1,
			this.colZip1,
			this.colPhone1,
			this.colSource});
			this.peopleView.GridControl = this.peopleGrid;
			this.peopleView.Name = "peopleView";
			this.peopleView.OptionsBehavior.Editable = false;
			this.peopleView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLastName1, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.peopleView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.peopleView_RowClick);
			this.peopleView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.peopleView_CustomDrawCell);
			this.peopleView.FocusedRowObjectChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventHandler(this.peopleView_FocusedRowObjectChanged);
			// 
			// colLastName1
			// 
			this.colLastName1.FieldName = "LastName";
			this.colLastName1.Name = "colLastName1";
			this.colLastName1.Visible = true;
			this.colLastName1.VisibleIndex = 0;
			this.colLastName1.Width = 121;
			// 
			// colHisName
			// 
			this.colHisName.FieldName = "HisName";
			this.colHisName.Name = "colHisName";
			this.colHisName.Visible = true;
			this.colHisName.VisibleIndex = 1;
			this.colHisName.Width = 97;
			// 
			// colHerName
			// 
			this.colHerName.FieldName = "HerName";
			this.colHerName.Name = "colHerName";
			this.colHerName.Visible = true;
			this.colHerName.VisibleIndex = 2;
			this.colHerName.Width = 100;
			// 
			// colFullName
			// 
			this.colFullName.FieldName = "FullName";
			this.colFullName.Name = "colFullName";
			this.colFullName.Visible = true;
			this.colFullName.VisibleIndex = 3;
			this.colFullName.Width = 100;
			// 
			// colAddress1
			// 
			this.colAddress1.FieldName = "Address";
			this.colAddress1.Name = "colAddress1";
			this.colAddress1.Visible = true;
			this.colAddress1.VisibleIndex = 4;
			this.colAddress1.Width = 86;
			// 
			// colCity1
			// 
			this.colCity1.FieldName = "City";
			this.colCity1.Name = "colCity1";
			this.colCity1.Visible = true;
			this.colCity1.VisibleIndex = 5;
			this.colCity1.Width = 56;
			// 
			// colState1
			// 
			this.colState1.FieldName = "State";
			this.colState1.Name = "colState1";
			this.colState1.Visible = true;
			this.colState1.VisibleIndex = 6;
			this.colState1.Width = 64;
			// 
			// colZip1
			// 
			this.colZip1.FieldName = "Zip";
			this.colZip1.Name = "colZip1";
			this.colZip1.Visible = true;
			this.colZip1.VisibleIndex = 7;
			this.colZip1.Width = 51;
			// 
			// colPhone1
			// 
			this.colPhone1.FieldName = "Phone";
			this.colPhone1.Name = "colPhone1";
			this.colPhone1.Visible = true;
			this.colPhone1.VisibleIndex = 8;
			this.colPhone1.Width = 73;
			// 
			// colSource
			// 
			this.colSource.FieldName = "Source";
			this.colSource.Name = "colSource";
			this.colSource.Visible = true;
			this.colSource.VisibleIndex = 9;
			this.colSource.Width = 77;
			// 
			// availablePayments
			// 
			this.availablePayments.DataMember = "AvailablePayments";
			this.availablePayments.DataSource = this.viewModelBindingSource;
			this.availablePayments.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.availablePayments.Location = new System.Drawing.Point(18, 42);
			this.availablePayments.MainView = this.availablePaymentsView;
			this.availablePayments.MenuManager = this.ribbonControl1;
			this.availablePayments.Name = "availablePayments";
			this.availablePayments.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
			this.repositoryItemMemoEdit1});
			this.availablePayments.Size = new System.Drawing.Size(546, 679);
			this.availablePayments.TabIndex = 10;
			this.availablePayments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
			this.availablePaymentsView});
			// 
			// availablePaymentsView
			// 
			this.availablePaymentsView.Appearance.CardCaption.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.availablePaymentsView.Appearance.CardCaption.Options.UseFont = true;
			this.availablePaymentsView.Appearance.HideSelectionCardCaption.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.availablePaymentsView.Appearance.HideSelectionCardCaption.Options.UseFont = true;
			this.availablePaymentsView.Appearance.SelectedCardCaption.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.availablePaymentsView.Appearance.SelectedCardCaption.Options.UseFont = true;
			this.availablePaymentsView.CardCaptionFormat = "{2} {3} (#{0} of {1})";
			this.availablePaymentsView.CardMinSize = new System.Drawing.Size(280, 539);
			this.availablePaymentsView.CardVertInterval = 20;
			this.availablePaymentsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
			this.colFirstName,
			this.colLastName,
			this.colDate,
			this.colAmount,
			this.colFinalFour,
			this.colCardIssuer,
			this.colPledgeType,
			this.colComments,
			this.colCompany,
			this.colAddress,
			this.colCity,
			this.colState,
			this.colZip,
			this.colCountry,
			this.colPhone,
			this.colEmail,
			this.colWarning});
			this.availablePaymentsView.GridControl = this.availablePayments;
			this.availablePaymentsView.Name = "availablePaymentsView";
			this.availablePaymentsView.OptionsBehavior.AllowExpandCollapse = false;
			this.availablePaymentsView.OptionsBehavior.Editable = false;
			this.availablePaymentsView.OptionsSingleRecordMode.StretchCardToViewWidth = true;
			this.availablePaymentsView.OptionsView.CardArrangeRule = DevExpress.XtraGrid.Views.Layout.LayoutCardArrangeRule.AllowPartialCards;
			this.availablePaymentsView.OptionsView.ShowHeaderPanel = false;
			this.availablePaymentsView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
			new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDate, DevExpress.Data.ColumnSortOrder.Descending)});
			this.availablePaymentsView.TemplateCard = this.layoutViewCard1;
			this.availablePaymentsView.VisibleRecordIndexChanged += new DevExpress.XtraGrid.Views.Layout.Events.LayoutViewVisibleRecordIndexChangedEventHandler(this.availablePaymentsView_VisibleRecordIndexChanged);
			this.availablePaymentsView.CustomCardLayout += new DevExpress.XtraGrid.Views.Layout.Events.LayoutViewCustomCardLayoutEventHandler(this.availablePaymentsView_CustomCardLayout);
			this.availablePaymentsView.CustomDrawCardCaption += new DevExpress.XtraGrid.Views.Layout.Events.LayoutViewCustomDrawCardCaptionEventHandler(this.availablePaymentsView_CustomDrawCardCaption);
			// 
			// colFirstName
			// 
			this.colFirstName.ColumnEdit = this.repositoryItemMemoEdit1;
			this.colFirstName.FieldName = "FirstName";
			this.colFirstName.LayoutViewField = this.layoutViewField_colFirstName;
			this.colFirstName.Name = "colFirstName";
			// 
			// repositoryItemMemoEdit1
			// 
			this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
			// 
			// layoutViewField_colFirstName
			// 
			this.layoutViewField_colFirstName.EditorPreferredWidth = 208;
			this.layoutViewField_colFirstName.Location = new System.Drawing.Point(0, 0);
			this.layoutViewField_colFirstName.Name = "layoutViewField_colFirstName";
			this.layoutViewField_colFirstName.Size = new System.Drawing.Size(214, 32);
			this.layoutViewField_colFirstName.TextSize = new System.Drawing.Size(0, 0);
			this.layoutViewField_colFirstName.TextVisible = false;
			// 
			// colLastName
			// 
			this.colLastName.FieldName = "LastName";
			this.colLastName.LayoutViewField = this.layoutViewField_colLastName;
			this.colLastName.Name = "colLastName";
			// 
			// layoutViewField_colLastName
			// 
			this.layoutViewField_colLastName.EditorPreferredWidth = 208;
			this.layoutViewField_colLastName.Location = new System.Drawing.Point(214, 0);
			this.layoutViewField_colLastName.Name = "layoutViewField_colLastName";
			this.layoutViewField_colLastName.Size = new System.Drawing.Size(214, 32);
			this.layoutViewField_colLastName.TextSize = new System.Drawing.Size(0, 0);
			this.layoutViewField_colLastName.TextVisible = false;
			// 
			// colDate
			// 
			this.colDate.FieldName = "Date";
			this.colDate.LayoutViewField = this.layoutViewField_colDate;
			this.colDate.Name = "colDate";
			// 
			// layoutViewField_colDate
			// 
			this.layoutViewField_colDate.EditorPreferredWidth = 362;
			this.layoutViewField_colDate.Location = new System.Drawing.Point(0, 65);
			this.layoutViewField_colDate.Name = "layoutViewField_colDate";
			this.layoutViewField_colDate.Size = new System.Drawing.Size(466, 32);
			this.layoutViewField_colDate.TextSize = new System.Drawing.Size(114, 19);
			// 
			// colAmount
			// 
			this.colAmount.DisplayFormat.FormatString = "c";
			this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colAmount.FieldName = "Amount";
			this.colAmount.LayoutViewField = this.layoutViewField_colAmount;
			this.colAmount.Name = "colAmount";
			// 
			// layoutViewField_colAmount
			// 
			this.layoutViewField_colAmount.EditorPreferredWidth = 362;
			this.layoutViewField_colAmount.Location = new System.Drawing.Point(0, 97);
			this.layoutViewField_colAmount.Name = "layoutViewField_colAmount";
			this.layoutViewField_colAmount.Size = new System.Drawing.Size(466, 32);
			this.layoutViewField_colAmount.TextSize = new System.Drawing.Size(114, 19);
			// 
			// colFinalFour
			// 
			this.colFinalFour.FieldName = "FinalFour";
			this.colFinalFour.LayoutViewField = this.layoutViewField_colFinalFour;
			this.colFinalFour.Name = "colFinalFour";
			// 
			// layoutViewField_colFinalFour
			// 
			this.layoutViewField_colFinalFour.EditorPreferredWidth = 129;
			this.layoutViewField_colFinalFour.Location = new System.Drawing.Point(233, 129);
			this.layoutViewField_colFinalFour.Name = "layoutViewField_colFinalFour";
			this.layoutViewField_colFinalFour.Size = new System.Drawing.Size(233, 32);
			this.layoutViewField_colFinalFour.TextSize = new System.Drawing.Size(114, 19);
			// 
			// colCardIssuer
			// 
			this.colCardIssuer.FieldName = "CardIssuer";
			this.colCardIssuer.LayoutViewField = this.layoutViewField_colCardIssuer;
			this.colCardIssuer.Name = "colCardIssuer";
			// 
			// layoutViewField_colCardIssuer
			// 
			this.layoutViewField_colCardIssuer.EditorPreferredWidth = 129;
			this.layoutViewField_colCardIssuer.Location = new System.Drawing.Point(0, 129);
			this.layoutViewField_colCardIssuer.Name = "layoutViewField_colCardIssuer";
			this.layoutViewField_colCardIssuer.Size = new System.Drawing.Size(233, 32);
			this.layoutViewField_colCardIssuer.TextSize = new System.Drawing.Size(114, 19);
			// 
			// colPledgeType
			// 
			this.colPledgeType.FieldName = "PledgeType";
			this.colPledgeType.LayoutViewField = this.layoutViewField_colPledgeType;
			this.colPledgeType.Name = "colPledgeType";
			// 
			// layoutViewField_colPledgeType
			// 
			this.layoutViewField_colPledgeType.EditorPreferredWidth = 362;
			this.layoutViewField_colPledgeType.Location = new System.Drawing.Point(0, 161);
			this.layoutViewField_colPledgeType.Name = "layoutViewField_colPledgeType";
			this.layoutViewField_colPledgeType.Size = new System.Drawing.Size(466, 32);
			this.layoutViewField_colPledgeType.TextSize = new System.Drawing.Size(114, 19);
			// 
			// colComments
			// 
			this.colComments.ColumnEdit = this.repositoryItemMemoEdit1;
			this.colComments.FieldName = "Comments";
			this.colComments.LayoutViewField = this.layoutViewField_colComments;
			this.colComments.Name = "colComments";
			// 
			// layoutViewField_colComments
			// 
			this.layoutViewField_colComments.EditorPreferredWidth = 362;
			this.layoutViewField_colComments.Location = new System.Drawing.Point(0, 193);
			this.layoutViewField_colComments.Name = "layoutViewField_colComments";
			this.layoutViewField_colComments.Size = new System.Drawing.Size(466, 29);
			this.layoutViewField_colComments.TextSize = new System.Drawing.Size(114, 19);
			// 
			// colCompany
			// 
			this.colCompany.FieldName = "Company";
			this.colCompany.LayoutViewField = this.layoutViewField_colCompany;
			this.colCompany.Name = "colCompany";
			// 
			// layoutViewField_colCompany
			// 
			this.layoutViewField_colCompany.EditorPreferredWidth = 344;
			this.layoutViewField_colCompany.Location = new System.Drawing.Point(0, 96);
			this.layoutViewField_colCompany.Name = "layoutViewField_colCompany";
			this.layoutViewField_colCompany.Size = new System.Drawing.Size(428, 32);
			this.layoutViewField_colCompany.TextSize = new System.Drawing.Size(73, 19);
			// 
			// colAddress
			// 
			this.colAddress.FieldName = "Address";
			this.colAddress.LayoutViewField = this.layoutViewField_colAddress;
			this.colAddress.Name = "colAddress";
			// 
			// layoutViewField_colAddress
			// 
			this.layoutViewField_colAddress.EditorPreferredWidth = 422;
			this.layoutViewField_colAddress.Location = new System.Drawing.Point(0, 32);
			this.layoutViewField_colAddress.Name = "layoutViewField_colAddress";
			this.layoutViewField_colAddress.Size = new System.Drawing.Size(428, 32);
			this.layoutViewField_colAddress.TextSize = new System.Drawing.Size(0, 0);
			this.layoutViewField_colAddress.TextVisible = false;
			// 
			// colCity
			// 
			this.colCity.FieldName = "City";
			this.colCity.LayoutViewField = this.layoutViewField_colCity;
			this.colCity.Name = "colCity";
			// 
			// layoutViewField_colCity
			// 
			this.layoutViewField_colCity.EditorPreferredWidth = 137;
			this.layoutViewField_colCity.Location = new System.Drawing.Point(0, 64);
			this.layoutViewField_colCity.Name = "layoutViewField_colCity";
			this.layoutViewField_colCity.Size = new System.Drawing.Size(143, 32);
			this.layoutViewField_colCity.TextSize = new System.Drawing.Size(0, 0);
			this.layoutViewField_colCity.TextVisible = false;
			// 
			// colState
			// 
			this.colState.FieldName = "State";
			this.colState.LayoutViewField = this.layoutViewField_colState;
			this.colState.Name = "colState";
			// 
			// layoutViewField_colState
			// 
			this.layoutViewField_colState.EditorPreferredWidth = 136;
			this.layoutViewField_colState.Location = new System.Drawing.Point(143, 64);
			this.layoutViewField_colState.Name = "layoutViewField_colState";
			this.layoutViewField_colState.Size = new System.Drawing.Size(142, 32);
			this.layoutViewField_colState.TextSize = new System.Drawing.Size(0, 0);
			this.layoutViewField_colState.TextVisible = false;
			// 
			// colZip
			// 
			this.colZip.FieldName = "Zip";
			this.colZip.LayoutViewField = this.layoutViewField_colZip;
			this.colZip.Name = "colZip";
			// 
			// layoutViewField_colZip
			// 
			this.layoutViewField_colZip.EditorPreferredWidth = 137;
			this.layoutViewField_colZip.Location = new System.Drawing.Point(285, 64);
			this.layoutViewField_colZip.Name = "layoutViewField_colZip";
			this.layoutViewField_colZip.Size = new System.Drawing.Size(143, 32);
			this.layoutViewField_colZip.TextSize = new System.Drawing.Size(0, 0);
			this.layoutViewField_colZip.TextVisible = false;
			// 
			// colCountry
			// 
			this.colCountry.FieldName = "Country";
			this.colCountry.LayoutViewField = this.layoutViewField_colCountry;
			this.colCountry.Name = "colCountry";
			// 
			// layoutViewField_colCountry
			// 
			this.layoutViewField_colCountry.EditorPreferredWidth = 344;
			this.layoutViewField_colCountry.Location = new System.Drawing.Point(0, 128);
			this.layoutViewField_colCountry.Name = "layoutViewField_colCountry";
			this.layoutViewField_colCountry.Size = new System.Drawing.Size(428, 32);
			this.layoutViewField_colCountry.TextSize = new System.Drawing.Size(73, 19);
			// 
			// colPhone
			// 
			this.colPhone.FieldName = "Phone";
			this.colPhone.LayoutViewField = this.layoutViewField_colPhone;
			this.colPhone.Name = "colPhone";
			// 
			// layoutViewField_colPhone
			// 
			this.layoutViewField_colPhone.EditorPreferredWidth = 362;
			this.layoutViewField_colPhone.Location = new System.Drawing.Point(0, 448);
			this.layoutViewField_colPhone.Name = "layoutViewField_colPhone";
			this.layoutViewField_colPhone.Size = new System.Drawing.Size(466, 32);
			this.layoutViewField_colPhone.TextSize = new System.Drawing.Size(114, 19);
			// 
			// colEmail
			// 
			this.colEmail.FieldName = "Email";
			this.colEmail.LayoutViewField = this.layoutViewField_colEmail;
			this.colEmail.Name = "colEmail";
			// 
			// layoutViewField_colEmail
			// 
			this.layoutViewField_colEmail.EditorPreferredWidth = 362;
			this.layoutViewField_colEmail.Location = new System.Drawing.Point(0, 480);
			this.layoutViewField_colEmail.Name = "layoutViewField_colEmail";
			this.layoutViewField_colEmail.Size = new System.Drawing.Size(466, 32);
			this.layoutViewField_colEmail.TextSize = new System.Drawing.Size(114, 19);
			// 
			// colWarning
			// 
			this.colWarning.Caption = "<b>Warning</b>";
			this.colWarning.ColumnEdit = this.repositoryItemMemoEdit1;
			this.colWarning.FieldName = "Warning";
			this.colWarning.Image = global::ShomreiTorah.Billing.PaymentImport.Properties.Resources.Warning32;
			this.colWarning.LayoutViewField = this.fieldWarning;
			this.colWarning.Name = "colWarning";
			this.colWarning.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
			this.colWarning.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
			this.colWarning.OptionsField.SortFilterButtonShowMode = DevExpress.XtraGrid.Views.Layout.SortFilterButtonShowMode.Nowhere;
			this.colWarning.UnboundExpression = "\'This payment includes a journal ad.  Unless you have already entered the ad, you" +
	" should import this via the Import Ad button in the journal.\'";
			this.colWarning.UnboundType = DevExpress.Data.UnboundColumnType.String;
			// 
			// fieldWarning
			// 
			this.fieldWarning.AllowHtmlStringInCaption = true;
			this.fieldWarning.EditorPreferredWidth = 20;
			this.fieldWarning.Image = global::ShomreiTorah.Billing.PaymentImport.Properties.Resources.Warning32;
			this.fieldWarning.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
			this.fieldWarning.ImageToTextDistance = 8;
			this.fieldWarning.Location = new System.Drawing.Point(0, 0);
			this.fieldWarning.Name = "fieldWarning";
			this.fieldWarning.Size = new System.Drawing.Size(466, 65);
			this.fieldWarning.TextSize = new System.Drawing.Size(93, 59);
			// 
			// layoutViewCard1
			// 
			this.layoutViewCard1.CustomizationFormText = "TemplateCard";
			this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
			this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
			this.layoutViewField_colDate,
			this.layoutViewField_colAmount,
			this.layoutViewField_colFinalFour,
			this.layoutViewField_colPledgeType,
			this.layoutViewField_colComments,
			this.layoutViewField_colPhone,
			this.layoutViewField_colEmail,
			this.layoutViewField_colCardIssuer,
			this.Group1,
			this.fieldWarning});
			this.layoutViewCard1.Name = "layoutViewCard1";
			this.layoutViewCard1.OptionsItemText.TextToControlDistance = 5;
			this.layoutViewCard1.Text = "TemplateCard";
			// 
			// Group1
			// 
			this.Group1.CustomizationFormText = "Address";
			this.Group1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
			this.layoutViewField_colCountry,
			this.layoutViewField_colAddress,
			this.layoutViewField_colCity,
			this.layoutViewField_colState,
			this.layoutViewField_colZip,
			this.layoutViewField_colFirstName,
			this.layoutViewField_colLastName,
			this.layoutViewField_colCompany});
			this.Group1.Location = new System.Drawing.Point(0, 222);
			this.Group1.Name = "Group1";
			this.Group1.OptionsItemText.TextToControlDistance = 5;
			this.Group1.Size = new System.Drawing.Size(466, 226);
			this.Group1.Text = "Address";
			// 
			// CommentsMemoEdit
			// 
			this.CommentsMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.viewModelBindingSource, "Comments", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.CommentsMemoEdit.Location = new System.Drawing.Point(598, 511);
			this.CommentsMemoEdit.MenuManager = this.ribbonControl1;
			this.CommentsMemoEdit.Name = "CommentsMemoEdit";
			this.CommentsMemoEdit.Size = new System.Drawing.Size(301, 191);
			this.CommentsMemoEdit.StyleController = this.importUI;
			this.CommentsMemoEdit.TabIndex = 4;
			// 
			// CreatePledgeCheckEdit
			// 
			this.CreatePledgeCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.viewModelBindingSource, "CreatePledge", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.CreatePledgeCheckEdit.Location = new System.Drawing.Point(1383, 487);
			this.CreatePledgeCheckEdit.MenuManager = this.ribbonControl1;
			this.CreatePledgeCheckEdit.Name = "CreatePledgeCheckEdit";
			this.CreatePledgeCheckEdit.Properties.Caption = "Create Pledge";
			this.CreatePledgeCheckEdit.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.CreatePledgeCheckEdit.Size = new System.Drawing.Size(173, 19);
			this.CreatePledgeCheckEdit.StyleController = this.importUI;
			this.CreatePledgeCheckEdit.TabIndex = 5;
			// 
			// PledgeAmountSpinEdit
			// 
			this.PledgeAmountSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.viewModelBindingSource, "PledgeAmount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.PledgeAmountSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.viewModelBindingSource, "CreatePledge", true));
			this.PledgeAmountSpinEdit.EditValue = new decimal(new int[] {
			0,
			0,
			0,
			0});
			this.PledgeAmountSpinEdit.Location = new System.Drawing.Point(1383, 512);
			this.PledgeAmountSpinEdit.MenuManager = this.ribbonControl1;
			this.PledgeAmountSpinEdit.Name = "PledgeAmountSpinEdit";
			this.PledgeAmountSpinEdit.Properties.Appearance.Options.UseTextOptions = true;
			this.PledgeAmountSpinEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.PledgeAmountSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.PledgeAmountSpinEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
			this.PledgeAmountSpinEdit.Properties.Mask.EditMask = "C";
			this.PledgeAmountSpinEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.PledgeAmountSpinEdit.Size = new System.Drawing.Size(173, 26);
			this.PledgeAmountSpinEdit.StyleController = this.importUI;
			this.PledgeAmountSpinEdit.TabIndex = 6;
			// 
			// pledgeNote
			// 
			this.pledgeNote.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.viewModelBindingSource, "PledgeNote", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.pledgeNote.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.viewModelBindingSource, "CreatePledge", true));
			this.pledgeNote.Location = new System.Drawing.Point(1383, 676);
			this.pledgeNote.Name = "pledgeNote";
			this.pledgeNote.Properties.NullValuePrompt = "(will show on invoice)";
			this.pledgeNote.Properties.NullValuePromptShowForEmptyValue = true;
			this.pledgeNote.Properties.ShowNullValuePromptWhenFocused = true;
			this.pledgeNote.Size = new System.Drawing.Size(173, 26);
			this.pledgeNote.StyleController = this.importUI;
			this.pledgeNote.TabIndex = 7;
			// 
			// personSelector
			// 
			this.personSelector.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.viewModelBindingSource, "Person", true));
			this.personSelector.Location = new System.Drawing.Point(772, 378);
			this.personSelector.MenuManager = this.ribbonControl1;
			this.personSelector.Name = "personSelector";
			toolTipItem7.Text = "Click to select a person";
			superToolTip7.Items.Add(toolTipItem7);
			toolTipTitleItem6.Text = "New Person...";
			toolTipItem8.Text = "Adds a new person to the master directory";
			superToolTip8.Items.Add(toolTipTitleItem6);
			superToolTip8.Items.Add(toolTipItem8);
			this.personSelector.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, serializableAppearanceObject10, serializableAppearanceObject11, serializableAppearanceObject12, "", null, superToolTip7, true),
			new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "New person...", 90, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleLeft, ((System.Drawing.Image)(resources.GetObject("personSelector.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13, serializableAppearanceObject14, serializableAppearanceObject15, serializableAppearanceObject16, "", null, superToolTip8, true)});
			this.personSelector.Properties.NewPersonTemplate = null;
			this.personSelector.Size = new System.Drawing.Size(784, 28);
			this.personSelector.StyleController = this.importUI;
			this.personSelector.TabIndex = 12;
			// 
			// layoutControlGroup1
			// 
			this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.layoutControlGroup1.GroupBordersVisible = false;
			this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
			this.layoutControlItem2,
			this.splitterItem1,
			this.layoutControlGroup3,
			this.layoutControlGroup4,
			this.layoutControlGroup5,
			this.splitterItem3,
			this.splitterItem2});
			this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup1.Name = "Root";
			this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 5;
			this.layoutControlGroup1.Size = new System.Drawing.Size(1593, 739);
			this.layoutControlGroup1.TextVisible = false;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.availablePayments;
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(552, 709);
			this.layoutControlItem2.Text = "Payments to import";
			this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
			this.layoutControlItem2.TextSize = new System.Drawing.Size(169, 19);
			// 
			// splitterItem1
			// 
			this.splitterItem1.AllowHotTrack = true;
			this.splitterItem1.Location = new System.Drawing.Point(552, 0);
			this.splitterItem1.Name = "splitterItem1";
			this.splitterItem1.Size = new System.Drawing.Size(9, 709);
			// 
			// layoutControlGroup3
			// 
			this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
			this.ItemForCreatePledge,
			this.ItemForPledgeAmount,
			this.ItemForPledgeType,
			this.ItemForPledgeSubType,
			this.pledgeTypeTreeItem,
			this.emptySpaceItem1,
			this.pledgeNoteItem});
			this.layoutControlGroup3.Location = new System.Drawing.Point(915, 422);
			this.layoutControlGroup3.Name = "layoutControlGroup3";
			this.layoutControlGroup3.OptionsItemText.TextToControlDistance = 5;
			this.layoutControlGroup3.Size = new System.Drawing.Size(648, 287);
			this.layoutControlGroup3.Text = "Pledge Details";
			// 
			// ItemForCreatePledge
			// 
			this.ItemForCreatePledge.Control = this.CreatePledgeCheckEdit;
			this.ItemForCreatePledge.Location = new System.Drawing.Point(257, 0);
			this.ItemForCreatePledge.Name = "ItemForCreatePledge";
			this.ItemForCreatePledge.Size = new System.Drawing.Size(353, 25);
			this.ItemForCreatePledge.Text = "Create Pledge?";
			this.ItemForCreatePledge.TextSize = new System.Drawing.Size(169, 19);
			// 
			// ItemForPledgeAmount
			// 
			this.ItemForPledgeAmount.Control = this.PledgeAmountSpinEdit;
			this.ItemForPledgeAmount.Location = new System.Drawing.Point(257, 25);
			this.ItemForPledgeAmount.Name = "ItemForPledgeAmount";
			this.ItemForPledgeAmount.Size = new System.Drawing.Size(353, 32);
			this.ItemForPledgeAmount.Text = "Pledge Amount";
			this.ItemForPledgeAmount.TextSize = new System.Drawing.Size(169, 19);
			// 
			// ItemForPledgeType
			// 
			this.ItemForPledgeType.Control = this.PledgeTypeTextEdit;
			this.ItemForPledgeType.Location = new System.Drawing.Point(257, 125);
			this.ItemForPledgeType.Name = "ItemForPledgeType";
			this.ItemForPledgeType.Size = new System.Drawing.Size(353, 32);
			this.ItemForPledgeType.Text = "Pledge Type";
			this.ItemForPledgeType.TextSize = new System.Drawing.Size(169, 19);
			// 
			// ItemForPledgeSubType
			// 
			this.ItemForPledgeSubType.Control = this.PledgeSubTypeTextEdit;
			this.ItemForPledgeSubType.Location = new System.Drawing.Point(257, 157);
			this.ItemForPledgeSubType.Name = "ItemForPledgeSubType";
			this.ItemForPledgeSubType.Size = new System.Drawing.Size(353, 32);
			this.ItemForPledgeSubType.Text = "Pledge Subtype";
			this.ItemForPledgeSubType.TextSize = new System.Drawing.Size(169, 19);
			// 
			// pledgeTypeTreeItem
			// 
			this.pledgeTypeTreeItem.Control = this.pledgeTypeTree;
			this.pledgeTypeTreeItem.Location = new System.Drawing.Point(0, 0);
			this.pledgeTypeTreeItem.Name = "layoutControlItem1";
			this.pledgeTypeTreeItem.Size = new System.Drawing.Size(257, 221);
			this.pledgeTypeTreeItem.TextSize = new System.Drawing.Size(0, 0);
			this.pledgeTypeTreeItem.TextVisible = false;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.BestFitWeight = 10;
			this.emptySpaceItem1.Location = new System.Drawing.Point(257, 57);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.emptySpaceItem1.Size = new System.Drawing.Size(353, 68);
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// pledgeNoteItem
			// 
			this.pledgeNoteItem.Control = this.pledgeNote;
			this.pledgeNoteItem.Location = new System.Drawing.Point(257, 189);
			this.pledgeNoteItem.Name = "pledgeNoteItem";
			this.pledgeNoteItem.Size = new System.Drawing.Size(353, 32);
			this.pledgeNoteItem.Text = "Pledge Note";
			this.pledgeNoteItem.TextSize = new System.Drawing.Size(169, 19);
			// 
			// layoutControlGroup4
			// 
			this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
			this.layoutControlItem3,
			this.ItemForPerson});
			this.layoutControlGroup4.Location = new System.Drawing.Point(561, 0);
			this.layoutControlGroup4.Name = "layoutControlGroup4";
			this.layoutControlGroup4.OptionsItemText.TextToControlDistance = 5;
			this.layoutControlGroup4.Size = new System.Drawing.Size(1002, 413);
			this.layoutControlGroup4.Text = "Import to the following person:";
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
			this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
			this.layoutControlItem3.Control = this.peopleGrid;
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(964, 313);
			this.layoutControlItem3.Text = "Matching People";
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// ItemForPerson
			// 
			this.ItemForPerson.Control = this.personSelector;
			this.ItemForPerson.Location = new System.Drawing.Point(0, 313);
			this.ItemForPerson.Name = "ItemForPerson";
			this.ItemForPerson.Size = new System.Drawing.Size(964, 34);
			this.ItemForPerson.Text = "Or select someone else:";
			this.ItemForPerson.TextSize = new System.Drawing.Size(169, 19);
			// 
			// layoutControlGroup5
			// 
			this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
			this.ItemForComments});
			this.layoutControlGroup5.Location = new System.Drawing.Point(561, 422);
			this.layoutControlGroup5.Name = "layoutControlGroup5";
			this.layoutControlGroup5.OptionsItemText.TextToControlDistance = 5;
			this.layoutControlGroup5.Size = new System.Drawing.Size(345, 287);
			this.layoutControlGroup5.Text = "Payment Details";
			// 
			// ItemForComments
			// 
			this.ItemForComments.Control = this.CommentsMemoEdit;
			this.ItemForComments.Location = new System.Drawing.Point(0, 0);
			this.ItemForComments.Name = "ItemForComments";
			this.ItemForComments.Size = new System.Drawing.Size(307, 221);
			this.ItemForComments.StartNewLine = true;
			this.ItemForComments.Text = "Comments";
			this.ItemForComments.TextLocation = DevExpress.Utils.Locations.Top;
			this.ItemForComments.TextSize = new System.Drawing.Size(169, 19);
			// 
			// splitterItem3
			// 
			this.splitterItem3.AllowHotTrack = true;
			this.splitterItem3.Location = new System.Drawing.Point(906, 422);
			this.splitterItem3.Name = "splitterItem3";
			this.splitterItem3.ResizeMode = DevExpress.XtraLayout.SplitterItemResizeMode.AllSiblings;
			this.splitterItem3.Size = new System.Drawing.Size(9, 287);
			// 
			// splitterItem2
			// 
			this.splitterItem2.AllowHotTrack = true;
			this.splitterItem2.Location = new System.Drawing.Point(561, 413);
			this.splitterItem2.Name = "splitterItem2";
			this.splitterItem2.ResizeMode = DevExpress.XtraLayout.SplitterItemResizeMode.AllSiblings;
			this.splitterItem2.Size = new System.Drawing.Size(1002, 9);
			// 
			// emptyState
			// 
			this.emptyState.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
			this.emptyState.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.emptyState.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.emptyState.Dock = System.Windows.Forms.DockStyle.Fill;
			this.emptyState.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
			this.emptyState.LineVisible = true;
			this.emptyState.Location = new System.Drawing.Point(0, 117);
			this.emptyState.Name = "emptyState";
			this.emptyState.Size = new System.Drawing.Size(1593, 739);
			this.emptyState.TabIndex = 3;
			this.emptyState.Text = "label1";
			// 
			// ImportForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1593, 856);
			this.Controls.Add(this.importUI);
			this.Controls.Add(this.emptyState);
			this.Controls.Add(this.ribbonControl1);
			this.Name = "ImportForm";
			this.Text = "Import Payments";
			((System.ComponentModel.ISupportInitialize)(this.importUI)).EndInit();
			this.importUI.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.viewModelBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PledgeSubTypeTextEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PledgeTypeTextEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.peopleGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.peopleView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.availablePayments)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.availablePaymentsView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colFirstName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colLastName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colAmount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colFinalFour)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCardIssuer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPledgeType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colComments)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCompany)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colAddress)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colState)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colZip)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colCountry)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colPhone)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewField_colEmail)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.fieldWarning)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Group1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CommentsMemoEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CreatePledgeCheckEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PledgeAmountSpinEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgeNote.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.personSelector.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForCreatePledge)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForPledgeAmount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForPledgeType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForPledgeSubType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgeTypeTreeItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pledgeNoteItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForPerson)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemForComments)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
		private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
		private DevExpress.XtraBars.BarEditItem startDate;
		private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
		private DevExpress.XtraBars.BarButtonItem refresh;
		private DevExpress.XtraDataLayout.DataLayoutControl importUI;
		private DevExpress.XtraEditors.MemoEdit CommentsMemoEdit;
		private System.Windows.Forms.BindingSource viewModelBindingSource;
		private DevExpress.XtraEditors.CheckEdit CreatePledgeCheckEdit;
		private DevExpress.XtraEditors.SpinEdit PledgeAmountSpinEdit;
		private DevExpress.XtraEditors.TextEdit PledgeTypeTextEdit;
		private DevExpress.XtraEditors.TextEdit PledgeSubTypeTextEdit;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
		private DevExpress.XtraGrid.GridControl availablePayments;
		private DevExpress.XtraGrid.Views.Layout.LayoutView availablePaymentsView;
		private DevExpress.XtraGrid.Columns.LayoutViewColumn colDate;
		private DevExpress.XtraGrid.Columns.LayoutViewColumn colAmount;
		private DevExpress.XtraGrid.Columns.LayoutViewColumn colFinalFour;
		private DevExpress.XtraGrid.Columns.LayoutViewColumn colCardIssuer;
		private DevExpress.XtraGrid.Columns.LayoutViewColumn colPledgeType;
		private DevExpress.XtraGrid.Columns.LayoutViewColumn colComments;
		private DevExpress.XtraGrid.Columns.LayoutViewColumn colFirstName;
		private DevExpress.XtraGrid.Columns.LayoutViewColumn colLastName;
		private DevExpress.XtraGrid.Columns.LayoutViewColumn colCompany;
		private DevExpress.XtraGrid.Columns.LayoutViewColumn colAddress;
		private DevExpress.XtraGrid.Columns.LayoutViewColumn colCity;
		private DevExpress.XtraGrid.Columns.LayoutViewColumn colState;
		private DevExpress.XtraGrid.Columns.LayoutViewColumn colZip;
		private DevExpress.XtraGrid.Columns.LayoutViewColumn colCountry;
		private DevExpress.XtraGrid.Columns.LayoutViewColumn colPhone;
		private DevExpress.XtraGrid.Columns.LayoutViewColumn colEmail;
		private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
		private Data.UI.Grid.SmartGrid peopleGrid;
		private Data.UI.Grid.SmartGridView peopleView;
		private SmartGridColumn colLastName1;
		private SmartGridColumn colHisName;
		private SmartGridColumn colHerName;
		private SmartGridColumn colFullName;
		private SmartGridColumn colAddress1;
		private SmartGridColumn colCity1;
		private SmartGridColumn colState1;
		private SmartGridColumn colZip1;
		private SmartGridColumn colPhone1;
		private SmartGridColumn colSource;
		private PersonSelector personSelector;
		private DevExpress.XtraBars.BarButtonItem import;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.SplitterItem splitterItem1;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
		private DevExpress.XtraLayout.LayoutControlItem ItemForCreatePledge;
		private DevExpress.XtraLayout.LayoutControlItem ItemForPledgeAmount;
		private DevExpress.XtraLayout.LayoutControlItem ItemForPledgeType;
		private DevExpress.XtraLayout.LayoutControlItem ItemForPledgeSubType;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.LayoutControlItem ItemForPerson;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
		private DevExpress.XtraLayout.LayoutControlItem ItemForComments;
		private DevExpress.XtraLayout.SplitterItem splitterItem3;
		private DevExpress.XtraLayout.SplitterItem splitterItem2;
		private PledgeTypeTree pledgeTypeTree;
		private DevExpress.XtraLayout.LayoutControlItem pledgeTypeTreeItem;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraEditors.TextEdit pledgeNote;
		private DevExpress.XtraLayout.LayoutControlItem pledgeNoteItem;
		private DevExpress.XtraEditors.LabelControl emptyState;
		private DevExpress.XtraGrid.Columns.LayoutViewColumn colWarning;
		private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colFirstName;
		private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colLastName;
		private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colDate;
		private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colAmount;
		private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colFinalFour;
		private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colCardIssuer;
		private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colPledgeType;
		private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colComments;
		private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colCompany;
		private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colAddress;
		private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colCity;
		private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colState;
		private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colZip;
		private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colCountry;
		private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colPhone;
		private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_colEmail;
		private DevExpress.XtraGrid.Views.Layout.LayoutViewField fieldWarning;
		private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
		private DevExpress.XtraLayout.LayoutControlGroup Group1;
	}
}