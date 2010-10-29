using System;
using System.ComponentModel;
using DevExpress.Accessibility;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using ShomreiTorah.Billing.Properties;
using ShomreiTorah.Data;
using ShomreiTorah.Data.UI;
using ShomreiTorah.Singularity;

namespace ShomreiTorah.Billing.Controls.Editors {
	[UserRepositoryItem("Register")]
	sealed class RepositoryItemPersonRefEdit : RepositoryItemButtonEdit {
		static RepositoryItemPersonRefEdit() { Register(); }
		public static void Register() {
			EditorRegistrationInfo.Default.Editors.Add(
				new EditorClassInfo(
					"PersonRefEdit",
					typeof(PersonRefEdit),
					typeof(RepositoryItemPersonRefEdit),
					typeof(ButtonEditViewInfo),
					new ButtonEditPainter(),
					true, EditImageIndexes.ButtonEdit,
					typeof(ButtonEditAccessible)
				)
			);
		}
		public override string EditorTypeName { get { return "PersonRefEdit"; } }

		public RepositoryItemPersonRefEdit() {
			ReadOnly = true;
			TextEditStyle = TextEditStyles.DisableTextEditor;
		}
		public override void CreateDefaultButton() {
			Buttons.Add(new EditorButton(ButtonPredefines.Glyph) { Image = Resources.UserGrid, IsLeft = true, ToolTip = "Show Person" });
		}

		protected override void RaiseButtonClick(ButtonPressedEventArgs e) {
			base.RaiseButtonClick(e);

			var row = OwnerEdit.SelectedRow;
			var personAccessor = (IOwnedObject)row;
			AppFramework.Current.ShowDetails(personAccessor.Person);
		}
		public new PersonRefEdit OwnerEdit { get { return (PersonRefEdit)base.OwnerEdit; } }
	}
	class PersonRefEdit : ButtonEdit {
		static PersonRefEdit() { RepositoryItemPersonRefEdit.Register(); }

		internal Row SelectedRow {
			get {
				var grid = (GridControl)Parent;
				var view = (ColumnView)grid.FocusedView;
				return (Row)view.GetFocusedRow();
			}
		}

		protected override void OnDoubleClick(EventArgs e) {
			base.OnDoubleClick(e);
			var row = SelectedRow;
			if (Program.Current.CanShowDetails(row.Schema))
				Program.Current.ShowDetails(row);
		}

		[Category("Properties")]
		[Description("Gets an object containing properties, methods and events specific to the control.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public new RepositoryItemPersonRefEdit Properties { get { return base.Properties as RepositoryItemPersonRefEdit; } }

		public override string EditorTypeName { get { return "PersonRefEdit"; } }
	}
}
