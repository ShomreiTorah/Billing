using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word.Extensions;
using ShomreiTorah.Common;
using System.Runtime.InteropServices;
using ShomreiTorah.WinForms;
using System.IO;
using System.Reflection;
using System.Data;
using System.Globalization;

namespace ShomreiTorah.Billing.Export {
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
				Word.ScreenUpdating = false;
				sourceDoc = Word.Documents.Open(new DocumentsOpenArgs { FileName = templatePath, ReadOnly = true, Visible = false, AddToRecentFiles = false });

				Document doc;
				Range range;

				using (new ClipboardScope()) {
					int pageSize = sourceDoc.ContentControls.Count;
					sourceDoc.Range().Copy();

					doc = Word.Documents.Add();

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
				if (sourceDoc != null) ((_Document)sourceDoc).Close(ref dontSave, ref Missing, ref Missing);
				Word.ScreenUpdating = true;
			}
		}

		public static Document CreateBills(ICollection<BillingData.MasterDirectoryRow> people, BillKind[] kinds, DateTime startDate, IProgressReporter progress) {
			if (people == null) throw new ArgumentNullException("people");
			if (kinds == null) throw new ArgumentNullException("kinds");
			if (kinds.Length == 0) return null;
			kinds = kinds.OrderBy(k => (int)k).ToArray();

			progress = progress ?? new EmptyProgressReporter();

			progress.Caption = "Creating " + kinds.Join(" and ", k => k.ToString() + "s");

			var sourceDocs = new List<Document>(kinds.Length);
			Dictionary<BillKind, Range> sourceRanges = new Dictionary<BillKind, Range>();
			try {
				Word.ScreenUpdating = false;
				foreach (var kind in kinds) {
					var sd = Word.Documents.Open(new DocumentsOpenArgs { FileName = Path.Combine(TemplateFolder, kind.ToString() + ".docx"), ReadOnly = true, Visible = false, AddToRecentFiles = false });
					sourceDocs.Add(sd);
					sourceRanges.Add(kind, sd.Range());
				}

				Document doc = Word.Documents.Add();
				Range range = doc.Range();

				bool firstPage = true;
				using (new ClipboardScope()) {
					progress.Maximum = people.Count;
					int i = 0;
					foreach (var person in people) {
						progress.Progress = i;

						foreach (var kind in kinds) {
							var info = new BillInfo(person, startDate, kind);
							if (!info.ShouldSend) continue;

							range.Collapse(WdCollapseDirection.wdCollapseEnd);
							if (firstPage)
								firstPage = false;
							else
								range.InsertBreak(WdBreakType.wdPageBreak);

							sourceRanges[kind].Copy();
							range.Paste();
							FillBill(range, info);
							foreach (Shape shape in range.ShapeRange) {
								FillBill(shape.TextFrame.TextRange, info);
							}
						}

						i++;
					}
				}
				Word.Activate();
				doc.Activate();
				return doc;
			} finally {
				foreach (_Document sd in sourceDocs) sd.Close(ref dontSave, ref Missing, ref Missing);
				Word.ScreenUpdating = true;
			}
		}

		static readonly Dictionary<string, Action<Range, BillInfo>> CustomFields = new Dictionary<string, Action<Range, BillInfo>>(StringComparer.CurrentCultureIgnoreCase){
			{ "BalanceDue",		(range, info) => range.Text = info.Person.BalanceDue.ToString("c", Culture) },
			{ "Year",			(range, info) => range.Text = info.StartDate.Year.ToString(CultureInfo.CurrentCulture) },
			{ "StartDate",		(range, info) => range.Text = info.StartDate.ToShortDateString() },
			{ "MailingAddress",	(range, info) => range.Text = info.Person.MailingAddress },
			{ "Deductibility",	(range, info) => range.Text = info.Deductibility },
			{ "contributions",	(range, info) => range.Text = info.Accounts.Sum(a => a.Payments.Count) == 1 ? "contribution" : "contributions" },
			{ "Table",			 CreateTable },
			{ "PayTo",			 InsertPayTo },
		};
		static void InsertPayTo(Range range, BillInfo info) {
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

		static void FillBill(Range range, BillInfo info) {
			while (range.ContentControls.Count > 0) {
				var cc = range.ContentControls.Item(1);	//I remove them as we go along
				var targetRange = cc.Range;

				var fieldName = targetRange.Text;

				Action<Range, BillInfo> customField;

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
		static void CreateTable(Range targetRange, BillInfo info) {
			var table = targetRange.Tables.Add(targetRange, 2, 3);

			table.Rows.Alignment = WdRowAlignment.wdAlignRowCenter;
			table.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
			table.Range.ParagraphFormat.SpaceAfter = 0;
			table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
			Range range;
			Row row;
			foreach (var account in info.Accounts) {
				if (info.Kind == BillKind.Bill) {
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
					row.Range.Text = "You have no " + account.AccountName.ToLower(Culture) + " payments on record after " + info.StartDate.ToLongDateString();
				}

				shadingIndex = 0;
				foreach (var payment in account.Payments) {
					row = table.AddRow().StyleAmount().Stripe();
					row.Cells[1].Range.Text = payment.Date.ToShortDateString();
					row.Cells[2].Range.Text = payment.Method + (payment.IsCheckNumberNull() ? "" : " #" + payment.CheckNumber.ToString(Culture));
					row.Cells[3].Range.Text = payment.Amount.ToString("c", Culture);
				}

				if (account.TotalPaid != 0) {
					row = table.AddRow().MergeFirstCells().StyleAmount().StyleTotal();
					row.Cells[1].Range.Text = "Total:";
					row.Cells[2].Range.Text = account.TotalPaid.ToString("c", Culture);
				}
			}
			if (info.Kind == BillKind.Bill) {
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

			row.Range.ParagraphFormat.SpaceBefore = 10;

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
}
