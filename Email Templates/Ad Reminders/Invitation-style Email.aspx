<%@ Page Language="C#" Inherits="ShomreiTorah.Billing.Events.MelaveMalka.AdReminderEmailPage, ShomreiTorah.Billing" %>

<%@ Assembly Name="ShomreiTorah.Common" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="ShomreiTorah.Common" %>
<%@ Import Namespace="ShomreiTorah.Data" %>

<script runat="server">
	public override string EmailSubject { get { return "Shomrei Torah Melave Malka"; } }
</script>

<%var mm = DataContext.Table<MelaveMalkaInfo>().Rows.Single(m => m.Year == Row.Year); %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>

	<head>
		<title></title>
		<%-- XtraRichEdit has incorrect default margins for <p> tags--%>
		<style type="text/css">
			p {
				margin: 0 0 1em 0;
			}
		</style>
	</head>

	<body>
		<p>
			Hi
			<%:Row.Person.FullName %>,</p>
		<p>
			You are invited to our annual Melave Malka on
			<%: mm.MelaveMalkaDate.ToString("MMMM d, yyyy")%>
			at 8:30.
		</p>
		<p>
			We are honoring
			<%:mm.Honoree.FullName %></p>
		<p>
			Would you like to give an ad?</p>
		<%if (Row.Person.Field<decimal>("BalanceDue") > 0) { %><p>
			By the way, you owe
			<%:Row.Person.Field<decimal>("BalanceDue").ToString("c") %>.
		</p>
		<%} %>
	</body>

</html>
