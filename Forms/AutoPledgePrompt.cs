using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ShomreiTorah.Data;

namespace ShomreiTorah.Billing.Forms {
	partial class AutoPledgePrompt : XtraForm {
		public AutoPledgePrompt(Payment newRow) {
			InitializeComponent();

			var due = newRow.Person.GetBalance(newRow.Account);
			message.Text = String.Format(CultureInfo.CurrentCulture, @"{0} has {1:c} due for the {2}, and you are adding a {3:c} payment.
What would you like to do?", newRow.Person.FullName, due, newRow.Account.ToLower(CultureInfo.CurrentCulture), newRow.Amount);
			addAutoPledge.Text = String.Format(CultureInfo.CurrentCulture, @"Add a {0:c} donation pledge", newRow.Amount - due);
		}
	}
}