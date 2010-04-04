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

namespace ShomreiTorah.Billing.Controls.Editors {
	partial class AliyahNotePopup : XtraUserControl {
		const string EmptyRelative = "(None)";
		static readonly string[] RelativeNames = new[]{
			"Brother", "Brother-in-law",
			"Father", "Father-in-law",
			"Son", "Son-in-law",
			"Guest"
		};

		public AliyahNotePopup() {
			InitializeComponent();
			UpdateUI();
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
			if (isMatanah.Checked)
				text = "מתנה";

			if (relative.SelectedValue != null && relative.SelectedValue.ToString() != EmptyRelative) {
				if (isMatanah.Checked)
					text += ", ";
				text += relative.SelectedValue.ToString();
			}

			fullText.Text = text;
		}
	}
	[UserRepositoryItem("Register")]
	sealed class RepositoryItemAliyahNoteEdit : RepositoryItemPopupContainerEdit {
		static RepositoryItemAliyahNoteEdit() { Register(); }
		public static void Register() {
			EditorRegistrationInfo.Default.Editors.Add(
				new EditorClassInfo(
					"AliyahNoteEdit",
					typeof(AliyahNoteEdit),
					typeof(RepositoryItemAliyahNoteEdit),
					typeof(PopupContainerEditViewInfo),
					new ButtonEditPainter(),
					true, EditImageIndexes.TextEdit,
					typeof(PopupEditAccessible)
				)
			);
		}
		public override string EditorTypeName { get { return "AliyahNoteEdit"; } }

		public RepositoryItemAliyahNoteEdit() {
			AliyahNotePopup = new AliyahNotePopup { Dock = DockStyle.Fill };
			PopupControl = new PopupContainerControl { Width = 200, Height = 325 };//{ Width = 215+3, Height = 158+7 };
			PopupControl.Controls.Add(AliyahNotePopup);

			ShowPopupCloseButton = false;
			PopupSizeable = false;

			TextEditStyle = TextEditStyles.Standard;
		}


		#region Properties
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public AliyahNotePopup AliyahNotePopup { get; private set; }

		[Description("Gets or sets whether the text box is visible and enabled.")]
		[Category("Behavior")]
		[DefaultValue(TextEditStyles.Standard)]
		public new TextEditStyles TextEditStyle {
			get { return base.TextEditStyle; }
			set { base.TextEditStyle = value; }
		}
		[Description("Gets or sets a value indicating whether the close button is displayed within the popup window.")]
		[Category("Behavior")]
		[DefaultValue(false)]
		public new bool ShowPopupCloseButton {
			get { return base.ShowPopupCloseButton; }
			set { base.ShowPopupCloseButton = value; }
		}
		[Description("Gets or sets a value indicating whether end-users can resize the popup window.")]
		[Category("Behavior")]
		[DefaultValue(false)]
		public new bool PopupSizeable {
			get { return base.PopupSizeable; }
			set { base.PopupSizeable = value; }
		}
		#endregion
		protected override void RaiseQueryResultValue(QueryResultValueEventArgs e) {
			e.Value = AliyahNotePopup.NoteText;
			base.RaiseQueryResultValue(e);
		}
	}
	class AliyahNoteEdit : PopupContainerEdit {
		static AliyahNoteEdit() { RepositoryItemAliyahNoteEdit.Register(); }

		[Category("Properties")]
		[Description("Gets an object containing properties, methods and events specific to the spin edit control.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public new RepositoryItemAliyahNoteEdit Properties { get { return base.Properties as RepositoryItemAliyahNoteEdit; } }

		public override string EditorTypeName { get { return "AliyahNoteEdit"; } }
		protected override void DoShowPopup() {
			Properties.AliyahNotePopup.NoteText = EditValue as string;
			base.DoShowPopup();
		}
	}
}
