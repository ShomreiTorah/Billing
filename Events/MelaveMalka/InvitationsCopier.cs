using System;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ShomreiTorah.Data;
using ShomreiTorah.WinForms;

namespace ShomreiTorah.Billing.Events.MelaveMalka {
	public partial class InvitationsCopier : XtraForm {
		public static void Execute(int toYear) {
			Program.LoadTable<MelaveMalkaInvitation>();
			var sourceYears = Program.Table<MelaveMalkaInvitation>()
				.Rows.Select(r => r.Year)
					 .Where(y => y != toYear)
					 .Distinct()
					 .ToArray();

			if (sourceYears.Length == 0) {
				Dialog.ShowError("There are no years to copy from.");
				return;
			}

			new InvitationsCopier(toYear, sourceYears).ShowDisposingDialog();
		}

		readonly int toYear;
		private InvitationsCopier(int toYear, int[] fromYears) {
			InitializeComponent();

			this.toYear = toYear;

			Text = "Copy Invitations to " + toYear;
			sourceYear.Properties.Items.AddRange(fromYears);
			sourceYear.Properties.DropDownRows = fromYears.Length;
			sourceYear.SelectedItem = fromYears.Where(y => y < toYear).DefaultIfEmpty(fromYears[0]).Max();

			copySources.Items.AddRange(Names.MelaveMalkaSources.ToArray());
			copySources.SetItemChecked(0, true);
			copySources.SetItemChecked(1, true);
		}

		private void copySources_ItemCheck(object sender, ItemCheckEventArgs e) {
			doCopy.Enabled = copySources.CheckedItemsCount > 0;
		}

		private void doCopy_Click(object sender, System.EventArgs e) {
			var from = (int)sourceYear.SelectedItem;
			var sources = copySources.CheckedItems.Cast<CheckedListBoxItem>().Select(i => (string)i.Value).ToList();

			int count = 0;
			foreach (var s in Program.Table<MelaveMalkaInvitation>().Rows
									 .Where(r => r.Year == from && sources.Contains(r.Source, StringComparer.OrdinalIgnoreCase)).ToList()) {
				if (Program.Table<MelaveMalkaInvitation>().Rows.Any(r => r.Year == toYear && r.Person == s.Person))
					continue;
				Program.Table<MelaveMalkaInvitation>().Rows.Add(new MelaveMalkaInvitation {
					Person = s.Person,
					Year = toYear,
					DateAdded = DateTime.Now,
					ShouldCall = s.ShouldCall,
					ShouldEmail = s.ShouldEmail,
					Source = s.Source
				});
				count++;
			}
			if (count == 0)
				Dialog.Inform("No people were copied");
			else if (count == 1)
				Dialog.Inform("One invitation was copied");
			else
				Dialog.Inform(count + " invitations were copied");
		}
	}
}