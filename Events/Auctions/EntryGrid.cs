using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using ShomreiTorah.Common;
using ShomreiTorah.Common.Collections;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI.Grid;
using ShomreiTorah.Singularity;
using ShomreiTorah.WinForms;

namespace ShomreiTorah.Billing.Events.Auctions {
	partial class EntryGrid : XtraUserControl {
		struct PledgeKey : IEquatable<PledgeKey> {
			public PledgeKey(Pledge pledge)
				: this() {
				PledgeType = pledge.Type;
				SubType = pledge.SubType;
				Date = pledge.Date;
			}
			public PledgeKey(AuctionPledge pledge)
				: this() {
				PledgeType = pledge.PledgeType;
				SubType = pledge.Item.ItemName;
				Date = pledge.Item.Date;
			}

			public string PledgeType { get; private set; }
			public string SubType { get; private set; }
			public DateTime Date { get; private set; }

			public override int GetHashCode() { return Comparer.GetHashCode(this); }
			public bool Equals(PledgeKey obj) { return Comparer.Equals(this, obj); }
			public override bool Equals(object obj) { return obj is PledgeKey && Equals((PledgeKey)obj); }
			static readonly ValueComparer<PledgeKey> Comparer = new ValueComparer<PledgeKey>(
				o => o.Date,
				o => o.PledgeType,
				o => o.SubType
			);

			public static bool operator ==(PledgeKey a, PledgeKey b) { return a.Equals(b); }
			public static bool operator !=(PledgeKey a, PledgeKey b) { return !a.Equals(b); }
		}

		readonly BindingSource gridDataSource = new BindingSource();
		readonly SetDictionary<PledgeKey, Pledge> thirdPartyPledges = new SetDictionary<PledgeKey, Pledge>();

		Dictionary<PledgeKey, AuctionPledge> auctionPledges;
		private HashSet<DateTime> currentDates;
		private BindingList<AuctionItem> dataSource;

		private bool isSaving;

		public EntryGrid() {
			InitializeComponent();
			grid.DataSource = gridDataSource;
			amountEdit.Buttons[0].Shortcut = new KeyShortcut(Keys.M);

			Program.Table<Pledge>().RowAdded += Pledges_RowAdded;
			Program.Table<Pledge>().ValueChanged += Pledges_ValueChanged;
			Program.Table<Pledge>().RowRemoved += Pledges_RowRemoved;

			gridView.CustomSuperTip += gridView_CustomSuperTip;
		}

		///<summary>Releases the unmanaged resources used by the EntryGrid and optionally releases the managed resources.</summary>
		///<param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				Program.Table<Pledge>().RowAdded -= Pledges_RowAdded;
				Program.Table<Pledge>().ValueChanged -= Pledges_ValueChanged;
				Program.Table<Pledge>().RowRemoved -= Pledges_RowRemoved;

				if (components != null) components.Dispose();
			}
			base.Dispose(disposing);
		}

		public void BindTo(IEnumerable<AuctionItem> items) {
			dataSource = new BindingList<AuctionItem>(items.ToArray()) {
				AllowNew = false,
				AllowRemove = false
			};
			dataSource.ListChanged += delegate { OnChanged(); };
			CurrentPerson = dataSource[0].Person;
			currentDates = new HashSet<DateTime>(dataSource.Select(a => a.Date));	//The HashSet will ignore duplicates

			auctionPledges = dataSource.SelectMany(a => a.Pledges).ToDictionary(a => new PledgeKey(a));
			RescanPledges();

			gridDataSource.DataSource = dataSource;
			gridView.ExpandAllGroups();
		}
		public Person CurrentPerson { get; private set; }

		#region Track changes
		void RescanPledges() {
			if (isSaving) return;
			thirdPartyPledges.Clear();
			foreach (var pledge in Program.Table<Pledge>().Rows) {
				CheckAdd(pledge);
			}
		}

		//When changing thirdPartyPledges, we need to refresh the grid's highlighting
		///<summary>The pledge types that are shown on the grid.</summary>
		static readonly string[] pledgeTypes = { "Auction", "מי שברך" };
		void Pledges_RowAdded(object sender, RowListEventArgs<Pledge> e) { CheckAdd(e.Row); }
		void CheckAdd(Pledge row) {
			if (isSaving) return;
			if (currentDates.Contains(row.Date) && pledgeTypes.Contains(row.Type)) {
				if (row.Person != CurrentPerson) {
					thirdPartyPledges.Add(new PledgeKey(row), row);
					gridView.RefreshData();
				} else {
					AuctionPledge ap;
					if (auctionPledges.TryGetValue(new PledgeKey(row), out ap))
						ap.UpdateFromPledge(row);
				}
			}
		}
		void Pledges_ValueChanged(object sender, ValueChangedEventArgs<Pledge> e) {
			if (isSaving) return;
			//TODO: Check contains for old and new values
			if (e.Column == Pledge.TypeColumn || e.Column == Pledge.SubTypeColumn || e.Column == Pledge.PersonColumn || e.Column == Pledge.DateColumn) {
				RescanPledges();	//FIXME: It would be faster to check for the specific change, and remove rows that changed out.
				gridView.RefreshData();
				return;
			}
			if (e.Row.Person == CurrentPerson && currentDates.Contains(e.Row.Date)) {
				if (e.Column == Pledge.AmountColumn || e.Column == Pledge.NoteColumn)
					auctionPledges[new PledgeKey(e.Row)].UpdateFromPledge(e.Row);
			}
		}
		void Pledges_RowRemoved(object sender, RowListEventArgs<Pledge> e) {
			if (isSaving) return;
			if (currentDates.Contains(e.Row.Date) && pledgeTypes.Contains(e.Row.Type)) {
				if (e.Row.Person != CurrentPerson) {
					if (thirdPartyPledges.Remove(new PledgeKey(e.Row), e.Row))
						gridView.RefreshData();
				} else {
					AuctionPledge ap;
					if (auctionPledges.TryGetValue(new PledgeKey(e.Row), out ap))
						ap.Amount = null;
				}
			}
		}
		#endregion

		public void CommitChanges() {
			try {
				isSaving = true;
				foreach (var pledge in auctionPledges.Values) {
					pledge.CommitToPledge();
				}
			} finally { isSaving = false; }
		}

		private void amountEdit_ButtonClick(object sender, ButtonPressedEventArgs e) {
			gridView.SetFocusedValue(0m);
			//Switch to the Note cell - this commits the editor. 
			//After clicking מתנה, there's no reason to edit the
			//value.
			gridView.FocusedColumn = gridView.Columns[gridView.FocusedColumn.AbsoluteIndex + 1];
		}

		///<summary>Checks whether any of the pledges in the grid have changed from the database.  This is an expensive call.</summary>
		public bool HasChanges() {
			//If nothing has been bound yet, there are no changes.
			return dataSource != null && dataSource.Any(a => a.Pledges.Any(ap => ap.HasChanges()));
		}

		///<summary>Gets the total pledges shown in the grid, including any pledges that already exist</summary>
		[Browsable(false)]
		public decimal TotalPledged {
			get { return dataSource.Sum(a => (a.BidAmount ?? 0) + (a.MBAmount ?? 0)); }
		}
		///<summary>Gets the number of מתנות shown in the grid, including any pledges that already exist</summary>
		[Browsable(false)]
		public int מתנהCount {
			get { return dataSource.SelectMany(a => a.Pledges).Count(p => p.Amount == 0); }
		}

		///<summary>Occurs when the data in the grid changes.</summary>
		public event EventHandler Changed;
		///<summary>Raises the Changed event.</summary>
		internal protected virtual void OnChanged() { OnChanged(EventArgs.Empty); }
		///<summary>Raises the Changed event.</summary>
		///<param name="e">An EventArgs object that provides the event data.</param>
		internal protected virtual void OnChanged(EventArgs e) {
			if (Changed != null)
				Changed(this, e);
		}

		#region Cell Styling
		private void gridView_RowCellStyle(object sender, RowCellStyleEventArgs e) {
			if (IsPledgeColumn(e.Column)) {
				var ap = GetPledge(e.Column, e.RowHandle);
				if (ap == null) {
					e.Appearance.BackColor = gridView.PaintAppearance.VertLine.BackColor;
					e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
				} else {
					bool changed = ap.HasChanges(), hasExisting = thirdPartyPledges[new PledgeKey(ap)].Any();

					if (changed && hasExisting)
						e.Appearance.BackColor = Color.FromArgb(255, 192, 64);
					else if (changed)
						e.Appearance.BackColor = Color.FromArgb(255, 255, 128);
					else if (hasExisting)
						e.Appearance.BackColor = Color.FromArgb(128, 255, 128);
				}
			}
		}
		void gridView_CustomSuperTip(object sender, CustomToolTipEventArgs e) {
			if (e.HitInfo.InRowCell && IsPledgeColumn(e.HitInfo.Column)) {
				var auctionPledge = GetPledge(e.HitInfo.Column, e.HitInfo.RowHandle);
				if (auctionPledge == null)
					return;
				var otherPledges = thirdPartyPledges[new PledgeKey(auctionPledge)];

				if (otherPledges.Count == 0) {
					e.SuperTip = Utilities.CreateSuperTip(
						title: auctionPledge.PledgeType + " for " + auctionPledge.Item.ItemName + " on " + auctionPledge.Item.AuctionName,
						body: "No other pledges"
					);
				} else {
					e.SuperTip = Utilities.CreateSuperTip(
						title: "Other " + auctionPledge.PledgeType.ToLowerInvariant() + " pledges for " + auctionPledge.Item.ItemName + " on " + auctionPledge.Item.AuctionName + ":",
						body: " • "
							+ otherPledges.Join("\r\n\r\n • ",
								p => String.Format(CultureInfo.CurrentCulture,
												   "{0}:  {1:c}  {2}",
												   p.Person.FullName, p.Amount, p.Note
												  ).Replace("&", "&&").TrimEnd(' ')
							)
					);
				}
			}
		}

		private void gridView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e) {
			if (IsPledgeColumn(e.Column)) {
				if (GetPledge(e.Column, e.RowHandle) == null)
					e.RepositoryItem = emptyEdit;
			}
		}
		private void gridView_ShowingEditor(object sender, CancelEventArgs e) {
			if (IsPledgeColumn(gridView.FocusedColumn)) {
				if (GetPledge(gridView.FocusedColumn, gridView.FocusedRowHandle) == null)
					e.Cancel = true;
			}
		}


		///<summary>Checks whether a column is one of the four pledge columns.</summary>
		static bool IsPledgeColumn(GridColumn column) {
			return column.FieldName.StartsWith("MB", StringComparison.Ordinal) || column.FieldName.StartsWith("Bid", StringComparison.Ordinal);
		}
		///<summary>Gets the pledge displayed by a particular grid cell.</summary>
		AuctionPledge GetPledge(GridColumn column, int rowHandle) {
			var row = (AuctionItem)gridView.GetRow(rowHandle);
			if (column.FieldName.StartsWith("MB", StringComparison.Ordinal))
				return row.MBPledge;
			else if (column.FieldName.StartsWith("Bid", StringComparison.Ordinal))
				return row.BidPledge;
			else
				throw new ArgumentOutOfRangeException("column");
		}
		#endregion

		//This logic assumes that all rows have bids. 
		//If that changes, you should probably get rid
		//of this code; it's not necessary.
		#region Prevent Empty Cell Focus
		private void gridView_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e) {
			//If the user focuses a non-pledge column, force focus
			//back to a column with a pledge.
			if (IsPledgeColumn(e.FocusedColumn) && gridView.FocusedRowHandle >= 0) {
				if (GetPledge(e.FocusedColumn, gridView.FocusedRowHandle) == null) {
					gridView.FocusedColumn = colBidAmount;
					if (MouseButtons == MouseButtons.None) {
						//If the user tries to tab into a bad cell, go to the next row.
						if (e.PrevFocusedColumn == colBidNote)
							gridView.MoveNext();					//User is navigating forwards
						else
							gridView.FocusedColumn = colBidNote;	//User might be navigating backwards
					}
				}
			}
		}

		private void gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e) {
			//In case the user presses Up or Down from an MB row to a non-MB row.
			if (IsPledgeColumn(gridView.FocusedColumn) && e.FocusedRowHandle >= 0) {
				if (GetPledge(gridView.FocusedColumn, e.FocusedRowHandle) == null) {
					gridView.FocusedColumn = colBidNote;
				}
			}
		}
		#endregion
	}
}
