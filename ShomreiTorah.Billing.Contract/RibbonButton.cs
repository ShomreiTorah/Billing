using DevExpress.XtraBars;

namespace ShomreiTorah.Billing {
	///<summary>A permanent button in the main form's ribbon, supplied by a plugin.</summary>
	public abstract class RibbonButton {
		///<summary>Creates the item to display (including icon, caption, and event handler).</summary>
		public abstract BarItem CreateItem();

		///<summary>Gets the caption of the page that should contain the item.</summary>
		public abstract string Page { get; }
		///<summary>Gets the caption of the group that should contain the item.</summary>
		public abstract string Group { get; }
		///<summary>Indicates that the item should follow a separator.</summary>
		public abstract bool BeginGroup { get; }
	}
}
