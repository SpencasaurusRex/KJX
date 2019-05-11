using KJX.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.DeferredLighting;

namespace KJX.Factories
{
    public class NodeFactory
    {
        public Texture2D DefaultSprite;
        public Texture2D ClickedSprite;
        public Texture2D Numbers;

        public NodeFactory(Texture2D defaultSprite, Texture2D clickedSprite, Texture2D numbers)
        {
            DefaultSprite = defaultSprite;
            ClickedSprite = clickedSprite;
            Numbers = numbers;
        }

        public void Setup(Entity e, NodeLoad load)
        {
            var uvMesh = new UvMesh();
            float scale = Numbers.Width;
            uvMesh.SetVertices(new VertexPositionColorTexture[4]
            {
                new VertexPositionColorTexture(new Vector3(0, 0, 0), Color.White, new Vector2(0, 0)),
                new VertexPositionColorTexture(new Vector3(0, scale, 0), Color.White, new Vector2(0, .1f)),
                new VertexPositionColorTexture(new Vector3(scale, 0, 0), Color.White, new Vector2(1, 0)),
                new VertexPositionColorTexture(new Vector3(scale, scale, 0), Color.White, new Vector2(1, .1f)),
            });
            uvMesh.SetIndices(new short[6]
            {
                0, 2, 1,
                1, 2, 3
            });
            uvMesh.RecalculateBounds();
            uvMesh.SetTexture(Numbers);
            uvMesh.Offset= new Vector2(-DefaultSprite.Width / 2, DefaultSprite.Height-25);

            var slidingNumber = new SlidingNumber();
            slidingNumber.Instant = true;

            e.addComponent(new Clickable());
            e.addComponent(new SpriteButton(DefaultSprite, ClickedSprite));
            e.addComponent(slidingNumber);
            e.addComponent(new NodeAmount(load.Amount));
            e.addComponent(uvMesh);
            e.position = new Vector2(load.X, load.Y);
        }
    }
}
