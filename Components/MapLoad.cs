using System;
using Nez;

namespace KJX.Components
{
    public class MapLoad : Component
    {
        public NodeLoad[] Nodes;
        public Tuple<int, int>[] Connections;

        public MapLoad(NodeLoad[] nodes, Tuple<int, int>[] connections)
        {
            Nodes = nodes;
            Connections = connections;
        }
    }

    public class NodeLoad
    {
        public float X;
        public float Y;
        public int Amount;

        public NodeLoad(float x, float y, int amount)
        {
            X = x;
            Y = y;
            Amount = amount;
        }
    }
}
