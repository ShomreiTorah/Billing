using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Word;
using ShomreiTorah.Data;
using ShomreiTorah.Statements;

namespace ShomreiTorah.Billing.Statements.Word {
	static class WordExport {
		static object Missing = Type.Missing;
		static object dontSave = WdSaveOptions.wdDoNotSaveChanges;

		public static readonly string TemplateFolder = Path.Combine(Program.TemplatesDirectory, "Word Templates");
		public static readonly string MailingTemplateFolder = Path.Combine(TemplateFolder, "Mailings");

		///<summary>Forces a document to close.</summary>
		///<remarks>This method works around Office issues.</remarks>
		public static void CloseDoc(this _Document doc) {
			try {
				doc.Close(ref dontSave, ref Missing, ref Missing);
				doc.Close(ref Missing, ref Missing, ref Missing);
			} catch (COMException) {
				try {
					doc.Close(ref dontSave, ref Missing, ref Missing);
					doc.Close(ref dontSave, ref Missing, ref Missing);
				} catch (COMException) { }
			}
		}

		internal static Range AppendText(this Range range, string text) {
			range.InsertAfter(text);
			return range.Document.Range(range.End - text.Length, range.End);
		}
		public static WdColor ToWdColor(this Color color) {
			return (WdColor)(color.R + 0x100 * color.G + 0x10000 * color.B);
		}
	}

	//After sending a receipt, we should send the same person
	//another receipt for that year if he gives us more money
	//Therefore, we track when each receipt, and only print a
	//new receipt if a payment was modified after the last 1.
	//In case we need to regenerate a receipt, we can specify
	//a receiptLimit,
	class WordStatementInfo : StatementInfo {
		readonly bool resendExistingReceipts;
		public WordStatementInfo(Person person, DateTime startDate, StatementKind kind, bool resendExistingReceipts) : base(person, startDate, kind) { this.resendExistingReceipts = resendExistingReceipts; }

		public override bool ShouldSend {
			get {

				if (!base.ShouldSend)
					return false;

				if (Kind == StatementKind.Bill && Accounts.All(a => a.BalanceDue == 0))
					return false;

				if (Kind == StatementKind.Receipt) {
					//Find all Word receipts for the year that we're generating.
					var statements = Person.LoggedStatements.Where(s => s.StatementKind == "Receipt" && s.Media == "Word" && s.StartDate.Year == StartDate.Year);

					if (!statements.Any()) return true; //If we didn't make any Word receipts, send.
					var lastStatement = statements.Max(s => s.DateGenerated);

					if (resendExistingReceipts)
						return true;        //If the use wants to resend all receipts, always send.
					if (lastStatement <= Accounts.SelectMany(a => a.Payments).Max(p => p.Modified))
						return true;        //If one of the payments on the receipt was modified after the last receipt, send.

					return false;
				}
				return true;
			}
		}
		public void LogStatement() { base.LogStatement("Word", Kind.ToString()); }
	}
}