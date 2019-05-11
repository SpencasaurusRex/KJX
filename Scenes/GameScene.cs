using System;
using KJX.Components;
using KJX.Components.Global;
using KJX.Factories;
using KJX.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;

namespace KJX
{
    public class GameScene : Scene
    {
        Texture2D buttonTexture;
        Texture2D buttonPressedTexture;
        Texture2D lineTexture;
        Texture2D numberTexture;

        public GameScene()
        {
        }

        public override void initialize()
        {
            buttonTexture = content.Load<Texture2D>("Sprites/Button");
            buttonPressedTexture = content.Load<Texture2D>("Sprites/ButtonPressed");
            lineTexture = content.Load<Texture2D>("Sprites/DashedLine");
            numberTexture = content.Load<Texture2D>("Sprites/Numbers");

            camera.setPosition(new Vector2(-Screen.width / 2, -Screen.height / 2));
            addRenderer(new DefaultRenderer(camera: camera));

            var globals = createEntity("globals");
			globals.addComponent(new MouseInput());
            globals.addComponent(new EntityMap());

            NodeFactory nodeFactory = new NodeFactory(buttonTexture, buttonPressedTexture, numberTexture);

            addEntityProcessor(new InputSystem(globals));
            addEntityProcessor(new ClickDetector(globals));
            addEntityProcessor(new SpriteButtonSystem());
            addEntityProcessor(new MapLoader(globals, nodeFactory));
            addEntityProcessor(new ConnectionLoader(lineTexture));
            addEntityProcessor(new SlidingNumberMover());
            addEntityProcessor(new SlidingUVWriter());
            addEntityProcessor(new NodeClickHandler(globals));

            NodeLoad[] nodeLoads = new NodeLoad[3];
            nodeLoads[0] = new NodeLoad(-150, 0, 2);
            nodeLoads[1] = new NodeLoad(150, 0, 0);
            nodeLoads[2] = new NodeLoad(0, 100, 4);

            Tuple<int, int>[] connections = new Tuple<int, int>[3];
            connections[0] = new Tuple<int, int>(0, 1);
            connections[1] = new Tuple<int, int>(1, 2);
            connections[2] = new Tuple<int, int>(2, 0);

            globals.addComponent(new MapLoad(nodeLoads, connections));
        }
    }
}