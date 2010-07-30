using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;

namespace ShomreiTorah.Billing.Events.Seating {
	static class SeatingInfo {
		static RepositoryItemComboBox CreateSeatPledgeTypeEdit() {
			var edit = new RepositoryItemComboBox {
				HighlightedItemStyle = HighlightStyle.Skinned
			};
			edit.Items.AddRange(new[] { "ימים נוראים Seating", "Membership", "Associate Membership" });
			edit.DropDownRows = edit.Items.Count;

			return edit;
		}

		public static readonly RepositoryItemComboBox PledgeTypeEdit = CreateSeatPledgeTypeEdit();
	}
}
