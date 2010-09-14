using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShomreiTorah.Common;

namespace ShomreiTorah.Billing.Events.Seating {
	static class ExcelExporter {
		public static void ExportSeatingInfo(this IEnumerable<BillingData.SeatingReservationsRow> seats, string path) {
			var file = DB.CreateFile(path);
			using (var connection = file.OpenConnection()) {
				connection.ExecuteNonQuery(@"
CREATE TABLE [WomensSeating] (
	[Last Name]		NVARCHAR(128),
	[His Name]		NVARCHAR(128),
	[Her Name]		NVARCHAR(128),
	[Address]		NVARCHAR(128),
	[Phone]			NVARCHAR(128),

	[Men's Seats]	INT,
	[Boys' Seats]	INT,
	[Women's Seats]	INT,
	[Girls' Seats]	INT,
	[Notes]			LONGTEXT
);");

				foreach (var seat in seats.OrderBy(s => s.Person.LastName)) {
					var person = seat.Person;
					connection.ExecuteNonQuery(
						@"INSERT INTO [WomensSeating]
		([Last Name],	[His Name],	[Her Name],	[Address],	[Phone],	[Men's Seats],	[Boys' Seats], 	[Women's Seats],	[Girls' Seats], [Notes])
VALUES	(@LastName,		@HisName,	@HerName,	@Address,	@Phone,		@MensSeats,		@BoysSeats,		@WomensSeats,		@GirlsSeats,	@Notes);",
		new { person.LastName, person.HisName, person.HerName, person.Address, person.Phone, seat.MensSeats, seat.BoysSeats, seat.WomensSeats, seat.GirlsSeats, seat.Notes }
	);
				}
			}
		}
		public static void ExportWomensSeats(this IEnumerable<BillingData.SeatingReservationsRow> seats, string path) {
			var file = DB.CreateFile(path);
			using (var connection = file.OpenConnection()) {
				connection.ExecuteNonQuery(@"
CREATE TABLE [WomensSeating] (
	[Last Name]		NVARCHAR(128),
	[His Name]		NVARCHAR(128),
	[Her Name]		NVARCHAR(128),
	[Address]		NVARCHAR(128),
	[Phone]			NVARCHAR(128),

	[Women's Seats]			INT,
	[Girls' Seats]			INT,
	[Notes]			LONGTEXT
);");

				foreach (var seat in seats.Where(s => s.WomensSeats + s.GirlsSeats > 0).OrderBy(s => s.Person.LastName)) {
					var person = seat.Person;
					connection.ExecuteNonQuery(
						@"INSERT INTO [WomensSeating]
		([Last Name],	[His Name],	[Her Name],	[Address],	[Phone],	[Women's Seats],	[Girls' Seats], [Notes])
VALUES	(@LastName,		@HisName,	@HerName,	@Address,	@Phone,		@WomensSeats,		@GirlsSeats,	@Notes);",
		new { person.LastName, person.HisName, person.HerName, person.Address, person.Phone, seat.WomensSeats, seat.GirlsSeats, seat.Notes }
	);
				}
			}
		}
	}
}
