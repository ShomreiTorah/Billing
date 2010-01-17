using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ShomreiTorah.Common;

namespace ShomreiTorah.Billing.Controls {
	partial class NewPerson : XtraForm {
		DataView mdView;
		Func<PersonData, BillingData.MasterDirectoryRow> creator;
		public NewPerson() : this(p => Program.Data.MasterDirectory.AddMasterDirectoryRow(p, "Manually Added")) { }
		public NewPerson(Func<PersonData, BillingData.MasterDirectoryRow> creator) {
			if (creator == null) throw new ArgumentNullException("creator");

			this.creator = creator;
			InitializeComponent();
			mdView = new DataView(Program.Data.MasterDirectory);
			grid.DataSource = mdView;
		}

		private void newData_PersonChanged(object sender, EventArgs e) {
			var data = newData.Data;
			create.Enabled = !data.IsEmpty();

			var filters = new List<string>();
			if (!string.IsNullOrEmpty(data.HisName))
				filters.Add("HisName LIKE '" + data.HisName.Replace("'", "''") + "*'");
			if (!string.IsNullOrEmpty(data.HerName))
				filters.Add("HerName LIKE '" + data.HerName.Replace("'", "''") + "*'");
			if (!string.IsNullOrEmpty(data.LastName))
				filters.Add("LastName LIKE '" + data.LastName.Replace("'", "''") + "*'");

			mdView.RowFilter = filters.Join(" And ");
		}

		public BillingData.MasterDirectoryRow SelectedPerson { get; private set; }
		private void gridView_DoubleClick(object sender, EventArgs e) {
			SelectedPerson = (BillingData.MasterDirectoryRow)gridView.GetFocusedDataRow();
			DialogResult = DialogResult.OK;
			Close();
		}

		private void create_Click(object sender, EventArgs e) {
			SelectedPerson = creator(newData.Data);
		}
	}
}