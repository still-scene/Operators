using System.Collections.Generic;
using System.Runtime.InteropServices;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_6b8db50a_383c_486c_8065_3aefe8c85576
{
    public class _BoidDefinition : Instance<_BoidDefinition>
    {
        [Output(Guid = "bdab6d26-afc1-4432-8069-5dcf1567eeba")]
        public readonly Slot<StructuredList> OutBuffer = new Slot<StructuredList>();

        public _BoidDefinition()
        {
            OutBuffer.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            _boids.TypedElements[0].CohesionRadius = CohesionRadius.GetValue(context);
            _boids.TypedElements[0].CohesionDrive = CohesionDrive.GetValue(context);
            _boids.TypedElements[0].AlignmentRadius = AlignmentRadius.GetValue(context);
            _boids.TypedElements[0].AlignmentDrive = AlignmentDrive.GetValue(context);
            _boids.TypedElements[0].SeparationRadius = SeparationRadius.GetValue(context);
            _boids.TypedElements[0].SeparationDrive = SeparationDrive.GetValue(context);
            _boids.TypedElements[0].MaxSpeed = MaxSpeed.GetValue(context);
            OutBuffer.Value = _boids;
        }

        [StructLayout(LayoutKind.Explicit, Size = 8 * 4)]
        public struct Boid
        {
            [FieldOffset(0 * 4)]
            public float CohesionRadius;

            [FieldOffset(1 * 4)]
            public float CohesionDrive;

            [FieldOffset(2 * 4)]
            public float AlignmentRadius;

            [FieldOffset(3 * 4)]
            public float AlignmentDrive;

            [FieldOffset(4 * 4)]
            public float SeparationRadius;

            [FieldOffset(5 * 4)]
            public float SeparationDrive;

            [FieldOffset(6 * 4)]
            public float MaxSpeed;

            [FieldOffset(7 * 4)]
            public float TestString;
        }

        private readonly StructuredList<Boid> _boids = new StructuredList<Boid>(10);

        [Input(Guid = "BB9A7B9E-05F2-4383-B8EB-C73F21125EA3")]
        public readonly InputSlot<float> CohesionRadius = new InputSlot<float>();

        [Input(Guid = "44836F44-717A-4BB7-B115-15270DA62E1C")]
        public readonly InputSlot<float> CohesionDrive = new InputSlot<float>();

        [Input(Guid = "D33DE75A-02AE-4FC3-99A7-B28227ACB531")]
        public readonly InputSlot<float> AlignmentRadius = new InputSlot<float>();

        [Input(Guid = "43C6242B-8393-4E99-9B6A-97CE22D59E3D")]
        public readonly InputSlot<float> AlignmentDrive = new InputSlot<float>();

        [Input(Guid = "D894DD3D-7151-47D2-B665-D60318FE096D")]
        public readonly InputSlot<float> SeparationRadius = new InputSlot<float>();

        [Input(Guid = "CBB63479-1A21-4427-9441-2E1DC73D3F3C")]
        public readonly InputSlot<float> SeparationDrive = new InputSlot<float>();
        
        [Input(Guid = "0EF87235-EA06-406A-B291-5808BD947D8C")]
        public readonly InputSlot<float> MaxSpeed = new InputSlot<float>();
    }
}