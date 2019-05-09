using KJX.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace KJX.Factories
{
    public class NodeFactory
    {
        public Texture2D DefaultSprite;
        public Texture2D ClickedSprite;

        public NodeFactory(Texture2D defaultSprite, Texture2D clickedSprite)
        {
            DefaultSprite = defaultSprite;
            ClickedSprite = clickedSprite;
        }

        public void Setup(Entity e, NodeLoad load)
        {
            e.addComponent(new Clickable());
            e.addComponent(new SpriteButton(DefaultSprite, ClickedSprite));
            e.addComponent(new NodeAmount(load.Amount));
            e.position = new Vector2(load.X, load.Y);
        }
    }
}
