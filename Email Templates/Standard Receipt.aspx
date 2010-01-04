<%@ Page Language="C#" Inherits="ShomreiTorah.Billing.Export.EmailPage, ShomreiTorah.Billing" %>

<%@ Assembly Name="System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="ShomreiTorah.Billing.Export" %>

<script runat="server">
	public override string EmailSubject { get { return "Shomrei Torah Receipt"; } }
	public override BillKind Kind { get { return BillKind.Receipt; } }

	public override IEnumerable<string> ImageNames {
		get {
			yield return "Logo.gif";
		}
	}
</script>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>

	<head>
		<title>Shomrei Torah Receipt</title>
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
		<div style="border-bottom: solid 2px navy; clear: both">
			<img src="<%=ImagePrefix %>Logo.gif" alt="Shomrei Torah Logo" style="float: left;" />
			<div style="float: right;">
				<p>
					Federal Tax ID: 47-0953005</p>
				Congregation Shomrei Torah<br />
				of Passaic Clifton<br />
				1360 Clifton Ave. #908<br />
				Clifton, NJ 07012 </div>
			<h1 style="font-size: large; text-align: center; padding-top: 20px;">
				Congregation Shomrei Torah<br />
				<%=Info.StartDate.Year %>
				Contributions Summary</h1>
			<div style="clear: both; font-size: 1px">&nbsp;</div>
		</div>
		<div style="float: right; padding-top: 1em;">
			<%=DateTime.Today.ToLongDateString() %></div>
		<p>
			<%=Server.HtmlEncode(Info.Person.MailingAddress).Replace(Environment.NewLine, "<br />")%></p>
		<p>
			Dear
			<%=Server.HtmlEncode( Info.Person.FullName )%>,</p>
		<p>
			On behalf of Rabbi Weinberger and Congregation Shomrei Torah of Passaic Clifton,
			I would like to express my sincere gratitude and appreciation for your generous
			<%= Info.Accounts.Sum(a => a.Payments.Count) == 1 ? "contribution" : "contributions" %>
			to our shul. Below please review your
			<%=Info.StartDate.Year %>
			annual contributions summary. If you have any questions, please reply to this email
			or call me at (732) 516 - 5583.</p>
		<p>
			May your support of our Shul bring you ברכה and הצלחה in all of your endeavors.
		</p>
		<p>
			No goods or services have been provided.</p>
		<p>
			Sincerely,</p>
		<p>
			Jason P. (Yaacov) Gitstein<br />
			Treasurer
		</p>
		<table cellspacing="0" style="margin: 0 auto;">
			<%foreach (var account in Info.Accounts) {%>
			<thead>
				<tr>
					<th colspan="3" style="font-size: large; text-align: center; padding: 25px 0 7px 0;
						border-bottom: solid 2px black;">
						<%=Server.HtmlEncode(account.AccountName) %></th>
				</tr>
			</thead>
			<%
				const string StripeStyle = "background: #E8EBFF;";
				string curStyle = "";
				foreach (var payment in account.Payments) {
					curStyle = curStyle == "" ? StripeStyle : "";%>
			<tr>
				<td class="Date" style="padding-right: 8px; <%=curStyle%>">
					<%=payment.Date.ToShortDateString()%></td>
				<td class="Description" style="<%=curStyle%>">
					<%=Server.HtmlEncode(payment.Method.Replace("Unknown", "?")) %>
					<%if (!payment.IsCheckNumberNull()) {%>#<%=payment.CheckNumber%><%} %></td>
				<td class="Amount" style="text-align: right; <%=curStyle%>">
					<%=payment.Amount.ToString("c")%></td>
			</tr>
			<%} %>
			<tr class="Total">
				<td class="Description" colspan="2">Total:</td>
				<td class="Amount" style="text-align: right; font-weight: bold;">
					<%=account.Payments.Sum(p => p.Amount).ToString("c")%></td>
			</tr>
			<%} %>
		</table>
	</body>

</html>
