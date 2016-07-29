using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NinjaNye.SearchExtensions;
using NinjaNye.SearchExtensions.Levenshtein;
using ShomreiTorah.Data;

namespace ShomreiTorah.Billing.PaymentImport {
	static class Matcher {
		static IEnumerable<Person> ByEmail(PaymentInfo source) {
			var email = Program.Table<EmailAddress>().Rows
				.FirstOrDefault(e => e.Email.Equals(source.Email, StringComparison.OrdinalIgnoreCase));
			if (email != null)
				yield return email.Person;
		}

		static IEnumerable<Person> ByPhone(PaymentInfo source) {
			var phone = source.Phone.FormatPhoneNumber();
			return Program.Table<Person>().Rows.Where(p => p.Phone == phone);
		}

		static IEnumerable<Person> Fuzzy(PaymentInfo source) {
			IEnumerable<Person> candidates = Program.Table<Person>().Rows;

			// Filter by each field, but only if that field has any matches.

			var sourceAddress = AddressInfo.Parse(source.Address);
			candidates = candidates.Where(p =>
				 IsMatch(p.Zip, source.Zip) && IsMatch(p.State, source.State)
			  && IsMatch(p.City, source.City) && AddressInfo.Parse(p.Address) == sourceAddress)
				.DefaultIfEmpty(candidates);

			candidates = candidates.LevenshteinDistanceOf(p => p.LastName).ComparedTo(source.LastName)
				.BestMatches()
				.DefaultIfEmpty(candidates);

			// Match the imported first name against either HisName or HerName.
			candidates = candidates.LevenshteinDistanceOf(p => p.HisName).ComparedTo(source.FirstName)
				.Union(candidates.LevenshteinDistanceOf(p => p.HerName).ComparedTo(source.FirstName))
				.BestMatches()
				.DefaultIfEmpty(candidates);

			// If none of the matches found anything, give up.
			if (candidates == Program.Table<Person>().Rows)
				return Enumerable.Empty<Person>();
			return candidates;
		}

		static IEnumerable<T> BestMatches<T>(this IEnumerable<ILevenshteinDistance<T>> results)
			=> results.Where(t => t.Distance <= 3).OrderByDescending(t => t.Distance).Select(t => t.Item);

		static bool IsMatch(string a, string b) {
			return string.IsNullOrWhiteSpace(a) || string.IsNullOrWhiteSpace(b)
				|| a.Trim().Equals(b.Trim(), StringComparison.InvariantCultureIgnoreCase);
		}
		static IEnumerable<T> DefaultIfEmpty<T>(this IEnumerable<T> sequence, IEnumerable<T> defaultValue)
			=> sequence.Any() ? sequence : defaultValue;


		static readonly IReadOnlyCollection<Func<PaymentInfo, IEnumerable<Person>>> all = new Func<PaymentInfo, IEnumerable<Person>>[] {
			ByEmail,
			ByPhone,
			Fuzzy,
		};

		internal static IEnumerable<Person> FindMatches(PaymentInfo source) {
			return all.Select(f => f(source).ToList())
					  .FirstOrDefault(Enumerable.Any);
		}
	}

	struct AddressInfo {
		public readonly static AddressInfo Invalid = new AddressInfo();

		public string HouseNumber { get; private set; }
		public string StreetName { get; private set; }
		public string Apartment { get; private set; }

		public string Original { get; private set; }

		readonly static Regex houseNumberMatcher = new Regex(@"^([0-9/]+[A-Z]?|[^NESW])$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		readonly static Regex apartmentMatcher = new Regex(@"^[A-Z]{0,2}([0-9/]+[A-Z]?)?$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		static Regex streetCleaner = new Regex(@"[#.]|(?<=[0-9])FL(O+R)?\b|\b(Ave(nue)?|St(reet)?|R(oa)?d|Pl(ace)?|C(our)?t|Ter(race)?|APT|FL(O+R)?|UNIT)\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
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
