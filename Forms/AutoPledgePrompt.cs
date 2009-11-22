using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Globalization;

namespace ShomreiTorah.Billing.Forms {
	partial class AutoPledgePrompt : XtraForm {
		public AutoPledgePrompt(BillingData.PaymentsRow newRow) {
			InitializeComponent();

			var due = newRow.MasterDirectoryRow.GetBalance(newRow.Account);
			message.Text = String.Format(CultureInfo.CurrentUICulture, @"{0} has {1:c} due for the {2}, and you are adding a {3:c} payment.
What would you like to do?", newRow.MasterDirectoryRow.FullName, due, newRow.Account.ToLower(CultureInfo.CurrentUICulture), newRow.Amount);
			addAutoPledge.Text = String.Format(CultureInfo.CurrentUICulture, @"Add a {0:c} donation pledge", newRow.Amount - due);
		}
	}
}