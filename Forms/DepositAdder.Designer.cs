namespace ShomreiTorah.Billing.Forms {
	partial class DepositAdder {
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
			this.cancel = new DevExpress.XtraEditors.SimpleButton();
			this.add = new DevExpress.XtraEditors.SimpleButton();
			this.depositDate = new DevExpress.XtraEditors.DateEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.grid = new DevExpress.XtraGrid.GridControl();
			this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colCheck = new DevExpress.XtraGrid.Columns.GridColumn();
			this.checkEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colMethod = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCheckNumber = new DevExpress.XtraGrid.Columns.GridColumn();
			this.checkNumberEdit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
			this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colComments = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colModified = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colModifier = new DevExpress.XtraGrid.Columns.GridColumn();
			this.summary = new DevExpress.XtraEditors.LabelControl();
			this.depositNumber = new DevExpress.XtraEditors.SpinEdit();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			((System.ComponentModel.ISupportInitialize)(this.depositDate.Properties.VistaTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.depositDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkNumberEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.depositNumber.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// cancel
			// 
			this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(719, 540);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 4;
			this.cancel.Text = "Cancel";
			// 
			// add
			// 
			this.add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.add.Enabled = false;
			this.add.Location = new System.Drawing.Point(638, 540);
			this.add.Name = "add";
			this.add.Size = new System.Drawing.Size(75, 23);
			this.add.TabIndex = 3;
			this.add.Text = "Add Deposit";
			this.add.Click += new System.EventHandler(this.add_Click);
			// 
			// depositDate
			// 
			this.depositDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.depositDate.EditValue = null;
			this.depositDate.Location = new System.Drawing.Point(59, 12);
			this.depositDate.Name = "depositDate";
			this.depositDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.depositDate.Properties.DisplayFormat.FormatString = "D";
			this.depositDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.depositDate.Properties.EditFormat.FormatString = "D";
			this.depositDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.depositDate.Properties.Mask.EditMask = "D";
			this.depositDate.Properties.NullValuePrompt = "Please select the date of the deposit";
			this.depositDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.depositDate.Size = new System.Drawing.Size(735, 20);
			this.depositDate.TabIndex = 0;
			this.depositDate.DrawItem += new DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventHandler(this.depositDate_DrawItem);
			this.depositDate.EditValueChanged += new System.EventHandler(this.depositDate_EditValueChanged);
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(12, 15);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(27, 13);
			this.labelControl1.TabIndex = 3;
			this.labelControl1.Text = "Date:";
			// 
			// grid
			// 
			this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grid.Location = new System.Drawing.Point(12, 97);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.checkEdit,
            this.checkNumberEdit});
			this.grid.Size = new System.Drawing.Size(782, 437);
			this.grid.TabIndex = 2;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCheck,
            this.colFullName,
            this.colDate,
            this.colMethod,
            this.colCheckNumber,
            this.colAmount,
            this.colComments,
            this.colModified,
            this.colModifier});
			this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView.GridControl = this.grid;
			this.gridView.Name = "gridView";
			this.gridView.OptionsBehavior.Editable = false;
			this.gridView.OptionsCustomization.AllowFilter = false;
			this.gridView.OptionsCustomization.AllowGroup = false;
			this.gridView.OptionsSelection.MultiSelect = true;
			this.gridView.OptionsView.ShowGroupPanel = false;
			this.gridView.OptionsView.ShowIndicator = false;
			this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFullName, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.gridView.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView_BeforeLeaveRow);
			this.gridView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView_CustomUnboundColumnData);
			this.gridView.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView_CustomColumnDisplayText);
			this.gridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyDown);
			this.gridView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridView_MouseUp);
			// 
			// colCheck
			// 
			this.colCheck.Caption = " ";
			this.colCheck.ColumnEdit = this.checkEdit;
			this.colCheck.FieldName = "colCheck";
			this.colCheck.Name = "colCheck";
			this.colCheck.OptionsColumn.AllowEdit = false;
			this.colCheck.OptionsColumn.AllowMove = false;
			this.colCheck.OptionsColumn.AllowSize = false;
			this.colCheck.OptionsColumn.FixedWidth = true;
			this.colCheck.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
			this.colCheck.Visible = true;
			this.colCheck.VisibleIndex = 0;
			this.colCheck.Width = 20;
			// 
			// checkEdit
			// 
			this.checkEdit.AutoHeight = false;
			this.checkEdit.Name = "checkEdit";
			// 
			// colFullName
			// 
			this.colFullName.FieldName = "Person";
			this.colFullName.Name = "colFullName";
			this.colFullName.OptionsColumn.AllowEdit = false;
			this.colFullName.OptionsColumn.AllowFocus = false;
			this.colFullName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.colFullName.OptionsColumn.ReadOnly = true;
			this.colFullName.Visible = true;
			this.colFullName.VisibleIndex = 1;
			this.colFullName.Width = 49;
			// 
			// colDate
			// 
			this.colDate.FieldName = "Date";
			this.colDate.Name = "colDate";
			this.colDate.OptionsColumn.AllowEdit = false;
			this.colDate.OptionsColumn.AllowFocus = false;
			this.colDate.OptionsColumn.ReadOnly = true;
			this.colDate.Visible = true;
			this.colDate.VisibleIndex = 2;
			this.colDate.Width = 49;
			// 
			// colMethod
			// 
			this.colMethod.FieldName = "Method";
			this.colMethod.Name = "colMethod";
			this.colMethod.OptionsColumn.AllowEdit = false;
			this.colMethod.OptionsColumn.AllowFocus = false;
			this.colMethod.OptionsColumn.ReadOnly = true;
			this.colMethod.Visible = true;
			this.colMethod.VisibleIndex = 3;
			this.colMethod.Width = 49;
			// 
			// colCheckNumber
			// 
			this.colCheckNumber.ColumnEdit = this.checkNumberEdit;
			this.colCheckNumber.DisplayFormat.FormatString = "f0";
			this.colCheckNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colCheckNumber.FieldName = "CheckNumber";
			this.colCheckNumber.Name = "colCheckNumber";
			this.colCheckNumber.OptionsColumn.AllowEdit = false;
			this.colCheckNumber.OptionsColumn.AllowFocus = false;
			this.colCheckNumber.OptionsColumn.ReadOnly = true;
			this.colCheckNumber.Visible = true;
			this.colCheckNumber.VisibleIndex = 4;
			this.colCheckNumber.Width = 54;
			// 
			// checkNumberEdit
			// 
			this.checkNumberEdit.AutoHeight = false;
			this.checkNumberEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.checkNumberEdit.DisplayFormat.FormatString = "f0";
			this.checkNumberEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.checkNumberEdit.Mask.EditMask = "f0";
			this.checkNumberEdit.Name = "checkNumberEdit";
			this.checkNumberEdit.NullText = "N/A";
			// 
			// colAmount
			// 
			this.colAmount.DisplayFormat.FormatString = "c";
			this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colAmount.FieldName = "Amount";
			this.colAmount.Name = "colAmount";
			this.colAmount.OptionsColumn.AllowEdit = false;
			this.colAmount.OptionsColumn.AllowFocus = false;
			this.colAmount.OptionsColumn.ReadOnly = true;
			this.colAmount.Visible = true;
			this.colAmount.VisibleIndex = 5;
			this.colAmount.Width = 93;
			// 
			// colComments
			// 
			this.colComments.FieldName = "Comments";
			this.colComments.Name = "colComments";
			this.colComments.OptionsColumn.AllowEdit = false;
			this.colComments.OptionsColumn.AllowFocus = false;
			this.colComments.OptionsColumn.ReadOnly = true;
			this.colComments.Visible = true;
			this.colComments.VisibleIndex = 6;
			this.colComments.Width = 182;
			// 
			// colModified
			// 
			this.colModified.DisplayFormat.FormatString = "f";
			this.colModified.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colModified.FieldName = "Modified";
			this.colModified.Name = "colModified";
			this.colModified.OptionsColumn.AllowEdit = false;
			this.colModified.OptionsColumn.AllowFocus = false;
			this.colModified.OptionsColumn.ReadOnly = true;
			// 
			// colModifier
			// 
			this.colModifier.FieldName = "Modifier";
			this.colModifier.Name = "colModifier";
			this.colModifier.OptionsColumn.AllowEdit = false;
			this.colModifier.OptionsColumn.AllowFocus = false;
			this.colModifier.OptionsColumn.ReadOnly = true;
			// 
			// summary
			// 
			this.summary.Location = new System.Drawing.Point(12, 65);
			this.summary.Name = "summary";
			this.summary.Size = new System.Drawing.Size(45, 26);
			this.summary.TabIndex = 5;
			this.summary.Text = "Total:\r\nSelected:";
			// 
			// depositNumber
			// 
			this.depositNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.depositNumber.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.depositNumber.Location = new System.Drawing.Point(59, 39);
			this.depositNumber.Name = "depositNumber";
			this.depositNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.depositNumber.Properties.IsFloatValue = false;
			this.depositNumber.Properties.Mask.EditMask = "N00";
			this.depositNumber.Properties.MaxValue = new decimal(new int[] {
            65536,
            0,
            0,
            0});
			this.depositNumber.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.depositNumber.Properties.NullText = " ";
			this.depositNumber.Size = new System.Drawing.Size(734, 20);
			this.depositNumber.TabIndex = 1;
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(12, 42);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(41, 13);
			this.labelControl2.TabIndex = 7;
			this.labelControl2.Text = "Number:";
			// 
			// DepositAdder
			// 
			this.AcceptButton = this.add;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(820, 589);
			this.ControlBox = false;
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.depositNumber);
			this.Controls.Add(this.summary);
			this.Controls.Add(this.grid);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.depositDate);
			this.Controls.Add(this.add);
			this.Controls.Add(this.cancel);
			this.MinimumSize = new System.Drawing.Size(450, 400);
			this.Name = "DepositAdder";
			this.ShowIcon = false;
			this.Text = "DepositAdder";
			((System.ComponentModel.ISupportInitialize)(this.depositDate.Properties.VistaTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.depositDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkNumberEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.depositNumber.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.SimpleButton cancel;
		private DevExpress.XtraEditors.SimpleButton add;
		private DevExpress.XtraEditors.DateEdit depositDate;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraGrid.GridControl grid;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView;
		private DevExpress.XtraGrid.Columns.GridColumn colFullName;
		private DevExpress.XtraGrid.Columns.GridColumn colDate;
		private DevExpress.XtraGrid.Columns.GridColumn colMethod;
		private DevExpress.XtraGrid.Columns.GridColumn colCheckNumber;
		private DevExpress.XtraGrid.Columns.GridColumn colAmount;
		private DevExpress.XtraGrid.Columns.GridColumn colComments;
		private DevExpress.XtraGrid.Columns.GridColumn colModified;
		private DevExpress.XtraGrid.Columns.GridColumn colModifier;
		private DevExpress.XtraGrid.Columns.GridColumn colCheck;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit checkEdit;
		private DevExpress.XtraEditors.LabelControl summary;
		private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit checkNumberEdit;
		private DevExpress.XtraEditors.SpinEdit depositNumber;
		private DevExpress.XtraEditors.LabelControl labelControl2;
	}
}