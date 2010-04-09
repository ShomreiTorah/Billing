using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShomreiTorah.Billing.Forms.GridForms {
	partial class PledgeViewer : GridFormBase {
		public PledgeViewer() { InitializeComponent(); }

		protected override void OnShown(EventArgs e) {
			base.OnShown(e);
			colNote.Width = 150;
			colComments.Width = 120;
		}
	}
}