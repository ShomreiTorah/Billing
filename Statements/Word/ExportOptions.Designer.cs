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
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportOptions));
            this.startDate = new DevExpress.XtraEditors.DateEdit();
            this.ExportOptionsConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
            this.docTypes = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.ok = new DevExpress.XtraEditors.SimpleButton();
            this.cancel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.skipEmail = new DevExpress.XtraEditors.CheckEdit();
            this.skipEmailItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.skipNonStaleReceipts = new DevExpress.XtraEditors.CheckEdit();
            this.skipNonStaleReceiptsItem = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.startDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExportOptionsConvertedLayout)).BeginInit();
            this.ExportOptionsConvertedLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skipEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skipEmailItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skipNonStaleReceipts.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skipNonStaleReceiptsItem)).BeginInit();
            this.SuspendLayout();
            // 
            // startDate
            // 
            this.startDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startDate.EditValue = new System.DateTime(2010, 1, 14, 0, 0, 0, 0);
            this.startDate.Location = new System.Drawing.Point(18, 40);
            this.startDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.startDate.Name = "startDate";
            this.startDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.startDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.startDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.startDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.startDate.Properties.DisplayFormat.FormatString = "MMMM d, yyyy";
            this.startDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.startDate.Properties.EditFormat.FormatString = "MMMM d, yyyy";
            this.startDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.startDate.Properties.Mask.EditMask = "MMMM d, yyyy";
            this.startDate.Properties.NullValuePrompt = "Please select a date";
            this.startDate.Properties.ShowToday = false;
            this.startDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.startDate.Size = new System.Drawing.Size(272, 26);
            this.startDate.StyleController = this.ExportOptionsConvertedLayout;
            this.startDate.TabIndex = 12;
            // 
            // ExportOptionsConvertedLayout
            // 
            this.ExportOptionsConvertedLayout.Controls.Add(this.skipNonStaleReceipts);
            this.ExportOptionsConvertedLayout.Controls.Add(this.skipEmail);
            this.ExportOptionsConvertedLayout.Controls.Add(this.docTypes);
            this.ExportOptionsConvertedLayout.Controls.Add(this.startDate);
            this.ExportOptionsConvertedLayout.Controls.Add(this.ok);
            this.ExportOptionsConvertedLayout.Controls.Add(this.cancel);
            this.ExportOptionsConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExportOptionsConvertedLayout.Location = new System.Drawing.Point(0, 0);
            this.ExportOptionsConvertedLayout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExportOptionsConvertedLayout.Name = "ExportOptionsConvertedLayout";
            this.ExportOptionsConvertedLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(973, 526, 675, 600);
            this.ExportOptionsConvertedLayout.Root = this.layoutControlGroup1;
            this.ExportOptionsConvertedLayout.Size = new System.Drawing.Size(308, 305);
            this.ExportOptionsConvertedLayout.TabIndex = 18;
            // 
            // docTypes
            // 
            this.docTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.docTypes.CheckOnClick = true;
            this.docTypes.Cursor = System.Windows.Forms.Cursors.Default;
            this.docTypes.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.docTypes.HotTrackItems = true;
            this.docTypes.HotTrackSelectMode = DevExpress.XtraEditors.HotTrackSelectMode.SelectItemOnClick;
            this.docTypes.Location = new System.Drawing.Point(18, 94);
            this.docTypes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.docTypes.Name = "docTypes";
            this.docTypes.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.docTypes.Size = new System.Drawing.Size(272, 97);
            this.docTypes.StyleController = this.ExportOptionsConvertedLayout;
            this.docTypes.TabIndex = 17;
            this.docTypes.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.docTypes_ItemCheck);
            // 
            // ok
            // 
            this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Enabled = false;
            this.ok.Location = new System.Drawing.Point(157, 255);
            this.ok.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(133, 32);
            this.ok.StyleController = this.ExportOptionsConvertedLayout;
            this.ok.TabIndex = 14;
            this.ok.Text = "OK";
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(18, 255);
            this.cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(133, 32);
            this.cancel.StyleController = this.ExportOptionsConvertedLayout;
            this.cancel.TabIndex = 13;
            this.cancel.Text = "Cancel";
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
            this.skipNonStaleReceiptsItem,
            this.skipEmailItem,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(308, 305);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.docTypes;
            this.layoutControlItem1.CustomizationFormText = "Generate:";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 54);
            this.layoutControlItem1.Name = "docTypesitem";
            this.layoutControlItem1.Size = new System.Drawing.Size(278, 125);
            this.layoutControlItem1.Text = "Generate:";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(74, 19);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.startDate;
            this.layoutControlItem2.CustomizationFormText = "Start date:";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "startDateitem";
            this.layoutControlItem2.Size = new System.Drawing.Size(278, 54);
            this.layoutControlItem2.Text = "Start date:";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(74, 19);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.ok;
            this.layoutControlItem3.CustomizationFormText = "okitem";
            this.layoutControlItem3.Location = new System.Drawing.Point(139, 237);
            this.layoutControlItem3.Name = "okitem";
            this.layoutControlItem3.Size = new System.Drawing.Size(139, 38);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.cancel;
            this.layoutControlItem4.CustomizationFormText = "cancelitem";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 237);
            this.layoutControlItem4.Name = "cancelitem";
            this.layoutControlItem4.Size = new System.Drawing.Size(139, 38);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // skipEmail
            // 
            this.skipEmail.Location = new System.Drawing.Point(18, 226);
            this.skipEmail.Name = "skipEmail";
            this.skipEmail.Properties.Caption = "Skip people with email addresses";
            this.skipEmail.Size = new System.Drawing.Size(272, 23);
            this.skipEmail.StyleController = this.ExportOptionsConvertedLayout;
            toolTipTitleItem2.Text = "Skip people with email addresses";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "If checked, will only generate statements for people who do not have any associat" +
    "ed email addresses.\r\n\r\nUse this to save paper.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.skipEmail.SuperTip = superToolTip2;
            this.skipEmail.TabIndex = 18;
            // 
            // skipEmailItem
            // 
            this.skipEmailItem.Control = this.skipEmail;
            this.skipEmailItem.Location = new System.Drawing.Point(0, 208);
            this.skipEmailItem.Name = "skipEmailItem";
            this.skipEmailItem.Size = new System.Drawing.Size(278, 29);
            this.skipEmailItem.TextSize = new System.Drawing.Size(0, 0);
            this.skipEmailItem.TextVisible = false;
            // 
            // skipNonStaleReceipts
            // 
            this.skipNonStaleReceipts.EditValue = true;
            this.skipNonStaleReceipts.Location = new System.Drawing.Point(18, 197);
            this.skipNonStaleReceipts.Name = "skipNonStaleReceipts";
            this.skipNonStaleReceipts.Properties.Caption = "Don\'t create extra receipts";
            this.skipNonStaleReceipts.Size = new System.Drawing.Size(272, 23);
            this.skipNonStaleReceipts.StyleController = this.ExportOptionsConvertedLayout;
            toolTipTitleItem1.Text = "Don\'t create extra receipts";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = resources.GetString("toolTipItem1.Text");
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.skipNonStaleReceipts.SuperTip = superToolTip1;
            this.skipNonStaleReceipts.TabIndex = 19;
            // 
            // skipNonStaleReceiptsItem
            // 
            this.skipNonStaleReceiptsItem.Control = this.skipNonStaleReceipts;
            this.skipNonStaleReceiptsItem.Location = new System.Drawing.Point(0, 179);
            this.skipNonStaleReceiptsItem.Name = "skipNonStaleReceiptsItem";
            this.skipNonStaleReceiptsItem.Size = new System.Drawing.Size(278, 29);
            this.skipNonStaleReceiptsItem.TextSize = new System.Drawing.Size(0, 0);
            this.skipNonStaleReceiptsItem.TextVisible = false;
            // 
            // ExportOptions
            // 
            this.AcceptButton = this.ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(308, 305);
            this.ControlBox = false;
            this.Controls.Add(this.ExportOptionsConvertedLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(188, 221);
            this.Name = "ExportOptions";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Create Word Statements";
            ((System.ComponentModel.ISupportInitialize)(this.startDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExportOptionsConvertedLayout)).EndInit();
            this.ExportOptionsConvertedLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.docTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skipEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skipEmailItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skipNonStaleReceipts.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skipNonStaleReceiptsItem)).EndInit();
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
		private DevExpress.XtraEditors.CheckEdit skipNonStaleReceipts;
		private DevExpress.XtraEditors.CheckEdit skipEmail;
		private DevExpress.XtraLayout.LayoutControlItem skipNonStaleReceiptsItem;
		private DevExpress.XtraLayout.LayoutControlItem skipEmailItem;
	}
}