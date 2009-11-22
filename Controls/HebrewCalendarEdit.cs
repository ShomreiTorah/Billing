using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Accessibility;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using ShomreiTorah.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.Utils;
using ShomreiTorah.Common.Calendar;
using DevExpress.XtraEditors.Controls;

namespace ShomreiTorah.Billing.Controls {
	sealed class HebrewCalendarEdit : PopupContainerEdit {
		static HebrewCalendarEdit() {
			EditorRegistrationInfo.Default.Editors.Add(
				new EditorClassInfo(
					"HebrewCalendarEdit",
					typeof(HebrewCalendarEdit),
					typeof(RepositoryItemHebrewCalendarEdit),
					typeof(PopupContainerEditViewInfo),
					new ButtonEditPainter(),
					true, EditImageIndexes.DateEdit,
					typeof(PopupEditAccessible)
				)
			);
		}

		[Category("Properties")]
		[Description("Gets an object containing properties, methods and events specific to the spin edit control.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public new RepositoryItemHebrewCalendarEdit Properties { get { return base.Properties as RepositoryItemHebrewCalendarEdit; } }

		public override string EditorTypeName {
			get { return "HebrewCalendarEdit"; }
		}

		protected override void DoShowPopup() {
			FlushPendingEditActions();	
			if (EditValue == null || EditValue == DBNull.Value)
				Properties.Calendar.SelectedDate = null;
			else
				Properties.Calendar.SelectedDate = (DateTime)EditValue;
			base.DoShowPopup();
		}
	}
	sealed class RepositoryItemHebrewCalendarEdit : RepositoryItemPopupContainerEdit {
		public RepositoryItemHebrewCalendarEdit() {
			Calendar = new HebrewCalendar { Dock = DockStyle.Fill };
			Calendar.KeyUp += Calendar_KeyUp;
			Calendar.DateClicked += Calendar_DateClicked;

			PopupControl = new PopupContainerControl { Width = 750, Height = 475 };//{ Width = 215+3, Height = 158+7 };
			PopupControl.Controls.Add(Calendar);

			ShowPopupCloseButton = false;
			PopupSizeable = false;

			Mask.MaskType = MaskType.DateTime;

			DisplayFormat.FormatType = EditFormat.FormatType = FormatType.DateTime;
			Mask.EditMask = DisplayFormat.FormatString = EditFormat.FormatString = "d";

			TextEditStyle = TextEditStyles.Standard;
		}

		void Calendar_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter)
				OwnerEdit.ClosePopup();
		}

		void Calendar_DateClicked(object sender, HebrewDateEventArgs e) {
			OwnerEdit.ClosePopup();
		}
		protected override void RaiseQueryResultValue(QueryResultValueEventArgs e) {
			if (Calendar.SelectedDate == null)
				e.Value = null;
			else
				e.Value = Calendar.SelectedDate.Value.EnglishDate;
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public HebrewCalendar Calendar { get; private set; }

		public override string EditorTypeName {
			get { return "HebrewCalendarEdit"; }
		}
	}
}
