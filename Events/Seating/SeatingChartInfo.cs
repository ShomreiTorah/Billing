using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using ShomreiTorah.Data;

namespace ShomreiTorah.Billing.Events.Seating {
	partial class SeatingChartInfo : XtraForm {
		public static SeatingChartInfo Show(IWin32Window parent, ParsedSeatingChart chart, IEnumerable<SeatingReservation> seats) {
			SeatInfo[] data = CreateDataSource(chart, seats);

			if (!data.Any()) {
				XtraMessageBox.Show("This seating chart has no issues!",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return null;
			} else {
				var form = new SeatingChartInfo(data);
				form.Show(parent);
				return form;
			}
		}

		private static SeatInfo[] CreateDataSource(ParsedSeatingChart chart, IEnumerable<SeatingReservation> seats) {
			//CS means Chart Seat; RS means Reserved Seat.
			var data = new[] {
				//Extra seats
				chart.AllSeats.Where(cs => seats.All(rs => !cs.Matches(rs.Person)))
							  .Select(cs => new SeatInfo(cs, message: "No matching reservation")),

				//Seats with wrong widths
				chart.AllSeats.Where(cs => !cs.CheckWidth())
							  .Select(cs => new SeatInfo(cs, message: "Width is wrong")),

			}.SelectMany(s => s).ToArray();
			return data;
		}
		public void UpdateData(ParsedSeatingChart chart, IEnumerable<SeatingReservation> seats) {
			grid.DataSource = CreateDataSource(chart, seats);
		}

		class SeatInfo {
			readonly SeatGroup seat;

			public SeatInfo(SeatGroup seat, string message) { this.seat = seat; Message = message; }

			[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used with data-binding")]
			public string Name { get { return seat.Name; } }
			[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used with data-binding")]
			public int SeatCount { get { return seat.SeatCount; } }
			[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used with data-binding")]
			public string Message { get; private set; }

			public void Select() { seat.Select(); }
		}

		private SeatingChartInfo(object dataSource) {
			InitializeComponent();

			grid.DataSource = dataSource;
		}

		private void grid_MouseDoubleClick(object sender, MouseEventArgs e) {
			var rowHandle = gridView.CalcHitInfo(e.Location).RowHandle;

			if (rowHandle >= 0) {
				var info = (SeatInfo)gridView.GetRow(rowHandle);
				info.Select();
			}
		}
		private void gridView_CustomColumnSort(object sender, CustomColumnSortEventArgs e) {
			if (e.Column == colName) {
				var name1 = (e.Value1 ?? "").ToString();
				var name2 = (e.Value2 ?? "").ToString();

				if (name1.Length < 3 || name2.Length < 3)
					return;

				e.Result = String.Compare(name1.Substring(2), name2.Substring(2), StringComparison.CurrentCultureIgnoreCase);
				if (e.SortOrder == ColumnSortOrder.Descending)
					e.Result = -e.Result;

				e.Handled = true;
			}
		}
	}
}
