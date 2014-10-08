using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ShomreiTorah.Data;
using DevExpress.XtraCharts;

namespace ShomreiTorah.Billing.Controls {
	public partial class TransactionLog : UserControl {
		public TransactionLog() {
			InitializeComponent();
		}

		public void SetData(IEnumerable<ITransaction> transactions, IEnumerable<Tuple<DateTime, string>> events) {
			decimal runningBalance = 0;
			var data = transactions
				.OrderBy(t => t.Date)
				.Select(t => new {
					t.Date,
					t.Account,
					Description = (t is Pledge ? ((Pledge)t).Type + ", " + ((Pledge)t).SubType : ((Payment)t).Method + ", " + ((Payment)t).CheckNumber).TrimEnd(' ', ','),
					Amount = t.SignedAmount,
					RunningBalance = (runningBalance += t.SignedAmount)
				})
				.ToList();
			gridControl.DataSource = chartControl.DataSource = data;
			gridView.BestFitColumns();

			var xyDiagram = (XYDiagram)chartControl.Diagram;
			foreach (var e in events) {
				xyDiagram.AxisX.ConstantLines.Add(new ConstantLine(e.Item2, e.Item1));
			}
		}
	}
}
