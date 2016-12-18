using System;
using System.Collections.Generic;
using System.Composition;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ShomreiTorah.Billing.PaymentImport;
using ShomreiTorah.Common;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI;

namespace ShomreiTorah.Billing.Migrator.Importers {
	[Export(typeof(IImporter))]
	class QuickBooksImporter : IImporter {
		public String Filter => "Exported Excel Files|*.xlsx|All Files|*.*";

		public String Name => "QuickBooks Exported Transactions";

		///<summary>Detects whether an address line is a continuation of the previous address line.</summary>
		static readonly Regex addressPartDetector = new Regex(@"^(\d+th Floor|Apt\b.*|PO Box\b.*)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		///<summary>Parses the last line of an address into 'city, state zip'.</summary>
		static readonly Regex addressParser = new Regex(@"^([A-Z .]+)[,<]? ([A-Z.]{2,})(?: (\d+))?(?:-\d{4})?$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

		static void SetAddress(StagedPerson person, string fullAddress, string address1, string address2, out string company) {
			if (fullAddress == null) {
				company = null;
				return;
			}
			fullAddress = fullAddress.Replace(",", ", ").NormalizeSpaces().Trim();
			address1 = address1?.Trim().NormalizeSpaces();
			address2 = address2?.Trim().NormalizeSpaces();

			if (address2 == null || addressPartDetector.IsMatch(address2 ?? "") || address1.StartsWith("PO Box")) {
				// If the second field is a continuation of the first, combine them.
				person.Address = (address1 + " " + address2).Trim();
				company = null;
			} else {
				// Otherwise, assume it's 'Company Address'.
				if (!char.IsNumber(address2[0]))
					throw new InvalidOperationException($"Weird address for {person.FullName}: '{address1}', '{address2}' ({fullAddress})");
				company = address1;
				person.Address = address2;
			}

			var firstParts = (address1 + " " + address2).Trim();
			if (!fullAddress.StartsWith(firstParts))
				throw new InvalidOperationException($"Unrecognized address format for {person.FullName}: '{fullAddress}' expected to start with '{firstParts}'");
			var parsed = addressParser.Match(fullAddress.Substring(firstParts.Length).Trim());

			person.City = parsed.Groups[1].Value;
			person.State = UsStates.Abbreviate(parsed.Groups[2].Value.Replace(".", ""));
			person.Zip = parsed.Groups[3].Value;
		}

		public void Import(String fileName) {
			var methodMap = Names.PaymentMethods.ToDictionary(k => k, StringComparer.CurrentCultureIgnoreCase);
			methodMap.Add("American Express", "Credit Card");
			methodMap.Add("MasterCard", "Credit Card");
			methodMap.Add("Visa", "Credit Card");

			var genderizer = Genderizer.Create();
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

					// Stores columns that have been used for actual properties.  All
					// other non-empty columns will be added to Comments.
					var usedValues = new Dictionary<int, string>();

					// Gets the ordinal of a named column, and suppresses that column
					// from being listed in the Comments field.
					Func<string, int> GetField = (string name) => {
						Int32 ordinal = reader.GetOrdinal(name);
						usedValues[ordinal] = reader.GetNullableString(ordinal);
						return ordinal;
					};

					string company;
					var fullName = reader.GetString(GetField("Name"));
					genderizer.SetFirstName(fullName.Substring(fullName.IndexOf(',')).Trim(), person);
					person.LastName = fullName.Remove(fullName.IndexOf(','));
					person.FullName = (person.HisName ?? person.HerName) + " " + person.LastName;
					SetAddress(person, reader.GetString(
						GetField("Name Address")), reader.GetString(GetField("Name Street1")),
						reader.GetString(GetField("Name Street2")), out company
					);
					// Only add the person to the table if we actually have a payment
					// too (as opposed to the second boundary row).
					if (person.Table == null) {
						AppFramework.Table<StagedPerson>().Rows.Add(person);
						person.Person = Matcher.FindBestMatch(person);
					}

					// TODO: Warn on bad zip

					StagedPayment payment = new StagedPayment {
						Date = reader.GetNullableDateTime(GetField("Date of Check")) ?? reader.GetDateTime(GetField("Date")),
						Method = reader.GetString(GetField("Pay Meth")),
						Amount = reader.GetDecimal(GetField("Amount")),
						CheckNumber = reader.GetNullableString(GetField("Check #")),
						Account = Names.DefaultAccount,
						ExternalId = reader.GetString(GetField("Num")),
						StagedPerson = person,
						Company = company,
						Comments = Enumerable
							.Range(0, reader.FieldCount)
							.Where(i => !usedValues.ContainsKey(i))
							.Select(i => reader.GetName(i) + ": " + reader.GetString(i))
							.Join("\n")
					};
					payment.Method = methodMap.GetOrNull(payment.Method) ?? payment.Method;
					AppFramework.Table<StagedPayment>().Rows.Add(payment);
				}
			}
		}
	}

	static class Extensions {
		static readonly Regex normalizer = new Regex(@"\s+");

		public static string NormalizeSpaces(this string str) => str == null ? null : normalizer.Replace(str, " ");

		public static DateTime? GetNullableDateTime(this DbDataReader reader, int ordinal) {
			return reader.IsDBNull(ordinal) ? new DateTime?() : reader.GetDateTime(ordinal);
		}
		public static string GetNullableString(this DbDataReader reader, int ordinal) {
			return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
		}
	}
}
