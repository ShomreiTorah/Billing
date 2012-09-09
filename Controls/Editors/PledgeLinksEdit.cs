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

namespace ShomreiTorah.Billing.Controls.Editors {
	public partial class PledgeLinksEdit : XtraUserControl {
		readonly MyController controller;

		public PledgeLinksEdit() {
			InitializeComponent();

			colLinkAmount.ColumnEditor = EditorRepository.CurrencyEditor.CreateItem();
		}

		private void pledgesView_CustomSuperTip(object sender, CustomToolTipEventArgs e) {
			if (e.HitInfo.Column == colLinkAmount && e.HitInfo.InRowCell) {
				var row = pledgesView.GetRow(e.HitInfo.RowHandle);

			}
		}

		private void pledgesView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
			if (e.Column == colAmount)
				e.Value = controller.GetLinkedAmount((Pledge)e.Row);
			else if (e.Column == colLinkAmount) {
			}
		}
		private void pledgesView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e) {
			if (e.Column == colAmount)
				e.DisplayText = controller.GetLinkedAmountText(controller.Pledges.Rows[e.ListSourceRowIndex], (decimal)e.Value);
		}

		private class MyController {
			readonly Payment currentPayment;

			public FilteredTable<Pledge> Pledges { get; private set; }

			public void Refresh() {
				Pledges = Program.Table<Pledge>().Filter(p => p.Person == currentPayment.Person && p.Account == currentPayment.Account);
			}

			#region Linked Amount Texts
			public decimal GetLinkedAmount(Pledge pledge) {
				//Unlike, GetAmountDescription(), I don't need ToList()
				var payments = pledge.LinkedPayments.Where(o => o.Payment != currentPayment);
				return payments.Sum(p => p.Amount);
			}

			public string GetLinkedAmountText(Pledge pledge, decimal linkedAmount) {
				return String.Format(CultureInfo.CurrentCulture,
									 "{0:c} − {1:c} = {2:c}",
									 pledge.Amount, linkedAmount, pledge.Amount - linkedAmount);
			}
			public string GetLinkedAmountDescription(Pledge pledge) {
				var payments = pledge.LinkedPayments.Where(o => o.Payment != currentPayment).ToList();
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
		}

	}
}
