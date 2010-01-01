using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using ShomreiTorah.WinForms.Forms;

namespace ShomreiTorah.Billing.Export {
	partial class WordExporter : XtraForm {
		public static void Execute(params BillingData.MasterDirectoryRow[] people) {
			if (people == null) throw new ArgumentNullException("people");
			if (people.Length == 0) return;

			Program.DoReload();
			using (var form = new WordExporter(people)) {
				if (form.ShowDialog() == DialogResult.Cancel) return;
				form.CreateDocument();
			}
		}
		readonly BillingData.MasterDirectoryRow[] people;
		WordExporter(BillingData.MasterDirectoryRow[] people) {
			InitializeComponent();
			this.people = people;
			startDate.DateTime = new DateTime(DateTime.Today.AddDays(-20).Year, 1, 1);
			startDate.Properties.MaxValue = DateTime.Today;

			grid.DataSource = people;
			gridView.BestFitColumns();
		}
		private void EditValueChanged(object sender, EventArgs e) { SetEnabled(); }
		void SetEnabled() { createDoc.Enabled = docType.EditValue != null && startDate.EditValue != null; }

		void CreateDocument() {
			XtraMessageBox.Show(this, "I haven't written the Word exporter yet.\r\nSorry.", "Shomrei Torah Billing");
		}

		private void createDoc_Click(object sender, EventArgs e) { CreateDocument(); }

		private void createEnvelopes_ItemClick(object sender, ItemClickEventArgs e) { ProgressWorker.Execute(ui => WordExport.CreateEnvelopes(people, ui), true); }

		private void createLabels_ItemClick(object sender, ItemClickEventArgs e) { ProgressWorker.Execute(ui => WordExport.CreateLabels(people, "8160", ui), true); }
	}
}