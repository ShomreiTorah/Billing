using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ShomreiTorah.Billing.Statements {
	public class StatementInfo {
		public StatementInfo(BillingData.MasterDirectoryRow person, DateTime startDate, StatementKind kind) {
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

		public BillingData.MasterDirectoryRow Person { get; private set; }
		public DateTime StartDate { get; private set; }
		public DateTime EndDate { get; private set; }
		public StatementKind Kind { get; private set; }

		public virtual bool ShouldSend { get { return Accounts.Count > 0; } }

		public void Recalculate() {
			TotalBalance = Math.Max(0, Person.BalanceDue);

			Accounts = new ReadOnlyCollection<StatementAccount>(
				BillingData.AccountNames.Select(a => new StatementAccount(this, a))
										.Where(ba => ba.ShouldInclude)
										.ToArray()
			);

			if (Accounts.Any(a => a.Pledges.Any(p => p.Type.StartsWith("Melave Malka", StringComparison.CurrentCultureIgnoreCase)))) {
				Deductibility = "No goods or services have been provided.  If you attended the Melave Malka, $25 per reservation is not tax deductible.";
			} else
				Deductibility = "No goods or services have been provided.";

		}

		public decimal TotalBalance { get; private set; }
		public ReadOnlyCollection<StatementAccount> Accounts { get; private set; }
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
			Program.Data.StatementLog.AddStatementLogRow(Guid.NewGuid(), Person, lastGenTime, media, kind, StartDate, EndDate, Environment.UserName);
		}
	}
	public class StatementAccount {
		internal StatementAccount(StatementInfo parent, string accountName) {
			Parent = parent;
			AccountName = accountName;
			OutstandingBalance = Parent.Person.GetBalance(Parent.StartDate, AccountName);
			BalanceDue = Math.Max(0, Parent.Person.GetBalance(AccountName));

			Func<ITransaction, bool> filter = t => t.Date >= Parent.StartDate && t.Date < Parent.EndDate && t.Account == AccountName;

			Pledges = new ReadOnlyCollection<BillingData.PledgesRow>(Parent.Person.GetPledgesRows().Where(p => filter(p)).OrderBy(p => p.Date).ToArray());
			Payments = new ReadOnlyCollection<BillingData.PaymentsRow>(Parent.Person.GetPaymentsRows().Where(p => filter(p)).OrderBy(p => p.Date).ToArray());

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

		public StatementInfo Parent { get; private set; }
		public string AccountName { get; private set; }

		public decimal OutstandingBalance { get; private set; }
		public decimal BalanceDue { get; private set; }

		public decimal TotalPledged { get; private set; }
		public decimal TotalPaid { get; private set; }

		public ReadOnlyCollection<BillingData.PledgesRow> Pledges { get; private set; }
		public ReadOnlyCollection<BillingData.PaymentsRow> Payments { get; private set; }
	}
	public enum StatementKind {
		Bill,
		Receipt
	}
}