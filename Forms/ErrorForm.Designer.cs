namespace ShomreiTorah.Billing.Forms {
	partial class ErrorForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorForm));
			this.caption = new DevExpress.XtraEditors.LabelControl();
			this.exceptionText = new DevExpress.XtraEditors.MemoEdit();
			((System.ComponentModel.ISupportInitialize)(this.exceptionText.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// caption
			// 
			this.caption.Appearance.Options.UseTextOptions = true;
			this.caption.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.caption.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
			this.caption.Dock = System.Windows.Forms.DockStyle.Top;
			this.caption.Location = new System.Drawing.Point(0, 0);
			this.caption.Name = "caption";
			this.caption.Padding = new System.Windows.Forms.Padding(4);
			this.caption.Size = new System.Drawing.Size(536, 21);
			this.caption.TabIndex = 0;
			this.caption.Text = "Unfortunately, an error occurred.\r\n";
			// 
			// exceptionText
			// 
			this.exceptionText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.exceptionText.Location = new System.Drawing.Point(0, 21);
			this.exceptionText.Name = "exceptionText";
			this.exceptionText.Properties.ReadOnly = true;
			this.exceptionText.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.exceptionText.Properties.UseParentBackground = true;
			this.exceptionText.Size = new System.Drawing.Size(536, 296);
			this.exceptionText.TabIndex = 1;
			// 
			// ErrorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(536, 317);
			this.Controls.Add(this.exceptionText);
			this.Controls.Add(this.caption);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ErrorForm";
			this.Text = "Error!";
			((System.ComponentModel.ISupportInitialize)(this.exceptionText.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.LabelControl caption;
		private DevExpress.XtraEditors.MemoEdit exceptionText;
	}
}