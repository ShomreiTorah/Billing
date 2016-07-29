using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Composition;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ShomreiTorah.Common;
using ShomreiTorah.Data;

namespace ShomreiTorah.Billing.PaymentImport {
	class ViewModel : INotifyPropertyChanged {
		///<summary>Payments that are ready to import.</summary>
		readonly ObservableCollection<PaymentInfo> writablePayments = new ObservableCollection<PaymentInfo>();

		///<summary>All payments from the source (including already-imported payments).</summary>
		IReadOnlyCollection<PaymentInfo> allPayments;

		public ReadOnlyObservableCollection<PaymentInfo> AvailablePayments { get; }

		readonly ObservableCollection<Person> matchingPeople = new ObservableCollection<Person>();

		///<summary>All existing people that may match the current payment.</summary>
		public ReadOnlyObservableCollection<Person> MatchingPeople { get; }

		PaymentInfo currentPayment;
		///<summary>Gets or sets the payment currently being imported.</summary>
		public PaymentInfo CurrentPayment {
			get { return currentPayment; }
			set {
				currentPayment = value;
				if (value != null) {
					Comments = "\n" + value.Comments;
					CreatePledge = false;
					PledgeType = null;  // TODO: Infer type from payment comments
					PledgeSubType = null;
					PledgeAmount = value.Amount;
					SetPerson();
				}
				OnPropertyChanged();
			}
		}

		Person person;
		///<summary>Gets or sets the person who will own the created payment.</summary>
		public Person Person {
			get { return person; }
			set { person = value; OnPropertyChanged(); }
		}


		string comments;
		///<summary>Gets or sets the comments field of the payment to create.</summary>
		public string Comments {
			get { return comments; }
			set { comments = value; OnPropertyChanged(); }
		}

		bool createPledge;
		///<summary>Gets or sets whether to also create a linked pledge when importing the payment.</summary>
		public bool CreatePledge {
			get { return createPledge; }
			set { createPledge = value; OnPropertyChanged(); }
		}
		decimal pledgeAmount;
		///<summary>Gets or sets the amount of the pledge to create.</summary>
		public decimal PledgeAmount {
			get { return pledgeAmount; }
			set { pledgeAmount = value; OnPropertyChanged(); }
		}

		string pledgeType;
		///<summary>Gets or sets the Type field of the pledge to create.</summary>
		public string PledgeType {
			get { return pledgeType; }
			set { pledgeType = value; OnPropertyChanged(); }
		}

		string pledgeSubType;
		///<summary>Gets or sets the SubType field of the pledge to create.</summary>
		public string PledgeSubType {
			get { return pledgeSubType; }
			set { pledgeSubType = value; OnPropertyChanged(); }
		}



		readonly IPaymentSource source;

		[ImportingConstructor]
		public ViewModel(IEnumerable<IPaymentSource> sources) {
			AvailablePayments = new ReadOnlyObservableCollection<PaymentInfo>(writablePayments);
			MatchingPeople = new ReadOnlyObservableCollection<Person>(matchingPeople);

			source = sources.Single(s => s.Name == Config.ReadAttribute("Billing", "PaymentImport", "Source", "Name"));
		}

		///<summary>Loads payments to import from the current source.</summary>
		public void LoadPayments(DateTime start) {
			Program.LoadTable<ImportedPayment>();
			allPayments = source.GetPayments(start).OrderBy(p => p.Date).ToList();
			RefreshPayments();
		}

		private void RefreshPayments() {
			writablePayments.Clear();
			if (!allPayments.Any())
				return;
			var start = allPayments.First().Date;
			var alreadyImported = new HashSet<string>(
				Program.Table<ImportedPayment>().Rows
					.Where(ip => ip.Source == source
					.Name && ip.Payment.Date >= start)
					.Select(ip => ip.ExternalId));
			foreach (var p in allPayments.Where(p => !alreadyImported.Contains(p.Id)))
				writablePayments.Add(p);
		}

		private void SetPerson() {
			if (CurrentPayment == null)
				return;

			matchingPeople.Clear();
			matchingPeople.AddRange(Matcher.FindMatches(CurrentPayment));
		}


		public void Import() {
			var payment = new Payment {
				Account = Names.DefaultAccount,
				CheckNumber = CurrentPayment.FinalFour,
				Amount = CurrentPayment.Amount,
				Comments = Comments.Trim(),
				Date = CurrentPayment.Date,
				Method = "Credit Card",
				Person = Person,
			};
			Program.Table<Payment>().Rows.Add(payment);
			Program.Table<ImportedPayment>().Rows.Add(new ImportedPayment {
				DateImported = DateTime.Now,
				ExternalId = CurrentPayment.Id,
				ImportingUser = Environment.UserName,
				Payment = payment,
				Source = source.Name
			});
			if (CreatePledge) {
				var pledge = new Pledge {
					Account = payment.Account,
					Amount = PledgeAmount,
					Comments = "Created for credit card payment:\n" + payment.Comments,
					Date = payment.Date,
					Person = payment.Person,
					Type = PledgeType,
					SubType = PledgeSubType
				};

				Program.Table<PledgeLink>().Rows.Add(new PledgeLink {
					Amount = pledge.Amount,
					Pledge = pledge,
					Payment = payment
				});
				Program.Table<Pledge>().Rows.Add(pledge);
			}
			RefreshPayments();
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

