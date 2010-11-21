namespace ShomreiTorah.Billing.Events.MelaveMalka {
	partial class CallerList {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CallerList));
			this.calleesView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colPerson1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colDateAdded1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAdAmount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.grid = new ShomreiTorah.Data.UI.Grid.SmartGrid(this.components);
			this.gridView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colPerson = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colDateAdded = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colEmailAddresses = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.emailLinkEdit = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
			this.addCaller = new ShomreiTorah.WinForms.Controls.Lookup.ItemSelector();
			this.colRowId = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colRowId1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colCaller = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			((System.ComponentModel.ISupportInitialize)(this.calleesView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emailLinkEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.addCaller.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// calleesView
			// 
			this.calleesView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPerson1,
            this.colDateAdded1,
            this.colAdAmount});
			this.calleesView.GridControl = this.grid;
			this.calleesView.Name = "calleesView";
			// 
			// colPerson1
			// 
			this.colPerson1.Caption = "Full Name";
			this.colPerson1.FieldName = "Person";
			this.colPerson1.Name = "colPerson1";
			this.colPerson1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
			this.colPerson1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.colPerson1.OptionsColumn.ReadOnly = true;
			this.colPerson1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colPerson1.ShowEditorOnMouseDown = true;
			this.colPerson1.Visible = true;
			this.colPerson1.VisibleIndex = 0;
			// 
			// colDateAdded1
			// 
			this.colDateAdded1.FieldName = "DateAdded";
			this.colDateAdded1.Name = "colDateAdded1";
			this.colDateAdded1.OptionsColumn.AllowEdit = false;
			this.colDateAdded1.OptionsColumn.AllowFocus = false;
			this.colDateAdded1.Visible = true;
			this.colDateAdded1.VisibleIndex = 1;
			// 
			// colAdAmount
			// 
			this.colAdAmount.DisplayFormat.FormatString = "c";
			this.colAdAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colAdAmount.FieldName = "AdAmount";
			this.colAdAmount.Name = "colAdAmount";
			this.colAdAmount.OptionsColumn.AllowEdit = false;
			this.colAdAmount.OptionsColumn.AllowFocus = false;
			this.colAdAmount.OptionsColumn.ReadOnly = true;
			this.colAdAmount.Visible = true;
			this.colAdAmount.VisibleIndex = 2;
			// 
			// grid
			// 
			this.grid.DataMember = "Callers";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			gridLevelNode1.LevelTemplate = this.calleesView;
			gridLevelNode1.RelationName = "Callees";
			this.grid.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
			this.grid.Location = new System.Drawing.Point(0, 20);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.RegistrationCount = 48;
			this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.emailLinkEdit});
			this.grid.Size = new System.Drawing.Size(514, 358);
			this.grid.TabIndex = 1;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.calleesView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPerson,
            this.colDateAdded,
            this.colEmailAddresses});
			this.gridView.GridControl = this.grid;
			this.gridView.Name = "gridView";
			this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
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
			this.colDateAdded.FieldName = "DateAdded";
			this.colDateAdded.Name = "colDateAdded";
			this.colDateAdded.OptionsColumn.AllowEdit = false;
			this.colDateAdded.OptionsColumn.ReadOnly = true;
			this.colDateAdded.Width = 66;
			// 
			// colEmailAddresses
			// 
			this.colEmailAddresses.ColumnEditor = this.emailLinkEdit;
			this.colEmailAddresses.FieldName = "EmailAddresses";
			this.colEmailAddresses.Name = "colEmailAddresses";
			this.colEmailAddresses.OptionsColumn.ReadOnly = true;
			this.colEmailAddresses.Visible = true;
			this.colEmailAddresses.VisibleIndex = 1;
			this.colEmailAddresses.Width = 96;
			// 
			// emailLinkEdit
			// 
			this.emailLinkEdit.AutoHeight = false;
			this.emailLinkEdit.Name = "emailLinkEdit";
			this.emailLinkEdit.ReadOnly = true;
			this.emailLinkEdit.SingleClick = true;
			this.emailLinkEdit.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.emailLinkEdit_OpenLink);
			// 
			// addCaller
			// 
			this.addCaller.Dock = System.Windows.Forms.DockStyle.Top;
			this.addCaller.Location = new System.Drawing.Point(0, 0);
			this.addCaller.Name = "addCaller";
			this.addCaller.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.addCaller.Size = new System.Drawing.Size(514, 20);
			this.addCaller.TabIndex = 0;
			this.addCaller.EditValueChanged += new System.EventHandler(this.addCaller_EditValueChanged);
			// 
			// colRowId
			// 
			this.colRowId.FieldName = "RowId";
			this.colRowId.Name = "colRowId";
			this.colRowId.Visible = true;
			this.colRowId.VisibleIndex = 0;
			// 
			// colRowId1
			// 
			this.colRowId1.FieldName = "RowId";
			this.colRowId1.Name = "colRowId1";
			this.colRowId1.Visible = true;
			this.colRowId1.VisibleIndex = 0;
			// 
			// colCaller
			// 
			this.colCaller.FieldName = "Caller";
			this.colCaller.Name = "colCaller";
			this.colCaller.Visible = true;
			this.colCaller.VisibleIndex = 6;
			// 
			// CallerList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(514, 378);
			this.Controls.Add(this.grid);
			this.Controls.Add(this.addCaller);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CallerList";
			this.Text = "CallerList";
			((System.ComponentModel.ISupportInitialize)(this.calleesView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emailLinkEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.addCaller.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private WinForms.Controls.Lookup.ItemSelector addCaller;
		private Data.UI.Grid.SmartGrid grid;
		private Data.UI.Grid.SmartGridView gridView;
		private Data.UI.Grid.SmartGridColumn colPerson;
		private Data.UI.Grid.SmartGridColumn colDateAdded;
		private Data.UI.Grid.SmartGridColumn colEmailAddresses;
		private Data.UI.Grid.SmartGridColumn colRowId;
		private Data.UI.Grid.SmartGridView calleesView;
		private Data.UI.Grid.SmartGridColumn colPerson1;
		private Data.UI.Grid.SmartGridColumn colDateAdded1;
		private Data.UI.Grid.SmartGridColumn colAdAmount;
		private Data.UI.Grid.SmartGridColumn colRowId1;
		private Data.UI.Grid.SmartGridColumn colCaller;
		private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit emailLinkEdit;
	}
}