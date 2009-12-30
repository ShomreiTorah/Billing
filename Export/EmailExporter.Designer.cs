namespace ShomreiTorah.Billing.Export {
	partial class EmailExporter {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailExporter));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.emailTemplate = new DevExpress.XtraEditors.ComboBoxEdit();
			this.startDate = new DevExpress.XtraEditors.DateEdit();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.cancel = new DevExpress.XtraEditors.SimpleButton();
			this.sendBills = new DevExpress.XtraEditors.SimpleButton();
			this.grid = new DevExpress.XtraGrid.GridControl();
			this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.buttonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			this.colHisName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colHerName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTotalPaid = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colBalanceDue = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colEmails = new DevExpress.XtraGrid.Columns.GridColumn();
			this.previewAddress = new DevExpress.XtraEditors.TextEdit();
			this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
			((System.ComponentModel.ISupportInitialize)(this.emailTemplate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.startDate.Properties.VistaTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.startDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.previewAddress.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(12, 15);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(73, 13);
			this.labelControl1.TabIndex = 0;
			this.labelControl1.Text = "Email template:";
			// 
			// emailTemplate
			// 
			this.emailTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.emailTemplate.Location = new System.Drawing.Point(105, 12);
			this.emailTemplate.Name = "emailTemplate";
			this.emailTemplate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.emailTemplate.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
			this.emailTemplate.Properties.NullValuePrompt = "Please select an email template";
			this.emailTemplate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.emailTemplate.Size = new System.Drawing.Size(480, 20);
			this.emailTemplate.TabIndex = 0;
			this.emailTemplate.EditValueChanged += new System.EventHandler(this.EditValueChanged);
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
			this.startDate.TabIndex = 1;
			this.startDate.EditValueChanged += new System.EventHandler(this.EditValueChanged);
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(12, 41);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(53, 13);
			this.labelControl2.TabIndex = 3;
			this.labelControl2.Text = "Start date:";
			// 
			// labelControl3
			// 
			this.labelControl3.Location = new System.Drawing.Point(12, 91);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(189, 13);
			this.labelControl3.TabIndex = 5;
			this.labelControl3.Text = "The following people will receive emails:";
			// 
			// cancel
			// 
			this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(510, 337);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 5;
			this.cancel.Text = "Cancel";
			// 
			// sendBills
			// 
			this.sendBills.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.sendBills.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.sendBills.Enabled = false;
			this.sendBills.Location = new System.Drawing.Point(429, 337);
			this.sendBills.Name = "sendBills";
			this.sendBills.Size = new System.Drawing.Size(75, 23);
			this.sendBills.TabIndex = 3;
			this.sendBills.Text = "Send Bills";
			// 
			// grid
			// 
			this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grid.Location = new System.Drawing.Point(12, 110);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.buttonEdit});
			this.grid.ShowOnlyPredefinedDetails = true;
			this.grid.Size = new System.Drawing.Size(572, 221);
			this.grid.TabIndex = 6;
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
            this.colBalanceDue,
            this.colEmails});
			this.gridView.GridControl = this.grid;
			this.gridView.Name = "gridView";
			this.gridView.OptionsView.ShowGroupPanel = false;
			this.gridView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLastName, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.gridView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView_CustomUnboundColumnData);
			// 
			// colLastName
			// 
			this.colLastName.ColumnEdit = this.buttonEdit;
			this.colLastName.FieldName = "LastName";
			this.colLastName.Name = "colLastName";
			this.colLastName.OptionsColumn.ReadOnly = true;
			this.colLastName.Visible = true;
			this.colLastName.VisibleIndex = 0;
			// 
			// buttonEdit
			// 
			this.buttonEdit.AutoHeight = false;
			this.buttonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Show Preview", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("buttonEdit.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Show Preview", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Send Preview", -1, false, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("buttonEdit.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Send Preview", null, null, true)});
			this.buttonEdit.Name = "buttonEdit";
			this.buttonEdit.ReadOnly = true;
			this.buttonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.buttonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit_ButtonClick);
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
			// colEmails
			// 
			this.colEmails.Caption = "Email Addresses";
			this.colEmails.FieldName = "colEmails";
			this.colEmails.Name = "colEmails";
			this.colEmails.OptionsColumn.AllowEdit = false;
			this.colEmails.OptionsColumn.ReadOnly = true;
			this.colEmails.UnboundType = DevExpress.Data.UnboundColumnType.String;
			this.colEmails.Visible = true;
			this.colEmails.VisibleIndex = 6;
			// 
			// previewAddress
			// 
			this.previewAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.previewAddress.Location = new System.Drawing.Point(105, 65);
			this.previewAddress.Name = "previewAddress";
			this.previewAddress.Size = new System.Drawing.Size(479, 20);
			this.previewAddress.TabIndex = 7;
			this.previewAddress.TextChanged += new System.EventHandler(this.previewAddress_TextChanged);
			// 
			// labelControl4
			// 
			this.labelControl4.Location = new System.Drawing.Point(12, 68);
			this.labelControl4.Name = "labelControl4";
			this.labelControl4.Size = new System.Drawing.Size(87, 13);
			this.labelControl4.TabIndex = 8;
			this.labelControl4.Text = "Send previews to:";
			// 
			// EmailExporter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(597, 372);
			this.Controls.Add(this.labelControl4);
			this.Controls.Add(this.previewAddress);
			this.Controls.Add(this.grid);
			this.Controls.Add(this.sendBills);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.labelControl3);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.startDate);
			this.Controls.Add(this.emailTemplate);
			this.Controls.Add(this.labelControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(269, 269);
			this.Name = "EmailExporter";
			this.Text = "Send Emails";
			((System.ComponentModel.ISupportInitialize)(this.emailTemplate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.startDate.Properties.VistaTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.startDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.previewAddress.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.ComboBoxEdit emailTemplate;
		private DevExpress.XtraEditors.DateEdit startDate;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.LabelControl labelControl3;
		private DevExpress.XtraEditors.SimpleButton cancel;
		private DevExpress.XtraEditors.SimpleButton sendBills;
		private DevExpress.XtraGrid.GridControl grid;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView;
		private DevExpress.XtraGrid.Columns.GridColumn colLastName;
		private DevExpress.XtraGrid.Columns.GridColumn colHisName;
		private DevExpress.XtraGrid.Columns.GridColumn colHerName;
		private DevExpress.XtraGrid.Columns.GridColumn colAddress;
		private DevExpress.XtraGrid.Columns.GridColumn colTotalPaid;
		private DevExpress.XtraGrid.Columns.GridColumn colBalanceDue;
		private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit buttonEdit;
		private DevExpress.XtraEditors.TextEdit previewAddress;
		private DevExpress.XtraEditors.LabelControl labelControl4;
		private DevExpress.XtraGrid.Columns.GridColumn colEmails;
	}
}