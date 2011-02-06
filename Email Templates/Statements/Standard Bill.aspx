<%@ Page Language="C#" Inherits="ShomreiTorah.Billing.Statements.Email.EmailPage, ShomreiTorah.Billing" MasterPageFile="EmailPage.master" %>

<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="ShomreiTorah.Billing.Statements" %>

<script runat="server">
	public override string EmailSubject { get { return "Shomrei Torah Bill"; } }
	public override StatementKind Kind { get { return StatementKind.Bill; } }
	public override IEnumerable<string> ImageNames {
		get {
            yield return "LeviKrinsky.png";
            yield return "Logo.gif";
		}
	}
</script>

<asp:Content runat="server" ContentPlaceHolderID="Logo">
	<img src="<%=ImagePrefix %>Logo.gif" alt="Shomrei Torah Logo" style="float: left;" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Title">
	Congregation Shomrei Torah<br />
	Billing Statement
</asp:Content>
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
		On behalf of Rabbi Weinberger and Congregation Shomrei Torah, I would like to express my sincere gratitude and appreciation
		for your financial support and valued participation in our davening and learning. Through your generosity, support, and
		participation our Shul will continue to grow and thrive as a special place of Torah and Avodah.</p>
	<p>
		Your total balance due is <b>
			<%=Info.TotalBalance.ToString("c") %></b>. Please review the summary below. If you have any questions regarding the
		pledges or payments contained herein, please reply to this email or contact Yaacov Gitstein at (732) 516 - 5583.
	</p>
	<p>
		Thank you.</p>
	<%
		const string StripeStyle = "background: #E8EBFF;";
		string curStyle = "";
	%>
	<table cellspacing="0" style="margin: 0 auto;">
		<%foreach (var account in Info.Accounts) {%>
		<tr>
			<th colspan="3" style="padding-top: 25px; border-bottom: solid 2px black;">
				<%=Server.HtmlEncode(account.AccountName) %>
				Pledges</th>
		</tr>
		<tr>
			<td colspan="2" style="padding-bottom: 7px;">Starting Balance (as of
				<%=Info.StartDate.ToShortDateString() %>): </td>
			<td style="text-align: right; padding-bottom: 7px;">
				<%=account.OutstandingBalance.ToString("c")%></td>
		</tr>
		<%curStyle = ""; foreach (var pledge in account.Pledges) {
		curStyle = curStyle == "" ? StripeStyle : "";%>
		<tr>
			<td style="padding-right: 8px; <%=curStyle%>">
				<%= pledge.Date.ToShortDateString() %></td>
			<td style="<%=curStyle%>">
				<%= pledge.Type+(String.IsNullOrEmpty(pledge.SubType)?"":", "+pledge.SubType) %>
				<%if (!String.IsNullOrEmpty(pledge.Note)) {%><div style="font-style: italic;">
					<%=Server.HtmlEncode( pledge.Note )%></div>
				<%} %>
			</td>
			<td style="text-align: right; <%=curStyle%>">
				<%= pledge.Amount.ToString("c") %></td>
		</tr>
		<%} %>
		<tr>
			<td colspan="2" style="border-top: solid 1px black; border-bottom: solid 2px black; padding-top: 10px;">Total: </td>
			<td style="text-align: right; font-weight: bold; border-top: solid 1px black; border-bottom: solid 2px black; padding-top: 10px;">
				<%=account.TotalPledged.ToString("c")%>
			</td>
		</tr>
		<tr>
			<th colspan="3" style="padding-top: 25px; border-bottom: solid 2px black;">
				<%=Server.HtmlEncode(account.AccountName) %>
				Payments </th>
			As of
			<%=Info.LastEnteredPayment.ToLongDateString() %>
		</tr>
		<%curStyle = ""; foreach (var payment in account.Payments) {
		curStyle = curStyle == "" ? StripeStyle : "";%>
		<tr>
			<td style="padding-right: 8px; <%=curStyle%>">
				<%=payment.Date.ToShortDateString() %></td>
			<td style="<%=curStyle%>">
				<%=Server.HtmlEncode(payment.Method.Replace("Unknown", "?")) %>
				<%if (!String.IsNullOrEmpty(payment.CheckNumber)) {%>#<%=Server.HtmlEncode(payment.CheckNumber) %><%} %></td>
			<td style="text-align: right; <%=curStyle%>">
				<%=payment.Amount.ToString("c") %></td>
		</tr>
		<%} %>
		<%if (account.Payments.Count == 0) { %><tr>
			<td colspan="3">You have no
				<%=account.AccountName.ToLower() %>
				payments on record after
				<%=Info.StartDate.ToLongDateString() %></td>
		</tr>
		<%} else { %>
		<tr>
			<td colspan="2" style="border-top: solid 1px black; border-bottom: solid 2px black; padding-top: 10px;">Total: </td>
			<td style="text-align: right; font-weight: bold; border-top: solid 1px black; border-bottom: solid 2px black; padding-top: 10px;">
				<%=account.TotalPaid.ToString("c")%></td>
		</tr>
		<%}
	}%>
		<tr>
			<td colspan="2" style="padding-top: 15px">Total Pledged:</td>
			<td style="padding-top: 15px; text-align: right;">
				<%=Info.TotalPledged.ToString("c") %></td>
		</tr>
		<tr>
			<td colspan="2">Total Paid:</td>
			<td style="text-align: right;">-<%=Info.TotalPaid.ToString("c") %></td>
		</tr>
		<tr>
			<td colspan="2" style="padding-top: 5px; border-top: solid 1px black; border-bottom: solid 2px black;">Balance due: </td>
			<td style="padding-top: 5px; text-align: right; border-top: solid 1px black; border-bottom: solid 2px black;"><b>
				<%=Info.TotalBalance.ToString("c") %></b></td>
		</tr>
	</table>
	<%if (Info.TotalBalance > 0) { %><p>
		Please make your checks payable to <b>Congregation Shomrei Torah of Passaic-Clifton</b>, and mail your remittance to:</p>
	<blockquote>
		<p>
			Congregation Shomrei Torah of Passaic-Clifton<br />
			1360 Clifton Ave. # 908<br />
			Clifton, NJ 07012</p>
		<%} %>
	</blockquote>
	<p>
		Sincerely,</p>
	<p>
        Levi Krinsky<br />
        <img src="<%=ImagePrefix %>LeviKrinsky.png" alt="Signature" /> <br />
        Treasurer
	</p>
</asp:Content>
