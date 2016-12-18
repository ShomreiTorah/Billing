using ShomreiTorah.Billing.PaymentImport;
using ShomreiTorah.Data;

namespace ShomreiTorah.Billing.Migrator {
	partial class StagedPerson : IPerson, IImportingPerson {
		string IImportingPerson.Email => null;
		string IImportingPerson.FinalFour => null;
		string IImportingPerson.FirstName => HisName ?? HerName;
	}
}
