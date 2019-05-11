using System;
using KJX.Components;
using Nez;

namespace KJX.Systems
{
    public class SlidingNumberMover : EntityProcessingSystem
    {
        public SlidingNumberMover() : base(new Matcher().all(typeof(NodeAmount), typeof(SlidingNumber)))
        {
        }

        public override void process(Entity entity)
        {
            var rollingNumber = entity.getComponent<SlidingNumber>();
            var nodeAmount = entity.getComponent<NodeAmount>();
            if (rollingNumber.Instant)
            {
                rollingNumber.Number = nodeAmount.Amount;
                rollingNumber.Instant = false;
            }

            rollingNumber.Previous = rollingNumber.Number;
            var diff = nodeAmount.Amount - rollingNumber.Number;
            rollingNumber.Number += Math.Sign(diff) * Math.Min(Math.Abs(diff), .1f);
        }
    }
}
