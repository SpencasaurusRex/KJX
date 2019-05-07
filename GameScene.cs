using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace KJX
{
    public class GameScene : Scene
    {
        Texture2D buttonTexture;

        public GameScene()
        {
        }

        public override void initialize()
        {
            buttonTexture = content.Load<Texture2D>("Sprites/Button");

            camera.setPosition(new Vector2(-Screen.width / 2, -Screen.height / 2));
            addRenderer(new DefaultRenderer(camera: camera));

            CreateButton(0, 0);
        }

        public void CreateButton(float x, float y)
        {
            var e = createEntity("testButton");
            e.addComponent(new Sprite(buttonTexture));
        }
    }
}
