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
				else
					pledgesGrid.DataSource = controller.Pledges;
			}
		}

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
				else
					controller.SetAmount(pledge, (decimal)e.Value);
			}
		}
		private void pledgesView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e) {
			if (e.ListSourceRowIndex < 0)
				return;
			if (e.Column == colAmount)
				e.DisplayText = controller.GetUnlinkedAmountText(controller.Pledges.Rows[e.ListSourceRowIndex], (decimal)e.Value);
		}

		private sealed class MyController : IDisposable {
			Payment currentPayment;
			Person person;
			string account;

			public MyController() {
				Pledges = Program.Table<Pledge>().Filter(p => p.Person == person && p.Account == account);
			}

			public Payment CurrentPayment {
				get { return currentPayment; }
				set {
					currentPayment = value;

					if (value == null)
						return;
					person = value.Person;
					account = value.Account;
					Pledges.Rescan();
				}
			}
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

			public decimal GetAmount(Pledge pledge) {
				//FirstOrDefault() will return 0 if there are no rows.
				return pledge.LinkedPayments
									 .Where(o => o.Payment == currentPayment)
									 .Select(o => o.Amount)
									 .FirstOrDefault();
			}
			public void SetAmount(Pledge pledge, decimal value) {
				var link = pledge.LinkedPayments.FirstOrDefault(o => o.Payment == currentPayment);

				if (value == 0) {
					Program.Table<PledgeLink>().Rows.Remove(link);
				} else {
					if (link != null)
						link.Amount = value;
					else
						Program.Table<PledgeLink>().Rows.Add(new PledgeLink { Pledge = pledge, Payment = CurrentPayment, Amount = value });
				}
			}
		}
	}
}
