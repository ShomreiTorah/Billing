using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Drawing.Imaging;
using System.Net.Mail;
using ShomreiTorah.Common;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;
using System.IO.Compression;
using ShomreiTorah.WinForms.Forms;
using System.Net.Mime;

namespace ShomreiTorah.Billing.Forms {
	partial class ErrorForm : XtraForm {
		readonly Exception exception;
		readonly Stream imageStream;
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Error handling")]
		public ErrorForm(Exception exception) {
			InitializeComponent();

			while (exception is TargetInvocationException)
				exception = exception.InnerException;

			try {
				imageStream = SaveScreenshot();
			} catch { }

			this.exception = exception;
			exceptionText.Text = exception.ToString();
		}
		[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Error handling")]
		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			bool emailSent;
			try {
				ProgressWorker.Execute(ui => {
					ui.Caption = "Creating error report";
					using (var message = new MailMessage(Email.AlertsAddress, Email.AdminAddress)) {
						message.Subject = "ShomreiTorah.Billing v" + Updater.Checker.CurrentVersion + " Error from " + Environment.MachineName + "\\" + Environment.UserName;
						message.Body = exception.ToString();

						try {
							message.Attachments.Add(new Attachment(SaveDB(), "Data.xml.gz", "application/x-gzip"));
						} catch { }
						if (imageStream != null)
							message.Attachments.Add(new Attachment(imageStream, "Screen.jpeg", MediaTypeNames.Image.Jpeg));

						ui.Caption = "Sending error report";
						Email.Default.Send(message);
					}
				}, false);
				emailSent = true;
			} catch (TargetInvocationException) {
				emailSent = false;
			}
			caption.Text += emailSent ? "The error has been emailed to our IT department."
									  : "Another error occurred while emailing the error to our IT department.";
			exceptionText.DeselectAll();
		}
		static Stream SaveDB() {
			var retVal = new MemoryStream();
			using (var compressor = new GZipStream(retVal, CompressionMode.Compress, true))
				Program.Data.WriteXml(compressor);
			retVal.Position = 0;
			return retVal;
		}
		static Stream SaveScreenshot() {
			var retVal = new MemoryStream();
			var screen = SystemInformation.VirtualScreen;
			using (var image = new Bitmap(screen.Width, screen.Height))
			using (var g = Graphics.FromImage(image)) {
				g.CopyFromScreen(screen.Location, Point.Empty, screen.Size);
				image.Save(retVal, ImageFormat.Jpeg);
			}
			retVal.Position = 0;
			return retVal;
		}
	}
}