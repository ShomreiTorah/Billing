namespace ShomreiTorah.Billing.Events.MelaveMalka {
	partial class SeatingForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeatingForm));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
			this.personSelector = new ShomreiTorah.Data.UI.Controls.PersonSelector();
			this.searchLookup = new ShomreiTorah.WinForms.Controls.Lookup.ItemSelector();
			this.addButton = new DevExpress.XtraEditors.SimpleButton();
			this.addPanel = new DevExpress.XtraLayout.LayoutControl();
			this.addMensSeats = new DevExpress.XtraEditors.SpinEdit();
			this.cancelAdd = new DevExpress.XtraEditors.SimpleButton();
			this.addWomensSeats = new DevExpress.XtraEditors.SpinEdit();
			this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.mensSeatsItem = new DevExpress.XtraLayout.LayoutControlItem();
			this.womensSeatsItem = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.grid = new ShomreiTorah.Data.UI.Grid.SmartGrid(this.components);
			this.gridView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colPerson = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colDateAdded = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colMensSeats = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colWomensSeats = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colRowId = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			((System.ComponentModel.ISupportInitialize)(this.personSelector.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.searchLookup.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.addPanel)).BeginInit();
			this.addPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.addMensSeats.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.addWomensSeats.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mensSeatsItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.womensSeatsItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			this.SuspendLayout();
			// 
			// personSelector
			// 
			this.personSelector.Dock = System.Windows.Forms.DockStyle.Top;
			this.personSelector.Location = new System.Drawing.Point(0, 0);
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
			this.personSelector.Properties.NullValuePrompt = "Click here to add a reservation";
			this.personSelector.Size = new System.Drawing.Size(791, 20);
			this.personSelector.TabIndex = 0;
			this.personSelector.PersonSelecting += new System.EventHandler<ShomreiTorah.Data.UI.Controls.PersonSelectingEventArgs>(this.personSelector_PersonSelecting);
			this.personSelector.EditValueChanged += new System.EventHandler(this.personSelector_EditValueChanged);
			// 
			// searchLookup
			// 
			this.searchLookup.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.searchLookup.Location = new System.Drawing.Point(0, 398);
			this.searchLookup.Name = "searchLookup";
			this.searchLookup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.searchLookup.Properties.NullValuePrompt = "Click here to search the list";
			this.searchLookup.Size = new System.Drawing.Size(791, 20);
			this.searchLookup.TabIndex = 1;
			this.searchLookup.EditValueChanged += new System.EventHandler(this.searchLookup_EditValueChanged);
			// 
			// addButton
			// 
			this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.addButton.Image = global::ShomreiTorah.Billing.Properties.Resources.Add16;
			this.addButton.Location = new System.Drawing.Point(719, 31);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(60, 22);
			this.addButton.StyleController = this.addPanel;
			this.addButton.TabIndex = 8;
			this.addButton.Text = "Add";
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// addPanel
			// 
			this.addPanel.AllowCustomization= false;
			this.addPanel.AutoScroll = false;
			this.addPanel.Controls.Add(this.addButton);
			this.addPanel.Controls.Add(this.addMensSeats);
			this.addPanel.Controls.Add(this.cancelAdd);
			this.addPanel.Controls.Add(this.addWomensSeats);
			this.addPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.addPanel.Location = new System.Drawing.Point(0, 20);
			this.addPanel.Name = "addPanel";
			this.addPanel.OptionsView.AutoSizeInLayoutControl = DevExpress.XtraLayout.AutoSizeModes.UseMinAndMaxSize;
			this.addPanel.Root = this.layoutControlGroup1;
			this.addPanel.Size = new System.Drawing.Size(791, 65);
			this.addPanel.TabIndex = 4;
			this.addPanel.Text = "layoutControl1";
			this.addPanel.Visible = false;
			// 
			// addMensSeats
			// 
			this.addMensSeats.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.addMensSeats.Location = new System.Drawing.Point(103, 31);
			this.addMensSeats.Name = "addMensSeats";
			this.addMensSeats.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.addMensSeats.Size = new System.Drawing.Size(103, 20);
			this.addMensSeats.StyleController = this.addPanel;
			this.addMensSeats.TabIndex = 5;
			this.addMensSeats.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddEditor_KeyDown);
			// 
			// cancelAdd
			// 
			this.cancelAdd.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.cancelAdd.Appearance.Options.UseBackColor = true;
			this.cancelAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelAdd.Image = global::ShomreiTorah.Billing.Properties.Resources.Close;
			this.cancelAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
			this.cancelAdd.Location = new System.Drawing.Point(693, 31);
			this.cancelAdd.Name = "cancelAdd";
			this.cancelAdd.Size = new System.Drawing.Size(22, 22);
			this.cancelAdd.StyleController = this.addPanel;
			this.cancelAdd.TabIndex = 3;
			this.cancelAdd.Text = "Close";
			this.cancelAdd.ToolTip = "Close";
			this.cancelAdd.Click += new System.EventHandler(this.cancelAdd_Click);
			// 
			// addWomensSeats
			// 
			this.addWomensSeats.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.addWomensSeats.Location = new System.Drawing.Point(301, 31);
			this.addWomensSeats.Name = "addWomensSeats";
			this.addWomensSeats.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.addWomensSeats.Size = new System.Drawing.Size(100, 20);
			this.addWomensSeats.StyleController = this.addPanel;
			this.addWomensSeats.TabIndex = 7;
			this.addWomensSeats.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddEditor_KeyDown);
			// 
			// layoutControlGroup1
			// 
			this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
			this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.layoutControlGroup1.GroupBordersVisible = false;
			this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
			this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup1.Name = "layoutControlGroup1";
			this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.layoutControlGroup1.Size = new System.Drawing.Size(791, 65);
			this.layoutControlGroup1.Text = "layoutControlGroup1";
			this.layoutControlGroup1.TextVisible = false;
			// 
			// layoutControlGroup2
			// 
			this.layoutControlGroup2.CustomizationFormText = "Add Reservation";
			this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.mensSeatsItem,
            this.womensSeatsItem,
            this.emptySpaceItem1,
            this.layoutControlItem1});
			this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup2.Name = "layoutControlGroup2";
			this.layoutControlGroup2.Size = new System.Drawing.Size(791, 65);
			this.layoutControlGroup2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.layoutControlGroup2.Text = "Add Reservation";
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.addButton;
			this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
			this.layoutControlItem3.Location = new System.Drawing.Point(707, 0);
			this.layoutControlItem3.MaxSize = new System.Drawing.Size(64, 26);
			this.layoutControlItem3.MinSize = new System.Drawing.Size(64, 26);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(64, 26);
			this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem3.Text = "layoutControlItem3";
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextToControlDistance = 0;
			this.layoutControlItem3.TextVisible = false;
			// 
			// mensSeatsItem
			// 
			this.mensSeatsItem.BestFitWeight = 50;
			this.mensSeatsItem.Control = this.addMensSeats;
			this.mensSeatsItem.CustomizationFormText = "mensSeatsItem";
			this.mensSeatsItem.Location = new System.Drawing.Point(0, 0);
			this.mensSeatsItem.Name = "mensSeatsItem";
			this.mensSeatsItem.Size = new System.Drawing.Size(198, 26);
			this.mensSeatsItem.Text = "mensSeatsItem";
			this.mensSeatsItem.TextSize = new System.Drawing.Size(88, 13);
			// 
			// womensSeatsItem
			// 
			this.womensSeatsItem.BestFitWeight = 50;
			this.womensSeatsItem.Control = this.addWomensSeats;
			this.womensSeatsItem.CustomizationFormText = "womensSeatsItem";
			this.womensSeatsItem.Location = new System.Drawing.Point(198, 0);
			this.womensSeatsItem.Name = "womensSeatsItem";
			this.womensSeatsItem.Size = new System.Drawing.Size(195, 26);
			this.womensSeatsItem.Text = "womensSeatsItem";
			this.womensSeatsItem.TextSize = new System.Drawing.Size(88, 13);
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.BestFitWeight = 800;
			this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
			this.emptySpaceItem1.Location = new System.Drawing.Point(393, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(288, 26);
			this.emptySpaceItem1.Text = "emptySpaceItem1";
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.cancelAdd;
			this.layoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
			this.layoutControlItem1.Location = new System.Drawing.Point(681, 0);
			this.layoutControlItem1.MaxSize = new System.Drawing.Size(26, 26);
			this.layoutControlItem1.MinSize = new System.Drawing.Size(26, 26);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(26, 26);
			this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem1.Text = "layoutControlItem1";
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextToControlDistance = 0;
			this.layoutControlItem1.TextVisible = false;
			// 
			// grid
			// 
			this.grid.DataMember = "SeatReservations";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 85);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.RegistrationCount = 56;
			this.grid.Size = new System.Drawing.Size(791, 313);
			this.grid.TabIndex = 3;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPerson,
            this.colDateAdded,
            this.colMensSeats,
            this.colWomensSeats});
			this.gridView.GridControl = this.grid;
			this.gridView.Name = "gridView";
			this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
			this.gridView.OptionsSelection.MultiSelect = true;
			this.gridView.OptionsView.ShowFooter = true;
			this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPerson, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.gridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
			// 
			// colPerson
			// 
			this.colPerson.AllowKeyboardActivation = false;
			this.colPerson.Caption = "Full Name";
			this.colPerson.FieldName = "Person";
			this.colPerson.Name = "colPerson";
			this.colPerson.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
			this.colPerson.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.colPerson.OptionsColumn.ReadOnly = true;
			this.colPerson.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colPerson.ShowEditorOnMouseDown = true;
			this.colPerson.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Person", "{0} Families")});
			this.colPerson.Visible = true;
			this.colPerson.VisibleIndex = 0;
			this.colPerson.Width = 78;
			// 
			// colDateAdded
			// 
			this.colDateAdded.FieldName = "DateAdded";
			this.colDateAdded.Name = "colDateAdded";
			this.colDateAdded.OptionsColumn.AllowEdit = false;
			this.colDateAdded.OptionsColumn.ReadOnly = true;
			this.colDateAdded.Visible = true;
			this.colDateAdded.VisibleIndex = 1;
			this.colDateAdded.Width = 76;
			// 
			// colMensSeats
			// 
			this.colMensSeats.Caption = "Journals";
			this.colMensSeats.FieldName = "MensSeats";
			this.colMensSeats.Name = "colMensSeats";
			this.colMensSeats.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MensSeats", "{0} Men")});
			this.colMensSeats.Visible = true;
			this.colMensSeats.VisibleIndex = 2;
			this.colMensSeats.Width = 59;
			// 
			// colWomensSeats
			// 
			this.colWomensSeats.Caption = "Dinners";
			this.colWomensSeats.FieldName = "WomensSeats";
			this.colWomensSeats.Name = "colWomensSeats";
			this.colWomensSeats.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "WomensSeats", "{0} Women")});
			this.colWomensSeats.Visible = true;
			this.colWomensSeats.VisibleIndex = 3;
			this.colWomensSeats.Width = 64;
			// 
			// colRowId
			// 
			this.colRowId.FieldName = "RowId";
			this.colRowId.Name = "colRowId";
			this.colRowId.Visible = true;
			this.colRowId.VisibleIndex = 0;
			// 
			// SeatingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(791, 418);
			this.Controls.Add(this.grid);
			this.Controls.Add(this.addPanel);
			this.Controls.Add(this.searchLookup);
			this.Controls.Add(this.personSelector);
			this.Name = "SeatingForm";
			this.Text = "SeatingForm";
			((System.ComponentModel.ISupportInitialize)(this.personSelector.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.searchLookup.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.addPanel)).EndInit();
			this.addPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.addMensSeats.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.addWomensSeats.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mensSeatsItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.womensSeatsItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Data.UI.Controls.PersonSelector personSelector;
		private WinForms.Controls.Lookup.ItemSelector searchLookup;
		private Data.UI.Grid.SmartGrid grid;
		private Data.UI.Grid.SmartGridView gridView;
		private Data.UI.Grid.SmartGridColumn colPerson;
		private Data.UI.Grid.SmartGridColumn colDateAdded;
		private Data.UI.Grid.SmartGridColumn colMensSeats;
		private Data.UI.Grid.SmartGridColumn colWomensSeats;
		private Data.UI.Grid.SmartGridColumn colRowId;
		private DevExpress.XtraEditors.SimpleButton cancelAdd;
		private DevExpress.XtraEditors.SimpleButton addButton;
		private DevExpress.XtraEditors.SpinEdit addWomensSeats;
		private DevExpress.XtraEditors.SpinEdit addMensSeats;
		private DevExpress.XtraLayout.LayoutControl addPanel;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.LayoutControlItem mensSeatsItem;
		private DevExpress.XtraLayout.LayoutControlItem womensSeatsItem;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
	}
}