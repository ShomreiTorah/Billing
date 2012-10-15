using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;
using ShomreiTorah.Data;
using ShomreiTorah.Singularity;

namespace ShomreiTorah.Billing.Controls {
	partial class ModifiedPaymentsGrid : XtraUserControl {
		public ModifiedPaymentsGrid() {
			InitializeComponent();
			gridView.ActiveFilterCriteria = new OperandProperty("Modified") > Program.LaunchTime.ToUniversalTime();
			if (!Program.Current.IsDesignTime)
				Program.Table<Payment>().ValueChanged += Payments_ValueChanged;
		}

		//Wait until we get some visible data before auto-sizing the grid.
		void Payments_ValueChanged(object sender, ValueChangedEventArgs<Payment> e) {
			if (((Table)sender).IsLoadingData) return;
			gridView.BestFitColumns();
			Program.Table<Payment>().ValueChanged -= Payments_ValueChanged;
		}
	}
}
