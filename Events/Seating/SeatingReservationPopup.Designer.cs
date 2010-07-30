namespace ShomreiTorah.Billing.Events.Seating {
	partial class SeatingReservationPopup {
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
			this.editor = new ShomreiTorah.Billing.Events.Seating.SeatingReservationEdit();
			this.SuspendLayout();
			// 
			// editor
			// 
			this.editor.Location = new System.Drawing.Point(0, 0);
			this.editor.Name = "editor";
			this.editor.Size = new System.Drawing.Size(647, 92);
			this.editor.TabIndex = 0;
			// 
			// SeatingReservationPopup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1018, 483);
			this.Controls.Add(this.editor);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "SeatingReservationPopup";
			this.Text = "Seating Reservation Editor";
			this.ResumeLayout(false);

		}

		#endregion

		private SeatingReservationEdit editor;
	}
}