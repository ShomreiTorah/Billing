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

namespace ShomreiTorah.Billing.Controls {
	partial class BaseGrid : GridControl {
		bool initComponentFinished;
		public BaseGrid() { Init(); }
		public BaseGrid(IContainer container) { container.Add(this); Init(); }

		void Init() {
			InitializeComponent();
			initComponentFinished = true;
			DataSource = Program.Data ?? new BillingData();
			accountEdit.Items.Clear();
			accountEdit.Items.AddRange(BillingData.AccountNames);
		}

		//Both our initComponent and our parent's initComponent call begin/end init.
		//I hide the first endInit and the second beginInit.
		public override void BeginInit() {
			if (!initComponentFinished)
				base.BeginInit();
		}
		public override void EndInit() {
			if (initComponentFinished)
				base.EndInit();
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override object DataSource {
			get { return base.DataSource; }
			set { base.DataSource = value; }
		}
		protected override void RegisterView(BaseView gv) {
			base.RegisterView(gv);
			if (DesignMode) return;

			gv.KeyUp += view_KeyUp;

			var view = gv as GridView;
			if (view != null) {
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
		protected override void OnLoaded() {
			base.OnLoaded();
			foreach (var view in Views.OfType<ColumnView>())	//MainView will have no columns in RegisterView, so I need to do this here
				CheckColumns(view);
		}
		void CheckColumns(ColumnView view) {
			if (view.Columns.Count == 0) return;
			if (!view.IsDetailView && view != MainView)
				return;	//Skip pattern views. I do each clone individually; otherwise, the event handler won't be added to the clone.

			var depDateCol = view.Columns.ColumnByFieldName("DepositDateSql");

			if (depDateCol != null && depDateCol.OptionsFilter.FilterPopupMode == FilterPopupMode.Default) {
				depDateCol.OptionsFilter.FilterPopupMode = FilterPopupMode.DateSmart;
				view.ShowFilterPopupDate += view_ShowFilterPopupDate;
			}
		}

		void view_ShowFilterPopupDate(object sender, FilterPopupDateEventArgs e) {
			if (e.Column.FieldName != "DepositDateSql") return;
			e.List.Clear();
			e.List.Add(new FilterDateElement("Undeposited", "Show payments that have not been deposited", new OperandProperty("DepositDateSql").IsNull()));
			e.List.Add(new FilterDateElement("All Deposited", "Show payments that have been deposited", new OperandProperty("DepositDateSql").IsNotNull()));

			e.List.AddRange(
				Program.Data.Payments
					.Where(p => p.DepositDate.HasValue)
					.Select(p => p.DepositDate.Value)
					.Distinct()
					.Select(d => new FilterDateElement(d.ToLongDateString(), "Show payments deposited on " + d.ToLongDateString(), new OperandProperty("DepositDateSql") < d))
			);
		}

		protected override void OnHandleCreated(EventArgs e) {
			base.OnHandleCreated(e);
			if (!DesignMode) {
				var gridView = MainView as GridView;
				if (gridView != null)
					gridView.BestFitColumns();
			}
		}
		void view_KeyUp(object sender, KeyEventArgs e) {
			var view = sender as GridView;
			if (e.KeyData == Keys.Delete) {
				if (view.OptionsBehavior.AllowDeleteRows == DefaultBoolean.False) {
					XtraMessageBox.Show("You cannot delete rows from the master directory.\r\nIf you really want to delete someone, call Schabse.");
					return;
				}

				var rows = view.GetSelectedRows().Select<int, DataRow>(view.GetDataRow).ToArray();

				string message;
				var itemName = ListBindingHelper.GetListName(view.DataSource, null).ToLower(CultureInfo.CurrentUICulture);

				if (itemName == "emaillist") {
					if (rows.Length == 1)
						message = "Are you sure you want to delete this email address from the email list?";
					else
						message = "Are you sure you want to delete these email addresses from the email list?";
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
	}
}
