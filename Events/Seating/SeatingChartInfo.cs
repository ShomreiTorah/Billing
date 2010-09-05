using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Data;
using DevExpress.XtraEditors;

namespace ShomreiTorah.Billing.Events.Seating {
	partial class SeatingChartInfo : XtraForm {
		public static void Show(IWin32Window parent, ParsedSeatingChart chart, IEnumerable<BillingData.SeatingReservationsRow> seats) {
			var data =
				//CS means Chart Seat; RS means Reserved Seat.
				new[]{
					//Extra seats
					chart.AllSeats.Where(cs => seats.All( rs => !cs.Matches(rs.Person)))
								  .Select(cs => new { cs.Name, cs.SeatCount, Message = "No matching reservation"}),

					//Seats with wrong widths
					chart.AllSeats.Where(cs => !cs.CheckWidth())
								  .Select(cs => new { cs.Name, cs.SeatCount, Message = "Width is wrong"}),

				}.SelectMany(s => s).ToArray();

			if (!data.Any()) {
				XtraMessageBox.Show("This seating chart has no issues!",
									"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			} else
				new SeatingChartInfo(data).Show(parent);
		}

		private SeatingChartInfo(object dataSource) {
			InitializeComponent();

			grid.DataSource = dataSource;
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
