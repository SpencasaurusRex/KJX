using KJX.Components;
using KJX.Components.Global;
using Nez;
using Nez.Sprites;

namespace KJX
{
    public class ClickDetector : EntityProcessingSystem
    {
		readonly Entity globalEntity;

        public ClickDetector(Entity globalEntity) : base(new Matcher().all(typeof(Clickable), typeof(Sprite)))
        {
			this.globalEntity = globalEntity;
        }

        public override void process(Entity entity)
        {
			var globalInput = globalEntity.getComponent<MouseInput>();

            var sprite = entity.getComponent<Sprite>();
            var clickable = entity.getComponent<Clickable>();
            
			// Correct mouse position for off-center camera
			float mouseX = globalInput.MouseX - Screen.width / 2;
			float mouseY = globalInput.MouseY - Screen.height / 2;
            var spriteRect = sprite.bounds;
			if (spriteRect.contains(mouseX, mouseY))
			{
				clickable.LeftPressed = globalInput.LeftPressed;
				clickable.RightPressed = globalInput.RightPressed;

				clickable.LeftClicked = globalInput.LeftClicked;
				clickable.RightClicked = globalInput.RightClicked;

				clickable.LeftReleased = globalInput.LeftReleased;
				clickable.RightReleased = globalInput.RightReleased;
			}
			else
			{
				clickable.LeftClicked = false;
				clickable.RightClicked = false;
				clickable.LeftPressed = false;
				clickable.RightPressed = false;
			}
		}
    }
}