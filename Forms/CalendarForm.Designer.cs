using ShomreiTorah.WinForms.Controls;
namespace ShomreiTorah.Billing.Forms {
	partial class CalendarForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarForm));
			this.calendar = new ShomreiTorah.WinForms.Controls.HebrewCalendar();
			this.SuspendLayout();
			// 
			// calendar
			// 
			this.calendar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.calendar.Location = new System.Drawing.Point(0, 0);
			this.calendar.Name = "calendar";
			this.calendar.Size = new System.Drawing.Size(695, 435);
			this.calendar.TabIndex = 0;
			// 
			// CalendarForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(699, 439);
			this.Controls.Add(this.calendar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CalendarForm";
			this.Text = "Hebrew Calendar";
			this.ResumeLayout(false);

		}

		#endregion

		private HebrewCalendar calendar;
	}
}