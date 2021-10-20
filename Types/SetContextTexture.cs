using SharpDX.Direct3D11;
using T3.Core;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;
using T3.Core.Rendering;
using Utilities = T3.Core.Utilities;
using Vector4 = System.Numerics.Vector4;


namespace T3.Operators.Types.Id_944d1903_cd23_49ca_9b0d_2fc73bfcfd30
{
    public class SetContextTexture : Instance<SetContextTexture>
    {
        [Output(Guid = "db61864d-0dd4-44bf-9722-0b9ce7e8fdd4")]
        public readonly Slot<Command> Output = new Slot<Command>();

        public SetContextTexture()
        {
            Output.UpdateAction = Update;
        }

        //private Buffer _parameterBuffer = null;

        private void Update(EvaluationContext context)
        {
            var id = Id.GetValue(context);
            
            //var previousMap = context.PrbPrefilteredSpecular;
            var tex = PrefilteredSpecularMap.GetValue(context) ?? PbrContextSettings.WhitePixelTexture;
            var hadPreviousTexture = context.ContextTextures.TryGetValue(id, out var previousTexture);
            context.ContextTextures[id] = tex;
            // {
            //     
            // }
            //
            // if (tex != null)
            // {
            //     context.PrbPrefilteredSpecular = tex;
            // }
            
            SubTree.GetValue(context);
            if (hadPreviousTexture)
            {
                context.ContextTextures[id] = previousTexture;
            }
            else
            {
                context.ContextTextures.Remove(id);
            }
        }

        [Input(Guid = "16863415-1d90-46a7-80a4-372602a49c6f")]
        public readonly InputSlot<Command> SubTree = new InputSlot<Command>();

        [Input(Guid = "1CD51956-0E0C-4B3F-B071-8D86CDCB7080")]
        public readonly InputSlot<string> Id = new InputSlot<string>();
        
        [Input(Guid = "3ab2e94d-b10b-4cd9-9ee0-073292a947fc")]
        public readonly InputSlot<Texture2D> PrefilteredSpecularMap = new InputSlot<Texture2D>();

    }
}