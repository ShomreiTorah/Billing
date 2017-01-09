using System;
using System.Collections.Generic;
using System.Composition;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ShomreiTorah.Billing.PaymentImport;
using ShomreiTorah.Common;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI;

namespace ShomreiTorah.Billing.Migrator.Importers {
	[Export(typeof(IImporter))]
	public class QuickBooksImporter : IImporter {
		public String Filter => "Exported Excel Files|*.xlsx|All Files|*.*";

		public String Name => "QuickBooks Exported Transactions";

		///<summary>Detects whether an address line is a continuation of the previous address line.</summary>
		static readonly Regex addressPartDetector = new Regex(@"^(\d+th Floor|Apt\b.*|PO Box\b.*)$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		///<summary>Parses the last line of an address into 'city, state zip'.</summary>
		static readonly Regex addressParser = new Regex(@"^([A-Z .]+)[,<]? ([A-Z.]{2,})(?: (\d+))?(?:-\d{4})?$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

		static void SetAddress(StagedPerson person, string fullAddress, string address1, string address2, ref string company) {
			// If we already parsed an address, skip all of the work.
			// We check this here to make sure the address fields are
			// still added to usedValues to avoid duplicate comments.
			if (person.Address != null)
				return;
			if (fullAddress == null) {
				company = null;
				person.Address = "";
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

		public void Import(string fileName, SynchronizationContext uiThread, IProgressReporter progress) {
			var methodMap = Names.PaymentMethods.ToDictionary(k => k, StringComparer.CurrentCultureIgnoreCase);
			methodMap.Add("American Express", "Credit Card");
			methodMap.Add("MasterCard", "Credit Card");
			methodMap.Add("Visa", "Credit Card");

			progress.Caption = "Reading " + Path.GetFileName(fileName);

			var genderizer = Genderizer.Create();
			var connector = DB.OpenFile(fileName);

			var matchTasks = new LinkedList<Task>();
			progress.Maximum = connector.ExecuteScalar<int>("SELECT COUNT(*) FROM [Sheet1$]");
			using (var reader = connector.ExecuteReader("SELECT * FROM [Sheet1$]")) {
				StagedPerson person = new StagedPerson();
				string company = null;

				// The source file is denormalized, and contains one row per payment,
				// with columns describing the person as part of the payment.  People
				// are separated by rows with values in the second column.
				while (reader.Read()) {
					if (progress.WasCanceled)
						return;
					progress.Progress++;
					// If we're at a boundary between people, skip the row, and start
					// a new person.  The second row in the boundary will noop.
					if (!reader.IsDBNull(1)) {
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
						usedValues[ordinal] = reader[ordinal].ToString();
						return ordinal;
					};

					var fullName = reader.GetNullableString(GetField("Name"));
					if (fullName == null)
						continue;   // Bad data; ignore.
					progress.Caption = "Reading payments for " + fullName;

					int comma = fullName.IndexOf(',');
					if (comma < 0 || fullName.EndsWith(", LLC"))
						person.LastName = person.FullName = fullName;
					else {
						genderizer.SetFirstName(fullName.Substring(comma + 1).Trim(), person);
						person.LastName = fullName.Remove(comma).Trim();
						person.FullName = (person.HisName ?? person.HerName) + " " + person.LastName;
					}
					person.FullName = reader.GetNullableString(GetField("Ship To Address 1")) ?? person.FullName;
					SetAddress(person,
						reader.GetNullableString(GetField("Name Address")),
						reader.GetNullableString(GetField("Name Street1")),
						reader.GetNullableString(GetField("Name Street2")),
						ref company
					);
					// If these values exist discretely in other columns (Ship To),
					// don't include them in Comments.
					usedValues.Add(-1, person.City);
					usedValues.Add(-2, person.State);
					usedValues.Add(-3, person.Zip);

					// Only add the person to the table if we actually have a payment
					// too (as opposed to the second boundary row).
					if (person.Table == null) {
						AppFramework.Table<StagedPerson>().Rows.Add(person);

						// Do the CPU-intensive part on separate threads so it can utilize all cores.
						// But only set the result on the UI thread to avoid threading bugs, both for
						// change events in the grid (after the caller re-enables them) and since the
						// child collection is not thread-safe.
						async void SetPerson(StagedPerson thisPerson)
						{
							Person inferredTarget = await Task.Run(() => Matcher.FindBestMatch(thisPerson));
							if (inferredTarget != null)
								uiThread.Post(_ => thisPerson.Person = inferredTarget, null);
						}
						SetPerson(person);
					}

					// TODO: Warn on bad zip

					GetField("Date"); // Exclude Date from Comments, even if we don't fetch it below.
					StagedPayment payment = new StagedPayment {
						Date = reader.GetNullableDateTime(GetField("Date of Check")) ?? reader.GetDateTime(GetField("Date")),
						Method = reader.GetNullableString(GetField("Pay Meth")) ?? "Donation",
						Amount = (decimal)reader.GetDouble(GetField("Amount")),
						CheckNumber = reader.GetNullableString(GetField("Check #")),
						Account = Names.DefaultAccount,
						ExternalId = reader.GetNullableString(GetField("Num")) ?? Guid.NewGuid().ToString(),
						StagedPerson = person,
						Company = company,
						Comments = Enumerable
							.Range(0, reader.FieldCount)
							.Where(i => !usedValues.ContainsKey(i) && !reader.IsDBNull(i) && !usedValues.ContainsValue(reader[i].ToString()))
							.Select(i => reader.GetName(i) + ": " + reader[i])
							.Join(Environment.NewLine)
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
			if (reader.IsDBNull(ordinal))
				return null;
			if (!DateTime.TryParse(reader.GetString(ordinal), CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces, out var date))
				return null;
			return date;
		}
		public static string GetNullableString(this DbDataReader reader, int ordinal) {
			return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
		}
	}
}
