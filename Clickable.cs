using Nez;

namespace KJX
{
    public class Clickable : Component
    {
        public bool Left;
        public bool Right;
        public bool LeftClicked;
        public bool RightClicked;

        public Clickable(bool left, bool right)
        {
            Left = left;
            Right = right;
        }
    }
}
