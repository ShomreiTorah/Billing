using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data.Filtering;

namespace ShomreiTorah.Billing.Forms.GridForms {
	partial class StatementLogViewer : GridFormBase {
		public StatementLogViewer(string media) {
			InitializeComponent();

			Text = media + " Statements";
			gridView.ActiveFilterCriteria = new OperandProperty("Media") == media;
		}
	}
}