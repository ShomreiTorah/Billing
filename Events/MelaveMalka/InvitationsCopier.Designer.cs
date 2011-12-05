namespace ShomreiTorah.Billing.Events.MelaveMalka {
	partial class InvitationsCopier {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvitationsCopier));
			this.sourceYear = new DevExpress.XtraEditors.ComboBoxEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.copySources = new DevExpress.XtraEditors.CheckedListBoxControl();
			this.cancel = new DevExpress.XtraEditors.SimpleButton();
			this.doCopy = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.sourceYear.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.copySources)).BeginInit();
			this.SuspendLayout();
			// 
			// sourceYear
			// 
			this.sourceYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.sourceYear.Location = new System.Drawing.Point(72, 13);
			this.sourceYear.Name = "sourceYear";
			this.sourceYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.sourceYear.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
			this.sourceYear.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
			this.sourceYear.Size = new System.Drawing.Size(144, 20);
			this.sourceYear.TabIndex = 0;
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(12, 16);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(54, 13);
			this.labelControl1.TabIndex = 1;
			this.labelControl1.Text = "Copy from:";
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(12, 43);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(131, 13);
			this.labelControl2.TabIndex = 2;
			this.labelControl2.Text = "Select the sources to copy:";
			// 
			// copySources
			// 
			this.copySources.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.copySources.CheckOnClick = true;
			this.copySources.Location = new System.Drawing.Point(12, 62);
			this.copySources.Name = "copySources";
			this.copySources.Size = new System.Drawing.Size(204, 119);
			this.copySources.TabIndex = 3;
			this.copySources.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.copySources_ItemCheck);
			// 
			// cancel
			// 
			this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(141, 187);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 4;
			this.cancel.Text = "Cancel";
			// 
			// doCopy
			// 
			this.doCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.doCopy.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.doCopy.Location = new System.Drawing.Point(60, 188);
			this.doCopy.Name = "doCopy";
			this.doCopy.Size = new System.Drawing.Size(75, 23);
			this.doCopy.TabIndex = 5;
			this.doCopy.Text = "Copy";
			this.doCopy.Click += new System.EventHandler(this.doCopy_Click);
			// 
			// InvitationsCopier
			// 
			this.AcceptButton = this.doCopy;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(228, 222);
			this.Controls.Add(this.doCopy);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.copySources);
			this.Controls.Add(this.labelControl2);
			this.Controls.Add(this.labelControl1);
			this.Controls.Add(this.sourceYear);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "InvitationsCopier";
			this.Text = "InvitationsCopier";
			((System.ComponentModel.ISupportInitialize)(this.sourceYear.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.copySources)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.ComboBoxEdit sourceYear;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.CheckedListBoxControl copySources;
		private DevExpress.XtraEditors.SimpleButton cancel;
		private DevExpress.XtraEditors.SimpleButton doCopy;
	}
}