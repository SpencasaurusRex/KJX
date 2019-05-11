using System.Collections.Generic;
using Nez;

namespace KJX.Components.Global
{
    public class GlobalNodeMap : Nez.Component
    {
        public Dictionary<int, NodeAmount> Nodes;
        public Dictionary<int, List<int>> Connections;

        public GlobalNodeMap()
        {
            Nodes = new Dictionary<int, NodeAmount>();
            Connections = new Dictionary<int, List<int>>();
        }
    }
}
