using Microsoft.Xna.Framework.Graphics;

namespace KJX.Components
{
    public class SpriteButton : Nez.Component
    {
        public Texture2D DefaultTexture;
        public Texture2D ClickedTexture;

        public SpriteButton(Texture2D defaultTexture, Texture2D clickedTexture)
        {
            DefaultTexture = defaultTexture;
            ClickedTexture = clickedTexture;
        }
    }
}
