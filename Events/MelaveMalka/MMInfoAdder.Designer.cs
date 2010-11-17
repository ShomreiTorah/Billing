namespace ShomreiTorah.Billing.Events.MelaveMalka {
	partial class MMInfoAdder {
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
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MMInfoAdder));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
			this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
			this.speaker = new DevExpress.XtraEditors.TextEdit();
			this.honoree = new ShomreiTorah.Data.UI.Controls.PersonSelector();
			this.melaveMalkaDate = new ShomreiTorah.Billing.Controls.HebrewCalendarEdit();
			this.adDeadline = new ShomreiTorah.Billing.Controls.HebrewCalendarEdit();
			this.year = new DevExpress.XtraEditors.SpinEdit();
			this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			this.cancel = new DevExpress.XtraEditors.SimpleButton();
			this.ok = new DevExpress.XtraEditors.SimpleButton();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
			this.dataLayoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.speaker.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.honoree.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.melaveMalkaDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.adDeadline.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.year.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataLayoutControl1
			// 
			this.dataLayoutControl1.Controls.Add(this.speaker);
			this.dataLayoutControl1.Controls.Add(this.honoree);
			this.dataLayoutControl1.Controls.Add(this.melaveMalkaDate);
			this.dataLayoutControl1.Controls.Add(this.adDeadline);
			this.dataLayoutControl1.Controls.Add(this.year);
			this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
			this.dataLayoutControl1.Name = "dataLayoutControl1";
			this.dataLayoutControl1.Root = this.layoutControlGroup1;
			this.dataLayoutControl1.Size = new System.Drawing.Size(574, 94);
			this.dataLayoutControl1.TabIndex = 0;
			this.dataLayoutControl1.Text = "dataLayoutControl1";
			// 
			// speaker
			// 
			this.speaker.Location = new System.Drawing.Point(93, 60);
			this.speaker.Name = "speaker";
			this.speaker.Size = new System.Drawing.Size(469, 20);
			this.speaker.StyleController = this.dataLayoutControl1;
			this.speaker.TabIndex = 8;
			// 
			// honoree
			// 
			this.honoree.Location = new System.Drawing.Point(93, 36);
			this.honoree.Name = "honoree";
			toolTipItem1.Text = "Click to select a person";
			superToolTip1.Items.Add(toolTipItem1);
			toolTipTitleItem1.Text = "New Person...";
			toolTipItem2.Text = "Adds a new person to the master directory";
			superToolTip2.Items.Add(toolTipTitleItem1);
			superToolTip2.Items.Add(toolTipItem2);
			this.honoree.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, superToolTip1, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "New person...", 90, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleLeft, ((System.Drawing.Image)(resources.GetObject("honoree.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, superToolTip2, true)});
			this.honoree.Properties.NullValuePrompt = "Click here to select the guest of honor";
			this.honoree.Size = new System.Drawing.Size(469, 20);
			this.honoree.StyleController = this.dataLayoutControl1;
			this.honoree.TabIndex = 7;
			// 
			// melaveMalkaDate
			// 
			this.melaveMalkaDate.Location = new System.Drawing.Point(409, 12);
			this.melaveMalkaDate.Name = "melaveMalkaDate";
			this.melaveMalkaDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
			this.melaveMalkaDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.melaveMalkaDate.Properties.DisplayFormat.FormatString = "dddd, MMMM d";
			this.melaveMalkaDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.melaveMalkaDate.Properties.EditFormat.FormatString = "dddd, MMMM d";
			this.melaveMalkaDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.melaveMalkaDate.Properties.Mask.EditMask = "dddd, MMMM d";
			this.melaveMalkaDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.melaveMalkaDate.Size = new System.Drawing.Size(153, 20);
			this.melaveMalkaDate.StyleController = this.dataLayoutControl1;
			this.melaveMalkaDate.TabIndex = 6;
			// 
			// adDeadline
			// 
			this.adDeadline.Location = new System.Drawing.Point(170, 12);
			this.adDeadline.Name = "adDeadline";
			this.adDeadline.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
			this.adDeadline.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.adDeadline.Properties.DisplayFormat.FormatString = "dddd, MMMM d";
			this.adDeadline.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.adDeadline.Properties.EditFormat.FormatString = "dddd, MMMM d";
			this.adDeadline.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.adDeadline.Properties.Mask.EditMask = "dddd, MMMM d";
			this.adDeadline.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
			this.adDeadline.Size = new System.Drawing.Size(162, 20);
			this.adDeadline.StyleController = this.dataLayoutControl1;
			this.adDeadline.TabIndex = 5;
			// 
			// year
			// 
			this.year.EditValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.year.Location = new System.Drawing.Point(43, 12);
			this.year.Name = "year";
			this.year.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
			this.year.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.year.Properties.Mask.EditMask = "f0";
			this.year.Properties.MaxValue = new decimal(new int[] {
            3000,
            0,
            0,
            0});
			this.year.Properties.MinValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.year.Size = new System.Drawing.Size(57, 20);
			this.year.StyleController = this.dataLayoutControl1;
			this.year.TabIndex = 4;
			this.year.EditValueChanged += new System.EventHandler(this.year_EditValueChanged);
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
            this.layoutControlItem5});
			this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup1.Name = "layoutControlGroup1";
			this.layoutControlGroup1.Size = new System.Drawing.Size(574, 94);
			this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.layoutControlGroup1.Text = "layoutControlGroup1";
			this.layoutControlGroup1.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.year;
			this.layoutControlItem1.CustomizationFormText = "Year:";
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.MaxSize = new System.Drawing.Size(92, 24);
			this.layoutControlItem1.MinSize = new System.Drawing.Size(92, 24);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(92, 24);
			this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem1.Text = "Year:";
			this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
			this.layoutControlItem1.TextSize = new System.Drawing.Size(26, 13);
			this.layoutControlItem1.TextToControlDistance = 5;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.adDeadline;
			this.layoutControlItem2.CustomizationFormText = "Ad Deadline:";
			this.layoutControlItem2.Location = new System.Drawing.Point(92, 0);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(232, 24);
			this.layoutControlItem2.Text = "Ad Deadline:";
			this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
			this.layoutControlItem2.TextSize = new System.Drawing.Size(61, 13);
			this.layoutControlItem2.TextToControlDistance = 5;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.melaveMalkaDate;
			this.layoutControlItem3.CustomizationFormText = "Melave Malka:";
			this.layoutControlItem3.Location = new System.Drawing.Point(324, 0);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(230, 24);
			this.layoutControlItem3.Text = "Melave Malka:";
			this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
			this.layoutControlItem3.TextSize = new System.Drawing.Size(68, 13);
			this.layoutControlItem3.TextToControlDistance = 5;
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.honoree;
			this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
			this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(554, 24);
			this.layoutControlItem4.Text = "Guest of Honor:";
			this.layoutControlItem4.TextSize = new System.Drawing.Size(77, 13);
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.speaker;
			this.layoutControlItem5.CustomizationFormText = "Guest Speaker:";
			this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.Size = new System.Drawing.Size(554, 26);
			this.layoutControlItem5.Text = "Guest Speaker:";
			this.layoutControlItem5.TextSize = new System.Drawing.Size(77, 13);
			// 
			// cancel
			// 
			this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(487, 6);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 1;
			this.cancel.Text = "Cancel";
			// 
			// ok
			// 
			this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ok.Location = new System.Drawing.Point(406, 6);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(75, 23);
			this.ok.TabIndex = 0;
			this.ok.Text = "OK";
			this.ok.Click += new System.EventHandler(this.ok_Click);
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.cancel);
			this.panelControl1.Controls.Add(this.ok);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelControl1.Location = new System.Drawing.Point(0, 94);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(574, 41);
			this.panelControl1.TabIndex = 10;
			// 
			// MMInfoAdder
			// 
			this.AcceptButton = this.ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(574, 135);
			this.ControlBox = false;
			this.Controls.Add(this.dataLayoutControl1);
			this.Controls.Add(this.panelControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(380, 147);
			this.Name = "MMInfoAdder";
			this.Text = "Add Melave Malka";
			((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
			this.dataLayoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.speaker.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.honoree.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.melaveMalkaDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.adDeadline.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.year.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
		private DevExpress.XtraEditors.SpinEdit year;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private Data.UI.Controls.PersonSelector honoree;
		private Controls.HebrewCalendarEdit melaveMalkaDate;
		private Controls.HebrewCalendarEdit adDeadline;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private DevExpress.XtraEditors.SimpleButton cancel;
		private DevExpress.XtraEditors.SimpleButton ok;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.TextEdit speaker;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
	}
}