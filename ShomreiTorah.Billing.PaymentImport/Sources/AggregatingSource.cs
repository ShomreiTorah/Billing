using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ShomreiTorah.Common;

namespace ShomreiTorah.Billing.PaymentImport.Sources {
	[Export]
	public class AggregatingSource {
		private readonly IReadOnlyList<IPaymentSource> sources;

		[ImportingConstructor]
		public AggregatingSource([ImportMany] IEnumerable<IPaymentSource> sources) {
			var byName = sources.ToDictionary(s => s.Name);
			this.sources = Config.GetElement("Billing", "PaymentImport", "Sources")
								 .Elements()
								 .Select(n => byName[n.Name.LocalName])
								 .ToList();
		}

		public async Task<IEnumerable<PaymentInfo>> GetPaymentsAsync(DateTime start, CancellationToken cancellationToken) {
			var results = await Task.WhenAll(
				sources.Select(async s => (await s.GetPaymentsAsync(start, cancellationToken))
											.Select(p => p.WithSource(s.Name)))
			);
			var seen = new Dictionary<string, PaymentInfo>();

			return results.SelectMany(list => list.Where(p => {
				// If we've already seen this payment, update its amount
				// from the later (refining) source, but do not return a
				// second copy.
				if (seen.TryGetValue(p.Id, out var match)) {
					match.Amount = p.Amount;
					return false;
				}
				seen.Add(p.Id, p);
				return true;
			})).ToList();   // Process all sources immediately to merge in later duplicates.
		}
	}
}
