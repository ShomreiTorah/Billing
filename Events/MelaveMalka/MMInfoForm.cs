using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ShomreiTorah.Data;
using DevExpress.XtraGrid.Views.Base;
using System.Windows.Forms;
using System.Globalization;
using ShomreiTorah.WinForms;
using ShomreiTorah.Common;
using ShomreiTorah.WinForms.Forms;
using System.IO;

namespace ShomreiTorah.Billing.Events.MelaveMalka {
	partial class MMInfoForm : XtraForm {
		public MMInfoForm() {
			Program.LoadTable<MelaveMalkaInfo>();
			InitializeComponent();
		}

		private void showAddForm_ItemClick(object sender, ItemClickEventArgs e) {
			new MMInfoAdder().Show(this);
		}

		private void uploadAdBlank_ItemClick(object sender, ItemClickEventArgs e) {
			var row = gridView.GetFocusedRow() as MelaveMalkaInfo;

			string filePath;
			using (var dialog = new OpenFileDialog {
				Filter = "PDF Files (*.pdf)|*.pdf|All Files|*.*",
				Title = "Select " + row.Year + " Ad Blank"
			}) {
				if (dialog.ShowDialog(this) == DialogResult.Cancel) return;
				filePath = dialog.FileName;
			}
			if (!filePath.Contains(row.Year.ToString(CultureInfo.InvariantCulture))) {
				if (!Dialog.Warn("Are you sure that " + filePath + " is the " + row.Year + " ad blank?"))
					return;
			}

			ProgressWorker.Execute(progress => {
				progress.Caption = "Uploading " + Path.GetFileName(filePath);
				FtpClient.Default.UploadFile(row.AdBlankPath, filePath, progress);
			}, cancellable: false);
		}

		private void gridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e) {
			var row = gridView.GetFocusedRow() as MelaveMalkaInfo;
			uploadAdBlank.Visibility = row == null ? BarItemVisibility.OnlyInCustomizing : BarItemVisibility.Always;
			if (row != null)
				uploadAdBlank.Caption = "Upload " + row.Year + " Ad Blank";
		}
	}
}