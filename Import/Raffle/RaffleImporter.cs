using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using Rafflizer;
using ShomreiTorah.Common;
using DevExpress.XtraGrid;

namespace ShomreiTorah.Billing.Import.Raffle {
	partial class RaffleImporter : XtraForm {
		public static void Execute() {
			string dbPath;
			using (var dialog = new OpenFileDialog {
				Filter = "ListMaker Database (Data.lmdb.gz)|Data.lmdb.gz|ListMaker Databases|*.lmdb.gz|All Files|*.*",
				Title = "Open ListMaker Database"
			}) {
				try {
					dialog.FileName = Config.ReadAttribute("ListMaker", "DatabasePath");
					dialog.InitialDirectory = Path.GetFileName(dialog.InitialDirectory);
				} catch (ConfigurationException) { }

				if (dialog.ShowDialog() == DialogResult.Cancel) return;
				dbPath = dialog.FileName;
			}

			DateTime? raffleDate = DatePrompt.Prompt();
			if (raffleDate == null) return;
			using (var database = new RaffleDB()) {
				database.ReadGzip(dbPath);

				using (var form = new RaffleImporter(database, raffleDate.Value)) {
					form.ShowDialog();
				}
			}
		}
		readonly Resolver resolver = new Resolver("Raffle " + DateTime.Now.Year);
		readonly List<ImportedTicket> tickets;
		readonly DateTime raffleDate;
		RaffleImporter(RaffleDB database, DateTime raffleDate) {
			InitializeComponent();

			accountEdit.Items.AddRange(BillingData.AccountNames);
			accountEdit.DropDownRows = BillingData.AccountNames.Count;

			this.raffleDate = raffleDate;
			tickets = (
				from DataRowView person in database.AllPeople.DefaultView
				let t = person.CreateChildView(database.Raffle_Tickets.ParentRelations[0].RelationName)
				where t.Count > 0
				select new ImportedTicket(resolver.Resolve(new PersonData(person.Row)), t)
			).ToList();

			grid.DataSource = tickets;
			importedTicketsView.BestFitColumns();
		}
		#region UI
		private void grid_ViewRegistered(object sender, ViewOperationEventArgs e) {
			var gridView = e.View as GridView;
			if (gridView != null) gridView.BestFitColumns();
		}
		private void importedTicketsView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e) {
			if (e.Column == colPaymentMethod) {
				var it = (ImportedTicket)importedTicketsView.GetRow(e.RowHandle);
				e.RepositoryItem = it.PaymentMethod == "Unpaid" ? (RepositoryItem)unpaidEdit : paymentMethodEdit;
			}
		}
		private void importedTicketsView_ShowingEditor(object sender, CancelEventArgs e) {
			if (importedTicketsView.FocusedColumn == colCheckNumber) {
				var it = (ImportedTicket)importedTicketsView.GetFocusedRow();
				e.Cancel = it.AmountPaid == 0;
			}
		}
		#endregion
		private void ok_Click(object sender, EventArgs e) {
			foreach (var it in tickets)
				it.DoImport(raffleDate);
		}
		private void cancel_Click(object sender, EventArgs e) {
			foreach (var it in tickets)
				it.Person.UndoAction();
		}
		class ImportedTicket : INotifyPropertyChanged {
			public ImportedTicket(ResolvedPerson person, DataView ticketsView) {
				Person = person;
				Account = "Operating Fund";
				Type = "Melave Malka Raffle";

				Tickets = ticketsView;
				var tickets = ticketsView.Rows<RaffleDB.Raffle_TicketsRow>();

				if (ticketsView.Count > 1)
					SubType = "tickets #" + tickets.Join(", #", t => t.TicketID.ToString(CultureInfo.InvariantCulture));
				else
					SubType = "ticket #" + tickets.First().TicketID.ToString(CultureInfo.InvariantCulture);
				Amount = RaffleDB.CalcPrice(ticketsView.Count);

				Comments = "Imported from Rafflizer\r\n" + tickets
					.Select(t => (t.Notes ?? "").Trim())
					.Distinct(StringComparer.OrdinalIgnoreCase)
					.Join(Environment.NewLine);

				AmountPaid = RaffleDB.CalcPrice(tickets.Count(t => t.Paid));
				PaymentMethod = AmountPaid > 0 ? "Cash" : "Unpaid";
			}

			public ResolvedPerson Person { get; private set; }

			[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Data binding")]
			public string HisName { get { return Person.ResolvedRow.HisName; } }
			[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Data binding")]
			public string HerName { get { return Person.ResolvedRow.HerName; } }
			[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Data binding")]
			public string LastName { get { return Person.ResolvedRow.LastName; } }
			[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Data binding")]
			public string Address { get { return Person.ResolvedRow.Address; } }

			[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Data binding")]
			public DataView Tickets { get; private set; }

			public string Account { get; set; }
			public string Type { get; set; }
			public string SubType { get; set; }
			[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Data binding")]
			public string Note { get; set; }
			public Decimal Amount { get; set; }
			public string Comments { get; set; }

			decimal amountPaid;
			string paymentMethod;
			int? checkNumber;
			///<summary>Gets or sets the type of payment.</summary>
			public string PaymentMethod {
				get { return paymentMethod; }
				set {
					paymentMethod = value;
					if (value != "Check") CheckNumber = null;
					OnPropertyChanged("PaymentMethod");
				}
			}
			///<summary>Gets or sets the amount that was already paid.</summary>
			public decimal AmountPaid {
				get { return amountPaid; }
				set {
					var wasZero = AmountPaid == 0;
					amountPaid = value;
					if (wasZero != (AmountPaid == 0)) {
						PaymentMethod = AmountPaid > 0 ? "Cash" : "Unpaid";
					}
					OnPropertyChanged("AmountPaid");
				}
			}
			///<summary>Gets or sets the check number.</summary>
			public int? CheckNumber {
				get { return checkNumber; }
				set {
					checkNumber = value;
					if (value != null) PaymentMethod = "Check";
					OnPropertyChanged("CheckNumber");
				}
			}

			const string Modifier = "Raffle Import";
			public void DoImport(DateTime raffleDate) {
				var pledge = Program.Data.Pledges.AddPledgesRow(
						Guid.NewGuid(), Person.ResolvedRow, raffleDate,
						Type, SubType, Account, Amount, Note, Comments,
						DateTime.Now, Modifier, null, 0);
				pledge.SetExternalIDNull();
				pledge.Modifier = Modifier;

				if (AmountPaid == 0)
					return;
				var payment = Program.Data.Payments.AddPaymentsRow(
						Guid.NewGuid(), Person.ResolvedRow, raffleDate,
						PaymentMethod, CheckNumber ?? -1, Account, AmountPaid,
						Comments, DateTime.Now, Modifier, null, 0, null);

				if (CheckNumber == null)
					payment.SetCheckNumberNull();
				payment.SetExternalIDNull();
				payment.Modifier = Modifier;
			}

			///<summary>Occurs when a property value is changed.</summary>
			public event PropertyChangedEventHandler PropertyChanged;
			///<summary>Raises the PropertyChanged event.</summary>
			///<param name="name">The name of the property that changed.</param>
			internal protected virtual void OnPropertyChanged(string name) { OnPropertyChanged(new PropertyChangedEventArgs(name)); }
			///<summary>Raises the PropertyChanged event.</summary>
			///<param name="e">An EventArgs object that provides the event data.</param>
			internal protected virtual void OnPropertyChanged(PropertyChangedEventArgs e) {
				if (PropertyChanged != null)
					PropertyChanged(this, e);
			}
		}

		private void importedTicketsView_DoubleClick(object sender, EventArgs e) {
			var hitInfo = importedTicketsView.CalcHitInfo(grid.PointToClient(MousePosition));
			if (hitInfo.InRow && hitInfo.RowHandle >= 0)
				importedTicketsView.SetMasterRowExpanded(hitInfo.RowHandle, !importedTicketsView.GetMasterRowExpanded(hitInfo.RowHandle));
		}

	}
}