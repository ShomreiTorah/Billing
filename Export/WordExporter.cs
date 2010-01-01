using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ShomreiTorah.WinForms.Forms;

namespace ShomreiTorah.Billing.Export {
	partial class WordExporter : XtraForm {
		public static void Execute(params BillingData.MasterDirectoryRow[] people) {
			if (people == null) throw new ArgumentNullException("people");
			if (people.Length == 0) return;

			Program.DoReload();
			using (var form = new WordExporter(people)) {
				form.ShowDialog();
			}
		}
		readonly BillingData.MasterDirectoryRow[] people;
		WordExporter(BillingData.MasterDirectoryRow[] people) {
			InitializeComponent();
			this.people = people;

			docType.Properties.Items.AddRange(Array.ConvertAll<string, string>(Directory.GetFiles(WordExport.TemplateFolder, "*.docx"), Path.GetFileNameWithoutExtension));

			startDate.DateTime = new DateTime(DateTime.Today.AddDays(-20).Year, 1, 1);
			startDate.Properties.MaxValue = DateTime.Today;

			grid.DataSource = people;
			gridView.BestFitColumns();
		}
		private void EditValueChanged(object sender, EventArgs e) { SetEnabled(); }
		void SetEnabled() { createDoc.Enabled = docType.EditValue != null && startDate.EditValue != null; }

		private void createDoc_Click(object sender, EventArgs e) {
			ProgressWorker.Execute(ui => WordExport.DoExport(people, docType.Text + ".docx", ui), true);
			cancel.Text = "Close";
		}
	}
}