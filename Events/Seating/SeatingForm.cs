using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using Microsoft.Office.Interop.Word.Extensions;
using ShomreiTorah.Billing.Controls;
using ShomreiTorah.Common;
using Word = Microsoft.Office.Interop.Word;
using System.Threading;
using System.Diagnostics;

namespace ShomreiTorah.Billing.Events.Seating {
	partial class SeatingForm : Forms.GridFormBase {
		static readonly Bitmap LoadingImage = Properties.Resources.Loading16;

		readonly int year;
		readonly DataView dataSource;
		public SeatingForm(int year) {
			InitializeComponent();

			loadingIconItem.EditValue = LoadingImage;
			colPledgeType.ColumnEdit = SeatingInfo.PledgeTypeEdit;
			this.year = year;
			var filterString = "Parent(Seat).Date > #1/1/" + year + "# AND Parent(Seat).Date < #12/31/" + year + "#";

			grid.DataMember = null;
			grid.DataSource = dataSource = new DataView(Program.Data.SeatingReservations, filterString, null, DataViewRowState.CurrentRows);

			Text = year.ToString(CultureInfo.CurrentCulture) + " Seating Reservations";
			colChartStatus.Visible = colChartStatus.OptionsColumn.ShowInCustomizationForm = false;

			Program.Data.Pledges.PledgesRowChanged += Pledges_PledgesRowChanged;
			Program.Data.SeatingReservations.SeatingReservationsRowChanged += SeatingReservations_SeatingReservationsRowChanged;
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				Program.Data.SeatingReservations.SeatingReservationsRowChanged -= SeatingReservations_SeatingReservationsRowChanged;
				Program.Data.Pledges.PledgesRowChanged -= Pledges_PledgesRowChanged;
				if (components != null) components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region AddEntry Panel
		private void personSelector_SelectedPersonChanged(object sender, EventArgs e) {
			if (personSelector.SelectedPerson == null) return;
			addNewPanel.Show();
			addNewEdit.BeginAddNew(personSelector.SelectedPerson);
		}

		private void personSelector_SelectingPerson(object sender, SelectingPersonEventArgs e) {
			if (e.Person == null) return;
			if (addNewPanel.Visible) {
				if (DialogResult.Yes != XtraMessageBox.Show("Are you sure you want to start adding a new reservation?\r\nYou haven't added the reservation you're currently editing yet!",
															"Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
					e.Cancel = true;
			}
			var existingReservation = Program.Data.SeatingReservations.CurrentRows()
					.FirstOrDefault(sr => sr.PledgesRow.Date.Year == year && sr.PledgesRow.PersonId == e.Person.Id);
			if (existingReservation != null) {
				if (DialogResult.Yes != XtraMessageBox.Show(e.Person.VeryFullName + " already have a reservation for " + existingReservation.TotalSeats + " seats."
														  + "\r\nAre you sure you want to add a second reservation?",
															"Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
					e.Cancel = true;
			}
		}

		private void addNewEdit_EnterPressed(object sender, EventArgs e) {
			addEntry.PerformClick();
		}

		private void addEntry_Click(object sender, EventArgs e) {
			if (!addNewEdit.CommitNew())
				return;
			CloseAddEndtryPanel();
		}
		private void cancelAddEntry_Click(object sender, EventArgs e) { CloseAddEndtryPanel(confirm: true); }
		void CloseAddEndtryPanel(bool confirm = false) {
			if (!addNewPanel.Visible) return;
			if (confirm && DialogResult.No == XtraMessageBox.Show("Are you sure you wish to cancel adding this seating reservation?",
																  "Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
				return;
			addNewPanel.Hide();
			personSelector.SelectedPerson = null;
		}
		#endregion

		void Pledges_PledgesRowChanged(object sender, BillingData.PledgesRowChangeEvent e) {
			if (e.Row.Date.Year != year) return;
			var seatRow = e.Row.GetSeatingReservationsRows().FirstOrDefault();
			if (seatRow == null) return;

			gridView.RefreshRow(gridView.GetRowHandle(dataSource.Rows<BillingData.SeatingReservationsRow>().IndexOf(seatRow)));
		}

		private void gridView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
			if (e.Column.FieldName.StartsWith("Pledge/", StringComparison.OrdinalIgnoreCase)) {
				var columnName = Path.GetFileName(e.Column.FieldName);
				var row = (BillingData.SeatingReservationsRow)dataSource[e.ListSourceRowIndex].Row;

				if (e.IsGetData)
					e.Value = row.PledgesRow[columnName];
				else
					row.PledgesRow[columnName] = e.Value;
			} else if (e.Column == colChartStatus) {
				if (colChartStatus.ColumnEdit == gridLoadingEdit)
					e.Value = LoadingImage;
				else if (seatGroups == null)
					e.Value = null;
				else {
					var row = (BillingData.SeatingReservationsRow)dataSource[e.ListSourceRowIndex].Row;

					var seat = FindSeatGroup(row.Person);
					if (seat == null)
						e.Value = null;
					else {
						var reservedSeats = row.MensSeats + row.BoysSeats;
						e.Value = reservedSeats - seat.SeatCount;
					}
				}
			}
		}

		private void gridView_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyData == Keys.Delete) {
				var row = (BillingData.SeatingReservationsRow)gridView.GetFocusedDataRow();
				if (row == null) return;

				new SeatingReservationDeleter(row).ShowDialog(this);
			}
		}

		#region Word
		static Word.Application Word { get { return Office<Word.ApplicationClass>.App; } }
		private void openWordDoc_ItemClick(object sender, ItemClickEventArgs e) {
			string fileName;
			using (var openDialog = new OpenFileDialog {
				Filter = "Word Documents|*.docx;*.doc|All Files|*.*",
				Title = "Open Schedule"
			}) {
				if (openDialog.ShowDialog() == DialogResult.Cancel) return;
				fileName = openDialog.FileName;
			}
			BeginOpenChart(Word.Documents.Open(fileName));
		}

		private void wordDocsMenu_BeforePopup(object sender, CancelEventArgs e) {
			wordDocList.Strings.Clear();

			try {
				if (!Office<Word.ApplicationClass>.IsRunning) return;

				LoadingCaption = "Connecting to Word...";
				foreach (Word.Document document in Word.Documents) {
					wordDocList.Strings.Add(document.Name);
				}
			} finally { LoadingCaption = null; }
		}

		private void wordDocList_ListItemClick(object sender, ListItemClickEventArgs e) {
			var name = wordDocList.Strings[e.Index];
			BeginOpenChart(Word.Documents.Items().Single(d => d.Name == name));
		}
		#endregion
		#region SeatingChart
		string LoadingCaption {
			get { return loadingIconItem.Caption; }
			set {
				if (InvokeRequired) {
					BeginInvoke(new Action(delegate { LoadingCaption = value; }));
					return;
				}
				if (LoadingCaption == value) return;
				loadingIconItem.Visibility = String.IsNullOrEmpty(value) ? BarItemVisibility.OnlyInCustomizing : BarItemVisibility.OnlyInRuntime;
				loadingIconItem.Caption = value;
			}
		}

		void BeginOpenChart(Word.Document document) {
			colChartStatus.Visible = colChartStatus.OptionsColumn.ShowInCustomizationForm = true;

			LoadingCaption = "Reading " + document.Name + "...";
			colChartStatus.ColumnEdit = gridLoadingEdit;
			ThreadPool.QueueUserWorkItem(delegate {
				try {
					chart = WordParser.ParseChart(document);
				} catch (Exception ex) {
					if (Debugger.IsAttached) {
						LoadingCaption = null;
						colChartStatus.ColumnEdit = null;
						Debugger.Break();
						return;
					}
					BeginInvoke(new Action(delegate {
						LoadingCaption = null;
						colChartStatus.ColumnEdit = null;
						new Forms.ErrorForm(ex).Show();
					}));
				}

				BeginInvoke(new Action(delegate {
					try {
						if (seatGroups == null)
							seatGroups = new Dictionary<BillingData.MasterDirectoryRow, SeatGroup>();
						else
							seatGroups.Clear();

						gridView.RefreshData();

					} finally { LoadingCaption = null; colChartStatus.ColumnEdit = null; }
				}));
			});
		}

		void SeatingReservations_SeatingReservationsRowChanged(object sender, BillingData.SeatingReservationsRowChangeEvent e) {
			if (e.Row.PledgesRow.Date.Year != year)
				return;
			gridView.RefreshRowCell(
				gridView.GetRowHandle(dataSource.Rows<BillingData.SeatingReservationsRow>().IndexOf(e.Row)),
				colChartStatus
			);
		}

		SeatGroup FindSeatGroup(BillingData.MasterDirectoryRow person) {
			SeatGroup retVal;
			if (seatGroups.TryGetValue(person, out retVal))
				return retVal;

			retVal = chart.AllSeats.FirstOrDefault(s => s.Matches(person));
			seatGroups.Add(person, retVal);

			return retVal;
		}

		private void gridView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e) {
			if (e.Column == colChartStatus) {
				if (e.Column.ColumnEdit != null) return;
				if (e.Value == null)
					e.DisplayText = "Not in chart";
				else {
					var value = (int)e.Value;
					if (value < -1)
						e.DisplayText = -value + " extra seats";
					else if (value == -1)
						e.DisplayText = "1 extra seat";
					else if (value == 0)
						e.DisplayText = "Perfect";
					else if (value == 1)
						e.DisplayText = "Missing 1 seat";
					else
						e.DisplayText = "Missing " + value + " seats";
				}
			}
		}

		ParsedSeatingChart chart;

		///<summary>Contains the SeatGroups corresponding to people in the master directory.</summary>
		Dictionary<BillingData.MasterDirectoryRow, SeatGroup> seatGroups;
		#endregion
	}
}