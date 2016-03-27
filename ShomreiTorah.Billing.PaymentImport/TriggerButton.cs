using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraBars;
using ShomreiTorah.WinForms;

namespace ShomreiTorah.Billing.PaymentImport {
	[Export(typeof(RibbonButton))]
	public class TriggerButton : RibbonButton {
		[Import]
		public Forms.MainForm MainForm { get; set; }

		public override string Page => "Data";
		public override string Group => "Payments";
		public override bool BeginGroup => true;

		public override BarItem CreateItem() {
			var item = new BarButtonItem { Caption = "Import Credit Card Payments" };
			item.ItemClick += delegate { Dialog.Show("TODO", System.Windows.Forms.MessageBoxIcon.Information); };
			return item;
		}
	}
}
