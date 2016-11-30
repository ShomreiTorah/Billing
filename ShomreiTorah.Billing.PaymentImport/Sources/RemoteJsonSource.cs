using System;
using System.Collections.Generic;
using System.Composition;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShomreiTorah.Common;

namespace ShomreiTorah.Billing.PaymentImport.Sources {
	///<summary>Imports payments from a remote JSON endpoint over HTTPS.  The URL is expected to include an auth token.</summary>
	[Export(typeof(IPaymentSource))]
	class RemoteJsonSource : IPaymentSource {
		public string Name => "RemoteJson";

		public async Task<IEnumerable<PaymentInfo>> GetPaymentsAsync(DateTime start, CancellationToken cancellationToken) {
			var url = new UriBuilder(Config.ReadAttribute("Billing", "PaymentImport", "Sources", "RemoteJson", "Url"));
			url.Query = (String.IsNullOrEmpty(url.Query) ? "" : url.Query.TrimStart('?') + "&")
					  + "start=" + start.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

			using (var client = new HttpClient()) {
				var response = await client.GetAsync(url.Uri, cancellationToken);

				return JsonConvert.DeserializeObject<List<PaymentInfo>>(await response.Content.ReadAsStringAsync());
			}
		}
	}
}
