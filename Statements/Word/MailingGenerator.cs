using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word.Extensions;
using ShomreiTorah.Common;
using ShomreiTorah.Data;
using ShomreiTorah.WinForms;

namespace ShomreiTorah.Billing.Statements.Word {
	static partial class MailingGenerator {
		static Application Word { get { return Office<ApplicationClass>.App; } }

		public static Document CreateMailing(ICollection<WordStatementInfo> statements, string templateName, IProgressReporter progress) {
			if (statements == null) throw new ArgumentNullException("statements");
			if (templateName == null) throw new ArgumentNullException("templateName");

			var templatePath = Path.Combine(WordExport.MailingTemplateFolder, templateName);
			if (!File.Exists(templatePath)) throw new ArgumentException("Template does not exist", "templateName", new FileNotFoundException("Template does not exist", templatePath));
			progress = progress ?? new EmptyProgressReporter();

			progress.Caption = "Creating " + Path.GetFileNameWithoutExtension(templateName);

			Document sourceDoc = null;
			try {
				sourceDoc = Word.Documents.Open(FileName: templatePath, ReadOnly: true, AddToRecentFiles: false);

				Document doc = Word.Documents.Add();
				doc.ShowGrammaticalErrors = doc.ShowSpellingErrors = false; ;

				object subjectProp = sourceDoc.BuiltInDocumentProperties.GetType().InvokeMember("Item",
								  BindingFlags.Default | BindingFlags.GetProperty,
								  null,
								  sourceDoc.BuiltInDocumentProperties,
								  new object[] { WdBuiltInProperty.wdPropertySubject },
								  CultureInfo.InvariantCulture);

				var type = (string)subjectProp.GetType().InvokeMember("Value", BindingFlags.Default | BindingFlags.GetProperty, null, subjectProp, new object[0], CultureInfo.InvariantCulture).ToString();

				switch (type.ToUpperInvariant()) {
					case "MASS": CreateMassMailing(statements, sourceDoc, doc, progress); break;
					case "PERSONALIZED": CreatePersonalizedMailing(statements, sourceDoc, doc, progress); break;
					default:
						throw new ArgumentException("Unknown document type: " + type + ".  Please set the Subject field of " + templateName + " to either Mass or Personalized.", "templateName");
				}

				Word.Activate();
				doc.Activate();
				return doc;
			} finally {
				Word.ScreenUpdating = true;
				if (sourceDoc != null) sourceDoc.CloseDoc();
			}
		}

		#region MassMailing
		static void CreateMassMailing(ICollection<WordStatementInfo> statements, Document sourceDoc, Document doc, IProgressReporter progress) {
			using (new ClipboardScope()) {
				sourceDoc.Range().Copy();

				int pageSize = sourceDoc.ContentControls.Count;

				var people = statements.Select(s => s.Person).Distinct().OrderBy(p => p.LastName).ToArray();

				int pageCount = (int)Math.Ceiling(people.Length / (float)pageSize);
				progress.Maximum = pageCount;

				var range = doc.Range();
				for (int i = 0; i < pageCount; i++) {
					if (progress.WasCanceled) return;
					progress.Progress = i;
					range.Collapse(WdCollapseDirection.wdCollapseEnd);
					range.Paste();
				}

				new MassMailingGenerator(people).Populate(doc.Range());
			}
		}
		class MassMailingGenerator : ContentPopulator {
			public MassMailingGenerator(IList<Person> people) { this.people = people; }
			readonly IList<Person> people;
			int index;

			protected override void Fill(Range range, string name) {
				range.Text = index >= people.Count ? "" : people[index].MailingAddress;
				index++;
			}
		}
		#endregion

		#region PersonalizedMailing
		static void CreatePersonalizedMailing(ICollection<WordStatementInfo> statements, Document sourceDoc, Document doc, IProgressReporter progress) {
			using (new ClipboardScope()) {
				var populator = new MailingPopulator();
				sourceDoc.Range().Copy();
				Range range = doc.Range();

				progress.Maximum = statements.Count;
				int i = 0;
				foreach (var person in statements.GroupBy(s => s.Person)) {
					if (progress.WasCanceled) return;
					progress.Progress = i;

					range.Collapse(WdCollapseDirection.wdCollapseEnd);
					range.Paste();

					populator.Populate(range, person);
					foreach (Shape shape in range.ShapeRange)
						populator.Populate(shape.TextFrame.TextRange, person);

					i++;
				}
			}
		}
		class MailingPopulator : DataContentPopulator {
			delegate void CustomField(Range range, Person person, IEnumerable<WordStatementInfo> info);
			static readonly Dictionary<string, CustomField> CustomFields = new Dictionary<string, CustomField>(StringComparer.CurrentCultureIgnoreCase){
				{ "MailingAddress",	(range, person, infos) => range.Text = person.MailingAddress },
				{ "Kinds",			(range, person, infos) => range.Text = infos.Select((s, i) => i == 0 ? s.Kind.ToString() : s.Kind.ToString().ToLower(CultureInfo.CurrentCulture)).Join(" and ").Replace("Bill", "Invoice") },

				{ "Year",			(range, person, infos) => range.Text = infos.Min(s => s.StartDate).Year.ToString(CultureInfo.CurrentCulture) },
				{ "StartDate",		(range, person, infos) => range.Text = infos.Min(s => s.StartDate).ToShortDateString() },
			};

			public IEnumerable<WordStatementInfo> Info { get; private set; }
			public void Populate(Range range, IEnumerable<WordStatementInfo> info) { Info = info; base.Populate(range, info.First().Person); }

			protected override bool PopulateCustomField(Range range, string name) {
				CustomField customField;

				if (!CustomFields.TryGetValue(name, out customField))
					return false;
				customField(range, Person, Info);
				return true;
			}
		}

		#endregion
	}
}
