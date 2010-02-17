using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
			BillKind[] kinds;
			DateTime startDate;

			using (var options = new ExportOptions()) {
				if (options.ShowDialog() == DialogResult.Cancel) return;
				startDate = options.StartDate;
				kinds = options.Kinds.ToArray();
			}

			//Only include people who should receive at least one of the BillKinds.
			people = people.Where(p => kinds.Any(k => new BillInfo(p, startDate, k).ShouldSend))
						   .OrderBy(p => p.LastName)
						   .ToArray();

			if (people.Length == 0) {
				XtraMessageBox.Show("There are no people to send to.",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			using (var form = new WordExporter(kinds, startDate, people)) {
				form.ShowDialog();
			}
		}
		readonly DateTime startDate;
		readonly BillKind[] kinds;
		readonly BillingData.MasterDirectoryRow[] people;
		WordExporter(BillKind[] kinds, DateTime startDate, BillingData.MasterDirectoryRow[] people) {
			InitializeComponent();
			this.kinds = kinds;
			this.startDate = startDate;
			this.people = people;

			var barItems = Array.ConvertAll<string, BarItem>(Directory.GetFiles(WordExport.MailingTemplateFolder, "*.docx"),
				p => {
					var retVal = new BarButtonItem(barManager, Path.GetFileNameWithoutExtension(p));
					retVal.ItemClick += MailingExport_ItemClick;
					return retVal;
				}
			);
			barManager.Items.AddRange(barItems);
			mailingDocuments.ItemLinks.AddRange(barItems);

			grid.DataSource = Program.Data.MasterDirectory.Where(people.Contains).AsDataView();
			gridView.BestFitColumns();
		}
		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			createDoc.Focus();
		}

		private void MailingExport_ItemClick(object sender, ItemClickEventArgs e) {
			ProgressWorker.Execute(ui => WordExport.CreateMailing(people, e.Item.Caption + ".docx", ui), true);
			cancel.Text = "Close";
		}
		void createDoc_Click(object sender, EventArgs e) {
			ProgressWorker.Execute(ui => WordExport.CreateBills(people, kinds, startDate, ui), true);
			if (cancel.Text != "Close")
				XtraMessageBox.Show("To create mailing labels or envelopes, click the down arrow next to Create Documents.",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Information);
			cancel.Text = "Close";
		}
	}
}