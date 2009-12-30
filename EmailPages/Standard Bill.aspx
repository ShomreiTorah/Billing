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
	</head>

	<body>
		<p>
			Dear
			<%=Person.FullName %>,</p>
		<p>
			On behalf of Rabbi Weinberger and the Shul, I would like to express our gratitude
			for your financial support and valued participation in our davening and learning.
			Through your generosity, support, and participation our Shul will continue to grow
			and thrive as a special place of Torah and Avodah.</p>
		<%foreach (var account in Person.OpenAccounts) {%>
		<h1>
			<%=Server.HtmlEncode(account) %></h1>
		<table>
			<%if (Person.GetBalance(StartDate, account) != 0) { %>
			<tr>
				<td></td>
				<td>Outstanding Balance:</td>
				<td>
					<%=Person.GetBalance(StartDate)%></td>
			</tr>
			<%} %>
			<%foreach (var pledge in Person.GetPledgesRows().Where(p => p.Date >= StartDate && p.Account == account)) {%>
			<tr>
				<td>
					<%=pledge.Date%></td>
				<td>
					<%=pledge.Type%></td>
				<td>
					<%=pledge.Amount.ToString("c")%></td>
			</tr>
			<%} %></table>
		<table>
			<%foreach (var payment in Person.GetPaymentsRows().Where(p => p.Date >= StartDate&& p.Account == account)) {%>
			<tr>
				<td>
					<%=payment.Date %></td>
				<td>
					<%=payment.Method %></td>
				<td>
					<%=payment.Amount.ToString("c") %></td>
			</tr>
			<%} %>
		</table>
		<%} %>
	</body>

</html>
