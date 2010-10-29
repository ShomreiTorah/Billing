using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ShomreiTorah.Data;
using ShomreiTorah.Singularity.DataBinding;
using ShomreiTorah.WinForms.Forms;

namespace ShomreiTorah.Billing.Statements.Word {
	partial class WordExporter : XtraForm {
		public static void Execute(Form parent, params Person[] people) {
			if (people == null) throw new ArgumentNullException("people");
			if (people.Length == 0) return;

			Program.Current.RefreshDatabase();
			WordStatementInfo[] statements;

			using (var options = new ExportOptions()) {
				if (options.ShowDialog() == DialogResult.Cancel) return;
				var kinds = options.Kinds.OrderBy(k => (int)k).ToArray();

				statements = people
					.Distinct()
					.OrderBy(p => p.LastName)
					.SelectMany(p => kinds.Select(kind => new WordStatementInfo(p, options.StartDate, kind, options.ReceiptLimit)))
					.Where(s => s.ShouldSend)
					.ToArray();
			}

			if (statements.Length == 0) {
				XtraMessageBox.Show("There are no people to send to.",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			new WordExporter(statements).Show(parent);
		}
		readonly WordStatementInfo[] statements;
		WordExporter(WordStatementInfo[] statements) {
			InitializeComponent();
			this.statements = statements;

			var barItems = Array.ConvertAll<string, BarItem>(Directory.GetFiles(WordExport.MailingTemplateFolder, "*.docx"),
				p => {
					var retVal = new BarButtonItem(barManager, Path.GetFileNameWithoutExtension(p));
					retVal.ItemClick += MailingExport_ItemClick;
					return retVal;
				}
			);
			barManager.Items.AddRange(barItems);
			mailingDocuments.ItemLinks.AddRange(barItems);

			grid.DataSource = new RowListBinder(
				Program.Table<Person>(),
				statements.Select(p => p.Person).Distinct().ToArray()
			);

			gridView.BestFitColumns();
		}
		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			createDoc.Focus();
		}

		private void MailingExport_ItemClick(object sender, ItemClickEventArgs e) {
			ProgressWorker.Execute(ui => MailingGenerator.CreateMailing(statements, e.Item.Caption + ".docx", ui), true);

			cancel.Text = "Close";
		}
		void createDoc_Click(object sender, EventArgs e) {
			ProgressWorker.Execute(ui => StatementGenerator.CreateBills(statements, ui), true);
			if (DialogResult.Yes == XtraMessageBox.Show("Would you like to log these statements?",
														"Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) {
				foreach (var statement in statements) {
					statement.LogStatement();
				}
			}

			if (cancel.Text != "Close")
				XtraMessageBox.Show("To create mailing labels or envelopes, click the down arrow next to Create Documents.",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Information);
			cancel.Text = "Close";
		}

		private void cancel_Click(object sender, EventArgs e) { Close(); }
	}
}