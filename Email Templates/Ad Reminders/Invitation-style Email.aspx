<%@ Page Language="C#" Inherits="ShomreiTorah.Billing.Events.MelaveMalka.AdReminderEmailPage, ShomreiTorah.Billing" %>

<%@ Assembly Name="ShomreiTorah.Common" %>
<%@ Assembly Name="System.Core" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="ShomreiTorah.Common" %>
<%@ Import Namespace="ShomreiTorah.Common.Calendar" %>
<%@ Import Namespace="ShomreiTorah.Data" %>

<script runat="server">
	public override string EmailSubject { get { return "Shomrei Torah Melave Malka"; } }
</script>

<%MelaveMalkaInfo mm = DataContext.Table<MelaveMalkaInfo>().Rows.Single(m => m.Year == Row.Year); %>
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
			Dear
			<%:Row.Person.HisName ?? Row.Person.HerName %>,
		</p>
		<p>
			We are pleased to invite you to the annual Melave Malka of Bais Medrash Shomrei Torah, to take place on מוצאי שבת פרשת
			<%:new HebrewDate(mm.MelaveMalkaDate).Parsha %>,
			<%=mm.MelaveMalkaDate.ToString("MMMM d") %>
			at 8:30 PM. Our guests of honor this year are
			<%:mm.Honoree.FullName %>.<br />
			We hope to see you there.
		</p>
		<p>
			<%List<Pledge> lastYear = Row.Person.Pledges.Where(p => p.ExternalSource == "Journal " + (mm.Year - 1)).ToList(); %>
			<% if (lastYear.Any()) { %>
			Last year, you gave
			<%if (lastYear.Count == 1) { %>
			a
			<%: lastYear[0].SubType.ToLower()%>
			<%} else if (lastYear.Select(p => p.SubType).Distinct().Count() == 1) {%>
			<%: lastYear.Count+" "+ lastYear[0].SubType.ToLower()+"s"%>
			<%} else if (lastYear.Count == 2) {%>
			<%:"a "+lastYear.Join(" and a ", p => p.SubType) %>
			<%} else { %>
			<%:("a "+lastYear.Take(lastYear.Count - 1).Join(", a ", p => p.SubType) + ", and a " + lastYear.Last().SubType).ToLower() %>
			<%} %>
			to the journal (for
			<%:lastYear.Sum(p => p.Amount).ToString("c")%>). We hope that you will be able give the same (or higher) this year.
			<%} else { %>
			We hope that you will be able to give an ad for the Melave Malka journal.
			<%} %>
		</p>
		<p>
			The deadline for ads is
			<%: mm.AdDeadline.ToLongDateString() %>. You can download an ad blank by clicking here (TBD).
			<br />
			Ads can also be given by sending email to <a href="mailto:Journal@ShomreiTorah.us">Journal@ShomreiTorah.us</a>. Please remember
			to include the following information:</p>
		<ol>
			<li>Your full name and address</li>
			<li>Type of ad</li>
			<li>Number of men & ladies Melave Malka reservations</li>
			<li>Text of your ad</li>
		</ol>
		<p>
			The Melave Malka is the perfect chance to meet everyone in the shul, and is great fun. So please be sure to come.
		</p>
		<p>
			Best wishes, Dovid Laks</p>
	</body>

</html>
