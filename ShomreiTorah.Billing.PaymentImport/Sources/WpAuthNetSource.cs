using System;
using System.Collections.Generic;
using System.Composition;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShomreiTorah.Common;

namespace ShomreiTorah.Billing.PaymentImport.Sources {
	///<summary>Imports payments from the MySQL database used by WP AuthNet.</summary>
	[Export]
	[ExportMetadata("Name", "WP AuthNet")]
	public class WpAuthNetSource : IPaymentSource {
		public IEnumerable<PaymentInfo> GetPayments(DateTime start) {
			DB.RegisterFactory("MySql", MySql.Data.MySqlClient.MySqlClientFactory.Instance);
			DB.RegisterFactory("MySql.Data.MySqlClient", MySql.Data.MySqlClient.MySqlClientFactory.Instance);

			var db = new DBConnector(Config.GetElement("Databases", "WordPress"));

			using (var reader = db.ExecuteReader(@"
SELECT p.id, s.name,
	us.billingFirstName, us.billingLastName, us.billingCompany,
	us.billingAddress, us.billingCity, us.billingState, us.billingZip, us.billingCountry, us.billingPhone,
	us.emailAddress,
	us.lastFourDigitsOfCreditCard, p.xAmount, p.paymentDate,
	us.subscriptionNotes, us.userIP,
	CONVERT(p.fullAuthorizeNetResponse USING utf8) AS response
FROM wp_authnet_user_subscription us
	JOIN wp_authnet_payment p ON us.ID = p.user_subscription_id
	LEFT JOIN wp_authnet_subscription s ON s.ID = p.xSubscriptionId
WHERE p.paymentDate > ?start", new { start })) {
				return reader.Cast<IDataRecord>()
							 .Select(dr => new PaymentInfo {
								 Id = dr.GetInt32(dr.GetOrdinal("id")),
								 Email = dr.GetString(dr.GetOrdinal("emailAddress")),
								 FinalFour = dr.GetString(dr.GetOrdinal("lastFourDigitsOfCreditCard")),
								 CardIssuer = dr.GetString(dr.GetOrdinal("response")).Split('|')[51],
								 PledgeType = dr.GetString(dr.GetOrdinal("name")),
								 Date = dr.GetDateTime(dr.GetOrdinal("paymentDate")),
								 Amount = dr.GetDecimal(dr.GetOrdinal("xAmount")),
								 Comments = dr.GetString(dr.GetOrdinal("subscriptionNotes"))
										  + "\nIP Address: " + dr.GetString(dr.GetOrdinal("userIP"))
							 })
							 .ToList();
			}
		}
	}
}
