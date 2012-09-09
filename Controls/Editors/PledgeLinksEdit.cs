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
		}

		///<summary>Gets or sets the payment to display links for.</summary>
		public Payment HostPayment {
			get { return controller.CurrentPayment; }
			set {
				controller.CurrentPayment = value;
				pledgesGrid.DataSource = controller.Pledges;
				pledgesGrid.DataMember = null;
			}
		}

		private void pledgesView_CustomSuperTip(object sender, CustomToolTipEventArgs e) {
			if (e.HitInfo.Column == colAmount && e.HitInfo.InRowCell) {
				var row = (Pledge)pledgesView.GetRow(e.HitInfo.RowHandle);
				if (row != null)
					e.SuperTip = Utilities.CreateSuperTip("Unpaid Amount", controller.GetLinkedAmountDescription(row));
			} else if (e.HitInfo.Column == colLinkAmount) {
				e.SuperTip = Utilities.CreateSuperTip("Amount to Link", "Enter the portion of this pledge that this payment is intended to pay.");
			}
		}

		private void pledgesView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
			if (e.Column == colAmount)
				e.Value = controller.GetLinkedAmount((Pledge)e.Row);
			else if (e.Column == colLinkAmount) {
				var pledge = (Pledge)e.Row;
				if (e.IsGetData)
					e.Value = controller.GetAmount(pledge);
				else
					controller.SetAmount(pledge, (decimal)e.Value);
			}
		}
		private void pledgesView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e) {
			if (e.Column == colAmount)
				e.DisplayText = controller.GetLinkedAmountText(controller.Pledges.Rows[e.ListSourceRowIndex], (decimal)e.Value);
		}

		private class MyController {
			Payment currentPayment;

			public Payment CurrentPayment {
				get { return currentPayment; }
				set {
					currentPayment = value;
					Pledges = Program.Table<Pledge>().Filter(p => p.Person == CurrentPayment.Person && p.Account == CurrentPayment.Account);
				}
			}
			public FilteredTable<Pledge> Pledges { get; private set; }

			#region Linked Amount Texts
			public decimal GetLinkedAmount(Pledge pledge) {
				//Unlike, GetAmountDescription(), I don't need ToList()
				var payments = pledge.LinkedPayments.Where(o => o.Payment != CurrentPayment);
				return payments.Sum(p => p.Amount);
			}

			public string GetLinkedAmountText(Pledge pledge, decimal linkedAmount) {
				return String.Format(CultureInfo.CurrentCulture,
									 "{0:c} − {1:c} = {2:c}",
									 pledge.Amount, linkedAmount, pledge.Amount - linkedAmount);
			}
			public string GetLinkedAmountDescription(Pledge pledge) {
				var payments = pledge.LinkedPayments.Where(o => o.Payment != CurrentPayment).ToList();
				decimal linkedAmount = payments.Sum(p => p.Amount);
				if (linkedAmount == 0)
					return String.Format(CultureInfo.CurrentCulture,
										 "This pledge was for {0:c}.\r\nIt has not been linked to any payments.",
										 pledge.Amount);
				else if (linkedAmount == pledge.Amount)
					return String.Format(CultureInfo.CurrentCulture,
										 "This pledge was for {0:c}.\r\nThe entire amount has already been linked to {1} payment{2}.",
										 pledge.Amount, payments.Count, payments.Count == 1 ? "" : "s");
				else
					return String.Format(CultureInfo.CurrentCulture,
										 "This pledge was for {0:c}.\r\nOf that amount, {1:c} have already been linked to {2} payment{3}.\r\n{4:c} is unlinked.",
										 pledge.Amount, linkedAmount, payments.Count, payments.Count == 1 ? "" : "s", pledge.Amount - linkedAmount);
			}
			#endregion

			public decimal GetAmount(Pledge pledge) {
				//FirstOrDefault() will return 0 if there are no rows.
				return CurrentPayment.LinkedPledges
									 .Where(o => o.Pledge == pledge)
									 .Select(o => o.Amount)
									 .FirstOrDefault();
			}
			public void SetAmount(Pledge pledge, decimal value) {
				var link = CurrentPayment.LinkedPledges.FirstOrDefault(o => o.Pledge == pledge);

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
