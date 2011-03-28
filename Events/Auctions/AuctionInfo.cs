using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShomreiTorah.Common;
using ShomreiTorah.Common.Calendar;
using ShomreiTorah.Common.Calendar.Holidays;
using System.Collections.ObjectModel;
using System.Globalization;

namespace ShomreiTorah.Billing.Events.Auctions {
	///<summary>Describes a single auction.</summary>
	class AuctionInfo {
		private AuctionInfo(Holiday holiday) : this(holiday.Date, TimeSpan.Zero, holiday.Name) { }
		private AuctionInfo(IHebrewEvent date, string name) : this(date, TimeSpan.Zero, name) { }
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
		public IEnumerable<AuctionItem> CreateItems(int hebrewYear) {
			var date = Date.GetDate(hebrewYear);
			var pledgeDate = date + Time;
			return CreateItems(date, (name, mb) => new AuctionItem(pledgeDate, name, mb));
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

				yield return creator("אתה הראית", מישברך);
				yield return creator("חתן תורה", מישברך);
				yield return creator("חתן בראשית", מישברך);
				yield return creator("מפטיר", מישברך);
				yield return creator("הגבהה", None);
			}
		}

		static readonly AuctionGroup יום٠כיפור =
			new AuctionGroup("יום כיפור", new AuctionInfo(Holiday.יום٠כיפור.Date, "יום כיפור שחרית"), new YomKippurMincha());

		static readonly AuctionGroup שמיני٠עצרת = new AuctionGroup("שמיני עצרת",
			new AuctionInfo(Holiday.סוכות[8]),
			new SimchasTorahMaariv(),
			new SimchasTorahShacharis(TimeSpan.FromHours(6.5), "שמחת תורה השכמה שחרית"),
			new SimchasTorahShacharis(TimeSpan.FromHours(8.5), "שמחת תורה שחרית")
		);

		public static readonly ReadOnlyCollection<AuctionGroup> Groups = new ReadOnlyCollection<AuctionGroup>(new[]{
			new AuctionGroup("ראש השנה",		new AuctionInfo(Holiday.ראש٠השנה[1]),	new AuctionInfo(Holiday.ראש٠השנה[2])),
			יום٠כיפור,

			new AuctionGroup("סוכות",			new AuctionInfo(Holiday.סוכות[1]),		new AuctionInfo(Holiday.סוכות[2])),
			שמיני٠עצרת,

			new AuctionGroup("פסח",				new AuctionInfo(Holiday.פסח[1]),		new AuctionInfo(Holiday.פסח[2])),
			new AuctionGroup("אחרון של פסח",	new AuctionInfo(Holiday.פסח[7]),		new AuctionInfo(Holiday.פסח[8])),

			new AuctionGroup("פסח",				new AuctionInfo(Holiday.שבועות[1]),		new AuctionInfo(Holiday.שבועות[2])),
		});
		#endregion
	}
	class AuctionGroup {
		public AuctionGroup(string name, params AuctionInfo[] auctions) { Name = name; Auctions = new ReadOnlyCollection<AuctionInfo>(auctions); }
		public string Name { get; private set; }
		public ReadOnlyCollection<AuctionInfo> Auctions { get; private set; }

		public override string ToString() {
			return Name + " (" + Auctions.Count + " auctions)";
		}
	}
	///<summary>Describes a single item in an auction, optionally including a מי שברך.</summary>
	class AuctionItem {
		public AuctionItem(DateTime date, string name, bool includeמישברך) {
			Date = date;
			Name = name;
		}

		///<summary>Gets the date (and time) for the item's pledges.</summary>
		public DateTime Date { get; private set; }
		///<summary>Gets the pledge subtype.</summary>
		public string Name { get; private set; }

		//TODO Properties for grid columns, pledge creation.
	}
}
