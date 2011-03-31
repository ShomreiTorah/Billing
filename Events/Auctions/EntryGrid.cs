using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils;

namespace ShomreiTorah.Billing.Events.Auctions {
	partial class EntryGrid : XtraUserControl {
		readonly BindingSource gridDataSource = new BindingSource();
		public EntryGrid() {
			InitializeComponent();
			grid.DataSource = gridDataSource;
			amountEdit.Buttons[1].Shortcut = new KeyShortcut(Keys.M);
		}

		private BindingList<AuctionItem> dataSource;
		public void BindTo(IEnumerable<AuctionItem> items) {
			dataSource = new BindingList<AuctionItem>(items.ToArray()) {
				AllowNew = false,
				AllowRemove = false
			};
			dataSource.ListChanged += delegate { OnChanged(); };

			gridDataSource.DataSource = dataSource;
			gridView.ExpandAllGroups();
		}

		private void amountEdit_ButtonClick(object sender, ButtonPressedEventArgs e) {
			gridView.SetFocusedValue(0m);
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
				if (GetPledge(e.Column, e.RowHandle) == null) {
					e.Appearance.BackColor = gridView.PaintAppearance.VertLine.BackColor;
					e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
				}

				//TODO: Green for cells with other people's pledges
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
