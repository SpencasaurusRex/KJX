using Microsoft.Xna.Framework.Graphics;
using Nez;

namespace KJX.Components
{
    public class SpriteButton : Component
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
