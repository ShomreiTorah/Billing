<%@ Page Language="C#" Inherits="ShomreiTorah.Billing.Events.MelaveMalka.EmailPage<ShomreiTorah.Data.Caller>, ShomreiTorah.Billing" %>

<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Linq" %>

<script runat="server">
</script>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>

	<head>
		<title></title>
	</head>

	<body>
		<p>
			Hi <%=Row.Person.HisName %>,</p>
		<p>
			Attached are the people you ought to call.</p>
	</body>

</html>
