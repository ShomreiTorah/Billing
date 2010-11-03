namespace ShomreiTorah.Billing.Events.MelaveMalka {
	partial class InvitationsForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvitationsForm));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
			this.listSearch = new ShomreiTorah.WinForms.Controls.Lookup.ItemSelector();
			this.personSelector = new ShomreiTorah.Data.UI.Controls.PersonSelector();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.source = new DevExpress.XtraEditors.ComboBoxEdit();
			this.grid = new ShomreiTorah.Data.UI.Grid.SmartGrid(this.components);
			this.gridView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colPerson = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colDateAdded = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colSource = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colId = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colRowId = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			((System.ComponentModel.ISupportInitialize)(this.listSearch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.personSelector.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.source.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			this.SuspendLayout();
			// 
			// listSearch
			// 
			this.listSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.listSearch.Location = new System.Drawing.Point(0, 312);
			this.listSearch.Name = "listSearch";
			this.listSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.listSearch.Properties.NullValuePrompt = "Click here to search the invitations";
			this.listSearch.Size = new System.Drawing.Size(515, 20);
			this.listSearch.TabIndex = 0;
			this.listSearch.EditValueChanged += new System.EventHandler(this.listSearch_EditValueChanged);
			// 
			// personSelector
			// 
			this.personSelector.Dock = System.Windows.Forms.DockStyle.Fill;
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
			this.personSelector.Size = new System.Drawing.Size(374, 20);
			this.personSelector.TabIndex = 1;
			this.personSelector.EditValueChanged += new System.EventHandler(this.personSelector_EditValueChanged);
			// 
			// panelControl1
			// 
			this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl1.Controls.Add(this.personSelector);
			this.panelControl1.Controls.Add(this.labelControl1);
			this.panelControl1.Controls.Add(this.source);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(515, 20);
			this.panelControl1.TabIndex = 2;
			// 
			// labelControl1
			// 
			this.labelControl1.Dock = System.Windows.Forms.DockStyle.Right;
			this.labelControl1.Location = new System.Drawing.Point(374, 0);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Padding = new System.Windows.Forms.Padding(2);
			this.labelControl1.Size = new System.Drawing.Size(41, 17);
			this.labelControl1.TabIndex = 3;
			this.labelControl1.Text = "Source:";
			// 
			// source
			// 
			this.source.Dock = System.Windows.Forms.DockStyle.Right;
			this.source.Location = new System.Drawing.Point(415, 0);
			this.source.Name = "source";
			this.source.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.source.Size = new System.Drawing.Size(100, 20);
			this.source.TabIndex = 2;
			// 
			// grid
			// 
			this.grid.DataMember = "Invitees";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 20);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.RegistrationCount = 39;
			this.grid.Size = new System.Drawing.Size(515, 292);
			this.grid.TabIndex = 3;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPerson,
            this.colDateAdded,
            this.colSource});
			this.gridView.GridControl = this.grid;
			this.gridView.Name = "gridView";
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
			this.colPerson.Visible = true;
			this.colPerson.VisibleIndex = 0;
			this.colPerson.Width = 65;
			// 
			// colDateAdded
			// 
			this.colDateAdded.DisplayFormat.FormatString = "D";
			this.colDateAdded.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colDateAdded.FieldName = "DateAdded";
			this.colDateAdded.Name = "colDateAdded";
			this.colDateAdded.OptionsColumn.AllowEdit = false;
			this.colDateAdded.OptionsColumn.ReadOnly = true;
			this.colDateAdded.Visible = true;
			this.colDateAdded.VisibleIndex = 1;
			this.colDateAdded.Width = 76;
			// 
			// colSource
			// 
			this.colSource.FieldName = "Source";
			this.colSource.Name = "colSource";
			this.colSource.Visible = true;
			this.colSource.VisibleIndex = 2;
			this.colSource.Width = 52;
			// 
			// colId
			// 
			this.colId.FieldName = "Id";
			this.colId.Name = "colId";
			this.colId.Visible = true;
			this.colId.VisibleIndex = 0;
			// 
			// colRowId
			// 
			this.colRowId.FieldName = "RowId";
			this.colRowId.Name = "colRowId";
			this.colRowId.Visible = true;
			this.colRowId.VisibleIndex = 0;
			// 
			// InvitationsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(515, 332);
			this.Controls.Add(this.grid);
			this.Controls.Add(this.panelControl1);
			this.Controls.Add(this.listSearch);
			this.Name = "InvitationsForm";
			this.Text = "InvitationsForm";
			((System.ComponentModel.ISupportInitialize)(this.listSearch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.personSelector.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			this.panelControl1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.source.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private WinForms.Controls.Lookup.ItemSelector listSearch;
		private Data.UI.Controls.PersonSelector personSelector;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.ComboBoxEdit source;
		private Data.UI.Grid.SmartGrid grid;
		private Data.UI.Grid.SmartGridView gridView;
		private Data.UI.Grid.SmartGridColumn colId;
		private Data.UI.Grid.SmartGridColumn colPerson;
		private Data.UI.Grid.SmartGridColumn colDateAdded;
		private Data.UI.Grid.SmartGridColumn colSource;
		private Data.UI.Grid.SmartGridColumn colRowId;
	}
}