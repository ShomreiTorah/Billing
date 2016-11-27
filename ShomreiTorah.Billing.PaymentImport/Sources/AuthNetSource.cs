using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AuthorizeNetLite;
using AuthorizeNetLite.Options;
using AuthorizeNetLite.TransactionDetails;
using AuthorizeNetLite.Transactions;
using ShomreiTorah.Common;

namespace ShomreiTorah.Billing.PaymentImport.Sources {
	///<summary>Imports payments from the Authorize.Net API.</summary>
	[Export(typeof(IPaymentSource))]
	class AuthNetSource : IPaymentSource {
		public String Name => "AuthorizeNet";

		public async Task<IEnumerable<PaymentInfo>> GetPaymentsAsync(DateTime start, CancellationToken cancellationToken) {
			Configuration.RegisterConfiguration(GatewayUrl.Production, new Authentication {
				ApiLogin = Config.ReadAttribute("Billing", "PaymentImport", "Source", "ApiLogin"),
				TransactionKey = Config.ReadAttribute("Billing", "PaymentImport", "Source", "TransactionKey"),
			});

			var details = await Task.WhenAll(
				(await GetBatchIdsAsync(start, DateTime.Now, cancellationToken))
					.Select(b => BatchTransactionsRequest.GetAsync(b, cancellationToken))
					.Select(async ts => (await ts).Select(t => TransactionDetailRequest.GetAsync(t.TransactionID, cancellationToken))));
			return (await Task.WhenAll(details.Select(Task.WhenAll)))
				.SelectMany(a => a)
				.Select(t => new PaymentInfo {
					Address = t.BillingAddress.Street,
					Amount = t.Status == "voided" ? 0 : t.AuthorizedAmount,
					CardIssuer = (t.Payment[0] as CreditCard)?.CardType,
					City = t.BillingAddress.City,
					Company = t.BillingAddress.Company,
					Country = t.BillingAddress.Country,
					Date = t.SubmittedLocal,
					Email = t.Customer?.EMail,
					FinalFour = (t.Payment[0] as CreditCard)?.CardNumber?.Trim('X'),
					FirstName = t.BillingAddress.FirstName,
					Id = t.TransactionID.ToString(),
					LastName = t.BillingAddress.LastName,
					Phone = t.BillingAddress.PhoneNumber,
					State = t.BillingAddress.State,
					Zip = t.BillingAddress.ZipCode
				});
		}

		async Task<IEnumerable<Int64>> GetBatchIdsAsync(DateTime start, DateTime end, CancellationToken cancellationToken) {
			const Int32 MaxDays = 31;

			start = DateTime.SpecifyKind(start, DateTimeKind.Local);
			end = DateTime.SpecifyKind(end, DateTimeKind.Local);
			if ((end - start).Days <= MaxDays)
				return (await SettledBatchListRequest.GetAsync(start, end, cancellationToken)).Select(b => b.BatchID);

			var batches = await Task.WhenAll(
				Enumerable.Range(0, (int)Math.Ceiling((end - start).TotalDays / MaxDays))
					.Select(d => SettledBatchListRequest.GetAsync(
						start.AddDays(d * MaxDays), start.AddDays((d + 1) * MaxDays), cancellationToken)));
			return batches.SelectMany(a => a).Select(b => b.BatchID).Distinct();
		}
	}
}
