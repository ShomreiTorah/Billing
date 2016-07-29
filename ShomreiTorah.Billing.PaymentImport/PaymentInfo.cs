using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShomreiTorah.Billing.PaymentImport {
	///<summary>A payment from an external source that can be imported.</summary>
	public class PaymentInfo {
		public string Id { get; set; }
		public DateTime Date { get; set; }
		public decimal Amount { get; set; }
		public string FinalFour { get; set; }
		public string CardIssuer { get; set; }
		public string PledgeType { get; set; }
		public string Comments { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Company { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string Country { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
	}

	///<summary>A source of external payments to import.</summary>
	public interface IPaymentSource {
		string Name { get; }

		///<summary>Gets all payments made after the given date that have not yet been imported.</summary>
		IEnumerable<PaymentInfo> GetPayments(DateTime start);
	}
}
