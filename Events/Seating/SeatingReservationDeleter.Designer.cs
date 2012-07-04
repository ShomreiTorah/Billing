namespace ShomreiTorah.Billing.Events.Seating {
	partial class SeatingReservationDeleter {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeatingReservationDeleter));
			this.message = new DevExpress.XtraEditors.LabelControl();
			this.cancel = new DevExpress.XtraEditors.SimpleButton();
			this.deleteSeat = new DevExpress.XtraEditors.SimpleButton();
			this.deleteBoth = new DevExpress.XtraEditors.SimpleButton();
			this.SuspendLayout();
			// 
			// message
			// 
			this.message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.message.Appearance.Options.UseTextOptions = true;
			this.message.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.message.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
			this.message.Location = new System.Drawing.Point(12, 12);
			this.message.Name = "message";
			this.message.Size = new System.Drawing.Size(306, 26);
			this.message.TabIndex = 0;
			this.message.Text = "Are you sure you want to delete this $500 reservation for 3 seats for this person?";
			this.message.UseMnemonic = false;
			// 
			// cancel
			// 
			this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(12, 152);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(306, 23);
			this.cancel.TabIndex = 3;
			this.cancel.Text = "Cancel";
			this.cancel.Click += new System.EventHandler(this.cancel_Click);
			// 
			// deleteSeat
			// 
			this.deleteSeat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.deleteSeat.Location = new System.Drawing.Point(13, 123);
			this.deleteSeat.Name = "deleteSeat";
			this.deleteSeat.Size = new System.Drawing.Size(305, 23);
			this.deleteSeat.TabIndex = 2;
			this.deleteSeat.Text = "Delete Seating Reservation Only";
			this.deleteSeat.Click += new System.EventHandler(this.deleteSeat_Click);
			// 
			// deleteBoth
			// 
			this.deleteBoth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.deleteBoth.Location = new System.Drawing.Point(12, 94);
			this.deleteBoth.Name = "deleteBoth";
			this.deleteBoth.Size = new System.Drawing.Size(306, 23);
			this.deleteBoth.TabIndex = 1;
			this.deleteBoth.Text = "Delete Seating Reservation and Pledge";
			this.deleteBoth.Click += new System.EventHandler(this.deleteBoth_Click);
			// 
			// SeatingReservationDeleter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(330, 187);
			this.ControlBox = false;
			this.Controls.Add(this.deleteBoth);
			this.Controls.Add(this.deleteSeat);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.message);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SeatingReservationDeleter";
			this.Text = "Delete Seating Reservation";
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.LabelControl message;
		private DevExpress.XtraEditors.SimpleButton cancel;
		private DevExpress.XtraEditors.SimpleButton deleteSeat;
		private DevExpress.XtraEditors.SimpleButton deleteBoth;
	}
}