namespace ShomreiTorah.Billing.Events.Seating {
	partial class SeatingForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeatingForm));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
			this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
			this.grid = new ShomreiTorah.Billing.Controls.BaseGrid(this.components);
			this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.personEdit = new ShomreiTorah.Billing.Controls.Editors.RepositoryItemPersonRefEdit();
			this.colMensSeats = new DevExpress.XtraGrid.Columns.GridColumn();
			this.seatCountEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.colWomensSeats = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colBoysSeats = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colGirlsSeats = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colNotes = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
			this.personRefEdit = new ShomreiTorah.Billing.Controls.Editors.RepositoryItemPersonRefEdit();
			this.personSelector = new ShomreiTorah.Billing.Controls.PersonSelector();
			this.addNewPanel = new DevExpress.XtraEditors.PanelControl();
			this.addNewEdit = new ShomreiTorah.Billing.Events.Seating.SeatingReservationEdit();
			this.addEntry = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.personEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.seatCountEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.personRefEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.addNewPanel)).BeginInit();
			this.addNewPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// ribbon
			// 
			this.ribbon.ApplicationButtonText = null;
			this.ribbon.Location = new System.Drawing.Point(0, 0);
			this.ribbon.MaxItemId = 4;
			this.ribbon.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
			this.ribbon.Name = "ribbon";
			this.ribbon.Size = new System.Drawing.Size(753, 21);
			this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
			// 
			// grid
			// 
			this.grid.DataMember = "SeatingReservations";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 233);
			this.grid.MainView = this.gridView;
			this.grid.MenuManager = this.ribbon;
			this.grid.Name = "grid";
			this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.personEdit,
            this.seatCountEdit});
			this.grid.Size = new System.Drawing.Size(1011, 493);
			this.grid.TabIndex = 1;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFullName,
            this.colMensSeats,
            this.colWomensSeats,
            this.colBoysSeats,
            this.colGirlsSeats,
            this.colNotes,
            this.colStatus});
			this.gridView.GridControl = this.grid;
			this.gridView.Name = "gridView";
			// 
			// colFullName
			// 
			this.colFullName.ColumnEdit = this.personEdit;
			this.colFullName.FieldName = "FullName";
			this.colFullName.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical;
			this.colFullName.Name = "colFullName";
			this.colFullName.OptionsColumn.ReadOnly = true;
			this.colFullName.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colFullName.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
			this.colFullName.Visible = true;
			this.colFullName.VisibleIndex = 0;
			// 
			// personEdit
			// 
			this.personEdit.AutoHeight = false;
			this.personEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("personEdit.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Show Person", null, null, true)});
			this.personEdit.Name = "personEdit";
			this.personEdit.ReadOnly = true;
			this.personEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			// 
			// colMensSeats
			// 
			this.colMensSeats.ColumnEdit = this.seatCountEdit;
			this.colMensSeats.FieldName = "MensSeats";
			this.colMensSeats.Name = "colMensSeats";
			this.colMensSeats.Visible = true;
			this.colMensSeats.VisibleIndex = 1;
			// 
			// seatCountEdit
			// 
			this.seatCountEdit.AutoHeight = false;
			this.seatCountEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.seatCountEdit.IsFloatValue = false;
			this.seatCountEdit.Mask.EditMask = "N00";
			this.seatCountEdit.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.seatCountEdit.Name = "seatCountEdit";
			// 
			// colWomensSeats
			// 
			this.colWomensSeats.ColumnEdit = this.seatCountEdit;
			this.colWomensSeats.FieldName = "WomensSeats";
			this.colWomensSeats.Name = "colWomensSeats";
			this.colWomensSeats.Visible = true;
			this.colWomensSeats.VisibleIndex = 2;
			// 
			// colBoysSeats
			// 
			this.colBoysSeats.ColumnEdit = this.seatCountEdit;
			this.colBoysSeats.FieldName = "BoysSeats";
			this.colBoysSeats.Name = "colBoysSeats";
			this.colBoysSeats.Visible = true;
			this.colBoysSeats.VisibleIndex = 3;
			// 
			// colGirlsSeats
			// 
			this.colGirlsSeats.ColumnEdit = this.seatCountEdit;
			this.colGirlsSeats.FieldName = "GirlsSeats";
			this.colGirlsSeats.Name = "colGirlsSeats";
			this.colGirlsSeats.Visible = true;
			this.colGirlsSeats.VisibleIndex = 4;
			// 
			// colNotes
			// 
			this.colNotes.FieldName = "Notes";
			this.colNotes.Name = "colNotes";
			this.colNotes.Visible = true;
			this.colNotes.VisibleIndex = 5;
			// 
			// colStatus
			// 
			this.colStatus.FieldName = "Status";
			this.colStatus.Name = "colStatus";
			this.colStatus.Visible = true;
			this.colStatus.VisibleIndex = 6;
			// 
			// personRefEdit
			// 
			this.personRefEdit.AutoHeight = false;
			this.personRefEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("personRefEdit.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Show Person", null, null, true)});
			this.personRefEdit.Name = "personRefEdit";
			this.personRefEdit.ReadOnly = true;
			this.personRefEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
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
			this.personSelector.Size = new System.Drawing.Size(1011, 20);
			this.personSelector.TabIndex = 2;
			this.personSelector.TabStop = false;
			this.personSelector.Value = ((object)(resources.GetObject("personSelector.Value")));
			this.personSelector.SelectedPersonChanged += new System.EventHandler(this.personSelector_SelectedPersonChanged);
			this.personSelector.SelectingPerson += new System.EventHandler<ShomreiTorah.Billing.Controls.SelectingPersonEventArgs>(this.personSelector_SelectingPerson);
			// 
			// addNewPanel
			// 
			this.addNewPanel.Controls.Add(this.addNewEdit);
			this.addNewPanel.Controls.Add(this.addEntry);
			this.addNewPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.addNewPanel.Location = new System.Drawing.Point(0, 136);
			this.addNewPanel.Name = "addNewPanel";
			this.addNewPanel.Size = new System.Drawing.Size(1011, 97);
			this.addNewPanel.TabIndex = 3;
			this.addNewPanel.Visible = false;
			// 
			// addNewEdit
			// 
			this.addNewEdit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.addNewEdit.Location = new System.Drawing.Point(2, 2);
			this.addNewEdit.Name = "addNewEdit";
			this.addNewEdit.Size = new System.Drawing.Size(924, 93);
			this.addNewEdit.TabIndex = 1;
			// 
			// addEntry
			// 
			this.addEntry.Appearance.Options.UseTextOptions = true;
			this.addEntry.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.addEntry.Dock = System.Windows.Forms.DockStyle.Right;
			this.addEntry.Image = global::ShomreiTorah.Billing.Properties.Resources.Add32;
			this.addEntry.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
			this.addEntry.Location = new System.Drawing.Point(926, 2);
			this.addEntry.Name = "addEntry";
			this.addEntry.Size = new System.Drawing.Size(83, 93);
			this.addEntry.TabIndex = 0;
			this.addEntry.Text = "Add Reservation";
			this.addEntry.Click += new System.EventHandler(this.addEntry_Click);
			// 
			// SeatingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1011, 726);
			this.Controls.Add(this.grid);
			this.Controls.Add(this.addNewPanel);
			this.Controls.Add(this.personSelector);
			this.MainView = this.gridView;
			this.Name = "SeatingForm";
			this.Text = "Seating Reservations";
			this.Controls.SetChildIndex(this.personSelector, 0);
			this.Controls.SetChildIndex(this.addNewPanel, 0);
			this.Controls.SetChildIndex(this.grid, 0);
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.personEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.seatCountEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.personRefEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.addNewPanel)).EndInit();
			this.addNewPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
		private Controls.BaseGrid grid;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView;
		private Controls.PersonSelector personSelector;
		private DevExpress.XtraEditors.PanelControl addNewPanel;
		private DevExpress.XtraEditors.SimpleButton addEntry;
		private SeatingReservationEdit addNewEdit;
		private Controls.Editors.RepositoryItemPersonRefEdit personRefEdit;
		private DevExpress.XtraGrid.Columns.GridColumn colFullName;
		private DevExpress.XtraGrid.Columns.GridColumn colMensSeats;
		private DevExpress.XtraGrid.Columns.GridColumn colWomensSeats;
		private DevExpress.XtraGrid.Columns.GridColumn colBoysSeats;
		private DevExpress.XtraGrid.Columns.GridColumn colGirlsSeats;
		private DevExpress.XtraGrid.Columns.GridColumn colNotes;
		private DevExpress.XtraGrid.Columns.GridColumn colStatus;
		private Controls.Editors.RepositoryItemPersonRefEdit personEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit seatCountEdit;
	}
}