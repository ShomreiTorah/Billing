<%@ Page Language="C#" Inherits="ShomreiTorah.Billing.Export.EmailPage, ShomreiTorah.Billing" %>

<%@ Assembly Name="System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="ShomreiTorah.Billing.Export" %>

<script runat="server">
	public override string EmailSubject { get { return "Shomrei Torah Bill"; } }
	public override BillKind Kind { get { return BillKind.Bill; } }
	public override IEnumerable<string> ImageNames {
		get {
			yield return "Logo.gif";
		}
	}
</script>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>

	<head>
		<title>Shomrei Torah Bill</title>
		<style type="text/css">
			body {
				font-family: Verdana;
			}
			.Total td {
				border-top: solid 1px black;
				border-bottom: solid 2px black;
				padding-top: 10px;
			}
		</style>
	</head>

	<body>
		<div style="border-bottom: solid 2px navy">
			<table cellspacing="0" width="100%">
				<tr>
					<td style="width:210px">
						<img src="<%=ImagePrefix %>Logo.gif" alt="Shomrei Torah Logo" style="float: left;" />
					</td>
					<td>
						<h1 style="font-size: large; text-align: center; padding-top: 20px;">
							Congregation Shomrei Torah<br />
							Billing Statement</h1>
					</td>
					<td style="width: 250px">
						<p>
							Federal Tax ID: 47-0953005</p>
						Congregation Shomrei Torah<br />
						of Passaic Clifton<br />
						1360 Clifton Ave. #908<br />
						Clifton, NJ 07012 </td>
				</tr>
			</table>
		</div>
		<div style="padding-top: 1em; text-align: right; float: right;">
			<%=DateTime.Today.ToLongDateString() %></div>
		<p>
			<%=Server.HtmlEncode(Info.Person.MailingAddress).Replace(Environment.NewLine, "<br />")%></p>
		<p>
			Dear
			<%=Server.HtmlEncode(Info.Person.FullName)%>,</p>
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
		<p>
			Sincerely,</p>
		<p>
			Jason P. (Yaacov) Gitstein<br />
			Treasurer
		</p>
		<%
			const string StripeStyle = "background: #E8EBFF;";
			string curStyle = "";
		%>
		<table cellspacing="0" style="margin: 0 auto;">
			<%foreach (var account in Info.Accounts) {%>
			<tr>
				<th colspan="3" style="font-size: large; text-align: center; border-bottom: solid blue 1px;
					padding-top: 30px">
					<%=Server.HtmlEncode(account.AccountName) %></th>
			</tr>
			<tr>
				<td colspan="2">Balance due:</td>
				<td class="Amount" style="text-align: right; font-weight: bold;">
					<%=account.BalanceDue.ToString("c")%></td>
			</tr>
			<tr>
				<th colspan="3" style="padding-top: 25px; border-bottom: solid 2px black;">Pledges
				</th>
			</tr>
			<%if (account.OutstandingBalance > 0) { %>
			<tr class="OutstandingBalance">
				<td class="Description" colspan="2" style="padding-bottom: 7px;">Outstanding Balance:
				</td>
				<td class="Amount" style="text-align: right; padding-bottom: 7px;">
					<%=account.OutstandingBalance.ToString("c")%></td>
			</tr>
			<%} %>
			<%curStyle = ""; foreach (var pledge in account.Pledges) {
		 curStyle = curStyle == "" ? StripeStyle : "";%>
			<tr>
				<td class="Date" style="padding-right: 8px; <%=curStyle%>">
					<%= pledge.Date.ToShortDateString() %></td>
				<td class="Description" style="<%=curStyle%>">
					<%= pledge.Type %><%if (!String.IsNullOrEmpty(pledge.Note)) {%><div class="Note"
						style="font-style: italic;">
						<%=Server.HtmlEncode( pledge.Note )%></div>
					<%} %>
				</td>
				<td class="Amount" style="text-align: right; <%=curStyle%>">
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
			<%curStyle = ""; foreach (var payment in account.Payments) {
		 curStyle = curStyle == "" ? StripeStyle : "";%>
			<tr>
				<td class="Date" style="padding-right: 8px; <%=curStyle%>">
					<%=payment.Date.ToShortDateString() %></td>
				<td class="Description" style="<%=curStyle%>">
					<%=Server.HtmlEncode(payment.Method.Replace("Unknown", "?")) %>
					<%if (!payment.IsCheckNumberNull()) {%>#<%=payment.CheckNumber %><%} %></td>
				<td class="Amount" style="text-align: right; <%=curStyle%>">
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
