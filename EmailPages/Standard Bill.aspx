<%@ Page Language="C#" Inherits="ShomreiTorah.Billing.Export.EmailPage, ShomreiTorah.Billing" %>

<%@ Assembly Name="System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="ShomreiTorah.Billing.Export" %>

<script runat="server">
	public override string EmailSubject { get { return "Shomrei Torah Bill"; } }
	public override BillKind Kind { get { return BillKind.Bill; } }
</script>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>

	<head>
		<title>Shomrei Torah Bill</title>
		<style type="text/css">
			body {
				font-family: Verdana;
			}
			td {
				border-bottom: solid 1px gray;
			}
			.Total td {
				border-top: solid 1px black;
				border-bottom: solid 2px black;
				padding-top: 10px;
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
		<table cellspacing="0">
			<%foreach (var account in Info.Accounts) {%>
			
			<tr>
				<th colspan="3" style="font-size: large; text-align: center; border-bottom: solid blue 1px;"><%=Server.HtmlEncode(account.AccountName) %></th>
			</tr>
			<tr>
				<td colspan="2">Balance due:</td>
				<td class="Amount" style="text-align: right; font-weight: bold;">
					<%=account.BalanceDue.ToString("c")%></td>
			</tr>
			<tr>
				<th colspan="3" style="padding-top: 25px; border-bottom: solid 2px black;">Pledges</th>
			</tr>
			<%if (account.OutstandingBalance > 0) { %>
			<tr class="OutstandingBalance">
				<td class="Description" colspan="2" style="padding-bottom: 7px;">Outstanding Balance:</td>
				<td class="Amount" style="text-align: right; padding-bottom: 7px;"><%=account.OutstandingBalance.ToString("c")%></td>
			</tr>
			<%} %>
			<%foreach (var pledge in account.Pledges) {%>
			<tr>
				<td class="Date" style="padding-right: 8px;">
					<%= pledge.Date.ToShortDateString() %></td>
				<td class="Description">
					<%= pledge.Type %><%if (!String.IsNullOrEmpty(pledge.Note)) {%><div class="Note"
						style="font-style: italic;">
						<%=pledge.Note %></div>
					<%} %>
				</td>
				<td class="Amount" style="text-align: right;">
					<%= pledge.Amount.ToString("c") %></td>
			</tr>
			<%} %>
			<tr class="Total">
				<td class="Description" colspan="2">Total: </td>
				<td class="Amount" style="text-align: right; font-weight: bold;">
					<%=account.Pledges.Sum(p => p.Amount).ToString("c")%></td>
			</tr>
			<%if (account.Payments.Count == 0) { %><tr>
				<td colspan="3">You have no payments on record after
					<%=Info.StartDate.ToLongDateString() %></td>
			</tr>
			<%} %>
			<tr>
				<th colspan="3" style="padding-top: 25px; border-bottom: solid 2px black;">Payments
				</th>
			</tr>
			<%foreach (var payment in account.Payments) {%>
			<tr>
				<td class="Date" style="padding-right: 8px;">
					<%=payment.Date.ToShortDateString() %></td>
				<td class="Description">
					<%=payment.Method.Replace("Unknown", "?")%>
					<%if (!payment.IsCheckNumberNull()) {%>#<%=payment.CheckNumber %><%} %></td>
				<td class="Amount" style="text-align: right;">
					<%=payment.Amount.ToString("c") %></td>
			</tr>
			<%} %>
			<tr class="Total">
				<td class="Description" colspan="2">Total: </td>
				<td class="Amount" style="text-align: right; font-weight: bold;">
					<%=account.Payments.Sum(p => p.Amount).ToString("c")%></td>
			</tr>
			<%} %>
		</table>
	</body>

</html>
