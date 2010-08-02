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
			this.grid = new ShomreiTorah.Billing.Controls.BaseGrid(this.components);
			this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPledgeType = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.currencyEditor = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.colMensSeats = new DevExpress.XtraGrid.Columns.GridColumn();
			this.seatCountEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.colWomensSeats = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colBoysSeats = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colGirlsSeats = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colNotes = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
			this.personSelector = new ShomreiTorah.Billing.Controls.PersonSelector();
			this.addNewPanel = new DevExpress.XtraEditors.PanelControl();
			this.cancelAddEntry = new DevExpress.XtraEditors.SimpleButton();
			this.addNewEdit = new ShomreiTorah.Billing.Events.Seating.SeatingReservationEdit();
			this.addEntry = new DevExpress.XtraEditors.SimpleButton();
			this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.wordButton = new DevExpress.XtraBars.BarButtonItem();
			this.wordDocsMenu = new DevExpress.XtraBars.PopupMenu(this.components);
			this.wordDocList = new DevExpress.XtraBars.BarListItem();
			this.openWordDoc = new DevExpress.XtraBars.BarButtonItem();
			this.repositoryItemPersonRefEdit1 = new ShomreiTorah.Billing.Controls.Editors.RepositoryItemPersonRefEdit();
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.currencyEditor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.seatCountEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.addNewPanel)).BeginInit();
			this.addNewPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.wordDocsMenu)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemPersonRefEdit1)).BeginInit();
			this.SuspendLayout();
			// 
			// ribbon
			// 
			this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.wordButton,
            this.openWordDoc,
            this.wordDocList});
			this.ribbon.MaxItemId = 8;
			this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
			this.ribbon.SelectedPage = this.ribbonPage1;
			this.ribbon.Size = new System.Drawing.Size(1011, 116);
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
            this.seatCountEdit,
            this.currencyEditor,
            this.repositoryItemPersonRefEdit1});
			this.grid.Size = new System.Drawing.Size(1011, 493);
			this.grid.TabIndex = 2;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDate,
            this.colFullName,
            this.colPledgeType,
            this.colAmount,
            this.colMensSeats,
            this.colWomensSeats,
            this.colBoysSeats,
            this.colGirlsSeats,
            this.colNotes,
            this.colStatus});
			this.gridView.GridControl = this.grid;
			this.gridView.Name = "gridView";
			this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
			this.gridView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView_CustomUnboundColumnData);
			this.gridView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyUp);
			// 
			// colDate
			// 
			this.colDate.Caption = "Date";
			this.colDate.FieldName = "Pledge/Date";
			this.colDate.Name = "colDate";
			this.colDate.OptionsColumn.AllowEdit = false;
			this.colDate.OptionsColumn.ReadOnly = true;
			this.colDate.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
			this.colDate.Visible = true;
			this.colDate.VisibleIndex = 1;
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
			this.colFullName.Visible = true;
			this.colFullName.VisibleIndex = 0;
			// 
			// colPledgeType
			// 
			this.colPledgeType.Caption = "Pledge Type";
			this.colPledgeType.FieldName = "Pledge/Type";
			this.colPledgeType.Name = "colPledgeType";
			this.colPledgeType.UnboundType = DevExpress.Data.UnboundColumnType.String;
			this.colPledgeType.Visible = true;
			this.colPledgeType.VisibleIndex = 2;
			// 
			// colAmount
			// 
			this.colAmount.Caption = "Amount";
			this.colAmount.ColumnEdit = this.currencyEditor;
			this.colAmount.FieldName = "Pledge/Amount";
			this.colAmount.Name = "colAmount";
			this.colAmount.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
			this.colAmount.Visible = true;
			this.colAmount.VisibleIndex = 3;
			// 
			// currencyEditor
			// 
			this.currencyEditor.AutoHeight = false;
			this.currencyEditor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.currencyEditor.DisplayFormat.FormatString = "c";
			this.currencyEditor.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.currencyEditor.EditFormat.FormatString = "c";
			this.currencyEditor.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.currencyEditor.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.currencyEditor.Mask.EditMask = "c";
			this.currencyEditor.Name = "currencyEditor";
			// 
			// colMensSeats
			// 
			this.colMensSeats.ColumnEdit = this.seatCountEdit;
			this.colMensSeats.FieldName = "MensSeats";
			this.colMensSeats.Name = "colMensSeats";
			this.colMensSeats.Visible = true;
			this.colMensSeats.VisibleIndex = 4;
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
			this.colWomensSeats.VisibleIndex = 5;
			// 
			// colBoysSeats
			// 
			this.colBoysSeats.ColumnEdit = this.seatCountEdit;
			this.colBoysSeats.FieldName = "BoysSeats";
			this.colBoysSeats.Name = "colBoysSeats";
			this.colBoysSeats.Visible = true;
			this.colBoysSeats.VisibleIndex = 6;
			// 
			// colGirlsSeats
			// 
			this.colGirlsSeats.ColumnEdit = this.seatCountEdit;
			this.colGirlsSeats.FieldName = "GirlsSeats";
			this.colGirlsSeats.Name = "colGirlsSeats";
			this.colGirlsSeats.Visible = true;
			this.colGirlsSeats.VisibleIndex = 7;
			// 
			// colNotes
			// 
			this.colNotes.FieldName = "Notes";
			this.colNotes.Name = "colNotes";
			this.colNotes.Visible = true;
			this.colNotes.VisibleIndex = 8;
			// 
			// colStatus
			// 
			this.colStatus.FieldName = "Status";
			this.colStatus.Name = "colStatus";
			this.colStatus.Visible = true;
			this.colStatus.VisibleIndex = 9;
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
			this.personSelector.TabIndex = 0;
			this.personSelector.TabStop = false;
			this.personSelector.Value = ((object)(resources.GetObject("personSelector.Value")));
			this.personSelector.SelectedPersonChanged += new System.EventHandler(this.personSelector_SelectedPersonChanged);
			this.personSelector.SelectingPerson += new System.EventHandler<ShomreiTorah.Billing.Controls.SelectingPersonEventArgs>(this.personSelector_SelectingPerson);
			// 
			// addNewPanel
			// 
			this.addNewPanel.Controls.Add(this.cancelAddEntry);
			this.addNewPanel.Controls.Add(this.addNewEdit);
			this.addNewPanel.Controls.Add(this.addEntry);
			this.addNewPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.addNewPanel.Location = new System.Drawing.Point(0, 136);
			this.addNewPanel.Name = "addNewPanel";
			this.addNewPanel.Size = new System.Drawing.Size(1011, 97);
			this.addNewPanel.TabIndex = 1;
			this.addNewPanel.Visible = false;
			// 
			// cancelAddEntry
			// 
			this.cancelAddEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelAddEntry.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.cancelAddEntry.Appearance.Options.UseBackColor = true;
			this.cancelAddEntry.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
			this.cancelAddEntry.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelAddEntry.Image = global::ShomreiTorah.Billing.Properties.Resources.Close;
			this.cancelAddEntry.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
			this.cancelAddEntry.Location = new System.Drawing.Point(913, 0);
			this.cancelAddEntry.Name = "cancelAddEntry";
			this.cancelAddEntry.Size = new System.Drawing.Size(13, 13);
			this.cancelAddEntry.TabIndex = 2;
			this.cancelAddEntry.Text = "Close";
			this.cancelAddEntry.ToolTip = "Close";
			this.cancelAddEntry.Click += new System.EventHandler(this.cancelAddEntry_Click);
			// 
			// addNewEdit
			// 
			this.addNewEdit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.addNewEdit.Location = new System.Drawing.Point(2, 2);
			this.addNewEdit.Name = "addNewEdit";
			this.addNewEdit.Size = new System.Drawing.Size(924, 93);
			this.addNewEdit.TabIndex = 0;
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
			this.addEntry.TabIndex = 1;
			this.addEntry.Text = "Add Reservation";
			this.addEntry.Click += new System.EventHandler(this.addEntry_Click);
			// 
			// ribbonPage1
			// 
			this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
			this.ribbonPage1.Name = "ribbonPage1";
			this.ribbonPage1.Text = "Events";
			// 
			// ribbonPageGroup1
			// 
			this.ribbonPageGroup1.ItemLinks.Add(this.wordButton);
			this.ribbonPageGroup1.Name = "ribbonPageGroup1";
			this.ribbonPageGroup1.ShowCaptionButton = false;
			this.ribbonPageGroup1.Text = "ימים נוראים";
			// 
			// wordButton
			// 
			this.wordButton.ActAsDropDown = true;
			this.wordButton.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
			this.wordButton.Caption = "Seating Chart";
			this.wordButton.DropDownControl = this.wordDocsMenu;
			this.wordButton.Id = 4;
			this.wordButton.LargeGlyph = global::ShomreiTorah.Billing.Properties.Resources.WordDocuments32;
			this.wordButton.Name = "wordButton";
			// 
			// wordDocsMenu
			// 
			this.wordDocsMenu.ItemLinks.Add(this.wordDocList, true);
			this.wordDocsMenu.ItemLinks.Add(this.openWordDoc, true);
			this.wordDocsMenu.MenuCaption = "Open Documents";
			this.wordDocsMenu.Name = "wordDocsMenu";
			this.wordDocsMenu.Ribbon = this.ribbon;
			this.wordDocsMenu.ShowCaption = true;
			this.wordDocsMenu.BeforePopup += new System.ComponentModel.CancelEventHandler(this.wordDocsMenu_BeforePopup);
			// 
			// wordDocList
			// 
			this.wordDocList.Caption = "Documents";
			this.wordDocList.Id = 7;
			this.wordDocList.Name = "wordDocList";
			this.wordDocList.ListItemClick += new DevExpress.XtraBars.ListItemClickEventHandler(this.wordDocList_ListItemClick);
			// 
			// openWordDoc
			// 
			this.openWordDoc.Caption = "&Open...";
			this.openWordDoc.Glyph = global::ShomreiTorah.Billing.Properties.Resources.Open16;
			this.openWordDoc.Id = 6;
			this.openWordDoc.Name = "openWordDoc";
			this.openWordDoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.openWordDoc_ItemClick);
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
			this.Controls.SetChildIndex(this.ribbon, 0);
			this.Controls.SetChildIndex(this.personSelector, 0);
			this.Controls.SetChildIndex(this.addNewPanel, 0);
			this.Controls.SetChildIndex(this.grid, 0);
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.currencyEditor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.seatCountEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.addNewPanel)).EndInit();
			this.addNewPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.wordDocsMenu)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemPersonRefEdit1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private Controls.BaseGrid grid;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView;
		private Controls.PersonSelector personSelector;
		private DevExpress.XtraEditors.PanelControl addNewPanel;
		private DevExpress.XtraEditors.SimpleButton addEntry;
		private SeatingReservationEdit addNewEdit;
		private DevExpress.XtraGrid.Columns.GridColumn colFullName;
		private DevExpress.XtraGrid.Columns.GridColumn colMensSeats;
		private DevExpress.XtraGrid.Columns.GridColumn colWomensSeats;
		private DevExpress.XtraGrid.Columns.GridColumn colBoysSeats;
		private DevExpress.XtraGrid.Columns.GridColumn colGirlsSeats;
		private DevExpress.XtraGrid.Columns.GridColumn colNotes;
		private DevExpress.XtraGrid.Columns.GridColumn colStatus;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit seatCountEdit;
		private DevExpress.XtraEditors.SimpleButton cancelAddEntry;
		private DevExpress.XtraGrid.Columns.GridColumn colDate;
		private DevExpress.XtraGrid.Columns.GridColumn colPledgeType;
		private DevExpress.XtraGrid.Columns.GridColumn colAmount;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit currencyEditor;
		private DevExpress.XtraBars.BarButtonItem wordButton;
		private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
		private DevExpress.XtraBars.BarButtonItem openWordDoc;
		private DevExpress.XtraBars.BarListItem wordDocList;
		private DevExpress.XtraBars.PopupMenu wordDocsMenu;
		private Controls.Editors.RepositoryItemPersonRefEdit repositoryItemPersonRefEdit1;
	}
}