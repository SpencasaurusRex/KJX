using System;
using KJX.Components;
using KJX.Components.Global;
using KJX.Factories;
using KJX.Systems;
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
			globals.addComponent(new MouseInput());
            globals.addComponent(new EntityMap());

            NodeFactory nodeFactory = new NodeFactory(buttonTexture, buttonPressedTexture);

            addEntityProcessor(new InputSystem(globals));
            addEntityProcessor(new ClickDetector(globals));
            addEntityProcessor(new SpriteButtonSystem());
            addEntityProcessor(new MapLoader(globals, nodeFactory));

            NodeLoad[] nodeLoads = new NodeLoad[2];
            nodeLoads[0] = new NodeLoad(-100, 0, 2);
            nodeLoads[1] = new NodeLoad(100, 0, 0);

            Tuple<int, int>[] connections = new Tuple<int, int>[2];
            connections[0] = new Tuple<int, int>(0, 1);
            connections[1] = new Tuple<int, int>(1, 0);

            globals.addComponent(new MapLoad(nodeLoads, connections));
        }

        public override void update()
        {
            base.update();
        }
    }
}