using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShomreiTorah.Data;
using ShomreiTorah.Singularity;
using ShomreiTorah.Singularity.DataBinding;

namespace ShomreiTorah.Billing.Migrator.Forms {
	public partial class ImportForm : Form {
		public ImportForm() {
			InitializeComponent();
		}
	}
	///<summary>A component that binds to a dummy DataContext for use in designers in libraries.</summary>
	class DesignerBinder : BindableDataContextBase {
		static DesignerBinder() {
			// Whenever you change an assembly, the designer loads a new copy of it.
			// However, it keeps the already-loaded copies of referenced assemblies.
			// Therefore, new versions of this project can load against old versions
			// of ShomreiTorah.Data.dll. This causes errors, because the old version
			// of this assembly will have already registered its child relation with
			// the singleton Person schema. To solve this problem, check whether the
			// Person schema already has our child relation from an older build, and
			// delete the old column (from the old schema) so that we can replace it
			// with the new schema's child relation in its static constructor. Maybe
			// I shouldn't have made these singletons…
			var existingSchema = Person.Schema.ChildRelations["StagedPeople"]?.ChildSchema;
			if (existingSchema?.RowType != typeof(StagedPerson))
				existingSchema?.Columns.RemoveColumn("Person");
		}

		protected override DataContext FindDataContext() {
			var context = new DataContext();
			context.Tables.AddTable(PledgeLink.CreateTable());
			context.Tables.AddTable(Payment.CreateTable());
			context.Tables.AddTable(Pledge.CreateTable());

			context.Tables.AddTable(Person.CreateTable());

			context.Tables.AddTable(StagedPayment.CreateTable());
			context.Tables.AddTable(StagedPerson.CreateTable());

			return context;
		}
	}
}
