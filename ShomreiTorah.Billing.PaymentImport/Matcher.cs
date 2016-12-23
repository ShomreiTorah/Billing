using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NinjaNye.SearchExtensions;
using NinjaNye.SearchExtensions.Levenshtein;
using ShomreiTorah.Common;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI;

namespace ShomreiTorah.Billing.PaymentImport {
	public static class Matcher {
		static IEnumerable<Person> ByImportedPayments(IImportingPerson source) {
			if (string.IsNullOrEmpty(source.FinalFour))
				return Enumerable.Empty<Person>();
			return AppFramework.Table<Payment>().Rows
						  .Where(p => p.Method == "Credit Card" && p.CheckNumber == source.FinalFour)
						  .Select(p => p.Person)
						  .Where(p => GetMatchScore(source, p) == 0);
		}

		static IEnumerable<Person> ByEmail(IImportingPerson source) {
			if (string.IsNullOrEmpty(source.Email))
				yield break;
			var email = AppFramework.Table<EmailAddress>().Rows
				.FirstOrDefault(e => e.Email.Equals(source.Email, StringComparison.OrdinalIgnoreCase));
			if (email != null)
				yield return email.Person;
		}

		static IEnumerable<Person> ByPhone(IImportingPerson source) {
			var phone = source.Phone.FormatPhoneNumber();
			if (string.IsNullOrEmpty(phone))
				yield break;
			var match = AppFramework.Table<Person>().Rows.FirstOrDefault(p => p.Phone == phone);
			if (match != null && GetMatchScore(source, match) == 0)
				yield return match;
		}

		static IEnumerable<Person> Fuzzy(IImportingPerson source) {
			IEnumerable<Person> candidates = AppFramework.Table<Person>().Rows;

			// Filter by each field, but only if that field has any matches.

			if (!string.IsNullOrEmpty(source.Address)) {
				var sourceAddress = AddressInfo.Parse(source.Address);
				var sourceState = UsStates.Abbreviate(source.State);
				candidates = candidates.Where(p =>
					 IsMatch(p.Zip, source.Zip) && IsMatch(p.State, sourceState)
				  && IsMatch(p.City, source.City) && AddressInfo.Parse(p.Address) == sourceAddress)
					.DefaultIfEmpty(candidates);
			}

			candidates = candidates.Where(p => p.LastName.Equals(source.LastName, StringComparison.CurrentCultureIgnoreCase))
				.DefaultIfEmpty(candidates);

			candidates = candidates.LevenshteinDistanceOf(p => p.LastName).ComparedTo(source.LastName)
				.BestMatches()
				.DefaultIfEmpty(candidates);

			// Match the imported first name against either HisName or HerName.
			if (!string.IsNullOrWhiteSpace(source.FirstName)) {
				candidates = candidates.LevenshteinDistanceOf(p => p.HisName).ComparedTo(source.FirstName)
					.Union(candidates.LevenshteinDistanceOf(p => p.HerName).ComparedTo(source.FirstName))
					.BestMatches()
					.Distinct()
					.DefaultIfEmpty(candidates);
			}

			// If none of the matches found anything, give up.
			if (candidates == AppFramework.Table<Person>().Rows)
				return Enumerable.Empty<Person>();
			return candidates;
		}

		static IEnumerable<T> BestMatches<T>(this IEnumerable<ILevenshteinDistance<T>> results)
			=> results.Where(t => t.Distance <= 3)
					  .GroupBy(t => t.Distance, t => t.Item)
					  .FindMin(g => g.Key)
			?? Enumerable.Empty<T>();

		static bool IsMatch(string a, string b) {
			return string.IsNullOrWhiteSpace(a) || string.IsNullOrWhiteSpace(b)
				|| a.Trim().Equals(b.Trim(), StringComparison.InvariantCultureIgnoreCase);
		}
		static IEnumerable<T> DefaultIfEmpty<T>(this IEnumerable<T> sequence, IEnumerable<T> defaultValue)
			=> sequence.Any() ? sequence : defaultValue;


		static readonly IReadOnlyCollection<Func<IImportingPerson, IEnumerable<Person>>> all = new Func<IImportingPerson, IEnumerable<Person>>[] {
			ByEmail,
			ByImportedPayments,
			ByPhone,
			Fuzzy,
		};

		public static IEnumerable<Person> FindMatches(IImportingPerson source) {
			return all.Select(f => f(source).ToList())
					  .FirstOrDefault(Enumerable.Any)
				   ?? Enumerable.Empty<Person>();
		}

		public static int GetMatchScore(IImportingPerson source, Person match) {
			if (string.IsNullOrWhiteSpace(source.Address))
				return source.LastName.Equals(match.LastName, StringComparison.CurrentCultureIgnoreCase)
					&& source.FirstName.Equals(match.HisName, StringComparison.CurrentCultureIgnoreCase)
					 ? 1 : 2;
			if (!AddressInfo.Parse(source.Address).Equals(AddressInfo.Parse(match.Address))
			 || LevenshteinProcessor.LevenshteinDistance(source.LastName, match.LastName) > 1)
				return 2;
			return 0;
		}

		public static Person FindBestMatch(IImportingPerson source) {
			var matches = FindMatches(source).ToList();
			// If there is exactly one match, ignore the score.
			if (matches.Count < 2)
				return matches.FirstOrDefault();
			return (from match in matches
					let score = GetMatchScore(source, match)
					where score < 2
					orderby score
					select match).FirstOrDefault();
		}
	}

	public interface IImportingPerson {
		string FirstName { get; }
		string LastName { get; }
		string Address { get; }
		string City { get; }
		string State { get; }
		string Zip { get; }
		string Phone { get; }
		string Email { get; }

		///<summary>Gets the last four digits of the person's credit card number, if present.</summary>
		string FinalFour { get; }
	}

	struct AddressInfo {
		public readonly static AddressInfo Invalid = new AddressInfo();

		public string HouseNumber { get; private set; }
		public string StreetName { get; private set; }
		public string Apartment { get; private set; }

		public string Original { get; private set; }

		readonly static Regex houseNumberMatcher = new Regex(@"^([0-9/]+[A-Z]?|[^NESW])$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		readonly static Regex apartmentMatcher = new Regex(@"^[A-Z]{0,2}([0-9/]+[A-Z]?)?$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		static Regex streetCleaner = new Regex(@"[#.,]|(?<=[0-9])FL(O+R)?\b|\b(Ave(nue)?|St(reet)?|R(oa)?d|Pl(ace)?|C(our)?t|Ter(race)?|APT|FL(O+R)?|UNIT)\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		public static AddressInfo Parse(string address) {
			if (String.IsNullOrWhiteSpace(address) || address.Contains("**"))
				return Invalid;

			var split = streetCleaner.Replace(address, "").Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
			if (split.Length == 1)
				return new AddressInfo { StreetName = split[0], Original = address };

			var retVal = new AddressInfo { Original = address };

			var houseCount = split.TakeWhile(s => houseNumberMatcher.IsMatch(s)).Count();
			var apartmentCount = split.Reverse().TakeWhile(s => apartmentMatcher.IsMatch(s)).Count();
			var streetCount = split.Length - houseCount - apartmentCount;

			retVal.HouseNumber = String.Concat(split.Take(houseCount));
			retVal.StreetName = String.Concat(split.Skip(houseCount).Take(streetCount));
			retVal.Apartment = String.Concat(split.Skip(houseCount + streetCount));

			if (retVal.StreetName.Equals("THECIR", StringComparison.OrdinalIgnoreCase))
				retVal.StreetName = "TheCircle";

			return retVal;
		}

		public static bool operator ==(AddressInfo a, AddressInfo b) {
			return String.Equals(a.StreetName, b.StreetName, StringComparison.InvariantCultureIgnoreCase)
				 && String.Equals(a.HouseNumber, b.HouseNumber, StringComparison.InvariantCultureIgnoreCase)
				 && (
					String.Equals(a.Apartment, b.Apartment, StringComparison.InvariantCultureIgnoreCase)
				 || String.IsNullOrWhiteSpace(a.Apartment) || String.IsNullOrWhiteSpace(b.Apartment)
				   );

		}
		public static bool operator !=(AddressInfo a, AddressInfo b) { return !(a == b); }

		public override bool Equals(object obj) {
			if (obj == null || GetType() != obj.GetType()) {
				return false;
			}
			var b = (AddressInfo)obj;
			return String.Equals(StreetName, b.StreetName, StringComparison.OrdinalIgnoreCase)
				 && String.Equals(Apartment, b.Apartment, StringComparison.OrdinalIgnoreCase)
				 && String.Equals(HouseNumber, b.HouseNumber, StringComparison.OrdinalIgnoreCase);
		}

		public override int GetHashCode() {
			return StringComparer.OrdinalIgnoreCase.GetHashCode(HouseNumber ?? "")
				 ^ StringComparer.OrdinalIgnoreCase.GetHashCode(StreetName ?? "")
				 ^ StringComparer.OrdinalIgnoreCase.GetHashCode(Apartment ?? "");
		}
		public override string ToString() { return Original; }
	}
}
