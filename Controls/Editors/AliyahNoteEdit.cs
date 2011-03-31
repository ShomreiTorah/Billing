using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.Accessibility;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.Text.RegularExpressions;
using DevExpress.XtraEditors.Popup;
using ShomreiTorah.Data;

namespace ShomreiTorah.Billing.Controls.Editors {
	partial class AliyahNotePopup : XtraUserControl {
		readonly AliyahNoteEdit edit;
		public AliyahNotePopup(AliyahNoteEdit edit) {
			InitializeComponent();
			UpdateUI();
			this.edit = edit;

			relative.BeginUpdate();
			relative.Items.Clear();
			relative.Items.Add(AliyahNote.EmptyRelative);
			relative.Items.AddRange(Names.RelationNames.ToArray());
			relative.EndUpdate();
		}

		readonly AliyahNote parsed = new AliyahNote();
		public string NoteText {
			get { return fullText.Text; }
			set {
				parsed.Text = value;
				fullText.Text = parsed.Text;	//After normalization
			}
		}

		private void fullText_EditValueChanged(object sender, EventArgs e) {
			if (isUpdatingUI) return;
			parsed.Text = fullText.Text;
			UpdateUI();
		}
		private void fullText_Leave(object sender, EventArgs e) {
			fullText.Text = parsed.Text;	//Normalize the text after the user edits it.
		}

		bool isUpdatingUI;
		void UpdateUI() {
			isUpdatingUI = true;
			isMatanah.Checked = parsed.Isמתנה;

			if (String.IsNullOrEmpty(parsed.Relative))
				relative.SelectedValue = AliyahNote.EmptyRelative;
			else
				relative.SelectedValue = parsed.Relative;

			isUpdatingUI = false;
		}

		private void isMatanah_CheckedChanged(object sender, EventArgs e) {
			if (isUpdatingUI) return;
			parsed.Isמתנה = isMatanah.Checked;
			fullText.Text = parsed.Text;
		}
		private void relative_SelectedIndexChanged(object sender, EventArgs e) {
			if (isUpdatingUI) return;
			parsed.Relative = relative.Text;
			fullText.Text = parsed.Text;
		}

		private void relative_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) edit.ClosePopup();
		}
		private void relative_DoubleClick(object sender, EventArgs e) { edit.ClosePopup(); }
	}
	[UserRepositoryItem("Register")]
	sealed class RepositoryItemAliyahNoteEdit : RepositoryItemPopupBase {
		static RepositoryItemAliyahNoteEdit() { Register(); }
		public static void Register() {
			EditorRegistrationInfo.Default.Editors.Add(
				new EditorClassInfo(
					"AliyahNoteEdit",
					typeof(AliyahNoteEdit),
					typeof(RepositoryItemAliyahNoteEdit),
					typeof(PopupBaseEditViewInfo),
					new ButtonEditPainter(),
					true, EditImageIndexes.TextEdit,
					typeof(PopupEditAccessible)
				)
			);
		}
		public override void CreateDefaultButton() {
			Buttons.Add(new EditorButton(ButtonPredefines.Ellipsis) { IsDefaultButton = true });
		}

		public override string EditorTypeName { get { return "AliyahNoteEdit"; } }
	}

	class AliyahNotePopupForm : PopupBaseForm {
		AliyahNotePopup control;
		public AliyahNotePopupForm(AliyahNoteEdit edit)
			: base(edit) {
			control = new AliyahNotePopup(edit) { Dock = DockStyle.Fill };
			Controls.Add(control);
		}

		//public new AliyahNoteEdit OwnerEdit { get { return base.OwnerEdit as AliyahNoteEdit; } }

		protected override Size CalcFormSizeCore() { return new Size(200, 325); }

		public override object ResultValue { get { return control.NoteText; } }
		public override void ShowPopupForm() {
			control.NoteText = OwnerEdit.Text;
			base.ShowPopupForm();
			control.Focus();
		}
	}


	class AliyahNoteEdit : PopupBaseEdit {
		static AliyahNoteEdit() { RepositoryItemAliyahNoteEdit.Register(); }

		[Category("Properties")]
		[Description("Gets an object containing properties, methods and events specific to the spin edit control.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public new RepositoryItemAliyahNoteEdit Properties { get { return base.Properties as RepositoryItemAliyahNoteEdit; } }

		protected override PopupBaseForm CreatePopupForm() { return new AliyahNotePopupForm(this); }

		public override string EditorTypeName { get { return "AliyahNoteEdit"; } }
	}
}
