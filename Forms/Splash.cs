using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics.CodeAnalysis;
using ShomreiTorah.Common;

namespace ShomreiTorah.Billing.Forms {
	partial class Splash : Form {
		static readonly Rectangle captionArea = new Rectangle(165, 281, 169, 37);
		readonly Bitmap image;

		Form captionForm;
		Label captionLabel;
		public Splash() {
			InitializeComponent();
			image = (Bitmap)BackgroundImage;
			SetStyle(ControlStyles.AllPaintingInWmPaint
				   | ControlStyles.UserPaint, true);

			captionForm = new Form {
				FormBorderStyle = FormBorderStyle.None,
				StartPosition = FormStartPosition.Manual,
				ShowInTaskbar = false,
				ControlBox = false,
				BackColor = Color.White
			};
			captionLabel = new Label {
				Dock = DockStyle.Fill,
				Font = new Font("Segoe UI", 12),
				Text = "Please Wait...",
				TextAlign = ContentAlignment.MiddleCenter
			};
			captionForm.Controls.Add(captionLabel);
		}

		public string Caption {
			get { return captionLabel.Text; }
			set { shownEvent.WaitOne(); BeginInvoke(new Action(delegate { captionLabel.Text = value; })); }
		}

		readonly ManualResetEvent shownEvent = new ManualResetEvent(false);
		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			Size = image.Size;

			Screen desktop = Screen.FromPoint(Control.MousePosition);

			var width = desktop.WorkingArea.Width;
			if (desktop.Bounds.Width > 2 * desktop.Bounds.Height)
				width /= 2;
			Rectangle screenRect = desktop.WorkingArea;
			Location = new Point(
				Math.Max(screenRect.X, screenRect.X + (width - Width) / 2),
				Math.Max(screenRect.Y, screenRect.Y + (screenRect.Height - Height) / 2)
			);

			UpdateWindow();
			captionForm.Bounds = RectangleToScreen(captionArea);
			captionForm.Show(this);
			captionForm.Bounds = RectangleToScreen(captionArea);
			shownEvent.Set();
		}
		protected override CreateParams CreateParams {
			get {
				CreateParams createParams = base.CreateParams;
				createParams.ExStyle |= NativeMethods.LayeredWindow;						//To support transparency, the window must be a layered window.
				return createParams;
			}
		}
		public void CloseSplash() {
			if (IsDisposed) {
				Email.Warn("Billing Splash Double-Close on " + Environment.MachineName + "\\" + Environment.UserName, Environment.StackTrace);
				return;
			}
			shownEvent.WaitOne();
			if (InvokeRequired)
				BeginInvoke(new Action(Dispose));
			else
				Dispose();
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null) components.Dispose();
				captionForm.Dispose();
				shownEvent.Close();
				image.Dispose();
			}
			base.Dispose(disposing);
		}
		static Point Zero;
		[SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults")]
		void UpdateWindow() {
			IntPtr screenDC = NativeMethods.GetDC(IntPtr.Zero);
			IntPtr imageDC = NativeMethods.CreateCompatibleDC(screenDC);
			IntPtr gdiBitmap = IntPtr.Zero;
			IntPtr oldBitmap = IntPtr.Zero;

			try {
				gdiBitmap = image.GetHbitmap(Color.FromArgb(0));				//Get a GDI handle to the image.
				oldBitmap = NativeMethods.SelectObject(imageDC, gdiBitmap);		//Select the image into the DC, and cache the old bitmap.

				Size size = image.Size;											//Get the size and location of the form, as integers.
				Point location = this.Location;

				BlendFunction alphaInfo = new BlendFunction { SourceConstantAlpha = 255, AlphaFormat = 1 };	//This struct provides information about the opacity of the form.

				NativeMethods.UpdateLayeredWindow(Handle, screenDC, ref location, ref size, imageDC, ref Zero, 0, ref alphaInfo, UlwType.Alpha);
			} finally {
				NativeMethods.ReleaseDC(IntPtr.Zero, screenDC);					//Release the Screen's DC.

				if (gdiBitmap != IntPtr.Zero) {									//If we got a GDI bitmap,
					NativeMethods.SelectObject(imageDC, oldBitmap);				//Select the old bitmap into the DC
					NativeMethods.DeleteObject(gdiBitmap);						//Delete the GDI bitmap,
				}
				NativeMethods.DeleteDC(imageDC);								//And delete the DC.
			}
			Invalidate();
		}
	}
}
