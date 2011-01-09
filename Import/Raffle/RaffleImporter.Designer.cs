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
			this.components = new System.ComponentModel.Container();
			DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaffleImporter));
			this.originalTicketsView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colTicketAdded = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTicketId = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPaid = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTicketComments = new DevExpress.XtraGrid.Columns.GridColumn();
			this.grid = new ShomreiTorah.Data.UI.Grid.SmartGrid(this.components);
			this.importedTicketsView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colPerson = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colDate = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAccount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colType = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colSubType = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colNote = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAmount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAmountPaid = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colPaymentMethod = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.paymentMethodEdit = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
			this.colCheckNumber = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colComments = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.unpaidEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			this.panel1 = new System.Windows.Forms.Panel();
			this.ok = new DevExpress.XtraEditors.SimpleButton();
			this.cancel = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.originalTicketsView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.importedTicketsView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentMethodEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.unpaidEdit)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// originalTicketsView
			// 
			this.originalTicketsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTicketAdded,
            this.colTicketId,
            this.colPaid,
            this.colTicketComments});
			this.originalTicketsView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.originalTicketsView.GridControl = this.grid;
			this.originalTicketsView.Name = "originalTicketsView";
			this.originalTicketsView.OptionsView.ColumnAutoWidth = false;
			this.originalTicketsView.OptionsView.ShowGroupPanel = false;
			// 
			// colTicketAdded
			// 
			this.colTicketAdded.DisplayFormat.FormatString = "G";
			this.colTicketAdded.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colTicketAdded.FieldName = "DateAdded";
			this.colTicketAdded.Name = "colTicketAdded";
			this.colTicketAdded.OptionsColumn.AllowEdit = false;
			this.colTicketAdded.OptionsColumn.AllowFocus = false;
			this.colTicketAdded.OptionsColumn.ReadOnly = true;
			this.colTicketAdded.Visible = true;
			this.colTicketAdded.VisibleIndex = 0;
			// 
			// colTicketId
			// 
			this.colTicketId.DisplayFormat.FormatString = "#{0}";
			this.colTicketId.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.colTicketId.FieldName = "TicketId";
			this.colTicketId.Name = "colTicketId";
			this.colTicketId.OptionsColumn.AllowEdit = false;
			this.colTicketId.OptionsColumn.AllowFocus = false;
			this.colTicketId.OptionsColumn.ReadOnly = true;
			this.colTicketId.Visible = true;
			this.colTicketId.VisibleIndex = 1;
			// 
			// colPaid
			// 
			this.colPaid.FieldName = "Paid";
			this.colPaid.Name = "colPaid";
			this.colPaid.OptionsColumn.AllowEdit = false;
			this.colPaid.OptionsColumn.AllowFocus = false;
			this.colPaid.OptionsColumn.ReadOnly = true;
			this.colPaid.Visible = true;
			this.colPaid.VisibleIndex = 2;
			// 
			// colTicketComments
			// 
			this.colTicketComments.FieldName = "Comments";
			this.colTicketComments.Name = "colTicketComments";
			this.colTicketComments.OptionsColumn.AllowEdit = false;
			this.colTicketComments.OptionsColumn.AllowFocus = false;
			this.colTicketComments.OptionsColumn.ReadOnly = true;
			this.colTicketComments.Visible = true;
			this.colTicketComments.VisibleIndex = 3;
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
			this.grid.RegistrationCount = 50;
			this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
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
            this.colPerson,
            this.colDate,
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
			this.importedTicketsView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDate, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.importedTicketsView.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.importedTicketsView_CustomRowCellEdit);
			this.importedTicketsView.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.importedTicketsView_ShowingEditor);
			// 
			// colPerson
			// 
			this.colPerson.Caption = "Person";
			this.colPerson.FieldName = "Person";
			this.colPerson.Name = "colPerson";
			this.colPerson.Visible = true;
			this.colPerson.VisibleIndex = 0;
			// 
			// colDate
			// 
			this.colDate.Caption = "Time";
			this.colDate.DisplayFormat.FormatString = "t";
			this.colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colDate.FieldName = "Date";
			this.colDate.Name = "colDate";
			this.colDate.OptionsColumn.AllowEdit = false;
			this.colDate.Visible = true;
			this.colDate.VisibleIndex = 1;
			// 
			// colAccount
			// 
			this.colAccount.FieldName = "Account";
			this.colAccount.Name = "colAccount";
			this.colAccount.Visible = true;
			this.colAccount.VisibleIndex = 2;
			this.colAccount.Width = 58;
			// 
			// colType
			// 
			this.colType.FieldName = "Type";
			this.colType.Name = "colType";
			this.colType.Visible = true;
			this.colType.VisibleIndex = 3;
			this.colType.Width = 43;
			// 
			// colSubType
			// 
			this.colSubType.FieldName = "SubType";
			this.colSubType.Name = "colSubType";
			this.colSubType.Visible = true;
			this.colSubType.VisibleIndex = 4;
			this.colSubType.Width = 64;
			// 
			// colNote
			// 
			this.colNote.FieldName = "Note";
			this.colNote.Name = "colNote";
			this.colNote.Visible = true;
			this.colNote.VisibleIndex = 5;
			this.colNote.Width = 42;
			// 
			// colAmount
			// 
			this.colAmount.FieldName = "Amount";
			this.colAmount.Name = "colAmount";
			this.colAmount.Visible = true;
			this.colAmount.VisibleIndex = 6;
			this.colAmount.Width = 56;
			// 
			// colAmountPaid
			// 
			this.colAmountPaid.FieldName = "AmountPaid";
			this.colAmountPaid.Name = "colAmountPaid";
			this.colAmountPaid.Visible = true;
			this.colAmountPaid.VisibleIndex = 7;
			this.colAmountPaid.Width = 79;
			// 
			// colPaymentMethod
			// 
			this.colPaymentMethod.ColumnEditor = this.paymentMethodEdit;
			this.colPaymentMethod.FieldName = "PaymentMethod";
			this.colPaymentMethod.Name = "colPaymentMethod";
			this.colPaymentMethod.Visible = true;
			this.colPaymentMethod.VisibleIndex = 8;
			this.colPaymentMethod.Width = 105;
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
			this.colCheckNumber.FieldName = "CheckNumber";
			this.colCheckNumber.Name = "colCheckNumber";
			this.colCheckNumber.Visible = true;
			this.colCheckNumber.VisibleIndex = 9;
			this.colCheckNumber.Width = 88;
			// 
			// colComments
			// 
			this.colComments.FieldName = "Comments";
			this.colComments.Name = "colComments";
			this.colComments.Visible = true;
			this.colComments.VisibleIndex = 10;
			this.colComments.Width = 69;
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
			((System.ComponentModel.ISupportInitialize)(this.paymentMethodEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.unpaidEdit)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private ShomreiTorah.Data.UI.Grid.SmartGrid grid;
		private DevExpress.XtraGrid.Views.Grid.GridView originalTicketsView;
		private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup paymentMethodEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit unpaidEdit;
		private System.Windows.Forms.Panel panel1;
		private DevExpress.XtraEditors.SimpleButton ok;
		private DevExpress.XtraEditors.SimpleButton cancel;
		private Data.UI.Grid.SmartGridView importedTicketsView;
		private Data.UI.Grid.SmartGridColumn colAccount;
		private Data.UI.Grid.SmartGridColumn colType;
		private Data.UI.Grid.SmartGridColumn colSubType;
		private Data.UI.Grid.SmartGridColumn colNote;
		private Data.UI.Grid.SmartGridColumn colAmount;
		private Data.UI.Grid.SmartGridColumn colAmountPaid;
		private Data.UI.Grid.SmartGridColumn colPaymentMethod;
		private Data.UI.Grid.SmartGridColumn colCheckNumber;
		private Data.UI.Grid.SmartGridColumn colComments;
		private DevExpress.XtraGrid.Columns.GridColumn colTicketAdded;
		private DevExpress.XtraGrid.Columns.GridColumn colTicketId;
		private DevExpress.XtraGrid.Columns.GridColumn colPaid;
		private DevExpress.XtraGrid.Columns.GridColumn colTicketComments;
		private Data.UI.Grid.SmartGridColumn colPerson;
		private Data.UI.Grid.SmartGridColumn colDate;

	}
}