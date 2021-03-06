﻿using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using ShomreiTorah.WinForms;

namespace ShomreiTorah.Billing.PaymentImport {
	[Export(typeof(RibbonButton))]
	public class TriggerButton : RibbonButton {
		[Import]
		public IMainForm MainForm { get; set; }

		[Import]
		public ExportFactory<ImportForm> ImportFactory { get; set; }

		public override string Page => "Data";
		public override string Group => "Payments";
		public override bool BeginGroup => true;

		public override BarItem CreateItem() {
			var item = new BarButtonItem { Caption = "Import Credit Card Payments" };
			item.ItemClick += delegate {
				var form = ImportFactory.CreateExport().Value;
				form.MdiParent = (Form)MainForm;
				form.Show();
			};
			return item;
		}
	}
}
