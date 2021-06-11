using System;
using T3.Core;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_487dad15_abb2_4d8f_a66a_520af9739684
{
    public class CW_ResourceIcon : Instance<CW_ResourceIcon>
    {
        [Output(Guid = "2a942a7d-3e98-4c15-9736-675095c714c6")]
        public readonly Slot<Command> Output = new Slot<Command>();

        [Input(Guid = "56bc4d62-4938-4173-86d5-1f1bd3ea6a43")]
        public readonly InputSlot<string> ImagePath = new InputSlot<string>();

        [Input(Guid = "e49a4ccf-31aa-4168-9b28-b034dbc0848a")]
        public readonly InputSlot<float> Value = new InputSlot<float>();

        [Input(Guid = "a03886ac-21a6-4c3e-bedd-a3c1a60f17ab")]
        public readonly InputSlot<System.Numerics.Vector2> Position = new InputSlot<System.Numerics.Vector2>();

    }
}

