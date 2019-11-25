using T3.Core.Operator.Helper;
using T3.Core;
using T3.Core.Operator;

namespace T3.Operators.Types
{
    public class ParticleDraw : Instance<ParticleDraw>
    {
        [Output(Guid = "519c6615-7814-42e9-aa7d-5158bc02bb1e")]
        public readonly Slot<Command> Output = new Slot<Command>();


        [Input(Guid = "ed0c2c1a-2a20-4d49-a812-80f8d19e447b")]
        public readonly InputSlot<ParticleSystem> ParticleSystem = new InputSlot<ParticleSystem>();

        [Input(Guid = "CD19CC42-4033-4B43-A73C-3E4E50D3095E")]
        public readonly InputSlot<System.Numerics.Vector4> Color = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "8D418AD8-8D65-491A-9CF3-14DD046A3A53")]
        public readonly InputSlot<float> Size = new InputSlot<float>();
    }
}

