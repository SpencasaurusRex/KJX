using Nez;
using Microsoft.Xna.Framework.Input;
using KJX.Components.Global;

namespace KJX.Systems
{
	public class InputSystem : EntityProcessingSystem
	{
		public InputSystem(Entity globalEntity) : base(new Matcher().all(typeof(MouseInput)))
		{
		}

		public override void process(Entity entity)
		{
			var input = entity.getComponent<MouseInput>();

			input.LeftPressedLastFrame = input.LeftPressed;
			input.RightPressedLastFrame = input.RightPressed;

			input.LeftPressed = Input.currentMouseState.LeftButton == ButtonState.Pressed;
			input.RightPressed = Input.currentMouseState.RightButton == ButtonState.Pressed;

			input.LeftClicked = input.LeftPressed && !input.LeftPressedLastFrame;
			input.RightClicked = input.RightPressed && !input.RightPressedLastFrame;

			input.LeftReleased = !input.LeftPressed && input.LeftPressedLastFrame;
			input.RightReleased = !input.RightPressed && input.RightPressedLastFrame;

			input.MouseX = Input.currentMouseState.X;
			input.MouseY = Input.currentMouseState.Y;
		}
	}
}