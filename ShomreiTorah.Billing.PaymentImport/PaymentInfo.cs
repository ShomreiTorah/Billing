using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShomreiTorah.Billing.PaymentImport {
	///<summary>A payment from an external source that can be imported.</summary>
	public class PaymentInfo {
		public int Id { get; set; }
		public PersonData Person { get; set; }
		public string Email { get; set; }
		public DateTime Date { get; set; }
		public decimal Amount { get; set; }
		public string FinalFour { get; set; }
		public string CardIssuer { get; set; }
		public string PledgeType { get; set; }
		public string Comments { get; set; }
	}

	///<summary>A source of external payments to import.</summary>
	public interface IPaymentSource {
		///<summary>Gets all payments made after the given date that have not yet been imported.</summary>
		IEnumerable<PaymentInfo> GetPayments(DateTime start);
	}
}
