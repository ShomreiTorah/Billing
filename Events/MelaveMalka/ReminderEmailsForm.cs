using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Export;
using DevExpress.XtraRichEdit.Export.Html;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using ShomreiTorah.Billing.Controls;
using ShomreiTorah.Common;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI.Controls;
using ShomreiTorah.Data.UI.DisplaySettings;
using ShomreiTorah.Data.UI.Grid;
using ShomreiTorah.Singularity;
using ShomreiTorah.Statements.Email;
using ShomreiTorah.WinForms;
using ShomreiTorah.WinForms.Forms;

namespace ShomreiTorah.Billing.Events.MelaveMalka {
	public partial class ReminderEmailsForm : XtraForm {
		static readonly DirectoryTemplateResolver Resolver = new DirectoryTemplateResolver(Path.Combine(Program.AppDirectory, @"Email Templates\Ad Reminders"));

		readonly ITemplateService razor;
		readonly FilteredTable<MelaveMalkaInvitation> dataSource;
		readonly int year;
		public ReminderEmailsForm(int year) {
			AdReminderEmail.Schema.ToString();          //Force static ctor
			Program.LoadTable<AdReminderEmail>();       //Will load invites as a dependency
			InitializeComponent();

			this.year = year;
			Text = "Melave Malka " + year + " Reminder Emails";

			listSearch.Properties.DataSource = bindingSource.DataSource = dataSource
				= Program.Table<MelaveMalkaInvitation>().Filter(mmi => mmi.Year == year && mmi.Person.EmailAddresses.Any());
			EditorRepository.PersonOwnedLookup.Apply(listSearch.Properties);

			gridView.ActiveFilterCriteria = new OperandProperty("AdAmount") == 0;
			new AdvancedColumnsBehavior("ad amounts", fieldNames: new[] { "AdAmount" }).Apply(gridView);

			CheckableGridController.Handle(colShouldEmail);

			razor = new TemplateService(new TemplateServiceConfiguration { Resolver = Resolver });
			resetSingle.Strings.AddRange(Resolver.Templates.ToArray());
			resetSelected.Strings.AddRange(Resolver.Templates.ToArray());
			previewAddressItem.EditValue = PreviewAddressEdit.DefaultAddress;   //It is impossible to have a non-default EditValue for a BarEditItem, so I apply the default manually.
		}

		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			ToggleRowsBehavior.Instance.Apply(gridView);    //Must happen after datasource application to handle PersonEditor events
		}

		///<summary>Releases the unmanaged resources used by the ReminderEmailsForm and optionally releases the managed resources.</summary>
		///<param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (emailLogRenderer.IsValueCreated) emailLogRenderer.Value.Dispose();
				if (razor != null) razor.Dispose();
				if (components != null) components.Dispose();
				dataSource.Dispose();
			}
			base.Dispose(disposing);
		}

		private void listSearch_EditValueChanged(object sender, EventArgs e) {
			var row = listSearch.EditValue as MelaveMalkaInvitation;
			if (row == null) return;
			var handle = gridView.GetRowHandle(dataSource.Rows.IndexOf(row));
			if (handle < 0)
				Dialog.ShowError(row.Person.FullName + " do not meet the current filter");
			else
				gridView.SetSelection(handle, makeVisible: true);
			listSearch.EditValue = null;
		}

		MelaveMalkaInvitation SelectedInvitee { get { return bindingSource.Current as MelaveMalkaInvitation; } }

		#region Send Emails
		private List<MelaveMalkaInvitation> ConfirmSendAll() {
			var allRecipients = dataSource.Rows.OrderBy(p => p.Person.LastName).Where(i => i.AdAmount == 0 && i.ShouldEmail).ToList();

			var recentRecipients = allRecipients.Where(i => i.ReminderEmails.Any(e => e.Date.Date == DateTime.Today)).ToList();
			if (recentRecipients.Any()) {
				string message;
				if (recentRecipients.Has(2))
					message = "The following people have already been emailed today and will not be emailed again:\r\n\r\n  • "
							+ recentRecipients.Join("\r\n  • ", i => i.Person.FullName);
				else
					message = recentRecipients.First().Person.FullName + " have already been emailed today and will not be emailed again.";
				Dialog.Show(message, MessageBoxIcon.Warning);
			}
			var emptyRecipients = allRecipients.Where(i => String.IsNullOrWhiteSpace(i.EmailSubject) || String.IsNullOrWhiteSpace(i.EmailSource)).ToList();
			if (emptyRecipients.Any()) {
				string message;
				if (emptyRecipients.Has(2))
					message = "The following people do not have en email to send:\r\n\r\n  • "
							+ emptyRecipients.Join("\r\n  • ", i => i.Person.FullName);
				else
					message = emptyRecipients.First().Person.FullName + " do not have en email to send.";
				Dialog.Show(message, MessageBoxIcon.Warning);
			}

			allRecipients.RemoveAll(i => recentRecipients.Contains(i) || emptyRecipients.Contains(i));
			if (allRecipients.Count == 0) {
				Dialog.Inform("There is no-one to email.");
				return null;
			} else if (allRecipients.Count == 1) {
				if (!Dialog.Confirm("Would you like to email " + allRecipients[0].Person.FullName + "?"))
					return null;
			} else {
				if (!Dialog.Confirm("Would you like to email " + allRecipients.Count + " people?"))
					return null;
			}

			return allRecipients;
		}
		private void sendAll_ItemClick(object sender, ItemClickEventArgs args) {
			bindingSource.EndEdit();        //Commit any changes in the editor.  (Very important; otherwise, any changes made since the last time it lost focus will not be sent)
			var allRecipients = ConfirmSendAll();
			if (allRecipients == null) return;

			ProgressWorker.Execute(progress => {
				progress.Maximum = allRecipients.Count;
				foreach (var recipient in allRecipients) {
					progress.Caption = "Emailing " + recipient.Person.FullName;
					progress.Progress++;
					SendEmail(recipient);
					if (progress.WasCanceled) return;
				}
			}, true);
		}
		private void sendSelected_ItemClick(object sender, ItemClickEventArgs args) {
			bindingSource.EndEdit();        //Commit any changes in the editor.  (Very important; otherwise, any changes made since the last time it lost focus will not be sent)
			#region Validation
			var recipient = SelectedInvitee;
			if (recipient == null) return;

			if (recipient.AdAmount > 0) {
				Dialog.ShowError(recipient.Person.FullName + " already gave an ad.");
				return;
			}
			if (String.IsNullOrWhiteSpace(recipient.EmailSubject) || String.IsNullOrWhiteSpace(recipient.EmailSource)) {
				Dialog.ShowError("Please enter an email to send.");
				return;
			}
			if (recipient.ReminderEmails.Any(e => e.Date.Date == DateTime.Today)) {
				if (!Dialog.Warn(recipient.Person.FullName + " have already been emailed today.\r\nAre you sure you want to send another email?"))
					return;
			} else {
				if (!Dialog.Confirm("Would you like to email " + recipient.Person.FullName + "?"))
					return;
			}
			#endregion

			ProgressWorker.Execute(progress => {
				progress.Maximum = -1;
				progress.Caption = "Emailing " + recipient.Person.FullName;
				SendEmail(recipient);
			}, false);
		}
		void SendEmail(MelaveMalkaInvitation recipient) {
			using (var message = new MailMessage {
				From = Email.JournalAddress,
				SubjectEncoding = Email.DefaultEncoding,
				BodyEncoding = Email.DefaultEncoding,
				Subject = recipient.EmailSubject,
				Body = recipient.EmailSource,
				IsBodyHtml = true
			}) {
				message.To.Add(recipient.EmailAddresses);   //Comma-separated string
				Email.Hosted.Send(message);
			}

			BeginInvoke(new Action(delegate {   //The table can only be updated from the UI thread.
				Program.Table<AdReminderEmail>().Rows.Add(new AdReminderEmail {
					Recipient = recipient,
					Date = DateTime.Now,
					EmailSubject = recipient.EmailSubject,
					EmailSource = recipient.EmailSource
				});
			}));
		}
		#endregion

		#region Email log view
		private void grid_FocusedViewChanged(object sender, ViewFocusEventArgs e) {
			if (e.View != null && e.View != gridView) { //If the user clicked a detail clone,
				var email = (AdReminderEmail)e.View.GetRow(0);
				gridView.SetSelection(gridView.GetRowHandle(dataSource.Rows.IndexOf(email.Recipient)), makeVisible: true);
			}
		}
		private void logView_DoubleClick(object sender, EventArgs e) {
			var view = (SmartGridView)sender;
			var info = view.CalcHitInfo(grid.PointToClient(MousePosition));

			if (info.RowHandle >= 0 && info.InRow) {
				var dx = e as DXMouseEventArgs;
				if (dx != null) dx.Handled = true;

				var email = (AdReminderEmail)view.GetRow(info.RowHandle);
				if (Dialog.Confirm("Would you like to set " + email.Recipient.Person.FullName + " to receive this email?")) {
					email.Recipient.EmailSubject = email.EmailSubject;
					email.Recipient.EmailSource = email.EmailSource;
				}
			}
		}
		readonly Lazy<RepositoryItemRichTextEdit> emailLogRenderer = new Lazy<RepositoryItemRichTextEdit>(
			() => new RepositoryItemRichTextEdit { DocumentFormat = DocumentFormat.Html },
			LazyThreadSafetyMode.None
		);
		private void logView_MeasurePreviewHeight(object sender, RowHeightEventArgs e) {
			using (RichTextEditViewInfo vi = new RichTextEditViewInfo(emailLogRenderer.Value)) {
				var view = ((GridView)sender);
				var email = (AdReminderEmail)view.GetRow(e.RowHandle);
				vi.LoadText(email.EmailSource);
				e.RowHeight = vi.CalcHeight(((GridViewInfo)view.GetViewInfo()).CalcRowPreviewWidth(e.RowHandle) - 1) + 2;
			}
		}
		private void logView_CustomDrawRowPreview(object sender, RowObjectCustomDrawEventArgs e) {
			using (RichTextEditViewInfo vi = new RichTextEditViewInfo(emailLogRenderer.Value)) {
				var view = ((GridView)sender);
				var email = (AdReminderEmail)view.GetRow(e.RowHandle);
				vi.LoadText(email.EmailSource);
				vi.UpdatePaintAppearance();
				vi.CalcViewInfo(e.Graphics, MouseButtons.None, Point.Empty, e.Bounds);
				RichTextEditPainter.DrawRTF(vi, e.Cache);
			}
			e.Handled = true;
		}
		#endregion

		#region Composer
		private void gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e) {
			splitContainerControl1.PanelVisibility = SelectedInvitee == null ? SplitPanelVisibility.Panel1 : SplitPanelVisibility.Both;
		}

		private void recipientAddresses_OpenLink(object sender, OpenLinkEventArgs e) {
			var str = e.EditValue as string;
			if (!String.IsNullOrWhiteSpace(str))
				Process.Start("mailto: " + str);
			e.Handled = true;
		}
		private void emailEditor_BeforeExport(object sender, BeforeExportEventArgs e) {
			if (e.DocumentFormat == DocumentFormat.Html)    //Force inline CSS, since Gmail's web UI ignores <style> elements
				((HtmlDocumentExporterOptions)e.Options).CssPropertiesExportType = CssPropertiesExportType.Inline;
		}

		bool suppressZoomItemChange;
		private void zoomBarProperties_EditValueChanging(object sender, ChangingEventArgs e) {
			suppressZoomItemChange = true;
			emailEditor.ActiveView.ZoomFactor = (int)e.NewValue / 100f;
			suppressZoomItemChange = false;
		}

		private void emailEditor_ZoomChanged(object sender, EventArgs e) {
			zoomItem.Caption = emailEditor.ActiveView.ZoomFactor.ToString("p0", CultureInfo.CurrentCulture);
			if (!suppressZoomItemChange)
				zoomItem.EditValue = (int)Math.Round(emailEditor.ActiveView.ZoomFactor * 100);
		}
		#endregion

		#region Templates
		private void resetSingle_ListItemClick(object sender, ListItemClickEventArgs e) {
			ApplyTemplate(resetSingle.Strings[e.Index], SelectedInvitee);
		}

		private void resetSelected_ListItemClick(object sender, ListItemClickEventArgs e) {
			ApplyTemplate(resetSelected.Strings[e.Index], gridView.GetSelectedRows().Select(gridView.GetRow).Cast<MelaveMalkaInvitation>().ToArray());
		}

		void ApplyTemplate(string templateName, params MelaveMalkaInvitation[] people) {
			if (people.Length == 0) {
				Dialog.ShowError("Please select people.");
				return;
			}
			if (people.Length > 1 && !Dialog.Confirm($"Would you like to set {people.Length} people to receive the {templateName} template?"))
				return;

			Program.LoadTable<MelaveMalkaInfo>();       //Used by the templates
			foreach (var recipient in people) {
				try {
					using (var message = razor.CreateMessage(recipient, templateName)) {
						recipient.EmailSubject = message.Subject;
						recipient.EmailSource = message.Body;
					}
				} catch (Exception ex) {
					Dialog.ShowError($"An error occurred while applying the template to {recipient.Person.VeryFullName}:\n{ex}");
					return;
				}
			}
		}
		#endregion

		private void showPreview_ItemClick(object sender, ItemClickEventArgs e) {
			var form = CopyableWebBrowser.CreatePreviewForm("Email Preview: " + SelectedInvitee.EmailSubject, SelectedInvitee.EmailSource);
			form.Show(MdiParent);
		}
		private void sendPreview_ItemClick(object sender, ItemClickEventArgs e) {
			if (String.IsNullOrWhiteSpace(previewAddressItem.EditValue as string)) {
				Dialog.ShowError("Please enter a preview address");
				return;
			}
			Email.Hosted.Send(
				from: Email.JournalAddress,
				to: new MailAddress(previewAddressItem.EditValue.ToString(), "Preview: " + Environment.UserName),
				subject: SelectedInvitee.EmailSubject,
				body: SelectedInvitee.EmailSource,
				html: true
			);
			InfoMessage.Show("Sent preview to " + previewAddressItem.EditValue);
		}

		private void inviteAllEmails_ItemClick(object sender, ItemClickEventArgs e) {
			var existingInvites = new HashSet<Person>(dataSource.Rows.Select(mmi => mmi.Person));
			foreach (var person in Program.Table<EmailAddress>().Rows.Select(ea => ea.Person).Distinct()) {
				if (person != null && !existingInvites.Contains(person))
					Program.Table<MelaveMalkaInvitation>().Rows.Add(new MelaveMalkaInvitation {
						Person = person,
						DateAdded = DateTime.Now,
						Year = year,
						Source = Names.MelaveMalkaSources.First()
					});

			}
		}
	}
}