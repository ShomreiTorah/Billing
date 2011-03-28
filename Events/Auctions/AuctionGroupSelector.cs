using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ShomreiTorah.Common;
using ShomreiTorah.Common.Calendar;

namespace ShomreiTorah.Billing.Events.Auctions {
	partial class AuctionGroupSelector : XtraUserControl {
		public AuctionGroupSelector() {
			InitializeComponent();

			var today = HebrewDate.Today;
			SetSelection(today.HebrewYear, AuctionInfo.Groups.Last(g => g.Auctions[0].Date.GetDate(today.HebrewYear) <= today));
		}

		[Browsable(false)]
		public AuctionGroup SelectedGroup { get; private set; }
		[Browsable(false)]
		public int SelectedYear { get; private set; }

		private void buttonEdit_ButtonClick(object sender, ButtonPressedEventArgs e) {
			if (e.Button.IsLeft && SelectedGroup == AuctionInfo.Groups.First())
				SetSelection(SelectedYear - 1, AuctionInfo.Groups.Last());
			else if (!e.Button.IsLeft && SelectedGroup == AuctionInfo.Groups.Last())
				SetSelection(SelectedYear + 1, AuctionInfo.Groups.First());
			else {
				var groupIndex = AuctionInfo.Groups.IndexOf(SelectedGroup);
				int direction = e.Button.IsLeft ? -1 : +1;
				SetSelection(SelectedYear, AuctionInfo.Groups[groupIndex + direction]);
			}
		}

		public void SetSelection(int year, AuctionGroup group) {
			if (group == null) throw new ArgumentNullException("group");
			SelectedYear = year;
			SelectedGroup = group;

			buttonEdit.Text = group.Name + ", " + (year - 5000).ToHebrewString(HebrewNumberFormat.LetterQuoted);
		}

		///<summary>Occurs when the selected AuctionGroup changes.</summary>
		[Description("Occurs when the selected AuctionGroup changes")]
		[Category("Action")]
		public event EventHandler SelectionChanged;
		///<summary>Raises the SelectionChanged event.</summary>
		internal protected virtual void OnSelectionChanged() { OnSelectionChanged(EventArgs.Empty); }
		///<summary>Raises the SelectionChanged event.</summary>
		///<param name="e">An EventArgs object that provides the event data.</param>
		internal protected virtual void OnSelectionChanged(EventArgs e) {
			if (SelectionChanged != null)
				SelectionChanged(this, e);
		}
	}
}
