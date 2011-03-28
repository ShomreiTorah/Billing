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
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryForm));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
			this.personSelector = new ShomreiTorah.Data.UI.Controls.PersonSelector();
			this.groupSelector = new ShomreiTorah.Billing.Events.Auctions.AuctionGroupSelector();
			((System.ComponentModel.ISupportInitialize)(this.personSelector.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// personSelector
			// 
			this.personSelector.Dock = System.Windows.Forms.DockStyle.Top;
			this.personSelector.Location = new System.Drawing.Point(0, 0);
			this.personSelector.Name = "personSelector";
			toolTipItem3.Text = "Click to select a person";
			superToolTip3.Items.Add(toolTipItem3);
			toolTipTitleItem2.Text = "New Person...";
			toolTipItem4.Text = "Adds a new person to the master directory";
			superToolTip4.Items.Add(toolTipTitleItem2);
			superToolTip4.Items.Add(toolTipItem4);
			this.personSelector.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, superToolTip3, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "New person...", 90, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleLeft, ((System.Drawing.Image)(resources.GetObject("personSelector1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, superToolTip4, true)});
			this.personSelector.Size = new System.Drawing.Size(536, 20);
			this.personSelector.TabIndex = 0;
			// 
			// groupSelector
			// 
			this.groupSelector.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupSelector.Location = new System.Drawing.Point(0, 20);
			this.groupSelector.Name = "groupSelector";
			this.groupSelector.Size = new System.Drawing.Size(536, 20);
			this.groupSelector.TabIndex = 1;
			this.groupSelector.SelectionChanged += new System.EventHandler(this.groupSelector_SelectionChanged);
			// 
			// EntryForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(536, 365);
			this.Controls.Add(this.groupSelector);
			this.Controls.Add(this.personSelector);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "EntryForm";
			this.Text = "Auction Entry";
			((System.ComponentModel.ISupportInitialize)(this.personSelector.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Data.UI.Controls.PersonSelector personSelector;
		private AuctionGroupSelector groupSelector;
	}
}