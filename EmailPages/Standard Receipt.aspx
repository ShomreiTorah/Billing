<%@ Page Language="C#" Inherits="ShomreiTorah.Billing.Export.EmailPage, ShomreiTorah.Billing" %>

<%@ Assembly Name="System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="ShomreiTorah.Billing.Export" %>

<script runat="server">
	public override string EmailSubject { get { return "Shomrei Torah Receipt"; } }
	public override BillKind Kind { get { return BillKind.Receipt; } }
</script>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>

	<head>
		<title>Shomrei Torah Receipt</title>
		<style type="text/css">
			body {
				font-family: Verdana;
			}
			h1 {
				font-size: large;
				text-align: center;
				border-bottom: solid blue 1px;
			}
			td {
				border-bottom: solid 1px navy;
			}
			thead th {
				border-bottom: solid 2px black;
			}
			td.Date {
				padding-right: 8px;
			}
			td.Amount {
				text-align: right;
			}
			.Total td {
				border-top: solid 2px black;
				padding-top: 10px;
			}
			.Total .Amount {
				font-weight: bold;
			}
			.Payments th {
				padding-top: 25px;
			}
		</style>
	</head>

	<body>
		<p>
			Dear
			<%=Info.Person.FullName %>,</p>
		<p>
			On behalf of Rabbi Weinberger and Congregation Shomrei Torah, we would like to express
			our gratitude for your financial support and valued participation in our davening
			and learning. Through your generosity, support, and participation our Shul will
			continue to grow and thrive as a special place of Torah and Avodah.</p>
		<p>
			Please review the summary below. If you have any questions regarding any of the
			pledges or payments contained herein, please reply to this email or contact Yaacov
			Gitstein at (732) 516 - 5583. Thank you.
		</p>
		<p>
			תזכו למצות</p>
		<%foreach (var account in Info.Accounts) {%>
		<h1>
			<%=Server.HtmlEncode(account.AccountName) %></h1>
		<table cellspacing="0" class="Payments">
			<thead>
				<tr>
					<th colspan="3">Payments</th>
				</tr>
			</thead>
			<%foreach (var payment in account.Payments) {%>
			<tr>
				<td class="Date">
					<%=payment.Date.ToShortDateString() %></td>
				<td class="Description">
					<%=payment.Method.Replace("Unknown", "?")%>
					<%if (!payment.IsCheckNumberNull()) {%>#<%=payment.CheckNumber %><%} %></td>
				<td class="Amount">
					<%=payment.Amount.ToString("c") %></td>
			</tr>
			<%} %>
			<tr class="Total">
				<td class="Description" colspan="2">Total:</td>
				<td class="Amount">
					<%=account.Payments.Sum(p => p.Amount).ToString("c")%></td>
			</tr>
		</table>
		<%} %>
	</body>

</html>
