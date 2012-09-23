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

namespace ShomreiTorah.Billing.Controls.Editors {
	public partial class PledgeLinksEdit : XtraUserControl {
		readonly MyController controller;

		public PledgeLinksEdit() {
			InitializeComponent();

			colLinkAmount.ColumnEditor = EditorRepository.CurrencyEditor.CreateItem();
			controller = new MyController();
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

		public IList<PledgeLink> Links { get { return controller.Links; } }

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
					UpdateSummary();
				}
			}
		}
		private void pledgesView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e) {
			if (e.ListSourceRowIndex < 0)
				return;
			if (e.Column == colAmount)
				e.DisplayText = controller.GetUnlinkedAmountText(controller.Pledges.Rows[e.ListSourceRowIndex], (decimal)e.Value);
		}
		#endregion

		#region Toolbar
		void UpdateSummary() {
			var s = controller.GetPaymentSummary();
			paymentSummary.Caption = "Payment: " + s.Short;
			paymentSummary.SuperTip = Utilities.CreateSuperTip("Payment Information", s.Long);
		}
		#endregion

		private sealed class MyController : IDisposable {
			Payment currentPayment;
			Person person;
			string account;

			///<summary>Holds the PledgeLinks created for the current detached Payment.</summary>
			///<remarks>This collection is re-used to allow the Payment editor to re-bind 
			///the grid whenever the dropdown is shown, without losing all data.
			///
			/// Before switching to a new payment, this must be cleared.</remarks>
			IList<PledgeLink> detachedLinks = new List<PledgeLink>();

			public MyController() {
				Pledges = Program.Table<Pledge>().Filter(p => p.Person == person && p.Account == account);
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
					person = value.Person;
					account = value.Account;
					Pledges.Rescan();

					if (value.Table == null)
						Links = detachedLinks;
					else
						Links = new ChildRowList<PledgeLink>(value.LinkedPledges);
				}
			}
			public IList<PledgeLink> Links { get; private set; }
			public FilteredTable<Pledge> Pledges { get; private set; }

			public void Dispose() {
				Pledges.Dispose();
			}

			#region Linked Amount Texts
			public decimal GetUnlinkedAmount(Pledge pledge) {
				//Unlike, GetAmountDescription(), I don't need ToList()
				var payments = pledge.LinkedPayments.Where(o => o.Payment != CurrentPayment);
				return pledge.Amount - payments.Sum(p => p.Amount);
			}

			public string GetUnlinkedAmountText(Pledge pledge, decimal unlinkedAmount) {
				return String.Format(CultureInfo.CurrentCulture,
									 "{0:c} − {1:c} = {2:c}",
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
			public decimal GetAmount(Pledge pledge) {
				//FirstOrDefault() will return 0 if there are no rows.
				return Links.Where(o => o.Pledge == pledge)
							.Select(o => o.Amount)
							.FirstOrDefault();
			}
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
		}
		class SummaryInfo {
			public string Short { get; set; }
			public string Long { get; set; }
		}

		private void clearLinks_ItemClick(object sender, ItemClickEventArgs e) {
			controller.Links.Clear();
			UpdateSummary();
			pledgesGrid.RefreshDataSource();
		}

		private void fillLinks_ItemClick(object sender, ItemClickEventArgs e) {
			//See the button's tooltip for a detailed description of this method.

			decimal paymentRemaining = HostPayment.Amount - Links.Sum(o => o.Amount);
			if (paymentRemaining == 0) {
				Dialog.Inform("This payment has already been completely linked");
				return;
			}

			//Row handles are indexed by visual order, and include
			//all applicable rows, even collapsed group rows. It's
			//exactly what I need here.
			//http://documentation.devexpress.com/#WindowsForms/CustomDocument642
			for (int i = 0; i < pledgesView.RowCount; i++) {
				var pledge = (Pledge)pledgesView.GetRow(i);

				var linkedToUs = controller.GetAmount(pledge);
				var unlinked = controller.GetUnlinkedAmount(pledge) - linkedToUs;

				var additional = Math.Min(paymentRemaining, unlinked);

				controller.SetAmount(pledge, linkedToUs + additional);
				paymentRemaining -= additional;

				if (paymentRemaining == 0)
					break;
			}

			UpdateSummary();
			pledgesGrid.RefreshDataSource();
		}
	}
}
