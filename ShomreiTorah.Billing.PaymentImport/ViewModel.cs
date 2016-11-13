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
using ShomreiTorah.Data.UI;
using ShomreiTorah.WinForms.Forms;

namespace ShomreiTorah.Billing.PaymentImport {
    // TODO: Split into Dictionary<string, ImportingPayment> to preserve data with scroll or refresh.
	[Export]
	public class ViewModel : INotifyPropertyChanged {
		///<summary>All payments from the source (including already-imported payments).</summary>
		IReadOnlyCollection<PaymentInfo> allPayments;
		IReadOnlyCollection<Person> directMatches;


		ReadOnlyCollection<PaymentInfo> availablePayments;
		///<summary>Gets all payments that are ready to import.</summary>
		public ReadOnlyCollection<PaymentInfo> AvailablePayments {
			get { return availablePayments; }
			private set { availablePayments = value; OnPropertyChanged(); }
		}


		ReadOnlyCollection<Person> matchingPeople;
		///<summary>Gets existing people that may match the current payment.</summary>
		public ReadOnlyCollection<Person> MatchingPeople {
			get { return matchingPeople; }
			private set { matchingPeople = value; OnPropertyChanged(); }
		}


		PaymentInfo currentPayment;
		///<summary>Gets or sets the payment currently being imported.</summary>
		public PaymentInfo CurrentPayment {
			get { return currentPayment; }
			set {
				currentPayment = value;
				if (value != null) {
					Comments = "\n" + value.Comments;
					CreatePledge = false;
					PledgeType = null;  // TODO: Infer type from payment comments & amount
					PledgeSubType = null;
					PledgeAmount = value.Amount;
					FindMathingPeople();
				}
				OnPropertyChanged();
			}
		}

		Person person;
		///<summary>Gets or sets the person who will own the created payment.</summary>
		public Person Person {
			get { return person; }
			set {
				person = value;
				var people = directMatches.ToList();
				if (value != null && !directMatches.Contains(value))
					people.Add(value);
				MatchingPeople = people.AsReadOnly();
				OnPropertyChanged();
			}
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
		public ViewModel([ImportMany] IEnumerable<IPaymentSource> sources) {
			source = sources.Single(s => s.Name == Config.ReadAttribute("Billing", "PaymentImport", "Source", "Name"));
		}

		///<summary>Loads payments to import from the current source.</summary>
		public void LoadPayments(DateTime start) {
			AppFramework.LoadTables(ImportedPayment.Schema);
			if (!ProgressWorker.Execute(p => {
				p.Caption = "Loading payments after " + start.ToShortDateString();
				allPayments = source.GetPayments(start).OrderBy(pi => pi.Date).ToList();
			}, cancellable: true))
				return;
			RefreshPayments();
		}

		private void RefreshPayments() {
			if (!allPayments.Any()) {
				AvailablePayments = new ReadOnlyCollection<PaymentInfo>(new PaymentInfo[0]);
				return;
			}
			var start = allPayments.First().Date;
			var alreadyImported = new HashSet<string>(
				AppFramework.Table<ImportedPayment>().Rows
					.Where(ip => ip.Source == source
					.Name && ip.Payment.Date >= start)
					.Select(ip => ip.ExternalId));
			AvailablePayments = allPayments.Where(p => !alreadyImported.Contains(p.Id)).ToList().AsReadOnly();
		}

		private void FindMathingPeople() {
			if (CurrentPayment == null)
				return;

			directMatches = MatchingPeople = Matcher.FindMatches(CurrentPayment).ToList().AsReadOnly();
			Person = directMatches.Count == 1 ? directMatches.First() : null;
		}


		public void Import() {
			if (!AppFramework.Table<EmailAddress>().Rows
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
				Comments = Comments.Trim(),
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

				AppFramework.Table<PledgeLink>().Rows.Add(new PledgeLink {
					Amount = pledge.Amount,
					Pledge = pledge,
					Payment = payment
				});
				AppFramework.Table<Pledge>().Rows.Add(pledge);
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

