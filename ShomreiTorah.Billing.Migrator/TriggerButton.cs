using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using ShomreiTorah.WinForms;

namespace ShomreiTorah.Billing.Migrator {
	[Export(typeof(RibbonButton))]
	public class TriggerButton : RibbonButton {
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
