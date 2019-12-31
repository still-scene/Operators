using System;
using T3.Core.Operator;

namespace T3.Operators.Types
{
    public class _multiImageFxSetup : Instance<_multiImageFxSetup>
    {
        [Output(Guid = "b6bd9c40-1695-46d0-925e-dbaa7882f0ff")]
        public readonly Slot<SharpDX.Direct3D11.Texture2D> Output = new Slot<SharpDX.Direct3D11.Texture2D>();


        [Input(Guid = "fc069ee6-7d18-4856-bcf3-1e7c9b8fd4d8")]
        public readonly InputSlot<SharpDX.Direct3D11.Texture2D> ImageA = new InputSlot<SharpDX.Direct3D11.Texture2D>();

        [Input(Guid = "c3da7928-5c0c-4478-9412-fd4b68a094d5")]
        public readonly InputSlot<SharpDX.Direct3D11.Texture2D> ImageB = new InputSlot<SharpDX.Direct3D11.Texture2D>();

        [Input(Guid = "7f14d0e3-1159-434d-b038-74644948937c")]
        public readonly InputSlot<string> ShaderPath = new InputSlot<string>();

        [Input(Guid = "bcc7fb78-1ac3-46f7-be46-885233420e80")]
        public readonly MultiInputSlot<float> FloatParams = new MultiInputSlot<float>();
    }
}
