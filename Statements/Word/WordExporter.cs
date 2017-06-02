using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using Microsoft.Win32;
using ShomreiTorah.Common;
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

			using (var options = new ExportOptions() {
				SkipEmail = people.Length > 1,
				ResendExistingReceipts = people.Length == 1
			}) {
				if (options.ShowDialog() == DialogResult.Cancel) return;
				var kinds = options.Kinds.OrderBy(k => (int)k).ToArray();

				statements = people
					.Distinct()
					.Where(p => !options.SkipEmail || !p.EmailAddresses.Any())
					.OrderBy(p => p.LastName)
					.SelectMany(p => kinds.Select(kind => new WordStatementInfo(p, options.StartDate, kind, options.ResendExistingReceipts)))
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

		readonly BitArray selection;
		readonly Person[] people;
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

			people = statements.Select(p => p.Person).Distinct().ToArray();

			//This must happen before the grid calls CustomUnboundColumnData
			selection = new BitArray(people.Length, true);

			// If no-one has an address (eg, generating statements for a single
			// person), don't uncheck anything. Otherwise, uncheck everyone who
			// does not have an address.
			if (people.Any(p => !String.IsNullOrWhiteSpace(p.Address))) {
				for (int i = 0; i < people.Length; i++) {
					selection[i] = !String.IsNullOrWhiteSpace(people[i].Address);
				}
			}
			colIsChecked.Visible = people.Length > 1;
			UpdateLabel();

			grid.DataSource = new RowListBinder(Program.Table<Person>(), people);

			CheckableGridController.Handle(colIsChecked);

			gridView.BestFitColumns();
			duplexMode.Checked = DefaultDuplexMode;
		}
		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			createDoc.Focus();
		}

		private ICollection<WordStatementInfo> SelectedStatements {
			get {
				return (from wsi in statements
						join p in people.Select((p, i) => new { Person = p, Index = i }) on wsi.Person equals p.Person
						where selection[p.Index]
						select wsi
					   ).ToList();
			}
		}

		private void MailingExport_ItemClick(object sender, ItemClickEventArgs e) {
			ProgressWorker.Execute(ui => MailingGenerator.CreateMailing(SelectedStatements, e.Item.Caption + ".docx", ui), true);

			cancel.Text = "Close";
		}
		void createDoc_Click(object sender, EventArgs e) {
			DefaultDuplexMode = duplexMode.Checked;
			var stmts = SelectedStatements;
			ProgressWorker.Execute(ui => StatementGenerator.CreateBills(stmts, ui, duplexMode.Checked), true);
			if (DialogResult.Yes == XtraMessageBox.Show("Would you like to log these statements?",
														"Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) {
				foreach (var statement in stmts) {
					statement.LogStatement();
				}
			}

			if (cancel.Text != "Close")
				XtraMessageBox.Show("To create mailing labels or envelopes, click the down arrow next to Create Documents.",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Information);
			cancel.Text = "Close";
		}

		private void cancel_Click(object sender, EventArgs e) { Close(); }

		private void gridView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
			if (e.Column == colIsChecked) {
				if (e.IsGetData)
					e.Value = selection[e.ListSourceRowIndex];
				else {
					selection[e.ListSourceRowIndex] = (bool)e.Value;
					UpdateLabel();
				}
			}
		}

		private void UpdateLabel() {
			// If there is only one person, we hide the checkboxes entirely.
			if (selection.Count == 1) {
				label.Text = "Generating " + statements.Join(" and ", wsi => wsi.Kind.ToString().ToLower()) + " for one person:";
				return;
			}

			var checkedCount = 0;
			for (int i = 0; i < selection.Count; i++) {
				if (selection[i])
					checkedCount++;
			}

			createDoc.Enabled = checkedCount > 0;

			if (checkedCount == 0)
				label.Text = "Please check at least one person to generate statements for.";
			else if (checkedCount == 1)
				label.Text = "Generating statements for one person out of " + selection.Count + ".";
			else if (checkedCount == selection.Count)
				label.Text = "Generating statements for all " + checkedCount + " people.";
			else
				label.Text = "Generating statements for " + checkedCount + " people out of " + selection.Count + ".";
		}
	}
}