namespace ShomreiTorah.Billing.Import.Raffle {
	partial class RaffleImporter {
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
			DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaffleImporter));
			this.originalTicketsView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colHisName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colHerName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCity = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colState = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colZip = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPhone = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTicketID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPaid = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colNotes = new DevExpress.XtraGrid.Columns.GridColumn();
			this.grid = new DevExpress.XtraGrid.GridControl();
			this.importedTicketsView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colHisName1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colHerName1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colLastName1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAddress1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAccount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.accountEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSubType = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.currencyEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.colAmountPaid = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPaymentMethod = new DevExpress.XtraGrid.Columns.GridColumn();
			this.paymentMethodEdit = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
			this.colCheckNumber = new DevExpress.XtraGrid.Columns.GridColumn();
			this.checkNumberEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			this.colComments = new DevExpress.XtraGrid.Columns.GridColumn();
			this.unpaidEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			this.panel1 = new System.Windows.Forms.Panel();
			this.ok = new DevExpress.XtraEditors.SimpleButton();
			this.cancel = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.originalTicketsView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.importedTicketsView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.accountEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.currencyEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentMethodEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkNumberEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.unpaidEdit)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// originalTicketsView
			// 
			this.originalTicketsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFullName,
            this.colHisName,
            this.colHerName,
            this.colLastName,
            this.colAddress,
            this.colCity,
            this.colState,
            this.colZip,
            this.colPhone,
            this.colTicketID,
            this.colPaid,
            this.colNotes});
			this.originalTicketsView.GridControl = this.grid;
			this.originalTicketsView.Name = "originalTicketsView";
			this.originalTicketsView.OptionsView.ShowGroupPanel = false;
			// 
			// colFullName
			// 
			this.colFullName.FieldName = "FullName";
			this.colFullName.Name = "colFullName";
			this.colFullName.OptionsColumn.AllowEdit = false;
			this.colFullName.OptionsColumn.AllowFocus = false;
			this.colFullName.OptionsColumn.ReadOnly = true;
			this.colFullName.Visible = true;
			this.colFullName.VisibleIndex = 0;
			// 
			// colHisName
			// 
			this.colHisName.FieldName = "HisName";
			this.colHisName.Name = "colHisName";
			this.colHisName.OptionsColumn.AllowEdit = false;
			this.colHisName.OptionsColumn.AllowFocus = false;
			this.colHisName.OptionsColumn.ReadOnly = true;
			this.colHisName.Visible = true;
			this.colHisName.VisibleIndex = 1;
			// 
			// colHerName
			// 
			this.colHerName.FieldName = "HerName";
			this.colHerName.Name = "colHerName";
			this.colHerName.OptionsColumn.AllowEdit = false;
			this.colHerName.OptionsColumn.AllowFocus = false;
			this.colHerName.OptionsColumn.ReadOnly = true;
			this.colHerName.Visible = true;
			this.colHerName.VisibleIndex = 2;
			// 
			// colLastName
			// 
			this.colLastName.FieldName = "LastName";
			this.colLastName.Name = "colLastName";
			this.colLastName.OptionsColumn.AllowEdit = false;
			this.colLastName.OptionsColumn.AllowFocus = false;
			this.colLastName.OptionsColumn.ReadOnly = true;
			this.colLastName.Visible = true;
			this.colLastName.VisibleIndex = 3;
			// 
			// colAddress
			// 
			this.colAddress.FieldName = "Address";
			this.colAddress.Name = "colAddress";
			this.colAddress.OptionsColumn.AllowEdit = false;
			this.colAddress.OptionsColumn.AllowFocus = false;
			this.colAddress.OptionsColumn.ReadOnly = true;
			this.colAddress.Visible = true;
			this.colAddress.VisibleIndex = 4;
			// 
			// colCity
			// 
			this.colCity.FieldName = "City";
			this.colCity.Name = "colCity";
			this.colCity.OptionsColumn.AllowEdit = false;
			this.colCity.OptionsColumn.AllowFocus = false;
			this.colCity.OptionsColumn.ReadOnly = true;
			this.colCity.Visible = true;
			this.colCity.VisibleIndex = 5;
			// 
			// colState
			// 
			this.colState.FieldName = "State";
			this.colState.Name = "colState";
			this.colState.OptionsColumn.AllowEdit = false;
			this.colState.OptionsColumn.AllowFocus = false;
			this.colState.OptionsColumn.ReadOnly = true;
			this.colState.Visible = true;
			this.colState.VisibleIndex = 6;
			// 
			// colZip
			// 
			this.colZip.FieldName = "Zip";
			this.colZip.Name = "colZip";
			this.colZip.OptionsColumn.AllowEdit = false;
			this.colZip.OptionsColumn.AllowFocus = false;
			this.colZip.OptionsColumn.ReadOnly = true;
			this.colZip.Visible = true;
			this.colZip.VisibleIndex = 7;
			// 
			// colPhone
			// 
			this.colPhone.FieldName = "Phone";
			this.colPhone.Name = "colPhone";
			this.colPhone.OptionsColumn.AllowEdit = false;
			this.colPhone.OptionsColumn.AllowFocus = false;
			this.colPhone.OptionsColumn.ReadOnly = true;
			this.colPhone.Visible = true;
			this.colPhone.VisibleIndex = 8;
			// 
			// colTicketID
			// 
			this.colTicketID.FieldName = "TicketID";
			this.colTicketID.Name = "colTicketID";
			this.colTicketID.OptionsColumn.AllowEdit = false;
			this.colTicketID.OptionsColumn.AllowFocus = false;
			this.colTicketID.OptionsColumn.ReadOnly = true;
			this.colTicketID.Visible = true;
			this.colTicketID.VisibleIndex = 9;
			// 
			// colPaid
			// 
			this.colPaid.FieldName = "Paid";
			this.colPaid.Name = "colPaid";
			this.colPaid.OptionsColumn.AllowEdit = false;
			this.colPaid.OptionsColumn.AllowFocus = false;
			this.colPaid.OptionsColumn.ReadOnly = true;
			this.colPaid.Visible = true;
			this.colPaid.VisibleIndex = 10;
			// 
			// colNotes
			// 
			this.colNotes.FieldName = "Notes";
			this.colNotes.Name = "colNotes";
			this.colNotes.OptionsColumn.AllowEdit = false;
			this.colNotes.OptionsColumn.AllowFocus = false;
			this.colNotes.OptionsColumn.ReadOnly = true;
			this.colNotes.Visible = true;
			this.colNotes.VisibleIndex = 11;
			// 
			// grid
			// 
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			gridLevelNode1.LevelTemplate = this.originalTicketsView;
			gridLevelNode1.RelationName = "Tickets";
			this.grid.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
			this.grid.Location = new System.Drawing.Point(0, 0);
			this.grid.MainView = this.importedTicketsView;
			this.grid.Name = "grid";
			this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.accountEdit,
            this.currencyEdit,
            this.checkNumberEdit,
            this.paymentMethodEdit,
            this.unpaidEdit});
			this.grid.Size = new System.Drawing.Size(1008, 502);
			this.grid.TabIndex = 0;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.importedTicketsView,
            this.originalTicketsView});
			this.grid.ViewRegistered += new DevExpress.XtraGrid.ViewOperationEventHandler(this.grid_ViewRegistered);
			// 
			// importedTicketsView
			// 
			this.importedTicketsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHisName1,
            this.colHerName1,
            this.colLastName1,
            this.colAddress1,
            this.colAccount,
            this.colType,
            this.colSubType,
            this.colNote,
            this.colAmount,
            this.colAmountPaid,
            this.colPaymentMethod,
            this.colCheckNumber,
            this.colComments});
			this.importedTicketsView.GridControl = this.grid;
			this.importedTicketsView.Name = "importedTicketsView";
			this.importedTicketsView.OptionsDetail.ShowDetailTabs = false;
			this.importedTicketsView.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.importedTicketsView_CustomRowCellEdit);
			this.importedTicketsView.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.importedTicketsView_ShowingEditor);
			this.importedTicketsView.DoubleClick += new System.EventHandler(this.importedTicketsView_DoubleClick);
			// 
			// colHisName1
			// 
			this.colHisName1.FieldName = "HisName";
			this.colHisName1.Name = "colHisName1";
			this.colHisName1.OptionsColumn.AllowEdit = false;
			this.colHisName1.OptionsColumn.ReadOnly = true;
			this.colHisName1.Visible = true;
			this.colHisName1.VisibleIndex = 0;
			// 
			// colHerName1
			// 
			this.colHerName1.FieldName = "HerName";
			this.colHerName1.Name = "colHerName1";
			this.colHerName1.OptionsColumn.AllowEdit = false;
			this.colHerName1.OptionsColumn.ReadOnly = true;
			this.colHerName1.Visible = true;
			this.colHerName1.VisibleIndex = 1;
			// 
			// colLastName1
			// 
			this.colLastName1.FieldName = "LastName";
			this.colLastName1.Name = "colLastName1";
			this.colLastName1.OptionsColumn.AllowEdit = false;
			this.colLastName1.OptionsColumn.ReadOnly = true;
			this.colLastName1.Visible = true;
			this.colLastName1.VisibleIndex = 2;
			// 
			// colAddress1
			// 
			this.colAddress1.FieldName = "Address";
			this.colAddress1.Name = "colAddress1";
			this.colAddress1.OptionsColumn.AllowEdit = false;
			this.colAddress1.OptionsColumn.ReadOnly = true;
			this.colAddress1.Visible = true;
			this.colAddress1.VisibleIndex = 3;
			// 
			// colAccount
			// 
			this.colAccount.ColumnEdit = this.accountEdit;
			this.colAccount.FieldName = "Account";
			this.colAccount.Name = "colAccount";
			this.colAccount.Visible = true;
			this.colAccount.VisibleIndex = 4;
			// 
			// accountEdit
			// 
			this.accountEdit.AutoHeight = false;
			this.accountEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.accountEdit.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
			this.accountEdit.Name = "accountEdit";
			// 
			// colType
			// 
			this.colType.FieldName = "Type";
			this.colType.Name = "colType";
			this.colType.Visible = true;
			this.colType.VisibleIndex = 5;
			// 
			// colSubType
			// 
			this.colSubType.FieldName = "SubType";
			this.colSubType.Name = "colSubType";
			this.colSubType.Visible = true;
			this.colSubType.VisibleIndex = 6;
			// 
			// colNote
			// 
			this.colNote.FieldName = "Note";
			this.colNote.Name = "colNote";
			this.colNote.Visible = true;
			this.colNote.VisibleIndex = 7;
			// 
			// colAmount
			// 
			this.colAmount.ColumnEdit = this.currencyEdit;
			this.colAmount.FieldName = "Amount";
			this.colAmount.Name = "colAmount";
			this.colAmount.Visible = true;
			this.colAmount.VisibleIndex = 8;
			// 
			// currencyEdit
			// 
			this.currencyEdit.AutoHeight = false;
			this.currencyEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.currencyEdit.DisplayFormat.FormatString = "c";
			this.currencyEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.currencyEdit.EditFormat.FormatString = "c";
			this.currencyEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.currencyEdit.Mask.EditMask = "c";
			this.currencyEdit.Name = "currencyEdit";
			// 
			// colAmountPaid
			// 
			this.colAmountPaid.ColumnEdit = this.currencyEdit;
			this.colAmountPaid.FieldName = "AmountPaid";
			this.colAmountPaid.Name = "colAmountPaid";
			this.colAmountPaid.Visible = true;
			this.colAmountPaid.VisibleIndex = 9;
			// 
			// colPaymentMethod
			// 
			this.colPaymentMethod.ColumnEdit = this.paymentMethodEdit;
			this.colPaymentMethod.FieldName = "PaymentMethod";
			this.colPaymentMethod.Name = "colPaymentMethod";
			this.colPaymentMethod.Visible = true;
			this.colPaymentMethod.VisibleIndex = 10;
			// 
			// paymentMethodEdit
			// 
			this.paymentMethodEdit.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Cash", "Cash"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Check", "Check")});
			this.paymentMethodEdit.Name = "paymentMethodEdit";
			// 
			// colCheckNumber
			// 
			this.colCheckNumber.ColumnEdit = this.checkNumberEdit;
			this.colCheckNumber.FieldName = "CheckNumber";
			this.colCheckNumber.Name = "colCheckNumber";
			this.colCheckNumber.Visible = true;
			this.colCheckNumber.VisibleIndex = 11;
			// 
			// checkNumberEdit
			// 
			this.checkNumberEdit.AutoHeight = false;
			this.checkNumberEdit.Mask.EditMask = "f00";
			this.checkNumberEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
			this.checkNumberEdit.Name = "checkNumberEdit";
			this.checkNumberEdit.NullText = "N/A";
			// 
			// colComments
			// 
			this.colComments.FieldName = "Comments";
			this.colComments.Name = "colComments";
			this.colComments.Visible = true;
			this.colComments.VisibleIndex = 12;
			// 
			// unpaidEdit
			// 
			this.unpaidEdit.AutoHeight = false;
			this.unpaidEdit.Name = "unpaidEdit";
			this.unpaidEdit.ReadOnly = true;
			this.unpaidEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.ok);
			this.panel1.Controls.Add(this.cancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 502);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1008, 47);
			this.panel1.TabIndex = 1;
			// 
			// ok
			// 
			this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.ok.Location = new System.Drawing.Point(840, 12);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(75, 23);
			this.ok.TabIndex = 1;
			this.ok.Text = "Import";
			this.ok.Click += new System.EventHandler(this.ok_Click);
			// 
			// cancel
			// 
			this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(921, 12);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 0;
			this.cancel.Text = "Cancel";
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// RaffleImporter
			// 
			this.AcceptButton = this.ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(1008, 549);
			this.Controls.Add(this.grid);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "RaffleImporter";
			this.Text = "Import Raffle";
			((System.ComponentModel.ISupportInitialize)(this.originalTicketsView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.importedTicketsView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.accountEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.currencyEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentMethodEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkNumberEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.unpaidEdit)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraGrid.GridControl grid;
		private DevExpress.XtraGrid.Views.Grid.GridView importedTicketsView;
		private DevExpress.XtraGrid.Views.Grid.GridView originalTicketsView;
		private DevExpress.XtraGrid.Columns.GridColumn colFullName;
		private DevExpress.XtraGrid.Columns.GridColumn colHisName;
		private DevExpress.XtraGrid.Columns.GridColumn colHerName;
		private DevExpress.XtraGrid.Columns.GridColumn colLastName;
		private DevExpress.XtraGrid.Columns.GridColumn colAddress;
		private DevExpress.XtraGrid.Columns.GridColumn colCity;
		private DevExpress.XtraGrid.Columns.GridColumn colState;
		private DevExpress.XtraGrid.Columns.GridColumn colZip;
		private DevExpress.XtraGrid.Columns.GridColumn colPhone;
		private DevExpress.XtraGrid.Columns.GridColumn colTicketID;
		private DevExpress.XtraGrid.Columns.GridColumn colPaid;
		private DevExpress.XtraGrid.Columns.GridColumn colNotes;
		private DevExpress.XtraGrid.Columns.GridColumn colHisName1;
		private DevExpress.XtraGrid.Columns.GridColumn colHerName1;
		private DevExpress.XtraGrid.Columns.GridColumn colLastName1;
		private DevExpress.XtraGrid.Columns.GridColumn colAddress1;
		private DevExpress.XtraGrid.Columns.GridColumn colAccount;
		private DevExpress.XtraGrid.Columns.GridColumn colType;
		private DevExpress.XtraGrid.Columns.GridColumn colSubType;
		private DevExpress.XtraGrid.Columns.GridColumn colNote;
		private DevExpress.XtraGrid.Columns.GridColumn colAmount;
		private DevExpress.XtraGrid.Columns.GridColumn colComments;
		private DevExpress.XtraGrid.Columns.GridColumn colAmountPaid;
		private DevExpress.XtraGrid.Columns.GridColumn colPaymentMethod;
		private DevExpress.XtraGrid.Columns.GridColumn colCheckNumber;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox accountEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit currencyEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit checkNumberEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup paymentMethodEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit unpaidEdit;
		private System.Windows.Forms.Panel panel1;
		private DevExpress.XtraEditors.SimpleButton ok;
		private DevExpress.XtraEditors.SimpleButton cancel;

	}
}