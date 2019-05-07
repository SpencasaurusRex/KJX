using Microsoft.Xna.Framework;
using Nez;

namespace KJX
{
    public class Clickable : Component
    {
        public Rectangle ClickArea;

        public Clickable(Rectangle clickArea)
        {
            ClickArea = clickArea;
        }
    }
}
