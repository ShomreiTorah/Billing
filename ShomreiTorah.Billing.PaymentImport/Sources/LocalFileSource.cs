using System;
using System.Collections.Generic;
using System.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShomreiTorah.Common;

namespace ShomreiTorah.Billing.PaymentImport.Sources {
	///<summary>Imports payments from a local JSON file, for debugging.</summary>
	[Export(typeof(IPaymentSource))]
	public class LocalFileSource : IPaymentSource {
		public string Name => "LocalJson";

		public Task<IEnumerable<PaymentInfo>> GetPaymentsAsync(DateTime start, CancellationToken cancellationToken) {
			var path = Config.ReadAttribute("Billing", "PaymentImport", "Sources", "LocalJson", "Path");
			return Task.FromResult(JsonConvert.DeserializeObject<List<PaymentInfo>>(File.ReadAllText(path))
				.Where(p => p.Date >= start));
		}
	}
}
