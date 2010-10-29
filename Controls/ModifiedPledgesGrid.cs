using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;
using ShomreiTorah.Data;
using ShomreiTorah.Singularity;

namespace ShomreiTorah.Billing.Controls {
	partial class ModifiedPledgesGrid : XtraUserControl {
		public ModifiedPledgesGrid() {
			InitializeComponent();
			gridView.ActiveFilterCriteria = new OperandProperty("Modified") > Program.LaunchTime.ToUniversalTime();
			if (!Program.Current.IsDesignTime)
				Program.Table<Pledge>().ValueChanged += Pledges_ValueChanged;
		}

		void Pledges_ValueChanged(object sender, ValueChangedEventArgs<Pledge> e) {
			gridView.BestFitColumns();
			Program.Table<Pledge>().ValueChanged -= Pledges_ValueChanged;
		}
	}
}
