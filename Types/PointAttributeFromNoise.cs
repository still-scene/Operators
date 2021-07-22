using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Interfaces;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_7af59063_88d2_4697_985c_e09b8c77a43f
{
    public class PointAttributeFromNoise : Instance<PointAttributeFromNoise>
    {
        [Output(Guid = "bcf4be5a-e3ea-48da-a06d-c206041f8d41")]
        public readonly Slot<T3.Core.DataTypes.BufferWithViews> OutBuffer = new Slot<T3.Core.DataTypes.BufferWithViews>();

        // public SamplePointAttributes()
        // {
        //     OutBuffer.TransformableOp = this;
        // }
        
        // System.Numerics.Vector3 ITransformable.Translation { get => Center.Value; set => Center.SetTypedInputValue(value); }
        // System.Numerics.Vector3 ITransformable.Rotation { get => System.Numerics.Vector3.Zero; set { } }
        // System.Numerics.Vector3 ITransformable.Scale { get => System.Numerics.Vector3.One; set { } }

        //public Action<ITransformable, EvaluationContext> TransformCallback { get => OutBuffer.TransformCallback; set => OutBuffer.TransformCallback = value; }
        
        [Input(Guid = "47c5b5cc-e48e-4111-a9a2-4e3ccebe8964")]
        public readonly InputSlot<T3.Core.DataTypes.BufferWithViews> GPoints = new InputSlot<T3.Core.DataTypes.BufferWithViews>();

        [Input(Guid = "a092b2fb-df64-4b6a-89ff-a8fe7bc1de05", MappedType = typeof(Attributes))]
        public readonly InputSlot<int> Brightness = new InputSlot<int>();

        [Input(Guid = "6427417b-3bd3-46cb-994e-561d91cdc512")]
        public readonly InputSlot<float> BrightnessFactor = new InputSlot<float>();

        [Input(Guid = "f6c2a790-c2b4-41b0-ade8-f39b28af2ea6")]
        public readonly InputSlot<float> BrightnessOffset = new InputSlot<float>();

        [Input(Guid = "d5877e95-c689-47cb-8852-9a6db40548d5", MappedType = typeof(Attributes))]
        public readonly InputSlot<int> Red = new InputSlot<int>();

        [Input(Guid = "b640ac69-324f-4aa8-aaf5-c209c29766a0")]
        public readonly InputSlot<float> RedFactor = new InputSlot<float>();

        [Input(Guid = "55d8bb8e-0650-4684-a232-4f0cde397133")]
        public readonly InputSlot<float> RedOffset = new InputSlot<float>();

        [Input(Guid = "df65d576-6e63-4082-a8c2-159e57ac4cf5", MappedType = typeof(Attributes))]
        public readonly InputSlot<int> Green = new InputSlot<int>();

        [Input(Guid = "cb2cc77d-65e1-4324-b3a2-76311bf4b283")]
        public readonly InputSlot<float> GreenFactor = new InputSlot<float>();

        [Input(Guid = "7d592032-da00-4540-ace1-76d710826c07")]
        public readonly InputSlot<float> GreenOffset = new InputSlot<float>();

        [Input(Guid = "43c2f8fd-168b-4696-b4c5-54cd33d3f50d", MappedType = typeof(Attributes))]
        public readonly InputSlot<int> Blue = new InputSlot<int>();

        [Input(Guid = "6283568c-32b4-42f4-879e-099fb07c30f4")]
        public readonly InputSlot<float> BlueFactor = new InputSlot<float>();

        [Input(Guid = "e1e841eb-edbb-407e-986a-704ce77f89d1")]
        public readonly InputSlot<float> BlueOffset = new InputSlot<float>();

        [Input(Guid = "b0c96c9c-ae16-4781-9642-5dd84dbe9fe2")]
        public readonly InputSlot<System.Numerics.Vector3> Center = new InputSlot<System.Numerics.Vector3>();

        [Input(Guid = "f966e78b-b4e5-4d26-a239-febe24f12bd7")]
        public readonly InputSlot<float> Phase = new InputSlot<float>();

        [Input(Guid = "16b6db95-e71d-427e-93b5-1568d7cd249c")]
        public readonly InputSlot<float> Frequency = new InputSlot<float>();

        [Input(Guid = "69fc36a5-b5bf-4c5f-bd0c-0c81473e4c5a")]
        public readonly InputSlot<float> Amount = new InputSlot<float>();


        private enum Attributes
        {
            NotUsed =0,
            For_X = 1,
            For_Y =2,
            For_Z =3,
            For_W =4,
            Rotate_X =5,
            Rotate_Y =6 ,
            Rotate_Z =7,
        }
    }
}

