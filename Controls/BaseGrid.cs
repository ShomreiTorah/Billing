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
using ShomreiTorah.Common;

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
			gv.DoubleClick += view_DoubleClick;

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

		void view_DoubleClick(object sender, EventArgs e) {
			var view = (GridView)sender;
			var rowHandle = view.CalcHitInfo(PointToClient(MousePosition)).RowHandle;

			if (rowHandle >= 0)
				ShowDetailsForm(view.GetDataRow(rowHandle));
		}
		public static void ShowDetailsForm(DataRow row) {
			switch (row.Table.TableName) {
				case "MasterDirectory":
					new Forms.PersonDetails((BillingData.MasterDirectoryRow)row) { MdiParent = Program.MainForm }.Show();
					break;
				case "Pledges":
					new Forms.PledgeEditPopup((BillingData.PledgesRow)row).Show(Program.MainForm);
					break;
				case "Payments":
					new Forms.PaymentEditPopup((BillingData.PaymentsRow)row).Show(Program.MainForm);
					break;
			}
		}

		static readonly string[] SubTypeSorts = new[] { "כהן", "לוי", "שלישי", "רביעי", "חמישי", "שישי", "שביעי", "מפטיר", "פתיחה", "הגבהה" };
		void view_CustomColumnSort(object sender, CustomColumnSortEventArgs e) {
			switch (e.Column.FieldName) {
				case "SubType":
					var index1 = Array.IndexOf(SubTypeSorts, e.Value1 as string);
					var index2 = Array.IndexOf(SubTypeSorts, e.Value2 as string);

					e.Result = index1.CompareTo(index2);
					e.Handled = index1 != index2;
					break;
				case "FullName":
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
					break;
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
				var view = (GridView)sender;
				var dataView = view.DataSource as DataView;
				if (dataView == null) {
					var bindingSource = view.DataSource as BindingSource;
					if (bindingSource != null)
						dataView = bindingSource.List as DataView;
				}
				Debug.Assert(dataView != null);

				var row = (BillingData.PaymentsRow)dataView[e.ListSourceRowIndex].Row;

				Debug.Assert(e.RowHandle == GridControl.InvalidRowHandle || row == view.GetDataRow(e.RowHandle));

				e.Value = row.DepositsRow;
			}
		}

		protected override void OnLoaded() {
			base.OnLoaded();
			foreach (var view in Views.OfType<ColumnView>())	//MainView will have no columns in RegisterView, so I need to do this here
				CheckColumns(view);
		}
		///<summary>Called for each concrete (non-pattern) view after the view's columns have been populated.</summary>
		///<remarks>This is called for the grid's primary view(s) in OnLoaded, and for detail clones in RegisterView.</remarks>
		void CheckColumns(ColumnView view) {
			if (view.Columns.Count == 0) return;
			if (!view.IsDetailView && view != MainView)
				return;	//Skip pattern views. I do each clone individually; otherwise, the event handler won't be added to the clone.


			var fullNameCol = view.Columns.ColumnByFieldName("FullName");
			if (fullNameCol != null) {
				fullNameCol.SortMode = ColumnSortMode.Custom;
				fullNameCol.GroupInterval = ColumnGroupInterval.Alphabetical;
			}
			var subtypeCol = view.Columns.ColumnByFieldName("SubType");
			if (subtypeCol != null)
				subtypeCol.SortMode = ColumnSortMode.Custom;

			if (view.Columns.ColumnByFieldName("Deposit") != null) {
				view.CustomUnboundColumnData += view_CustomUnboundColumnData;
				view.ShowFilterPopupListBox += view_ShowFilterPopupListBox;
			}
			if (view.Columns.ColumnByFieldName("CheckNumber") != null)
				view.ValidatingEditor += view_ValidatingEditor;
		}

		void view_ShowFilterPopupListBox(object sender, FilterPopupListBoxEventArgs e) {
			if (e.Column.FieldName == "Deposit") {
				foreach (var item in e.ComboBox.Items.OfType<FilterItem>()) {
					var valueItem = item.Value as FilterItem;
					if (valueItem != null) {
						if ((int)valueItem.Value == 2)
							item.Text = "(Undeposited)";
						else if ((int)valueItem.Value == 3)
							item.Text = "(All deposited)";
					}
				}
			}
		}

		void view_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e) {
			if (!e.Valid) return;

			var view = (ColumnView)sender;
			if (view.FocusedColumn.FieldName != "CheckNumber") return;
			var row = (BillingData.PaymentsRow)view.GetFocusedDataRow();

			string message = row.CheckDuplicateWarning(e.Value as string, false);
			e.Valid = string.IsNullOrEmpty(message)
					|| DialogResult.Yes == XtraMessageBox.Show(message, "Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
			if (!e.Valid)
				e.ErrorText = message;
		}
	}
}
