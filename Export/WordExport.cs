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

			progress = progress ?? new EmptyProgressReporter();

			progress.Caption = "Creating " + kinds.Join(" and ", k => k.ToString() + "s");

			var sourceDocs = new List<Document>(kinds.Length);
			Dictionary<BillKind, Range> sourceRanges = new Dictionary<BillKind, Range>();
			try {
				Word.ScreenUpdating = false;
				foreach (var kind in kinds) {
					var sd = Word.Documents.Open(new DocumentsOpenArgs { FileName = Path.Combine(TemplateFolder, kind.ToString() + ".docx"), ReadOnly = true, Visible = false, AddToRecentFiles = false });
					sourceRanges.Add(kind, sd.Range());
				}

				Document doc = Word.Documents.Add();
				Range range = doc.Range();

				using (new ClipboardScope()) {
					progress.Maximum = people.Count;
					int i = 0;
					foreach (var person in people) {
						progress.Progress = i;

						foreach (var kind in kinds) {
							var info = new BillInfo(person, startDate, kind);
							if (!info.ShouldSend) continue;

							sourceRanges[kind].Copy();
							range.Paste();
							FillBill(range, info);
							range.Collapse(WdCollapseDirection.wdCollapseEnd);
						}

						i++;
					}
				}
				doc.Activate();
				return doc;
			} finally {
				foreach (_Document sd in sourceDocs) sd.Close(ref dontSave, ref Missing, ref Missing);
				Word.ScreenUpdating = true;
			}
		}

		static readonly Dictionary<string, Action<Range, BillInfo>> CustomFields = new Dictionary<string, Action<Range, BillInfo>>(StringComparer.CurrentCultureIgnoreCase){
			{ "Year",			(range, info) => range.Text = info.StartDate.Year.ToString(CultureInfo.CurrentCulture) },
			{ "StartDate",		(range, info) => range.Text = info.StartDate.ToShortDateString() },
			{ "MailingAddress",	(range, info) => range.Text = info.Person.MailingAddress },
			{ "contributions",	(range, info) => range.Text = info.Accounts.Sum(a => a.Payments.Count) == 1 ? "contribution" : "contributions" },
			{ "Table",			 CreateTable },
		};

		static void FillBill(Range range, BillInfo info) {
			for (int i = range.ContentControls.Count; i > 0; i--) {
				var cc = range.ContentControls.Item(i);
				var targetRange = cc.Range;

				var fieldName = targetRange.Text;

				Action<Range, BillInfo> customField;

				if (!CustomFields.TryGetValue(fieldName, out customField)
				 && !Program.Data.MasterDirectory.Columns.Contains(fieldName))
					throw new InvalidDataException("Unknown ContentControl: " + fieldName);
				cc.Delete(false);
				if (customField != null)
					customField(range, info);
				else
					targetRange.Text = info.Person[fieldName].ToString();
			}
		}

		static readonly CultureInfo Culture = CultureInfo.CurrentCulture;
		//Receipts are the same as bills except that they don't have
		//Balance Due, the Pledges section, and the Payments header.
		static void CreateTable(Range parentRange, BillInfo info) {
			var table = parentRange.Tables.Add(parentRange, 0, 3);

			Range range;
			Row row;
			foreach (var account in info.Accounts) {
				row = table.Rows.Add().MakeHeader(2);
				row.Range.Text = account.AccountName;

				if (info.Kind == BillKind.Bill) {
					row = table.Rows.Add().MergeFirstCells();
					row.Cells[1].Range.Text = "Balance Due:";
					row.Cells[2].Range.Text = account.BalanceDue.ToString("c", Culture);

					row = table.Rows.Add().MakeHeader(1);
					row.Range.Text = "Pledges";

					if (account.OutstandingBalance != 0) {
						row = table.Rows.Add().MergeFirstCells().StyleAmount();
						row.Cells[1].Range.Text = "Starting Balance:";
						row.Cells[2].Range.Text = account.OutstandingBalance.ToString("c", Culture);
					}

					foreach (var pledge in account.Pledges) {
						row = table.Rows.Add().StyleAmount();
						row.Cells[1].Range.Text = pledge.Date.ToShortDateString();
						row.Cells[2].Range.Text = pledge.Type + (String.IsNullOrEmpty(pledge.SubType) ? "" : ", " + pledge.SubType);
						if (!String.IsNullOrEmpty(pledge.Note)) {
							range = row.Cells[2].Range;
							range.Collapse(WdCollapseDirection.wdCollapseEnd);
							range.Font.Italic = 1;
							range.Text = Environment.NewLine + pledge.Note;
						}
						row.Cells[3].Range.Text = pledge.Amount.ToString("c", Culture);
					}

					row = table.Rows.Add().MergeFirstCells().StyleAmount();
					row.Cells[1].Range.Text = "Total:";
					row.Cells[2].Range.Text = (account.OutstandingBalance + account.Pledges.Sum(p => p.Amount)).ToString("c", Culture);

					row = table.Rows.Add().MakeHeader(1);
					row.Range.Text = "Payments";
					if (account.Payments.Count == 0) {
						row = table.Rows.Add().MakeHeader(0);
						row.Range.Text = "You have no " + account.AccountName.ToLower(Culture) + " payments on record after " + info.StartDate.ToLongDateString();
					}
				}

				foreach (var payment in account.Payments) {
					row = table.Rows.Add().StyleAmount();
					row.Cells[1].Range.Text = payment.Date.ToShortDateString();
					row.Cells[2].Range.Text = payment.Method + (payment.IsCheckNumberNull() ? "" : " #" + payment.CheckNumber.ToString(Culture));
					row.Cells[3].Range.Text = payment.Amount.ToString("c", Culture);
				}

				row = table.Rows.Add().MergeFirstCells().StyleAmount();
				row.Cells[1].Range.Text = "Total:";
				row.Cells[2].Range.Text = (account.Payments.Sum(p => p.Amount)).ToString("c", Culture);
			}
		}
		static object One = 1, Cells = WdUnits.wdCell;
		///<summary>Merges the first two cells of a row.</summary>
		static Row MergeFirstCells(this Row row) {
			var range = row.Cells[1].Range;
			range.MoveEnd(ref Cells, ref One);
			range.Cells.Merge();
			return row;
		}
		///<summary>Formats a row as a header row and merges the row's cells.</summary>
		///<param name="row">The row to format.</param>
		///<param name="level">If 0, no formatting will be applied.  Otherwise, the size will ramp up.</param>
		static Row MakeHeader(this Row row, int level) {
			row.Cells.Merge();
			row.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
			row.Range.Font.Bold = Math.Sign(level);
			row.Range.Font.Size += level * 2;
			return row;
		}
		static Row StyleAmount(this Row row) {
			row.Cells[row.Cells.Count].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
			return row;
		}
	}
}
