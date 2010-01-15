namespace ShomreiTorah.Billing.Import.Journal {
	partial class JournalImporter {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JournalImporter));
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.adsGrid = new DevExpress.XtraGrid.GridControl();
			this.adsDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.adsView = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
			this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
			this.colFullName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colHisName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colHerName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colLastName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colAddress = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colCity = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colState = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colZip = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colPhone = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colEmail = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colResolveType = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
			this.colExternalID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colAdStatus = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colMensSeats = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colWomensSeats = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colAdType = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colDateEntered = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colNotes = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
			this.colAmountToBill = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colPaymentMethod = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.colCheckNumber = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			this.checkNumberEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			this.colImportState = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.adsGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.adsDataTableBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.adsView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkNumberEdit)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
			this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
			this.splitContainerControl1.Name = "splitContainerControl1";
			this.splitContainerControl1.Panel1.Controls.Add(this.adsGrid);
			this.splitContainerControl1.Panel1.Text = "Panel1";
			this.splitContainerControl1.Panel2.Text = "Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(1107, 546);
			this.splitContainerControl1.SplitterPosition = 190;
			this.splitContainerControl1.TabIndex = 0;
			this.splitContainerControl1.Text = "splitContainerControl1";
			// 
			// adsGrid
			// 
			this.adsGrid.DataSource = this.adsDataTableBindingSource;
			this.adsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.adsGrid.Location = new System.Drawing.Point(0, 0);
			this.adsGrid.MainView = this.adsView;
			this.adsGrid.Name = "adsGrid";
			this.adsGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.checkNumberEdit});
			this.adsGrid.Size = new System.Drawing.Size(909, 546);
			this.adsGrid.TabIndex = 0;
			this.adsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.adsView});
			// 
			// adsDataTableBindingSource
			// 
			this.adsDataTableBindingSource.DataSource = typeof(PowerPointJournal.JournalDB.AdsDataTable);
			// 
			// adsView
			// 
			this.adsView.Appearance.RowSeparator.BorderColor = System.Drawing.Color.Blue;
			this.adsView.Appearance.RowSeparator.Options.UseBorderColor = true;
			this.adsView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3});
			this.adsView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colExternalID,
            this.colFullName,
            this.colHisName,
            this.colLastName,
            this.colAddress,
            this.colCity,
            this.colState,
            this.colZip,
            this.colPhone,
            this.colEmail,
            this.colMensSeats,
            this.colWomensSeats,
            this.colAdType,
            this.colAmountToBill,
            this.colAdStatus,
            this.colNotes,
            this.colDateEntered,
            this.colHerName,
            this.colPaymentMethod,
            this.colCheckNumber,
            this.colImportState,
            this.colResolveType});
			this.adsView.GridControl = this.adsGrid;
			this.adsView.GroupCount = 1;
			this.adsView.GroupFormat = "[#image]{1} {2}";
			this.adsView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "", null, "({0} ads)")});
			this.adsView.Name = "adsView";
			this.adsView.OptionsBehavior.Editable = false;
			this.adsView.OptionsCustomization.AllowRowSizing = true;
			this.adsView.RowSeparatorHeight = 24;
			this.adsView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colImportState, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colHisName, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.adsView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.adsView_CustomUnboundColumnData);
			this.adsView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.adsView_RowStyle);
			// 
			// gridBand1
			// 
			this.gridBand1.Caption = "Person";
			this.gridBand1.Columns.Add(this.colFullName);
			this.gridBand1.Columns.Add(this.colHisName);
			this.gridBand1.Columns.Add(this.colHerName);
			this.gridBand1.Columns.Add(this.colLastName);
			this.gridBand1.Columns.Add(this.colAddress);
			this.gridBand1.Columns.Add(this.colCity);
			this.gridBand1.Columns.Add(this.colState);
			this.gridBand1.Columns.Add(this.colZip);
			this.gridBand1.Columns.Add(this.colPhone);
			this.gridBand1.Columns.Add(this.colEmail);
			this.gridBand1.Columns.Add(this.colResolveType);
			this.gridBand1.MinWidth = 20;
			this.gridBand1.Name = "gridBand1";
			this.gridBand1.Width = 368;
			// 
			// colFullName
			// 
			this.colFullName.FieldName = "FullName";
			this.colFullName.Name = "colFullName";
			this.colFullName.OptionsColumn.AllowFocus = false;
			this.colFullName.Visible = true;
			this.colFullName.Width = 123;
			// 
			// colHisName
			// 
			this.colHisName.FieldName = "HisName";
			this.colHisName.Name = "colHisName";
			this.colHisName.OptionsColumn.AllowFocus = false;
			this.colHisName.Visible = true;
			this.colHisName.Width = 91;
			// 
			// colHerName
			// 
			this.colHerName.FieldName = "HerName";
			this.colHerName.Name = "colHerName";
			this.colHerName.OptionsColumn.AllowFocus = false;
			this.colHerName.Visible = true;
			this.colHerName.Width = 73;
			// 
			// colLastName
			// 
			this.colLastName.FieldName = "LastName";
			this.colLastName.Name = "colLastName";
			this.colLastName.OptionsColumn.AllowFocus = false;
			this.colLastName.Visible = true;
			this.colLastName.Width = 81;
			// 
			// colAddress
			// 
			this.colAddress.FieldName = "Address";
			this.colAddress.Name = "colAddress";
			this.colAddress.OptionsColumn.AllowFocus = false;
			this.colAddress.RowIndex = 1;
			this.colAddress.Visible = true;
			this.colAddress.Width = 300;
			// 
			// colCity
			// 
			this.colCity.FieldName = "City";
			this.colCity.Name = "colCity";
			this.colCity.OptionsColumn.AllowFocus = false;
			this.colCity.RowIndex = 2;
			this.colCity.Visible = true;
			this.colCity.Width = 98;
			// 
			// colState
			// 
			this.colState.FieldName = "State";
			this.colState.Name = "colState";
			this.colState.OptionsColumn.AllowFocus = false;
			this.colState.RowIndex = 2;
			this.colState.Visible = true;
			this.colState.Width = 98;
			// 
			// colZip
			// 
			this.colZip.FieldName = "Zip";
			this.colZip.Name = "colZip";
			this.colZip.OptionsColumn.AllowFocus = false;
			this.colZip.RowIndex = 2;
			this.colZip.Visible = true;
			this.colZip.Width = 104;
			// 
			// colPhone
			// 
			this.colPhone.FieldName = "Phone";
			this.colPhone.Name = "colPhone";
			this.colPhone.OptionsColumn.AllowFocus = false;
			this.colPhone.RowIndex = 3;
			this.colPhone.Visible = true;
			this.colPhone.Width = 148;
			// 
			// colEmail
			// 
			this.colEmail.FieldName = "Email";
			this.colEmail.Name = "colEmail";
			this.colEmail.OptionsColumn.AllowFocus = false;
			this.colEmail.RowIndex = 3;
			this.colEmail.Visible = true;
			this.colEmail.Width = 133;
			// 
			// colResolveType
			// 
			this.colResolveType.Caption = "Resolve Type";
			this.colResolveType.FieldName = "colResolveType";
			this.colResolveType.Name = "colResolveType";
			this.colResolveType.OptionsColumn.AllowFocus = false;
			this.colResolveType.RowIndex = 3;
			this.colResolveType.UnboundType = DevExpress.Data.UnboundColumnType.String;
			this.colResolveType.Visible = true;
			// 
			// gridBand2
			// 
			this.gridBand2.Caption = "Ad";
			this.gridBand2.Columns.Add(this.colExternalID);
			this.gridBand2.Columns.Add(this.colAdStatus);
			this.gridBand2.Columns.Add(this.colMensSeats);
			this.gridBand2.Columns.Add(this.colWomensSeats);
			this.gridBand2.Columns.Add(this.colAdType);
			this.gridBand2.Columns.Add(this.colDateEntered);
			this.gridBand2.Columns.Add(this.colNotes);
			this.gridBand2.MinWidth = 20;
			this.gridBand2.Name = "gridBand2";
			this.gridBand2.Width = 188;
			// 
			// colExternalID
			// 
			this.colExternalID.FieldName = "ExternalID";
			this.colExternalID.Name = "colExternalID";
			this.colExternalID.OptionsColumn.AllowFocus = false;
			this.colExternalID.Visible = true;
			this.colExternalID.Width = 94;
			// 
			// colAdStatus
			// 
			this.colAdStatus.Caption = "Ad Status";
			this.colAdStatus.Name = "colAdStatus";
			this.colAdStatus.OptionsColumn.AllowFocus = false;
			this.colAdStatus.UnboundType = DevExpress.Data.UnboundColumnType.String;
			this.colAdStatus.Visible = true;
			this.colAdStatus.Width = 94;
			// 
			// colMensSeats
			// 
			this.colMensSeats.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.colMensSeats.FieldName = "MensSeats";
			this.colMensSeats.Name = "colMensSeats";
			this.colMensSeats.OptionsColumn.AllowFocus = false;
			this.colMensSeats.RowIndex = 1;
			this.colMensSeats.Visible = true;
			this.colMensSeats.Width = 94;
			// 
			// colWomensSeats
			// 
			this.colWomensSeats.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
			this.colWomensSeats.FieldName = "WomensSeats";
			this.colWomensSeats.Name = "colWomensSeats";
			this.colWomensSeats.OptionsColumn.AllowFocus = false;
			this.colWomensSeats.RowIndex = 1;
			this.colWomensSeats.Visible = true;
			this.colWomensSeats.Width = 94;
			// 
			// colAdType
			// 
			this.colAdType.Caption = "Ad Type";
			this.colAdType.Name = "colAdType";
			this.colAdType.OptionsColumn.AllowFocus = false;
			this.colAdType.RowIndex = 2;
			this.colAdType.UnboundType = DevExpress.Data.UnboundColumnType.String;
			this.colAdType.Visible = true;
			this.colAdType.Width = 188;
			// 
			// colDateEntered
			// 
			this.colDateEntered.FieldName = "DateEntered";
			this.colDateEntered.Name = "colDateEntered";
			this.colDateEntered.OptionsColumn.AllowFocus = false;
			this.colDateEntered.RowIndex = 3;
			this.colDateEntered.Visible = true;
			this.colDateEntered.Width = 94;
			// 
			// colNotes
			// 
			this.colNotes.FieldName = "Notes";
			this.colNotes.Name = "colNotes";
			this.colNotes.OptionsColumn.AllowFocus = false;
			this.colNotes.RowIndex = 3;
			this.colNotes.Visible = true;
			this.colNotes.Width = 94;
			// 
			// gridBand3
			// 
			this.gridBand3.Caption = "Billing";
			this.gridBand3.Columns.Add(this.colAmountToBill);
			this.gridBand3.Columns.Add(this.colPaymentMethod);
			this.gridBand3.Columns.Add(this.colCheckNumber);
			this.gridBand3.MinWidth = 20;
			this.gridBand3.Name = "gridBand3";
			this.gridBand3.Width = 151;
			// 
			// colAmountToBill
			// 
			this.colAmountToBill.DisplayFormat.FormatString = "c";
			this.colAmountToBill.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colAmountToBill.FieldName = "AmountToBill";
			this.colAmountToBill.Name = "colAmountToBill";
			this.colAmountToBill.OptionsColumn.AllowFocus = false;
			this.colAmountToBill.Visible = true;
			this.colAmountToBill.Width = 151;
			// 
			// colPaymentMethod
			// 
			this.colPaymentMethod.FieldName = "PaymentMethod";
			this.colPaymentMethod.Name = "colPaymentMethod";
			this.colPaymentMethod.OptionsColumn.AllowFocus = false;
			this.colPaymentMethod.RowIndex = 1;
			this.colPaymentMethod.Visible = true;
			this.colPaymentMethod.Width = 151;
			// 
			// colCheckNumber
			// 
			this.colCheckNumber.ColumnEdit = this.checkNumberEdit;
			this.colCheckNumber.FieldName = "CheckNumber";
			this.colCheckNumber.Name = "colCheckNumber";
			this.colCheckNumber.OptionsColumn.AllowFocus = false;
			this.colCheckNumber.RowIndex = 2;
			this.colCheckNumber.Visible = true;
			this.colCheckNumber.Width = 151;
			// 
			// checkNumberEdit
			// 
			this.checkNumberEdit.AutoHeight = false;
			this.checkNumberEdit.DisplayFormat.FormatString = "f0";
			this.checkNumberEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.checkNumberEdit.Name = "checkNumberEdit";
			this.checkNumberEdit.NullText = "N/A";
			// 
			// colImportState
			// 
			this.colImportState.Caption = "Import State";
			this.colImportState.FieldName = "colImportState";
			this.colImportState.Name = "colImportState";
			this.colImportState.OptionsColumn.AllowFocus = false;
			this.colImportState.UnboundType = DevExpress.Data.UnboundColumnType.String;
			this.colImportState.Visible = true;
			// 
			// JournalImporter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1107, 546);
			this.Controls.Add(this.splitContainerControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "JournalImporter";
			this.Text = "JournalImporter";
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.adsGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.adsDataTableBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.adsView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkNumberEdit)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
		private DevExpress.XtraGrid.GridControl adsGrid;
		private System.Windows.Forms.BindingSource adsDataTableBindingSource;
		private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView adsView;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFullName;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colHisName;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colHerName;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLastName;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colAddress;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCity;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colState;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colZip;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPhone;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmail;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colExternalID;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colAdStatus;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colMensSeats;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colWomensSeats;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colAdType;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDateEntered;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNotes;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colAmountToBill;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPaymentMethod;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCheckNumber;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colImportState;
		private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colResolveType;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
		private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit checkNumberEdit;
	}
}