using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ShomreiTorah.Common;
using ShomreiTorah.Common.Calendar;
using ShomreiTorah.Common.Calendar.Holidays;
using System.Collections.ObjectModel;
using System.Globalization;
using ShomreiTorah.Data;
using System.Diagnostics;

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

				yield return creator("חתן תורה", מישברך);
				yield return creator("חתן בראשית", מישברך);
				yield return creator("מפטיר", מישברך);
				yield return creator("הגבהה", None);
			}
		}

		static readonly AuctionGroup יום٠כיפור =
			new AuctionGroup("יום כיפור", new AuctionInfo(Holiday.יום٠כיפור.Date, new TimeSpan(7, 45, 00), "יום כיפור שחרית"), new YomKippurMincha());

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

			new AuctionGroup("שבועות",			new AuctionInfo(Holiday.שבועות[1]),		new AuctionInfo(Holiday.שבועות[2])),
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
	class AuctionItem : INotifyPropertyChanged {
		static readonly ReadOnlyCollection<string> SortedOrder = Names.PledgeTypes.Single(p => p.Name == "Auction").Subtypes;

		public AuctionItem(Person person, DateTime date, string auctionName, string itemName, bool includeמישברך) {
			Date = date;
			AuctionName = auctionName;

			ItemName = itemName;
			ItemIndex = SortedOrder.IndexOf(itemName);
			Debug.Assert(ItemIndex >= 0, itemName + " is not a subtype!");

			BidPledge = new AuctionPledge(this, "Auction");
			BidPledge.PropertyChanged += (sender, e) => OnPropertyChanged("Bid" + e.PropertyName);
			if (includeמישברך) {
				MBPledge = new AuctionPledge(this, "מי שברך");
				BidPledge.PropertyChanged += (sender, e) => OnPropertyChanged("MB" + e.PropertyName);
			}
		}

		///<summary>Gets the name of the auction that the item belongs to.</summary>
		public string AuctionName { get; private set; }
		///<summary>Gets the pledge subtype.</summary>
		public string ItemName { get; private set; }

		///<summary>Gets the date (and time) for the item's pledges.</summary>
		public DateTime Date { get; private set; }

		///<summary>Gets the standard index of the pledge subtype; used to sort the grid.</summary>
		public int ItemIndex { get; private set; }

		public AuctionPledge BidPledge { get; private set; }
		public AuctionPledge MBPledge { get; private set; }

		///<summary>Gets the item's potential pledges.  These pledges may have null values.</summary>
		public IEnumerable<AuctionPledge> Pledges {
			get {
				if (BidPledge != null) yield return BidPledge;
				if (MBPledge != null) yield return MBPledge;
			}
		}

		#region Expose Pledge Properties
		public decimal? BidAmount {
			get { return BidPledge == null ? new Decimal?() : BidPledge.Amount; }
			set {
				if (BidPledge != null)
					BidPledge.Amount = value;
			}
		}
		public string BidNote {
			get { return BidPledge == null ? null : BidPledge.Note; }
			set {
				if (BidPledge != null)
					BidPledge.Note = value;
			}
		}
		public decimal? MBAmount {
			get { return MBPledge == null ? new Decimal?() : MBPledge.Amount; }
			set {
				if (MBPledge != null)
					MBPledge.Amount = value;
			}
		}
		public string MBNote {
			get { return MBPledge == null ? null : MBPledge.Note; }
			set {
				if (MBPledge != null)
					MBPledge.Note = value;
			}
		}
		#endregion

		///<summary>Occurs when a property value is changed.</summary>
		public event PropertyChangedEventHandler PropertyChanged;
		///<summary>Raises the PropertyChanged event.</summary>
		///<param name="name">The name of the property that changed.</param>
		protected virtual void OnPropertyChanged(string name) { OnPropertyChanged(new PropertyChangedEventArgs(name)); }
		///<summary>Raises the PropertyChanged event.</summary>
		///<param name="e">An EventArgs object that provides the event data.</param>
		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e) {
			if (PropertyChanged != null)
				PropertyChanged(this, e);
		}
	}

	class AuctionPledge : INotifyPropertyChanged {
		public AuctionPledge(AuctionItem item, string pledgeType) {
			Item = item;
			PledgeType = pledgeType;
		}
		public AuctionItem Item { get; private set; }
		public string PledgeType { get; private set; }

		decimal? amount;
		AliyahNote note;
		public decimal? Amount {
			get { return amount; }
			set {
				amount = value;
				if (value == null) {
					note = null;
				} else {
					if (note == null)
						note = new AliyahNote();
					note.Isמתנה = value == 0;	//Don't call the property setter; we don't need its logic or event
				}
				OnPropertyChanged("Amount");
				OnPropertyChanged("Note");
			}
		}

		public string Note {
			get { return note == null ? null : note.Text; }
			set {
				if (value == null) {
					note = null;
					amount = null;
					OnPropertyChanged("Amount");
				} else {
					if (note == null) note = new AliyahNote();

					note.Text = value;
					if (note.Isמתנה) {
						amount = 0;	//Don't call the property setter; we don't need its logic or event
						OnPropertyChanged("Amount");
					} else if (Amount == 0 || Amount == null) {
						amount = 18;
						OnPropertyChanged("Amount");
					}
				}
				OnPropertyChanged("Note");
			}
		}

		///<summary>Occurs when a property value is changed.</summary>
		public event PropertyChangedEventHandler PropertyChanged;
		///<summary>Raises the PropertyChanged event.</summary>
		///<param name="name">The name of the property that changed.</param>
		protected virtual void OnPropertyChanged(string name) { OnPropertyChanged(new PropertyChangedEventArgs(name)); }
		///<summary>Raises the PropertyChanged event.</summary>
		///<param name="e">An EventArgs object that provides the event data.</param>
		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e) {
			if (PropertyChanged != null)
				PropertyChanged(this, e);
		}
	}
}
