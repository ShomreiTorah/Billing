using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word.Extensions;
using ShomreiTorah.Data;

namespace ShomreiTorah.Billing.Statements.Word {
	abstract class ContentPopulator {
		protected abstract void Fill(Range range, string name);

		public void Populate(Range range) {
			int i = 0;
			while (range.ContentControls.Count > i) {
				var cc = range.ContentControls.Item(i + 1);	//I remove them as we go along, except where deletion fails.  Item() is one-based.
				var targetRange = cc.Range;

				try {
					cc.Delete(false);
				} catch (COMException) {
					i++;	//Sometimes (in shapes?), the deletion fails.  When that happens, just skip it in the next iteration
				}

				Fill(targetRange, targetRange.Text);
			}
		}
	}

	abstract class DataContentPopulator : ContentPopulator {
		public Person Person { get; private set; }

		protected abstract bool PopulateCustomField(Range range, string name);

		public void Populate(Range range, Person person) { Person = person; base.Populate(range); }
		protected override void Fill(Range range, string name) {
			if (PopulateCustomField(range, name)) return;

			if (!Person.Schema.Columns.Contains(name))
				throw new InvalidDataException("Unknown ContentControl: " + name);

			range.Text = Person[name].ToString();
		}
	}
}