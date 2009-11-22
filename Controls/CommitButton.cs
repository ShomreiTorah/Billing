using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Drawing;

namespace ShomreiTorah.Billing.Controls {
	class CommitButton : SimpleButton {
		CommitType commitType;
		public CommitButton() {
			CommitType = CommitType.Create;
		}

		[Category("Appearance")]
		[DefaultValue(CommitType.Create)]
		public CommitType CommitType {
			get { return commitType; }
			set {
				commitType = value;
				switch (value) {
					case CommitType.Create:
						base.Text = "Add";
						Image = Properties.Resources.Add16;
						break;
					case CommitType.Save:
						base.Text = "Update";
						Image = Properties.Resources.Save16;
						break;
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override string Text {
			get { return base.Text; }
			set { base.Text = CommitType == CommitType.Create ? "Add" : "Update"; ; }
		}
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override Image Image {
			get { return base.Image; }
			set { base.Image = value; }
		}
	}
	enum CommitType {
		Create,
		Save
	}
}
