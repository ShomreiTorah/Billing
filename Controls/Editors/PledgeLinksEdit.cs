using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ShomreiTorah.Data.UI.Grid;
using DevExpress.XtraGrid.Views.Base;
using ShomreiTorah.Data.UI.DisplaySettings;
using ShomreiTorah.Data;
using System.Globalization;
using ShomreiTorah.Singularity;
using ShomreiTorah.WinForms;
using System.Diagnostics;
using DevExpress.XtraBars;
using ShomreiTorah.Billing.Properties;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;

namespace ShomreiTorah.Billing.Controls.Editors {
	public partial class PledgeLinksEdit : XtraUserControl {
		readonly MyController controller;

		public PledgeLinksEdit() {
			InitializeComponent();

			colLinkAmount.ColumnEditor = EditorRepository.CurrencyEditor.CreateItem();
			controller = new MyController();
			controller.DataChanged += delegate { UpdateSummary(); };
			pledgesGrid.DataMember = null;
		}


		///<summary>Releases the unmanaged resources used by the PledgeLinksEdit and optionally releases the managed resources.</summary>
		///<param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				controller.Dispose();
				if (components != null) components.Dispose();
			}
			base.Dispose(disposing);
		}

		///<summary>Gets or sets the payment to display links for.</summary>
		[Bindable(true)]
		public Payment HostPayment {
			get { return controller.CurrentPayment; }
			set {
				controller.CurrentPayment = value;
				pledgesGrid.Enabled = value != null;
				if (value == null)
					pledgesGrid.DataSource = null;
				else {
					pledgesGrid.DataSource = controller.Pledges;
					UpdateSummary();
				}
			}
		}

		public event EventHandler DataChanged {
			add { controller.DataChanged += value; }
			remove { controller.DataChanged -= value; }
		}

		public IList<PledgeLink> Links { get { return controller.Links; } }
		public PledgeLinksStatus Status { get { return controller.Status; } }
		///<summary>Indicates whether there are any available pledges which this payment does not fully compensate.</summary>
		public bool HasUnlinkedPledges { get { return controller.HasUnlinkedPledges; } }

		public void RefreshAll() {
			//In case the account or person changed
			controller.Pledges.Rescan();
			//Trigger all other changes
			controller.OnDataChanged();
			//In case the pledge link amounts changed
			pledgesGrid.RefreshDataSource();
		}

		#region Grid
		private void pledgesView_CustomSuperTip(object sender, CustomToolTipEventArgs e) {
			if (e.HitInfo.Column == colAmount && e.HitInfo.InRowCell) {
				var row = (Pledge)pledgesView.GetRow(e.HitInfo.RowHandle);
				if (row != null)
					e.SuperTip = Utilities.CreateSuperTip("Unpaid Amount", controller.GetUnlinkedAmountDescription(row));
			} else if (e.HitInfo.Column == colLinkAmount) {
				e.SuperTip = Utilities.CreateSuperTip("Amount to Link", "Enter the portion of this pledge that this payment is intended to pay.");
			}
		}

		private void pledgesView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
			//Before binding to a pledge grid, we can get weird results.
			if (!(e.Row is Pledge))
				return;
			if (e.Column == colAmount)
				e.Value = controller.GetUnlinkedAmount((Pledge)e.Row);
			else if (e.Column == colLinkAmount) {
				var pledge = (Pledge)e.Row;
				if (e.IsGetData)
					e.Value = controller.GetAmount(pledge);
				else {
					controller.SetAmount(pledge, (decimal)e.Value);
					controller.OnDataChanged();
				}
			}
		}
		private void pledgesView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e) {
			if (e.ListSourceRowIndex < 0)
				return;
			if (e.Column == colAmount)
				e.DisplayText = controller.GetUnlinkedAmountText(controller.Pledges.Rows[e.ListSourceRowIndex], (decimal)e.Value);
		}

		private void pledgesView_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e) {
			if (pledgesView.FocusedColumn != colLinkAmount)
				return;
			var pledge = (Pledge)pledgesView.GetFocusedRow();
			e.ErrorText = controller.GetErrorText(pledge, (decimal)e.Value);
			e.Valid = String.IsNullOrEmpty(e.ErrorText);
		}

		private void pledgesView_ValidateRow(object sender, ValidateRowEventArgs e) {
			var pledge = (Pledge)e.Row;
			e.ErrorText = controller.GetErrorText(pledge);
			e.Valid = String.IsNullOrEmpty(e.ErrorText);
		}

		private void pledgesView_RowStyle(object sender, RowStyleEventArgs e) {
			if (e.RowHandle < 0) return;
			var pledge = (Pledge)pledgesView.GetRow(e.RowHandle);
			bool isValid = String.IsNullOrEmpty(controller.GetErrorText(pledge));
			if (!isValid)
				e.Appearance.ForeColor = Color.Red;
		}
		#endregion

		#region Toolbar
		static Dictionary<PledgeLinksStatus, Image> statusIcons = new Dictionary<PledgeLinksStatus, Image> {
			{ PledgeLinksStatus.Empty,		Resources.StatusRed16	},
			{ PledgeLinksStatus.Partial,	Resources.StatusYellow16},
			{ PledgeLinksStatus.Complete,	Resources.StatusGreen16	},
			{ PledgeLinksStatus.Error,		Resources.StatusError16	},
		};

		void UpdateSummary() {
			//If the user hasn't set the amount of a new payment yet, do nothing.
			if (HostPayment == null || HostPayment.Person == null || HostPayment[Payment.AmountColumn] == null)
				return;

			var s = controller.GetPaymentSummary();
			paymentSummary.Caption = "Payment: " + s.Short;
			paymentSummary.SuperTip = Utilities.CreateSuperTip("Payment Information", s.Long);

			paymentSummary.Glyph = statusIcons[controller.Status];

			migratePledges.Visibility = controller.GetMemberPledges().Any() ? BarItemVisibility.Always : BarItemVisibility.OnlyInCustomizing;
		}

		private void clearLinks_ItemClick(object sender, ItemClickEventArgs e) {
			controller.Links.Clear();
			controller.OnDataChanged();
			pledgesGrid.RefreshDataSource();
		}

		private void fillLinks_ItemClick(object sender, ItemClickEventArgs e) {
			//See the button's tooltip for a detailed description of this method.

			if (HostPayment.Amount == Links.Sum(o => o.Amount)) {
				Dialog.Inform("This payment has already been completely linked.");
				return;
			}

			//Row handles are indexed by visual order, and include
			//all applicable rows, even collapsed group rows. It's
			//exactly what I need here.
			//http://documentation.devexpress.com/#WindowsForms/CustomDocument642

			controller.FillPledges(Enumerable.Range(0, pledgesView.RowCount)
											 .Select(pledgesView.GetRow)
											 .Cast<Pledge>()
								  );
			pledgesGrid.RefreshDataSource();
		}

		private void addDonation_ItemClick(object sender, ItemClickEventArgs e) {
			decimal paymentRemaining = HostPayment.Amount - Links.Sum(o => o.Amount);
			if (paymentRemaining == 0) {
				Dialog.Inform("This payment has already been completely linked; there is no need for a donation pledge.");
				return;
			}

			if (HasUnlinkedPledges) {
				if (!Dialog.Warn("There are still other pledges that have not been paid off.  Presumably, " + HostPayment.Person.FullName + " intended to pay them rather than creating a new donation.\r\n\r\nAre you sure you want to create a donation pledge anyway?"))
					return;
			}

			var pledge = new Pledge {
				Account = HostPayment.Account,
				Amount = paymentRemaining,
				Comments = "Automatically created donation pledge for " + HostPayment.Amount.ToString("c", CultureInfo.CurrentCulture) + " " + HostPayment.Method.ToLowerInvariant(),
				Date = HostPayment.Date,
				Person = HostPayment.Person,
				Type = "Donation"
			};
			Links.Add(new PledgeLink {
				Amount = paymentRemaining,
				Payment = HostPayment,
				Pledge = pledge,
			});
			Program.Table<Pledge>().Rows.Add(pledge);
		}


		private void migratePledges_ItemClick(object sender, ItemClickEventArgs e) {
			ShowMigrationDialog();
		}
		public void ShowMigrationDialog() {
			var memberPledges = controller.GetMemberPledges().ToList();

			if (!memberPledges.Any())
				return;

			using (var dialog = new Forms.PledgeMigrator(controller.Person, memberPledges)) {
				if (dialog.ShowDialog() != DialogResult.OK)
					return;

				controller.MovePledges(dialog.SelectedPledges);
				pledgesGrid.RefreshDataSource();
			}
		}
		#endregion

		private sealed class MyController : IDisposable {
			Payment currentPayment;

			public Person Person { get { return CurrentPayment == null ? null : CurrentPayment.Person; } }
			public string Account { get { return CurrentPayment == null ? null : CurrentPayment.Account; } }

			///<summary>Holds the PledgeLinks created for the current detached Payment.</summary>
			///<remarks>This collection is re-used to allow the Payment editor to re-bind 
			///the grid whenever the dropdown is shown, without losing all data.
			///
			/// Before switching to a new payment, this must be cleared.</remarks>
			IList<PledgeLink> detachedLinks = new List<PledgeLink>();

			public MyController() {
				Pledges = Program.Table<Pledge>().Filter(p => p.Person == Person && p.Account == Account);

				Pledges.RowAdded += delegate { OnDataChanged(); };
				Pledges.RowRemoved += delegate { OnDataChanged(); };
				Pledges.ValueChanged += (s, e) => { if (e.Column == Pledge.AmountColumn)OnDataChanged(); };
			}

			///<summary>A mutable wrapper around a ChildRowCollection, which adds and deletes rows from the underlying foreign table.</summary>
			private class ChildRowList<TChildRow> : IList<TChildRow> where TChildRow : Row {
				private readonly IChildRowCollection<TChildRow> rows;

				public ChildRowList(IChildRowCollection<TChildRow> rows) { this.rows = rows; }

				public bool Contains(TChildRow item) { return rows.Contains(item); }
				public void CopyTo(TChildRow[] array, int arrayIndex) { rows.CopyTo(array, arrayIndex); }
				public IEnumerator<TChildRow> GetEnumerator() { return rows.GetEnumerator(); }
				System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return GetEnumerator(); }
				public int IndexOf(TChildRow item) { return rows.IndexOf(item); }
				public int Count { get { return rows.Count; } }
				public bool IsReadOnly { get { return false; } }

				public void Insert(int index, TChildRow item) {
					throw new NotSupportedException();
				}
				public TChildRow this[int index] {
					get { return rows[index]; }
					set { throw new NotSupportedException(); }
				}

				public void Add(TChildRow row) {
					if (row == null) throw new ArgumentNullException("row");

					if (row[rows.Relation.ChildColumn] != rows.ParentRow)
						throw new ArgumentException("New child rows must already be assigned their parent", "row");

					rows.ChildTable.Rows.Add(row);
					Debug.Assert(Contains(row), "Row did not get added to CRC");
				}

				public bool Remove(TChildRow item) {
					if (!Contains(item))
						return false;
					item.RemoveRow();
					return true;
				}
				public void RemoveAt(int index) {
					this[index].RemoveRow();
				}
				public void Clear() {
					//Calling RemoveRow() will remove the row from the ChildRowCollection.
					for (int i = Count - 1; i >= 0; i--)
						this[i].RemoveRow();

					Debug.Assert(Count == 0, "RemoveRow() didn't empty the CRC");
				}
			}

			public Payment CurrentPayment {
				get { return currentPayment; }
				set {
					if (value != null && Links == detachedLinks && detachedLinks.Any(o => o.Payment != value))
						throw new InvalidOperationException("Before switching Payments, the detached Links collection must be cleared.");
					currentPayment = value;

					if (value == null) {
						if (Links != detachedLinks)
							Links = null;
						return;
					}

					if (value.Table == null)
						Links = detachedLinks;
					else
						Links = new ChildRowList<PledgeLink>(value.LinkedPledges);

					Pledges.Rescan();
				}
			}
			public IList<PledgeLink> Links { get; private set; }
			public FilteredTable<Pledge> Pledges { get; private set; }

			///<summary>Occurs when the pledges, links or payment data changes.</summary>
			public event EventHandler DataChanged;
			///<summary>Raises the DataChanged event.</summary>
			internal void OnDataChanged() { OnDataChanged(EventArgs.Empty); }
			///<summary>Raises the DataChanged event.</summary>
			///<param name="e">An EventArgs object that provides the event data.</param>
			internal void OnDataChanged(EventArgs e) {
				if (DataChanged != null)
					DataChanged(this, e);
			}

			public void Dispose() {
				Pledges.Dispose();
			}

			public IEnumerable<Pledge> GetMemberPledges() {
				return Person.RelatedMembers
								.SelectMany(r => r.Member.Pledges.Where(p => new AliyahNote(p.Note).Relative == r.RelationType));
			}
			///<summary>Moves a collection of pledges from a member to a relative.</summary>
			public void MovePledges(IEnumerable<Pledge> pledges) {
				foreach (var pledge in pledges) {
					//Move the relative from the Note to the Comments
					var note = new AliyahNote(pledge.Note);
					pledge.Comments = ("Moved from " + pledge.Person.FullName + " to his " + note.Relative.ToLower() + "\r\n" + pledge.Comments).Trim();

					note.Relative = null;
					pledge.Note = note.Text;	//Without the relative

					pledge.Person = this.Person;
				}
				FillPledges(pledges.OrderByDescending(p => p.Date));
			}

			///<summary>Fills the links of an ordered collection of pledges with any remaining unlinked amount in this payment.</summary>
			public void FillPledges(IEnumerable<Pledge> pledges) {
				decimal paymentRemaining = CurrentPayment.Amount - Links.Sum(o => o.Amount);

				foreach (var pledge in pledges) {
					var linkedToUs = GetAmount(pledge);
					var unlinked = GetUnlinkedAmount(pledge) - linkedToUs;

					var additional = Math.Min(paymentRemaining, unlinked);

					SetAmount(pledge, linkedToUs + additional);
					paymentRemaining -= additional;

					if (paymentRemaining == 0)
						break;
				}

				OnDataChanged();
			}


			#region Linked Amount Texts
			///<summary>Gets the portion of a pledge that has not already been linked to other payments.  This will not include the portion linked to this payment, even when editing existing payments.</summary>
			public decimal GetUnlinkedAmount(Pledge pledge) {
				//Unlike, GetAmountDescription(), I don't need ToList()
				var payments = pledge.LinkedPayments.Where(o => o.Payment != CurrentPayment);
				return pledge.Amount - payments.Sum(p => p.Amount);
			}

			public string GetUnlinkedAmountText(Pledge pledge, decimal unlinkedAmount) {
				return String.Format(CultureInfo.CurrentCulture,
									 "<color=gray>{0:c} − {1:c} =</color> {2:c}",
									 pledge.Amount, pledge.Amount - unlinkedAmount, unlinkedAmount);
			}
			public string GetUnlinkedAmountDescription(Pledge pledge) {
				var payments = pledge.LinkedPayments.Where(o => o.Payment != CurrentPayment).ToList();
				decimal linkedAmount = payments.Sum(p => p.Amount);
				if (linkedAmount == 0)
					return String.Format(CultureInfo.CurrentCulture,
										 "This pledge was for {0:c}.\r\nIt has not been linked to any other payments.",
										 pledge.Amount);
				else if (linkedAmount == pledge.Amount)
					return String.Format(CultureInfo.CurrentCulture,
										 "This pledge was for {0:c}.\r\nThe entire amount has already been linked to {1} other payment{2}.",
										 pledge.Amount, payments.Count, payments.Count == 1 ? "" : "s");
				else
					return String.Format(CultureInfo.CurrentCulture,
										 "This pledge was for {0:c}.\r\nOf that amount, {1:c} have already been linked to {2} other payment{3}.\r\n{4:c} is unlinked.",
										 pledge.Amount, linkedAmount, payments.Count, payments.Count == 1 ? "" : "s", pledge.Amount - linkedAmount);
			}
			#endregion

			#region Mutable Amount
			///<summary>Gets the portion of a pledge to link to this payment.</summary>
			public decimal GetAmount(Pledge pledge) {
				//FirstOrDefault() will return 0 if there are no rows.
				return Links.Where(o => o.Pledge == pledge)
							.Select(o => o.Amount)
							.FirstOrDefault();
			}
			///<summary>Sets the portion of a pledge to link to this payment.</summary>
			public void SetAmount(Pledge pledge, decimal value) {
				var link = Links.FirstOrDefault(o => o.Pledge == pledge);

				if (value == 0) {
					Links.Remove(link);
				} else {
					if (link != null)
						link.Amount = value;
					else
						Links.Add(new PledgeLink { Pledge = pledge, Payment = CurrentPayment, Amount = value });
				}
			}
			#endregion

			public PledgeLinksStatus Status {
				get {
					if (Links.Any(o => !String.IsNullOrEmpty(GetErrorText(o.Pledge))))
						return PledgeLinksStatus.Error;

					decimal linked = Links.Sum(o => o.Amount);
					if (linked == 0)
						return PledgeLinksStatus.Empty;
					else if (linked == CurrentPayment.Amount)
						return PledgeLinksStatus.Complete;
					else if (linked > CurrentPayment.Amount)
						return PledgeLinksStatus.Error;
					else
						return PledgeLinksStatus.Partial;
				}
			}

			///<summary>Indicates whether there are any available pledges which this payment does not fully compensate.</summary>
			public bool HasUnlinkedPledges {
				get {
					return Pledges.Rows.Any(r => GetAmount(r) < GetUnlinkedAmount(r));
				}
			}

			public SummaryInfo GetPaymentSummary() {
				var linked = Links.Sum(o => o.Amount);
				var personBalance = CurrentPayment.Person.Transactions.Where(t => t.Account == CurrentPayment.Account)
																	  .Sum(t => t.SignedAmount);

				if (currentPayment.Table != null)
					personBalance += CurrentPayment.Amount;

				return new SummaryInfo {
					Short = String.Format(CultureInfo.CurrentCulture,
										  "{0:c} − {1:c} = {2:c}",
										  CurrentPayment.Amount, linked, currentPayment.Amount - linked),
					Long = String.Format(CultureInfo.CurrentCulture,
										 "{0:c} of this {1:c} payment is linked to {2} pledge{3}.\r\n{4:c} remain unaccounted for.\r\n\r\n{5} owe {6:c} for the {7} account (before accounting for this payment).",
										 linked, CurrentPayment.Amount, Links.Count, Links.Count > 1 ? "s" : "", currentPayment.Amount - linked,
										 CurrentPayment.Person.FullName, personBalance, CurrentPayment.Account)
				};
			}

			///<summary>Checks whether a proposed amount is valid for a linked pledge.</summary>
			///<param name="pledge">The pledge to check for.</param>
			///<param name="newAmount">The new amount specified by the user, or null (optional) to check the current amount.</param>
			///<returns>An error message, or null if the pledge is valid.</returns>
			public string GetErrorText(Pledge pledge, decimal? newAmount = null) {
				newAmount = newAmount ?? GetAmount(pledge);

				if (newAmount < 0)
					return "Amount to link cannot be negative.  If you don't want to link this payment, set it to zero.";
				if (newAmount > CurrentPayment.Amount)
					return "Amount to link cannot be more than the entire payment.";
				if (newAmount > pledge.Amount)
					return "Amount to link cannot be more than the amount of the pledge.";
				if (newAmount > GetUnlinkedAmount(pledge))
					return "Amount to link cannot be more than the portion of the pledge that has not already been linked to other payments";

				return null;
			}
		}
		class SummaryInfo {
			public string Short { get; set; }
			public string Long { get; set; }
		}
	}

	public enum PledgeLinksStatus {
		///<summary>The payment has no linked pledges.</summary>
		Empty,
		///<summary>Only some of the amount of the payment is linked.</summary>
		Partial,
		///<summary>The payment is completely linked.</summary>
		Complete,

		///<summary>The links are invalid.</summary>
		Error
	}
}
