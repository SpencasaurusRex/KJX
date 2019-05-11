using KJX.Components;
using Nez;

namespace KJX.Systems
{
    public class SlidingUVWriter : EntityProcessingSystem
    {
        public SlidingUVWriter() : base(new Matcher().all(typeof(SlidingNumber), typeof(UvMesh)))
        {
        }

        public override void process(Entity entity)
        {
            var uvMesh = entity.getComponent<UvMesh>();
            var slidingNumber = entity.getComponent<SlidingNumber>();

            //if (slidingNumber.Number != slidingNumber.Previous) return;
            float bottom = (9 - slidingNumber.Number) * .1f;
            float top = bottom + .1f;
            uvMesh.Vertices[0].TextureCoordinate.Y = uvMesh.Vertices[2].TextureCoordinate.Y = bottom;
            uvMesh.Vertices[1].TextureCoordinate.Y = uvMesh.Vertices[3].TextureCoordinate.Y = top;
        }
    }
}
