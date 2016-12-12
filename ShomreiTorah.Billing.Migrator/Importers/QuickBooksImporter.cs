using System;
using System.Collections.Generic;
using System.Composition;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShomreiTorah.Common;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI;

namespace ShomreiTorah.Billing.Migrator.Importers {
	[Export(typeof(IImporter))]
	class QuickBooksImporter : IImporter {
		public String Filter => "Exported Excel Files|*.xlsx|All Files|*.*";

		public String Name => "QuickBooks Exported Transactions";

		public void Import(String fileName) {
			var connector = DB.OpenFile(fileName);
			using (var connection = connector.OpenConnection())
			using (var reader = connector.ExecuteReader("SELECT * FROM [Sheet1$]")) {
				StagedPerson person = new StagedPerson();

				// The source file is denormalized, and contains one row per payment,
				// with columns describing the person as part of the payment.  People
				// are separated by rows with values in the second column.
				while (reader.Read()) {
					// If we're at a boundary between people, skip the row, and start
					// a new person.  The second row in the boundary will noop.
					if (!reader.IsDBNull(2)) {
						person = new StagedPerson();
						continue;
					}

					// Only add the person to the table if we actually have a payment
					// too (as opposed to the second boundary row).
					if (person.Table == null)
						AppFramework.Table<StagedPerson>().Rows.Add(person);

					// Stores columns that have been used for actual properties.  All
					// other non-empty columns will be added to Comments.
					var usedValues = new Dictionary<string, string>();

					// Gets the ordinal of a named column, and suppresses that column
					// from being listed in the Comments field.
					Func<string, int> GetField = (string name) => {
						Int32 ordinal = reader.GetOrdinal(name);
						usedValues[name] = reader.GetNullableString(ordinal);
						return ordinal;
					};

					var fullName = reader.GetString(GetField("Name"));
					var firstName = fullName.Substring(fullName.IndexOf(',')).Trim();
					// TODO: Genderize
					person.LastName = fullName.Remove(fullName.IndexOf(','));
					// TODO: Set address.  If Street1 is a company name, use Street2.

					AppFramework.Table<StagedPayment>().Rows.Add(new StagedPayment {
						Date = reader.GetNullableDateTime(GetField("Date of Check")) ?? reader.GetDateTime(GetField("Date")),
						Method = reader.GetString(GetField("Pay Meth")),  // TODO: Normalize case & card types
						Amount = reader.GetDecimal(GetField("Amount")),
						CheckNumber = reader.GetNullableString(GetField("Check #")),
						Account = Names.DefaultAccount,
						ExternalId = reader.GetString(GetField("Num")),
						StagedPerson = person,
						// TODO: Pull all other non-empty fields into comments.
					});
				}
			}
		}
	}

	static class Extensions {
		public static DateTime? GetNullableDateTime(this DbDataReader reader, int ordinal) {
			return reader.IsDBNull(ordinal) ? new DateTime?() : reader.GetDateTime(ordinal);
		}
		public static string GetNullableString(this DbDataReader reader, int ordinal) {
			return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
		}
	}
}
