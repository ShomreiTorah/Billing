namespace ShomreiTorah.Billing.Controls {
	partial class BaseGrid {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseGrid));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
			this.editors = new DevExpress.XtraEditors.Repository.PersistentRepository(this.components);
			this.currencyEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.checkNumberEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.paymentMethodEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.stateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.accountEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			this.personRefEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.personSourceEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
			((System.ComponentModel.ISupportInitialize)(this.currencyEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkNumberEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.paymentMethodEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stateEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.accountEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.personRefEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.personSourceEdit)).BeginInit();
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
            this.personRefEdit,
            this.personSourceEdit});
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
			this.checkNumberEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.checkNumberEdit.DisplayFormat.FormatString = "f0";
			this.checkNumberEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.checkNumberEdit.EditFormat.FormatString = "f0";
			this.checkNumberEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.checkNumberEdit.IsFloatValue = false;
			this.checkNumberEdit.Mask.EditMask = "f0";
			this.checkNumberEdit.Name = "checkNumberEdit";
			this.checkNumberEdit.NullText = "N/A";
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
			// personRefEdit
			// 
			this.personRefEdit.AutoHeight = false;
			this.personRefEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("personRefEdit.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Show Person", null, null, true)});
			this.personRefEdit.Name = "personRefEdit";
			this.personRefEdit.ReadOnly = true;
			this.personRefEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			// 
			// gridView1
			// 
			this.gridView1.GridControl = this;
			this.gridView1.Name = "gridView1";
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
			// BaseGrid
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
			((System.ComponentModel.ISupportInitialize)(this.personRefEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.personSourceEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.Repository.PersistentRepository editors;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit currencyEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit checkNumberEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox paymentMethodEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox stateEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox accountEdit;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit personRefEdit;
		private DevExpress.XtraEditors.Repository.RepositoryItemComboBox personSourceEdit;
	}
}
