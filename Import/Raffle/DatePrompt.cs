using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ShomreiTorah.Common.Calendar;

namespace ShomreiTorah.Billing.Import.Raffle {
	partial class DatePrompt : DevExpress.XtraEditors.XtraForm {
		DatePrompt() {
			InitializeComponent();
			date.DateTime = DateTime.Today.Last(DayOfWeek.Saturday);
		}

		public static DateTime? Prompt() {
			using (var dialog = new DatePrompt()) {
				return dialog.ShowDialog() == DialogResult.OK ? dialog.date.DateTime : new DateTime?();
			}
		}
	}
}