using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Accessibility;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using ShomreiTorah.Common.Calendar;
using ShomreiTorah.WinForms.Controls;

namespace ShomreiTorah.Billing.Controls {
	sealed class HebrewCalendarEdit : PopupBaseEdit {
		static HebrewCalendarEdit() { RepositoryItemHebrewCalendarEdit.Register(); }

		[Category("Properties")]
		[Description("Gets an object containing properties, methods and events specific to the spin edit control.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public new RepositoryItemHebrewCalendarEdit Properties { get { return base.Properties as RepositoryItemHebrewCalendarEdit; } }
		public override string EditorTypeName { get { return "HebrewCalendarEdit"; } }

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DateTime DateTime {
			get { return (DateTime)EditValue; }
			set { EditValue = value; }
		}
		///<summary>Gets the time component of the current value, if any.</summary>
		///<remarks>This property is used to preserve the TimeOfDay when 
		///the user selects a date. Since HebrewDates do not store times,
		///I need to manually re-add the time in MyPopupForm.ResultValue.</remarks>
		private TimeSpan TimeSpan { get { return EditValue is DateTime ? DateTime.TimeOfDay : TimeSpan.Zero; } }

		protected override void DoShowPopup() {
			FlushPendingEditActions();	//Force the DateTime to reflect manual edits
			base.DoShowPopup();
		}

		protected override PopupBaseForm CreatePopupForm() { return new MyPopupForm(this); }
		class MyPopupForm : PopupBaseForm {
			public new HebrewCalendarEdit OwnerEdit { get { return (HebrewCalendarEdit)base.OwnerEdit; } }
			public HebrewCalendar Calendar { get; private set; }
			public MyPopupForm(HebrewCalendarEdit owner)
				: base(owner) {

				Calendar = new HebrewCalendar { Dock = DockStyle.Fill };
				Calendar.KeyUp += Calendar_KeyUp;
				Calendar.DateClicked += Calendar_DateClicked;

				Controls.Add(Calendar);
			}
			protected override Size CalcFormSizeCore() { return new Size(744, 533); }

			public override void ShowPopupForm() {
				if (OwnerEdit.EditValue == null || OwnerEdit.EditValue == DBNull.Value)
					Calendar.SelectedDate = null;
				else
					Calendar.SelectedDate = (DateTime)OwnerEdit.EditValue;	//TODO: Select the bottom-right corner; selection changes
				base.ShowPopupForm();
				Calendar.Focus();
			}

			void Calendar_KeyUp(object sender, KeyEventArgs e) {
				if (e.KeyCode == Keys.Enter)
					ClosePopup();
			}
			void Calendar_DateClicked(object sender, HebrewDateEventArgs e) {
				ClosePopup();
			}
			public override object ResultValue {
				get { return Calendar.SelectedDate == null ? null : (object)(Calendar.SelectedDate.Value.EnglishDate + OwnerEdit.TimeSpan); }
			}
		}
	}

	[UserRepositoryItem("Register")]
	sealed class RepositoryItemHebrewCalendarEdit : RepositoryItemPopupBase {
		static RepositoryItemHebrewCalendarEdit() { Register(); }
		public static void Register() {
			EditorRegistrationInfo.Default.Editors.Add(
				new EditorClassInfo(
					"HebrewCalendarEdit",
					typeof(HebrewCalendarEdit),
					typeof(RepositoryItemHebrewCalendarEdit),
					typeof(PopupBaseEditViewInfo),
					new ButtonEditPainter(),
					true, EditImageIndexes.DateEdit,
					typeof(PopupEditAccessible)
				)
			);
		}

		public RepositoryItemHebrewCalendarEdit() {
			Mask.MaskType = MaskType.DateTime;

			DisplayFormat.FormatType = EditFormat.FormatType = FormatType.DateTime;
			Mask.EditMask = DisplayFormat.FormatString = EditFormat.FormatString = "d";

			TextEditStyle = TextEditStyles.Standard;
		}

		public override string EditorTypeName {
			get { return "HebrewCalendarEdit"; }
		}
	}
}