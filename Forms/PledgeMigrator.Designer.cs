namespace ShomreiTorah.Billing.Forms {
	partial class PledgeMigrator {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PledgeMigrator));
			this.instructions = new DevExpress.XtraEditors.LabelControl();
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.ok = new DevExpress.XtraEditors.SimpleButton();
			this.cancel = new DevExpress.XtraEditors.SimpleButton();
			this.grid = new ShomreiTorah.Data.UI.Grid.SmartGrid();
			this.gridView = new ShomreiTorah.Data.UI.Grid.SmartGridView();
			this.colCheck = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.colPerson = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colDate = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colType = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colSubType = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAccount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colAmount = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colNote = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colComments = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colModified = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colModifier = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.topLabel = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.colPledgeId = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colExternalSource = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			this.colExternalId = new ShomreiTorah.Data.UI.Grid.SmartGridColumn();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.topLabel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			this.SuspendLayout();
			// 
			// instructions
			// 
			this.instructions.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.instructions.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
			this.instructions.Location = new System.Drawing.Point(12, 12);
			this.instructions.Name = "instructions";
			this.instructions.Size = new System.Drawing.Size(691, 52);
			this.instructions.StyleController = this.layoutControl1;
			this.instructions.TabIndex = 0;
			this.instructions.Text = resources.GetString("instructions.Text");
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.ok);
			this.layoutControl1.Controls.Add(this.cancel);
			this.layoutControl1.Controls.Add(this.grid);
			this.layoutControl1.Controls.Add(this.instructions);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(552, 227, 250, 350);
			this.layoutControl1.Root = this.layoutControlGroup1;
			this.layoutControl1.Size = new System.Drawing.Size(715, 357);
			this.layoutControl1.TabIndex = 1;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// ok
			// 
			this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.ok.Location = new System.Drawing.Point(488, 322);
			this.ok.MinimumSize = new System.Drawing.Size(79, 23);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(106, 23);
			this.ok.StyleController = this.layoutControl1;
			this.ok.TabIndex = 6;
			this.ok.Text = "OK";
			// 
			// cancel
			// 
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(598, 322);
			this.cancel.MinimumSize = new System.Drawing.Size(79, 23);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(105, 23);
			this.cancel.StyleController = this.layoutControl1;
			this.cancel.TabIndex = 5;
			this.cancel.Text = "Cancel";
			// 
			// grid
			// 
			this.grid.DataMember = "Pledges";
			this.grid.Location = new System.Drawing.Point(12, 72);
			this.grid.MainView = this.gridView;
			this.grid.Name = "grid";
			this.grid.RegistrationCount = 52;
			this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
			this.grid.ShowOnlyPredefinedDetails = true;
			this.grid.Size = new System.Drawing.Size(691, 242);
			this.grid.TabIndex = 4;
			this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
			// 
			// gridView
			// 
			this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCheck,
            this.colPerson,
            this.colDate,
            this.colType,
            this.colSubType,
            this.colAccount,
            this.colAmount,
            this.colNote,
            this.colComments,
            this.colModified,
            this.colModifier});
			this.gridView.GridControl = this.grid;
			this.gridView.Name = "gridView";
			this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
			this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDate, DevExpress.Data.ColumnSortOrder.Descending)});
			this.gridView.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gridView_CustomUnboundColumnData);
			// 
			// colCheck
			// 
			this.colCheck.Caption = " ";
			this.colCheck.ColumnEditor = this.repositoryItemCheckEdit1;
			this.colCheck.FieldName = "IsChecked";
			this.colCheck.MaxWidth = 1;
			this.colCheck.Name = "colCheck";
			this.colCheck.OptionsColumn.AllowMove = false;
			this.colCheck.OptionsColumn.AllowShowHide = false;
			this.colCheck.OptionsColumn.AllowSize = false;
			this.colCheck.OptionsColumn.FixedWidth = true;
			this.colCheck.ToolTip = "Migrate this pledge?";
			this.colCheck.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
			this.colCheck.Visible = true;
			this.colCheck.VisibleIndex = 0;
			this.colCheck.Width = 1;
			// 
			// repositoryItemCheckEdit1
			// 
			this.repositoryItemCheckEdit1.AutoHeight = false;
			this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
			// 
			// colPerson
			// 
			this.colPerson.AllowKeyboardActivation = false;
			this.colPerson.FieldName = "Person";
			this.colPerson.Name = "colPerson";
			this.colPerson.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
			this.colPerson.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
			this.colPerson.OptionsColumn.ReadOnly = true;
			this.colPerson.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
			this.colPerson.ShowEditorOnMouseDown = true;
			this.colPerson.Visible = true;
			this.colPerson.VisibleIndex = 1;
			this.colPerson.Width = 52;
			// 
			// colDate
			// 
			this.colDate.FieldName = "Date";
			this.colDate.Name = "colDate";
			this.colDate.Visible = true;
			this.colDate.VisibleIndex = 2;
			this.colDate.Width = 57;
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
			// colAccount
			// 
			this.colAccount.FieldName = "Account";
			this.colAccount.MaxWidth = 100;
			this.colAccount.Name = "colAccount";
			this.colAccount.Visible = true;
			this.colAccount.VisibleIndex = 5;
			this.colAccount.Width = 58;
			// 
			// colAmount
			// 
			this.colAmount.DisplayFormat.FormatString = "c";
			this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.colAmount.FieldName = "Amount";
			this.colAmount.MaxWidth = 85;
			this.colAmount.Name = "colAmount";
			this.colAmount.SummaryItem.DisplayFormat = "{0:c} Total Pledged";
			this.colAmount.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
			this.colAmount.Visible = true;
			this.colAmount.VisibleIndex = 6;
			this.colAmount.Width = 56;
			// 
			// colNote
			// 
			this.colNote.FieldName = "Note";
			this.colNote.Name = "colNote";
			this.colNote.Visible = true;
			this.colNote.VisibleIndex = 7;
			this.colNote.Width = 42;
			// 
			// colComments
			// 
			this.colComments.FieldName = "Comments";
			this.colComments.Name = "colComments";
			this.colComments.Visible = true;
			this.colComments.VisibleIndex = 8;
			this.colComments.Width = 69;
			// 
			// colModified
			// 
			this.colModified.DisplayFormat.FormatString = "g";
			this.colModified.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colModified.FieldName = "Modified";
			this.colModified.Name = "colModified";
			this.colModified.Width = 106;
			// 
			// colModifier
			// 
			this.colModifier.FieldName = "Modifier";
			this.colModifier.Name = "colModifier";
			this.colModifier.Width = 47;
			// 
			// layoutControlGroup1
			// 
			this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
			this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.layoutControlGroup1.GroupBordersVisible = false;
			this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.topLabel,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1});
			this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup1.Name = "Root";
			this.layoutControlGroup1.Size = new System.Drawing.Size(715, 357);
			this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.layoutControlGroup1.Text = "Root";
			this.layoutControlGroup1.TextVisible = false;
			// 
			// topLabel
			// 
			this.topLabel.Control = this.instructions;
			this.topLabel.CustomizationFormText = "topLabel";
			this.topLabel.Location = new System.Drawing.Point(0, 0);
			this.topLabel.Name = "topLabel";
			this.topLabel.Size = new System.Drawing.Size(695, 56);
			this.topLabel.Text = "topLabel";
			this.topLabel.TextSize = new System.Drawing.Size(0, 0);
			this.topLabel.TextToControlDistance = 0;
			this.topLabel.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.grid;
			this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 56);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 6, 6);
			this.layoutControlItem1.Size = new System.Drawing.Size(695, 254);
			this.layoutControlItem1.Text = "layoutControlItem1";
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextToControlDistance = 0;
			this.layoutControlItem1.TextVisible = false;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.cancel;
			this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
			this.layoutControlItem2.FillControlToClientArea = false;
			this.layoutControlItem2.Location = new System.Drawing.Point(586, 310);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(109, 27);
			this.layoutControlItem2.Text = "layoutControlItem2";
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextToControlDistance = 0;
			this.layoutControlItem2.TextVisible = false;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.ok;
			this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
			this.layoutControlItem3.FillControlToClientArea = false;
			this.layoutControlItem3.Location = new System.Drawing.Point(476, 310);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(110, 27);
			this.layoutControlItem3.Text = "layoutControlItem3";
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextToControlDistance = 0;
			this.layoutControlItem3.TextVisible = false;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
			this.emptySpaceItem1.Location = new System.Drawing.Point(0, 310);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(476, 27);
			this.emptySpaceItem1.Text = "emptySpaceItem1";
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// colPledgeId
			// 
			this.colPledgeId.FieldName = "PledgeId";
			this.colPledgeId.Name = "colPledgeId";
			this.colPledgeId.Visible = true;
			this.colPledgeId.VisibleIndex = 0;
			// 
			// colExternalSource
			// 
			this.colExternalSource.FieldName = "ExternalSource";
			this.colExternalSource.Name = "colExternalSource";
			this.colExternalSource.Visible = true;
			this.colExternalSource.VisibleIndex = 11;
			// 
			// colExternalId
			// 
			this.colExternalId.FieldName = "ExternalId";
			this.colExternalId.Name = "colExternalId";
			this.colExternalId.Visible = true;
			this.colExternalId.VisibleIndex = 12;
			// 
			// PledgeMigrator
			// 
			this.AcceptButton = this.ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(715, 357);
			this.ControlBox = false;
			this.Controls.Add(this.layoutControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PledgeMigrator";
			this.Text = "Migrate Pledges";
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.topLabel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.LabelControl instructions;
		private DevExpress.XtraLayout.LayoutControl layoutControl1;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
		private DevExpress.XtraLayout.LayoutControlItem topLabel;
		private DevExpress.XtraEditors.SimpleButton ok;
		private DevExpress.XtraEditors.SimpleButton cancel;
		private ShomreiTorah.Data.UI.Grid.SmartGrid grid;
		private ShomreiTorah.Data.UI.Grid.SmartGridView gridView;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private ShomreiTorah.Data.UI.Grid.SmartGridColumn colCheck;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
		private ShomreiTorah.Data.UI.Grid.SmartGridColumn colPerson;
		private ShomreiTorah.Data.UI.Grid.SmartGridColumn colDate;
		private ShomreiTorah.Data.UI.Grid.SmartGridColumn colType;
		private ShomreiTorah.Data.UI.Grid.SmartGridColumn colSubType;
		private ShomreiTorah.Data.UI.Grid.SmartGridColumn colAccount;
		private ShomreiTorah.Data.UI.Grid.SmartGridColumn colAmount;
		private ShomreiTorah.Data.UI.Grid.SmartGridColumn colNote;
		private ShomreiTorah.Data.UI.Grid.SmartGridColumn colComments;
		private ShomreiTorah.Data.UI.Grid.SmartGridColumn colModified;
		private ShomreiTorah.Data.UI.Grid.SmartGridColumn colModifier;
		private ShomreiTorah.Data.UI.Grid.SmartGridColumn colPledgeId;
		private ShomreiTorah.Data.UI.Grid.SmartGridColumn colExternalSource;
		private ShomreiTorah.Data.UI.Grid.SmartGridColumn colExternalId;
	}
}