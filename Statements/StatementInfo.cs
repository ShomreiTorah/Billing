using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace ShomreiTorah.Billing.Statements {
	public class BillInfo {
		public BillInfo(BillingData.MasterDirectoryRow person, DateTime startDate, BillKind kind) {
			Person = person;
			StartDate = startDate;
			Kind = kind;

			Recalculate();
		}

		public BillingData.MasterDirectoryRow Person { get; private set; }
		public DateTime StartDate { get; private set; }
		public BillKind Kind { get; private set; }

		public bool ShouldSend { get { return Accounts.Count > 0; } }

		public void Recalculate() {
			TotalBalance = Math.Max(0, Person.BalanceDue);

			Accounts = new ReadOnlyCollection<BillAccount>(
				BillingData.AccountNames.Select(a => new BillAccount(this, a))
										.Where(ba => ba.ShouldInclude)
										.ToArray()
			);

			if (Accounts.Any(a => a.Pledges.Any(p => p.Type.StartsWith("Melave Malka", StringComparison.CurrentCultureIgnoreCase)))) {
				Deductibility = "No goods or services have been provided.  If you attended the Melave Malka, $25 per reservation is not tax deductible.";
			} else
				Deductibility = "No goods or services have been provided.";

		}

		public decimal TotalBalance { get; private set; }
		public ReadOnlyCollection<BillAccount> Accounts { get; private set; }
		public string Deductibility { get; private set; }
	}
	public class BillAccount {
		internal BillAccount(BillInfo parent, string accountName) {
			Parent = parent;
			AccountName = accountName;
			OutstandingBalance = Parent.Person.GetBalance(Parent.StartDate, AccountName);
			BalanceDue = Math.Max(0, Parent.Person.GetBalance(AccountName));

			Func<ITransaction, bool> filter;
			if (parent.Kind == BillKind.Receipt)
				filter = t => t.Date.Year == Parent.StartDate.Year && t.Account == AccountName;
			else
				filter = t => t.Date >= Parent.StartDate && t.Account == AccountName;

			Pledges = new ReadOnlyCollection<BillingData.PledgesRow>(Parent.Person.GetPledgesRows().Where(p => filter(p)).OrderBy(p => p.Date).ToArray());
			Payments = new ReadOnlyCollection<BillingData.PaymentsRow>(Parent.Person.GetPaymentsRows().Where(p => filter(p)).OrderBy(p => p.Date).ToArray());

			TotalPledged = OutstandingBalance + Pledges.Sum(p => p.Amount);
			TotalPaid = Payments.Sum(p => p.Amount);
		}
		internal bool ShouldInclude {
			get {
				if (Parent.Kind == BillKind.Bill)
					return BalanceDue > 0;
				else
					return Payments.Any();
			}
		}

		public BillInfo Parent { get; private set; }
		public string AccountName { get; private set; }

		public decimal OutstandingBalance { get; private set; }
		public decimal BalanceDue { get; private set; }

		public decimal TotalPledged { get; private set; }
		public decimal TotalPaid { get; private set; }

		public ReadOnlyCollection<BillingData.PledgesRow> Pledges { get; private set; }
		public ReadOnlyCollection<BillingData.PaymentsRow> Payments { get; private set; }
	}
	public enum BillKind {
		Bill,
		Receipt
	}
}
