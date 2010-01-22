namespace ShomreiTorah.Billing.Forms {
	partial class PaymentEditPopup {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentEditPopup));
			this.paymentEdit = new ShomreiTorah.Billing.Controls.PaymentEdit();
			this.SuspendLayout();
			// 
			// paymentEdit
			// 
			this.paymentEdit.Location = new System.Drawing.Point(0, 0);
			this.paymentEdit.MinimumSize = new System.Drawing.Size(347, 175);
			this.paymentEdit.Name = "paymentEdit";
			this.paymentEdit.Size = new System.Drawing.Size(485, 175);
			this.paymentEdit.TabIndex = 0;
			// 
			// PaymentEditPopup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(662, 334);
			this.Controls.Add(this.paymentEdit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PaymentEditPopup";
			this.Text = "Edit Payment";
			this.ResumeLayout(false);

		}

		#endregion

		private ShomreiTorah.Billing.Controls.PaymentEdit paymentEdit;
	}
}