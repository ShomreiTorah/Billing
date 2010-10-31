namespace ShomreiTorah.Billing.Controls {
	partial class ModifiedPaymentsGrid {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.grid = new ShomreiTorah.Data.UI.Grid.SmartGrid(this.components);
			this.gridView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colFullName = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colDate = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colMethod = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colCheckNumber = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.checkNumberEdit = new Data.UI.Controls.RepositoryItemCheckNumberEdit();
			this.colAccount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAmount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colDeposit = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.depositEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			this.colComments = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colModified = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colModifier = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkNumberEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.depositEdit)).BeginInit();
			this.SuspendLayout();
			// 
			// grid
			// 
			this.grid.DataMember = "Payments";
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(0, 0);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.RegistrationCount = 38;
			this.grid.Size = new System.Drawing.Size(712, 495);
			this.grid.TabIndex = 2;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFullName,
            this.colDate,
            this.colMethod,
            this.colCheckNumber,
            this.colAccount,
            this.colAmount,
            this.colDeposit,
            this.colComments,
            this.colModified,
            this.colModifier});
			this.gridView.GridControl = this.grid;
			this.gridView.Name = "gridView";
			this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
			this.gridView.OptionsView.ShowFooter = true;
			this.gridView.OptionsView.ShowGroupPanel = false;
			this.gridView.OptionsView.ShowIndicator = false;
			this.gridView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
			this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colModified, DevExpress.Data.ColumnSortOrder.Ascending)});
			// 
			// colFullName
			// 
			this.colFullName.Caption = "Full Name";
			this.colFullName.FieldName = "Person";
			this.colFullName.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Alphabetical;
			this.colFullName.Name = "colFullName";
			this.colFullName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
			this.colFullName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.colFullName.OptionsColumn.ReadOnly = true;
			this.colFullName.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colFullName.ShowEditorOnMouseDown = true;
			this.colFullName.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
			this.colFullName.SummaryItem.DisplayFormat = "{0} Payments";
			this.colFullName.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
			this.colFullName.Visible = true;
			this.colFullName.VisibleIndex = 0;
			this.colFullName.Width = 101;
			// 
			// colDate
			// 
			this.colDate.FieldName = "Date";
			this.colDate.Name = "colDate";
			this.colDate.OptionsColumn.AllowEdit = false;
			this.colDate.OptionsColumn.AllowFocus = false;
			this.colDate.OptionsColumn.ReadOnly = true;
			this.colDate.Visible = true;
			this.colDate.VisibleIndex = 1;
			this.colDate.Width = 79;
			// 
			// colMethod
			// 
			this.colMethod.FieldName = "Method";
			this.colMethod.MaxWidth = 70;
			this.colMethod.Name = "colMethod";
			this.colMethod.OptionsColumn.AllowEdit = false;
			this.colMethod.OptionsColumn.AllowFocus = false;
			this.colMethod.OptionsColumn.ReadOnly = true;
			this.colMethod.Visible = true;
			this.colMethod.VisibleIndex = 2;
			this.colMethod.Width = 68;
			// 
			// colCheckNumber
			// 
			this.colCheckNumber.ColumnEditor = this.checkNumberEdit;
			this.colCheckNumber.FieldName = "CheckNumber";
			this.colCheckNumber.Name = "colCheckNumber";
			this.colCheckNumber.OptionsColumn.AllowEdit = false;
			this.colCheckNumber.OptionsColumn.AllowFocus = false;
			this.colCheckNumber.OptionsColumn.ReadOnly = true;
			this.colCheckNumber.Visible = true;
			this.colCheckNumber.VisibleIndex = 3;
			this.colCheckNumber.Width = 110;
			// 
			// checkNumberEdit
			// 
			this.checkNumberEdit.Name = "checkNumberEdit";
			// 
			// colAccount
			// 
			this.colAccount.FieldName = "Account";
			this.colAccount.MaxWidth = 100;
			this.colAccount.Name = "colAccount";
			this.colAccount.OptionsColumn.AllowEdit = false;
			this.colAccount.OptionsColumn.AllowFocus = false;
			this.colAccount.OptionsColumn.ReadOnly = true;
			this.colAccount.Visible = true;
			this.colAccount.VisibleIndex = 4;
			this.colAccount.Width = 72;
			// 
			// colAmount
			// 
			this.colAmount.DisplayFormat.FormatString = "c";
			this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colAmount.FieldName = "Amount";
			this.colAmount.MaxWidth = 85;
			this.colAmount.Name = "colAmount";
			this.colAmount.OptionsColumn.AllowEdit = false;
			this.colAmount.OptionsColumn.AllowFocus = false;
			this.colAmount.OptionsColumn.ReadOnly = true;
			this.colAmount.SummaryItem.DisplayFormat = "{0:c} Total Paid";
			this.colAmount.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.colAmount.Visible = true;
			this.colAmount.VisibleIndex = 5;
			this.colAmount.Width = 85;
			// 
			// colDeposit
			// 
			this.colDeposit.Caption = "Deposited";
			this.colDeposit.ColumnEditor = this.depositEdit;
			this.colDeposit.FieldName = "Deposit";
			this.colDeposit.MaxWidth = 90;
			this.colDeposit.Name = "colDeposit";
			this.colDeposit.OptionsColumn.AllowEdit = false;
			this.colDeposit.OptionsColumn.AllowFocus = false;
			this.colDeposit.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
			this.colDeposit.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.colDeposit.OptionsColumn.ReadOnly = true;
			this.colDeposit.UnboundType = DevExpress.Data.UnboundColumnType.Object;
			this.colDeposit.Visible = true;
			this.colDeposit.VisibleIndex = 6;
			this.colDeposit.Width = 90;
			// 
			// depositEdit
			// 
			this.depositEdit.AutoHeight = false;
			this.depositEdit.Name = "depositEdit";
			this.depositEdit.NullText = "Undeposited";
			this.depositEdit.ReadOnly = true;
			// 
			// colComments
			// 
			this.colComments.FieldName = "Comments";
			this.colComments.Name = "colComments";
			this.colComments.OptionsColumn.AllowEdit = false;
			this.colComments.OptionsColumn.AllowFocus = false;
			this.colComments.OptionsColumn.ReadOnly = true;
			this.colComments.Visible = true;
			this.colComments.VisibleIndex = 7;
			this.colComments.Width = 105;
			// 
			// colModified
			// 
			this.colModified.DisplayFormat.FormatString = "g";
			this.colModified.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colModified.FieldName = "Modified";
			this.colModified.Name = "colModified";
			this.colModified.OptionsColumn.AllowEdit = false;
			this.colModified.OptionsColumn.AllowFocus = false;
			this.colModified.OptionsColumn.ReadOnly = true;
			this.colModified.Width = 112;
			// 
			// colModifier
			// 
			this.colModifier.FieldName = "Modifier";
			this.colModifier.Name = "colModifier";
			this.colModifier.OptionsColumn.AllowEdit = false;
			this.colModifier.OptionsColumn.AllowFocus = false;
			this.colModifier.OptionsColumn.ReadOnly = true;
			this.colModifier.Width = 47;
			// 
			// ModifiedPaymentsGrid
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.grid);
			this.Name = "ModifiedPaymentsGrid";
			this.Size = new System.Drawing.Size(712, 495);
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkNumberEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.depositEdit)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Data.UI.Grid.SmartGrid grid;
		private Data.UI.Grid.SmartGridView gridView;
		private Data.UI.Grid.SmartGridColumn colFullName;
		private Data.UI.Grid.SmartGridColumn colDate;
		private Data.UI.Grid.SmartGridColumn colMethod;
		private Data.UI.Grid.SmartGridColumn colCheckNumber;
		private Data.UI.Grid.SmartGridColumn colAccount;
		private Data.UI.Grid.SmartGridColumn colAmount;
		private Data.UI.Grid.SmartGridColumn colDeposit;
		private Data.UI.Grid.SmartGridColumn colComments;
		private Data.UI.Grid.SmartGridColumn colModified;
		private Data.UI.Grid.SmartGridColumn colModifier;
		
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit depositEdit;
		private Data.UI.Controls.RepositoryItemCheckNumberEdit checkNumberEdit;
	}
}
