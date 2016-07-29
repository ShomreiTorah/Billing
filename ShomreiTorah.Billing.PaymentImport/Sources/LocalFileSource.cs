using System;
using System.Collections.Generic;
using System.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShomreiTorah.Common;

namespace ShomreiTorah.Billing.PaymentImport.Sources {
	///<summary>Imports payments from a local JSON file, for debugging.</summary>
	[Export]
	class LocalFileSource : IPaymentSource {
		public string Name => "Local File";

		public IEnumerable<PaymentInfo> GetPayments(DateTime start) {
			var path = Config.ReadAttribute("Billing", "PaymentImport", "Source", "LocalPath");
			return JsonConvert.DeserializeObject<List<PaymentInfo>>(File.ReadAllText(path))
				.Where(p => p.Date >= start);
		}
	}
}
