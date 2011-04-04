namespace ShomreiTorah.Billing.Events.Auctions {
	partial class EntryForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryForm));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.save = new DevExpress.XtraEditors.SimpleButton();
			this.cancel = new DevExpress.XtraEditors.SimpleButton();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.summaryLabel = new DevExpress.XtraEditors.LabelControl();
			this.personSelector = new ShomreiTorah.Data.UI.Controls.PersonSelector();
			this.entryGrid = new ShomreiTorah.Billing.Events.Auctions.EntryGrid();
			this.groupSelector = new ShomreiTorah.Billing.Events.Auctions.AuctionGroupSelector();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.personSelector.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.labelControl2);
			this.panelControl1.Controls.Add(this.save);
			this.panelControl1.Controls.Add(this.cancel);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelControl1.Location = new System.Drawing.Point(0, 584);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(621, 41);
			this.panelControl1.TabIndex = 3;
			// 
			// labelControl2
			// 
			this.labelControl2.Appearance.Font = new System.Drawing.Font("Larissa", 21F);
			this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Purple;
			this.labelControl2.Dock = System.Windows.Forms.DockStyle.Left;
			this.labelControl2.Location = new System.Drawing.Point(2, 2);
			this.labelControl2.Margin = new System.Windows.Forms.Padding(0);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.labelControl2.Size = new System.Drawing.Size(170, 37);
			this.labelControl2.TabIndex = 2;
			this.labelControl2.Text = "Happy Birthday!";
			// 
			// save
			// 
			this.save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.save.Location = new System.Drawing.Point(416, 6);
			this.save.Name = "save";
			this.save.Size = new System.Drawing.Size(87, 23);
			this.save.TabIndex = 0;
			this.save.Text = "Apply Changes";
			this.save.Click += new System.EventHandler(this.save_Click);
			// 
			// cancel
			// 
			this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancel.Location = new System.Drawing.Point(509, 6);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(100, 23);
			this.cancel.TabIndex = 1;
			this.cancel.Text = "Discard Changes";
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// labelControl1
			// 
			this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelControl1.Location = new System.Drawing.Point(0, 63);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(621, 521);
			this.labelControl1.TabIndex = 4;
			this.labelControl1.Text = "Please select a person";
			// 
			// summaryLabel
			// 
			this.summaryLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
			this.summaryLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.summaryLabel.Location = new System.Drawing.Point(0, 40);
			this.summaryLabel.Name = "summaryLabel";
			this.summaryLabel.Padding = new System.Windows.Forms.Padding(5);
			this.summaryLabel.Size = new System.Drawing.Size(621, 23);
			this.summaryLabel.TabIndex = 5;
			this.summaryLabel.Text = "a&b&c";
			this.summaryLabel.UseMnemonic = false;
			// 
			// personSelector
			// 
			this.personSelector.Dock = System.Windows.Forms.DockStyle.Top;
			this.personSelector.Location = new System.Drawing.Point(0, 0);
			this.personSelector.Name = "personSelector";
			toolTipItem1.Text = "Click to select a person";
			superToolTip1.Items.Add(toolTipItem1);
			toolTipTitleItem1.Text = "New Person...";
			toolTipItem2.Text = "Adds a new person to the master directory";
			superToolTip2.Items.Add(toolTipTitleItem1);
			superToolTip2.Items.Add(toolTipItem2);
			this.personSelector.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, superToolTip1, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "New person...", 90, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleLeft, ((System.Drawing.Image)(resources.GetObject("personSelector.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, superToolTip2, true)});
			this.personSelector.Size = new System.Drawing.Size(621, 20);
			this.personSelector.TabIndex = 0;
			this.personSelector.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.personSelector_ButtonPressed);
			this.personSelector.EditValueChanged += new System.EventHandler(this.personSelector_EditValueChanged);
			// 
			// entryGrid
			// 
			this.entryGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.entryGrid.Location = new System.Drawing.Point(0, 63);
			this.entryGrid.Name = "entryGrid";
			this.entryGrid.Size = new System.Drawing.Size(621, 521);
			this.entryGrid.TabIndex = 2;
			this.entryGrid.Visible = false;
			this.entryGrid.Changed += new System.EventHandler(this.entryGrid_Changed);
			// 
			// groupSelector
			// 
			this.groupSelector.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupSelector.Location = new System.Drawing.Point(0, 20);
			this.groupSelector.Name = "groupSelector";
			this.groupSelector.Size = new System.Drawing.Size(621, 20);
			this.groupSelector.TabIndex = 1;
			this.groupSelector.SelectionChanged += new System.EventHandler(this.groupSelector_SelectionChanged);
			// 
			// EntryForm
			// 
			this.AcceptButton = this.save;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(621, 625);
			this.Controls.Add(this.entryGrid);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.summaryLabel);
			this.Controls.Add(this.panelControl1);
			this.Controls.Add(this.groupSelector);
			this.Controls.Add(this.personSelector);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "EntryForm";
			this.Text = "Auction Entry";
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			this.panelControl1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.personSelector.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Data.UI.Controls.PersonSelector personSelector;
		private AuctionGroupSelector groupSelector;
		private EntryGrid entryGrid;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.SimpleButton save;
		private DevExpress.XtraEditors.SimpleButton cancel;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.LabelControl summaryLabel;
		private DevExpress.XtraEditors.LabelControl labelControl2;
	}
}