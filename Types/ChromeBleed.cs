using SharpDX.Direct3D11;
using T3.Core;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_007b7ad9_e8f2_4830_be0f_d3f5f3444683
{
    public class ChromeBleed : Instance<ChromeBleed>
    {
        [Output(Guid = "5ff09d7b-4f78-4230-8ca7-4d3da4606e3f")]
        public readonly Slot<Command> Output = new Slot<Command>();

        [Input(Guid = "7504facd-2800-4d23-a86a-7b97ccc54529")]
        public readonly MultiInputSlot<Command> Command = new MultiInputSlot<Command>();

        [Input(Guid = "29579dbe-bc75-4be9-b268-845ec0cd389d")]
        public readonly InputSlot<System.Numerics.Vector4> Fill = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "2b115c7f-9ced-43a1-b46c-46495ca262ff")]
        public readonly InputSlot<float> BlurRadius = new InputSlot<float>();

        [Input(Guid = "f8072fb7-9769-4fd1-8159-4f3d06b27994")]
        public readonly InputSlot<System.Numerics.Vector4> BackColor = new InputSlot<System.Numerics.Vector4>();

    }
}

