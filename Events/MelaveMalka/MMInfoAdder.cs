using System;
using System.Drawing;
using System.Linq;
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

			if ((honoree2.SelectedPerson == null) != (String.IsNullOrWhiteSpace(honoree2Title.Text))) {
				Dialog.ShowError("If there is a secondary honoree, you must enter the honoree and the title.");
				return;
			}

			Program.Table<MelaveMalkaInfo>().Rows.Add(new MelaveMalkaInfo {
				Year = (int)year.Value,

				Honoree = honoree.SelectedPerson,
				HonoreeTitle = honoreeTitle.Text,

				Honoree2 = honoree2.SelectedPerson,
				Honoree2Title = honoree2Title.Text,

				Speaker = speaker.Text,
				MelaveMalkaDate = melaveMalkaDate.DateTime + ((DateTime)mmTime.EditValue).TimeOfDay,
				AdDeadline = adDeadline.DateTime
			});
			Dispose();
		}
	}
}