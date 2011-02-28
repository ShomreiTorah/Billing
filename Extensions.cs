using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ShomreiTorah.Data;
using ShomreiTorah.Singularity;

namespace ShomreiTorah.Billing {
	static class Extensions {
		static readonly Regex phoneParser = new Regex(@"^\(?(\d{3})\)?\s*-?\s*(\d{3})\s*-?\s*(\d{4})$", RegexOptions.Compiled);
		//public static bool IsPhoneNumber(this string value) { return phoneParser.IsMatch(value); }
		public static string FormatPhoneNumber(this string phone) {
			if (phone == null) return null;
			var match = phoneParser.Match(phone);

			if (!match.Success)
				return phone;
			return match.Result("($1) $2 - $3");
		}
		public static bool IsInvalidAddress(this string address) { return String.IsNullOrWhiteSpace(address) || address.Contains("**"); }
		public static int EqualPart(this string str, string substr) {
			int i;
			for (i = 0; i < str.Length
				&& i < substr.Length && Char.ToUpper(str[i], CultureInfo.InvariantCulture) == Char.ToUpper(substr[i], CultureInfo.InvariantCulture);
				i++) {
			}
			return i;
		}

		#region PersonData Operations
		internal static Person AddPerson(this TypedTable<Person> table, PersonData data, string source) {
			var retVal = new Person { Source = source };
			retVal.Set(data);
			table.Rows.Add(retVal);
			return retVal;
		}

		///<summary>Updates the data of a Person row from the given PersonData.</summary>
		///<param name="person">The Person row to update.</param>
		///<param name="newData">The data to set to.  Empty fields are ignored.</param>
		internal static void Update(this Person person, PersonData newData) {
			if (!String.IsNullOrEmpty(newData.FullName)) {
				person.FullName = newData.FullName;
				person.Salutation = newData.FullName.Replace(" " + newData.HisName + " ", " ").Replace(" " + newData.HerName + " ", " ");
			}

			if (!String.IsNullOrEmpty(newData.HisName))
				person.HisName = newData.HisName;
			if (!String.IsNullOrEmpty(newData.HerName))
				person.HerName = newData.HerName;
			if (!String.IsNullOrEmpty(newData.LastName))
				person.LastName = newData.LastName;

			if (!newData.Address.IsInvalidAddress())
				person.Address = newData.Address;
			if (!String.IsNullOrEmpty(newData.City))
				person.City = newData.City;
			if (!String.IsNullOrEmpty(newData.State))
				person.State = newData.State;
			if (!String.IsNullOrEmpty(newData.Zip))
				person.Zip = newData.Zip;

			if (!String.IsNullOrEmpty(newData.Phone))
				person.Phone = newData.Phone;
		}
		///<summary>Sets the data of this row to the given PersonData.</summary>
		///<param name="person">The Person row to update.</param>
		///<param name="data">The data to set to.  Fields that are empty in data will be emptied in the row.</param>
		internal static void Set(this Person person, PersonData data) {
			person.FullName = data.FullName;
			person.Salutation = data.FullName.Replace(" " + data.HisName + " ", " ").Replace(" " + data.HerName + " ", " ");

			person.HisName = data.HisName;
			person.HerName = data.HerName;
			person.LastName = data.LastName;

			person.Address = data.Address;
			person.City = data.City;
			person.State = data.State;
			person.Zip = data.Zip;

			person.Phone = data.Phone;
		}
		#endregion
	}
}
