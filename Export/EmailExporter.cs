using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Win32;
using ShomreiTorah.Common;
using ShomreiTorah.WinForms.Forms;

namespace ShomreiTorah.Billing.Export {
	partial class EmailExporter : XtraForm {
		readonly BillingData.MasterDirectoryRow[] people;
		readonly EditorButton sendPreviewButton, showPreviewButton;

		public static void Execute(params BillingData.MasterDirectoryRow[] people) {
			if (people == null) throw new ArgumentNullException("people");
			people = Array.FindAll(people, r => r.GetEmailListRows().Length > 0);
			if (people.Length == 0) return;
			Program.DoReload();

			if (HttpRuntime.AppDomainAppVirtualPath == null) {
				XtraMessageBox.Show("ASP.Net is not initialized.\r\nPlese restart the program and try again.",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var fileNames = Array.ConvertAll<string, string>(Directory.GetFiles(Program.AspxPath, "*.aspx"), Path.GetFileNameWithoutExtension);
			if (fileNames.Length == 0) {
				XtraMessageBox.Show("There are no email templates.\r\nPlese contact Schabse.",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			using (var form = new EmailExporter(people, fileNames)) {
				if (form.ShowDialog() == DialogResult.Cancel) return;
				form.SendBills();
			}
		}

		const string SettingsPath = @"HKEY_CURRENT_USER\Software\Shomrei Torah\Billing\";
		EmailExporter(BillingData.MasterDirectoryRow[] people, string[] fileNames) {
			InitializeComponent();
			this.people = people;

			sendPreviewButton = buttonEdit.Buttons[1];
			showPreviewButton = buttonEdit.Buttons[0];

			startDate.DateTime = new DateTime(DateTime.Today.AddDays(-20).Year, 1, 1);
			startDate.Properties.MaxValue = DateTime.Today;

			var recentEmails = (string[])Registry.GetValue(SettingsPath, "RecentPreviewEmails", null);
			if (recentEmails != null)
				previewAddress.Properties.Items.AddRange(recentEmails);
			previewAddress.Text = Registry.GetValue(SettingsPath, "LastPreviewEmail", null) as string;

			CheckPreviewAddress();

			grid.DataSource = people;
			gridView.BestFitColumns();

			emailTemplate.Properties.Items.AddRange(fileNames);
			emailTemplate.Properties.DropDownRows = Math.Max(emailTemplate.Properties.Items.Count, 7);
			SetEnabled();
		}

		protected override void OnClosed(EventArgs e) {
			base.OnClosed(e);
			if (previewAddress.Properties.Items.Count > 0)
				Registry.SetValue(SettingsPath, "RecentPreviewEmails", previewAddress.Properties.Items.OfType<string>().ToArray(), RegistryValueKind.MultiString);
			if (!String.IsNullOrEmpty(previewAddress.Text))
				Registry.SetValue(SettingsPath, "LastPreviewEmail", previewAddress.Text, RegistryValueKind.String);
		}

		private void EditValueChanged(object sender, EventArgs e) { SetEnabled(); }
		void SetEnabled() {
			showPreviewButton.Enabled = sendBills.Enabled = emailTemplate.EditValue != null && startDate.EditValue != null;
			sendPreviewButton.Enabled = showPreviewButton.Enabled && previewMailAddress != null;
		}

		static readonly MailAddress BillingAddress = new MailAddress("Billing@ShomreiTorah.us", "Shomrei Torah Billing");

		static readonly Dictionary<string, string> MediaTypes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
			{ ".png",	"image/png"		},
			{ ".gif",	"image/gif"		},
			{ ".jpeg",	"image/jpeg"	},
			{ ".jpg",	"image/jpeg"	},
		};
		static readonly string ImagesPath = Path.Combine(Program.AspxPath, @"Images\");
		MailMessage CreateMessage(BillingData.MasterDirectoryRow person) {
			using (var page = PageBuilder.CreatePage<EmailPage>("/" + emailTemplate.EditValue + ".aspx")) {
				page.ImagePrefix = "cid:";
				page.Info = new BillInfo(person, startDate.DateTime, page.Kind);

				var message = new MailMessage { From = BillingAddress, SubjectEncoding = Email.DefaultEncoding };

				var htmlContent = AlternateView.CreateAlternateViewFromString(page.RenderPage(), Email.DefaultEncoding, "text/html");

				htmlContent.TransferEncoding = System.Net.Mime.TransferEncoding.QuotedPrintable;
				htmlContent.LinkedResources.AddRange(page.ImageNames.Select(i =>
					new LinkedResource(Path.Combine(ImagesPath, i), MediaTypes[Path.GetExtension(i)]) { ContentId = i }
				));

				message.AlternateViews.Add(htmlContent);

				message.Subject = page.EmailSubject;

				return message;
			}
		}

		void SendBills() {
			ProgressWorker.Execute(ui => {
				ui.Maximum = people.Length;
				foreach (var person in people) {
					ui.Caption = "Emailing " + person.VeryFullName;
					ui.Progress++;

					if (ui.WasCanceled) return;

					using (var message = CreateMessage(person)) {
						message.To.AddRange(person.GetEmailListRows().Select(e => e.MailAddress));
						Email.Hosted.Send(message);
					}
				}
			}, true);
		}
		private void buttonEdit_ButtonClick(object sender, ButtonPressedEventArgs e) {
			var row = (BillingData.MasterDirectoryRow)gridView.GetFocusedRow();
			if (row == null) return;

			if (e.Button.Caption == sendPreviewButton.Caption) {
				using (var message = CreateMessage(row)) {
					message.To.Add(previewMailAddress);
					Email.Hosted.Send(message);
				}
			} else {
				string html, subject;
				using (var page = PageBuilder.CreatePage<EmailPage>("/" + emailTemplate.EditValue + ".aspx")) {
					page.ImagePrefix = ImagesPath;
					page.Info = new BillInfo(row, startDate.DateTime, page.Kind);

					html = page.RenderPage();
					subject = page.EmailSubject;
				}
				var form = new XtraForm {
					Text = "Email Preview: " + subject,
					FormBorderStyle = FormBorderStyle.SizableToolWindow,
					Size = new Size(600, 400),
					StartPosition = FormStartPosition.CenterParent,
					Icon = this.Icon
				};
				var browser = new CopyableWebBrowser {
					Dock = DockStyle.Fill,
					AllowNavigation = false,
					AllowWebBrowserDrop = false,
					DocumentText = html,
					IsWebBrowserContextMenuEnabled = false,
					WebBrowserShortcutsEnabled = false
				};
				form.Controls.Add(browser);
				form.Show(this);
			}
		}
		class CopyableWebBrowser : WebBrowser {
			public override bool PreProcessMessage(ref Message msg) {
				if (msg.Msg == 0x101	//WM_KEYUP
				 && msg.WParam.ToInt32() == (int)Keys.C && ModifierKeys == Keys.Control) {
					DoCopy();
					return true;
				}
				return base.PreProcessMessage(ref msg);
			}
			void DoCopy() {
				Document.ExecCommand("SelectAll", false, null);
				Document.ExecCommand("Copy", false, null);
				Document.ExecCommand("Unselect", false, null);
			}
		}

		private void gridView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
			if (e.Column == colEmails) {
				var row = (BillingData.MasterDirectoryRow)gridView.GetRow(e.RowHandle);
				if (row != null)
					e.Value = String.Join(", ", Array.ConvertAll(row.GetEmailListRows(), m => m.Email));
			}
		}

		MailAddress previewMailAddress;
		private void previewAddress_TextChanged(object sender, EventArgs e) { CheckPreviewAddress(); }
		void CheckPreviewAddress() {
			if (String.IsNullOrEmpty(previewAddress.Text)) {
				previewMailAddress = null;
			} else {
				try {
					previewMailAddress = new MailAddress(previewAddress.Text, Environment.UserName);
				} catch (FormatException) { previewMailAddress = null; }
			}
			SetEnabled();
		}

		private void previewAddress_AddingMRUItem(object sender, AddingMRUItemEventArgs e) {
			if (e.Item is MailAddress) return;
			try {
				new MailAddress(e.Item as string).ToString();
			} catch (FormatException) { e.Cancel = true; }
		}

		private void previewAddress_Validating(object sender, CancelEventArgs e) {
			CheckPreviewAddress();
			e.Cancel = !String.IsNullOrEmpty(previewAddress.Text) && previewMailAddress == null;
			previewAddress.ErrorText = e.Cancel ? "Invalid email address" : null;
		}
	}
}
