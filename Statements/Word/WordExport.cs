using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word.Extensions;
using ShomreiTorah.Common;
using ShomreiTorah.WinForms;

namespace ShomreiTorah.Billing.Statements.Word {
	static class WordExport {
		static object Missing = Type.Missing;
		static object dontSave = WdSaveOptions.wdDoNotSaveChanges;

		public static readonly string TemplateFolder = Path.Combine(Program.AppDirectory, "Word Templates");
		public static readonly string MailingTemplateFolder = Path.Combine(TemplateFolder, "Mailings");
		static Application Word { get { return Office<ApplicationClass>.App; } }

		public static Document CreateMailing(IList<BillingData.MasterDirectoryRow> people, string templateName, IProgressReporter progress) {
			if (people == null) throw new ArgumentNullException("people");
			if (templateName == null) throw new ArgumentNullException("templateName");
			var templatePath = Path.Combine(MailingTemplateFolder, templateName);
			if (!File.Exists(templatePath)) throw new ArgumentException("Template does not exist", "templateName", new FileNotFoundException("Template does not exist", templatePath));
			progress = progress ?? new EmptyProgressReporter();

			progress.Caption = "Creating " + Path.GetFileNameWithoutExtension(templateName);

			Document sourceDoc = null;
			try {
				sourceDoc = Word.Documents.Open(new DocumentsOpenArgs { FileName = templatePath, ReadOnly = true, Visible = false, AddToRecentFiles = false });

				Document doc;
				Range range;

				using (new ClipboardScope()) {
					int pageSize = sourceDoc.ContentControls.Count;
					sourceDoc.Range().Copy();

					doc = Word.Documents.Add();
					doc.ShowGrammaticalErrors = doc.ShowSpellingErrors = false;

					int pageCount = (int)Math.Ceiling(people.Count / (float)pageSize);
					progress.Maximum = pageCount;
					range = doc.Range();
					for (int i = 0; i < pageCount; i++) {
						if (progress.WasCanceled) return null;
						progress.Progress = i;
						range.Collapse(WdCollapseDirection.wdCollapseEnd);
						range.Paste();
					}
				}

				var placeholderCount = doc.ContentControls.Count;
				for (int i = 0; i < placeholderCount; i++) {
					if (progress.WasCanceled) return null;
					progress.Progress = i;

					var cc = doc.ContentControls.Item(1);	//I remove them as we go along
					range = cc.Range;
					cc.Delete(false);

					range.Text = i >= people.Count ? "" : people[i].MailingAddress;
				}

				Word.Activate();
				doc.Activate();
				return doc;
			} finally {
				Word.ScreenUpdating = true;
				if (sourceDoc != null) ((_Document)sourceDoc).Close(ref dontSave, ref Missing, ref Missing);
			}
		}

		public static Document CreateBills(ICollection<WordStatementInfo> statements, IProgressReporter progress) {
			if (statements == null) throw new ArgumentNullException("statements");

			progress = progress ?? new EmptyProgressReporter();

			progress.Caption = "Creating document";

			Dictionary<StatementKind, Range> sourceRanges = new Dictionary<StatementKind, Range>();
			try {
				foreach (var kind in statements.Select(s => s.Kind).Distinct()) {
					var sd = Word.Documents.Open(new DocumentsOpenArgs { FileName = Path.Combine(TemplateFolder, kind.ToString() + ".docx"), ReadOnly = true, Visible = false, AddToRecentFiles = false });
					sourceRanges.Add(kind, sd.Range());
				}

				Document doc = Word.Documents.Add();
				doc.ShowGrammaticalErrors = doc.ShowSpellingErrors = false;
				Range range = doc.Range();

				bool firstPage = true;
				using (new ClipboardScope()) {
					progress.Maximum = statements.Count;
					int i = 0;
					foreach (var info in statements) {
						if (progress.WasCanceled) return null;
						progress.Progress = i;

						progress.Caption = "Creating " + info.Kind.ToString().ToLower(Culture) + " for " + info.Person.FullName;

						if (firstPage)
							firstPage = false;
						else {
							range.Start = range.End - 1;
							while (range.Text.Trim().Length == 0)
								range.Start--;
							range.Start++;
							range.Text = "\f";
							range.Collapse(WdCollapseDirection.wdCollapseEnd);
						}
						sourceRanges[info.Kind].Copy();
						range.Paste();

						FillBill(range, info);
						foreach (Shape shape in range.ShapeRange)
							FillBill(shape.TextFrame.TextRange, info);

						i++;
					}
				}
				Word.Activate();
				doc.Activate();
				return doc;
			} finally {
				Word.ScreenUpdating = true;
				foreach (var sd in sourceRanges.Values) sd.Document.CloseDoc();
			}
		}

		static void CloseDoc(this _Document doc) { doc.Close(ref dontSave, ref Missing, ref Missing); }

		static readonly Dictionary<string, Action<Range, StatementInfo>> CustomFields = new Dictionary<string, Action<Range, StatementInfo>>(StringComparer.CurrentCultureIgnoreCase){
			{ "BalanceDue",		(range, info) => range.Text = info.Person.BalanceDue.ToString("c", Culture) },
			{ "Year",			(range, info) => range.Text = info.StartDate.Year.ToString(CultureInfo.CurrentCulture) },
			{ "StartDate",		(range, info) => range.Text = info.StartDate.ToShortDateString() },
			{ "MailingAddress",	(range, info) => range.Text = info.Person.MailingAddress },
			{ "Deductibility",	(range, info) => range.Text = info.Deductibility },
			{ "contributions",	(range, info) => range.Text = info.Accounts.Sum(a => a.Payments.Count) == 1 ? "contribution" : "contributions" },
			{ "Table",			 CreateTable },
			{ "PayTo",			 InsertPayTo },
		};
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
		static Range AppendText(this Range range, string text) {
			range.InsertAfter(text);
			return range.Document.Range(range.End - text.Length, range.End);
		}

		static void FillBill(Range range, StatementInfo info) {
			while (range.ContentControls.Count > 0) {
				var cc = range.ContentControls.Item(1);	//I remove them as we go along
				var targetRange = cc.Range;

				var fieldName = targetRange.Text;

				Action<Range, StatementInfo> customField;

				if (!CustomFields.TryGetValue(fieldName, out customField)
				 && !Program.Data.MasterDirectory.Columns.Contains(fieldName))
					throw new InvalidDataException("Unknown ContentControl: " + fieldName);
				cc.Delete(false);
				if (customField != null)
					customField(targetRange, info);
				else
					targetRange.Text = info.Person[fieldName].ToString();
			}
		}

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
					row.Cells[2].Range.Text = payment.Method.Replace("Unknown", "?") + (payment.IsCheckNumberNull() ? "" : " #" + payment.CheckNumber.ToString(Culture));
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
				row.Cells[2].Range.Text = info.Person.TotalPledged.ToString("c", Culture);

				row = table.AddRow().MergeFirstCells().StyleAmount();
				row.Cells[1].Range.Text = "Total Paid:";
				row.Cells[2].Range.Text = "-" + info.Person.TotalPaid.ToString("c", Culture);

				row = table.AddRow().MergeFirstCells().StyleAmount().StyleTotal();
				row.Cells[1].Range.Text = "Balance due:";
				row.Cells[2].Range.Text = info.Person.BalanceDue.ToString("c", Culture);
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
	}

	//After sending a receipt, we should send the same person
	//another receipt for that year if he gives us more money
	//Therefore, we track when each receipt, and only print a
	//new receipt if a payment was modified after the last 1.
	//In case we need to regenerate a receipt, we can specify
	//a receiptLimit,
	class WordStatementInfo : StatementInfo {
		readonly DateTime receiptLimit;
		public WordStatementInfo(BillingData.MasterDirectoryRow person, DateTime startDate, StatementKind kind, DateTime receiptLimit) : base(person, startDate, kind) { this.receiptLimit = receiptLimit; }

		public override bool ShouldSend {
			get {
				if (!base.ShouldSend)
					return false;
				if (Kind == StatementKind.Receipt) {
					//Find all Word receipts for the year that we're generating.
					var statements = Person.GetStatementLogRows().Where(s => s.StatementKind == "Receipt" && s.Media == "Word" && s.StartDate.Year == StartDate.Year);

					if (!statements.Any()) return true;	//If we didn't make any Word receitps, send.
					var lastStatement = statements.Max(s => s.DateGenerated);

					if (lastStatement >= receiptLimit)
						return true;		//If the last receipt that we generated was after receiptLimit, (re-)send
					if (lastStatement <= Accounts.SelectMany(a => a.Payments).Max(p => p.Modified))
						return true;		//If one of the payments on the receipt was modified after the last receipt, send.

					return false;
				}
				return true;
			}
		}
		public void LogStatement() { base.LogStatement("Word", Kind.ToString()); }
	}
}
