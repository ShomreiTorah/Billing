using System;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI.DisplaySettings;
using ShomreiTorah.Singularity;
using ShomreiTorah.WinForms;

namespace ShomreiTorah.Billing.Events.MelaveMalka {
	partial class CallListForm : XtraForm {
		readonly int year;

		readonly FilteredTable<MelaveMalkaInvitation> dataSource;
		public CallListForm(int year) {
			Program.LoadTable<MelaveMalkaInvitation>();	//Includes Callers as a dependency
			InitializeComponent();

			this.year = year;
			Text = "Melave Malka " + year + " Call List";

			grid.DataMember = null;
			listSearch.Properties.DataSource = grid.DataSource = dataSource = new FilteredTable<MelaveMalkaInvitation>(
					Program.Table<MelaveMalkaInvitation>(),
					mmi => mmi.Year == year
				);
			EditorRepository.PersonOwnedLookup.Apply(listSearch.Properties);

			gridView.ActiveFilterCriteria = new OperandProperty("AdAmount") == 0;
			CheckableGridController.Handle(colShouldCall);

			Program.Table<Caller>().RowAdded += CallersTable_Changed;
			Program.Table<Caller>().RowRemoved += CallersTable_Changed;
			BindCallerDropDown();
		}
		private void showCallers_ItemClick(object sender, ItemClickEventArgs e) { new CallerList(year).Show(MdiParent); }


		///<summary>Releases the unmanaged resources used by the CallListForm and optionally releases the managed resources.</summary>
		///<param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				Program.Table<Caller>().RowAdded -= CallersTable_Changed;
				Program.Table<Caller>().RowRemoved -= CallersTable_Changed;

				if (components != null) components.Dispose();
			}
			base.Dispose(disposing);
		}
		void CallersTable_Changed(object sender, RowListEventArgs<Caller> e) { BindCallerDropDown(); }
		void BindCallerDropDown() {
			callerEdit.BeginUpdate();
			callerEdit.Items.Clear();
			foreach (var caller in Program.Table<Caller>().Rows.Where(c => c.Year == year))
				callerEdit.Items.Add(caller);
			callerEdit.EndUpdate();
		}


		private void gridView_InvalidValueException(object sender, InvalidValueExceptionEventArgs e) {
			//Deleting the text in the combobox will
			//try to set the cell value to an empty 
			//string, and fail with an invalid cast.
			//I handle this case and actually set it
			//to null.
			if (gridView.FocusedColumn == colCaller) {
				var str = e.Value as string;	//If the value is a non-null but empty string
				if (str != null && str.Trim().Length == 0) {
					e.ExceptionMode = ExceptionMode.NoAction;
					gridView.SetFocusedRowCellValue(colCaller, null);
				}
			}
		}

		private void listSearch_EditValueChanged(object sender, EventArgs e) {
			var row = listSearch.EditValue as MelaveMalkaInvitation;
			if (row == null) return;
			var handle = gridView.GetRowHandle(dataSource.Rows.IndexOf(row));
			if (handle < 0)
				Dialog.ShowError(row.Person.FullName + " do not meet the current filter");
			else
				gridView.SetSelection(handle, makeVisible: true);
			listSearch.EditValue = null;
		}
	}
}