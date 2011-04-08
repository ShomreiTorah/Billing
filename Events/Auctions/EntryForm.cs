using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ShomreiTorah.Data;
using System.Globalization;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using ShomreiTorah.WinForms;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;

namespace ShomreiTorah.Billing.Events.Auctions {
	partial class EntryForm : XtraForm {
		readonly DXPopupMenu recentMenu;
		readonly EditorButton recentButton;
		public EntryForm() {
			InitializeComponent();
			UpdateSummary();

			personSelector.Properties.Buttons.Add(recentButton = new EditorButton {
				Caption = "Recent",
				ImageLocation = ImageLocation.MiddleRight,
				Kind = ButtonPredefines.DropDown,
				Shortcut = new KeyShortcut(Keys.Control | Keys.R),
				SuperTip = Utilities.CreateSuperTip(title: "Recent people", body: "Shows people whom you've already selected in this session."),
				Visible = false
			});
			recentMenu = new DXPopupMenu();
		}

		///<summary>Releases the unmanaged resources used by the EntryForm and optionally releases the managed resources.</summary>
		///<param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				recentMenu.Dispose();
				if (components != null) components.Dispose();
			}
			base.Dispose(disposing);
		}

		void AddRecentMenuItem(Person person) {
			if (recentMenu.Items.Cast<DXMenuItem>().Any(m => m.Tag == person))
				return;
			recentMenu.Items.Insert(0,
				new DXMenuItem(person.FullName, delegate { personSelector.EditValue = person; }) {
					ShowHotKeyPrefix = false,
					Tag = person
				}
			);
			recentButton.Visible = true;
		}
		private void personSelector_ButtonPressed(object sender, ButtonPressedEventArgs e) {
			if (e.Button.Index == recentButton.Index) {
				if (recentMenu.OwnerPopup != null)
					recentMenu.HidePopup();
				else {
					var evi = personSelector.GetViewInfo() as ButtonEditViewInfo;
					var bvi = evi.ButtonInfoByButton(e.Button);
					var pt = new Point(bvi.Bounds.Left, bvi.Bounds.Bottom);

					MenuManagerHelper.GetMenuManager(LookAndFeel).ShowPopupMenu(recentMenu, personSelector, pt);
				}
			}
		}

		private void groupSelector_SelectionChanged(object sender, EventArgs e) { SetGroup(); }
		private void personSelector_EditValueChanged(object sender, EventArgs e) { SetGroup(); }

		protected override void OnFormClosing(FormClosingEventArgs e) {
			base.OnFormClosing(e);
			e.Cancel = !ConfirmChange();
		}

		private bool ConfirmChange() {
			if (!entryGrid.HasChanges())
				return true;
			switch (Dialog.Show("Do you want to save your changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)) {
				case DialogResult.Yes:
					SaveChanges();
					return true;
				case DialogResult.No:
					return true;

				case DialogResult.Cancel:
					isReverting = true;
					groupSelector.SetSelection(currentYear, currentGroup);
					personSelector.EditValue = entryGrid.CurrentPerson;	//Go back to the current selection.  This won't recurse due to isReverting.
					isReverting = false;
					return false;

				default:
					throw new InvalidProgramException();
			}
		}
		private AuctionGroup currentGroup;
		private int currentYear;
		private bool isReverting;
		void SetGroup(bool confirm = true) {
			if (isReverting)	//Prevent recursion if the user hits Cancel
				return;
			if (confirm && !ConfirmChange())
				return;

			currentGroup = groupSelector.SelectedGroup;
			currentYear = groupSelector.SelectedYear;

			if (personSelector.SelectedPerson == null) {
				entryGrid.Hide();
				UpdateSummary();	//Even if no person is selected, we still need to update the summary for the entire group
				return;
			}
			AddRecentMenuItem(personSelector.SelectedPerson);	//If the person didn't change, this is a no-op.

			entryGrid.BindTo(groupSelector.SelectedGroup.Auctions
								.SelectMany(a => a.CreateItems(groupSelector.SelectedYear, personSelector.SelectedPerson))
			);
			entryGrid.Show();
			UpdateSummary();
		}

		private void save_Click(object sender, EventArgs e) {
			SaveChanges();
			personSelector.SelectedPerson = null;
			personSelector.Focus();
		}
		void SaveChanges() {
			entryGrid.CommitChanges();
			Program.Current.SaveDatabase();
		}
		private void cancel_Click(object sender, EventArgs e) {
			if (Dialog.Warn("Are you sure you want to discard your changes?"))
				SetGroup(confirm: false);	//This will re-bind the grid and discard all changes.
		}

		#region Summaries
		private void entryGrid_SummaryChanged(object sender, EventArgs e) { UpdateSummary(); }
		void UpdateSummary() {
			var summary = new StringBuilder();

			decimal personTotal = 0;
			int personמתנות = 0;
			#region This Person
			if (personSelector.SelectedPerson != null) {
				personTotal = entryGrid.TotalPledged;
				personמתנות = entryGrid.מתנהCount;

				summary.AppendFormat(CultureInfo.CurrentCulture, "{0:c} for ", personTotal);
				summary.Append(personSelector.SelectedPerson.FullName);
				if (personמתנות > 0) {
					summary.Append(", plus ").Append(personמתנות);
					if (personמתנות == 1)
						summary.Append(" מתנה");
					else
						summary.Append(" מתנות");
				}
				summary.AppendLine();
			}
			#endregion
			//For the grand totals, we don't need time matches
			//This way, we also catch pledges entered manually
			//without our custom times.
			#region Everything
			var allPledges = Program.Table<Pledge>().Rows
					.Where(p => p.Person != personSelector.SelectedPerson	//These pledges are already in the grid; don't double-count them.
							 && (p.Type == "Auction" || p.Type == "מי שברך")
							 && groupSelector.SelectedGroup.Auctions.Any(
									g => p.Date.Date == g.Date.GetDate(groupSelector.SelectedYear)
								)
						  ).ToList();

			summary.AppendFormat(CultureInfo.CurrentCulture, "Total: {0:c}", personTotal + allPledges.Sum(p => p.Amount));
			var mc = personמתנות + allPledges.Count(p => new AliyahNote(p.Note).Isמתנה);
			if (mc > 0) {
				summary.Append(", plus ").Append(mc);
				if (mc == 1)
					summary.Append(" מתנה");
				else
					summary.Append(" מתנות");
			}
			#endregion
			summary.AppendLine();
			#region Last Year
			var lastYearsPledges = Program.Table<Pledge>().Rows
					.Where(p => (p.Type == "Auction" || p.Type == "מי שברך")
							 && groupSelector.SelectedGroup.Auctions.Any(
									g => p.Date.Date == g.Date.GetDate(groupSelector.SelectedYear - 1)
								)
						  );

			summary.AppendFormat(CultureInfo.CurrentCulture, "Last year's total: {0:c}", lastYearsPledges.Sum(p => p.Amount));
			#endregion

			summaryLabel.Text = summary.ToString();
		}
		#endregion
	}
}