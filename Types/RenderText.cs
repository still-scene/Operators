using T3.Core;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_fd31d208_12fe_46bf_bfa3_101211f8f497
{
    public class RenderText : Instance<RenderText>
    {
        [Output(Guid = "3f8b20a7-c8b8-45ab-86a1-0efcd927358e")]
        public readonly Slot<Command> Output = new Slot<Command>();

        [Input(Guid = "f1f1be0e-d5bc-4940-bbc1-88bfa958f0e1")]
        public readonly InputSlot<string> Text = new InputSlot<string>();

        [Input(Guid = "0e5f05b4-5e8a-4f6d-8cac-03b04649eb67")]
        public readonly InputSlot<System.Numerics.Vector4> Color = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "15b1e70a-561c-4ba3-a078-eead7383e41e")]
        public readonly InputSlot<System.Numerics.Vector3> Params3 = new InputSlot<System.Numerics.Vector3>();

        [Input(Guid = "50c9ab21-39f4-4e92-b5a7-ad9e60ae6ec3")]
        public readonly InputSlot<string> FontPath = new InputSlot<string>();

        [Input(Guid = "d89c518c-a862-4f46-865b-0380350b7417")]
        public readonly InputSlot<float> Size = new InputSlot<float>();

        [Input(Guid = "eaf9dc37-e70f-4197-895c-b5607456b4a2")]
        public readonly InputSlot<float> LineHeight = new InputSlot<float>();

        [Input(Guid = "835d7f17-9de4-4612-a2f0-01c1346cdf1a")]
        public readonly InputSlot<float> Spacing = new InputSlot<float>();

        [Input(Guid = "de0fed7d-d2af-4424-baf3-81606e26559f")]
        public readonly InputSlot<System.Numerics.Vector2> Position = new InputSlot<System.Numerics.Vector2>();

        [Input(Guid = "ae7f7e83-fa18-44fd-b639-3bd0dbd3ac06")]
        public readonly InputSlot<int> VerticalAlign = new InputSlot<int>();

        [Input(Guid = "82cc31ff-3307-4b6d-be70-16e471c2ffc9")]
        public readonly InputSlot<int> HorizontalAlign = new InputSlot<int>();
    }
}

