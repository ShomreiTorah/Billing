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
			a {
				color: Blue;
			}
		</style>
	</head>

	<body>
		<p>
			Dear
			<%:Row.Person.ActualSalutation %>,
		</p>
		<p>
			We are pleased to invite you to the annual Melave Malka of Bais Medrash Shomrei Torah, to take place on מוצאי שבת פרשת
			<%:new HebrewDate(mm.MelaveMalkaDate).Parsha %>,
			<%=mm.MelaveMalkaDate.ToString("MMMM d 'at' h:mm tt") %>. Our guests of honor this year are
			<%:mm.Honoree.FullName %>.<br />
			We hope to see you there.
		</p>
		<p>
			<%List<Pledge> lastYear = Row.Person.Pledges.Where(p => p.ExternalSource == "Journal " + (mm.Year - 1)).ToList();
			%>
			<% if (lastYear.Any()) {
		  var adTypes = lastYear.GroupBy(p => p.SubType, (subtype, set) => set.Has(2) ? (set.Count() + " " + subtype.ToLower() + "s") : "a " + subtype.ToLower()).ToList();
			%>
			Last year, you gave
			<%if (lastYear.Count <= 2) {%>
			<%:adTypes.Join(" and ")%>
			<%} else { %>
			<%:(adTypes.Take(adTypes.Count - 1).Join(", ") + ", and " + lastYear.Last()).ToLower()%>
			<%} %>
			to the journal (for
			<%:lastYear.Sum(p => p.Amount).ToString("c")%>). We hope that you will be able give the same (or higher) this year.
			<%} else { %>
			We hope that you will be able to give an ad for the Melave Malka journal.
			<%} %>
		</p>
		<p>
			The deadline for ads is
			<%: mm.AdDeadline.ToLongDateString() %>.<br />
			You can download an ad blank by clicking <a href="http://ShomreiTorah.us<%:mm.AdBlankPath %>">here</a>.
			<br />
			Ads can also be emailed to <a href="mailto:Journal@ShomreiTorah.us">Journal@ShomreiTorah.us</a>. Please remember to include
			the following information:</p>
		<ol>
			<li>Your full name and address</li>
			<li>Type of ad</li>
			<li>Number of men's & ladies' Melave Malka reservations</li>
			<li>Text of your ad</li>
		</ol>
		<%if (Row.Source == "Shul") { %>
		<p>
			The Melave Malka is the perfect chance to meet everyone in the shul, and is great fun. So please be sure to come.
		</p>
		<%} %>
		<p>
			Best wishes,<br />
			Dovid Laks</p>
	</body>

</html>
