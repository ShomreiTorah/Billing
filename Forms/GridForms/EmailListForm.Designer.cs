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
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
			this.grid = new ShomreiTorah.Billing.Controls.BaseGrid(this.components);
			this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colJoinDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.personEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			this.emptyPersonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			this.personSelector = new ShomreiTorah.Billing.Controls.PersonSelector();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.personEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptyPersonEdit)).BeginInit();
			this.SuspendLayout();
			// 
			// grid
			// 
			this.grid.DataMember = "EmailList";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 142);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.emptyPersonEdit,
            this.personEdit});
			this.grid.Size = new System.Drawing.Size(821, 340);
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
			this.gridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_FocusedRowChanged);
			this.gridView.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView_CustomRowCellEdit);
			// 
			// colName
			// 
			this.colName.FieldName = "Name";
			this.colName.Name = "colName";
			this.colName.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colName.Visible = true;
			this.colName.VisibleIndex = 0;
			// 
			// colEmail
			// 
			this.colEmail.FieldName = "Email";
			this.colEmail.Name = "colEmail";
			this.colEmail.Visible = true;
			this.colEmail.VisibleIndex = 1;
			// 
			// colJoinDate
			// 
			this.colJoinDate.Caption = "Date Joined";
			this.colJoinDate.FieldName = "JoinDate";
			this.colJoinDate.Name = "colJoinDate";
			this.colJoinDate.OptionsColumn.AllowEdit = false;
			this.colJoinDate.OptionsColumn.ReadOnly = true;
			this.colJoinDate.Visible = true;
			this.colJoinDate.VisibleIndex = 2;
			// 
			// colFullName
			// 
			this.colFullName.Caption = "Person";
			this.colFullName.ColumnEdit = this.personEdit;
			this.colFullName.FieldName = "FullName";
			this.colFullName.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical;
			this.colFullName.Name = "colFullName";
			this.colFullName.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colFullName.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
			this.colFullName.Visible = true;
			this.colFullName.VisibleIndex = 3;
			// 
			// personEdit
			// 
			this.personEdit.AutoHeight = false;
			this.personEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Show Person", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("personEdit.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "Show Person", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Clear", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "Dissociate this person from this email address", null, null, true)});
			this.personEdit.Name = "personEdit";
			this.personEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.personEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.personEdit_ButtonClick);
			// 
			// emptyPersonEdit
			// 
			this.emptyPersonEdit.AutoHeight = false;
			this.emptyPersonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Show Person", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("emptyPersonEdit.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "Show Person", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Clear", -1, false, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8, "", null, null, true)});
			this.emptyPersonEdit.Name = "emptyPersonEdit";
			this.emptyPersonEdit.NullText = "(None)";
			this.emptyPersonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.emptyPersonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.personEdit_ButtonClick);
			// 
			// personSelector
			// 
			this.personSelector.Caption = "Select a person:";
			this.personSelector.DefaultText = "Please click here to select a person";
			this.personSelector.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.personSelector.Location = new System.Drawing.Point(0, 482);
			this.personSelector.Name = "personSelector";
			this.personSelector.PopupOpen = false;
			this.personSelector.ScrollPosition = 0;
			this.personSelector.SearchTable = null;
			this.personSelector.SelectedIndex = -1;
			this.personSelector.Size = new System.Drawing.Size(821, 20);
			this.personSelector.TabIndex = 1;
			this.personSelector.TabStop = false;
			this.personSelector.Value = ((object)(resources.GetObject("personSelector.Value")));
			this.personSelector.SelectedPersonChanged += new System.EventHandler(this.personSelector_SelectedPersonChanged);
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
			this.Controls.SetChildIndex(this.personSelector, 0);
			this.Controls.SetChildIndex(this.grid, 0);
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.personEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptyPersonEdit)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.BaseGrid grid;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView;
		private DevExpress.XtraGrid.Columns.GridColumn colName;
		private DevExpress.XtraGrid.Columns.GridColumn colEmail;
		private DevExpress.XtraGrid.Columns.GridColumn colJoinDate;
		private DevExpress.XtraGrid.Columns.GridColumn colFullName;
		private ShomreiTorah.Billing.Controls.PersonSelector personSelector;
		private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit emptyPersonEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit personEdit;
	}
}