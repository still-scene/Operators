using System;
using System.Numerics;
using T3.Core;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_3b0eb327_6ad8_424f_bca7_ccbfa2c9a986
{
    public class Jitter : Instance<Jitter>
    {
        [Output(Guid = "0307A381-FE96-4988-89B1-FD6DC0274119", DirtyFlagTrigger = DirtyFlagTrigger.Animated)]
        public readonly Slot<float> Result = new Slot<float>();

        public Jitter()
        {
            Result.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var startValue = Value.GetValue(context);
            var limitRange = MaxRange.GetValue(context);
            var seed = Seed.GetValue(context);
            var jumpDistance = JumpDistance.GetValue(context);
            _rate = Rate.GetValue(context);

            var reset = Reset.GetValue(context);
            var jump = Jump.GetValue(context);

            if (!_initialized || reset || float.IsNaN(_offset))
            {
                _random = new Random(seed);
                _offset = 0;
                _initialized = true;
                jump = true;
            }

            _beatTime = EvaluationContext.GlobalTimeForEffects;

            if (UseRate)
            {
                var activationIndex = (int)(_beatTime * _rate);
                if (activationIndex != _lastActivationIndex)
                {
                    _lastActivationIndex = activationIndex;
                    jump = true;
                }
            }

            if (jump)
            {
                _jumpStartOffset = _offset;
                _jumpTargetOffset = _offset + (float)((_random.NextDouble() - 0.5f) * jumpDistance * 2f);

                if (limitRange > 0.001f)
                {
                    var d = Math.Abs(_jumpTargetOffset);
                    if (d > limitRange)
                    {
                        var overshot = Math.Min(d - limitRange, limitRange);
                        var random = (_random.NextDouble() * overshot);

                        _jumpTargetOffset = _jumpTargetOffset > 0
                                                ? (limitRange - (float)random)
                                                : (-limitRange + (float)random);
                    } 
                }

                _lastJumpTime = _beatTime;
            }
 
            var blending = Blending.GetValue(context);
            if (blending >= 0.001)
            {
                var t = (Fragment / blending).Clamp(0, 1);
                if (SmoothBlending.GetValue(context))
                    t = MathUtils.SmootherStep(0, 1, t);

                _offset = MathUtils.Lerp(_jumpStartOffset, _jumpTargetOffset, t);
            }
            else
            {
                _offset = _jumpTargetOffset;
            }

            Result.Value = _offset + startValue;
        }

        public float Fragment =>
            UseRate
                ? (float)((_beatTime - _lastJumpTime) * _rate).Clamp(0, 1)
                : (float)(_beatTime - _lastJumpTime).Clamp(0, 1);

        private bool UseRate => _rate > 0.0001f;

        private float _rate;
        private double _beatTime;

        private Random _random = new Random();
        private bool _initialized = false;
        private int _lastActivationIndex = 0;
        private double _lastJumpTime;
        private float _offset;
        private float _jumpStartOffset;
        private float _jumpTargetOffset;

        [Input(Guid = "7484B865-A74F-4B13-9520-BD42F289CB9A")]
        public readonly InputSlot<float> Value = new InputSlot<float>();

        [Input(Guid = "74D3963F-3563-4CC7-86B9-DCE93B5FE5AB")]
        public readonly InputSlot<float> JumpDistance = new InputSlot<float>();

        [Input(Guid = "41268143-F63A-49F2-9343-B64C885981B3")]
        public readonly InputSlot<float> MaxRange = new InputSlot<float>();

        [Input(Guid = "C7BBB096-DD90-4B06-9C16-36521347147C")]
        public readonly InputSlot<float> Rate = new InputSlot<float>();

        [Input(Guid = "57B0BB27-19FD-4D0C-96DE-9D5B320FDE98")]
        public readonly InputSlot<float> Blending = new InputSlot<float>();

        [Input(Guid = "E861CBAB-196E-46BD-A2C8-660E4CA62B9F")]
        public readonly InputSlot<bool> SmoothBlending = new InputSlot<bool>();

        [Input(Guid = "4083708B-FAA4-47C4-88CB-7D137A041DDB")]
        public readonly InputSlot<int> Seed = new InputSlot<int>();

        [Input(Guid = "FC34F1F1-90F9-4FC5-9433-1CB880BE97D0")]
        public readonly InputSlot<bool> Reset = new InputSlot<bool>();

        [Input(Guid = "12987B62-5732-421C-8B18-30D169765074")]
        public readonly InputSlot<bool> Jump = new InputSlot<bool>();
    }
}