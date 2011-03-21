using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using ShomreiTorah.Data;
using ShomreiTorah.Singularity.DataBinding;

namespace ShomreiTorah.Billing.Forms {
	partial class PledgeMigrator : XtraForm {
		readonly Person payee;
		readonly IList<Pledge> pledges;
		readonly BitArray selection;
		public PledgeMigrator(Person payee, IList<Pledge> pledges) {
			InitializeComponent();

			this.payee = payee;
			this.pledges = pledges;

			selection = new BitArray(pledges.Count);	//This must happen before the grid calls CustomUnboundColumnData

			grid.DataMember = null;
			grid.DataSource = new RowListBinder(Program.Table<Pledge>(), pledges.ToArray());	//Array covariance

			WinForms.CheckableGridController.Handle(colCheck);

			UpdateLabel();
		}

		void UpdateLabel() {
			var text = new StringBuilder();
			text.Append(payee.FullName).AppendLine(" has relatives in the Shul who have made the following pledges in his name.");
			text.Append("Would you like to reassociate these pledges to ").Append(payee.FullName).Append("?");

			var count = SelectedPledges.Count();
			if (count > 0) {
				text.AppendLine().AppendLine();
				text.AppendFormat(CultureInfo.CurrentCulture, "{0:#,0} pledge{1} selected, {2:c}",
								  count, count == 1 ? "" : "s", SelectedPledges.Sum(p => p.Amount));
				ok.Text = "Move pledges";
			} else
				ok.Text = "Close";
			instructions.Text = text.ToString();
		}

		public IEnumerable<Pledge> SelectedPledges {
			get { return pledges.Where((p, i) => selection[i]); }
		}

		private void gridView_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e) {
			if (e.Column == colCheck) {
				if (e.IsGetData)
					e.Value = selection[e.ListSourceRowIndex];
				else {
					selection[e.ListSourceRowIndex] = (bool)e.Value;
					UpdateLabel();
				}
			}
		}
	}
}