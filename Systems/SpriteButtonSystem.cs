using KJX.Components;
using Nez;
using Nez.Sprites;
using Nez.Textures;

namespace KJX
{
    public class SpriteButtonSystem : EntityProcessingSystem
    {
        public SpriteButtonSystem() : base(new Matcher().all(typeof(Clickable), typeof(SpriteButton)))
        {
        }

        public override void process(Entity entity)
        {
            var sprite = entity.getOrCreateComponent<Sprite>();
            var currentTexture = sprite.subtexture?.texture2D;
            var clickable = entity.getComponent<Clickable>();
            var button = entity.getComponent<SpriteButton>();
            var targetTexture = clickable.LeftPressed ? button.ClickedTexture : button.DefaultTexture;
            
            if (currentTexture != targetTexture)
            {
                sprite.setSubtexture(new Subtexture(targetTexture));
            }
        }
    }
}
