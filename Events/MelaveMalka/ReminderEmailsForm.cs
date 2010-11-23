using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ShomreiTorah.Data;
using ShomreiTorah.Singularity;
using ShomreiTorah.Data.UI.DisplaySettings;
using DevExpress.Data.Filtering;
using ShomreiTorah.WinForms;
using DevExpress.Utils;

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
				mmi => mmi.Year == year
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
	}
}