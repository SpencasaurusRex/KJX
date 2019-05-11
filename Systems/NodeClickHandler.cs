using System.Collections.Generic;
using KJX.Components;
using Nez;

namespace KJX.Systems
{
    public class NodeClickHandler : EntityProcessingSystem
    {
        readonly Entity globalEntity;

        public NodeClickHandler(Entity globalEntity) : base(new Matcher().all(typeof(Clickable), typeof(NodeAmount)))
        {
            this.globalEntity = globalEntity;
        }

        public override void process(Entity entity)
        {
        }

        protected override void process(List<Entity> entities)
        {
            var map = globalEntity.getComponent<EntityMap>();
            foreach (var entity in entities)
            {
                process(entity, map);
            }
        }

        public void process(Entity entity, EntityMap map)
        {
            var clickable = entity.getComponent<Clickable>();
            var nodeAmount = entity.getComponent<NodeAmount>();
            var connections = map[entity];

            if (clickable.LeftReleased)
            {
                if (nodeAmount.Amount < connections.Count)
                {
                    // TODO: Visual
                    return;
                }

                foreach (var connectedNode in connections)
                {
                    var connectedNodeAmount = connectedNode.getComponent<NodeAmount>();
                    connectedNodeAmount.Amount++;
                    nodeAmount.Amount--;
                }
            }

            if (clickable.RightReleased)
            {
                foreach (var connectedNode in connections)
                {
                    var connectedNodeAmount = connectedNode.getComponent<NodeAmount>();
                    if (connectedNodeAmount.Amount > 0)
                    {
                        connectedNodeAmount.Amount--;
                        nodeAmount.Amount++;
                    }
                }
            }
        }
    }
}
