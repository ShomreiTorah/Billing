using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word.Extensions;
using ShomreiTorah.Common;
using ShomreiTorah.WinForms.Forms;
using Microsoft.Win32;

namespace ShomreiTorah.Billing.Events.Purim {
	static class ShalachManosExport {
		static Application Word { get { return Office<ApplicationClass>.App; } }

		static int columnCount = (int)Registry.GetValue(Program.SettingsPath, "ShalachManosColumnCount", 3);
		public static int ColumnCount {
			get { return columnCount; }
			set {
				columnCount = Math.Max(value, 1);
				Registry.SetValue(Program.SettingsPath, "ShalachManosColumnCount", ColumnCount);
			}
		}

		public static Document CreateDocument(int year) {
			return ShalachManosExport.CreateDocument((
						from person in Program.Data.Pledges
						where person.Date.Year == year && person.Type == ShalachManosForm.PledgeType
						select person.MasterDirectoryRow into person
						orderby person.LastName
						select person
					).ToArray());
		}
		public static Document CreateDocument(IList<BillingData.MasterDirectoryRow> people) {
			var document = Word.Documents.Add();

			document.EmbedTrueTypeFonts = true;

			var range = document.Range();
			range.Font.Name = "Centaur Festive MT Italic";
			range.Font.Size = 14;
			range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
			range.PageSetup.LeftMargin = range.PageSetup.RightMargin = 24;
			range.PageSetup.TextColumns.SetCount(ColumnCount);

			var colSize = (int)Math.Ceiling(people.Count / (double)ColumnCount);

			for (int col = 0; col < ColumnCount; col++) {
				range.Text = people.Skip(col * colSize).Take(colSize).Join("\v", p => p.FullName);

				if (col == ColumnCount - 1) break;
				range.Collapse(WdCollapseDirection.wdCollapseEnd);
				range.InsertBreak(WdBreakType.wdColumnBreak);
			}

			document.Activate();
			Word.Activate();
			document.Activate();
			return document;
		}
	}
}
