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

namespace ShomreiTorah.Billing.Statements.Email {
	using Email = ShomreiTorah.Common.Email;

	partial class EmailExporter : XtraForm {
		readonly BillingData.MasterDirectoryRow[] people;
		readonly EditorButton sendPreviewButton, showPreviewButton;

		public static void Execute(params BillingData.MasterDirectoryRow[] people) {
			if (people == null) throw new ArgumentNullException("people");
			var originalPeople = people;
			people = Array.FindAll(people, r => r.GetEmailListRows().Length > 0);
			if (people.Length == 0) {
				if (originalPeople.Length == 1)
					XtraMessageBox.Show(originalPeople[0].FullName + " do not have any email addresses.",
										"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				else
					XtraMessageBox.Show("None of the people you selected have email addresses.",
										"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
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
			new EmailExporter(people, fileNames).Show();
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

			grid.DataSource = Program.Data.MasterDirectory.Where(people.Contains).AsDataView();
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

		MailMessage CreateMessage(BillingData.MasterDirectoryRow person) {
			return PageBuilder.CreateMessage(person, "/" + emailTemplate.EditValue + ".aspx", startDate.DateTime);
		}

		void SendBills() {
			var exceptions = new List<KeyValuePair<BillingData.MasterDirectoryRow, SmtpException>>();
			ProgressWorker.Execute(ui => {
				ui.Maximum = people.Length;
				foreach (var person in people) {
					ui.Caption = "Emailing " + person.VeryFullName;
					ui.Progress++;

					if (ui.WasCanceled) return;

					using (var message = CreateMessage(person)) {
						if (message == null) continue;

						message.To.AddRange(person.GetEmailListRows().Select(e => e.MailAddress));
						try {
							Email.Hosted.Send(message);
						} catch (SmtpException ex) { exceptions.Add(new KeyValuePair<BillingData.MasterDirectoryRow, SmtpException>(person, ex)); }
					}
				}
			}, true);
			if (exceptions.Any())
				XtraMessageBox.Show("The following errors occurred while sending the emails:\r\n\r\n  • "
					+ exceptions.Join("\r\n\r\n  • ", kvp => kvp.Key.FullName + ": " + kvp.Value.Message),
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		private void buttonEdit_ButtonClick(object sender, ButtonPressedEventArgs e) {
			var row = (BillingData.MasterDirectoryRow)gridView.GetFocusedDataRow();
			if (row == null) return;

			if (e.Button.Caption == sendPreviewButton.Caption) {
				using (var message = CreateMessage(row)) {
					if (message == null) {
						XtraMessageBox.Show(row.FullName + " do not have any relevant data and will not receive an email.",
											"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
					message.To.Add(previewMailAddress);
					Email.Hosted.Send(message);
				}
			} else {
				string html, subject;
				using (var page = PageBuilder.CreatePage<EmailPage>("/" + emailTemplate.EditValue + ".aspx")) {
					page.ImagePrefix = PageBuilder.ImagesPath;
					page.Info = new BillInfo(row, startDate.DateTime, page.Kind);
					if (!page.Info.ShouldSend) {
						XtraMessageBox.Show(row.FullName + " do not have any relevant data and will not receive an email.",
											"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}

					html = page.RenderPage();
					subject = page.EmailSubject;
				}
				var form = new XtraForm {
					Text = "Email Preview: " + subject,
					FormBorderStyle = FormBorderStyle.SizableToolWindow,
					Size = new Size(800, 600),
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
				if (msg.Msg == 0x101) {	//WM_KEYUP
					var key = (Keys)msg.WParam.ToInt32();
					if (key == Keys.C && ModifierKeys == Keys.Control) {
						DoCopy();
						return true;
					} else if (key == Keys.Escape) {
						FindForm().Close();
						return true;
					}
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
				var row = (BillingData.MasterDirectoryRow)gridView.GetDataRow(e.RowHandle);
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

		private void sendBills_Click(object sender, EventArgs e) { SendBills(); }
		private void cancel_Click(object sender, EventArgs e) { Close(); }
	}
}
