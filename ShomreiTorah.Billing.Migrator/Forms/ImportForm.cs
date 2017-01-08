using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Composition;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using ShomreiTorah.Billing.Migrator.Importers;
using ShomreiTorah.Billing.PaymentImport;
using ShomreiTorah.Common;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI;
using ShomreiTorah.Singularity;
using ShomreiTorah.Singularity.DataBinding;
using ShomreiTorah.WinForms.Forms;

namespace ShomreiTorah.Billing.Migrator.Forms {
	[Export]
	public partial class ImportForm : XtraForm {
		private readonly IReadOnlyList<IImporter> importers;

		[ImportingConstructor]
		public ImportForm([ImportMany] IEnumerable<IImporter> importers) {
			AppFramework.LoadTables(StagedPerson.Schema, StagedPayment.Schema);
			InitializeComponent();
			this.importers = importers.ReadOnlyCopy();

			importSources.Strings.AddRange(importers.Select(s => s.Name).ToArray());
		}

		private void importSources_ListItemClick(object sender, ListItemClickEventArgs e) {
			var source = importers[e.Index];
			using (var openDialog = new OpenFileDialog {
				Filter = source.Filter,
				Title = "Load " + source.Name
			}) {
				if (openDialog.ShowDialog(MdiParent) == DialogResult.Cancel)
					return;
				SynchronizationContext uiThread = SynchronizationContext.Current;
				using (AppFramework.Table<StagedPerson>().BeginLoadData(uiThread))
				using (AppFramework.Table<StagedPayment>().BeginLoadData(uiThread))
					ProgressWorker.Execute(
						MdiParent,
						progress => source.Import(openDialog.FileName, uiThread, progress),
						cancellable: true
					);
			}
		}

		private void clearStaging_ItemClick(object sender, ItemClickEventArgs e) {
			// TODO: Use SQL delete statement for efficiency?
			AppFramework.Table<StagedPerson>().Rows.Clear();
		}

		private void doImport_ItemClick(object sender, ItemClickEventArgs e) {

		}

		private void createPledges_ItemClick(object sender, ItemClickEventArgs e) {

		}

		#region Grid View Buttons
		private void sortByPersonCount_ItemClick(object sender, ItemClickEventArgs e) {
			peopleView.ClearGrouping();
			colPerson.Group();
			peopleView.GroupSummarySortInfo.Add(new GridSummaryItem(SummaryItemType.Count, "Person", "{0} staged people"), ColumnSortOrder.Descending);
		}

		private void filterByNonMatch_ItemClick(object sender, ItemClickEventArgs e) {
			peopleView.ActiveFilterCriteria = new OperandProperty(nameof(StagedPerson.Person)) != new OperandValue(null);
			colCity.Group();
		}

		private void filterByScore_CheckedChanged(object sender, ItemClickEventArgs e) {
			peopleView.RefreshData();
		}

		private void peopleView_CustomRowFilter(object sender, RowFilterEventArgs e) {
			if (!filterByScore.Checked)
				return;
			var person = AppFramework.Table<StagedPerson>().Rows[e.ListSourceRow];
			// If the row should be hidden, handle the event to force-hide the row.
			// Otherwise, leave it unhandled, to allow the user to further filter.
			e.Handled = person.Person == null || Matcher.GetMatchScore(person, person.Person) == 0;
			e.Visible = false;
		}
		#endregion

		static readonly Color[] matchColors = { Color.LightGreen, Color.Yellow, Color.Red };
		private void peopleView_RowStyle(object sender, RowStyleEventArgs e) {
			var person = (StagedPerson)peopleView.GetRow(e.RowHandle);
			if (person == null)
				e.Appearance.BackColor = Color.LightPink;
			else
				e.Appearance.BackColor = matchColors[Matcher.GetMatchScore(person, person.Person)];
		}

		private void peopleView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e) {
			if (e.Column == colPerson)
				e.RepositoryItem = e.CellValue == null ? nullPersonEdit : matchingPersonEdit;
		}

		private void matchingPersonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) {
			if (e.Button.Index == 1)
				((StagedPerson)peopleView.GetFocusedRow()).Person = null;
		}
	}
	///<summary>A component that binds to a dummy DataContext for use in designers in libraries.</summary>
	class DesignerBinder : BindableDataContextBase {
		static DesignerBinder() {
			// Whenever you change an assembly, the designer loads a new copy of it.
			// However, it keeps the already-loaded copies of referenced assemblies.
			// Therefore, new versions of this project can load against old versions
			// of ShomreiTorah.Data.dll. This causes errors, because the old version
			// of this assembly will have already registered its child relation with
			// the singleton Person schema. To solve this problem, check whether the
			// Person schema already has our child relation from an older build, and
			// delete the old column (from the old schema) so that we can replace it
			// with the new schema's child relation in its static constructor. Maybe
			// I shouldn't have made these singletons…
			var existingSchema = Person.Schema.ChildRelations["StagedPeople"]?.ChildSchema;
			if (existingSchema?.RowType != typeof(StagedPerson))
				existingSchema?.Columns.RemoveColumn("Person");
		}

		protected override DataContext FindDataContext() {
			if (AppFramework.Table<StagedPerson>() != null)
				return AppFramework.Current.DataContext;

			// At design time, we will have the main Billing AppFramework, which doesn't have our tables.

			var context = new DataContext();
			context.Tables.AddTable(PledgeLink.CreateTable());
			context.Tables.AddTable(Payment.CreateTable());
			context.Tables.AddTable(Pledge.CreateTable());

			context.Tables.AddTable(Person.CreateTable());

			context.Tables.AddTable(StagedPayment.CreateTable());
			context.Tables.AddTable(StagedPerson.CreateTable());

			return context;
		}
	}
}
