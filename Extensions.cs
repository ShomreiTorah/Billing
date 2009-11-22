using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
		public static bool IsInvalidAddress(this string address) { return address.Contains("**"); }
	}
}
