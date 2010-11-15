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
			this.addPanel = new DevExpress.XtraEditors.GroupControl();
			this.addButton = new DevExpress.XtraEditors.SimpleButton();
			this.addWomensSeats = new DevExpress.XtraEditors.SpinEdit();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.addMensSeats = new DevExpress.XtraEditors.SpinEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.cancelAdd = new DevExpress.XtraEditors.SimpleButton();
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
			((System.ComponentModel.ISupportInitialize)(this.addWomensSeats.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.addMensSeats.Properties)).BeginInit();
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
			this.personSelector.Size = new System.Drawing.Size(716, 20);
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
			this.searchLookup.Size = new System.Drawing.Size(716, 20);
			this.searchLookup.TabIndex = 1;
			this.searchLookup.EditValueChanged += new System.EventHandler(this.searchLookup_EditValueChanged);
			// 
			// addPanel
			// 
			this.addPanel.Controls.Add(this.addButton);
			this.addPanel.Controls.Add(this.addWomensSeats);
			this.addPanel.Controls.Add(this.labelControl2);
			this.addPanel.Controls.Add(this.addMensSeats);
			this.addPanel.Controls.Add(this.labelControl1);
			this.addPanel.Controls.Add(this.cancelAdd);
			this.addPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.addPanel.Location = new System.Drawing.Point(0, 20);
			this.addPanel.Name = "addPanel";
			this.addPanel.Size = new System.Drawing.Size(716, 51);
			this.addPanel.TabIndex = 2;
			this.addPanel.Text = "Add Reservation";
			this.addPanel.Visible = false;
			// 
			// addButton
			// 
			this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.addButton.Image = global::ShomreiTorah.Billing.Properties.Resources.Add16;
			this.addButton.Location = new System.Drawing.Point(636, 24);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(75, 23);
			this.addButton.TabIndex = 8;
			this.addButton.Text = "Add";
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// addWomensSeats
			// 
			this.addWomensSeats.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.addWomensSeats.Location = new System.Drawing.Point(199, 25);
			this.addWomensSeats.Name = "addWomensSeats";
			this.addWomensSeats.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.addWomensSeats.Size = new System.Drawing.Size(80, 20);
			this.addWomensSeats.TabIndex = 7;
			this.addWomensSeats.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddEditor_KeyDown);
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(153, 28);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(40, 13);
			this.labelControl2.TabIndex = 6;
			this.labelControl2.Text = "Women:";
			// 
			// addMensSeats
			// 
			this.addMensSeats.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.addMensSeats.Location = new System.Drawing.Point(42, 25);
			this.addMensSeats.Name = "addMensSeats";
			this.addMensSeats.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.addMensSeats.Size = new System.Drawing.Size(80, 20);
			this.addMensSeats.TabIndex = 5;
			this.addMensSeats.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddEditor_KeyDown);
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(12, 28);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(24, 13);
			this.labelControl1.TabIndex = 4;
			this.labelControl1.Text = "Men:";
			// 
			// cancelAdd
			// 
			this.cancelAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelAdd.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.cancelAdd.Appearance.Options.UseBackColor = true;
			this.cancelAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.cancelAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelAdd.Image = global::ShomreiTorah.Billing.Properties.Resources.Close;
			this.cancelAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
			this.cancelAdd.Location = new System.Drawing.Point(703, 0);
			this.cancelAdd.Name = "cancelAdd";
			this.cancelAdd.Size = new System.Drawing.Size(13, 13);
			this.cancelAdd.TabIndex = 3;
			this.cancelAdd.Text = "Close";
			this.cancelAdd.ToolTip = "Close";
			this.cancelAdd.Click += new System.EventHandler(this.cancelAdd_Click);
			// 
			// grid
			// 
			this.grid.DataMember = "SeatReservations";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 71);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.RegistrationCount = 44;
			this.grid.Size = new System.Drawing.Size(716, 327);
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
			this.colPerson.Caption = "Full Name";
			this.colPerson.FieldName = "Person";
			this.colPerson.Name = "colPerson";
			this.colPerson.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
			this.colPerson.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.colPerson.OptionsColumn.ReadOnly = true;
			this.colPerson.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colPerson.ShowEditorOnMouseDown = true;
			this.colPerson.SummaryItem.DisplayFormat = "{0} Families";
			this.colPerson.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
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
			this.colMensSeats.FieldName = "MensSeats";
			this.colMensSeats.Name = "colMensSeats";
			this.colMensSeats.SummaryItem.DisplayFormat = "{0} Men";
			this.colMensSeats.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.colMensSeats.Visible = true;
			this.colMensSeats.VisibleIndex = 2;
			this.colMensSeats.Width = 74;
			// 
			// colWomensSeats
			// 
			this.colWomensSeats.FieldName = "WomensSeats";
			this.colWomensSeats.Name = "colWomensSeats";
			this.colWomensSeats.SummaryItem.DisplayFormat = "{0} Women";
			this.colWomensSeats.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.colWomensSeats.Visible = true;
			this.colWomensSeats.VisibleIndex = 3;
			this.colWomensSeats.Width = 90;
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
			this.ClientSize = new System.Drawing.Size(716, 418);
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
			this.addPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.addWomensSeats.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.addMensSeats.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Data.UI.Controls.PersonSelector personSelector;
		private WinForms.Controls.Lookup.ItemSelector searchLookup;
		private DevExpress.XtraEditors.GroupControl addPanel;
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
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.SpinEdit addMensSeats;
		private DevExpress.XtraEditors.LabelControl labelControl1;
	}
}