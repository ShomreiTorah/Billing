using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ShomreiTorah.Common;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI.DisplaySettings;
using ShomreiTorah.Singularity;
using ShomreiTorah.WinForms;
using ShomreiTorah.WinForms.Forms;

namespace ShomreiTorah.Billing.Events.MelaveMalka {
	public partial class ReminderEmailsForm : XtraForm {
		readonly int year;

		readonly FilteredTable<MelaveMalkaInvitation> dataSource;
		public ReminderEmailsForm(int year) {
			AdReminderEmail.Schema.ToString();			//Force static ctor
			Program.LoadTable<AdReminderEmail>();		//Will load invites as a dependency
			InitializeComponent();

			this.year = year;
			Text = "Melave Malka " + year + " Reminder Emails";

			grid.DataMember = null;
			listSearch.Properties.DataSource = grid.DataSource = dataSource = new FilteredTable<MelaveMalkaInvitation>(
				Program.Table<MelaveMalkaInvitation>(),
				mmi => mmi.Year == year //&& mmi.Person.EmailAddresses.Any()
			);
			EditorRepository.PersonOwnedLookup.Apply(listSearch.Properties);

			gridView.ActiveFilterCriteria = new OperandProperty("AdAmount") == 0;
			new AdvancedColumnsBehavior("ad amounts", fieldNames: new[] { "AdAmount" }).Apply(gridView);

			CheckableGridController.Handle(colShouldEmail);
			ToggleRowsBehavior.Instance.Apply(gridView);
		}

		///<summary>Releases the unmanaged resources used by the ReminderEmailsForm and optionally releases the managed resources.</summary>
		///<param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				dataSource.Dispose();
				if (components != null) components.Dispose();
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

		#region Send Emails
		private void sendAll_ItemClick(object sender, ItemClickEventArgs args) {
			var allRecipients = dataSource.Rows.Where(i => i.AdAmount == 0 && i.ShouldEmail).ToList();
			var recentRecipients = allRecipients.Where(i => i.ReminderEmails.Any(e => e.Date.Date == DateTime.Today));
			if (recentRecipients.Any()) {
				string message;
				if (recentRecipients.Has(2))
					message = "The following people have already been emailed today and will not be emailed again:\r\n\r\n  • "
							+ recentRecipients.Join("\r\n  • ", i => i.Person.FullName);
				else
					message = recentRecipients.First().Person.FullName + " have already been emailed today and will not be emailed again.";
				Dialog.Show(message, MessageBoxIcon.Warning);
			}

			allRecipients.RemoveAll(i => i.ReminderEmails.Any(e => e.Date.Date == DateTime.Today));
			if (allRecipients.Count == 0) {
				Dialog.Inform("There is no-one to email.");
				return;
			} else if (allRecipients.Count == 1) {
				if (!Dialog.Confirm("Would you like to email " + allRecipients[0].Person.FullName + "?"))
					return;
			} else {
				if (!Dialog.Confirm("Would you like to email " + allRecipients.Count + " people?"))
					return;
			}

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
		static void SendEmail(MelaveMalkaInvitation recipient) { 
			//TODO: Send & log
		}
		#endregion
	}
}