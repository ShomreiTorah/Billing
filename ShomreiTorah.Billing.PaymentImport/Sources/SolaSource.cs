using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShomreiTorah.Common;
using System;
using System.Collections.Generic;
using System.Composition;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShomreiTorah.Billing.PaymentImport.Sources {
	[Export(typeof(IPaymentSource))]
	public class SolaSource : IPaymentSource {
		public string Name => "Sola";
		public async Task<IEnumerable<PaymentInfo>> GetPaymentsAsync(DateTime start, CancellationToken cancellationToken) {
			using (var httpClient = new HttpClient()) {
				var response = await httpClient.PostAsync("https://x1.cardknox.com/reportjson", new ByteArrayContent(Encoding.UTF8.GetBytes(
					new JObject(
						new JProperty("xKey", Config.ReadAttribute("Billing", "PaymentImport", "Sources", "Sola", "Key")),
						new JProperty("xSoftwareName", "ShomreiTorah.Billing"),
						new JProperty("xSoftwareVersion", "0.0"),
						new JProperty("xCommand", "report:all"),
						new JProperty("xBeginDate", start.ToString("yyyy-MM-dd")),
						new JProperty("xEndDate", DateTime.Today.ToString("yyyy-MM-dd")),
						new JProperty("xFields", "xRefNum,xCardType,xName,xMaskedCardNumber,xEnteredDate,xAmount,xResponseResult,xCommand"),
						new JProperty("xVersion", "5.0.0")
					).ToString())),
					cancellationToken
				);

				using (var stream = await response.Content.ReadAsStreamAsync())
				using (var textReader = new StreamReader(stream, Encoding.UTF8))
				using (var reader = new JsonTextReader(textReader)) {
					var result = JObject.Load(reader);
					if ((string)result.Property("xStatus") != "Success") {
						throw new InvalidOperationException($"Sola returned an error.  Status: {result.Property("xStatus").Value}, Error: {result.Property("xError").Value}");
					}
					return result.Value<JArray>("xReportData")
							.Where(row => row.Value<string>("xCommand") == "CC:Sale" && row.Value<string>("xResponseResult") == "Approved")
							.Select(row => {
								var fullName = (string)row["xName"];
								var nameSpace = Math.Max(0, fullName.LastIndexOf(' '));
								var maskedCardNumber = (string)row["xMaskedCardNumber"];
								return new PaymentInfo {
									Id = (string)row["xRefNum"],
									Date = DateTime.Parse((string)row["xEnteredDate"]),
									FirstName = fullName.Substring(0, nameSpace).Trim(),
									LastName = fullName.Substring(nameSpace).Trim(),
									Amount = (decimal)row["xAmount"],
									FinalFour = maskedCardNumber.Substring(maskedCardNumber.Length - 4),
									CardIssuer = (string)row["xCardType"],
								};
							});

				};
			}
		}
	}
}
