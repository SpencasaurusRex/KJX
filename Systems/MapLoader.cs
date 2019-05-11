using System;
using KJX.Components;
using KJX.Factories;
using Nez;

namespace KJX.Systems
{
    public class MapLoader : EntityProcessingSystem
    {
        readonly Entity globalEntity;
        readonly NodeFactory nodeFactory;

        public MapLoader(Entity globalEntity, NodeFactory nodeFactory) : base(new Matcher().all(typeof(MapLoad)))
        {
            this.globalEntity = globalEntity;
            this.nodeFactory = nodeFactory;
        }

        public override void process(Entity entity)
        {
            var load = entity.getComponent<MapLoad>();
            var map = globalEntity.getComponent<EntityMap>();

            // Clear old map
            foreach (var oldNode in map.Connections.Keys)
            {
                oldNode.destroy();
            }
            map.Connections.Clear();

            // Create new map
            Entity[] nodeEntities = new Entity[load.Nodes.Length];
            for (int i = 0; i < load.Nodes.Length; i++)
            {
                nodeEntities[i] = scene.createEntity("Node");
                nodeFactory.Setup(nodeEntities[i], load.Nodes[i]);
            }
            // Link nodes
            foreach (var (i,j) in load.Connections)
            {
                map.Connect(nodeEntities[i], nodeEntities[j]);
                map.Connect(nodeEntities[j], nodeEntities[i]);
                var connectionLoad = scene.createEntity("connectionLoad");
                connectionLoad.addComponent(new ConnectionLoad(nodeEntities[i].position, nodeEntities[j].position));
            }

            entity.removeComponent<MapLoad>();
        }
    }
}
