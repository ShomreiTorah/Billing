using System;
using System.Collections.Generic;
using System.Composition;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using ShomreiTorah.Data.UI.DisplaySettings;
using ShomreiTorah.Data.UI.Grid;
using ShomreiTorah.WinForms;
using static ShomreiTorah.Data.UI.DisplaySettings.SettingsRegistrator;

namespace ShomreiTorah.Billing.Migrator {
	[Export(typeof(RibbonButton))]
	public class TriggerButton : RibbonButton {
		static TriggerButton() {
			EditorRepository.Register(StagedPayment.AmountColumn, EditorRepository.CurrencyEditor);
			EditorRepository.Register(StagedPayment.AccountColumn, EditorRepository.AccountEditor);

			GridManager.RegisterColumn(StagedPayment.MethodColumn, MaxWidth(70));
			GridManager.RegisterColumn(StagedPayment.AccountColumn, MaxWidth(100));
			GridManager.RegisterColumn(StagedPayment.CommentsColumn, new CommentsColumnController());
			GridManager.RegisterColumn(
				StagedPayment.AmountColumn,
				new ColumnController(c => {
					c.DisplayFormat.FormatType = FormatType.Numeric;
					c.DisplayFormat.FormatString = "c";

					c.MaxWidth = 85;
					c.SummaryItem.DisplayFormat = "{0:c} Total";
					c.SummaryItem.SummaryType = SummaryItemType.Sum;
				})
			);

			GridManager.RegisterBehavior(StagedPayment.Schema,
				DeletionBehavior.WithMessages<StagedPayment>(
					singular: p => $"Are you sure you don't want to import this {p.Amount:c} payment?",
					plural: payments => $"Are you sure you want to don't want to import {payments.Count()} " +
										$"payments totaling {payments.Sum(p => p.Amount):c}?"
				)
			);

			GridManager.RegisterBehavior(StagedPerson.Schema,
				DeletionBehavior.WithMessages<StagedPerson>(
					singular: p => $"Are you sure you don't want to import {p.FullName}, with {p.StagedPayments.Count} payments?",
					plural: people => $"Are you sure you want to don't want to import {people.Count()} people with " +
										$"payments totaling {people.Sum(p => p.StagedPayments.Sum(pp => pp.Amount)):c}?"
				)
			);
		}

		[Import]
		public IMainForm MainForm { get; set; }

		[Import]
		public ExportFactory<Forms.ImportForm> ImportFactory { get; set; }

		public override string Page => "Admin";
		public override string Group => "Import";
		public override bool BeginGroup => true;

		public override BarItem CreateItem() {
			var item = new BarButtonItem {
				Caption = "Migrate External Data",
				SuperTip = Utilities.CreateSuperTip("Migrate External Data", "Use this form for a one-time migration from QuickBooks or other sources.")
			};
			item.ItemClick += delegate {
				var form = ImportFactory.CreateExport().Value;
				form.MdiParent = (Form)MainForm;
				form.Show();
			};
			return item;
		}
	}
}
