using DevExpress.XtraEditors;
namespace ShomreiTorah.Billing.Events.Purim {
	partial class ShalachManosForm {
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
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShalachManosForm));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
			this.searchLookup = new ShomreiTorah.WinForms.Controls.Lookup.ItemSelector();
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
			this.colComments = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colModified = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colModifier = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colPledgeId = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.personSelector = new ShomreiTorah.Data.UI.Controls.PersonSelector();
			this.amount = new DevExpress.XtraEditors.SpinEdit();
			this.addPanel = new DevExpress.XtraLayout.LayoutControl();
			this.checkNumber = new DevExpress.XtraEditors.TextEdit();
			this.checkDate = new DevExpress.XtraEditors.DateEdit();
			this.comments = new DevExpress.XtraEditors.MemoEdit();
			this.paymentMethod = new DevExpress.XtraEditors.RadioGroup();
			this.add = new DevExpress.XtraEditors.SimpleButton();
			this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.checkGroup = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.searchLookup.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.accountEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.currencyEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.personSelector.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.amount.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.addPanel)).BeginInit();
			this.addPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.checkNumber.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkDate.Properties.VistaTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comments.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentMethod.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkGroup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
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
			this.ribbon.Size = new System.Drawing.Size(899, 114);
			// 
			// searchLookup
			// 
			this.searchLookup.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.searchLookup.Location = new System.Drawing.Point(0, 641);
			this.searchLookup.Name = "searchLookup";
			this.searchLookup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
			this.searchLookup.Properties.NullValuePrompt = "Click to search the list";
			this.searchLookup.Size = new System.Drawing.Size(899, 20);
			this.searchLookup.TabIndex = 3;
			this.searchLookup.EditValueChanged += new System.EventHandler(this.searchLookup_EditValueChanged);
			// 
			// grid
			// 
			this.grid.DataMember = "Pledges";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 190);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.RegistrationCount = 38;
			this.grid.Size = new System.Drawing.Size(899, 451);
			this.grid.TabIndex = 2;
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
            this.colModifier,
            this.colPledgeId});
			this.gridView.GridControl = this.grid;
			this.gridView.Name = "gridView";
			this.gridView.OptionsView.ShowFooter = true;
			this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFullName, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
			this.gridView.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
			// 
			// colFullName
			// 
			this.colFullName.Caption = "Full Name";
			this.colFullName.FieldName = "Person";
			this.colFullName.Name = "colFullName";
			this.colFullName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
			this.colFullName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.colFullName.OptionsColumn.ReadOnly = true;
			this.colFullName.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colFullName.ShowEditorOnMouseDown = true;
			this.colFullName.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
			this.colFullName.SummaryItem.DisplayFormat = "{0} People";
			this.colFullName.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
			this.colFullName.Visible = true;
			this.colFullName.VisibleIndex = 0;
			this.colFullName.Width = 78;
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
			this.colSubType.Caption = "Subtype";
			this.colSubType.FieldName = "SubType";
			this.colSubType.Name = "colSubType";
			this.colSubType.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
			this.colSubType.Visible = true;
			this.colSubType.VisibleIndex = 3;
			this.colSubType.Width = 59;
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
			this.colNote.FieldName = "Note";
			this.colNote.Name = "colNote";
			this.colNote.Visible = true;
			this.colNote.VisibleIndex = 6;
			this.colNote.Width = 42;
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
			this.colModified.FieldName = "Modified";
			this.colModified.Name = "colModified";
			this.colModified.OptionsColumn.AllowEdit = false;
			this.colModified.OptionsColumn.ReadOnly = true;
			this.colModified.Width = 128;
			// 
			// colModifier
			// 
			this.colModifier.FieldName = "Modifier";
			this.colModifier.Name = "colModifier";
			this.colModifier.OptionsColumn.AllowEdit = false;
			this.colModifier.OptionsColumn.ReadOnly = true;
			this.colModifier.Width = 47;
			// 
			// colPledgeId
			// 
			this.colPledgeId.FieldName = "PledgeId";
			this.colPledgeId.Name = "colPledgeId";
			this.colPledgeId.OptionsColumn.ShowInCustomizationForm = false;
			this.colPledgeId.Width = 54;
			// 
			// personSelector
			// 
			this.personSelector.Dock = System.Windows.Forms.DockStyle.Top;
			this.personSelector.Location = new System.Drawing.Point(0, 114);
			this.personSelector.Name = "personSelector";
			toolTipItem1.Text = "Click to select a person";
			superToolTip1.Items.Add(toolTipItem1);
			toolTipTitleItem1.Text = "New Person...";
			toolTipItem2.Text = "Adds a new person to the master directory";
			superToolTip2.Items.Add(toolTipTitleItem1);
			superToolTip2.Items.Add(toolTipItem2);
			this.personSelector.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, superToolTip1, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "New person...", 90, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleLeft, ((System.Drawing.Image)(resources.GetObject("personSelector.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, superToolTip2, true)});
			this.personSelector.Size = new System.Drawing.Size(899, 20);
			this.personSelector.TabIndex = 0;
			this.personSelector.PersonSelecting += new System.EventHandler<ShomreiTorah.Data.UI.Controls.PersonSelectingEventArgs>(this.personSelector_PersonSelecting);
			this.personSelector.EditValueChanged += new System.EventHandler(this.personSelector_EditValueChanged);
			// 
			// amount
			// 
			this.amount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.amount.Location = new System.Drawing.Point(88, 2);
			this.amount.MaximumSize = new System.Drawing.Size(90, 20);
			this.amount.Name = "amount";
			this.amount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.amount.Properties.DisplayFormat.FormatString = "c";
			this.amount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.amount.Properties.EditFormat.FormatString = "c";
			this.amount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.amount.Properties.Mask.EditMask = "c";
			this.amount.Size = new System.Drawing.Size(90, 20);
			this.amount.StyleController = this.addPanel;
			this.amount.TabIndex = 0;
			this.amount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			// 
			// addPanel
			// 
			this.addPanel.Controls.Add(this.checkNumber);
			this.addPanel.Controls.Add(this.checkDate);
			this.addPanel.Controls.Add(this.comments);
			this.addPanel.Controls.Add(this.amount);
			this.addPanel.Controls.Add(this.paymentMethod);
			this.addPanel.Controls.Add(this.add);
			this.addPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.addPanel.Location = new System.Drawing.Point(0, 134);
			this.addPanel.Name = "addPanel";
			this.addPanel.Root = this.layoutControlGroup1;
			this.addPanel.Size = new System.Drawing.Size(899, 56);
			this.addPanel.TabIndex = 1;
			this.addPanel.Text = "layoutControl1";
			// 
			// checkNumber
			// 
			this.checkNumber.Location = new System.Drawing.Point(259, 26);
			this.checkNumber.Name = "checkNumber";
			this.checkNumber.Size = new System.Drawing.Size(80, 20);
			this.checkNumber.StyleController = this.addPanel;
			this.checkNumber.TabIndex = 3;
			this.checkNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			// 
			// checkDate
			// 
			this.checkDate.EditValue = null;
			this.checkDate.Location = new System.Drawing.Point(259, 2);
			this.checkDate.Name = "checkDate";
			this.checkDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.checkDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
			this.checkDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.checkDate.Size = new System.Drawing.Size(80, 20);
			this.checkDate.StyleController = this.addPanel;
			this.checkDate.TabIndex = 2;
			this.checkDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			// 
			// comments
			// 
			this.comments.Location = new System.Drawing.Point(343, 2);
			this.comments.Name = "comments";
			this.comments.Properties.NullValuePrompt = "Comments (This will not appear on the bill)";
			this.comments.Size = new System.Drawing.Size(484, 52);
			this.comments.StyleController = this.addPanel;
			this.comments.TabIndex = 4;
			// 
			// paymentMethod
			// 
			this.paymentMethod.Location = new System.Drawing.Point(2, 27);
			this.paymentMethod.Name = "paymentMethod";
			this.paymentMethod.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.paymentMethod.Properties.Appearance.Options.UseBackColor = true;
			this.paymentMethod.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.paymentMethod.Properties.EnableFocusRect = true;
			this.paymentMethod.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Unpaid", "&Unpaid"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Cash", "Ca&sh"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Check", "&Check")});
			this.paymentMethod.Size = new System.Drawing.Size(176, 27);
			this.paymentMethod.StyleController = this.addPanel;
			this.paymentMethod.TabIndex = 1;
			this.paymentMethod.SelectedIndexChanged += new System.EventHandler(this.paymentMethod_SelectedIndexChanged);
			this.paymentMethod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			// 
			// add
			// 
			this.add.Image = global::ShomreiTorah.Billing.Properties.Resources.Add24;
			this.add.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
			this.add.Location = new System.Drawing.Point(831, 2);
			this.add.MinimumSize = new System.Drawing.Size(32, 53);
			this.add.Name = "add";
			this.add.Size = new System.Drawing.Size(66, 53);
			this.add.StyleController = this.addPanel;
			this.add.TabIndex = 5;
			this.add.Text = "Add Pledge";
			this.add.Click += new System.EventHandler(this.add_Click);
			// 
			// layoutControlGroup1
			// 
			this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
			this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.layoutControlGroup1.GroupBordersVisible = false;
			this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlGroup2,
            this.checkGroup});
			this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup1.Name = "layoutControlGroup1";
			this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.layoutControlGroup1.Size = new System.Drawing.Size(899, 56);
			this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.layoutControlGroup1.Text = "layoutControlGroup1";
			this.layoutControlGroup1.TextVisible = false;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.comments;
			this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
			this.layoutControlItem3.Location = new System.Drawing.Point(341, 0);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(488, 56);
			this.layoutControlItem3.Text = "layoutControlItem3";
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextToControlDistance = 0;
			this.layoutControlItem3.TextVisible = false;
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.add;
			this.layoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
			this.layoutControlItem4.Location = new System.Drawing.Point(829, 0);
			this.layoutControlItem4.MaxSize = new System.Drawing.Size(70, 26);
			this.layoutControlItem4.MinSize = new System.Drawing.Size(70, 26);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(70, 56);
			this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem4.Text = "layoutControlItem4";
			this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem4.TextToControlDistance = 0;
			this.layoutControlItem4.TextVisible = false;
			// 
			// layoutControlGroup2
			// 
			this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
			this.layoutControlGroup2.GroupBordersVisible = false;
			this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1});
			this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup2.Name = "layoutControlGroup2";
			this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.layoutControlGroup2.ShowInCustomizationForm = false;
			this.layoutControlGroup2.ShowTabPageCloseButton = true;
			this.layoutControlGroup2.Size = new System.Drawing.Size(180, 56);
			this.layoutControlGroup2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.layoutControlGroup2.Text = "layoutControlGroup2";
			this.layoutControlGroup2.TextVisible = false;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.paymentMethod;
			this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 25);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(180, 31);
			this.layoutControlItem2.Text = "layoutControlItem2";
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextToControlDistance = 0;
			this.layoutControlItem2.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.amount;
			this.layoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.MiddleRight;
			this.layoutControlItem1.CustomizationFormText = "Amount:";
			this.layoutControlItem1.FillControlToClientArea = false;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.MaxSize = new System.Drawing.Size(180, 0);
			this.layoutControlItem1.MinSize = new System.Drawing.Size(180, 24);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(180, 25);
			this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem1.Text = "Amount:";
			this.layoutControlItem1.TextSize = new System.Drawing.Size(73, 13);
			// 
			// checkGroup
			// 
			this.checkGroup.CustomizationFormText = "checkGroup";
			this.checkGroup.GroupBordersVisible = false;
			this.checkGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.layoutControlItem5});
			this.checkGroup.Location = new System.Drawing.Point(180, 0);
			this.checkGroup.Name = "checkGroup";
			this.checkGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.checkGroup.Size = new System.Drawing.Size(161, 56);
			this.checkGroup.Text = "checkGroup";
			this.checkGroup.TextVisible = false;
			// 
			// layoutControlItem6
			// 
			this.layoutControlItem6.Control = this.checkNumber;
			this.layoutControlItem6.CustomizationFormText = "Check Number:";
			this.layoutControlItem6.Location = new System.Drawing.Point(0, 24);
			this.layoutControlItem6.Name = "layoutControlItem6";
			this.layoutControlItem6.Size = new System.Drawing.Size(161, 32);
			this.layoutControlItem6.Text = "Check Number:";
			this.layoutControlItem6.TextSize = new System.Drawing.Size(73, 13);
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.checkDate;
			this.layoutControlItem5.CustomizationFormText = "Check Date:";
			this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem5.MaxSize = new System.Drawing.Size(161, 24);
			this.layoutControlItem5.MinSize = new System.Drawing.Size(161, 24);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.Size = new System.Drawing.Size(161, 24);
			this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem5.Text = "Check Date:";
			this.layoutControlItem5.TextSize = new System.Drawing.Size(73, 13);
			// 
			// ShalachManosForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(899, 661);
			this.Controls.Add(this.grid);
			this.Controls.Add(this.addPanel);
			this.Controls.Add(this.personSelector);
			this.Controls.Add(this.searchLookup);
			this.MainView = this.gridView;
			this.Name = "ShalachManosForm";
			this.Text = "Shalach Manos";
			this.Controls.SetChildIndex(this.ribbon, 0);
			this.Controls.SetChildIndex(this.searchLookup, 0);
			this.Controls.SetChildIndex(this.personSelector, 0);
			this.Controls.SetChildIndex(this.addPanel, 0);
			this.Controls.SetChildIndex(this.grid, 0);
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.searchLookup.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.accountEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.currencyEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.personSelector.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.amount.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.addPanel)).EndInit();
			this.addPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.checkNumber.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkDate.Properties.VistaTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comments.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentMethod.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkGroup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private ShomreiTorah.WinForms.Controls.Lookup.ItemSelector searchLookup;
		private Data.UI.Grid.SmartGrid grid;
		private Data.UI.Grid.SmartGridView gridView;
		private Data.UI.Grid.SmartGridColumn colFullName;
		private Data.UI.Grid.SmartGridColumn colDate;
		private Data.UI.Grid.SmartGridColumn colType;
		private Data.UI.Grid.SmartGridColumn colSubType;
		private Data.UI.Grid.SmartGridColumn colAccount;
		private Data.UI.Grid.SmartGridColumn colAmount;
		private Data.UI.Grid.SmartGridColumn colNote;
		private Data.UI.Grid.SmartGridColumn colComments;
		private Data.UI.Grid.SmartGridColumn colModified;
		private Data.UI.Grid.SmartGridColumn colModifier;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox accountEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit currencyEdit;
		private ShomreiTorah.Data.UI.Controls.PersonSelector personSelector;
		private DevExpress.XtraEditors.SpinEdit amount;
		private DevExpress.XtraEditors.RadioGroup paymentMethod;
		private DevExpress.XtraLayout.LayoutControl addPanel;
		private DevExpress.XtraEditors.MemoEdit comments;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private TextEdit checkNumber;
		private DevExpress.XtraEditors.DateEdit checkDate;
		private DevExpress.XtraEditors.SimpleButton add;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
		private Data.UI.Grid.SmartGridColumn colPledgeId;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
		private DevExpress.XtraLayout.LayoutControlGroup checkGroup;
	}
}