﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Composition;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ShomreiTorah.Billing.PaymentImport.Sources;
using ShomreiTorah.Common;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI;
using ShomreiTorah.WinForms.Forms;

namespace ShomreiTorah.Billing.PaymentImport {
	[Export]
	public class ViewModel : INotifyPropertyChanged {
		///<summary>All payments from the source (including already-imported payments).</summary>
		IReadOnlyCollection<PaymentInfo> allPayments;

		readonly Dictionary<string, ImportingPayment> importingPayments = new Dictionary<string, ImportingPayment>();
		ImportingPayment currentImport;

		///<summary>Stores user input for a single payment that is in the process of being imported.</summary>
		class ImportingPayment {
			// All properties of the current import must be stored here.
			// They must only be mutated through the wrapper properties,
			// so that we always raise PropertyChanged for data-binding.
			public readonly ReadOnlyObservableCollection<Person> matchingPeople;
			public string comments;
			public bool createPledge;
			public decimal pledgeAmount;
			public string pledgeType;
			public string pledgeSubType;
			public string pledgeNote;

			readonly ObservableCollection<Person> writableMatches;

			private Person person;
			public Person Person {
				get => person;
				set {
					if (value == Person)
						return;
					person = value;
					// If the user didn't already opt to create a pledge, and this person
					// doesn't owe anything that the payment might cover, create a pledge
					createPledge = createPledge || Person.Field<decimal>("BalanceDue") <= 0;
				}
			}

			public ImportingPayment(PaymentInfo payment) {
				comments = "\n" + payment.Comments;
				pledgeAmount = payment.Amount;

				writableMatches = new ObservableCollection<Person>(Matcher.FindMatches(payment));
				matchingPeople = new ReadOnlyObservableCollection<Person>(writableMatches);
				Person = writableMatches.Count == 1 ? writableMatches.First() : null;
			}

			public void AppendPerson(Person person) => writableMatches.Add(person);
			public void AppendPeople(IEnumerable<Person> people) => writableMatches.AddRange(people);
		}

		///<summary>Indicates whether the data source returned any payments at all (including already-imported payments).</summary>
		public bool PaymentsExist => allPayments.Any();

		ReadOnlyCollection<PaymentInfo> availablePayments;
		///<summary>Gets all payments that are ready to import.</summary>
		public ReadOnlyCollection<PaymentInfo> AvailablePayments {
			get { return availablePayments; }
			private set { availablePayments = value; OnPropertyChanged(); }
		}

		PaymentInfo currentPayment;
		///<summary>Gets or sets the payment currently being imported.</summary>
		public PaymentInfo CurrentPayment {
			get { return currentPayment; }
			set {
				currentPayment = value;
				if (value != null) {
					if (importingPayments.TryGetValue(value.Id, out currentImport)) {
						// Add any matches that were created since this was first selected.
						IEnumerable<Person> newMatches = Matcher.FindMatches(value).Except(MatchingPeople).ToList();
						currentImport.AppendPeople(newMatches);
						// If we discovered an exact match, prefer it. This happpens if the
						// user selects this payment, then goes back to a different payment
						// from the same person and creates a matching Person for it.
						Person = newMatches.FirstOrDefault(p => Matcher.GetMatchScore(value, p) == 0) ?? Person;
					} else {
						// If we haven't started importing this payment already, initialize its backing object.
						currentImport = new ImportingPayment(value);
						importingPayments.Add(value.Id, currentImport);
						InferType();
						OnNewPaymentSelected();
					}
					OnPropertyChanged(nameof(Comments));
					OnPropertyChanged(nameof(CreatePledge));
					OnPropertyChanged(nameof(PledgeType));
					OnPropertyChanged(nameof(PledgeSubType));
					OnPropertyChanged(nameof(PledgeNote));
					OnPropertyChanged(nameof(PledgeAmount));
					OnPropertyChanged(nameof(Person));
					OnPropertyChanged(nameof(MatchingPeople));
				}
				OnPropertyChanged();
			}
		}

		///<summary>Gets or sets a delegate to filter all payments from the data source.</summary>
		public Func<PaymentInfo, bool> PaymentFilter { get; set; } = _ => true;

		///<summary>Gets or sets the collection of pledge types to infer from based on the amount.</summary>
		public IReadOnlyCollection<PledgeType> PledgeTypes { get; set; }
		void InferType() {
			foreach (var factor in ("0, " + Config.ReadAttribute("Billing", "PaymentImport", "AdditionalPercentages")).Split(',')) {
				var fraction = 1 + decimal.Parse(factor.Trim()) / 100m;
				var actualAmount = CurrentPayment.Amount / fraction;
				foreach (var type in PledgeTypes ?? Names.PledgeTypes) {
					// Don't infer Melave Malka pledge types for non-journal payments.
					if (type == Names.JournalPledgeType && CurrentPayment.JournalInfo == null)
						continue;
					var subtype = type.Subtypes.FirstOrDefault(st => st.DefaultPrice == actualAmount);
					if (subtype != null) {
						PledgeType = type.Name;
						PledgeSubType = subtype.Name;
						return;
					} else if (type.DefaultPrice == actualAmount) {
						PledgeType = type.Name;
						return;
					}
				}
			}
		}

		///<summary>Occurs when a new payment is selected for import, allowing the caller to preset properties.</summary>
		public event EventHandler NewPaymentSelected;
		///<summary>Raises the NewPaymentSelected event.</summary>
		void OnNewPaymentSelected() => OnNewPaymentSelected(EventArgs.Empty);
		///<summary>Raises the NewPaymentSelected event.</summary>
		///<param name="e">An EventArgs object that provides the event data.</param>
		void OnNewPaymentSelected(EventArgs e) => NewPaymentSelected?.Invoke(this, e);


		///<summary>Gets existing people that may match the current payment.</summary>
		public ReadOnlyObservableCollection<Person> MatchingPeople => currentImport?.matchingPeople;

		///<summary>Gets or sets the person who will own the created payment.</summary>
		public Person Person {
			get { return currentImport?.Person; }
			set {
				currentImport.Person = value;
				if (value != null && !MatchingPeople.Contains(value))
					currentImport?.AppendPerson(value);
				OnPropertyChanged();
				// May change automatically in the inner setter.
				OnPropertyChanged(nameof(CreatePledge));
			}
		}


		///<summary>Gets or sets the comments field of the payment to create.</summary>
		public string Comments {
			get { return currentImport?.comments; }
			set { currentImport.comments = value; OnPropertyChanged(); }
		}

		///<summary>Gets or sets whether to also create a linked pledge when importing the payment.</summary>
		public bool CreatePledge {
			get { return currentImport?.createPledge ?? false; }
			set { currentImport.createPledge = value; OnPropertyChanged(); }
		}
		///<summary>Gets or sets the amount of the pledge to create.</summary>
		public decimal PledgeAmount {
			get { return currentImport?.pledgeAmount ?? 0; }
			set { currentImport.pledgeAmount = value; OnPropertyChanged(); }
		}

		///<summary>Gets or sets the Type field of the pledge to create.</summary>
		public string PledgeType {
			get { return currentImport?.pledgeType; }
			set { currentImport.pledgeType = value; OnPropertyChanged(); }
		}

		///<summary>Gets or sets the SubType field of the pledge to create.</summary>
		public string PledgeSubType {
			get { return currentImport?.pledgeSubType; }
			set { currentImport.pledgeSubType = value; OnPropertyChanged(); }
		}
		///<summary>Gets or sets the Note field of the pledge to create.</summary>
		public string PledgeNote {
			get { return currentImport?.pledgeNote; }
			set { currentImport.pledgeNote = value; OnPropertyChanged(); }
		}

		///<summary>Called after each payment is imported.</summary>
		public Action<PaymentInfo, Payment, Pledge> ImportCallback { get; set; }

		readonly AggregatingSource source;

		[ImportingConstructor]
		public ViewModel(AggregatingSource source) {
			this.source = source;
		}

		///<summary>Loads payments to import from the current source.</summary>
		public async Task LoadPayments(DateTime start) {
			AppFramework.LoadTables(ImportedPayment.Schema);
			await ProgressWorker.ExecuteAsync(async (p, token) => {
				p.Caption = "Loading payments after " + start.ToShortDateString();
				allPayments = (await source.GetPaymentsAsync(start, token))
					.Where(PaymentFilter)
					.Where(pi => pi.Amount > 0)
					.OrderByDescending(pi => pi.Date)
					.ToList();
			});
			RefreshPayments();
		}

		private void RefreshPayments() {
			if (!allPayments.Any()) {
				AvailablePayments = new ReadOnlyCollection<PaymentInfo>(new PaymentInfo[0]);
				return;
			}
			var start = allPayments.Last().Date;
			var alreadyImported = new HashSet<Tuple<string, string>>(
				AppFramework.Table<ImportedPayment>().Rows
					.Where(ip => ip.Payment.Date >= start)
					.Select(ip => Tuple.Create(ip.Source, ip.ExternalId)));
			AvailablePayments = allPayments
				.Where(p => !alreadyImported.Contains(Tuple.Create(p.SourceName, p.Id)))
				.ToList()
				.AsReadOnly();
		}


		public void Import() {
			if (!string.IsNullOrWhiteSpace(CurrentPayment.Email) && !AppFramework.Table<EmailAddress>().Rows
					.Any(r => r.Email.Equals(CurrentPayment.Email, StringComparison.OrdinalIgnoreCase))) {
				AppFramework.Table<EmailAddress>().Rows.Add(new EmailAddress {
					Email = CurrentPayment.Email,
					Name = CurrentPayment.FirstName + " " + CurrentPayment.LastName,
					DateAdded = CurrentPayment.Date,
					Person = Person
				});
			}

			var payment = new Payment {
				Account = Names.DefaultAccount,
				CheckNumber = CurrentPayment.FinalFour,
				Amount = CurrentPayment.Amount,
				Company = CurrentPayment.Company,
				Comments = TrimComments(Comments.Trim()),
				Date = CurrentPayment.Date,
				Method = "Credit Card",
				Person = Person,
			};
			AppFramework.Table<Payment>().Rows.Add(payment);
			AppFramework.Table<ImportedPayment>().Rows.Add(new ImportedPayment {
				DateImported = DateTime.Now,
				ExternalId = CurrentPayment.Id,
				ImportingUser = Environment.UserName,
				Payment = payment,
				Source = CurrentPayment.SourceName
			});
			Pledge pledge = null;
			if (CreatePledge) {
				pledge = new Pledge {
					Account = payment.Account,
					Amount = PledgeAmount,
					Comments = TrimComments("Created for credit card payment:\n" + Comments.Trim()),
					Date = payment.Date,
					Person = payment.Person,
					Type = PledgeType,
					SubType = PledgeSubType ?? "",
					Note = PledgeNote
				};

				AppFramework.Table<PledgeLink>().Rows.Add(new PledgeLink {
					Amount = pledge.Amount,
					Pledge = pledge,
					Payment = payment
				});
				AppFramework.Table<Pledge>().Rows.Add(pledge);
			}

			if (CurrentPayment.JournalInfo?.MensSeats != null || CurrentPayment.JournalInfo?.WomensSeats != null) {
				AppFramework.Table<MelaveMalkaSeat>().Rows.Add(new MelaveMalkaSeat {
					MensSeats = CurrentPayment.JournalInfo.MensSeats,
					WomensSeats = CurrentPayment.JournalInfo.WomensSeats,
					Person = payment.Person,
					Year = JournalAd.InferYear(payment.Date),
					DateAdded = DateTime.Now
				});
			}
			ImportCallback?.Invoke(CurrentPayment, payment, pledge);
			RefreshPayments();
		}

		///<summary>Trims Comments fields to fit in the database.</summary>
		static string TrimComments(string text) {
			if (text.Length <= 512)
				return text;
			return text.Remove(511) + "…";
		}

		///<summary>Occurs when a property value is changed.</summary>
		public event PropertyChangedEventHandler PropertyChanged;
		///<summary>Raises the PropertyChanged event.</summary>
		///<param name="name">The name of the property that changed.</param>
		protected virtual void OnPropertyChanged([CallerMemberName] string name = null) => OnPropertyChanged(new PropertyChangedEventArgs(name));
		///<summary>Raises the PropertyChanged event.</summary>
		///<param name="e">An EventArgs object that provides the event data.</param>
		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e) => PropertyChanged?.Invoke(this, e);
	}
}

