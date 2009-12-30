<%@ Page Language="C#" Inherits="ShomreiTorah.Billing.Export.EmailPage, ShomreiTorah.Billing" %>

<%@ Assembly Name="System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089" %>
<%@ Import Namespace="System.Linq" %>

<script runat="server">
	public override string EmailSubject { get { return "Shomrei Torah Bill"; } }
</script>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>

	<head>
		<title>Shomrei Torah Bill</title>
		<style type="text/css">
			body {
				font-family: Verdana;
			}
			h1 {
				font-size: large;
				text-align: center;
				border-bottom: solid blue 1px;
			}
			h3 .Amount {
				padding-left: 15px;
			}
			td {
				border-bottom: solid 1px navy;
			}
			thead th {
				border-bottom: solid 2px black;
			}
			.OutstandingBalance td {
				padding-bottom: 5px;
			}
			td.Date {
				padding-right: 8px;
			}
			td.Amount {
				text-align: right;
			}
			.Pledges .Description .Note {
				font-style: italic;
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
			<%=Person.FullName %>,</p>
		<p>
			On behalf of Rabbi Weinberger and Congregation Shomrei Torah, we would like to express
			our gratitude for your financial support and valued participation in our davening
			and learning. Through your generosity, support, and participation our Shul will
			continue to grow and thrive as a special place of Torah and Avodah.</p>
		<p>
			Please review the summary below. If you have any questions regarding any of the
			pledges or payments contained herein, please contact Yaacov Gitstein at 732-516-5583.
			Thank you.
		</p>
		<p>
			תזכו למצות</p>
		<%foreach (var account in Person.OpenAccounts) {%>
		<h1>
			<%=Server.HtmlEncode(account) %></h1>
		<h3>
			Balance due: <span class="Amount">
				<%=Math.Max(0, Person.GetBalance(account)).ToString("c")%></span>
		</h3>
		<%var pledges = Person.GetPledgesRows().Where(p => p.Date >= StartDate && p.Account == account).OrderBy(p => p.Date).ToArray();%>
		<table cellspacing="0" class="Pledges">
			<thead>
				<tr>
					<th colspan="3">Pledges</th>
				</tr>
			</thead>
			<%if (Person.GetBalance(StartDate, account) != 0) { %>
			<tr class="OutstandingBalance">
				<td class="Description" colspan="2">Outstanding Balance:</td>
				<td class="Amount">
					<%=Person.GetBalance(StartDate, account).ToString("c")%></td>
			</tr>
			<%} %>
			<%foreach (var pledge in pledges) {%>
			<tr>
				<td class="Date">
					<%= pledge.Date.ToShortDateString() %></td>
				<td class="Description">
					<%= pledge.Type %><%if (!String.IsNullOrEmpty(pledge.Note)) {%><div class="Note">
						<%=pledge.Note %></div>
					<%} %>
				</td>
				<td class="Amount">
					<%= pledge.Amount.ToString("c") %></td>
			</tr>
			<%} %>
			<tr class="Total">
				<td class="Description" colspan="2">Total:</td>
				<td class="Amount">
					<%=pledges.Sum(p=>p.Amount).ToString("c") %></td>
			</tr>
		</table>
		<%var payments = Person.GetPaymentsRows().Where(p => p.Date >= StartDate && p.Account == account).OrderBy(p => p.Date).ToArray(); %>
		<%if (payments.Length == 0) { %><div class="NoPayments">You have no payments on record
			after
			<%=StartDate.ToLongDateString() %></div>
		<%} %>
		<table cellspacing="0" class="Payments">
			<thead>
				<tr>
					<th colspan="3">Payments</th>
				</tr>
			</thead>
			<%foreach (var payment in payments) {%>
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
					<%=payments.Sum(p => p.Amount).ToString("c")%></td>
			</tr>
		</table>
		<%} %>
	</body>

</html>
