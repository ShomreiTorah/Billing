using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace ShomreiTorah.Billing.Export {
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

		public void Recalculate() {
			TotalBalance = Math.Max(0, Person.BalanceDue);

			Accounts = new ReadOnlyCollection<BillAccount>(
				(from t in Kind == BillKind.Receipt ? Person.GetPaymentsRows() : Person.Transactions
				 group t by t.Account into a
				 where a.Sum(t => t.SignedAmount) != 0
				 select new BillAccount(this, a.Key)).ToArray());
		}

		public decimal TotalBalance { get; private set; }
		public ReadOnlyCollection<BillAccount> Accounts { get; private set; }
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
		}

		public BillInfo Parent { get; private set; }
		public string AccountName { get; private set; }

		public decimal OutstandingBalance { get; private set; }
		public decimal BalanceDue { get; private set; }

		public ReadOnlyCollection<BillingData.PledgesRow> Pledges { get; private set; }
		public ReadOnlyCollection<BillingData.PaymentsRow> Payments { get; private set; }
	}
	public enum BillKind {
		Bill,
		Receipt
	}
}
