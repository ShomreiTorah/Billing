using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ShomreiTorah.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace ShomreiTorah.Billing.Events.Auctions {
	///<summary>Describes a single item in an auction, optionally including a מי שברך.</summary>
	class AuctionItem : INotifyPropertyChanged {
		static readonly ReadOnlyCollection<string> SortedOrder = Names.PledgeTypes.Single(p => p.Name == "Auction").Subtypes;

		internal AuctionItem(Person person, DateTime date, string auctionName, string itemName, bool includeמישברך) {
			Person = person;
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
		///<summary>Gets the person associated with the pledges.</summary>
		public Person Person { get; private set; }

		///<summary>Gets the date (and time) for the item's pledges.</summary>
		public DateTime Date { get; private set; }

		///<summary>Gets the standard index of the pledge subtype; used to sort the grid.</summary>
		public int ItemIndex { get; private set; }

		///<summary>Gets the pledge for the auction's bid.</summary>
		public AuctionPledge BidPledge { get; private set; }
		///<summary>Gets the pledge for the associated מי שברך, if any.</summary>
		public AuctionPledge MBPledge { get; private set; }

		///<summary>Gets the item's potential pledges.  These pledges may have null values.</summary>
		public IEnumerable<AuctionPledge> Pledges {
			get {
				if (BidPledge != null) yield return BidPledge;
				if (MBPledge != null) yield return MBPledge;
			}
		}

		#region Expose Pledge Properties
		//These properties allow the pledges' properties to
		//be databound. For non-existent pledges, they will
		//always be null.  PropertyChanged events for these
		//properties are forwarded in the constructor.
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",Justification= "Data-bound property")]
		public decimal? BidAmount {
			get { return BidPledge == null ? new Decimal?() : BidPledge.Amount; }
			set {
				if (BidPledge != null)
					BidPledge.Amount = value;
			}
		}
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Data-bound property")]
		public string BidNote {
			get { return BidPledge == null ? null : BidPledge.Note; }
			set {
				if (BidPledge != null)
					BidPledge.Note = value;
			}
		}
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Data-bound property")]
		public decimal? MBAmount {
			get { return MBPledge == null ? new Decimal?() : MBPledge.Amount; }
			set {
				if (MBPledge != null)
					MBPledge.Amount = value;
			}
		}
		[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Data-bound property")]
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

	///<summary>Describes an optional pledge associated with an auction.</summary>
	class AuctionPledge : INotifyPropertyChanged {
		public AuctionPledge(AuctionItem item, string pledgeType) {
			Item = item;
			PledgeType = pledgeType;
		}
		///<summary>Gets the item that owns this pledge.</summary>
		public AuctionItem Item { get; private set; }
		///<summary>Gets the pledge type (Auction or מי שברך).  The subtype is stored in the item.</summary>
		public string PledgeType { get; private set; }

		#region Pledge Synchronization
		///<summary>Finds an existing pledge that matches this instance, if any.</summary>
		public Pledge FindPledge() {
			return Program.Table<Pledge>().Rows.FirstOrDefault(p =>
				p.Date == Item.Date && p.Person == Item.Person && p.Type == PledgeType && p.SubType == Item.ItemName
			);
		}

		///<summary>Updates this instance's values after a change in a corresponding pledge.</summary>
		///<param name="existingPledge">The pledge to update from, or null to null out this pledge.</param>
		public void UpdateFromPledge(Pledge existingPledge) {
			if (existingPledge != null) {
				Amount = existingPledge.Amount;
				Note = existingPledge.Note;
			} else
				Note = null;
		}

		///<summary>Checks whether this pledge is different from its current state in the Pledges table.</summary>
		public bool HasChanges() {
			var existingPledge = FindPledge();
			if (existingPledge == null && Amount == null)
				return false;		//Neither this pledge nor the corresponding DB pledge exist.

			if (existingPledge != null && Amount != null) {
				if (Amount == existingPledge.Amount && Note == existingPledge.Note)
					return false;	//Both pledges exist and their contents match exactly.
			}
			return true;
		}
		#endregion

		decimal? amount;
		AliyahNote note;
		///<summary>Gets or sets the pledge amount, or null if there is no pledge for this item.  For מתנות, this will be zero.</summary>
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

		///<summary>Gets or sets the pledge note, or null if there is no pledge for this item.</summary>
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
