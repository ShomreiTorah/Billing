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

namespace ShomreiTorah.Billing.Controls.Editors {
	partial class AliyahNotePopup : XtraUserControl {
		const string EmptyRelative = "(None)";
		static readonly string[] RelativeNames = new[]{
			"Brother", "Brother-in-law",
			"Father", "Father-in-law",
			"Son", "Son-in-law",
			"Guest"
		};
		readonly AliyahNoteEdit edit;
		public AliyahNotePopup(AliyahNoteEdit edit) {
			InitializeComponent();
			UpdateUI();
			this.edit = edit;
		}

		static readonly Regex MatanahMatcher = new Regex(@"(^|\s|[;,|/\+-])+(מתנה|Matanah?)(\s|[;,|/\+-]|$)+", RegexOptions.IgnoreCase);
		public string NoteText {
			get { return fullText.Text; }
			set { fullText.Text = value.Trim(); }
		}

		private void fullText_EditValueChanged(object sender, EventArgs e) { UpdateUI(); }
		bool isUpdatingUI;
		void UpdateUI() {
			isUpdatingUI = true;
			isMatanah.Checked = MatanahMatcher.IsMatch(NoteText);
			var name = isMatanah.Checked ? MatanahMatcher.Replace(NoteText, "") : NoteText;
			name = name.Trim();

			relative.BeginUpdate();
			relative.Items.Clear();
			relative.Items.Add(EmptyRelative);
			relative.Items.AddRange(RelativeNames);

			if (!String.IsNullOrEmpty(name) && !RelativeNames.Contains(name, StringComparer.CurrentCultureIgnoreCase))
				relative.Items.Add(name);
			if (String.IsNullOrEmpty(name))
				relative.SelectedValue = EmptyRelative;
			else
				relative.SelectedValue = name;

			relative.EndUpdate();
			isUpdatingUI = false;
		}

		private void relative_SelectedIndexChanged(object sender, EventArgs e) { GenerateText(); }
		private void isMatanah_CheckedChanged(object sender, EventArgs e) { GenerateText(); }
		private void relative_Click(object sender, EventArgs e) { GenerateText(); }

		void GenerateText() {
			if (isUpdatingUI) return;

			string text = "";

			if (relative.SelectedValue != null && relative.SelectedValue.ToString() != EmptyRelative)
				text = relative.SelectedValue.ToString();

			if (isMatanah.Checked) {
				if (text.Length > 0)
					text += ", מתנה";
				else
					text = "מתנה";
			}
			
			fullText.Text = text;
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
