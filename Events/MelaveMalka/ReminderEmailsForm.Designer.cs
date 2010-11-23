namespace ShomreiTorah.Billing.Events.MelaveMalka {
	partial class ReminderEmailsForm {
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
			DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
			this.logView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colDate = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colEmailSubject1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colEmailSource = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.grid = new ShomreiTorah.Data.UI.Grid.SmartGrid(this.components);
			this.gridView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colShouldEmail = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colPerson = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colSource = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colEmailSubject = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAdAmount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.listSearch = new ShomreiTorah.WinForms.Controls.Lookup.ItemSelector();
			this.colRowId = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colRowId1 = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colRecipient = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			((System.ComponentModel.ISupportInitialize)(this.logView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.listSearch.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// logView
			// 
			this.logView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDate,
            this.colEmailSubject1,
            this.colEmailSource});
			this.logView.GridControl = this.grid;
			this.logView.Name = "logView";
			this.logView.OptionsView.ShowGroupPanel = false;
			this.logView.OptionsView.ShowPreview = true;
			this.logView.PreviewFieldName = "EmailSource";
			// 
			// colDate
			// 
			this.colDate.DisplayFormat.FormatString = "f";
			this.colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colDate.FieldName = "Date";
			this.colDate.Name = "colDate";
			this.colDate.OptionsColumn.AllowEdit = false;
			this.colDate.OptionsColumn.AllowFocus = false;
			this.colDate.OptionsColumn.ReadOnly = true;
			this.colDate.Visible = true;
			this.colDate.VisibleIndex = 0;
			// 
			// colEmailSubject1
			// 
			this.colEmailSubject1.FieldName = "EmailSubject";
			this.colEmailSubject1.Name = "colEmailSubject1";
			this.colEmailSubject1.OptionsColumn.AllowEdit = false;
			this.colEmailSubject1.OptionsColumn.AllowFocus = false;
			this.colEmailSubject1.OptionsColumn.ReadOnly = true;
			this.colEmailSubject1.Visible = true;
			this.colEmailSubject1.VisibleIndex = 1;
			// 
			// colEmailSource
			// 
			this.colEmailSource.FieldName = "EmailSource";
			this.colEmailSource.Name = "colEmailSource";
			this.colEmailSource.OptionsColumn.AllowEdit = false;
			this.colEmailSource.OptionsColumn.AllowFocus = false;
			this.colEmailSource.OptionsColumn.ReadOnly = true;
			this.colEmailSource.Visible = true;
			this.colEmailSource.VisibleIndex = 2;
			// 
			// grid
			// 
			this.grid.DataMember = "Invitees";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			gridLevelNode1.LevelTemplate = this.logView;
			gridLevelNode1.RelationName = "ReminderEmailLogs";
			this.grid.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
			this.grid.Location = new System.Drawing.Point(0, 0);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.RegistrationCount = 48;
			this.grid.Size = new System.Drawing.Size(306, 452);
			this.grid.TabIndex = 1;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.logView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colShouldEmail,
            this.colPerson,
            this.colSource,
            this.colEmailSubject,
            this.colAdAmount});
			this.gridView.GridControl = this.grid;
			this.gridView.Name = "gridView";
			this.gridView.OptionsSelection.MultiSelect = true;
			this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPerson, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// colShouldEmail
			// 
			this.colShouldEmail.Caption = " ";
			this.colShouldEmail.FieldName = "ShouldEmail";
			this.colShouldEmail.MaxWidth = 20;
			this.colShouldEmail.Name = "colShouldEmail";
			this.colShouldEmail.OptionsColumn.AllowSize = false;
			this.colShouldEmail.OptionsColumn.FixedWidth = true;
			this.colShouldEmail.ToolTip = "Should Email?";
			this.colShouldEmail.Visible = true;
			this.colShouldEmail.VisibleIndex = 0;
			this.colShouldEmail.Width = 33;
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
			this.colPerson.Visible = true;
			this.colPerson.VisibleIndex = 1;
			this.colPerson.Width = 65;
			// 
			// colSource
			// 
			this.colSource.FieldName = "Source";
			this.colSource.Name = "colSource";
			this.colSource.OptionsColumn.AllowEdit = false;
			this.colSource.OptionsColumn.ReadOnly = true;
			this.colSource.Visible = true;
			this.colSource.VisibleIndex = 2;
			this.colSource.Width = 52;
			// 
			// colEmailSubject
			// 
			this.colEmailSubject.FieldName = "EmailSubject";
			this.colEmailSubject.Name = "colEmailSubject";
			this.colEmailSubject.Width = 72;
			// 
			// colAdAmount
			// 
			this.colAdAmount.DisplayFormat.FormatString = "c";
			this.colAdAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colAdAmount.FieldName = "AdAmount";
			this.colAdAmount.Name = "colAdAmount";
			this.colAdAmount.OptionsColumn.AllowEdit = false;
			this.colAdAmount.OptionsColumn.ReadOnly = true;
			this.colAdAmount.Width = 62;
			// 
			// listSearch
			// 
			this.listSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.listSearch.Location = new System.Drawing.Point(0, 452);
			this.listSearch.Name = "listSearch";
			this.listSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.listSearch.Properties.NullValuePrompt = "Click here to search the list";
			this.listSearch.Size = new System.Drawing.Size(685, 20);
			this.listSearch.TabIndex = 0;
			this.listSearch.EditValueChanged += new System.EventHandler(this.listSearch_EditValueChanged);
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
			// colRecipient
			// 
			this.colRecipient.FieldName = "Recipient";
			this.colRecipient.Name = "colRecipient";
			this.colRecipient.Visible = true;
			this.colRecipient.VisibleIndex = 1;
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.Controls.Add(this.grid);
			this.splitContainerControl1.Panel1.Text = "Panel1";
			this.splitContainerControl1.Panel2.Text = "Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(685, 452);
			this.splitContainerControl1.SplitterPosition = 306;
			this.splitContainerControl1.TabIndex = 2;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// ReminderEmailsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(685, 472);
			this.Controls.Add(this.splitContainerControl1);
			this.Controls.Add(this.listSearch);
			this.Name = "ReminderEmailsForm";
			this.Text = "ReminderEmailsForm";
			((System.ComponentModel.ISupportInitialize)(this.logView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.listSearch.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private WinForms.Controls.Lookup.ItemSelector listSearch;
		private Data.UI.Grid.SmartGrid grid;
		private Data.UI.Grid.SmartGridView logView;
		private Data.UI.Grid.SmartGridColumn colDate;
		private Data.UI.Grid.SmartGridColumn colEmailSubject1;
		private Data.UI.Grid.SmartGridColumn colEmailSource;
		private Data.UI.Grid.SmartGridView gridView;
		private Data.UI.Grid.SmartGridColumn colShouldEmail;
		private Data.UI.Grid.SmartGridColumn colPerson;
		private Data.UI.Grid.SmartGridColumn colSource;
		private Data.UI.Grid.SmartGridColumn colEmailSubject;
		private Data.UI.Grid.SmartGridColumn colAdAmount;
		private Data.UI.Grid.SmartGridColumn colRowId;
		private Data.UI.Grid.SmartGridColumn colRowId1;
		private Data.UI.Grid.SmartGridColumn colRecipient;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
	}
}