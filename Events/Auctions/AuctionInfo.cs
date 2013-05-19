using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using ShomreiTorah.Common.Calendar;
using ShomreiTorah.Common.Calendar.Holidays;
using ShomreiTorah.Data;

namespace ShomreiTorah.Billing.Events.Auctions {
	///<summary>Describes a single auction.</summary>
	class AuctionInfo {
		private AuctionInfo(Holiday holiday) : this(holiday.Date, TimeSpan.Zero, holiday.Name) { }
		//private AuctionInfo(IHebrewEvent date, string name) : this(date, TimeSpan.Zero, name) { }
		private AuctionInfo(IHebrewEvent date, TimeSpan time, string name) {
			Date = date;
			Time = time;
			Name = name;
		}

		///<summary>Gets the time of day for the Date field for this auction.</summary>
		///<remarks>This is used to allow multiple auctions on the same day for יום כיפור and שמחת תורה.</remarks>
		public TimeSpan Time { get; private set; }
		///<summary>Gets the date that this auction takes place.</summary>
		public IHebrewEvent Date { get; private set; }

		///<summary>Gets the auction's display name.</summary>
		public string Name { get; private set; }

		public override string ToString() {
			string retVal = Name;
			if (Date is HebrewDayOfYear) {//None of the other implementations have ToString()s
				retVal += " (" + Date;
				if (Time != TimeSpan.Zero)
					retVal += Time.ToString(@"h\:mm", CultureInfo.CurrentCulture);
				retVal += ")";
			}
			return retVal;
		}


		///<summary>Creates the items in this auction for the given Hebrew year.</summary>
		public IEnumerable<AuctionItem> CreateItems(int hebrewYear, Person person) {
			var date = Date.GetDate(hebrewYear);
			var pledgeDate = date.EnglishDate + Time;
			return CreateItems(date, (itemName, mb) => new AuctionItem(person, pledgeDate, Name, itemName, mb));
		}

		#region Aliyah Lists
		const bool מישברך = true, None = false;
		static readonly string[] AliyahNames = { "כהן", "לוי", "שלישי", "רביעי", "חמישי", "שישי", "שביעי" };
		protected virtual IEnumerable<AuctionItem> CreateItems(HebrewDate date, Func<string, bool, AuctionItem> creator) {
			yield return creator("פתיחה", None);

			for (int a = 0; a < (date.Info.Isשבת ? 7 : 5); a++)
				yield return creator(AliyahNames[a], מישברך);

			yield return creator("מפטיר", מישברך);
			yield return creator("הגבהה", None);
		}

		class YomKippurShacharis : AuctionInfo {
			public YomKippurShacharis() : base(Holiday.יום٠כיפור.Date, new TimeSpan(7, 45, 00), "יום כיפור שחרית") { }
			protected override IEnumerable<AuctionItem> CreateItems(HebrewDate date, Func<string, bool, AuctionItem> creator) {
				yield return creator("פתיחה", None);

				//יום כיפור has 6 עליות on weekdays
				for (int a = 0; a < (date.Info.Isשבת ? 7 : 6); a++)
					yield return creator(AliyahNames[a], מישברך);

				yield return creator("מפטיר", מישברך);
				yield return creator("הגבהה", None);
			}
		}
		class YomKippurMincha : AuctionInfo {
			public YomKippurMincha() : base(Holiday.יום٠כיפור.Date, TimeSpan.FromHours(16), "יום כיפור מנחה") { }
			protected override IEnumerable<AuctionItem> CreateItems(HebrewDate date, Func<string, bool, AuctionItem> creator) {
				yield return creator("פתיחה דנעילה", None);
				yield return creator("פתיחה", None);

				//שלישי is מפטיר יונה
				for (int a = 0; a < 2; a++)
					yield return creator(AliyahNames[a], מישברך);

				yield return creator("מפטיר יונה", מישברך);
				yield return creator("הגבהה", None);
			}
		}
		class ShminiAtzeresShacharis : AuctionInfo {
			public ShminiAtzeresShacharis() : base(Holiday.סוכות[8]) { }
			protected override IEnumerable<AuctionItem> CreateItems(HebrewDate date, Func<string, bool, AuctionItem> creator) {
				foreach (var item in base.CreateItems(date, creator))
					yield return item;
				yield return creator("פתיחה דגשם", None);
			}
		}
		class SimchasTorahMaariv : AuctionInfo {
			public SimchasTorahMaariv() : base(Holiday.סוכות.Days.Last().Date, TimeSpan.FromHours(1), "שמחת תורה מעריב") { }
			protected override IEnumerable<AuctionItem> CreateItems(HebrewDate date, Func<string, bool, AuctionItem> creator) {
				yield return creator("אתה הראית", None);

				for (int a = 0; a < 5; a++)
					yield return creator(AliyahNames[a], מישברך);

				yield return creator("הגבהה", None);
			}
		}
		class SimchasTorahShacharis : AuctionInfo {
			public SimchasTorahShacharis(TimeSpan time, string name) : base(Holiday.סוכות.Days.Last().Date, time, name) { }

			protected override IEnumerable<AuctionItem> CreateItems(HebrewDate date, Func<string, bool, AuctionItem> creator) {
				yield return creator("אתה הראית", None);

				//Apparently, even the early מנין
				//gives everyone עליות. They have
				//fewer people, so it goes faster.
				//Thus, there aren't any auctions 
				//for עליות, and both מנינים use
				//the same auction.

				//for (int a = 0; a < 5; a++)
				//    yield return creator(AliyahNames[a], מישברך);

				yield return creator("כל הנערים", מישברך);
				yield return creator("חתן תורה", מישברך);
				yield return creator("חתן בראשית", מישברך);
				yield return creator("מפטיר", מישברך);
				yield return creator("הגבהה", None);
			}
		}

		static readonly AuctionGroup יום٠כיפור =
			new AuctionGroup("יום כיפור", new YomKippurShacharis(), new YomKippurMincha());

		static readonly AuctionGroup שמיני٠עצרת = new AuctionGroup("שמיני עצרת",
			new ShminiAtzeresShacharis(),
			new SimchasTorahMaariv(),
			new SimchasTorahShacharis(TimeSpan.FromHours(6.5), "שמחת תורה השכמה שחרית"),
			new SimchasTorahShacharis(TimeSpan.FromHours(8.5), "שמחת תורה שחרית")
		);

		///<summary>Gets the complete set of auction groups.</summary>
		public static readonly ReadOnlyCollection<AuctionGroup> Groups = new ReadOnlyCollection<AuctionGroup>(new[]{
			new AuctionGroup("ראש השנה",		new AuctionInfo(Holiday.ראש٠השנה[1]),	new AuctionInfo(Holiday.ראש٠השנה[2])),
			יום٠כיפור,

			new AuctionGroup("סוכות",			new AuctionInfo(Holiday.סוכות[1]),		new AuctionInfo(Holiday.סוכות[2])),
			שמיני٠עצרת,

			new AuctionGroup("פסח",				new AuctionInfo(Holiday.פסח[1]),		new AuctionInfo(Holiday.פסח[2])),
			new AuctionGroup("אחרון של פסח",	new AuctionInfo(Holiday.פסח[7]),		new AuctionInfo(Holiday.פסח[8])),

			new AuctionGroup("שבועות",			new AuctionInfo(Holiday.שבועות[1]),		new AuctionInfo(Holiday.שבועות[2])),
		});
		#endregion
	}
	///<summary>A contiguous group of auction specifications (eg, the first days of פסח).</summary>
	class AuctionGroup {
		public AuctionGroup(string name, params AuctionInfo[] auctions) { Name = name; Auctions = new ReadOnlyCollection<AuctionInfo>(auctions); }

		///<summary>Gets the name of the entire group.</summary>
		public string Name { get; private set; }
		///<summary>Gets the auctions in the group.</summary>
		public ReadOnlyCollection<AuctionInfo> Auctions { get; private set; }

		public override string ToString() {
			return Name + " (" + Auctions.Count + " auctions)";
		}
	}
}
