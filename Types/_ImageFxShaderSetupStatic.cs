using System;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_bd0b9c5b_c611_42d0_8200_31af9661f189
{
    public class _ImageFxShaderSetupStatic : Instance<_ImageFxShaderSetupStatic>
    {
        [Output(Guid = "d49f10dc-6617-4541-96d3-b58b0266b631")]
        public readonly Slot<SharpDX.Direct3D11.Texture2D> TextureOutput = new Slot<SharpDX.Direct3D11.Texture2D>();

        [Input(Guid = "b55312c4-6441-473f-a107-df50de60c72e")]
        public readonly InputSlot<SharpDX.Direct3D11.Texture2D> Texture = new InputSlot<SharpDX.Direct3D11.Texture2D>();

        [Input(Guid = "1e4e274b-60b2-4fe8-b275-ebef80d520a7")]
        public readonly InputSlot<string> Source = new InputSlot<string>();

        [Input(Guid = "4ef6f204-1894-4b0a-bb2d-8b5ecbad4040")]
        public readonly MultiInputSlot<float> Params = new MultiInputSlot<float>();

        [Input(Guid = "9695b557-433c-474b-bf34-219cbc134bee")]
        public readonly InputSlot<SharpDX.Size2> Resolution = new InputSlot<SharpDX.Size2>();

        [Input(Guid = "3fe1b650-ce34-4155-9b61-0425e39f7690")]
        public readonly InputSlot<SharpDX.Direct3D11.TextureAddressMode> Wrap = new InputSlot<SharpDX.Direct3D11.TextureAddressMode>();

        [Input(Guid = "ff7cb999-aa3a-4e11-b9c8-d027bdb55ff6")]
        public readonly InputSlot<SharpDX.DXGI.Format> OutputFormat = new InputSlot<SharpDX.DXGI.Format>();

        [Input(Guid = "6cf68692-43a5-4a93-873c-99aa0d2dde93")]
        public readonly InputSlot<System.Numerics.Vector4> BufferColor = new InputSlot<System.Numerics.Vector4>();

        [Input(Guid = "480d6c19-a33c-48b3-b9fa-aaf8bd31e6d9")]
        public readonly InputSlot<bool> GenerateMips = new InputSlot<bool>();

    }
}

