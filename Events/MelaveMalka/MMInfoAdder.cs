using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ShomreiTorah.Common.Calendar;
using ShomreiTorah.Data;
using ShomreiTorah.WinForms;
namespace ShomreiTorah.Billing.Events.MelaveMalka {
	partial class MMInfoAdder : DevExpress.XtraEditors.XtraForm {
		public MMInfoAdder() {
			Program.LoadTable<MelaveMalkaInfo>();
			InitializeComponent();
			year.EditValue = DateTime.Now.AddMonths(6).Year;
			while (Program.Table<MelaveMalkaInfo>().Rows.Any(m => m.Year == year.Value))
				year.Value++;
		}

		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			MinimumSize = new Size(MinimumSize.Width, Height);	//Adjust for skinned titlebars
		}

		private void year_EditValueChanged(object sender, EventArgs e) {
			if (melaveMalkaDate.EditValue is DateTime)
				melaveMalkaDate.DateTime = new DateTime((int)year.Value, melaveMalkaDate.DateTime.Month, melaveMalkaDate.DateTime.Day)
											.Next(DayOfWeek.Saturday);
			else
				melaveMalkaDate.DateTime = new DateTime((int)year.Value, 1, 20).Next(DayOfWeek.Saturday);
			adDeadline.DateTime = melaveMalkaDate.DateTime.AddDays(-10).Last(DayOfWeek.Monday);
		}

		private void ok_Click(object sender, EventArgs e) {
			if (Program.Table<MelaveMalkaInfo>().Rows.Any(m => m.Year == year.Value)) {
				Dialog.ShowError("Melave Malka info has already been added for " + year.Value);
				return;
			}
			if (honoree.SelectedPerson == null) {
				Dialog.ShowError("Please choose a guest of honor.");
				return;
			}
			if (String.IsNullOrWhiteSpace(speaker.Text)) {
				Dialog.ShowError("Please enter the guest speaker.");
				return;
			}

			Program.Table<MelaveMalkaInfo>().Rows.Add(new MelaveMalkaInfo {
				Year = (int)year.Value,
				Honoree = honoree.SelectedPerson,
				Speaker = speaker.Text,
				MelaveMalkaDate = melaveMalkaDate.DateTime,
				AdDeadline = adDeadline.DateTime
			});
			Dispose();
		}
	}
}