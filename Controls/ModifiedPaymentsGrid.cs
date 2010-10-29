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

		void Payments_ValueChanged(object sender, ValueChangedEventArgs<Payment> e) {
			gridView.BestFitColumns();
			Program.Table<Payment>().ValueChanged -= Payments_ValueChanged;
		}
	}
}
