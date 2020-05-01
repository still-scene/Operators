using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using SharpDX;
using T3.Core;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;
using Buffer = SharpDX.Direct3D11.Buffer;

namespace T3.Operators.Types.Id_491d5fc3_75f4_4ddd_854b_cd1769166fa6
{
    public class SpherePointCloud : Instance<SpherePointCloud>
    {
        [Output(Guid = "059737a1-09ce-42d0-a16a-e5d95cd0c8e1")]
        public readonly Slot<SharpDX.Direct3D11.ShaderResourceView> PointCloudSrv = new Slot<SharpDX.Direct3D11.ShaderResourceView>();

        [Output(Guid = "8c6b023f-6e09-48ae-b6b9-7e04b5032be3")]
        public readonly Slot<int> EmitterId = new Slot<int>();

        private static int IdCount = 0;
        
        public SpherePointCloud()
        {
            _id = ++IdCount;
            EmitterId.Value = _id;
            PointCloudSrv.UpdateAction = Update;
        }

        [StructLayout(LayoutKind.Explicit, Size = 32)]
        struct BufferEntry
        {
            [FieldOffset(0)]
            public SharpDX.Vector3 Pos;
            [FieldOffset(12)]
            public int Id;
            [FieldOffset(16)]
            public SharpDX.Vector4 Color;
        }

        private Buffer _buffer;
        private int _id;

        private void Update(EvaluationContext context)
        {
            var resourceManager = ResourceManager.Instance();

            var numEntries = Count.GetValue(context);
            numEntries = Math.Max(numEntries, 1);
            numEntries = Math.Min(numEntries, 500000);

            var bufferData = new BufferEntry[numEntries];

            var color = Color.GetValue(context);
            var random = new Random(Seed.GetValue(context));
            var radius = Radius.GetValue(context);
            for (int index = 0; index < numEntries; index++)
            {
                var v = new Vector3(random.NextFloat(-1, 1), random.NextFloat(-1, 1), random.NextFloat(-1, 1));
                v.Normalize();
                // v *= radius;
                v *= random.NextFloat(0.0f, radius);
                bufferData[index].Pos = v;
                bufferData[index].Id = _id;
                bufferData[index].Color = new Vector4(color.X, color.Y, color.Z, color.W);
            }
            
            var stride = 32;
            resourceManager.SetupStructuredBuffer(bufferData, stride * numEntries, stride, ref _buffer);
            resourceManager.CreateStructuredBufferSrv(_buffer, ref PointCloudSrv.Value);
        }
        
        [Input(Guid = "AD7F8575-A978-4A09-89F8-CF6F6EE8808C")]
        public readonly InputSlot<int> Count = new InputSlot<int>();

        [Input(Guid = "57543B8C-4AD6-4B0F-B270-7A81AD8908D9")]
        public readonly InputSlot<System.Numerics.Vector4> Color = new InputSlot<System.Numerics.Vector4>();
        
        [Input(Guid = "E5F8D8C8-4E22-4489-859D-7DED280ECE9F")]
        public readonly InputSlot<float> Radius = new InputSlot<float>();
        
        [Input(Guid = "99924178-BC02-470B-9750-2E0AC9B702B5")]
        public readonly InputSlot<int> Seed = new InputSlot<int>();
    }
}