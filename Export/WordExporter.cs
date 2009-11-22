using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

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

			grid.DataSource = people;
			gridView.BestFitColumns();
		}
		private void EditValueChanged(object sender, EventArgs e) { SetEnabled(); }
		void SetEnabled() { createDoc.Enabled = docType.EditValue != null && startDate.EditValue != null; }

		void CreateDocument() {
			XtraMessageBox.Show(this, "I haven't written the Word exporter yet.\r\nSorry.", "Shomrei Torah Billing");
		}
	}
}