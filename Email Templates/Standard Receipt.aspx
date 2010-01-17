<%@ Page Language="C#" Inherits="ShomreiTorah.Billing.Export.EmailPage, ShomreiTorah.Billing"
	MasterPageFile="EmailPage.Master" Title="Shomrei Torah Receipt" %>

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

<asp:Content runat="server" ContentPlaceHolderID="Logo">
	<img src="<%=ImagePrefix %>Logo.gif" alt="Shomrei Torah Logo" style="float: left;" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Title">
	Congregation Shomrei Torah<br />
	<%=Info.StartDate.Year %>
	Contributions Summary</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Body">
	<table cellspacing="0" width="100%">
		<tr>
			<td style="padding-top: 15px;">
				<%=Server.HtmlEncode(Info.Person.MailingAddress).Replace(Environment.NewLine, "<br />")%>
			</td>
			<td style="padding-top: 15px; width: 250px; vertical-align: top;">
				<%=DateTime.Today.ToLongDateString() %></td>
		</tr>
	</table>
	<p>
		Dear
		<%=Server.HtmlEncode(Info.Person.FullName)%>,</p>
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
		<%=Server.HtmlEncode(Info.Deductibility)%></p>
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
			<td style="padding-right: 8px; <%=curStyle%>">
				<%=payment.Date.ToShortDateString()%></td>
			<td style="<%=curStyle%>">
				<%=Server.HtmlEncode(payment.Method.Replace("Unknown", "?")) %>
				<%if (!payment.IsCheckNumberNull()) {%>#<%=payment.CheckNumber%><%} %></td>
			<td style="text-align: right; <%=curStyle%>">
				<%=payment.Amount.ToString("c")%></td>
		</tr>
		<%} %>
		<tr>
			<td colspan="2" style="border-top: solid 1px black; border-bottom: solid 2px black;
				padding-top: 10px;">Total:</td>
			<td style="text-align: right; font-weight: bold; border-top: solid 1px black; border-bottom: solid 2px black;
				padding-top: 10px;">
				<%=account.TotalPaid.ToString("c")%></td>
		</tr>
		<%} %>
	</table>
</asp:Content>
