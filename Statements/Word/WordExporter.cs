using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using ShomreiTorah.Data;
using ShomreiTorah.Singularity.DataBinding;
using ShomreiTorah.WinForms;
using ShomreiTorah.WinForms.Forms;

namespace ShomreiTorah.Billing.Statements.Word {
	partial class WordExporter : XtraForm {
		static bool defaultDuplexMode = 0 != (int)Registry.GetValue(Program.SettingsPath, "DefaultDuplexMode", defaultValue: 1);
		public static bool DefaultDuplexMode {
			get { return defaultDuplexMode; }
			set {
				defaultDuplexMode = value;
				Registry.SetValue(Program.SettingsPath, "DefaultDuplexMode", value ? 1 : 0);
			}
		}


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
			duplexMode.Checked = DefaultDuplexMode;
		}
		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			createDoc.Focus();
		}

		private void MailingExport_ItemClick(object sender, ItemClickEventArgs e) {
			ProgressWorker.Execute(ui =>
				MailingGenerator.CreateMailing(statements.Where(wsi => !String.IsNullOrWhiteSpace(wsi.Person.Address)).ToList(), e.Item.Caption + ".docx", ui),
			true);

			cancel.Text = "Close";

			NotifyMissingAddresses(e.Item.Caption.ToLowerInvariant());
		}
		void createDoc_Click(object sender, EventArgs e) {
			DefaultDuplexMode = duplexMode.Checked;
			ProgressWorker.Execute(ui => StatementGenerator.CreateBills(statements, ui, duplexMode.Checked), true);
			if (DialogResult.Yes == XtraMessageBox.Show("Would you like to log these statements?",
														"Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) {
				foreach (var statement in statements) {
					statement.LogStatement();
				}
			}

			if (cancel.Text != "Close")
				Dialog.Inform("To create mailing labels or envelopes, click the down arrow next to Create Documents.");

			cancel.Text = "Close";

			NotifyMissingAddresses("statements");
		}

		private void NotifyMissingAddresses(string noun) {
			var missingAddresses = statements.Count(wsi => String.IsNullOrWhiteSpace(wsi.Person.Address));
			if (missingAddresses == 0) return;

			Dialog.Inform("These " + noun + " include " + missingAddresses + (missingAddresses == 1 ? " person" : " people") + " with no mailing address.\r\nSee the filtered grid for details");
			gridView.ActiveFilterCriteria = new NullOperator("Address") | new BinaryOperator("Address", "", BinaryOperatorType.Equal);
		}

		private void cancel_Click(object sender, EventArgs e) { Close(); }
	}
}