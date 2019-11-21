﻿using System.Linq;
using System.Runtime.InteropServices;
using SharpDX.Direct3D11;
using T3.Core;
using T3.Core.Logging;
using T3.Core.Operator;

namespace T3.Operators.Types
{
    public class ParticleIndexBuffer : Instance<ParticleIndexBuffer>
    {
        [Output(Guid = "9F6D062D-34BA-47B9-B309-667E863258F3")]
        public readonly Slot<SharpDX.Direct3D11.Buffer> Buffer = new Slot<SharpDX.Direct3D11.Buffer>();

        public ParticleIndexBuffer()
        {
            Buffer.UpdateAction = Update;
            // Buffer.DirtyFlag.Trigger = DirtyFlagTrigger.Always; // for debugging with renderdoc
        }

        private void Update(EvaluationContext context)
        {
            int count = Count.GetValue(context);
            if (count == 0)
                return;

            var resourceManager = ResourceManager.Instance();
            resourceManager.SetupStructuredBuffer(4 * count, 4, ref Buffer.Value);

            var symbolChild = Parent.Symbol.Children.Single(c => c.Id == Id);
            Buffer.Value.DebugName = symbolChild.ReadableName;
            Log.Info($"{symbolChild.ReadableName} updated");
        }

        [Input(Guid = "1AF495E6-04F2-49B2-8A44-AE100CF405C4")]
        public readonly InputSlot<int> Count = new InputSlot<int>(1000);
    }
}