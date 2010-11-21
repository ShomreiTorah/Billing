using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ShomreiTorah.Data;
using ShomreiTorah.Singularity;

namespace ShomreiTorah.Billing.Events.MelaveMalka {
	partial class CallListForm : XtraForm {
		readonly int year;

		public CallListForm(int year) {
			Program.LoadTable<MelaveMalkaInvitation>();	//Includes Callers as a dependency
			InitializeComponent();

			this.year = year;
			Text = "Melave Malka " + year + " Call List";

			grid.DataMember = null;
			grid.DataSource = new FilteredTable<MelaveMalkaInvitation>(
				Program.Table<MelaveMalkaInvitation>(),
				mmi => mmi.Year == year
			);

			gridView.ActiveFilterCriteria = new OperandProperty("AdAmount") == 0;
		}

		private void showCallers_ItemClick(object sender, ItemClickEventArgs e) {
			new CallerList(year).Show(MdiParent);
		}
	}
}