using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word.Extensions;
using ShomreiTorah.Common;
using System.Runtime.InteropServices;
using ShomreiTorah.WinForms;

namespace ShomreiTorah.Billing.Export {
	static class WordExport {
		#region Utils
		static object Missing = Type.Missing;
		static void CloseDoc(this _Document doc) { doc.Close(ref Missing, ref Missing, ref Missing); }
		static int CountLabels(Document doc, string labelId, string placeholderText) {
			switch (labelId) {
				case "5160":
				case "8160":
				case "8660":
					return 30;
				case "5167":
				case "8167":
					return 80;
				case "5164":
				case "8164":
					return 6;
				default:
					var range = doc.Tables[0].Range;
					int retVal = 0;
					while (range.Find.Execute(new FindExecuteArgs { FindText = placeholderText }))
						retVal++;
					return retVal;
			}
		}
		#endregion

		static Application Word { get { return Office<ApplicationClass>.App; } }

		public static Document CreateLabels(IList<BillingData.MasterDirectoryRow> people, string labelId, IProgressReporter progress) {
			if (people == null) throw new ArgumentNullException("people");
			if (labelId == null) throw new ArgumentNullException("labelId");


			try {
				object arglabelID = labelId;
				if (progress != null) progress.Caption = "Loading Word";

				Word.ScreenUpdating = false;
				Document tempDoc = null;
				if (Word.Documents.Count == 0)	//The MailingLabel throws an exception if there are no open documents
					tempDoc = Word.Documents.Add(ref Missing, ref Missing, ref Missing, ref Missing);

				if (progress != null) progress.Caption = "Creating labels";
				object placeholderText = "Placeholder";
				Document doc;
				try {
					doc = Word.MailingLabel.CreateNewDocument(ref arglabelID, ref placeholderText, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing);
				} catch (COMException ex) {
					throw new ArgumentException("The label type " + labelId + " does not exist", "labelId", ex);
				}
				if (tempDoc != null) tempDoc.CloseDoc();
				if (progress != null && progress.WasCanceled) return null;

				Range range;
				int labelsPerSheet = CountLabels(doc, labelId, placeholderText.ToString());

				int pages = (int)Math.Ceiling(people.Count / (float)labelsPerSheet);

				if (pages > 1) {
					using (new ClipboardScope()) {
						if (progress != null) progress.Maximum = pages;
						range = doc.Range();

						range.WholeStory();
						range.Copy();
						for (int i = 1; i < pages; i++) {
							if (progress != null) progress.Progress = i;
							if (progress != null && progress.WasCanceled) return null;
							range.EndOf(WdUnits.wdStory, WdMovementType.wdMove);
							range.Paste();
						}
					}
				}
				if (progress != null && progress.WasCanceled) return null;

				range = doc.Range();
				range.WholeStory();

				if (progress != null) progress.Maximum = pages * labelsPerSheet;

				int index = 0;
				while (range.Find.Execute(new FindExecuteArgs { FindText = placeholderText.ToString() })) {
					if (progress != null) progress.Progress = index;
					if (progress != null && progress.WasCanceled) return null;

					if (index >= people.Count) {
						range.Cells[1].Range.Text = "";
						index++;
						continue;
					}

					var person = people[index];
					range.Cells[1].Range.Text = person.FullName + Environment.NewLine + person.Address + Environment.NewLine + person.City + ", " + person.State + "  " + person.Zip;
					index++;
				}
				doc.Activate();
				return doc;
			} finally { Word.ScreenUpdating = true; }
		}
		public static Document CreateEnvelopes(ICollection<BillingData.MasterDirectoryRow> people, IProgressReporter progress) {
			if (people == null) throw new ArgumentNullException("people");

			return null;
		}
	}
}
