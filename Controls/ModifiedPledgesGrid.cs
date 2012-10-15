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

		//Wait until we get some visible data before auto-sizing the grid.
		void Pledges_ValueChanged(object sender, ValueChangedEventArgs<Pledge> e) {
			if (((Table)sender).IsLoadingData) return;
			gridView.BestFitColumns();
			Program.Table<Pledge>().ValueChanged -= Pledges_ValueChanged;
		}
	}
}
