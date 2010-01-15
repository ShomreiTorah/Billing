namespace ShomreiTorah.Billing.Import.Journal {
	partial class YearPrompt {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YearPrompt));
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.year = new DevExpress.XtraEditors.SpinEdit();
			this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.year.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(12, 15);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(286, 13);
			this.labelControl1.TabIndex = 0;
			this.labelControl1.Text = "Please enter the year of the journal that you are importing:";
			// 
			// year
			// 
			this.year.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.year.EditValue = new decimal(new int[] {
            2010,
            0,
            0,
            0});
			this.year.Location = new System.Drawing.Point(304, 12);
			this.year.Name = "year";
			this.year.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.year.Properties.IsFloatValue = false;
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
			this.year.Size = new System.Drawing.Size(64, 20);
			this.year.TabIndex = 1;
			// 
			// simpleButton1
			// 
			this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.simpleButton1.Location = new System.Drawing.Point(293, 38);
			this.simpleButton1.Name = "simpleButton1";
			this.simpleButton1.Size = new System.Drawing.Size(75, 23);
			this.simpleButton1.TabIndex = 2;
			this.simpleButton1.Text = "Cancel";
			// 
			// simpleButton2
			// 
			this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.simpleButton2.Location = new System.Drawing.Point(212, 38);
			this.simpleButton2.Name = "simpleButton2";
			this.simpleButton2.Size = new System.Drawing.Size(75, 23);
			this.simpleButton2.TabIndex = 3;
			this.simpleButton2.Text = "OK";
			// 
			// YearPrompt
			// 
			this.AcceptButton = this.simpleButton2;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.simpleButton1;
			this.ClientSize = new System.Drawing.Size(380, 71);
			this.ControlBox = false;
			this.Controls.Add(this.simpleButton2);
			this.Controls.Add(this.simpleButton1);
			this.Controls.Add(this.year);
			this.Controls.Add(this.labelControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "YearPrompt";
			this.ShowIcon = false;
			this.Text = "Journal Year";
			((System.ComponentModel.ISupportInitialize)(this.year.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.SpinEdit year;
		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private DevExpress.XtraEditors.SimpleButton simpleButton2;
	}
}