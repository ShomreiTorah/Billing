using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using DevExpress.Accessibility;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using ShomreiTorah.Billing.Properties;

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
			var personAccessor = (IPersonAccesor)row;
			BaseGrid.ShowDetailsForm(personAccessor.Person);
		}
		public new PersonRefEdit OwnerEdit { get { return (PersonRefEdit)base.OwnerEdit; } }
	}
	class PersonRefEdit : ButtonEdit {
		static PersonRefEdit() { RepositoryItemPersonRefEdit.Register(); }

		internal DataRow SelectedRow {
			get {
				var grid = (GridControl)Parent;
				var view = (ColumnView)grid.FocusedView;
				return view.GetFocusedDataRow();
			}
		}

		protected override void OnDoubleClick(EventArgs e) {
			base.OnDoubleClick(e);
			BaseGrid.ShowDetailsForm(SelectedRow);
		}

		[Category("Properties")]
		[Description("Gets an object containing properties, methods and events specific to the control.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public new RepositoryItemPersonRefEdit Properties { get { return base.Properties as RepositoryItemPersonRefEdit; } }

		public override string EditorTypeName { get { return "PersonRefEdit"; } }
	}
}
