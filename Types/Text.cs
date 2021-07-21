using System;
using System.Numerics;
using T3.Core;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Interfaces;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_fd31d208_12fe_46bf_bfa3_101211f8f497
{
    public class Text : Instance<Text>, ITransformable
    {
        private enum HorizontalAligns
        {
            Left,
            Center,
            Right,
        }
        
        private enum VerticalAligns
        {
            Top,
            Middle,
            Bottom,
        }
        
        [Output(Guid = "3f8b20a7-c8b8-45ab-86a1-0efcd927358e", DirtyFlagTrigger = DirtyFlagTrigger.Always)]
        public readonly TransformCallbackSlot<Command> Output = new TransformCallbackSlot<Command>();

        
        public Text()
        {
            Output.TransformableOp = this;
        }
        
        System.Numerics.Vector3 ITransformable.Translation { get => new Vector3(Position.Value.X, Position.Value.Y,0); 
            set => Position.SetTypedInputValue(new Vector2(value.X, value.Y)); }
        System.Numerics.Vector3 ITransformable.Rotation { get => System.Numerics.Vector3.Zero; set { } }
        System.Numerics.Vector3 ITransformable.Scale { get => System.Numerics.Vector3.One; set { } }

        public Action<ITransformable, EvaluationContext> TransformCallback { get => Output.TransformCallback; set => Output.TransformCallback = value; }
        
        
        [Input(Guid = "f1f1be0e-d5bc-4940-bbc1-88bfa958f0e1")]
        public readonly InputSlot<string> Input = new InputSlot<string>();

        [Input(Guid = "0e5f05b4-5e8a-4f6d-8cac-03b04649eb67")]
        public readonly InputSlot<System.Numerics.Vector4> Color = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "989e6950-fd32-4d0b-97c2-d03264cb2db5")]
        public readonly InputSlot<System.Numerics.Vector4> Shadow = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "de0fed7d-d2af-4424-baf3-81606e26559f")]
        public readonly InputSlot<System.Numerics.Vector2> Position = new InputSlot<System.Numerics.Vector2>();

        [Input(Guid = "d89c518c-a862-4f46-865b-0380350b7417")]
        public readonly InputSlot<float> Size = new InputSlot<float>();

        [Input(Guid = "eaf9dc37-e70f-4197-895c-b5607456b4a2")]
        public readonly InputSlot<float> LineHeight = new InputSlot<float>();

        [Input(Guid = "ae7f7e83-fa18-44fd-b639-3bd0dbd3ac06", MappedType =  typeof(VerticalAligns))]
        public readonly InputSlot<int> VerticalAlign = new InputSlot<int>();

        [Input(Guid = "82cc31ff-3307-4b6d-be70-16e471c2ffc9", MappedType = typeof(HorizontalAligns))]
        public readonly InputSlot<int> HorizontalAlign = new InputSlot<int>();

        [Input(Guid = "835d7f17-9de4-4612-a2f0-01c1346cdf1a")]
        public readonly InputSlot<float> Spacing = new InputSlot<float>();

        [Input(Guid = "50c9ab21-39f4-4e92-b5a7-ad9e60ae6ec3")]
        public readonly InputSlot<string> FontPath = new InputSlot<string>();

        [Input(Guid = "28be4e86-6761-4d07-80bf-abf6f82897e4")]
        public readonly InputSlot<SharpDX.Direct3D11.CullMode> CullMode = new InputSlot<SharpDX.Direct3D11.CullMode>();

        [Input(Guid = "7a76d5aa-1f44-4238-9333-7c2951becc31")]
        public readonly InputSlot<bool> EnableZTest = new InputSlot<bool>();
    }
}

