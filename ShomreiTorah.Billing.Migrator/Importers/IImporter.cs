using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShomreiTorah.Common;

namespace ShomreiTorah.Billing.Migrator.Importers {
	///<summary>Populates staging tables with data from an external source.</summary>
	public interface IImporter {
		string Name { get; }
		string Filter { get; }
		void Import(string fileName, IProgressReporter progress);
	}
}
