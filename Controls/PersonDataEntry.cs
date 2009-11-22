using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ShomreiTorah.Billing.Controls {
	partial class PersonDataEntry : XtraUserControl {
		public PersonDataEntry() {
			InitializeComponent();
		}

		#region GUI
		private void FirstName_EditValueChanged(object sender, EventArgs e) { UpdateFirstNameEcho(); }

		private void lastName_EditValueChanged(object sender, EventArgs e) { lastNameEcho.Text = lastName.Text; OnPersonChanged(EventArgs.Empty); }
		void UpdateFirstNameEcho() {
			if (hisName.Text.Length == 0)
				firstNameEcho.Text = herName.Text;
			else
				firstNameEcho.Text = hisName.Text;
			OnPersonChanged(EventArgs.Empty);
		}
		#endregion
		#region Interface
		///<summary>Gets or sets the data being edited.</summary>
		[Description("Gets or sets the data being edited.")]
		[Category("Data")]
		public PersonData Data {
			get {
				return new PersonData {
					HisName = hisName.Text,
					HerName = herName.Text,
					LastName = lastName.Text,

					FullName = GeneratedFullName,
					Address = address.Text,
					City = city.Text,
					State = state.Text,
					Zip = zip.Text,

					Phone = phone.Text,
				};
			}
			//set {
			//    hisName.Text = value.HisName;
			//    herName.Text = value.HerName;
			//    lastName.Text = value.LastName;

			//    address.Text = value.Address;
			//    city.Text = value.City;
			//    state.Text = value.State;
			//    zip.Text = value.Zip;

			//    phone.Text = value.Phone;


			//    if (string.IsNullOrEmpty(value.FullName))
			//        titles.Text = String.Empty;
			//    else {
			//        var echoIndex = value.FullName.IndexOf(firstNameEcho.Text, StringComparison.OrdinalIgnoreCase);
			//        if (echoIndex != -1)
			//            titles.Text = value.FullName.Substring(0, echoIndex);
			//        else
			//            titles.Text = value.FullName;
			//    }
			//}
		}
		string GeneratedFullName {
			get {
				if (String.IsNullOrEmpty(hisName.Text) && String.IsNullOrEmpty(herName.Text))
					return String.Empty;
				return String.Join(" ", Array.FindAll(new[] { titles.Text, firstNameEcho.Text, lastNameEcho.Text }, str => !String.IsNullOrEmpty(str)));
			}
		}
		#endregion

		private void TextBox_Changed(object sender, EventArgs e) { OnPersonChanged(EventArgs.Empty); }

		///<summary>Occurs when any textbox is changed.</summary>
		public event EventHandler PersonChanged;
		///<summary>Raises the PersonChanged event.</summary>
		///<param name="e">An EventArgs object that provides the event data.</param>
		internal protected virtual void OnPersonChanged(EventArgs e) {
			if (PersonChanged != null)
				PersonChanged(this, e);
		}

	}
}
