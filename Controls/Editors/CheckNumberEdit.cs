using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.Accessibility;
using System.ComponentModel;
using DevExpress.Utils;

namespace ShomreiTorah.Billing.Controls.Editors {

	[UserRepositoryItem("Register")]
	sealed class RepositoryItemCheckNumberEdit : RepositoryItemTextEdit {
		static RepositoryItemCheckNumberEdit() { Register(); }
		public static void Register() {
			EditorRegistrationInfo.Default.Editors.Add(
				new EditorClassInfo(
					"CheckNumberEdit",
					typeof(CheckNumberEdit),
					typeof(RepositoryItemCheckNumberEdit),
					typeof(TextEditViewInfo),
					new TextEditPainter(),
					true, EditImageIndexes.TextEdit,
					typeof(TextEditAccessible)
				)
			);
		}
		public override string EditorTypeName {
			get { return "CheckNumberEdit"; }
		}

		public RepositoryItemCheckNumberEdit() {
			NullText = "N/A";
			AllowNullInput = DefaultBoolean.True;
		}

		[Category("Behavior")]
		[Description("Gets or sets the string displayed in the edit box when the editor's BaseEdit.EditValue is null.")]
		[DefaultValue("N/A")]
		public new string NullText {
			get { return base.NullText; }
			set { base.NullText = value; }
		}
		[RefreshProperties(RefreshProperties.All)]
		[Category("Behavior")]
		[Description("Gets or sets whether end-users can set the editor's value to a null reference.")]
		[DefaultValue(DefaultBoolean.True)]
		public new DefaultBoolean AllowNullInput {
			get { return base.AllowNullInput; }
			set { base.AllowNullInput = value; }
		}
	}
	class CheckNumberEdit : TextEdit {
		static CheckNumberEdit() { RepositoryItemCheckNumberEdit.Register(); }
		protected override void RaiseEditValueChanged() {
			if (((string)EditValue).Length == 0)
				EditValue = null;
			else
				base.RaiseEditValueChanged();
		}

		[Category("Properties")]
		[Description("Gets an object containing properties, methods and events specific to the spin edit control.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public new RepositoryItemCheckNumberEdit Properties { get { return base.Properties as RepositoryItemCheckNumberEdit; } }

		public override string EditorTypeName {
			get { return "CheckNumberEdit"; }
		}
	}
}
