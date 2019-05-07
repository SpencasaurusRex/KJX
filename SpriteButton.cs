using Nez;
using Nez.Sprites;

namespace KJX
{
    public class SpriteButton : Component
    {
        public Sprite DefaultSprite;
        public Sprite ClickedSprite;

        public SpriteButton(Sprite defaultSprite, Sprite clickedSprite)
        {
            DefaultSprite = defaultSprite;
            ClickedSprite = clickedSprite;
        }
    }
}
