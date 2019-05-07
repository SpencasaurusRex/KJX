using Nez;
using Nez.Sprites;

namespace KJX
{
    public class SpriteButtonSystem : EntityProcessingSystem
    {
        public SpriteButtonSystem() : base(new Matcher().all(typeof(Clickable), typeof(SpriteButton)))
        {
        }

        public override void process(Entity entity)
        {
            var currentSprite = entity.getComponent<Sprite>();
            var clickable = entity.getComponent<Clickable>();
            var button = entity.getComponent<SpriteButton>();
            var targetSprite = clickable.LeftClicked ? button.ClickedSprite : button.DefaultSprite;
            
            if (currentSprite != targetSprite)
            {
                entity.removeComponent<Sprite>();
                entity.addComponent(targetSprite);
            }
        }
    }
}
