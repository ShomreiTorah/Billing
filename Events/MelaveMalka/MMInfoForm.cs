using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ShomreiTorah.Data;

namespace ShomreiTorah.Billing.Events.MelaveMalka {
	partial class MMInfoForm : XtraForm {
		public MMInfoForm() {
			Program.LoadTable<MelaveMalkaInfo>();
			InitializeComponent();
		}

		private void showAddForm_ItemClick(object sender, ItemClickEventArgs e) {
			new MMInfoAdder().Show(this);
		}
	}
}