using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ShomreiTorah.Data;

namespace ShomreiTorah.Billing.Statements {
	public class StatementInfo {
		public StatementInfo(Person person, DateTime startDate, StatementKind kind) {
			Person = person;
			switch (kind) {
				case StatementKind.Bill:
					StartDate = startDate;
					EndDate = DateTime.Now;
					break;
				case StatementKind.Receipt:
					StartDate = new DateTime(startDate.Year, 1, 1);
					EndDate = new DateTime(startDate.Year + 1, 1, 1).AddTicks(-1);
					break;
			}

			Kind = kind;

			Recalculate();
		}

		public Person Person { get; private set; }
		public DateTime StartDate { get; private set; }
		public DateTime EndDate { get; private set; }
		public StatementKind Kind { get; private set; }

		public virtual bool ShouldSend { get { return Accounts.Count > 0; } }

		public void Recalculate() {
			TotalBalance = Math.Max(0, Person.Field<decimal>("BalanceDue"));

			Accounts = new ReadOnlyCollection<StatementAccount>(
				Names.AccountNames.Select(a => new StatementAccount(this, a))
								  .Where(ba => ba.ShouldInclude)
								  .ToArray()
			);

			TotalPledged = Accounts.Sum(a => a.TotalPledged);
			TotalPaid = Accounts.Sum(a => a.TotalPaid);

			if (Accounts.Any(a => a.Pledges.Any(p => p.Type.StartsWith("Melave Malka", StringComparison.CurrentCultureIgnoreCase)))) {
				Deductibility = "No goods or services have been provided.  If you attended the Melave Malka, $25 per reservation is not tax deductible.";
			} else
				Deductibility = "No goods or services have been provided.";

			LastEnteredPayment = Program.Table<Payment>().Rows.Max(p => p.Modified);
		}

		///<summary>Gets the date of the most recently entered payment in the system.</summary>
		public DateTime LastEnteredPayment { get; private set; }

		///<summary>Gets the total value of the pledges in the statement.</summary>
		public decimal TotalPledged { get; private set; }
		///<summary>Gets the total value of the payments in the statement.</summary>
		public decimal TotalPaid { get; private set; }
		///<summary>Gets the person's balance due.</summary>
		public decimal TotalBalance { get; private set; }
		///<summary>Gets the accounts in the statement.</summary>
		public ReadOnlyCollection<StatementAccount> Accounts { get; private set; }
		///<summary>Gets a disclaimer describing how much of the contributions are tax-deductible.</summary>
		public string Deductibility { get; private set; }

		//This method is called in a loop.
		//I want the times to be identical
		//for all of the calls so that it 
		//will sort nicely.
		[ThreadStatic]
		static DateTime lastGenTime;
		internal void LogStatement(string media, string kind) {
			var now = DateTime.Now;
			if ((now - lastGenTime) > TimeSpan.FromSeconds(5))
				lastGenTime = now;
			Program.Table<LoggedStatement>().Rows.Add(new LoggedStatement {
				Person = Person,
				DateGenerated = lastGenTime,
				Media = media,
				StatementKind = kind,
				StartDate = StartDate,
				EndDate = EndDate,
				UserName = Environment.UserName
			});
		}
	}
	///<summary>Contains data about a specific account in a statement.</summary>
	public class StatementAccount {
		internal StatementAccount(StatementInfo parent, string accountName) {
			Parent = parent;
			AccountName = accountName;
			OutstandingBalance = Parent.Person.GetBalance(Parent.StartDate, AccountName);
			BalanceDue = Math.Max(0, Parent.Person.GetBalance(AccountName));

			Func<ITransaction, bool> filter = t => t.Date >= Parent.StartDate && t.Date < Parent.EndDate && t.Account == AccountName;

			Pledges = new ReadOnlyCollection<Pledge>(Parent.Person.Pledges.Where(p => filter(p)).OrderBy(p => p.Date).ToArray());
			Payments = new ReadOnlyCollection<Payment>(Parent.Person.Payments.Where(p => filter(p)).OrderBy(p => p.Date).ToArray());

			TotalPledged = OutstandingBalance + Pledges.Sum(p => p.Amount);
			TotalPaid = Payments.Sum(p => p.Amount);
		}
		internal bool ShouldInclude {
			get {
				if (Parent.Kind == StatementKind.Bill)
					return BalanceDue > 0;
				else
					return Payments.Any();
			}
		}

		///<summary>Gets the statement containing the account.</summary>
		public StatementInfo Parent { get; private set; }
		///<summary>Gets the name of the account.</summary>
		public string AccountName { get; private set; }

		///<summary>Gets the outstanding balance in the account.</summary>
		public decimal OutstandingBalance { get; private set; }
		public decimal BalanceDue { get; private set; }

		///<summary>Gets the total value of the pledges in the account.</summary>
		public decimal TotalPledged { get; private set; }
		///<summary>Gets the total value of the payments in the account.</summary>
		public decimal TotalPaid { get; private set; }

		///<summary>Gets the pledges that belong to the account.</summary>
		public ReadOnlyCollection<Pledge> Pledges { get; private set; }
		///<summary>Gets the payments that belong to the account.</summary>
		public ReadOnlyCollection<Payment> Payments { get; private set; }
	}
	public enum StatementKind {
		Bill,
		Receipt
	}
}
