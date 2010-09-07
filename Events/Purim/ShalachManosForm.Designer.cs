namespace ShomreiTorah.Billing.Events.Purim {
	partial class ShalachManosForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShalachManosForm));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
			this.searchLookup = new ShomreiTorah.WinForms.Controls.LookupControl();
			this.grid = new ShomreiTorah.Billing.Controls.BaseGrid(this.components);
			this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
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
			this.colPledgeId = new DevExpress.XtraGrid.Columns.GridColumn();
			this.personSelector = new ShomreiTorah.Billing.Controls.PersonSelector();
			this.amount = new DevExpress.XtraEditors.SpinEdit();
			this.addPanel = new DevExpress.XtraLayout.LayoutControl();
			this.checkNumber = new ShomreiTorah.Billing.Controls.Editors.CheckNumberEdit();
			this.checkDate = new DevExpress.XtraEditors.DateEdit();
			this.comments = new DevExpress.XtraEditors.MemoEdit();
			this.paymentMethod = new DevExpress.XtraEditors.RadioGroup();
			this.add = new DevExpress.XtraEditors.SimpleButton();
			this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.checkGroup = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.repositoryItemPersonRefEdit1 = new ShomreiTorah.Billing.Controls.Editors.RepositoryItemPersonRefEdit();
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.accountEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.currencyEdit)).BeginInit();
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
			((System.ComponentModel.ISupportInitialize)(this.checkGroup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemPersonRefEdit1)).BeginInit();
			this.SuspendLayout();
			// 
			// ribbon
			// 
			this.ribbon.Size = new System.Drawing.Size(899, 116);
			// 
			// searchLookup
			// 
			this.searchLookup.DefaultText = "Click to search the list";
			this.searchLookup.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.searchLookup.Location = new System.Drawing.Point(0, 641);
			this.searchLookup.Name = "searchLookup";
			this.searchLookup.PopupOpen = false;
			this.searchLookup.ScrollPosition = 0;
			this.searchLookup.SearchTable = null;
			this.searchLookup.Size = new System.Drawing.Size(899, 20);
			this.searchLookup.TabIndex = 3;
			this.searchLookup.TabStop = false;
			this.searchLookup.ItemSelected += new System.EventHandler<ShomreiTorah.WinForms.Controls.ItemSelectionEventArgs>(this.searchLookup_ItemSelected);
			// 
			// grid
			// 
			this.grid.DataMember = "Pledges";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 213);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPersonRefEdit1});
			this.grid.Size = new System.Drawing.Size(899, 428);
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
			// 
			// colFullName
			// 
			this.colFullName.ColumnEdit = this.repositoryItemPersonRefEdit1;
			this.colFullName.FieldName = "FullName";
			this.colFullName.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical;
			this.colFullName.Name = "colFullName";
			this.colFullName.OptionsColumn.ReadOnly = true;
			this.colFullName.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colFullName.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
			this.colFullName.SummaryItem.DisplayFormat = "{0} People";
			this.colFullName.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
			this.colFullName.Visible = true;
			this.colFullName.VisibleIndex = 0;
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
			this.colSubType.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
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
			this.colAmount.SummaryItem.DisplayFormat = "Total: {0:c}";
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
			this.colModified.FieldName = "Modified";
			this.colModified.Name = "colModified";
			this.colModified.OptionsColumn.AllowEdit = false;
			this.colModified.OptionsColumn.ReadOnly = true;
			// 
			// colModifier
			// 
			this.colModifier.FieldName = "Modifier";
			this.colModifier.Name = "colModifier";
			this.colModifier.OptionsColumn.AllowEdit = false;
			this.colModifier.OptionsColumn.ReadOnly = true;
			// 
			// colPledgeId
			// 
			this.colPledgeId.FieldName = "PledgeId";
			this.colPledgeId.Name = "colPledgeId";
			this.colPledgeId.OptionsColumn.ShowInCustomizationForm = false;
			// 
			// personSelector
			// 
			this.personSelector.Caption = "Select a person:";
			this.personSelector.DefaultText = "Please click here to select a person";
			this.personSelector.Dock = System.Windows.Forms.DockStyle.Top;
			this.personSelector.Location = new System.Drawing.Point(0, 116);
			this.personSelector.Name = "personSelector";
			this.personSelector.PopupOpen = false;
			this.personSelector.ResultsLocation = ShomreiTorah.WinForms.Controls.ResultsLocation.Bottom;
			this.personSelector.ScrollPosition = 0;
			this.personSelector.SearchTable = null;
			this.personSelector.Size = new System.Drawing.Size(899, 20);
			this.personSelector.TabIndex = 0;
			this.personSelector.TabStop = false;
			this.personSelector.Value = ((object)(resources.GetObject("personSelector.Value")));
			this.personSelector.SelectedPersonChanged += new System.EventHandler(this.personSelector_SelectedPersonChanged);
			this.personSelector.SelectingPerson += new System.EventHandler<ShomreiTorah.Billing.Controls.SelectingPersonEventArgs>(this.personSelector_SelectingPerson);
			// 
			// amount
			// 
			this.amount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.amount.Location = new System.Drawing.Point(90, 13);
			this.amount.MaximumSize = new System.Drawing.Size(90, 20);
			this.amount.Name = "amount";
			this.amount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.amount.Properties.DisplayFormat.FormatString = "c";
			this.amount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.amount.Properties.EditFormat.FormatString = "c";
			this.amount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.amount.Properties.Mask.EditMask = "c";
			this.amount.Size = new System.Drawing.Size(82, 20);
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
			this.addPanel.Location = new System.Drawing.Point(0, 136);
			this.addPanel.Name = "addPanel";
			this.addPanel.Root = this.layoutControlGroup1;
			this.addPanel.Size = new System.Drawing.Size(899, 77);
			this.addPanel.TabIndex = 1;
			this.addPanel.Text = "layoutControl1";
			// 
			// checkNumber
			// 
			this.checkNumber.Location = new System.Drawing.Point(255, 37);
			this.checkNumber.Name = "checkNumber";
			this.checkNumber.Size = new System.Drawing.Size(80, 20);
			this.checkNumber.StyleController = this.addPanel;
			this.checkNumber.TabIndex = 3;
			this.checkNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			// 
			// checkDate
			// 
			this.checkDate.EditValue = null;
			this.checkDate.Location = new System.Drawing.Point(255, 13);
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
			this.comments.Location = new System.Drawing.Point(340, 12);
			this.comments.Name = "comments";
			this.comments.Properties.NullValuePrompt = "Comments (This will not appear on the bill)";
			this.comments.Size = new System.Drawing.Size(477, 53);
			this.comments.StyleController = this.addPanel;
			this.comments.TabIndex = 4;
			// 
			// paymentMethod
			// 
			this.paymentMethod.Location = new System.Drawing.Point(13, 37);
			this.paymentMethod.Name = "paymentMethod";
			this.paymentMethod.Properties.EnableFocusRect = true;
			this.paymentMethod.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Unpaid", "&Unpaid"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Cash", "Ca&sh"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Check", "&Check")});
			this.paymentMethod.Size = new System.Drawing.Size(159, 27);
			this.paymentMethod.StyleController = this.addPanel;
			this.paymentMethod.TabIndex = 1;
			this.paymentMethod.SelectedIndexChanged += new System.EventHandler(this.paymentMethod_SelectedIndexChanged);
			this.paymentMethod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Input_KeyDown);
			// 
			// add
			// 
			this.add.Image = global::ShomreiTorah.Billing.Properties.Resources.Add24;
			this.add.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
			this.add.Location = new System.Drawing.Point(821, 12);
			this.add.MinimumSize = new System.Drawing.Size(32, 53);
			this.add.Name = "add";
			this.add.Size = new System.Drawing.Size(66, 53);
			this.add.StyleController = this.addPanel;
			this.add.TabIndex = 5;
			this.add.Text = "Add";
			this.add.Click += new System.EventHandler(this.add_Click);
			// 
			// layoutControlGroup1
			// 
			this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
			this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.layoutControlGroup1.GroupBordersVisible = false;
			this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.checkGroup,
            this.layoutControlItem4,
            this.layoutControlGroup2});
			this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup1.Name = "layoutControlGroup1";
			this.layoutControlGroup1.Size = new System.Drawing.Size(899, 77);
			this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.layoutControlGroup1.Text = "layoutControlGroup1";
			this.layoutControlGroup1.TextVisible = false;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.comments;
			this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
			this.layoutControlItem3.Location = new System.Drawing.Point(328, 0);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(481, 57);
			this.layoutControlItem3.Text = "layoutControlItem3";
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextToControlDistance = 0;
			this.layoutControlItem3.TextVisible = false;
			// 
			// checkGroup
			// 
			this.checkGroup.CustomizationFormText = "checkGroup";
			this.checkGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.layoutControlItem5});
			this.checkGroup.Location = new System.Drawing.Point(165, 0);
			this.checkGroup.Name = "checkGroup";
			this.checkGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.checkGroup.Size = new System.Drawing.Size(163, 57);
			this.checkGroup.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.checkGroup.Text = "checkGroup";
			this.checkGroup.TextVisible = false;
			// 
			// layoutControlItem6
			// 
			this.layoutControlItem6.Control = this.checkNumber;
			this.layoutControlItem6.CustomizationFormText = "Check Number:";
			this.layoutControlItem6.Location = new System.Drawing.Point(0, 24);
			this.layoutControlItem6.Name = "layoutControlItem6";
			this.layoutControlItem6.Size = new System.Drawing.Size(161, 31);
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
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.add;
			this.layoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
			this.layoutControlItem4.Location = new System.Drawing.Point(809, 0);
			this.layoutControlItem4.MaxSize = new System.Drawing.Size(70, 26);
			this.layoutControlItem4.MinSize = new System.Drawing.Size(70, 26);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(70, 57);
			this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem4.Text = "layoutControlItem4";
			this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem4.TextToControlDistance = 0;
			this.layoutControlItem4.TextVisible = false;
			// 
			// layoutControlGroup2
			// 
			this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
			this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1});
			this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup2.Name = "layoutControlGroup2";
			this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.layoutControlGroup2.ShowInCustomizationForm = false;
			this.layoutControlGroup2.ShowTabPageCloseButton = true;
			this.layoutControlGroup2.Size = new System.Drawing.Size(165, 57);
			this.layoutControlGroup2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.layoutControlGroup2.Text = "layoutControlGroup2";
			this.layoutControlGroup2.TextVisible = false;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.paymentMethod;
			this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(163, 31);
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
			this.layoutControlItem1.MaxSize = new System.Drawing.Size(163, 24);
			this.layoutControlItem1.MinSize = new System.Drawing.Size(163, 24);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(163, 24);
			this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem1.Text = "Amount:";
			this.layoutControlItem1.TextSize = new System.Drawing.Size(73, 13);
			// 
			// repositoryItemPersonRefEdit1
			// 
			this.repositoryItemPersonRefEdit1.AutoHeight = false;
			this.repositoryItemPersonRefEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("repositoryItemPersonRefEdit1.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Show Person", null, null, true)});
			this.repositoryItemPersonRefEdit1.Name = "repositoryItemPersonRefEdit1";
			this.repositoryItemPersonRefEdit1.ReadOnly = true;
			this.repositoryItemPersonRefEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
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
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.accountEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.currencyEdit)).EndInit();
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
			((System.ComponentModel.ISupportInitialize)(this.checkGroup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemPersonRefEdit1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private ShomreiTorah.WinForms.Controls.LookupControl searchLookup;
		private Controls.BaseGrid grid;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView;
		private DevExpress.XtraGrid.Columns.GridColumn colFullName;
		private DevExpress.XtraGrid.Columns.GridColumn colDate;
		private DevExpress.XtraGrid.Columns.GridColumn colType;
		private DevExpress.XtraGrid.Columns.GridColumn colSubType;
		private DevExpress.XtraGrid.Columns.GridColumn colAccount;
		private DevExpress.XtraGrid.Columns.GridColumn colAmount;
		private DevExpress.XtraGrid.Columns.GridColumn colNote;
		private DevExpress.XtraGrid.Columns.GridColumn colComments;
		private DevExpress.XtraGrid.Columns.GridColumn colModified;
		private DevExpress.XtraGrid.Columns.GridColumn colModifier;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox accountEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit currencyEdit;
		private ShomreiTorah.Billing.Controls.PersonSelector personSelector;
		private DevExpress.XtraEditors.SpinEdit amount;
		private DevExpress.XtraEditors.RadioGroup paymentMethod;
		private DevExpress.XtraLayout.LayoutControl addPanel;
		private DevExpress.XtraEditors.MemoEdit comments;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private Controls.Editors.CheckNumberEdit  checkNumber;
		private DevExpress.XtraEditors.DateEdit checkDate;
		private DevExpress.XtraEditors.SimpleButton add;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private DevExpress.XtraLayout.LayoutControlGroup checkGroup;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
		private DevExpress.XtraGrid.Columns.GridColumn colPledgeId;
		private Controls.Editors.RepositoryItemPersonRefEdit repositoryItemPersonRefEdit1;
	}
}