using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ShomreiTorah.Data.UI.DisplaySettings;
using ShomreiTorah.Data;

namespace ShomreiTorah.Billing.Forms {
	partial class RelationCreator : XtraForm {
		public static void Execute(Person member = null, Person relative = null) {
			using (var dialog = new RelationCreator()) {
				dialog.memberSelector.SelectedPerson = member;
				dialog.relativeSelector.SelectedPerson = relative;

				if (dialog.ShowDialog() == DialogResult.Cancel)
					return;

				Program.Table<RelativeLink>().Rows.Add(new RelativeLink {
					Member = dialog.memberSelector.SelectedPerson,
					Relative = dialog.relativeSelector.SelectedPerson,
					RelationType = dialog.relationType.Text
				});
			}
		}

		public RelationCreator() {
			InitializeComponent();
			EditorRepository.RelationListEditor.Apply(relationType.Properties);
			memberSelector.Properties.Buttons.RemoveAt(1);	//Delete the Add Person button; it doesn't make sense to add a new member here
			SetEnabled();
		}

		void SetEnabled() {
			add.Enabled = memberSelector.SelectedPerson != null
					   && relativeSelector.SelectedPerson != null
					   && memberSelector.SelectedPerson != relativeSelector.SelectedPerson
					   && !String.IsNullOrWhiteSpace(relationType.Text);
		}

		private void Edit_ValueChanged(object sender, EventArgs e) { SetEnabled(); }
	}
}