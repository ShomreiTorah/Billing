using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevExpress.Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using ShomreiTorah.Data;

namespace ShomreiTorah.Billing.Forms {
	//This needs to handle the Email list form,
	//where some DataRows don't have people.

	partial class GridFormBase : XtraForm {
		public GridFormBase() { InitializeComponent(); }

		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			if (DesignMode)
				ribbon.SendToBack();
			else
				SetSelectionButtonsState();
		}

		GridView mainView;
		///<summary>Gets or sets the gridview used to generate statements.</summary>
		[Description("Gets or sets the gridview used to generate statements.")]
		[Category("Data")]
		public GridView MainView {
			get { return mainView; }
			set {
				if (value == null) return;
				if (MainView != null) {
					MainView.SelectionChanged -= MainView_SelectionChanged;
					MainView.FocusedRowChanged -= MainView_FocusedRowChanged;
				}

				mainView = value;
				if (!DesignMode) {
					MainView.SelectionChanged += MainView_SelectionChanged;
					MainView.FocusedRowChanged += MainView_FocusedRowChanged;
				}
			}
		}

		void MainView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e) { SetSelectionButtonsState(); }
		private void MainView_SelectionChanged(object sender, SelectionChangedEventArgs e) { SetSelectionButtonsState(); }
		void SetSelectionButtonsState() {
			if (!Visible) return;
			exportWordSelected.Enabled = emailSelected.Enabled = MainView.SelectedRowsCount > 0 && GetSelectedPeople().Any();
			exportWordSelected.Caption = emailSelected.Caption = MainView.SelectedRowsCount == 1 ? "Selected person" : "Selected people";
		}

		private void emailVisible_ItemClick(object sender, ItemClickEventArgs e) { Statements.Email.EmailExporter.Execute(MdiParent ?? this, GetVisiblePeople().ToArray()); }
		private void exportWordVisible_ItemClick(object sender, ItemClickEventArgs e) { Statements.Word.WordExporter.Execute(MdiParent ?? this, GetVisiblePeople().ToArray()); }

		private void emailSelected_ItemClick(object sender, ItemClickEventArgs e) { Statements.Email.EmailExporter.Execute(MdiParent ?? this, GetSelectedPeople().ToArray()); }
		private void exportWordSelected_ItemClick(object sender, ItemClickEventArgs e) { Statements.Word.WordExporter.Execute(MdiParent ?? this, GetSelectedPeople().ToArray()); }

		protected Person GetPerson(int rowHandle) {
			var row = MainView.GetRow(rowHandle);
			if (row == null) return null;
			return row as Person
				?? ((IOwnedObject)row).Person;
		}

		protected IEnumerable<Person> GetSelectedPeople() {
			return MainView.GetSelectedRows().Select<int, Person>(GetPerson).Where(p => p != null);
		}
		protected IEnumerable<Person> GetVisiblePeople() {
			return Enumerable.Range(0, MainView.DataRowCount).Select<int, Person>(GetPerson).Where(p => p != null);
		}
	}
}