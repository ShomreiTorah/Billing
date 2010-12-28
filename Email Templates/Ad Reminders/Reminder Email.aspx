<%@ Page Language="C#" Inherits="ShomreiTorah.Billing.Events.MelaveMalka.AdReminderEmailPage, ShomreiTorah.Billing" %>

<%@ Assembly Name="ShomreiTorah.Common" %>
<%@ Assembly Name="System.Core" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="ShomreiTorah.Common" %>
<%@ Import Namespace="ShomreiTorah.Common.Calendar" %>
<%@ Import Namespace="ShomreiTorah.Data" %>

<script runat="server">
	public override string EmailSubject { get { return "Shomrei Torah Melave Malka - Please give your ads!"; } }
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
			The deadline for Shomrei Torah's Melave Malka journal is
			<%:mm.AdDeadline.ToString("dddd, MMMM d") %>, just
			<%=(mm.AdDeadline-DateTime.Today).Days %>
			days away!</p>
		<p>
			The Melave Malka will take place on מוצאי שבת פרשת
			<%:new HebrewDate(mm.MelaveMalkaDate).Parsha %>,
			<%=mm.MelaveMalkaDate.ToString("MMMM d 'at' h:mm tt") %>. This year, we are honoring
			<%:mm.Honoree.FullName %>.<br />
		</p>
		<p>
			<%List<Pledge> lastYear = Row.Person.Pledges.Where(p => p.ExternalSource == "Journal " + (mm.Year - 1)).ToList();
			%>
			<% if (lastYear.Any()) {%>
			Last year, you were kind enough to give
			<%var adTypes = lastYear.GroupBy(p => p.SubType, (subtype, set) => set.Has(2) ? (set.Count() + " " + subtype.ToLower() + "s") : "a " + subtype.ToLower()).ToList();%>
			<%if (lastYear.Count <= 2) {%>
			<%:adTypes.Join(" and ")%>
			<%} else { %>
			<%:(adTypes.Take(adTypes.Count - 1).Join(", ") + ", and " + lastYear.Last()).ToLower()%>
			<%} %>
			to the journal for
			<%:lastYear.Has(2)?" a total of ":"" %>
			<%:lastYear.Sum(p => p.Amount).ToString("c")%>. We hope that you will come to the Melave Malka and give the same (or higher)
			this year.
			<%} else { %>
			We hope that you will come to the Melave Malka and give an ad for the journal.
			<%} %>
		</p>
		<p>
			You can download an ad blank by clicking <a href="http://ShomreiTorah.us<%:mm.AdBlankPath %>">here</a>.
			<br />
			Ads can also be emailed to <a href="mailto:Journal@ShomreiTorah.us">Journal@ShomreiTorah.us</a>. Please remember to include
			the following information:</p>
		<p style="margin-left: 36px">
			<!-- Numbered lists have margin issues -->
			1. &nbsp; Your full name and address<br />
			2. &nbsp; Type of ad<br />
			3. &nbsp; Number of men's & ladies' Melave Malka reservations<br />
			4. &nbsp; Text of your ad<br />
		</p>
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
