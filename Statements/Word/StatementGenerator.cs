using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Microsoft.Office.Interop.Word;
using RazorEngine.Templating;
using ShomreiTorah.Common;
using ShomreiTorah.Data;
using ShomreiTorah.Statements;
using ShomreiTorah.Statements.Email;
using ShomreiTorah.WinForms;

namespace ShomreiTorah.Billing.Statements.Word {
	static class StatementGenerator {
		static Application Word { get { return Office<ApplicationClass>.App; } }

		public static void Prepare(IEnumerable<WordStatementInfo> statements) {
			Program.LoadTables(statements.Select(s => s.Kind).Distinct().SelectMany(GetSchemas));
		}

		private static IEnumerable<Singularity.TableSchema> GetSchemas(StatementKind kind) {
			Document sd = null;
			try {
				sd = OpenTemplate(kind);
				var p = (dynamic)sd.CustomDocumentProperties;
				string[] tableNames = p["Singularity-Tables"]?.Value?.ToString().Split(',') ?? new string[0];
				return tableNames
					.Select(typeof(Person).Assembly.GetType)
					.Select(t => t.InvokeMember("Schema", BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Static, null, null, null))
					.Cast<Singularity.TableSchema>();
			} catch {
				// The CustomDocumentProperties indexer can mysteriously fail.
				// When that happens, let the user load things by hand instead
				// of making it impossible to generate statements.
				return Enumerable.Empty<Singularity.TableSchema>();
			} finally {
				sd?.CloseDoc();
			}
		}

		public static Document CreateBills(ICollection<WordStatementInfo> statements, IProgressReporter progress, bool duplexMode) {
			if (statements == null) throw new ArgumentNullException("statements");

			progress = progress ?? new EmptyProgressReporter();

			progress.Caption = "Creating document";

			Dictionary<StatementKind, Range> sourceRanges = new Dictionary<StatementKind, Range>();
			try {
				foreach (var kind in statements.Select(s => s.Kind).Distinct()) {
					Document sd = OpenTemplate(kind);
					// Fix Word 2013 bug 
					// http://blogs.msmvps.com/wordmeister/2013/02/22/word2013bug-not-available-for-reading/
					sd.ActiveWindow.View.Type = WdViewType.wdPrintView;
					sourceRanges.Add(kind, sd.Range());
				}

				Document doc = Word.Documents.Add();
				doc.ShowGrammaticalErrors = doc.ShowSpellingErrors = false;
				Range range = doc.Range();

				bool firstPage = true;
				using (new ClipboardScope())
				using (var populator = new StatementPopulator()) {
					progress.Maximum = statements.Count;
					int i = 0;
					foreach (var info in statements) {
						if (progress.WasCanceled) return null;
						progress.Progress = i;

						progress.Caption = "Creating " + info.Kind.ToString().ToLower(Culture) + " for " + info.Person.VeryFullName;

						if (firstPage)
							firstPage = false;
						else
							range.BreakPage(forceOddPage: duplexMode);

						sourceRanges[info.Kind].Copy();
						range.Paste();

						populator.Populate(range, info);
						foreach (Shape shape in range.ShapeRange)
							populator.Populate(shape.TextFrame.TextRange, info);

						i++;
					}
				}
				Word.Activate();
				doc.Activate();
				return doc;
			} finally {
				foreach (var sd in sourceRanges.Values) sd.Document.CloseDoc();
			}
		}

		private static Document OpenTemplate(StatementKind kind) {
			return Word.Documents.Open(
				FileName: Path.Combine(WordExport.TemplateFolder, kind.ToString() + ".docx"),
				ReadOnly: true,
				AddToRecentFiles: false
			);
		}

		///<summary>Appends a page break to a range, replacing any trailing whitespace.</summary>
		static void BreakPage(this Range range, bool forceOddPage) {
			range.Start = range.End - 1;
			while (range.Text.Trim().Length == 0)
				range.Start--;
			range.Start++;
			range.Text = "";
			range.InsertBreak(forceOddPage ? WdBreakType.wdSectionBreakOddPage : WdBreakType.wdPageBreak);
			range.Collapse(WdCollapseDirection.wdCollapseEnd);
		}

		sealed class StatementPopulator : DataContentPopulator, IDisposable {
			delegate void CustomField(Range range, StatementInfo info);
			static readonly Dictionary<string, CustomField> CustomFields = new Dictionary<string, CustomField>(StringComparer.CurrentCultureIgnoreCase){
				{ "BalanceDue",     (range, info) => range.Text = info.Person.Field<decimal>("BalanceDue").ToString("c", Culture) },
				{ "Paid",           (range, info) => range.Text = info.TotalPaid.ToString("c") },
				{ "Year",           (range, info) => range.Text = info.StartDate.Year.ToString(CultureInfo.CurrentCulture) },
				{ "StartDate",      (range, info) => range.Text = info.StartDate.ToShortDateString() },
				{ "MailingAddress", (range, info) => range.Text = addressLiner.Replace(info.Person.MailingAddress, "\v") },
				{ "Deductibility",  (range, info) => range.Text = info.Deductibility },
				{ "contributions",  (range, info) => range.Text = info.Accounts.Sum(a => a.Payments.Count) == 1 ? "contribution" : "contributions" },
				{ "Table",           CreateTable },
				{ "PayTo",           InsertPayTo },
			};

			public StatementInfo Info { get; private set; }
			public void Populate(Range range, StatementInfo info) { Info = info; base.Populate(range, info.Person); }
			readonly Lazy<RazorRunner> razorRunner = new Lazy<RazorRunner>();

			public void Dispose() {
				if (razorRunner.IsValueCreated) razorRunner.Value.Dispose();
			}

			static readonly Regex whitespace = new Regex(@"[\r\n\s]+");
			const string RazorPrefix = "Razor:";
			protected override bool PopulateCustomField(Range range, string name) {
				if (name.StartsWith(RazorPrefix)) {
					range.Text = whitespace.Replace(XElement.Parse($"<div>{RenderRazor(name)}</div>").Value, " ");
					return true;
				}
				if (!CustomFields.TryGetValue(name, out CustomField customField))
					return false;
				customField(range, Info);
				return true;
			}

			private string RenderRazor(string name) {
				return razorRunner.Value.RenderTemplate(name.Substring(RazorPrefix.Length).Trim(), Info);
			}
		}

		sealed class RazorRunner : IDisposable {
			// We only use StatementBuilder to reuse its Razor config (namespaces).
			StatementBuilder razor = new StatementBuilder(Path.Combine(Program.TemplatesDirectory, @"Email Templates\Statements"), imagePath: null);

			public void Dispose() => razor.Dispose();

			public string RenderTemplate(string name, StatementInfo info) {
				return razor.TemplateService.Resolve(name, null).Run(new ExecuteContext {
					ViewBag = { Info = info }
				});
			}
		}

		//This regex strips extra whitespace from well-indented XML.
		static readonly Regex addressCleaner = new Regex(@"[ \t]+");
		static readonly Regex addressLiner = new Regex(@"\r?\n\s*");
		static readonly string mailingAddress = addressCleaner.Replace(
					addressLiner.Replace(Config.MailingAddress.Trim(), "\v"),
					" ");

		static void InsertPayTo(Range range, StatementInfo info) {
			if (info.TotalBalance == 0)
				range.Text = "";
			else {
				range.Text = "To pay your balance securely by credit card, go to https://" + Config.DomainName + "/Donate.";
				range.InsertParagraphAfter();
				range.InsertAfter("Please make your checks payable to ");
				var subRange = range.AppendText(Config.LegalName);
				range.InsertAfter(", and mail your remittance to:");
				range.InsertParagraphAfter();
				subRange.Font.Bold = 1;

				subRange = range.AppendText(mailingAddress);
				range.InsertParagraphAfter();

				subRange.ParagraphFormat.LeftIndent = 36;
				subRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
			}
		}

		#region FillTable
		static readonly CultureInfo Culture = CultureInfo.CurrentCulture;
		//Receipts are the same as bills except that they don't have
		//Balance Due, the Pledges section, and the Payments header.
		static void CreateTable(Range targetRange, StatementInfo info) {
			var table = targetRange.Tables.Add(targetRange, 2, 3);

			table.Rows.Alignment = WdRowAlignment.wdAlignRowCenter;
			table.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
			table.Range.ParagraphFormat.SpaceAfter = 0;
			table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
			Range range;
			Row row;
			foreach (var account in info.Accounts) {
				if (info.Kind == StatementKind.Bill) {
					row = table.AddRow().MakeHeader();
					row.Range.Text = account.AccountName + " Pledges";

					shadingIndex = 0;

					row = table.AddRow().MergeFirstCells().StyleAmount().Stripe();
					row.Cells[1].Range.Text = "Starting Balance (as of " + info.StartDate.ToShortDateString() + "):";
					row.Cells[2].Range.Text = account.OutstandingBalance.ToString("c", Culture);

					foreach (var pledge in account.Pledges) {
						row = table.AddRow().StyleAmount().Stripe();
						row.Cells[1].Range.Text = pledge.Date.ToShortDateString();
						row.Cells[2].Range.Text = pledge.Type + (String.IsNullOrEmpty(pledge.SubType) ? "" : ", " + pledge.SubType);
						if (!String.IsNullOrEmpty(pledge.Note)) {
							range = row.Cells[2].Range;
							range.Start = range.End - 1;

							range.Text = Environment.NewLine + pledge.Note;
							range.Font.Italic = 1;
						}
						row.Cells[3].Range.Text = pledge.Amount.ToString("c", Culture);
					}

					row = table.AddRow().MergeFirstCells().StyleAmount().StyleTotal();
					row.Cells[1].Range.Text = "Total:";
					row.Cells[2].Range.Text = account.TotalPledged.ToString("c", Culture);
				}

				row = table.AddRow().MakeHeader();
				row.Range.Text = account.AccountName + " Payments";
				if (account.Payments.Count == 0) {
					row = table.AddRow().MergeRow();
					row.Range.Text = "You have no " + account.AccountName.ToLower(Culture) + " payments\von record after " + info.StartDate.ToLongDateString();
				}

				shadingIndex = 0;
				foreach (var payment in account.Payments) {
					row = table.AddRow().StyleAmount().Stripe();
					row.Cells[1].Range.Text = payment.Date.ToShortDateString();
					row.Cells[2].Range.Text = payment.MethodDescription;
					row.Cells[3].Range.Text = payment.Amount.ToString("c", Culture);
				}

				if (account.TotalPaid != 0) {
					row = table.AddRow().MergeFirstCells().StyleAmount().StyleTotal();
					row.Cells[1].Range.Text = "Total:";
					row.Cells[2].Range.Text = account.TotalPaid.ToString("c", Culture);
				}
			}
			if (info.Kind == StatementKind.Bill) {
				row = table.AddRow().MergeFirstCells().StyleAmount();
				row.Range.ParagraphFormat.SpaceBefore = 10;
				row.Cells[1].Range.Text = "Total Pledged:";
				row.Cells[2].Range.Text = info.TotalPledged.ToString("c", Culture);

				row = table.AddRow().MergeFirstCells().StyleAmount();
				row.Cells[1].Range.Text = "Total Paid:";
				row.Cells[2].Range.Text = "-" + info.TotalPaid.ToString("c", Culture);

				row = table.AddRow().MergeFirstCells().StyleAmount().StyleTotal();
				row.Cells[1].Range.Text = "Balance due:";
				row.Cells[2].Range.Text = info.Person.Field<decimal>("BalanceDue").ToString("c", Culture);
				row.Cells[2].Range.Font.Bold = 1;
			}
			table.Rows[table.Rows.Count].Delete();
			table.Rows[table.Rows.Count].Delete();
			table.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);
		}

		[ThreadStatic]
		static int shadingIndex;

		static Color? ParseColor(string xmlValue) =>
			xmlValue == null ? new Color?() : Color.FromArgb(int.Parse(xmlValue.TrimStart('#'), NumberStyles.AllowHexSpecifier));
		static readonly Color? stripeColor = ParseColor(Config.GetElement("Billing").Element("Statements")?.Attribute("StripeColor").Value);
		static Row Stripe(this Row row) {
			shadingIndex++;
			if (shadingIndex % 2 == 0)
				row.Shading.BackgroundPatternColor = stripeColor?.ToWdColor() ?? (WdColor)(-553582797);
			return row;
		}

		///<summary>Adds a row to a table, returning the third-to-last row.</summary>
		///<returns>Two rows before the one that was just added.</returns>
		///<remarks>This prevents unwanted formatting and bottom borders from copying downwards.</remarks>
		static Row AddRow(this Table table) {
			table.Rows.Add();
			return table.Rows[table.Rows.Count - 2];
		}

		///<summary>Merges the first two cells of a row.</summary>
		static Row MergeFirstCells(this Row row) {
			row.Cells[1].Merge(row.Cells[2]);
			return row;
		}

		///<summary>Merges the cells of a row.</summary>
		static Row MergeRow(this Row row) {
			row.Cells.Merge();
			row.Shading.BackgroundPatternColor = WdColor.wdColorWhite;
			row.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
			return row;
		}
		///<summary>Formats a row as a header row and merges the row's cells.</summary>
		///<param name="row">The row to format.</param>
		///<param name="level">If 0, no formatting will be applied.  Otherwise, the size will ramp up.</param>
		static Row MakeHeader(this Row row) {
			row.MergeRow();

			row.Range.Font.Color = (WdColor)(-553582593);
			row.Range.Font.Bold = 1;
			row.Range.Font.Size += 2;

			if (row.Index > 1)
				row.Range.ParagraphFormat.SpaceBefore = 7;

			var border = row.Borders[WdBorderType.wdBorderBottom];
			border.Visible = true;
			border.LineWidth = WdLineWidth.wdLineWidth150pt;

			return row;
		}
		static Row StyleTotal(this Row row) {
			row.Cells[row.Cells.Count].Range.Font.Bold = 1;
			row.Range.ParagraphFormat.SpaceBefore = 6;

			var border = row.Borders[WdBorderType.wdBorderBottom];
			border.Visible = true;
			border.LineWidth = WdLineWidth.wdLineWidth150pt;

			border = row.Borders[WdBorderType.wdBorderTop];
			border.Visible = true;
			border.LineWidth = WdLineWidth.wdLineWidth050pt;

			return row;
		}
		static Row StyleAmount(this Row row) {
			row.Cells[row.Cells.Count].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
			return row;
		}
		#endregion
	}
}