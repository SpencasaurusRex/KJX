using System;
using KJX.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace KJX.Systems
{
    public class ConnectionLoader : EntityProcessingSystem
    {
        readonly Texture2D line;

        public ConnectionLoader(Texture2D line) : base(new Matcher().all(typeof(ConnectionLoad)))
        {
            this.line = line;
        }

        public override void process(Entity loadEntity)
        {
            var load = loadEntity.getComponent<ConnectionLoad>();
            loadEntity.removeComponent<ConnectionLoad>();
            loadEntity.destroy();

            var distance = Vector2.Distance(load.Start, load.End);
            var difference = load.End - load.Start;
            var theta = (float)Math.Atan2(difference.Y, difference.X);

            for (int i = 0; i < distance; i += line.Width)
            {
                float t = i / distance;
                float x = load.Start.X + difference.X * t;
                float y = load.Start.Y + difference.Y * t;
                var lineEntity = scene.createEntity("connectionLine");
                lineEntity.position = new Vector2(x, y);
                lineEntity.rotation = theta;
                var sprite = new Sprite(line);
                lineEntity.addComponent(sprite.setRenderLayer(1));
            }
        }
    }
}
