using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using ShomreiTorah.Common;
using ShomreiTorah.Data;

namespace ShomreiTorah.Billing.Events.MelaveMalka {
	static class ExcelExporter {
		public static void ExportExcel(this IEnumerable<MelaveMalkaInvitation> invites, string path) {
			var file = DB.CreateFile(path);
			using (var connection = file.OpenConnection()) {
				connection.ExecuteNonQuery(@"
CREATE TABLE [Invitations] (
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

				foreach (var invite in invites.OrderBy(s => s.Person.LastName)) {
					var person = invite.Person;
					connection.ExecuteNonQuery(
						@"INSERT INTO [Invitations]
		([Last Name],	[His Name],	[Her Name],	[Full Name],	[Address],	[City],	[State],	[Zip], 	[Phone],	[Source])
VALUES	(@LastName,		@HisName,	@HerName,	@FullName,		@Address,	@City,	@State,		@Zip,	@Phone,		@Source);",
		new { person.LastName, person.HisName, person.HerName, person.FullName, person.Address, person.City, person.State, person.Zip, person.Phone, invite.Source }
	);
				}
			}
		}

		#region Call List
		public static void CreateGlobalCallList(int year, string path) {
			var file = DB.CreateFile(path);
			using (var connection = file.OpenConnection()) {
				CreateCallListSheet(
					connection,
					"All Callees",
					Program.Table<MelaveMalkaInvitation>().Rows.Where(i => i.Year == year && i.ShouldCall && i.AdAmount == 0)
				);
			}
		}
		public static void CreateCallList(this Caller caller, string path) {
			var file = DB.CreateFile(path);
			using (var connection = file.OpenConnection()) {
				CreateCallListSheet(
					connection,
					"Your callees",
					caller.Callees.Where(i => i.AdAmount == 0)
				);
				CreateCallListSheet(
					connection,
					"All Callees",
					Program.Table<MelaveMalkaInvitation>().Rows.Where(i => i.Year == caller.Year && i.ShouldCall && i.AdAmount == 0)
				);
			}
		}

		static void CreateCallListSheet(DbConnection connection, string sheetName, IEnumerable<MelaveMalkaInvitation> callees) {
			Program.LoadTable<MelaveMalkaSeat>();
			connection.ExecuteNonQuery(@"
CREATE TABLE [" + sheetName + @"] (
	[Last Name]	NVARCHAR(128),
	[His Name]	NVARCHAR(128),
	[Her Name]	NVARCHAR(128),
	[Address]	NVARCHAR(128),
	[Phone]		NVARCHAR(128),
	[Caller]	NVARCHAR(128),
	[Last Year]	NVARCHAR(64),
	[Seats]		NVARCHAR(64)
);");

			foreach (var callee in callees.OrderBy(s => s.Person.LastName)) {
				var person = callee.Person;
				connection.ExecuteNonQuery(
					@"INSERT INTO [" + sheetName + @"]
		([Last Name],	[His Name],	[Her Name],	[Address],	[Phone],	[Caller],	[Last Year],	[Seats])
VALUES	(@LastName,		@HisName,	@HerName,	@Address,	@Phone,		@Caller,	@LastAds,		@LastSeats);",
					new {
						person.LastName,
						person.HisName,
						person.HerName,

						person.Address,
						person.Phone,

						Caller = (callee.Caller == null) ? "(none)" : callee.Caller.ToString(),
						LastAds = person.Pledges
										.Where(p => p.ExternalSource == "Journal " + (callee.Year - 1))
										.Select(p => Names.AdTypes.FirstOrDefault(a => a.PledgeSubType == p.SubType))
										.Select(t => t == null ? "(other)" : t.Name)	// Handle custom pledges with unrecognized subtypes
										.DefaultIfEmpty(person.Invitees.Any(i => i.Year == callee.Year - 1) ? "(no ad)" : "(not invited)")
										.Join(", "),

						LastSeats = person.MelaveMalkaSeats
										.Where(s => s.Year == callee.Year - 1)
										.Select(s => "M: " + s.MensSeats + ", " + "W: " + s.WomensSeats)
										.FirstOrDefault() ?? ""
					}
				);
			}
		}
		#endregion
	}
}
