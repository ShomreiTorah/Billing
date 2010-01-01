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

namespace ShomreiTorah.Billing.Export {
	static class WordExport {
		static object Missing = Type.Missing;
		static void CloseDoc(this _Document doc) { doc.Close(ref Missing, ref Missing, ref Missing); }

		static readonly string TemplateFolder = Path.Combine(Program.AppDirectory, "Word Templates");
		static Application Word { get { return Office<ApplicationClass>.App; } }

		public static Document CreateMailing(IList<BillingData.MasterDirectoryRow> people, string templateName, IProgressReporter progress) {
			if (people == null) throw new ArgumentNullException("people");
			if (templateName == null) throw new ArgumentNullException("templateName");
			var templatePath = Path.Combine(TemplateFolder, templateName);
			if (!File.Exists(templatePath)) throw new ArgumentException("Template does not exist", "templateName", new FileNotFoundException("Template does not exist", templatePath));

			if (progress != null) progress.Caption = "Creating " + Path.GetFileNameWithoutExtension(templateName);
			try {
				Word.ScreenUpdating = false;
				Document doc;
				Range range;

				#region Create document
				using (new ClipboardScope()) {
					int pageSize;
					var sourceDoc = Word.Documents.Open(new DocumentsOpenArgs { FileName = templatePath, ReadOnly = true, Visible = true, AddToRecentFiles = false });
					try {
						pageSize = sourceDoc.ContentControls.Count;
						sourceDoc.Range().Copy();
					} finally { sourceDoc.CloseDoc(); }

					doc = Word.Documents.Add();

					int pageCount = (int)Math.Ceiling(people.Count / (float)pageSize);
					if (progress != null) progress.Maximum = pageCount;
					range = doc.Range();
					for (int i = 0; i < pageCount; i++) {
						if (progress != null && progress.WasCanceled) return null;
						if (progress != null) progress.Progress = i;
						range.Collapse(WdCollapseDirection.wdCollapseEnd);
						range.Paste();
					}
				}
				#endregion

				var placeholderCount = doc.ContentControls.Count;
				for (int i = 0; i < placeholderCount; i++) {
					if (progress != null && progress.WasCanceled) return null;
					if (progress != null) progress.Progress = i;

					var cc = doc.ContentControls.Item(1);	//I remove them as we go along
					range = cc.Range;
					cc.Delete(false);
					if (i >= people.Count)
						range.Text = "";
					else {
						var person = people[i];
						range.Text = person.FullName + Environment.NewLine + person.Address + Environment.NewLine + person.City + ", " + person.State + "  " + person.Zip;
					}
				}
				return doc;
			} finally { Word.ScreenUpdating = true; }
		}
	}
}
