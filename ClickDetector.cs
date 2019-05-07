using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;

namespace KJX
{
    public class ClickDetector : EntityProcessingSystem
    {
        public ClickDetector() : base(new Matcher().all(typeof(Clickable), typeof(Sprite)))
        {

        }

        public override void process(Entity entity)
        {
            var sprite = entity.getComponent<Sprite>();
            var clickable = entity.getComponent<Clickable>();
            bool leftClick = clickable.Left && Input.currentMouseState.LeftButton == ButtonState.Pressed;
            bool rightClick = clickable.Right && Input.currentMouseState.RightButton == ButtonState.Pressed;

            if (!leftClick) clickable.LeftClicked = false;
            if (!rightClick) clickable.RightClicked = false;

            if (leftClick || rightClick)
            {
                float mouseX = Input.currentMouseState.Position.X - Screen.width / 2;
                float mouseY = Input.currentMouseState.Position.Y - Screen.height / 2;
                var spriteRect = RectangleExt.fromFloats(entity.position.X, entity.position.Y, sprite.width, sprite.height);
                if (spriteRect.Contains(mouseX, mouseY))
                {
                    clickable.LeftClicked = leftClick;
                    clickable.RightClicked = rightClick;
                }
                else
                {
                    clickable.LeftClicked = false;
                    clickable.RightClicked = false;
                }
            }
        }
    }
}