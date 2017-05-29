using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using ShomreiTorah.Common;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI.DisplaySettings;
using ShomreiTorah.Singularity;
using ShomreiTorah.Statements.Email;
using ShomreiTorah.WinForms;
using ShomreiTorah.WinForms.Forms;

namespace ShomreiTorah.Billing.Events.MelaveMalka {
	partial class CallerList : XtraForm {
		static readonly DirectoryTemplateResolver Resolver = new DirectoryTemplateResolver(Path.Combine(Program.TemplatesDirectory, @"Email Templates\Caller Emails"));

		readonly ITemplateService razor;
		readonly FilteredTable<Caller> dataSource;
		readonly int year;
		public CallerList(int year) {
			Program.LoadTable<Caller>();
			InitializeComponent();
			this.Text = "Melave Malka " + year + " Callers";
			this.year = year;

			addCaller.Properties.DataSource = Program.Table<Person>();
			EditorRepository.PersonLookup.Apply(addCaller.Properties);

			grid.DataMember = null;
			grid.DataSource = dataSource = Program.Table<Caller>().Filter(c => c.Year == year);

			ToggleRowsBehavior.Instance.Apply(gridView);
			UpdateButtons();

			razor = new TemplateService(new TemplateServiceConfiguration { Resolver = Resolver });
			emailTemplateList.Strings.AddRange(Resolver.Templates.ToArray());
		}
		///<summary>Releases the unmanaged resources used by the CallerList and optionally releases the managed resources.</summary>
		///<param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				dataSource.Dispose();
				if (razor != null) razor.Dispose();
				if (components != null) components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void addCaller_EditValueChanged(object sender, EventArgs e) {
			var person = addCaller.EditValue as Person;
			if (person == null) return;
			addCaller.EditValue = null;

			if (person.Callers.Any(c => c.Year == year)) {
				Dialog.ShowError(person.FullName + " is already a caller for the " + year + " Melave Malka");
				return;
			}

			Program.Table<Caller>().Rows.Add(new Caller {
				Person = person,
				Year = year,
				DateAdded = DateTime.Now,
			});

			InfoMessage.Show(person.FullName + " has been added as a caller for the " + year + " Melave Malka");
		}

		private void emailLinkEdit_OpenLink(object sender, OpenLinkEventArgs e) {
			e.Handled = true;
			if (!String.IsNullOrWhiteSpace(e.EditValue as string))
				Process.Start("mailto: " + e.EditValue);
		}

		private void gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e) { UpdateButtons(); }
		void UpdateButtons() {
			var caller = gridView.GetFocusedRow() as Caller;
			if (caller == null)
				sendSingleEmail.Visibility = exportCallList.Visibility = BarItemVisibility.OnlyInCustomizing;
			else {
				sendSingleEmail.Visibility = exportCallList.Visibility = BarItemVisibility.Always;

				sendSingleEmail.Caption = "Email " + caller.Person.HisName + " " + caller.Person.LastName;
				exportCallList.Caption = "Export list for " + caller.Person.HisName + " " + caller.Person.LastName;
			}
		}

		private void exportCallList_ItemClick(object sender, ItemClickEventArgs e) {
			var caller = (Caller)gridView.GetFocusedRow();
			if (caller == null)
				Dialog.ShowError("Please select a caller");
			else if (caller.Callees.All(i => i.AdAmount > 0))
				Dialog.ShowError(caller.Name + " doesn't have anyone to call.");
			else {
				string path;
				using (var dialog = new SaveFileDialog {
					Filter = "Excel 2003 Spreadsheet|*.xls|Excel 2007 Spreadsheet (*.xlsx)|*.xlsx",
					FileName = "Call List for " + caller.Name + ".xls",
					Title = "Save Call List"
				}) {
					if (dialog.ShowDialog(MdiParent) != DialogResult.OK) return;
					path = dialog.FileName;
				}
				caller.CreateCallList(path);
				Process.Start(path);
			}
		}

		///<summary>The callers that the email menu was invoked for.</summary>
		IList<Caller> clickedCallers;
		private void sendSingleEmail_Popup(object sender, EventArgs e) {
			clickedCallers = new[] { (Caller)gridView.GetFocusedRow() };
		}

		private void sendAllEmails_Popup(object sender, EventArgs e) {
			clickedCallers = (IList<Caller>)dataSource.Rows;
		}

		private List<Caller> ConfirmSendEmailTemplate() {
			if (clickedCallers.Count == 0) {
				Dialog.ShowError("Please select a caller");
				return null;
			}
			var emptyCallers = clickedCallers.Where(c => c.Callees.All(i => i.AdAmount > 0)).ToList();
			if (emptyCallers.Any()) {
				Dialog.Show(emptyCallers.Join(", ", c => c.Person.FullName)
						  + " do not have anyone to call and will not be emailed.", MessageBoxIcon.Warning);
			}

			var nonEmailCallers = clickedCallers.Where(c => String.IsNullOrEmpty(c.EmailAddresses)).ToList();
			if (nonEmailCallers.Any())
				Dialog.Show(nonEmailCallers.Join(", ", c => c.Person.FullName) + " do not have email addresses.", MessageBoxIcon.Warning);

			var actualCallers = clickedCallers.Where(c => c.Callees.Any(i => i.AdAmount == 0) && !String.IsNullOrEmpty(c.EmailAddresses)).ToList();
			if (actualCallers.Count == 0) return null;	//We already displayed an error

			if (actualCallers.Count == 1) {
				if (!Dialog.Confirm("Would you like to send an email to " + actualCallers[0].Name + "?"))
					return null;
			} else {
				if (!Dialog.Confirm("Would you like to send emails to " + actualCallers.Count + " callers?"))
					return null;
			}
			return actualCallers;
		}
		private void emailTemplateList_ListItemClick(object sender, ListItemClickEventArgs e) {
			var actualCallers = ConfirmSendEmailTemplate();
			if (actualCallers == null) return;
			Program.LoadTables(MelaveMalkaInfo.Schema, MelaveMalkaSeat.Schema, MelaveMalkaInvitation.Schema);		//Used by the templates

			var template = emailTemplateList.Strings[e.Index];
			ProgressWorker.Execute(progress => {
				progress.Maximum = actualCallers.Count * 2;	//Two steps per caller

				foreach (var caller in actualCallers) {
					if (progress.WasCanceled) return;
					progress.Caption = "Creating spreadsheet for " + caller.Name;
					string attachmentPath;
					do {
						attachmentPath = Path.GetTempFileName();
						File.Delete(attachmentPath);
						attachmentPath = Path.ChangeExtension(attachmentPath, ".xls");	//OleDB cannot write XLS with other extensions
					} while (File.Exists(attachmentPath));

					try {
						caller.CreateCallList(attachmentPath);
						if (progress.WasCanceled) return;

						progress.Progress++;
						progress.Caption = "Emailing " + caller.Name;

						using (var message = razor.CreateMessage(caller, template)) {
							message.From = Email.JournalAddress;
							message.To.Add(caller.EmailAddresses);	//Comma-separated string
							message.Attachments.Add(new Attachment(attachmentPath, new ContentType {
								MediaType = "application/vnd.ms-excel",
								Name = "Call List for " + caller.Name + ".xls"
							}));

							Email.Default.Send(message);
						}
					} finally { File.Delete(attachmentPath); }
					progress.Progress++;
				}
			}, true);
		}
	}
}