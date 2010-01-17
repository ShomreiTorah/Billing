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
				EmailListTableAdapter = new EmailListTableAdapter { ClearBeforeFill = false }
			};
			try {
				AdapterManager.Connection
					= AdapterManager.MasterDirectoryTableAdapter.Connection
					= AdapterManager.PaymentsTableAdapter.Connection
					= AdapterManager.PledgesTableAdapter.Connection
					= AdapterManager.EmailListTableAdapter.Connection
					= (SqlConnection)DB.Default.OpenConnection();

				RefreshData(AdapterManager);
				//Don't dispose the connection; we'll need it to update the database.
			} finally { AdapterManager.Connection.Close(); }

			Pledges.ColumnChanging += Table_ColumnChanging;
			Payments.ColumnChanging += Table_ColumnChanging;

			EmailList.TableNewRow += EmailList_TableNewRow;
			//EmailList.EmailListRowChanged += EmailList_EmailListRowChanged;
			EmailList.ColumnChanged += EmailList_ColumnChanged;
		}
		internal void RefreshData(TableAdapterManager adapters) {
			adapters.MasterDirectoryTableAdapter.Fill(MasterDirectory);
			adapters.PledgesTableAdapter.Fill(Pledges);
			adapters.PaymentsTableAdapter.Fill(Payments);
			adapters.EmailListTableAdapter.Fill(EmailList);
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

		void Table_ColumnChanging(object sender, DataColumnChangeEventArgs e) {
			if (e.Column.ColumnName == "Amount") {
				e.SetError((decimal)e.ProposedValue > 0 ? null : "Amount must be positive");
			}

			if (e.Column.ColumnName.StartsWith("Modifie")
			 || Equals(e.Row[e.Column], e.ProposedValue)) //Handle nulls and strings
				return;
			e.Row["Modified"] = DateTime.UtcNow;
			e.Row["Modifier"] = Environment.UserName;
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
			public DateTime? DepositDate {
				get { return IsDepositDateSqlNull() ? new DateTime?() : DepositDateSql.Date; }
				set {
					if (value == null)
						SetDepositDateSqlNull();
					else
						DepositDateSql = value.Value.Date;
				}
			}


			public decimal SignedAmount { get { return -Amount; } }
		}
	}
	public interface ITransaction {
		[SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Date", Justification = "For internal consumption")]
		DateTime Date { get; }
		string Account { get; }
		//decimal Amount { get; }
		///<summary>Gets the amount with the sign as reflected in the balance due.</summary>
		decimal SignedAmount { get; }
	}
}

