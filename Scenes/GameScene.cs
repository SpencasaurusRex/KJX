using KJX.Components;
using KJX.Components.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace KJX
{
    public class GameScene : Scene
    {
        Texture2D buttonTexture;
        Texture2D buttonPressedTexture;

        public GameScene()
        {
        }

        public override void initialize()
        {
            buttonTexture = content.Load<Texture2D>("Sprites/Button");
            buttonPressedTexture = content.Load<Texture2D>("Sprites/ButtonPressed");

            camera.setPosition(new Vector2(-Screen.width / 2, -Screen.height / 2));
            addRenderer(new DefaultRenderer(camera: camera));

            var globals = createEntity("globals");
			globals.addComponent(new GlobalInput());

            CreateButton(0, 0);

            addEntityProcessor(new ClickDetector(globals));
            addEntityProcessor(new SpriteButtonSystem());
        }

        public void CreateButton(float x, float y)
        {
            var e = createEntity("testButton");
            e.addComponent(new Clickable());
            e.addComponent(new SpriteButton(new Sprite(buttonTexture), new Sprite(buttonPressedTexture)));
        }

        public override void update()
        {
            base.update();
        }
    }
}