using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI;

namespace ShomreiTorah.Billing.PaymentImport {
	///<summary>Attempts to infer genders for first names, based on existing data.</summary>
	public class Genderizer {
		readonly HashSet<string> femaleNames;

		public Genderizer(IEnumerable<Person> people) {
			femaleNames = new HashSet<string>(
				people.Select(p => p.HerName)
					  .Except(people.Select(p => p.HisName), StringComparer.CurrentCultureIgnoreCase),
				StringComparer.CurrentCultureIgnoreCase);
		}

		public bool IsFemale(string firstName) => femaleNames.Contains(firstName);
		public TPerson SetFirstName<TPerson>(string firstName, TPerson person) where TPerson : IPerson {
			if (IsFemale(firstName))
				person.HerName = firstName;
			else
				person.HisName = firstName;
			return person;
		}

		public static Genderizer Create() => new Genderizer(AppFramework.Table<Person>().Rows);
	}
}
