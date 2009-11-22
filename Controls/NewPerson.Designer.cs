namespace ShomreiTorah.Billing.Controls {
	partial class NewPerson {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewPerson));
			this.grid = new DevExpress.XtraGrid.GridControl();
			this.masterDirectoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colYKID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colHisName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colHerName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCity = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colState = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colZip = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPhone = new DevExpress.XtraGrid.Columns.GridColumn();
			this.panel1 = new System.Windows.Forms.Panel();
			this.newData = new ShomreiTorah.Billing.Controls.PersonDataEntry();
			this.panel2 = new System.Windows.Forms.Panel();
			this.create = new DevExpress.XtraEditors.SimpleButton();
			this.cancel = new DevExpress.XtraEditors.SimpleButton();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.personDataEntry1 = new ShomreiTorah.Billing.Controls.PersonDataEntry();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.masterDirectoryBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// grid
			// 
			this.grid.DataSource = this.masterDirectoryBindingSource;
			this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grid.Location = new System.Drawing.Point(319, 0);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.Size = new System.Drawing.Size(768, 270);
			this.grid.TabIndex = 0;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colYKID,
            this.colLastName,
            this.colHisName,
            this.colHerName,
            this.colFullName,
            this.colAddress,
            this.colCity,
            this.colState,
            this.colZip,
            this.colPhone});
			this.gridView.GridControl = this.grid;
			this.gridView.Name = "gridView";
			this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colLastName, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.gridView.DoubleClick += new System.EventHandler(this.gridView_DoubleClick);
			// 
			// colId
			// 
			this.colId.FieldName = "Id";
			this.colId.Name = "colId";
			this.colId.OptionsColumn.AllowEdit = false;
			// 
			// colYKID
			// 
			this.colYKID.FieldName = "YKID";
			this.colYKID.Name = "colYKID";
			this.colYKID.OptionsColumn.AllowEdit = false;
			// 
			// colLastName
			// 
			this.colLastName.FieldName = "LastName";
			this.colLastName.Name = "colLastName";
			this.colLastName.OptionsColumn.AllowEdit = false;
			this.colLastName.Visible = true;
			this.colLastName.VisibleIndex = 0;
			// 
			// colHisName
			// 
			this.colHisName.FieldName = "HisName";
			this.colHisName.Name = "colHisName";
			this.colHisName.OptionsColumn.AllowEdit = false;
			this.colHisName.Visible = true;
			this.colHisName.VisibleIndex = 1;
			// 
			// colHerName
			// 
			this.colHerName.FieldName = "HerName";
			this.colHerName.Name = "colHerName";
			this.colHerName.OptionsColumn.AllowEdit = false;
			this.colHerName.Visible = true;
			this.colHerName.VisibleIndex = 2;
			// 
			// colFullName
			// 
			this.colFullName.FieldName = "FullName";
			this.colFullName.Name = "colFullName";
			this.colFullName.OptionsColumn.AllowEdit = false;
			this.colFullName.Visible = true;
			this.colFullName.VisibleIndex = 3;
			// 
			// colAddress
			// 
			this.colAddress.FieldName = "Address";
			this.colAddress.Name = "colAddress";
			this.colAddress.OptionsColumn.AllowEdit = false;
			this.colAddress.Visible = true;
			this.colAddress.VisibleIndex = 4;
			// 
			// colCity
			// 
			this.colCity.FieldName = "City";
			this.colCity.Name = "colCity";
			this.colCity.OptionsColumn.AllowEdit = false;
			this.colCity.Visible = true;
			this.colCity.VisibleIndex = 5;
			// 
			// colState
			// 
			this.colState.FieldName = "State";
			this.colState.Name = "colState";
			this.colState.OptionsColumn.AllowEdit = false;
			this.colState.Visible = true;
			this.colState.VisibleIndex = 6;
			// 
			// colZip
			// 
			this.colZip.FieldName = "Zip";
			this.colZip.Name = "colZip";
			this.colZip.OptionsColumn.AllowEdit = false;
			this.colZip.Visible = true;
			this.colZip.VisibleIndex = 7;
			// 
			// colPhone
			// 
			this.colPhone.FieldName = "Phone";
			this.colPhone.Name = "colPhone";
			this.colPhone.OptionsColumn.AllowEdit = false;
			this.colPhone.Visible = true;
			this.colPhone.VisibleIndex = 8;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.newData);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.labelControl1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(319, 270);
			this.panel1.TabIndex = 1;
			// 
			// newData
			// 
			this.newData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.newData.Location = new System.Drawing.Point(0, 52);
			this.newData.Name = "newData";
			this.newData.Size = new System.Drawing.Size(319, 195);
			this.newData.TabIndex = 1;
			this.newData.PersonChanged += new System.EventHandler(this.newData_PersonChanged);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.create);
			this.panel2.Controls.Add(this.cancel);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 247);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(319, 23);
			this.panel2.TabIndex = 2;
			// 
			// create
			// 
			this.create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.create.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.create.Enabled = false;
			this.create.Location = new System.Drawing.Point(144, 0);
			this.create.Name = "create";
			this.create.Size = new System.Drawing.Size(94, 23);
			this.create.TabIndex = 0;
			this.create.Text = "Create Person";
			this.create.Click += new System.EventHandler(this.create_Click);
			// 
			// cancel
			// 
			this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(244, 0);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 1;
			this.cancel.Text = "Cancel";
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.Options.UseTextOptions = true;
			this.labelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
			this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelControl1.Location = new System.Drawing.Point(0, 0);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(319, 52);
			this.labelControl1.TabIndex = 0;
			this.labelControl1.Text = resources.GetString("labelControl1.Text");
			// 
			// personDataEntry1
			// 
			this.personDataEntry1.Location = new System.Drawing.Point(3, 45);
			this.personDataEntry1.Name = "personDataEntry1";
			this.personDataEntry1.Size = new System.Drawing.Size(313, 186);
			this.personDataEntry1.TabIndex = 1;
			// 
			// NewPerson
			// 
			this.AcceptButton = this.create;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(1087, 270);
			this.ControlBox = false;
			this.Controls.Add(this.grid);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(700, 300);
			this.Name = "NewPerson";
			this.Text = "New Person";
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.masterDirectoryBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraGrid.GridControl grid;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.BindingSource masterDirectoryBindingSource;
		private DevExpress.XtraGrid.Columns.GridColumn colId;
		private DevExpress.XtraGrid.Columns.GridColumn colYKID;
		private DevExpress.XtraGrid.Columns.GridColumn colLastName;
		private DevExpress.XtraGrid.Columns.GridColumn colHisName;
		private DevExpress.XtraGrid.Columns.GridColumn colHerName;
		private DevExpress.XtraGrid.Columns.GridColumn colFullName;
		private DevExpress.XtraGrid.Columns.GridColumn colAddress;
		private DevExpress.XtraGrid.Columns.GridColumn colCity;
		private DevExpress.XtraGrid.Columns.GridColumn colState;
		private DevExpress.XtraGrid.Columns.GridColumn colZip;
		private DevExpress.XtraGrid.Columns.GridColumn colPhone;
		private PersonDataEntry newData;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private PersonDataEntry personDataEntry1;
		private System.Windows.Forms.Panel panel2;
		private DevExpress.XtraEditors.SimpleButton create;
		private DevExpress.XtraEditors.SimpleButton cancel;

	}
}