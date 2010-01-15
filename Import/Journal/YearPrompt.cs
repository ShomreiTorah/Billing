using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ShomreiTorah.Billing.Import.Journal {
	partial class YearPrompt : XtraForm {
		public YearPrompt() {
			InitializeComponent();
			if (DateTime.Today.Month == 12)
				year.Value = DateTime.Today.Year + 1;
			else
				year.Value = DateTime.Today.Year;
		}

		public static int Prompt() {
			using (var dialog = new YearPrompt()) {
				return dialog.ShowDialog() == DialogResult.OK ? (int)dialog.year.Value : -1;
			}
		}
	}
}