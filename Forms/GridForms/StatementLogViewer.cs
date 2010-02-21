using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Data.Filtering;
using DevExpress.XtraEditors.Controls;

namespace ShomreiTorah.Billing.Forms.GridForms {
	partial class StatementLogViewer : GridFormBase {
		public StatementLogViewer(string media) {
			InitializeComponent();

			Text = media + " Statements";
			gridView.ActiveFilterCriteria = new OperandProperty("Media") == media;
		}

		private void personRefEdit_ButtonClick(object sender, ButtonPressedEventArgs e) {
			var row = gridView.GetFocusedDataRow() as BillingData.StatementLogRow;
			new PersonDetails(row.MasterDirectoryRow) { MdiParent = MdiParent }.Show();
		}
	}
}