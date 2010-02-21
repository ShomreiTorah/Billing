namespace ShomreiTorah.Billing.Statements.Word {
	partial class ExportOptions {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportOptions));
			this.startDate = new DevExpress.XtraEditors.DateEdit();
			this.cancel = new DevExpress.XtraEditors.SimpleButton();
			this.ok = new DevExpress.XtraEditors.SimpleButton();
			this.docTypes = new DevExpress.XtraEditors.CheckedListBoxControl();
			this.ExportOptionsConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
			this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.receiptLimit = new DevExpress.XtraEditors.DateEdit();
			this.receiptLimitContainer = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.startDate.Properties.VistaTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.startDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.docTypes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ExportOptionsConvertedLayout)).BeginInit();
			this.ExportOptionsConvertedLayout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.receiptLimit.Properties.VistaTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.receiptLimit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.receiptLimitContainer)).BeginInit();
			this.SuspendLayout();
			// 
			// startDate
			// 
			this.startDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.startDate.EditValue = new System.DateTime(2010, 1, 14, 0, 0, 0, 0);
			this.startDate.Location = new System.Drawing.Point(12, 28);
			this.startDate.Name = "startDate";
			this.startDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
			this.startDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.startDate.Properties.DisplayFormat.FormatString = "MMMM d, yyyy";
			this.startDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.startDate.Properties.EditFormat.FormatString = "MMMM d, yyyy";
			this.startDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.startDate.Properties.Mask.EditMask = "MMMM d, yyyy";
			this.startDate.Properties.NullValuePrompt = "Please select a date";
			this.startDate.Properties.ShowToday = false;
			this.startDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
			this.startDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.startDate.Size = new System.Drawing.Size(156, 20);
			this.startDate.StyleController = this.ExportOptionsConvertedLayout;
			this.startDate.TabIndex = 12;
			// 
			// cancel
			// 
			this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(89, 159);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(79, 22);
			this.cancel.StyleController = this.ExportOptionsConvertedLayout;
			this.cancel.TabIndex = 13;
			this.cancel.Text = "Cancel";
			// 
			// ok
			// 
			this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.ok.Enabled = false;
			this.ok.Location = new System.Drawing.Point(12, 159);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(73, 22);
			this.ok.StyleController = this.ExportOptionsConvertedLayout;
			this.ok.TabIndex = 14;
			this.ok.Text = "OK";
			// 
			// docTypes
			// 
			this.docTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.docTypes.CheckOnClick = true;
			this.docTypes.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
			this.docTypes.HotTrackItems = true;
			this.docTypes.HotTrackSelectMode = DevExpress.XtraEditors.HotTrackSelectMode.SelectItemOnClick;
			this.docTypes.Location = new System.Drawing.Point(12, 108);
			this.docTypes.Name = "docTypes";
			this.docTypes.SelectionMode = System.Windows.Forms.SelectionMode.None;
			this.docTypes.Size = new System.Drawing.Size(156, 47);
			this.docTypes.StyleController = this.ExportOptionsConvertedLayout;
			this.docTypes.TabIndex = 17;
			this.docTypes.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.docTypes_ItemCheck);
			// 
			// ExportOptionsConvertedLayout
			// 
			this.ExportOptionsConvertedLayout.Controls.Add(this.receiptLimit);
			this.ExportOptionsConvertedLayout.Controls.Add(this.docTypes);
			this.ExportOptionsConvertedLayout.Controls.Add(this.startDate);
			this.ExportOptionsConvertedLayout.Controls.Add(this.ok);
			this.ExportOptionsConvertedLayout.Controls.Add(this.cancel);
			this.ExportOptionsConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ExportOptionsConvertedLayout.Location = new System.Drawing.Point(0, 0);
			this.ExportOptionsConvertedLayout.Name = "ExportOptionsConvertedLayout";
			this.ExportOptionsConvertedLayout.Root = this.layoutControlGroup1;
			this.ExportOptionsConvertedLayout.Size = new System.Drawing.Size(180, 193);
			this.ExportOptionsConvertedLayout.TabIndex = 18;
			// 
			// layoutControlGroup1
			// 
			this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
			this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.layoutControlGroup1.GroupBordersVisible = false;
			this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.receiptLimitContainer});
			this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup1.Name = "layoutControlGroup1";
			this.layoutControlGroup1.Size = new System.Drawing.Size(180, 193);
			this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.layoutControlGroup1.Text = "layoutControlGroup1";
			this.layoutControlGroup1.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.docTypes;
			this.layoutControlItem1.CustomizationFormText = "Generate:";
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 80);
			this.layoutControlItem1.Name = "docTypesitem";
			this.layoutControlItem1.Size = new System.Drawing.Size(160, 67);
			this.layoutControlItem1.Text = "Generate:";
			this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
			this.layoutControlItem1.TextSize = new System.Drawing.Size(68, 13);
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.startDate;
			this.layoutControlItem2.CustomizationFormText = "Start date:";
			this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem2.Name = "startDateitem";
			this.layoutControlItem2.Size = new System.Drawing.Size(160, 40);
			this.layoutControlItem2.Text = "Start date:";
			this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
			this.layoutControlItem2.TextSize = new System.Drawing.Size(68, 13);
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.ok;
			this.layoutControlItem3.CustomizationFormText = "okitem";
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 147);
			this.layoutControlItem3.Name = "okitem";
			this.layoutControlItem3.Size = new System.Drawing.Size(77, 26);
			this.layoutControlItem3.Text = "okitem";
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextToControlDistance = 0;
			this.layoutControlItem3.TextVisible = false;
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.cancel;
			this.layoutControlItem4.CustomizationFormText = "cancelitem";
			this.layoutControlItem4.Location = new System.Drawing.Point(77, 147);
			this.layoutControlItem4.Name = "cancelitem";
			this.layoutControlItem4.Size = new System.Drawing.Size(83, 26);
			this.layoutControlItem4.Text = "cancelitem";
			this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem4.TextToControlDistance = 0;
			this.layoutControlItem4.TextVisible = false;
			// 
			// receiptLimit
			// 
			this.receiptLimit.EditValue = null;
			this.receiptLimit.Location = new System.Drawing.Point(12, 68);
			this.receiptLimit.Name = "receiptLimit";
			this.receiptLimit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.receiptLimit.Properties.DisplayFormat.FormatString = "MMMM d, yyyy";
			this.receiptLimit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.receiptLimit.Properties.EditFormat.FormatString = "MMMM d, yyyy";
			this.receiptLimit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.receiptLimit.Properties.Mask.EditMask = "MMMM d, yyyy";
			this.receiptLimit.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
			this.receiptLimit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.receiptLimit.Size = new System.Drawing.Size(156, 20);
			this.receiptLimit.StyleController = this.ExportOptionsConvertedLayout;
			this.receiptLimit.TabIndex = 18;
			// 
			// receiptLimitContainer
			// 
			this.receiptLimitContainer.Control = this.receiptLimit;
			this.receiptLimitContainer.CustomizationFormText = "Receipts after";
			this.receiptLimitContainer.Location = new System.Drawing.Point(0, 40);
			this.receiptLimitContainer.Name = "receiptLimitContainer";
			this.receiptLimitContainer.Size = new System.Drawing.Size(160, 40);
			this.receiptLimitContainer.Text = "Receipts after";
			this.receiptLimitContainer.TextLocation = DevExpress.Utils.Locations.Top;
			this.receiptLimitContainer.TextSize = new System.Drawing.Size(68, 13);
			this.receiptLimitContainer.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
			// 
			// ExportOptions
			// 
			this.AcceptButton = this.ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(180, 193);
			this.ControlBox = false;
			this.Controls.Add(this.ExportOptionsConvertedLayout);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(188, 221);
			this.Name = "ExportOptions";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Create Word Statements";
			((System.ComponentModel.ISupportInitialize)(this.startDate.Properties.VistaTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.startDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.docTypes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ExportOptionsConvertedLayout)).EndInit();
			this.ExportOptionsConvertedLayout.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.receiptLimit.Properties.VistaTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.receiptLimit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.receiptLimitContainer)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.DateEdit startDate;
		private DevExpress.XtraEditors.SimpleButton cancel;
		private DevExpress.XtraEditors.SimpleButton ok;
		private DevExpress.XtraEditors.CheckedListBoxControl docTypes;
		private DevExpress.XtraLayout.LayoutControl ExportOptionsConvertedLayout;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private DevExpress.XtraEditors.DateEdit receiptLimit;
		private DevExpress.XtraLayout.LayoutControlItem receiptLimitContainer;
	}
}