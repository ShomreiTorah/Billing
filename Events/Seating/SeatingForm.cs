using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using Microsoft.Office.Interop.Word.Extensions;
using ShomreiTorah.Common;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI.Controls;
using ShomreiTorah.Singularity;
using ShomreiTorah.WinForms;
using Word = Microsoft.Office.Interop.Word;

namespace ShomreiTorah.Billing.Events.Seating {
	partial class SeatingForm : Forms.GridFormBase {
		static readonly Bitmap LoadingImage = Properties.Resources.Loading16;

		readonly int year;
		readonly FilteredTable<SeatingReservation> seats;
		public SeatingForm(int year) {
			Program.LoadTable<SeatingReservation>();    //Before setting DataMember
			InitializeComponent();

			loadingIconItem.EditValue = LoadingImage;
			colPledgeType.ColumnEdit = SeatingInfo.PledgeTypeEdit;  //TODO: IEditorSettings?
			this.year = year;

			grid.DataMember = null;
			grid.DataSource = seats = Program.Table<SeatingReservation>().Filter(sr => sr.Pledge.Date.Year == year);

			Text = year.ToString(CultureInfo.CurrentCulture) + " Seating Reservations";
			colChartStatus.Visible = colChartStatus.OptionsColumn.ShowInCustomizationForm = false;

			Program.Table<Pledge>().ValueChanged += Pledge_ValueChanged;
			Program.Table<SeatingReservation>().RowRemoved += SeatingReservation_RowChanged;
			Program.Table<SeatingReservation>().ValueChanged += SeatingReservation_ValueChanged;
			Program.Table<SeatingReservation>().RowAdded += SeatingReservation_RowChanged;

			UpdateTotals();
		}


		void SeatingReservation_RowChanged(object sender, RowListEventArgs<SeatingReservation> e) {
			if (e.Row.Pledge.Date.Year != year)
				return;
			UpdateTotals();
		}

		void Pledge_ValueChanged(object sender, ValueChangedEventArgs<Pledge> e) {
			if (e.Row.Date.Year != year) return;
			var seatRow = e.Row.SeatingReservations.FirstOrDefault();
			if (seatRow == null) return;

			gridView.RefreshRow(gridView.GetRowHandle(seats.Rows.IndexOf(seatRow)));
		}

		protected override void Dispose(bool disposing) {
			if (disposing) {
				seats.Dispose();
				Program.Table<Pledge>().ValueChanged -= Pledge_ValueChanged;
				Program.Table<SeatingReservation>().RowRemoved -= SeatingReservation_RowChanged;
				Program.Table<SeatingReservation>().RowAdded -= SeatingReservation_RowChanged;
				Program.Table<SeatingReservation>().ValueChanged -= SeatingReservation_ValueChanged;

				if (components != null) components.Dispose();
			}
			base.Dispose(disposing);
		}

		void UpdateTotals() {
			int men = 0, women = 0;
			foreach (var seat in seats.Rows) {
				men += seat.MensSeats + seat.BoysSeats;
				women += seat.WomensSeats + seat.GirlsSeats;
			}

			mensTotal.Caption = "Men's Section: " + men + " Seats";
			womensTotal.Caption = "Women's Section: " + women + " Seats";
		}

		#region AddEntry Panel
		private void personSelector_EditValueChanged(object sender, EventArgs e) {
			if (personSelector.SelectedPerson == null) return;
			if (year != DateTime.Now.Year
			 && !Dialog.Warn("You're trying to add a " + year + " seating reservation.\nAre you sure you want to do that?")) {
				personSelector.SelectedPerson = null;
				return;
			}
			addNewPanel.Show();
			addNewEdit.BeginAddNew(personSelector.SelectedPerson);
		}

		private void personSelector_PersonSelecting(object sender, PersonSelectingEventArgs e) {
			if (e.Person == null) return;
			if (addNewPanel.Visible) {
				if (!Dialog.Warn("Are you sure you want to start adding a new reservation?\r\nYou haven't added the reservation you're currently editing yet!")) {
					e.Cancel = true;
					return;
				}
			}
			var existingReservation = Program.Table<SeatingReservation>().Rows.FirstOrDefault(sr => sr.Pledge.Date.Year == year && sr.Person == e.Person);
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

		private void gridView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
			if (seats == null) return;  //Still initializing

			if (e.Column.FieldName.StartsWith("Pledge/", StringComparison.OrdinalIgnoreCase)) {
				var columnName = Path.GetFileName(e.Column.FieldName);
				var row = seats.Rows[e.ListSourceRowIndex];

				if (e.IsGetData)
					e.Value = row.Pledge[columnName];
				else
					row.Pledge[columnName] = e.Value;
			} else if (e.Column == colChartStatus) {
				if (colChartStatus.ColumnEdit == gridLoadingEdit)
					e.Value = LoadingImage;
				else if (seatGroups == null)
					e.Value = null;
				else {
					var row = seats.Rows[e.ListSourceRowIndex];

					var chartCount = FindChartCount(row.Person);
					if (chartCount == 0) {
						if (row.MensSeats + row.BoysSeats == 0)
							e.Value = 0;    //Not in chart, but has no seats
						else
							e.Value = null; //Missing
					} else {
						var reservedSeats = row.MensSeats + row.BoysSeats;
						e.Value = reservedSeats - chartCount;
					}
				}
			}
		}

		private void gridView_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyData == Keys.Delete) {
				var row = (SeatingReservation)gridView.GetFocusedRow();
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
				Title = "Open Seating Chart"
			}) {
				if (openDialog.ShowDialog() == DialogResult.Cancel) return;
				fileName = openDialog.FileName;
			}
			BeginOpenWordChart(Word.Documents.Open(fileName));
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
			BeginOpenWordChart(Word.Documents.Items().Single(d => d.Name == name));
		}
		#endregion
		private void openHtmlChart_ItemClick(object sender, ItemClickEventArgs e) {
			string fileName;
			using (var openDialog = new OpenFileDialog {
				Filter = "HTML Files|*.html|All Files|*.*",
				Title = "Open HTML Seating Chart"
			}) {
				if (openDialog.ShowDialog() == DialogResult.Cancel) return;
				fileName = openDialog.FileName;
			}

			BeginLoadChart(Path.GetFileNameWithoutExtension(fileName), () => {
				var doc = XDocument.Load(fileName, LoadOptions.PreserveWhitespace);
				var group = doc.Descendants("aside").FirstOrDefault(elem => elem.Attribute("id").Value == "IntelliSense");
				if (group == null) {
					Dialog.Warn("Document does not contain <aside id=\"IntelliSense\">; not updating IntelliSense data");
				} else {
					var prefix = group
						.Elements()
						.Select(elem => elem.PreviousNode as XText)
						.FirstOrDefault()
					 ?? new XText("\r\n\t\t");

					var lastWhitespace = group.Nodes().OfType<XText>().LastOrDefault();
					group.Nodes().Remove();
					group.Add(seats.Rows.OrderBy(row => row.Person.LastName).SelectMany(row => new XNode[] {
						prefix,
						new XElement("input",
							new XAttribute("type", "hidden"), new XAttribute("class", "IntelliSense-Primer"),
							new XAttribute("data-person", row.Person.LastName + ", " + row.Person.HisName + " # " + SeatCount(row)
													   + (string.IsNullOrWhiteSpace(row.Notes) ? "" : "; " + Truncate(row.Notes, 30))))
					}));
					group.Add(lastWhitespace);
					using (var writer = XmlWriter.Create(fileName, new XmlWriterSettings() { OmitXmlDeclaration = true }))
						doc.Save(writer);
				}
				return HtmlChartParser.ParseChart(doc.Root);
			});
		}


		static string SeatCount(SeatingReservation row) {
			var count = row.MensSeats + row.BoysSeats;
			return count + " Seat" + (count == 1 ? "" : "s");
		}

		static string Truncate(string text, int max) {
			text = text.Replace("\r", "").Replace("\n", " ").Trim();
			if (text.Length <= max)
				return text;
			max = Math.Max(max, text.IndexOf(' ', max));
			if (text.Length <= max)
				return text;
			return text.Remove(max).Trim() + "…";
		}

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

		void BeginOpenWordChart(Word.Document document) {
			BeginLoadChart(document.Name, () => {
				try {
					Word.ScreenUpdating = false;
					return WordParser.ParseChart(document);
				} finally { Word.ScreenUpdating = true; }
			});
		}

		string lastChartName;
		Func<ParsedSeatingChart> lastChartLoader;
		private void refreshChart_ItemClick(object sender, ItemClickEventArgs e) {
			BeginLoadChart(lastChartName, lastChartLoader);
		}

		void BeginLoadChart(string name, Func<ParsedSeatingChart> loader) {
			lastChartName = name;
			lastChartLoader = loader;

			colChartStatus.Visible = colChartStatus.OptionsColumn.ShowInCustomizationForm = true;

			LoadingCaption = "Reading " + name + "...";
			colChartStatus.ColumnEdit = gridLoadingEdit;
			ThreadPool.QueueUserWorkItem(delegate {
				try {
					chart = loader();
				} catch (Exception ex) {
					BeginInvoke(new Action(delegate {
						LoadingCaption = null;
						colChartStatus.ColumnEdit = null;
						if (!Debugger.IsAttached)
							Program.Current.HandleException(ex);
					}));

					if (Debugger.IsAttached)
						Debugger.Break();
				}
				BeginInvoke(new Action(delegate {
					try {
						refreshChart.Enabled = showChartInfo.Enabled = chart != null;
						if (chart == null) {
							colChartStatus.Visible = colChartStatus.OptionsColumn.ShowInCustomizationForm = false;
							return;
						}
						if (seatGroups == null)
							seatGroups = new Dictionary<Person, int>();
						else
							seatGroups.Clear();

					} finally {
						LoadingCaption = null;
						colChartStatus.ColumnEdit = null;
						gridView.RefreshData();
					}
				}));
			});
		}



		void SeatingReservation_ValueChanged(object sender, ValueChangedEventArgs<SeatingReservation> e) {
			if (e.Row.Pledge.Date.Year != year)
				return;
			UpdateTotals();
			gridView.RefreshRowCell(
				gridView.GetRowHandle(seats.Rows.IndexOf(e.Row)),
				colChartStatus
			);
		}

		int FindChartCount(Person person) {
			int retVal;
			if (seatGroups.TryGetValue(person, out retVal))
				return retVal;

			retVal = chart.AllSeats.Where(s => s.Matches(person)).Sum(s => s.SeatCount);
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

		SeatingChartInfo infoForm;
		private void showChartInfo_ItemClick(object sender, ItemClickEventArgs e) {
			BeginLoadChart(lastChartName, lastChartLoader);

			if (infoForm != null && infoForm.Visible) {
				infoForm.UpdateData(chart, seats.Rows);
				infoForm.Activate();
			} else {
				infoForm = SeatingChartInfo.Show(MdiParent, chart, seats.Rows);
			}
		}

		ParsedSeatingChart chart;

		///<summary>Contains the SeatGroups corresponding to people in the master directory.</summary>
		Dictionary<Person, int> seatGroups;
		#endregion

		private void exportLadiesInfo_ItemClick(object sender, ItemClickEventArgs e) {
			string path;
			using (var dialog = new SaveFileDialog {
				Filter = "Excel 2003 Spreadsheet|*.xls|Excel 2007 Spreadsheet (*.xlsx)|*.xlsx",
				FileName = "Ladies' Seats " + year,
				Title = "Save Ladies' Seating Info"
			}) {
				if (dialog.ShowDialog(MdiParent) != DialogResult.OK) return;
				path = dialog.FileName;
			}
			seats.Rows.ExportWomensSeats(path);
			Process.Start(path);
		}

		private void exportAllInfo_ItemClick(object sender, ItemClickEventArgs e) {
			string path;
			using (var dialog = new SaveFileDialog {
				Filter = "Excel 2003 Spreadsheet|*.xls|Excel 2007 Spreadsheet (*.xlsx)|*.xlsx",
				FileName = "Seats " + year,
				Title = "Save Seating Info"
			}) {
				if (dialog.ShowDialog(MdiParent) != DialogResult.OK) return;
				path = dialog.FileName;
			}
			seats.Rows.ExportSeatingInfo(path);
			Process.Start(path);
		}
	}
}