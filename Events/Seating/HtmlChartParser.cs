using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Xml.Linq;
using System.Media;

namespace ShomreiTorah.Billing.Events.Seating {
	static class HtmlChartParser {
		public static ParsedSeatingChart ParseChart(XElement document) {
			return new ParsedSeatingChart(document
				.Descendants()
				.Where(e => ((string)e.Attribute("class") ?? "").Contains("Table"))
				.Select(ParseTable)
			);
		}


		static SeatRow ParseTable(this XElement elem) {
			return new SeatRow(
				elem.Elements("span")
					.Where(s => !string.IsNullOrWhiteSpace((string)s.Attribute("data-person")))
					.Select(ParseSeatGroup).Where(s => s != null)
			);
		}
		static SeatGroup ParseSeatGroup(this XElement cell) {
			return new HtmlSeatGroup(
				(string)cell.Attribute("data-person"),
				(int)cell.Attribute("data-count")
			);
		}

		class HtmlSeatGroup : SeatGroup {
			public HtmlSeatGroup(string name, int seatCount) : base(name, seatCount, seatCount) { }

			public override void Select() { SystemSounds.Beep.Play(); }

			public override bool Matches(Data.Person person) {
				return person.LastName + ", " + person.HisName == Name;
			}
		}
	}
}
