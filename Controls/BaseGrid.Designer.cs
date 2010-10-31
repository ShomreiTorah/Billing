namespace ShomreiTorah.Billing.Controls {
	partial class OldBaseGrid {
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
			this.editors = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
			this.currencyEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.checkNumberEdit = new Data.UI.Controls.RepositoryItemCheckNumberEdit();
			this.paymentMethodEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.stateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.accountEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();

			this.personSourceEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.gridView1 = new Data.UI.Grid.SmartGridView();
			this.depositEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
			((System.ComponentModel.ISupportInitialize)(this.currencyEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkNumberEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentMethodEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stateEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.accountEdit)).BeginInit();

			((System.ComponentModel.ISupportInitialize)(this.personSourceEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.depositEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// editors
			// 
			this.editors.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.currencyEdit,
            this.checkNumberEdit,
            this.paymentMethodEdit,
            this.stateEdit,
            this.accountEdit,
            this.personSourceEdit,
            this.depositEdit});
			// 
			// currencyEdit
			// 
			this.currencyEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.currencyEdit.DisplayFormat.FormatString = "c";
			this.currencyEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.currencyEdit.EditFormat.FormatString = "c";
			this.currencyEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.currencyEdit.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.currencyEdit.Mask.EditMask = "c";
			this.currencyEdit.Name = "currencyEdit";
			// 
			// checkNumberEdit
			// 
			this.checkNumberEdit.Name = "checkNumberEdit";
			// 
			// paymentMethodEdit
			// 
			this.paymentMethodEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.paymentMethodEdit.DropDownRows = 2;
			this.paymentMethodEdit.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
			this.paymentMethodEdit.Items.AddRange(new object[] {
            "Cash",
            "Check"});
			this.paymentMethodEdit.Name = "paymentMethodEdit";
			// 
			// stateEdit
			// 
			this.stateEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.stateEdit.DropDownRows = 16;
			this.stateEdit.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
			this.stateEdit.Items.AddRange(new object[] {
            "NJ",
            "NY",
            "",
            "AL",
            "AK",
            "AZ",
            "AR",
            "CA",
            "CO",
            "CT",
            "DE",
            "DC",
            "FL",
            "GA",
            "HI",
            "ID",
            "IL",
            "IN",
            "IA",
            "KS",
            "KY",
            "LA",
            "ME",
            "MD",
            "MA",
            "MI",
            "MN",
            "MS",
            "MO",
            "MT",
            "NE",
            "NV",
            "NH",
            "NM",
            "NC",
            "ND",
            "OH",
            "OK",
            "OR",
            "PA",
            "RI",
            "SC",
            "SD",
            "TN",
            "TX",
            "UT",
            "VT",
            "VA",
            "WA",
            "WV",
            "WI",
            "WY"});
			this.stateEdit.Name = "stateEdit";
			// 
			// accountEdit
			// 
			this.accountEdit.AutoHeight = false;
			this.accountEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.accountEdit.DropDownRows = 2;
			this.accountEdit.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Standard;
			this.accountEdit.Items.AddRange(new object[] {
            "Operating Fund",
            "Building Fund"});
			this.accountEdit.Name = "accountEdit";
			// 
			// personSourceEdit
			// 
			this.personSourceEdit.AutoHeight = false;
			this.personSourceEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.personSourceEdit.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
			this.personSourceEdit.Items.AddRange(new object[] {
            "YK Directory",
            "Manually Added"});
			this.personSourceEdit.Name = "personSourceEdit";
			// 
			// gridView1
			// 
			this.gridView1.GridControl = this;
			this.gridView1.Name = "gridView1";
			// 
			// depositEdit
			// 
			this.depositEdit.AutoHeight = false;
			this.depositEdit.Name = "depositEdit";
			this.depositEdit.NullText = "Undeposited";
			this.depositEdit.ReadOnly = true;
			// 
			// Data.UI.Grid.SmartGrid
			// 
			this.ExternalRepository = this.editors;
			this.MainView = this.gridView1;
			this.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			((System.ComponentModel.ISupportInitialize)(this.currencyEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkNumberEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentMethodEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stateEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.accountEdit)).EndInit();

			((System.ComponentModel.ISupportInitialize)(this.personSourceEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.depositEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.Repository.PersistentRepository editors;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit currencyEdit;
		private Data.UI.Controls.RepositoryItemCheckNumberEdit checkNumberEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox paymentMethodEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox stateEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox accountEdit;
		private Data.UI.Grid.SmartGridView gridView1;

		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox personSourceEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit depositEdit;
	}
}
