using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word.Extensions;
using ShomreiTorah.Common;
using ShomreiTorah.WinForms;

namespace ShomreiTorah.Billing.Statements.Word {
	static class StatementGenerator {
		static Application Word { get { return Office<ApplicationClass>.App; } }

		public static Document CreateBills(ICollection<WordStatementInfo> statements, IProgressReporter progress) {
			if (statements == null) throw new ArgumentNullException("statements");

			progress = progress ?? new EmptyProgressReporter();

			progress.Caption = "Creating document";

			Dictionary<StatementKind, Range> sourceRanges = new Dictionary<StatementKind, Range>();
			try {
				foreach (var kind in statements.Select(s => s.Kind).Distinct()) {
					var sd = Word.Documents.Open(new DocumentsOpenArgs {
						FileName = Path.Combine(WordExport.TemplateFolder, kind.ToString() + ".docx"),
						ReadOnly = true,
						//Visible = false,
						AddToRecentFiles = false
					});
					sourceRanges.Add(kind, sd.Range());
				}

				Document doc = Word.Documents.Add();
				doc.ShowGrammaticalErrors = doc.ShowSpellingErrors = false;
				Range range = doc.Range();

				bool firstPage = true;
				using (new ClipboardScope()) {
					var populator = new StatementPopulator();

					progress.Maximum = statements.Count;
					int i = 0;
					foreach (var info in statements) {
						if (progress.WasCanceled) return null;
						progress.Progress = i;

						progress.Caption = "Creating " + info.Kind.ToString().ToLower(Culture) + " for " + info.Person.VeryFullName;

						if (firstPage)
							firstPage = false;
						else
							range.BreakPage();

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
		///<summary>Appends a page break to a range, replacing any trailing whitespace.</summary>
		static void BreakPage(this Range range) {
			range.Start = range.End - 1;
			while (range.Text.Trim().Length == 0)
				range.Start--;
			range.Start++;
			range.Text = "\f";
			range.Collapse(WdCollapseDirection.wdCollapseEnd);
		}

		class StatementPopulator : DataContentPopulator {
			delegate void CustomField(Range range, StatementInfo info);
			static readonly Dictionary<string, CustomField> CustomFields = new Dictionary<string, CustomField>(StringComparer.CurrentCultureIgnoreCase){
				{ "BalanceDue",		(range, info) => range.Text = info.Person.Field<decimal>("BalanceDue").ToString("c", Culture) },
				{ "Year",			(range, info) => range.Text = info.StartDate.Year.ToString(CultureInfo.CurrentCulture) },
				{ "StartDate",		(range, info) => range.Text = info.StartDate.ToShortDateString() },
				{ "MailingAddress",	(range, info) => range.Text = info.Person.MailingAddress },
				{ "Deductibility",	(range, info) => range.Text = info.Deductibility },
				{ "contributions",	(range, info) => range.Text = info.Accounts.Sum(a => a.Payments.Count) == 1 ? "contribution" : "contributions" },
				{ "Table",			 CreateTable },
				{ "PayTo",			 InsertPayTo },
			};

			public StatementInfo Info { get; private set; }
			public void Populate(Range range, StatementInfo info) { Info = info; base.Populate(range, info.Person); }

			protected override bool PopulateCustomField(Range range, string name) {
				CustomField customField;

				if (!CustomFields.TryGetValue(name, out customField))
					return false;
				customField(range, Info);
				return true;
			}
		}
		static void InsertPayTo(Range range, StatementInfo info) {
			if (info.TotalBalance == 0)
				range.Text = "";
			else {
				range.Text = "Please make your checks payable to ";
				var subRange = range.AppendText("Congregation Shomrei Torah of Passaic-Clifton");
				range.InsertAfter(", and mail your remittance to:");
				range.InsertParagraphAfter();
				subRange.Font.Bold = 1;

				subRange = range.AppendText("Congregation Shomrei Torah of Passaic-Clifton\v1360 Clifton Ave. # 908\vClifton, NJ 07012");
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
					row.Cells[2].Range.Text = payment.Method.Replace("Unknown", "?") 
											+ (payment.CheckNumber == null ? "" : " #" + payment.CheckNumber.ToString(Culture));
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

		static Row Stripe(this Row row) {
			shadingIndex++;
			if (shadingIndex % 2 == 0)
				row.Shading.BackgroundPatternColor = (WdColor)(-553582797);
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
