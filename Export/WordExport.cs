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

namespace ShomreiTorah.Billing.Export {
	static class WordExport {
		static object Missing = Type.Missing;
		static object dontSave = WdSaveOptions.wdDoNotSaveChanges;

		public static readonly string TemplateFolder = Path.Combine(Program.AppDirectory, "Word Templates");
		static Application Word { get { return Office<ApplicationClass>.App; } }

		public static Document DoExport(IList<BillingData.MasterDirectoryRow> people, string templateName, IProgressReporter progress) {
			if (people == null) throw new ArgumentNullException("people");
			if (templateName == null) throw new ArgumentNullException("templateName");
			var templatePath = Path.Combine(TemplateFolder, templateName);
			if (!File.Exists(templatePath)) throw new ArgumentException("Template does not exist", "templateName", new FileNotFoundException("Template does not exist", templatePath));

			if (progress != null) progress.Caption = "Creating " + Path.GetFileNameWithoutExtension(templateName);

			Document sourceDoc = null;
			try {
				Word.ScreenUpdating = false;
				sourceDoc = Word.Documents.Open(new DocumentsOpenArgs { FileName = templatePath, ReadOnly = true, Visible = false, AddToRecentFiles = false });

				object subjectProp = sourceDoc.BuiltInDocumentProperties.GetType().InvokeMember("Item",
						   BindingFlags.Default | BindingFlags.GetProperty, null, sourceDoc.BuiltInDocumentProperties, new object[] { WdBuiltInProperty.wdPropertySubject });
				var type = (string)subjectProp.GetType().InvokeMember("Value", BindingFlags.Default | BindingFlags.GetProperty, null, subjectProp, new object[0]).ToString();

				switch (type.ToUpperInvariant()) {
					case "MAILING": return CreateMailing(people, sourceDoc, progress);
					default:
						throw new ArgumentException("Unknown document type: " + type);
				}
			} finally {
				if (sourceDoc != null) ((_Document)sourceDoc).Close(ref dontSave, ref Missing, ref Missing);
				Word.ScreenUpdating = true;
			}
		}

		static Document CreateMailing(IList<BillingData.MasterDirectoryRow> people, Document sourceDoc, IProgressReporter progress) {
			Document doc;
			Range range;

			using (new ClipboardScope()) {
				int pageSize = sourceDoc.ContentControls.Count;
				sourceDoc.Range().Copy();

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

			doc.Activate();
			return doc;
		}
	}
}
