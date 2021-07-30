using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_44d57201_addf_455c_9e31_709b018ba29f
{
    public class DrawConnectionLines : Instance<DrawConnectionLines>
    {

        [Output(Guid = "5f0e1d16-41a4-4c55-95c3-6e3b66a724b7")]
        public readonly Slot<T3.Core.Command> Output = new Slot<T3.Core.Command>();

        [Input(Guid = "1bf7d8c0-1c8c-4791-8960-389869059489")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> PointsA_ = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "db5ec31c-ea35-4780-a054-67ce9fbe80ec")]
        public readonly InputSlot<float> CellSize = new InputSlot<float>();

        [Input(Guid = "e84dcbfa-04e4-4acd-8fcd-b1da20abd71f")]
        public readonly InputSlot<bool> IsEnabled = new InputSlot<bool>();

        [Input(Guid = "7ae1d0c1-b9a7-47f1-8a0c-80bfc1219c4b")]
        public readonly InputSlot<int> StepCount = new InputSlot<int>();

        [Input(Guid = "496e1983-f74e-412c-9b80-8dedd0f8c1f8")]
        public readonly InputSlot<int> LinesPerStep = new InputSlot<int>();

        [Input(Guid = "ab4945b8-5e50-4f40-9689-839a4051f0ec")]
        public readonly InputSlot<T3.Core.DataTypes.Gradient> ColorOverLifetime = new InputSlot<T3.Core.DataTypes.Gradient>();

        [Input(Guid = "df2076a1-1d25-4112-b0e6-2987541786d9")]
        public readonly InputSlot<System.Numerics.Vector4> Color = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "5f64292f-24ac-4a6c-ac3f-402468b0391b")]
        public readonly InputSlot<float> LineWidth = new InputSlot<float>();

        [Input(Guid = "09af14b3-b4c3-4044-b5d1-0d05ec29b6b4")]
        public readonly InputSlot<float> ScatterLookUp = new InputSlot<float>();

        [Input(Guid = "7d6b777c-3478-4dec-b2a4-dd286473a3f2")]
        public readonly InputSlot<T3.Core.DataTypes.Gradient> LineGradient = new InputSlot<T3.Core.DataTypes.Gradient>();

        [Input(Guid = "2356bf51-8e08-49f9-8d97-fac5bb6bc25e")]
        public readonly InputSlot<int> BlendMode = new InputSlot<int>();

        [Input(Guid = "32cd717f-59aa-4fad-9a39-138177124b8c")]
        public readonly InputSlot<bool> EnableZWrite = new InputSlot<bool>();
    }
}

