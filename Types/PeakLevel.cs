using System;
using T3.Core;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;
using T3.Operators.Types.Id_c513c58d_e45c_408d_a0b8_250c9af31545;

namespace T3.Operators.Types.Id_d3fb5baf_43f8_4983_a1d9_42f4005a3af0
{
    public class PeakLevel : Instance<PeakLevel>
    {
        [Output(Guid = "6fe37109-0177-4823-9466-eaa49adb19d4")]
        public readonly Slot<float> AttackLevel = new Slot<float>();
        
        [Output(Guid = "80DCAD3B-5E93-4991-855D-24176EC54F4D", DirtyFlagTrigger = DirtyFlagTrigger.Animated)]
        public readonly Slot<bool> FoundPeak = new Slot<bool>();
        
        public PeakLevel()
        {
            AttackLevel.UpdateAction = Update;
            FoundPeak.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var t = EvaluationContext.BeatTime;

            var wasEvaluatedThisFrame = t <= _lastEvalTime;
            if (wasEvaluatedThisFrame)
                return;
            
            _lastEvalTime = t;
            
            var value = Value.GetValue(context);
            var increase = (value - _lastValue).Clamp(0, 10000);
            
            var timeSinceLastPeak = EvaluationContext.RunTimeInSecs - _lastPeakTime;
            if (timeSinceLastPeak < 0)
                _lastPeakTime = Double.NegativeInfinity;

            if (increase > Threshold.GetValue(context) && timeSinceLastPeak > MinTimeBetweenPeaks.GetValue(context))
            {
                 _lastPeakTime = EvaluationContext.RunTimeInSecs;
                 FoundPeak.Value = true;
            }
            else
            {
                FoundPeak.Value = false;
            }

            AttackLevel.Value = increase;
            _lastValue = value;
        }

        private double _lastEvalTime;
        private double _lastPeakTime = double.NegativeInfinity;
        private float _lastValue;
        
        
        [Input(Guid = "88ed25d3-ab67-47da-ad38-2f0126ce0492")]
        public readonly InputSlot<float> Value = new InputSlot<float>();

        [Input(Guid = "279C4F32-2F8A-4679-AFE4-BBF14CF6BA05")]
        public readonly InputSlot<float> Threshold = new InputSlot<float>();
        

        [Input(Guid = "D38D54B4-D15C-40C3-A5F1-6546F444965C")]
        public readonly InputSlot<float> MinTimeBetweenPeaks = new InputSlot<float>();
    }
}