namespace ShomreiTorah.Billing.Forms {
	partial class PledgeEditPopup {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PledgeEditPopup));
			this.pledgeEdit = new ShomreiTorah.Billing.Controls.PledgeEdit();
			this.SuspendLayout();
			// 
			// pledgeEdit
			// 
			this.pledgeEdit.Location = new System.Drawing.Point(0, 0);
			this.pledgeEdit.MinimumSize = new System.Drawing.Size(480, 203);
			this.pledgeEdit.Name = "pledgeEdit";
			this.pledgeEdit.Size = new System.Drawing.Size(555, 203);
			this.pledgeEdit.TabIndex = 0;
			// 
			// PledgeEditPopup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(750, 586);
			this.Controls.Add(this.pledgeEdit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PledgeEditPopup";
			this.Text = "Edit Pledge";
			this.ResumeLayout(false);

		}

		#endregion

		private ShomreiTorah.Billing.Controls.PledgeEdit pledgeEdit;
	}
}