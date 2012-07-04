namespace ShomreiTorah.Billing.Forms {
	partial class AutoPledgePrompt {
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
			this.message = new DevExpress.XtraEditors.LabelControl();
			this.addAutoPledge = new DevExpress.XtraEditors.SimpleButton();
			this.doNothing = new DevExpress.XtraEditors.SimpleButton();
			this.cancel = new DevExpress.XtraEditors.SimpleButton();
			this.SuspendLayout();
			// 
			// message
			// 
			this.message.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.message.Appearance.Options.UseTextOptions = true;
			this.message.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.message.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.message.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.message.Location = new System.Drawing.Point(12, 12);
			this.message.Name = "message";
			this.message.Size = new System.Drawing.Size(380, 64);
			this.message.TabIndex = 0;
			this.message.Text = "This person has $80.00 due, and you are adding a $120.00 payment.\r\nWhat" +
				" would you like to do?";
			this.message.UseMnemonic = false;
			// 
			// addAutoPledge
			// 
			this.addAutoPledge.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.addAutoPledge.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.addAutoPledge.Location = new System.Drawing.Point(95, 82);
			this.addAutoPledge.Name = "addAutoPledge";
			this.addAutoPledge.Size = new System.Drawing.Size(214, 23);
			this.addAutoPledge.TabIndex = 1;
			this.addAutoPledge.Text = "Add a $40.00 donation pledge";
			// 
			// doNothing
			// 
			this.doNothing.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.doNothing.DialogResult = System.Windows.Forms.DialogResult.Ignore;
			this.doNothing.Location = new System.Drawing.Point(95, 125);
			this.doNothing.Name = "doNothing";
			this.doNothing.Size = new System.Drawing.Size(214, 23);
			this.doNothing.TabIndex = 2;
			this.doNothing.Text = "Do nothing, and keep a negative balance";
			// 
			// cancel
			// 
			this.cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(95, 168);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(214, 23);
			this.cancel.TabIndex = 3;
			this.cancel.Text = "Cancel";
			// 
			// AutoPledgePrompt
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(404, 203);
			this.ControlBox = false;
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.doNothing);
			this.Controls.Add(this.addAutoPledge);
			this.Controls.Add(this.message);
			this.MinimumSize = new System.Drawing.Size(412, 193);
			this.Name = "AutoPledgePrompt";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Confirm Pledge";
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.LabelControl message;
		private DevExpress.XtraEditors.SimpleButton addAutoPledge;
		private DevExpress.XtraEditors.SimpleButton doNothing;
		private DevExpress.XtraEditors.SimpleButton cancel;
	}
}