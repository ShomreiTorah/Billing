namespace ShomreiTorah.Billing.Forms {
	partial class RelationCreator {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RelationCreator));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
			this.cancel = new DevExpress.XtraEditors.SimpleButton();
			this.add = new DevExpress.XtraEditors.SimpleButton();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.relationType = new DevExpress.XtraEditors.ComboBoxEdit();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.relativeSelector = new ShomreiTorah.Data.UI.Controls.PersonSelector();
			this.memberSelector = new ShomreiTorah.Data.UI.Controls.PersonSelector();
			((System.ComponentModel.ISupportInitialize)(this.relationType.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.relativeSelector.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memberSelector.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// cancel
			// 
			this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(275, 90);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 6;
			this.cancel.Text = "Cancel";
			// 
			// add
			// 
			this.add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.add.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.add.Location = new System.Drawing.Point(175, 90);
			this.add.Name = "add";
			this.add.Size = new System.Drawing.Size(94, 23);
			this.add.TabIndex = 5;
			this.add.Text = "Create Relation";
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(12, 41);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(19, 13);
			this.labelControl1.TabIndex = 1;
			this.labelControl1.Text = "is a ";
			// 
			// relationType
			// 
			this.relationType.Location = new System.Drawing.Point(37, 38);
			this.relationType.Name = "relationType";
			this.relationType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.relationType.Properties.NullValuePrompt = "Select a relation";
			this.relationType.Properties.NullValuePromptShowForEmptyValue = true;
			this.relationType.Size = new System.Drawing.Size(117, 20);
			this.relationType.TabIndex = 2;
			this.relationType.EditValueChanged += new System.EventHandler(this.Edit_ValueChanged);
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(160, 41);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(10, 13);
			this.labelControl2.TabIndex = 3;
			this.labelControl2.Text = "of";
			// 
			// relativeSelector
			// 
			this.relativeSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.relativeSelector.Location = new System.Drawing.Point(12, 12);
			this.relativeSelector.Name = "relativeSelector";
			toolTipItem1.Text = "Click to select a person";
			superToolTip1.Items.Add(toolTipItem1);
			toolTipTitleItem1.Text = "New Person...";
			toolTipItem2.Text = "Adds a new person to the master directory";
			superToolTip2.Items.Add(toolTipTitleItem1);
			superToolTip2.Items.Add(toolTipItem2);
			this.relativeSelector.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, superToolTip1, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "New person...", 90, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleLeft, ((System.Drawing.Image)(resources.GetObject("relativeSelector.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, superToolTip2, true)});
			this.relativeSelector.Properties.NullValuePrompt = "Select a relative";
			this.relativeSelector.Size = new System.Drawing.Size(338, 20);
			this.relativeSelector.TabIndex = 0;
			this.relativeSelector.EditValueChanged += new System.EventHandler(this.Edit_ValueChanged);
			// 
			// memberSelector
			// 
			this.memberSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.memberSelector.Location = new System.Drawing.Point(12, 64);
			this.memberSelector.Name = "memberSelector";
			toolTipItem3.Text = "Click to select a person";
			superToolTip3.Items.Add(toolTipItem3);
			toolTipTitleItem2.Text = "New Person...";
			toolTipItem4.Text = "Adds a new person to the master directory";
			superToolTip4.Items.Add(toolTipTitleItem2);
			superToolTip4.Items.Add(toolTipItem4);
			this.memberSelector.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, superToolTip3, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "New person...", 90, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleLeft, ((System.Drawing.Image)(resources.GetObject("memberSelector.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, superToolTip4, true)});
			this.memberSelector.Properties.NullValuePrompt = "Select a member of the Shul";
			this.memberSelector.Size = new System.Drawing.Size(338, 20);
			this.memberSelector.TabIndex = 4;
			this.memberSelector.EditValueChanged += new System.EventHandler(this.Edit_ValueChanged);
			// 
			// RelationCreator
			// 
			this.AcceptButton = this.add;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(362, 125);
			this.ControlBox = false;
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.relationType);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.relativeSelector);
			this.Controls.Add(this.memberSelector);
			this.Controls.Add(this.add);
			this.Controls.Add(this.cancel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(815, 163);
			this.MinimumSize = new System.Drawing.Size(215, 157);
			this.Name = "RelationCreator";
			this.Text = "Create Relation";
			((System.ComponentModel.ISupportInitialize)(this.relationType.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.relativeSelector.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memberSelector.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.SimpleButton cancel;
		private DevExpress.XtraEditors.SimpleButton add;
		private Data.UI.Controls.PersonSelector memberSelector;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.ComboBoxEdit relationType;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private Data.UI.Controls.PersonSelector relativeSelector;
	}
}