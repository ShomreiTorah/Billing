using System;
using System.Text;
using System.Linq;
using ShomreiTorah.Billing.BillingDataTableAdapters;
using System.Data.SqlClient;
using ShomreiTorah.Common;
using System.Data;
using System.Collections.ObjectModel;
using System.Net.Mail;
namespace ShomreiTorah.Billing {


	partial class BillingData {
		public static readonly ReadOnlyCollection<string> AccountNames = new ReadOnlyCollection<string>(new[] { "Operating Fund", "Building Fund" });
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

		public void Save() {
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
			public decimal GetBalance(DateTime until) {
				return GetPledgesRows().Where(p => p.Date < until).Sum(p => p.Amount) - GetPaymentsRows().Where(p => p.Date < until).Sum(p => p.Amount);
			}
			public decimal GetBalance(string account) {
				return GetPledgesRows().Where(p => p.Account == account).Sum(p => p.Amount) - GetPaymentsRows().Where(p => p.Account == account).Sum(p => p.Amount);
			}
			public decimal GetBalance(DateTime until, string account) {
				return GetPledgesRows().Where(p => p.Date < until && p.Account == account).Sum(p => p.Amount) - GetPaymentsRows().Where(p => p.Date < until && p.Account == account).Sum(p => p.Amount);
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
		public partial class PaymentsRow {
			public DateTime? DepositDate {
				get { return IsDepositDateSqlNull() ? new DateTime?() : DepositDateSql.Date; }
				set {
					if (value == null)
						SetDepositDateSqlNull();
					else
						DepositDateSql = value.Value.Date;
				}
			}
		}
	}
}

