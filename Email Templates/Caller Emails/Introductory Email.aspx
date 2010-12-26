<%@ Page Language="C#" Inherits="ShomreiTorah.Billing.Events.MelaveMalka.CallerEmailPage, ShomreiTorah.Billing" %>

<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="ShomreiTorah.Data" %>

<script runat="server">
	public override string EmailSubject { get { return "Shomrei Torah Melave Malka Phone Calls"; } }
</script>
<%var mm = DataContext.Table<MelaveMalkaInfo>().Rows.Single(m => m.Year == Row.Year); %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>

	<head>
		<title></title>
	</head>

	<body>
		<p>
			Hi
			<%:Row.Person.HisName %>,</p>
		Attached is an updated <span class="il">call</span> list for the Melave Malka.&nbsp; Yasher Koach for volunteering.&nbsp;
		A few pointers about the phone calls:<br />
		<ul>
			<li>Be prepared to take ads over the phone.&nbsp; If people want to, they (and you) can compose ads for them (just let us know
				whom they want to honor).&nbsp; If you want to, you can print  <a href="http://ShomreiTorah.us<%:mm.AdBlankPath %>">single page ad blanks</a> to make it easier.<br />
			</li>
			<li>While this is an important fund-raiser for the shul, it is more important as a social event--a chance for everyone in the
				shul to get together, and draw closer.&nbsp; If anyone can&#39;t afford to give an ad, that&#39;s fine; times are tough
				and a lot of people are struggling.&nbsp; Ask them to come anyway, and give what they feel comfortable with.&nbsp; The shul
				is self-catering the Melave Malka, which holds down the cost of the food, so people shouldn&#39;t feel bad about coming
				no matter what.</li>
			<li>You can easily filter the attached spreadsheet to show only the people that you are assigned to <span class="il">call</span>
				by clicking on the caller column &amp; choosing your name.</li>
			<li>The spreadsheet includes information on what type of ad (if any) each person gave last year.</li>
			<li>If people do give an ad over the phone, please remember to get all of the relevant details:
				<br />
				<ul>
					<li>Name</li>
					<li>Ad text</li>
					<li>Type of ad</li>
					<li>Number of Melave Malka reservations</li>
				</ul>
			</li>
			<li>If you finish your list, and would like more names, please let me know.</li>
		</ul>
		<p>
			&nbsp;</p>
		<p>
			תזכו למצוות!</p>
		<p>
			Thank you very much,<br />
			David Laks</p>
	</body>

</html>
