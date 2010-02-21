using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using System.Data;
using System.Globalization;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data.Filtering;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors.Controls;

namespace ShomreiTorah.Billing.Controls {
	[ToolboxItem(false)]
	partial class BaseGrid : GridControl {
		bool initComponentFinished;
		public BaseGrid() { Init(); }
		public BaseGrid(IContainer container) { container.Add(this); Init(); }

		void Init() {
			InitializeComponent();

			MainView = null;
			ViewCollection.Clear();

			initComponentFinished = true;
			DataSource = Program.Data ?? new BillingData();
			accountEdit.Items.Clear();
			accountEdit.Items.AddRange(BillingData.AccountNames);
		}
		protected override void CreateMainView() { }//Do nothing

		//Both our initComponent and our parent form's InitComponent call begin/end init.
		//I suppress the first EndInit and the second BeginInit.
		public override void EndInit() {
			if (initComponentFinished)
				base.EndInit();
		}
		public override void BeginInit() {
			if (!initComponentFinished)
				base.BeginInit();
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override object DataSource {
			get { return base.DataSource; }
			set { base.DataSource = value; }
		}
		protected override void OnHandleCreated(EventArgs e) {
			base.OnHandleCreated(e);
			if (!DesignMode) {
				var gridView = MainView as GridView;
				if (gridView != null)
					gridView.BestFitColumns();
			}
		}
		protected override void RegisterView(BaseView gv) {
			base.RegisterView(gv);
			if (DesignMode) return;

			gv.KeyUp += view_KeyUp;

			var view = gv as GridView;
			if (view != null) {
				view.CustomColumnSort += view_CustomColumnSort;

				view.ShowGridMenu += view_ShowGridMenu;

				view.BestFitColumns();	//For detail clones
				CheckColumns(view);

				GridColumn prevColumn = null;
				int prevRow = int.MinValue;
				int callCount = 0;	//The number of times that ShowingEditor for the cell
				view.ShowingEditor += (sender, e) => {
					if (prevColumn != view.FocusedColumn || prevRow != view.FocusedRowHandle)
						callCount = 0;		//If we've switched cells, reset the call count.

					if (callCount < 2 && view.FocusedColumn.ShowButtonMode != ShowButtonModeEnum.ShowAlways)
						e.Cancel = true;	//Only show the editor if we've gotten two calls or if we want to show right away

					callCount++;

					prevColumn = view.FocusedColumn;
					prevRow = view.FocusedRowHandle;
				};
			}
		}

		void view_CustomColumnSort(object sender, CustomColumnSortEventArgs e) {
			if (e.Column.FieldName == "FullName") {
				var row1 = e.Column.View.GetDataRow(e.Column.View.GetRowHandle(e.ListSourceRowIndex1));
				var row2 = e.Column.View.GetDataRow(e.Column.View.GetRowHandle(e.ListSourceRowIndex2));

				if (!row1.Table.Columns.Contains("LastName")) {
					var relation = row1.Table.ParentRelations[0];

					row1 = row1.GetParentRow(relation);
					row2 = row2.GetParentRow(relation);
				}

				if (row1 != null && row2 != null) {
					e.Result = StringComparer.CurrentCultureIgnoreCase.Compare(row1.Field<string>("LastName"), row2.Field<string>("LastName"));

					if (e.Result == 0)
						e.Result = StringComparer.CurrentCultureIgnoreCase.Compare(row1.Field<string>("HisName"), row2.Field<string>("HisName"));
					if (e.Result == 0)
						e.Result = StringComparer.CurrentCultureIgnoreCase.Compare(row1.Field<string>("HerName"), row2.Field<string>("HerName"));
					e.Handled = true;
				}
			}
		}
		void view_ShowGridMenu(object sender, GridMenuEventArgs e) {
			if (e.MenuType == GridMenuType.Column) {
				var grid = (GridView)sender;
				var modifier = grid.Columns.ColumnByFieldName("Modifier");
				var modified = grid.Columns.ColumnByFieldName("Modified");
				if (modifier != null && modified != null) {
					var item = new DXMenuCheckItem("Show Modifier Columns", modifier.Visible, null, delegate {
						modifier.Visible = !modifier.Visible;
						modified.Visible = !modified.Visible;
					});
					e.Menu.Items.Add(item);
				}
			}
		}
		void view_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyData == Keys.Delete) {
				var view = sender as GridView;
				var itemName = ListBindingHelper.GetListName(view.DataSource, null).ToLower(CultureInfo.CurrentUICulture);
				if (view.OptionsBehavior.AllowDeleteRows == DefaultBoolean.False) {
					if (itemName == "masterdirectory")
						XtraMessageBox.Show("You cannot delete rows from the master directory.\r\nIf you really want to delete someone, call Schabse.",
											"Shomrei Torah Billing", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				var rows = view.GetSelectedRows().Select<int, DataRow>(view.GetDataRow).ToArray();

				string message;

				if (itemName == "emaillist") {
					if (rows.Length == 1)
						message = "Are you sure you want to delete this email address from the email list?";
					else
						message = "Are you sure you want to delete these email addresses from the email list?";
				} else if (itemName == "statementlog") {
					if (rows.Length == 1)
						message = "Are you sure you want to remove the log for this statement?";
					else
						message = "Are you sure you want to remove the log for these statemente?";
				} else {
					var total = rows.Sum(r => r.Field<decimal>("Amount"));

					if (rows.Length == 1)
						message = "Are you sure you want to delete this " + total.ToString("c", CultureInfo.CurrentUICulture) + " " + itemName.Remove(itemName.Length - 1) + "?";
					else
						message = "Are you sure you want to delete " + rows.Length + " " + itemName + " totaling " + total.ToString("c", CultureInfo.CurrentUICulture) + "?";
				}
				if (DialogResult.Yes == XtraMessageBox.Show(message, "Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
					view.DeleteSelectedRows();
			}
		}
		void view_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
			if (e.Column.FieldName == "Deposit") {
				var row = (BillingData.PaymentsRow)((GridView)sender).GetDataRow(e.RowHandle);
				e.Value = row.DepositsRow;
			}
		}

		protected override void OnLoaded() {
			base.OnLoaded();
			foreach (var view in Views.OfType<ColumnView>())	//MainView will have no columns in RegisterView, so I need to do this here
				CheckColumns(view);
		}
		void CheckColumns(ColumnView view) {
			if (view.Columns.Count == 0) return;
			if (!view.IsDetailView && view != MainView)
				return;	//Skip pattern views. I do each clone individually; otherwise, the event handler won't be added to the clone.


			var fullNameCol = view.Columns.ColumnByFieldName("FullName");
			if (fullNameCol != null) {
				fullNameCol.SortMode = ColumnSortMode.Custom;
				fullNameCol.GroupInterval = ColumnGroupInterval.Alphabetical;
			}

			if (view.Columns.ColumnByFieldName("Deposit") != null)
				view.CustomUnboundColumnData += view_CustomUnboundColumnData;
			if (view.Columns.ColumnByFieldName("CheckNumber") != null)
				view.ValidatingEditor += view_ValidatingEditor;
		}

		void view_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e) {
			if (!e.Valid) return;
			if (!(e.Value is decimal)) return;
			var view = (ColumnView)sender;
			if (view.FocusedColumn.FieldName != "CheckNumber") return;
			var row = (BillingData.PaymentsRow)view.GetFocusedDataRow();

			string message = row.CheckDuplicateWarning((int)(decimal)e.Value, false);
			e.Valid = string.IsNullOrEmpty(message)
					|| DialogResult.Yes == XtraMessageBox.Show(message, "Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
			if (!e.Valid)
				e.ErrorText = message;
		}
	}
}
