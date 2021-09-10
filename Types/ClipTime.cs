using System.Diagnostics;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_83b8fc42_a200_4c3d_85dc_035b4f478069
{
    public class ClipTime : Instance<ClipTime>
    {
        [Output(Guid = "3d9050a0-5688-4315-a6a4-fd8f1613eae2", DirtyFlagTrigger = DirtyFlagTrigger.Always)]
        public readonly Slot<float> Time = new Slot<float>();

        public ClipTime()
        {
            Time.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            
            Time.Value = (float)context.TimeForKeyframes;
        }
    }
}