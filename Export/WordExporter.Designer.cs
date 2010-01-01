namespace ShomreiTorah.Billing.Export {
	partial class WordExporter {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WordExporter));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.grid = new DevExpress.XtraGrid.GridControl();
			this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colHisName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colHerName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTotalPaid = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colBalanceDue = new DevExpress.XtraGrid.Columns.GridColumn();
			this.buttonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			this.cancel = new DevExpress.XtraEditors.SimpleButton();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.startDate = new DevExpress.XtraEditors.DateEdit();
			this.docType = new DevExpress.XtraEditors.ComboBoxEdit();
			this.createDoc = new DevExpress.XtraEditors.DropDownButton();
			this.mailingMenu = new DevExpress.XtraBars.PopupMenu(this.components);
			this.createEnvelopes = new DevExpress.XtraBars.BarButtonItem();
			this.createLabels = new DevExpress.XtraBars.BarButtonItem();
			this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.startDate.Properties.VistaTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.startDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.docType.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mailingMenu)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
			this.SuspendLayout();
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(12, 15);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(77, 13);
			this.labelControl1.TabIndex = 10;
			this.labelControl1.Text = "Document type:";
			// 
			// grid
			// 
			this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grid.Location = new System.Drawing.Point(12, 83);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.buttonEdit});
			this.grid.ShowOnlyPredefinedDetails = true;
			this.grid.Size = new System.Drawing.Size(572, 248);
			this.grid.TabIndex = 16;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLastName,
            this.colHisName,
            this.colHerName,
            this.colAddress,
            this.colTotalPaid,
            this.colBalanceDue});
			this.gridView.GridControl = this.grid;
			this.gridView.Name = "gridView";
			this.gridView.OptionsView.ShowGroupPanel = false;
			this.gridView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLastName, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// colLastName
			// 
			this.colLastName.FieldName = "LastName";
			this.colLastName.Name = "colLastName";
			this.colLastName.OptionsColumn.AllowEdit = false;
			this.colLastName.OptionsColumn.ReadOnly = true;
			this.colLastName.Visible = true;
			this.colLastName.VisibleIndex = 0;
			// 
			// colHisName
			// 
			this.colHisName.FieldName = "HisName";
			this.colHisName.Name = "colHisName";
			this.colHisName.OptionsColumn.AllowEdit = false;
			this.colHisName.OptionsColumn.ReadOnly = true;
			this.colHisName.Visible = true;
			this.colHisName.VisibleIndex = 1;
			// 
			// colHerName
			// 
			this.colHerName.FieldName = "HerName";
			this.colHerName.Name = "colHerName";
			this.colHerName.OptionsColumn.AllowEdit = false;
			this.colHerName.OptionsColumn.ReadOnly = true;
			this.colHerName.Visible = true;
			this.colHerName.VisibleIndex = 2;
			// 
			// colAddress
			// 
			this.colAddress.FieldName = "Address";
			this.colAddress.Name = "colAddress";
			this.colAddress.OptionsColumn.AllowEdit = false;
			this.colAddress.OptionsColumn.ReadOnly = true;
			this.colAddress.Visible = true;
			this.colAddress.VisibleIndex = 3;
			// 
			// colTotalPaid
			// 
			this.colTotalPaid.DisplayFormat.FormatString = "c";
			this.colTotalPaid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colTotalPaid.FieldName = "TotalPaid";
			this.colTotalPaid.Name = "colTotalPaid";
			this.colTotalPaid.OptionsColumn.AllowEdit = false;
			this.colTotalPaid.OptionsColumn.ReadOnly = true;
			this.colTotalPaid.Visible = true;
			this.colTotalPaid.VisibleIndex = 4;
			// 
			// colBalanceDue
			// 
			this.colBalanceDue.DisplayFormat.FormatString = "c";
			this.colBalanceDue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colBalanceDue.FieldName = "BalanceDue";
			this.colBalanceDue.Name = "colBalanceDue";
			this.colBalanceDue.OptionsColumn.AllowEdit = false;
			this.colBalanceDue.OptionsColumn.ReadOnly = true;
			this.colBalanceDue.Visible = true;
			this.colBalanceDue.VisibleIndex = 5;
			// 
			// buttonEdit
			// 
			this.buttonEdit.AutoHeight = false;
			this.buttonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Show Preview", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("buttonEdit.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, "Show Preview", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Send Preview", -1, false, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("buttonEdit.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10, "Send Preview", null, null, true)});
			this.buttonEdit.Name = "buttonEdit";
			this.buttonEdit.ReadOnly = true;
			this.buttonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			// 
			// cancel
			// 
			this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(510, 337);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 15;
			this.cancel.Text = "Cancel";
			// 
			// labelControl3
			// 
			this.labelControl3.Location = new System.Drawing.Point(12, 64);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(189, 13);
			this.labelControl3.TabIndex = 14;
			this.labelControl3.Text = "The following people will receive emails:";
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(12, 41);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(53, 13);
			this.labelControl2.TabIndex = 12;
			this.labelControl2.Text = "Start date:";
			// 
			// startDate
			// 
			this.startDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.startDate.EditValue = null;
			this.startDate.Location = new System.Drawing.Point(105, 38);
			this.startDate.Name = "startDate";
			this.startDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
			this.startDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.startDate.Properties.DisplayFormat.FormatString = "D";
			this.startDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.startDate.Properties.EditFormat.FormatString = "D";
			this.startDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.startDate.Properties.Mask.EditMask = "D";
			this.startDate.Properties.NullValuePrompt = "Please select a date";
			this.startDate.Properties.ShowToday = false;
			this.startDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
			this.startDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.startDate.Size = new System.Drawing.Size(480, 20);
			this.startDate.TabIndex = 11;
			this.startDate.EditValueChanged += new System.EventHandler(this.EditValueChanged);
			// 
			// docType
			// 
			this.docType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.docType.Location = new System.Drawing.Point(105, 12);
			this.docType.Name = "docType";
			this.docType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.docType.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
			this.docType.Properties.NullValuePrompt = "Please select a document type";
			this.docType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.docType.Size = new System.Drawing.Size(480, 20);
			this.docType.TabIndex = 9;
			this.docType.EditValueChanged += new System.EventHandler(this.EditValueChanged);
			// 
			// createDoc
			// 
			this.createDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.createDoc.DropDownControl = this.mailingMenu;
			this.createDoc.Location = new System.Drawing.Point(369, 337);
			this.createDoc.Name = "createDoc";
			this.createDoc.Size = new System.Drawing.Size(135, 23);
			this.createDoc.TabIndex = 17;
			this.createDoc.Text = "Create Document";
			this.createDoc.Click += new System.EventHandler(this.createDoc_Click);
			// 
			// mailingMenu
			// 
			this.mailingMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.createEnvelopes),
            new DevExpress.XtraBars.LinkPersistInfo(this.createLabels)});
			this.mailingMenu.Manager = this.barManager1;
			this.mailingMenu.Name = "mailingMenu";
			// 
			// createEnvelopes
			// 
			this.createEnvelopes.Caption = "Create Envelopes";
			this.createEnvelopes.Id = 0;
			this.createEnvelopes.Name = "createEnvelopes";
			this.createEnvelopes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.createEnvelopes_ItemClick);
			// 
			// createLabels
			// 
			this.createLabels.Caption = "Create Mailing Labels";
			this.createLabels.Id = 1;
			this.createLabels.Name = "createLabels";
			this.createLabels.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.createLabels_ItemClick);
			// 
			// barManager1
			// 
			this.barManager1.DockControls.Add(this.barDockControlTop);
			this.barManager1.DockControls.Add(this.barDockControlBottom);
			this.barManager1.DockControls.Add(this.barDockControlLeft);
			this.barManager1.DockControls.Add(this.barDockControlRight);
			this.barManager1.Form = this;
			this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.createEnvelopes,
            this.createLabels});
			this.barManager1.MaxItemId = 2;
			// 
			// WordExporter
			// 
			this.AcceptButton = this.createDoc;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(597, 372);
			this.Controls.Add(this.createDoc);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.grid);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.labelControl3);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.startDate);
			this.Controls.Add(this.docType);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "WordExporter";
			this.Text = "Create Word Document";
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.startDate.Properties.VistaTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.startDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.docType.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mailingMenu)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraGrid.Columns.GridColumn colHerName;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraGrid.Columns.GridColumn colAddress;
		private DevExpress.XtraGrid.Columns.GridColumn colHisName;
		private DevExpress.XtraGrid.Columns.GridColumn colTotalPaid;
		private DevExpress.XtraGrid.Columns.GridColumn colBalanceDue;
		private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit buttonEdit;
		private DevExpress.XtraGrid.Columns.GridColumn colLastName;
		private DevExpress.XtraGrid.GridControl grid;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView;
		private DevExpress.XtraEditors.SimpleButton cancel;
		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.DateEdit startDate;
		private DevExpress.XtraEditors.ComboBoxEdit docType;
		private DevExpress.XtraEditors.DropDownButton createDoc;
		private DevExpress.XtraBars.PopupMenu mailingMenu;
		private DevExpress.XtraBars.BarButtonItem createEnvelopes;
		private DevExpress.XtraBars.BarButtonItem createLabels;
		private DevExpress.XtraBars.BarManager barManager1;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
	}
}