using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing;

namespace ShomreiTorah.Billing.Controls {
	class CopyableWebBrowser : WebBrowser {
		public static XtraForm CreatePreviewForm(string title, string html) {
			var form = new XtraForm {
				Text = title,
				FormBorderStyle = FormBorderStyle.SizableToolWindow,
				Size = new Size(800, 600),
				StartPosition = FormStartPosition.CenterParent,
			};
			var browser = new CopyableWebBrowser {
				Dock = DockStyle.Fill,
				AllowNavigation = false,
				AllowWebBrowserDrop = false,
				DocumentText = html,
				IsWebBrowserContextMenuEnabled = false,
				WebBrowserShortcutsEnabled = false
			};
			form.Controls.Add(browser);
			return form;
		}
		public override bool PreProcessMessage(ref Message msg) {
			if (msg.Msg == 0x101) {	//WM_KEYUP
				var key = (Keys)msg.WParam.ToInt32();
				if (key == Keys.C && ModifierKeys == Keys.Control) {
					DoCopy();
					return true;
				} else if (key == Keys.Escape) {
					FindForm().Close();
					return true;
				}
			}
			return base.PreProcessMessage(ref msg);
		}
		void DoCopy() {
			Document.ExecCommand("SelectAll", false, null);
			Document.ExecCommand("Copy", false, null);
			Document.ExecCommand("Unselect", false, null);
		}
	}
}
