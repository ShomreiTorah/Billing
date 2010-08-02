using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace ShomreiTorah.Billing.Events.Seating {
	///<summary>Holds information parsed from a seating chart.</summary>
	class ParsedSeatingChart {
		public ParsedSeatingChart(IEnumerable<SeatRow> rows) {
			Rows = new ReadOnlyCollection<SeatRow>(rows.ToArray());
		}

		public ReadOnlyCollection<SeatRow> Rows { get; private set; }
	}
	class SeatRow {
		public SeatRow(IEnumerable<SeatGroup> seats) { Seats = new ReadOnlyCollection<SeatGroup>(seats.ToArray()); }
		public ReadOnlyCollection<SeatGroup> Seats { get; private set; }

		public override string ToString() { return "Row - " + Seats.Count + " people; " + Seats.Sum(s => s.SeatCount) + " seats"; }
	}
	class SeatGroup {
		public SeatGroup(string name, int seatCount) {
			Name = name;
			SeatCount = seatCount;
		}

		public string Name { get; private set; }
		public int SeatCount { get; private set; }

		public override string ToString() { return Name + " - " + SeatCount; }
	}
}
