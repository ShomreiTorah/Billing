using System;
using System.Diagnostics;
using System.Linq;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI.DisplaySettings;
using ShomreiTorah.Singularity;
using ShomreiTorah.WinForms;
using ShomreiTorah.WinForms.Forms;

namespace ShomreiTorah.Billing.Events.MelaveMalka {
	partial class CallerList : XtraForm {
		readonly int year;
		public CallerList(int year) {
			Program.LoadTable<Caller>();
			InitializeComponent();
			this.Text = "Melave Malka " + year + " Callers";
			this.year = year;

			addCaller.Properties.DataSource = Program.Table<Person>();
			EditorRepository.PersonLookup.Apply(addCaller.Properties);

			grid.DataMember = null;
			grid.DataSource = new FilteredTable<Caller>(
				Program.Table<Caller>(),
				c => c.Year == year
			);

			colCallerPerson.ColumnEdit.DoubleClick += CallerPersonEdit_DoubleClick;
		}

		void CallerPersonEdit_DoubleClick(object sender, EventArgs e) { ToggleRow(gridView.FocusedRowHandle); }
		private void gridView_DoubleClick(object sender, EventArgs e) {
			var info = gridView.CalcHitInfo(grid.PointToClient(MousePosition));

			if (info.RowHandle >= 0 && info.InRow) {
				ToggleRow(info.RowHandle);
				var dx = e as DXMouseEventArgs;
				if (dx != null) dx.Handled = true;
			}
		}
		void ToggleRow(int handle) {
			gridView.SetMasterRowExpanded(handle, !gridView.GetMasterRowExpanded(handle));
		}

		private void addCaller_EditValueChanged(object sender, EventArgs e) {
			var person = addCaller.EditValue as Person;
			if (person == null) return;
			addCaller.EditValue = null;

			if (person.Callers.Any(c => c.Year == year)) {
				Dialog.ShowError(person.FullName + " is already a caller for the " + year + " Melave Malka");
				return;
			}

			Program.Table<Caller>().Rows.Add(new Caller {
				Person = person,
				Year = year,
				DateAdded = DateTime.Now,
			});

			InfoMessage.Show(person.FullName + " has been added as a caller for the " + year + " Melave Malka");
		}

		private void emailLinkEdit_OpenLink(object sender, OpenLinkEventArgs e) {
			e.Handled = true;
			if (!String.IsNullOrWhiteSpace(e.EditValue as string))
				Process.Start("mailto: " + e.EditValue);
		}
	}
}