using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShomreiTorah.Data;
using ShomreiTorah.Common;

namespace ShomreiTorah.Billing.Events.MelaveMalka {
	static class ExcelExporter {
		public static void ExportExcel(this IEnumerable<MelaveMalkaInvitation> invites, string path) {
			var file = DB.CreateFile(path);
			using (var connection = file.OpenConnection()) {
				connection.ExecuteNonQuery(@"
CREATE TABLE [SeatingReservations] (
	[Last Name]		NVARCHAR(128),
	[His Name]		NVARCHAR(128),
	[Her Name]		NVARCHAR(128),
	[Full Name]		NVARCHAR(128),
	[Address]		NVARCHAR(128),
	[City]			NVARCHAR(128),
	[State]			NVARCHAR(128),
	[Zip]			NVARCHAR(128),
	[Phone]			NVARCHAR(128),
	[Source]		NVARCHAR(128)
);");

				foreach (var seat in invites.OrderBy(s => s.Person.LastName)) {
					var person = seat.Person;
					connection.ExecuteNonQuery(
						@"INSERT INTO [SeatingReservations]
		([Last Name],	[His Name],	[Her Name],	[Full Name],	[Address],	[City],	[State],	[Zip], 	[Phone],	[Source])
VALUES	(@LastName,		@HisName,	@HerName,	@FullName,		@Address,	@City,	@State,		@Zip,	@Phone,		@Source);",
		new { person.LastName, person.HisName, person.HerName, person.FullName, person.Address, person.City, person.State, person.Zip, person.Phone, seat.Source }
	);
				}
			}
		}

	}
}
