namespace ShomreiTorah.Billing.Forms.GridForms {
	partial class EmailListForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailListForm));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
			this.grid = new ShomreiTorah.Data.UI.Grid.SmartGrid(this.components);
			this.gridView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colEmail = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colJoinDate = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colFullName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.personEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			this.emptyPersonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			this.personSelector = new ShomreiTorah.Data.UI.Controls.PersonSelector();
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.personEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptyPersonEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.personSelector.Properties)).BeginInit();
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
			this.ribbon.Size = new System.Drawing.Size(821, 114);
			// 
			// grid
			// 
			this.grid.DataMember = "EmailAddresses";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 114);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.RegistrationCount = 38;
			this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.emptyPersonEdit,
            this.personEdit});
			this.grid.Size = new System.Drawing.Size(821, 368);
			this.grid.TabIndex = 0;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colEmail,
            this.colJoinDate,
            this.colFullName});
			this.gridView.GridControl = this.grid;
			this.gridView.Name = "gridView";
			this.gridView.OptionsBehavior.SmartVertScrollBar = false;
			this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colJoinDate, DevExpress.Data.ColumnSortOrder.Descending)});
			this.gridView.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView_CustomRowCellEdit);
			this.gridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
			// 
			// colName
			// 
			this.colName.FieldName = "Name";
			this.colName.Name = "colName";
			this.colName.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colName.Visible = true;
			this.colName.VisibleIndex = 0;
			this.colName.Width = 46;
			// 
			// colEmail
			// 
			this.colEmail.FieldName = "Email";
			this.colEmail.Name = "colEmail";
			this.colEmail.Visible = true;
			this.colEmail.VisibleIndex = 1;
			this.colEmail.Width = 43;
			// 
			// colJoinDate
			// 
			this.colJoinDate.Caption = "Date Joined";
			this.colJoinDate.FieldName = "DateAdded";
			this.colJoinDate.Name = "colJoinDate";
			this.colJoinDate.OptionsColumn.AllowEdit = false;
			this.colJoinDate.OptionsColumn.ReadOnly = true;
			this.colJoinDate.Visible = true;
			this.colJoinDate.VisibleIndex = 2;
			this.colJoinDate.Width = 89;
			// 
			// colFullName
			// 
			this.colFullName.Caption = "Full Name";
			this.colFullName.ColumnEditor = this.personEdit;
			this.colFullName.FieldName = "Person";
			this.colFullName.Name = "colFullName";
			this.colFullName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
			this.colFullName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.colFullName.OptionsColumn.ReadOnly = true;
			this.colFullName.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colFullName.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
			this.colFullName.Visible = true;
			this.colFullName.VisibleIndex = 3;
			this.colFullName.Width = 74;
			// 
			// personEdit
			// 
			this.personEdit.AutoHeight = false;
			this.personEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Show Person", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("personEdit.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Show Person", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Clear", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dissociate this person from this email address", null, null, true)});
			this.personEdit.Name = "personEdit";
			this.personEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.personEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.personEdit_ButtonClick);
			this.personEdit.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.personEdit_CustomDisplayText);
			// 
			// emptyPersonEdit
			// 
			this.emptyPersonEdit.AutoHeight = false;
			this.emptyPersonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Show Person", -1, false, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("emptyPersonEdit.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Show Person", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Clear", -1, false, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
			this.emptyPersonEdit.Name = "emptyPersonEdit";
			this.emptyPersonEdit.NullText = "(None)";
			this.emptyPersonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.emptyPersonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.personEdit_ButtonClick);
			// 
			// personSelector
			// 
			this.personSelector.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.personSelector.Location = new System.Drawing.Point(0, 482);
			this.personSelector.Name = "personSelector";
			toolTipItem1.Text = "Click to select a person";
			superToolTip1.Items.Add(toolTipItem1);
			toolTipTitleItem1.Text = "New Person...";
			toolTipItem2.Text = "Adds a new person to the master directory";
			superToolTip2.Items.Add(toolTipTitleItem1);
			superToolTip2.Items.Add(toolTipItem2);
			this.personSelector.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "", null, superToolTip1, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "New person...", 90, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleLeft, ((System.Drawing.Image)(resources.GetObject("personSelector.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "", null, superToolTip2, true)});
			this.personSelector.Size = new System.Drawing.Size(821, 20);
			this.personSelector.TabIndex = 1;
			this.personSelector.EditValueChanged += new System.EventHandler(this.personSelector_EditValueChanged);
			// 
			// EmailListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(821, 502);
			this.Controls.Add(this.grid);
			this.Controls.Add(this.personSelector);
			this.MainView = this.gridView;
			this.Name = "EmailListForm";
			this.Text = "Email List";
			this.Controls.SetChildIndex(this.ribbon, 0);
			this.Controls.SetChildIndex(this.personSelector, 0);
			this.Controls.SetChildIndex(this.grid, 0);
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.personEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptyPersonEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.personSelector.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Data.UI.Grid.SmartGrid grid;
		private Data.UI.Grid.SmartGridView gridView;
		private Data.UI.Grid.SmartGridColumn colName;
		private Data.UI.Grid.SmartGridColumn colEmail;
		private Data.UI.Grid.SmartGridColumn colJoinDate;
		private Data.UI.Grid.SmartGridColumn colFullName;
		private ShomreiTorah.Data.UI.Controls.PersonSelector personSelector;
		private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit emptyPersonEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit personEdit;
	}
}