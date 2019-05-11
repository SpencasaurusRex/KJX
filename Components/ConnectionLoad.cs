using Microsoft.Xna.Framework;

namespace KJX.Components
{
    public class ConnectionLoad : Nez.Component
    {
        public Vector2 Start;
        public Vector2 End;

        public ConnectionLoad(Vector2 start, Vector2 end)
        {
            Start = start;
            End = end;
        }
    }
}
