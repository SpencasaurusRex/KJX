namespace KJX.Components.Global
{
	public class MouseInput : Nez.Component
	{
		public bool LeftPressed;
		public bool RightPressed;

		public bool LeftClicked;
		public bool RightClicked;

		public bool LeftReleased;
		public bool RightReleased;

		public bool LeftPressedLastFrame;
		public bool RightPressedLastFrame;

		public float MouseX;
		public float MouseY;
	}
}