using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics.CodeAnalysis;
using ShomreiTorah.Data;

namespace ShomreiTorah.Billing.Import {
	class Resolver {
		public Resolver(string source) { Source = source; }

		public string Source { get; private set; }

		///<summary>Gets an AllPeople row from this instance's AllPeopleDataTable for the specified person.</summary>
		///<param name="data">The data about the person.</param>
		///<remarks>This function will attempt to find a person in AllPeople that matches whatever data was provided.  
		///If there are no matches, or if the parameter is empty, the user is prompted to add a new person. 
		///If there are multiple matches, the user is prompted to select the person to update or add a new one.</remarks>
		public ResolvedPerson Resolve(PersonData data) {
			if (data.IsEmpty())
				return null;
			var retVal = new ResolvedPerson(this, data, GetMatches(data));

			if (retVal.Matches.Count == 0) {								//If there aren't any matches,
				retVal.SetAddNew(retVal.Data);

				//using (var form = new Forms.ResolveAdd(retVal))
				//    form.ShowDialog();
				return retVal;
			} else if (retVal.Matches.All(m =>
					(!String.IsNullOrEmpty(m.Zip) && !String.IsNullOrEmpty(data.Zip) && m.Zip != data.Zip)
						//|| (!String.IsNullOrEmpty(m.City) && !String.IsNullOrEmpty(data.City) && m.Zip != data.City)
				 || (!String.IsNullOrEmpty(m.State) && !String.IsNullOrEmpty(data.State) && m.State != data.State)
				)) {
				retVal.SetAddNew(retVal.Data);
				if (String.IsNullOrEmpty(retVal.Data.FullName))
					retVal.ResolvedRow.FullName = retVal.ResolvedRow.VeryFullName;

				//using (var form = new Forms.ResolveAdd(retVal))
				//    form.ShowDialog();
				return retVal;
			} else if (retVal.Matches.Count == 1) {							//If there was exactly one match,
				if (retVal.Data.IsUnequal(retVal.Matches[0])) {				//If the match isn't the same as the data,
					retVal.SetUseExisting(retVal.Matches[0]);				//Use the existing match from AllPeople
				} else {													//If it's a perfect match,
					retVal.SetUpdateExisting(retVal.Matches[0]);			//Use the existing match
					return retVal;											//And return without disambiguation.
				}
			} else {
				//using (var form = new Forms.Disambiguator(retVal)) {
				//    form.Action = ResolveAction.UseExisting;

				//    form.ShowDialog();
				//}
			}
			return retVal;
		}

		public static ReadOnlyCollection<Person> GetMatches(PersonData data) {
			if (data.IsEmpty())
				return EmptyCollection<Person>.Instance;

			if (!String.IsNullOrEmpty(data.FullName)) {
				if (String.IsNullOrEmpty(data.LastName)) {
					var lastNameStart = data.FullName.LastIndexOf(' ');
					if (lastNameStart > 0)
						data.LastName = data.FullName.Substring(lastNameStart);
				}
			}

			var initialMatches = GetInitialMatches(data).ToArray();
			if (!initialMatches.Any())
				return EmptyCollection<Person>.Instance;

			var retVal = FilterName(initialMatches, data).ToArray();
			if (retVal.Length == 0)
				return new ReadOnlyCollection<Person>(initialMatches);
			return new ReadOnlyCollection<Person>(retVal);
		}
		static IEnumerable<Person> FilterName(IEnumerable<Person> initialMatches, PersonData data) {
			if (!initialMatches.Any()) return EmptyCollection<Person>.Instance;
			var fullNameMatches = initialMatches.Where(p =>
				(!String.IsNullOrEmpty(p.HisName) && -1 != data.FullName.IndexOf(p.HisName, StringComparison.OrdinalIgnoreCase))
			 || (!String.IsNullOrEmpty(p.HerName) && -1 != data.FullName.IndexOf(p.HerName, StringComparison.OrdinalIgnoreCase))
			);
			if (fullNameMatches.Any())
				initialMatches = fullNameMatches;

			int bestHisMatch = 0;
			int bestHerMatch = 0;
			if (!String.IsNullOrEmpty(data.HisName))
				bestHisMatch = initialMatches.Max(p => p.HisName.EqualPart(data.HisName));
			if (!String.IsNullOrEmpty(data.HerName))
				bestHerMatch = initialMatches.Max(p => p.HerName.EqualPart(data.HerName));

			return initialMatches.Where(p =>
						  (bestHisMatch == 0 || p.HisName.EqualPart(data.HisName) >= bestHisMatch)
					   && (bestHerMatch == 0 || p.HerName.EqualPart(data.HerName) >= bestHerMatch)
				   );
		}
		static IEnumerable<Person> GetInitialMatches(PersonData data) {
			if (!String.IsNullOrEmpty(data.Phone)) {
				var phoneMatches = Program.Table<Person>().Rows.Where(p => p.Phone == data.Phone).ToArray();
				if (phoneMatches.Length == 1)
					return new ReadOnlyCollection<Person>(phoneMatches);

				if (phoneMatches.Length > 1) {
					var phoneLast = phoneMatches.Where(p => data.LastName.Equals(p.LastName, StringComparison.OrdinalIgnoreCase));
					if (phoneLast.Any())
						return phoneMatches;
				}
			}

			IEnumerable<Person> addressMatches = null;
			var address = AddressInfo.Parse(data.Address);
			if (address != AddressInfo.Invalid) {
				addressMatches = Program.Table<Person>().Rows.Where(p => !String.IsNullOrEmpty(p.Address) && AddressInfo.Parse(p.Address) == address);
				if (addressMatches.Any()) {
					var addrLastMatches = addressMatches.Where(p => data.LastName.Equals(p.LastName, StringComparison.OrdinalIgnoreCase));
					if (addrLastMatches.Any())
						return new ReadOnlyCollection<Person>(addrLastMatches.ToArray());
					return new ReadOnlyCollection<Person>(addressMatches.ToArray());
				}
			}
			//If we've gotten here, both phone and address are either missing or not in AllPeople.
			var retVal = Program.Table<Person>().Rows.Where(p => data.LastName.Equals(p.LastName, StringComparison.OrdinalIgnoreCase));
			if (!FilterName(retVal, data).Any())
				return Enumerable.Empty<Person>();
			return retVal;
		}
	}
	class ResolvedPerson {
		///<summary>Gets the people that match the original data.</summary>
		public ReadOnlyCollection<Person> Matches { get; private set; }
		///<summary>Gets the data to resolve.</summary>
		public PersonData Data { get; set; }
		///<summary>Gets the action to take.</summary>
		public ResolveAction Action { get; protected set; }
		///<summary>Gets the final resolved row</summary>
		public Person ResolvedRow { get; protected set; }

		public Resolver Resolver { get; private set; }

		//public ResolvedPerson(Resolver resolver, PersonData data) : this(resolver, data, new Person[0]) { }
		public ResolvedPerson(Resolver resolver, PersonData data, IList<Person> matches) { Resolver = resolver; Data = data; Matches = new ReadOnlyCollection<Person>(matches); }

		//public void AskUser() { Resolver.Disambiguate(this); }

		//public void SetSkip() { UndoAction(); }
		public void SetAddNew(PersonData newData) {
			UndoAction();
			ResolvedRow = Program.Table<Person>().AddPerson(newData, "Imported from " + Resolver.Source);
			Action = ResolveAction.AddNew;
		}
		public void SetUseExisting(Person row) {
			UndoAction();
			ResolvedRow = row;
			Action = ResolveAction.UseExisting;
		}
		PersonData originalData;
		public void SetUpdateExisting(Person row) {
			if (!Data.IsUnequal(row)) {
				SetUseExisting(row);
				return;
			}
			UndoAction();
			originalData = new PersonData(row);
			row.Update(Data);
			ResolvedRow = row;
			Action = ResolveAction.UpdateExisting;
		}

		public void UndoAction() {
			switch (Action) {
				case ResolveAction.AddNew:
					ResolvedRow.RemoveRow();
					break;
				case ResolveAction.UpdateExisting:
					ResolvedRow.Set(originalData);
					break;
			}
			Action = ResolveAction.Skip;
			ResolvedRow = null;
		}
	}
	enum ResolveAction {
		Skip,
		AddNew,
		UseExisting,
		UpdateExisting
	}

	static class EmptyCollection<T> {

		public static ReadOnlyCollection<T> Instance { get { return instance; } }

		[SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = "Explicit static constructor to tell C# compiler not to mark type as beforefieldinit")]
		static EmptyCollection() { }

		internal static readonly ReadOnlyCollection<T> instance = new ReadOnlyCollection<T>(new T[0]);
	}
	struct AddressInfo {
		public readonly static AddressInfo Invalid = new AddressInfo { HouseNumber = -1, StreetName = "*" };

		public int HouseNumber { get; set; }
		public string StreetName { get; set; }

		static Regex numberExtractor = new Regex("[^0-9]", RegexOptions.Compiled);
		public static AddressInfo Parse(string address) {
			if (String.IsNullOrEmpty(address) || address.IsInvalidAddress()) return Invalid;

			var split = address.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			if (split.Length == 1)
				return new AddressInfo { HouseNumber = -1, StreetName = address };

			var retVal = new AddressInfo();
			int houseNumber;

			if (int.TryParse(numberExtractor.Replace(split[0], ""), out houseNumber))
				retVal.HouseNumber = houseNumber;

			if (split.Length <= 3)
				retVal.StreetName = split[1];
			else
				retVal.StreetName = String.Join("", split, 1, split.Length - 2);

			retVal.StreetName = retVal.StreetName.Replace("-", "");

			return retVal;
		}

		public static bool operator ==(AddressInfo a, AddressInfo b) {
			return (a.HouseNumber < 0
				 || b.HouseNumber < 0
				 || a.HouseNumber == b.HouseNumber)
				 && a.StreetName.Equals(b.StreetName, StringComparison.OrdinalIgnoreCase);
		}
		public static bool operator !=(AddressInfo a, AddressInfo b) { return !(a == b); }

		public override bool Equals(object obj) {
			if (obj == null || GetType() != obj.GetType()) {
				return false;
			}
			return this == (AddressInfo)obj;
		}

		public override int GetHashCode() {
			return HouseNumber.GetHashCode() ^ StringComparer.OrdinalIgnoreCase.GetHashCode(StreetName);
		}
		public override string ToString() { return HouseNumber.ToString(CultureInfo.CurrentCulture) + " " + StreetName; }
	}
}
