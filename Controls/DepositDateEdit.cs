using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Accessibility;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Calendar;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;

namespace ShomreiTorah.Billing.Controls {
	[UserRepositoryItem("Register")]
	sealed class RepositoryItemDepositDateEdit : RepositoryItemDateEdit {
		static RepositoryItemDepositDateEdit() { Register(); }
		public static void Register() {
			EditorRegistrationInfo.Default.Editors.Add(
				new EditorClassInfo(
					"DepositDateEdit",
					typeof(DepositDateEdit),
					typeof(RepositoryItemDepositDateEdit),
					typeof(DateEditViewInfo),
					new ButtonEditPainter(),
					true, EditImageIndexes.DateEdit,
					typeof(PopupEditAccessible)
				)
			);
		}

		public RepositoryItemDepositDateEdit() {
			NullText = "Undeposited";
			if (Program.Data != null) {
				DrawItem += DepositDateEdit_DrawItem;
				Validating += Properties_Validating;
			}
		}

		void Properties_Validating(object sender, CancelEventArgs e) {
			var edit = (DepositDateEdit)sender;
			if (edit.EditValue is DateTime) {
				var hasDeposits = Program.Data.Payments.Any(p => p.DepositDate == edit.DateTime.Date);
				if (!hasDeposits)
					e.Cancel = DialogResult.No == XtraMessageBox.Show("There are no other deposits on " + edit.DateTime.ToLongDateString() + ".\r\nAre you sure you selected the correct date?",
																	  "Shomrei Torah Billing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			}
		}

		void DepositDateEdit_DrawItem(object sender, CustomDrawDayNumberCellEventArgs e) {
			var hasDeposits = Program.Data.Payments.Any(p => p.DepositDate == e.Date.Date);
			if (hasDeposits)
				e.Style.Font = new Font(e.Style.Font, FontStyle.Bold);
		}
		[DefaultValue("Undeposited")]
		public override string NullText {
			get { return base.NullText; }
			set { base.NullText = value; }
		}
		public override string EditorTypeName {
			get { return "DepositDateEdit"; }
		}
	}
	class DepositDateEdit : DateEdit {
		public DepositDateEdit() {
		}


		[Category("Properties")]
		[Description("Gets an object containing properties, methods and events specific to the spin edit control.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public new RepositoryItemDepositDateEdit Properties { get { return base.Properties as RepositoryItemDepositDateEdit; } }
		public override string EditorTypeName {
			get { return "DepositDateEdit"; }
		}
	}
}