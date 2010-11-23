<%@ Page Language="C#" Inherits="ShomreiTorah.Billing.Events.MelaveMalka.CallerEmailPage, ShomreiTorah.Billing" %>

<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Linq" %>

<script runat="server">
	public override string EmailSubject { get { return "Shomrei Torah Melave Malka Phone Calls"; } }
</script>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>

	<head>
		<title></title>
	</head>

	<body>
		<p>
			Hi <%:Row.Person.HisName %>,</p>
		<p>
			Attached are the people you ought to call.</p>
		<p>
			Hopefully, we'll eventually get a longer text to put here.</p>
		<p>
			תזכו למצוות!</p>
		<p>
			Thank you very much,<br />
			David Laks</p>
		<%if (Row.Person.Field<decimal>("BalanceDue") > 0) { %><p>
			By the way, you owe
			<%:Row.Person.Field<decimal>("BalanceDue").ToString("c") %>.
		</p>
		<%} %>
	</body>

</html>
