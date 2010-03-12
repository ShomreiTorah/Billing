using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Mail;
using System.Text;
using ShomreiTorah.Billing.BillingDataTableAdapters;
using ShomreiTorah.Common;
using System.Globalization;

namespace ShomreiTorah.Billing {
	partial class BillingData {
		public static readonly ReadOnlyCollection<string> AccountNames = new ReadOnlyCollection<string>(new[] { "Operating Fund", "Building Fund" });
		public static readonly ReadOnlyCollection<string> PaymentMethods = new ReadOnlyCollection<string>(new[] { "Cash", "Check" });
		internal TableAdapterManager AdapterManager { get; private set; }
		internal void Load() {
			AdapterManager = new TableAdapterManager {
				MasterDirectoryTableAdapter = new MasterDirectoryTableAdapter { ClearBeforeFill = false },
				PaymentsTableAdapter = new PaymentsTableAdapter { ClearBeforeFill = false },
				PledgesTableAdapter = new PledgesTableAdapter { ClearBeforeFill = false },
				EmailListTableAdapter = new EmailListTableAdapter { ClearBeforeFill = false },
				DepositsTableAdapter = new DepositsTableAdapter { ClearBeforeFill = false },
				StatementLogTableAdapter = new StatementLogTableAdapter { ClearBeforeFill = false }
			};
			try {
				AdapterManager.Connection
					= AdapterManager.MasterDirectoryTableAdapter.Connection
					= AdapterManager.PaymentsTableAdapter.Connection
					= AdapterManager.PledgesTableAdapter.Connection
					= AdapterManager.EmailListTableAdapter.Connection
					= AdapterManager.DepositsTableAdapter.Connection
					= AdapterManager.StatementLogTableAdapter.Connection
					= (SqlConnection)DB.Default.OpenConnection();

				RefreshData(AdapterManager);
				//Don't dispose the connection; we'll need it to update the database.
			} finally { AdapterManager.Connection.Close(); }

			Pledges.ColumnChanging += Table_ColumnChanging;
			Payments.ColumnChanging += Table_ColumnChanging;

			Payments.PaymentsRowDeleting += Payments_PaymentsRowDeleting;
			Deposits.DepositsRowDeleting += Deposits_DepositsRowDeleting;

			EmailList.TableNewRow += EmailList_TableNewRow;
			//EmailList.EmailListRowChanged += EmailList_EmailListRowChanged;
			EmailList.ColumnChanged += EmailList_ColumnChanged;
		}

		internal void RefreshData(TableAdapterManager adapters) {
			adapters.MasterDirectoryTableAdapter.Fill(MasterDirectory);
			adapters.PledgesTableAdapter.Fill(Pledges);
			adapters.PaymentsTableAdapter.Fill(Payments);
			adapters.EmailListTableAdapter.Fill(EmailList);
			adapters.DepositsTableAdapter.Fill(Deposits);
			adapters.StatementLogTableAdapter.Fill(StatementLog);
		}

		void EmailList_TableNewRow(object sender, DataTableNewRowEventArgs e) {
			var row = e.Row as EmailListRow;
			row.RandomCode = Guid.NewGuid().ToString("N").Remove(20).ToUpperInvariant();
			row.JoinDate = DateTime.Now;
		}

		void EmailList_ColumnChanged(object sender, DataColumnChangeEventArgs e) {
			if (e.Column == EmailList.EmailColumn) {
				if (e.ProposedValue == DBNull.Value) {
					e.SetError("Email address is required");
					return;
				}

				var address = (string)e.ProposedValue;
				if (string.IsNullOrEmpty(address)) {
					e.SetError("Email address is required");
					return;
				}

				try {
					e.ProposedValue = new MailAddress(address).Address;
				} catch (FormatException) {
					e.SetError("Invalid email address");
					return;
				}
				e.SetError(null);
			}
		}

		bool deletingDeposit;
		void Deposits_DepositsRowDeleting(object sender, BillingData.DepositsRowChangeEvent e) {
			try {
				deletingDeposit = true;
				foreach (var payment in e.Row.GetPaymentsRows()) {
					payment.SetDepositIdNull();
				}
			} finally { deletingDeposit = false; }
		}
		void Payments_PaymentsRowDeleting(object sender, BillingData.PaymentsRowChangeEvent e) {
			if (!e.Row.IsDepositIdNull() && e.Row.DepositsRow.Count == 1)
				e.Row.DepositsRow.Delete();
		}
		void Table_ColumnChanging(object sender, DataColumnChangeEventArgs e) {
			if (e.Column.ColumnName == "DepositId" && e.ProposedValue == DBNull.Value) {
				if (deletingDeposit) return;
				var payment = (PaymentsRow)e.Row;
				if (!payment.IsDepositIdNull()) {
					var deposit = payment.DepositsRow;
					if (deposit.Count == 1)
						deposit.Delete();
				}
			}

			if (e.Column.ColumnName == "Amount") {
				e.SetError((decimal)e.ProposedValue > 0 ? null : "Amount must be positive");
			}

			if (!e.Column.ColumnName.StartsWith("Modifie")
			 && e.Column.ColumnName != "DepositId"
			 && !Equals(e.Row[e.Column], e.ProposedValue)) { //Handle nulls and strings
				e.Row["Modified"] = DateTime.UtcNow;
				e.Row["Modifier"] = Environment.UserName;
			}
		}

		internal void Save() {
			AdapterManager.UpdateAll(this);
		}

		partial class MasterDirectoryDataTable {
			internal MasterDirectoryRow AddMasterDirectoryRow(PersonData data, string source) {
				var retVal = AddMasterDirectoryRow(Guid.NewGuid(), -1, data.LastName, data.HisName, data.HerName, data.FullName, data.Address, data.City, data.State, data.Zip, data.Phone, source);
				retVal.SetYKIDNull();
				return retVal;
			}
		}
		partial class PledgesDataTable {
			public PledgesRow AddPledgesRow(MasterDirectoryRow person, DateTime date, string type, string subtype,
											string note, string account, decimal amount, string comments) {
				return AddPledgesRow(person, date, type, subtype, note, account, amount, comments, null, null);
			}
			public PledgesRow AddPledgesRow(MasterDirectoryRow person, DateTime date, string type, string subtype,
											string note, string account, decimal amount, string comments,
											string externalSource, int? externalId) {

				var row = AddPledgesRow(Guid.NewGuid(), person, date, type, subtype, account, amount, note, comments, DateTime.Now, Environment.UserName, externalSource, externalId ?? -1);
				if (externalId == null)
					row.SetExternalIDNull();
				return row;
			}

			public void AddLookupColumns() {
				if (Columns.Contains("HisName")) return;
				Columns.Add("HisName", typeof(string), "Parent(Pledges).HisName");
				Columns.Add("HerName", typeof(string), "Parent(Pledges).HerName");
				Columns.Add("LastName", typeof(string), "Parent(Pledges).LastName");
				Columns.Add("Address", typeof(string), "Parent(Pledges).Address");
				Columns.Add("Phone", typeof(string), "Parent(Pledges).Phone");
				Columns.Add("Zip", typeof(string), "Parent(Pledges).Zip");
			}
		}
		partial class PaymentsDataTable {
			public PaymentsRow AddPaymentsRow(MasterDirectoryRow person, DateTime date, string method, string checkNumber, string account, decimal amount, string comments) {
				return AddPaymentsRow(person, date, method, checkNumber, account, amount, comments, null, null);
			}
			public PaymentsRow AddPaymentsRow(MasterDirectoryRow person, DateTime date, string method, string checkNumber, string account, decimal amount, string comments, string externalSource, int? externalId) {
				var row = AddPaymentsRow(Guid.NewGuid(), person, date, method, checkNumber, account, amount, comments, DateTime.Now, Environment.UserName, externalSource, externalId ?? -1, null);
				if (externalId == null)
					row.SetExternalIDNull();
				return row;
			}
		}

		partial class MasterDirectoryRow {
			#region PersonData Operations
			///<summary>Updates the data of this row from the given PersonData.</summary>
			///<param name="newData">The data to set to.  Empty fields are ignored.</param>
			internal void Update(PersonData newData) {
				if (!String.IsNullOrEmpty(newData.FullName))
					FullName = newData.FullName;

				if (!String.IsNullOrEmpty(newData.HisName))
					HisName = newData.HisName;
				if (!String.IsNullOrEmpty(newData.HerName))
					HerName = newData.HerName;
				if (!String.IsNullOrEmpty(newData.LastName))
					LastName = newData.LastName;

				if (!String.IsNullOrEmpty(newData.Address) && !Address.IsInvalidAddress())
					Address = newData.Address;
				if (!String.IsNullOrEmpty(newData.City))
					City = newData.City;
				if (!String.IsNullOrEmpty(newData.State))
					State = newData.State;
				if (!String.IsNullOrEmpty(newData.Zip))
					Zip = newData.Zip;

				if (!String.IsNullOrEmpty(newData.Phone))
					Phone = newData.Phone;
			}
			///<summary>Sets the data of this row to the given PersonData.</summary>
			///<param name="data">The data to set to.  Fields that are empty in data will be emptied in the row.</param>
			internal void Set(PersonData data) {
				FullName = data.FullName;

				HisName = data.HisName;
				HerName = data.HerName;
				LastName = data.LastName;

				Address = data.Address;
				City = data.City;
				State = data.State;
				Zip = data.Zip;

				Phone = data.Phone;
			}
			#endregion

			public IEnumerable<ITransaction> Transactions { get { return GetPledgesRows().Cast<ITransaction>().Concat(GetPaymentsRows()); } }

			public string MailingAddress {
				get {
					var retVal = new StringBuilder();
					if (!String.IsNullOrEmpty(FullName)) retVal.AppendLine(FullName);
					if (!String.IsNullOrEmpty(Address)) retVal.AppendLine(Address);
					if (!String.IsNullOrEmpty(City)
					 && !String.IsNullOrEmpty(State)) {
						retVal.Append(City).Append(", ").Append(State);
						if (!String.IsNullOrEmpty(Zip)) retVal.Append(" ").Append(Zip);
					}
					return retVal.ToString();
				}
			}

			///<summary>Gets the accounts in which this person has outstanding balance.</summary>
			public IEnumerable<string> OpenAccounts {
				get {
					return from t in Transactions
						   group t by t.Account into a
						   where a.Sum(t => t.SignedAmount) != 0
						   select a.Key;
				}
			}

			public decimal GetBalance(DateTime until) {
				return Transactions.Where(p => p.Date < until).Sum(p => p.SignedAmount);
			}
			public decimal GetBalance(string account) {
				return Transactions.Where(p => p.Account == account).Sum(p => p.SignedAmount);
			}
			public decimal GetBalance(DateTime until, string account) {
				return Transactions.Where(p => p.Date < until && p.Account == account).Sum(p => p.SignedAmount);
			}
			public string VeryFullName {
				get {
					StringBuilder retVal = new StringBuilder((HisName ?? "").Length + (HerName ?? "").Length + (LastName ?? "").Length + 6);

					if (!String.IsNullOrEmpty(HisName)) {
						retVal.Append(HisName);
						if (!String.IsNullOrEmpty(HerName))
							retVal.Append(" and ");
					}

					if (!String.IsNullOrEmpty(HerName))
						retVal.Append(HerName);

					if (retVal.Length != 0 && !String.IsNullOrEmpty(LastName)) retVal.Append(" ");

					if (!String.IsNullOrEmpty(LastName)) retVal.Append(LastName);
					return retVal.ToString();
				}
			}
		}
		public partial class EmailListRow {
			public MailAddress MailAddress { get { return new MailAddress(Email, Name); } }
		}
		public partial class PledgesRow : ITransaction {
			public decimal SignedAmount { get { return Amount; } }
		}

		public partial class PaymentsRow : ITransaction {
			public decimal SignedAmount { get { return -Amount; } }

			string lastCheckedCheckNumber;
			public string CheckDuplicateWarning(string newCheckNumber, bool force) {
				if (newCheckNumber == null) {
					lastCheckedCheckNumber = null;
					return null;
				}

				if (IsNull("PersonId")) return null;	//If the row is being added.
				if (!force) {
					if (lastCheckedCheckNumber == CheckNumber)
						lastCheckedCheckNumber = null;	//If we've commited a previous attempted change, warn again
					if (newCheckNumber == CheckNumber || newCheckNumber == lastCheckedCheckNumber)
						return null;
				}

				//Support detached rows (if the payment is being added)
				var duplicate = Program.Data.Payments.FirstOrDefault(p => p != this
																	   && p.PersonId == PersonId
																	   && String.Equals(p.CheckNumber, newCheckNumber, StringComparison.CurrentCultureIgnoreCase));
				if (duplicate == null) {
					lastCheckedCheckNumber = null;
					return null;
				}
				lastCheckedCheckNumber = force ? null : newCheckNumber;
				return String.Format(CultureInfo.CurrentUICulture, "{0} #{1} for {2} has already been entered ({3:d}, {4:c}).\r\nAre you sure you aren't making a mistake?",
																   duplicate.Method, duplicate.CheckNumber, duplicate.FullName, duplicate.Date, duplicate.Amount);
			}
		}
		public partial class DepositsRow : IComparable {

			public override string ToString() { return Date.ToShortDateString() + " #" + Number; }

			int IComparable.CompareTo(object obj) {
				var other = obj as DepositsRow;
				if (other == null) return 1;
				if (this == other) return 0;
				var result = Date.CompareTo(other.Date);
				return result == 0 ? Number.CompareTo(other.Number) : result;
			}
		}
	}
	public interface ITransaction {
		[SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Date", Justification = "For internal consumption")]
		DateTime Date { get; }
		string Account { get; }
		///<summary>Gets the amount with the sign as reflected in the balance due.</summary>
		decimal SignedAmount { get; }
	}
}


