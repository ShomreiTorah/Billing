using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShomreiTorah.Common;

namespace ShomreiTorah.Billing.PaymentImport.Sources {
	[Export(typeof(IPaymentSource))]
	public class WufooSource : IPaymentSource {
		public string Name => "Wufoo";

		public async Task<IEnumerable<PaymentInfo>> GetPaymentsAsync(DateTime start, CancellationToken cancellationToken) {
			var subdomain = Config.ReadAttribute("Billing", "PaymentImport", "Sources", Name, "Subdomain");
			var formName = Config.ReadAttribute("Billing", "PaymentImport", "Sources", Name, "FormName");
			var apiKey = Config.ReadAttribute("Billing", "PaymentImport", "Sources", Name, "ApiKey");

			var client = new HttpClient();
			var authBytes = Encoding.UTF8.GetBytes(apiKey + ":password");
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authBytes));
			string formUrl = $@"https://{subdomain}.wufoo.com/api/v3/forms/{formName}/";

			Task<string> fieldsTask = client.GetStringAsync(formUrl + "fields.json");
			Task<string> entriesTask = client.GetStringAsync(formUrl + "entries.json?system=true");
			// Fetch both responses in parallel.
			var fieldsResponse = JsonConvert.DeserializeObject<FieldsResponse>(await fieldsTask);
			var fieldIds = fieldsResponse
				.Fields
				.Concat<IFieldInfo>(fieldsResponse.Fields.SelectMany(f => f.SubFields))
				.Where(f => !string.IsNullOrEmpty(f.Title))
				.ToLookup(f => f.Title, f => f.Id);
			var fieldAliases = fieldsResponse
				.Fields
				.Where(f => f.SubFields.Count == 0) // The first subfield shares an ID with its parent.
				.Concat<IFieldInfo>(fieldsResponse.Fields.SelectMany(f => f.SubFields))
				.Where(f => !string.IsNullOrEmpty(f.Title))
				.ToDictionary(f => f.Id, f => f.Title);
			var responses = JObject.Parse(await entriesTask).Value<JArray>("Entries").Cast<JObject>();

			var fieldNameMappings = Config.GetElement("Billing", "PaymentImport", "Sources", Name, "FieldNames")
				.Elements()
				.ToLookup(e => e.Name.LocalName, e => e.Attribute("Alias").Value);
			return responses.Where(o => o.Value<string>("Status") == "Paid").Select(o => {
				var usedFields = new HashSet<string>();
				string Field(string name) {
					var names = fieldNameMappings[name].DefaultIfEmpty(name);
					usedFields.AddRange(names.SelectMany(n => fieldIds[n]));
					return names.SelectMany(n => fieldIds[n].Select(f => o.Value<string>(f))).Join("\r\n").Trim();
				}

				int? CoerceNumber(string value) {
					if (string.IsNullOrWhiteSpace(value)) return null;
					if (value.Equals("Yes", StringComparison.OrdinalIgnoreCase)) return 1;
					if (value.Equals("No", StringComparison.OrdinalIgnoreCase)) return 0;
					return int.Parse(value);
				}

				PaymentInfo payment = new PaymentInfo {
					// System fields:
					Amount = o.Value<decimal>("PurchaseTotal"),
					Date = o.Value<DateTime>("DateCreated"),
					Id = o.Value<string>("TransactionId"),

					// Mapped user fields:
					Address = (Field("Address") + " " + Field("Address2").Trim()),
					FirstName = Field("FirstName"),
					LastName = Field("LastName"),
					City = Field("City"),
					Comments = Field("Comments"),
					Email = Field("Email"),
					Phone = Field("Phone"),
					Country = Field("Country"),
					State = Field("State"),
					Zip = Field("Zip"),
					JournalInfo = new PaymentJournalInfo {
						AdText = Field("AdText"),
						MensSeats = CoerceNumber(Field("MensSeats")),
						WomensSeats = CoerceNumber(Field("WomensSeats")),
					}
				};

				payment.Comments += "\r\n" + o
					.Properties()
					.Where(p => !string.IsNullOrEmpty(p.Value.ToString()))
					.Where(p => !usedFields.Contains(p.Name))
					.Where(p => p.Name.StartsWith("Field"))
					.Select(p => $"{fieldAliases[p.Name]}: {p.Value}".Trim().TrimStart(':', ' '))
					.OrderBy(s => s)
					.Join("\r\n");
				return payment;
			});
		}

		public class FieldsResponse {
			public List<FieldInfo> Fields { get; set; }
		}
		public interface IFieldInfo {
			string Id { get; }
			string Title { get; }
		}
		public class FieldInfo : IFieldInfo {
			public string Id { get; set; }
			public string Title { get; set; }
			public List<SubFieldInfo> SubFields { get; } = new List<SubFieldInfo>();
		}
		public class SubFieldInfo : IFieldInfo {
			public string Id { get; set; }
			public string Label { get; set; }

			public string Title => Label;
		}
	}
}
