using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word.Extensions;
using System.IO;

namespace ShomreiTorah.Billing.Statements.Word {
	abstract class ContentPopulator {
		protected abstract void Fill(Range range, string name);

		public void Populate(Range range) {
			while (range.ContentControls.Count > 0) {
				var cc = range.ContentControls.Item(1);	//I remove them as we go along
				var targetRange = cc.Range;

				cc.Delete(false);

				Fill(targetRange, targetRange.Text);
			}
		}
	}

	abstract class DataContentPopulator : ContentPopulator {
		public BillingData.MasterDirectoryRow Person { get; private set; }

		protected abstract bool PopulateCustomField(Range range, string name);

		public void Populate(Range range, BillingData.MasterDirectoryRow person) { Person = person; base.Populate(range); }
		protected override void Fill(Range range, string name) {
			if (PopulateCustomField(range, name)) return;

			if (!Program.Data.MasterDirectory.Columns.Contains(name))
				throw new InvalidDataException("Unknown ContentControl: " + name);

			range.Text = Person[name].ToString();
		}
	}
}
