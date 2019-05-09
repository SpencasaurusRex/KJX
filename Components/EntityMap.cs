using System.Collections.Generic;
using Nez;

namespace KJX.Components
{
    public class EntityMap : Component
    {
        public Dictionary<Entity, List<Entity>> Connections;

        public EntityMap()
        {
            Connections = new Dictionary<Entity, List<Entity>>();
        }

        public List<Entity> this[Entity e]
        {
            get
            {
                if (!Connections.TryGetValue(e, out var list))
                {
                    Connections.Add(e, list = new List<Entity>());
                }
                return list;
            }
        }

        public void Connect(Entity from, Entity to)
        {
            this[from].Add(to);
        }

        public bool Disconnect(Entity from, Entity to)
        {
            return this[from].Remove(to);
        }
    }
}
