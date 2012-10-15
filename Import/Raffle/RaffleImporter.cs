using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using ShomreiTorah.Common;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI.Controls;
using ShomreiTorah.Data.UI.DisplaySettings;
using ShomreiTorah.Singularity;
using ShomreiTorah.Singularity.DataBinding;
using DevExpress.XtraGrid;

namespace ShomreiTorah.Billing.Import.Raffle {
	partial class RaffleImporter : XtraForm {
		readonly List<ImportedTicket> tickets;

		public RaffleImporter(int year) {
			Program.LoadTable<RaffleTicket>();
			InitializeComponent();

			colAccount.ColumnEdit = EditorRepository.AccountEditor.CreateItem();
			colCheckNumber.ColumnEdit = new RepositoryItemCheckNumberEdit();	//TODO: Fix (we don't have payments)
			colAmount.ColumnEdit = colAmountPaid.ColumnEdit = EditorRepository.CurrencyEditor.CreateItem();

			colPerson.ApplyController(new PersonColumnController());

			grid.DataSource = tickets = Program.Table<RaffleTicket>().Rows
				.Where(t => t.Year == year)
				.GroupBy(t => t.Person, (person, set) => new ImportedTicket(set.OrderBy(t => t.TicketId).ToList()))
				.ToList();

			ToggleRowsBehavior.Instance.Apply(importedTicketsView);
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

		private void cancel_Click(object sender, EventArgs e) { Close(); }
		private void ok_Click(object sender, EventArgs e) {
			foreach (var it in tickets)
				it.DoImport();
			Close();
		}
		#endregion

		class ImportedTicket : INotifyPropertyChanged, IOwnedObject {
			readonly IList<RaffleTicket> originals;
			public ImportedTicket(IList<RaffleTicket> originals) {
				this.originals = originals;
				Person = originals.First().Person;
				Account = "Operating Fund";
				Type = "Melave Malka Raffle";

				Tickets = ((IListSource)new RowListBinder(Program.Table<RaffleTicket>(), originals.Cast<Row>().ToList())).GetList();

				if (originals.Count > 1)
					SubType = "tickets #" + originals.Join(", #", t => t.TicketId.ToString(CultureInfo.InvariantCulture));
				else
					SubType = "ticket #" + originals.First().TicketId.ToString(CultureInfo.InvariantCulture);
				Amount = RaffleTicket.CalcPrice(originals.Count);

				Comments = (originals.Select(t => (t.Comments ?? "").Trim())
									.Distinct(StringComparer.OrdinalIgnoreCase)
									.Join(Environment.NewLine)
						+ "\r\n(imported from Rafflizer)").Trim();

				AmountPaid = RaffleTicket.CalcPrice(originals.Count(t => t.Paid));
				PaymentMethod = AmountPaid > 0 ? "Cash" : "Unpaid";
			}

			public Person Person { get; private set; }
			public DateTime Date { get { return originals[0].DateAdded; } }

			[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Data binding")]
			public IList Tickets { get; private set; }

			public string Account { get; set; }
			public string Type { get; set; }
			public string SubType { get; set; }
			[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Data binding")]
			public string Note { get; set; }
			public Decimal Amount { get; set; }
			public string Comments { get; set; }

			decimal amountPaid;
			string paymentMethod;
			string checkNumber;
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
			public string CheckNumber {
				get { return checkNumber; }
				set {
					checkNumber = value;
					if (value != null) PaymentMethod = "Check";
					OnPropertyChanged("CheckNumber");
				}
			}

			const string Modifier = "Raffle Import";
			public void DoImport() {
				var pledge = new Pledge {
					Person = Person,
					Date = Date,
					Type = Type,
					SubType = SubType,
					Note = Note,
					Account = Account,
					Amount = Amount,
					Comments = Comments
				};
				Program.Table<Pledge>().Rows.Add(pledge);
				pledge.Modifier = Modifier;

				if (AmountPaid != 0) {
					var payment = new Payment {
						Person = Person,
						Date = Date,
						Method = PaymentMethod,
						CheckNumber = CheckNumber,
						Account = Account,
						Amount = AmountPaid,
						Comments = Comments
					};
					Program.Table<Payment>().Rows.Add(payment);
					payment.Modifier = Modifier;

					Program.Table<PledgeLink>().Rows.Add(new PledgeLink {
						Amount = AmountPaid,
						Payment = payment,
						Pledge = pledge
					});
				}
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
	}
}