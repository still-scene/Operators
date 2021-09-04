using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using SharpDX;
using T3.Core;
using T3.Core.DataTypes;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;
using Vector3 = System.Numerics.Vector3;
using Vector4 = System.Numerics.Vector4;

namespace T3.Operators.Types.Id_b9999f07_da19_45b9_ae12_f9d0662c694c
{
    public class __BlendGradients : Instance<__BlendGradients>
    {
        [Output(Guid = "D457933E-6642-471E-807A-6C22008BBD0C")]
        public readonly Slot<Gradient> Result = new Slot<Gradient>();

        public __BlendGradients()
        {
            Result.UpdateAction = Update;
        }

        private void Update(EvaluationContext context)
        {
            var blendMode = (BlendModes)BlendMode.GetValue(context);
            var gradientA = GradientA.GetValue(context);
            var gradientB = GradientB.GetValue(context);
            
            _steps.Clear();
            foreach (var stepA in gradientA.Steps)
            {
                var positionA = stepA.NormalizedPosition;
                var colorA = stepA.Color;
                var colorB = gradientB.Sample(positionA);
                var blendedColor = BlendColors(colorA, colorB, blendMode);
                _steps[positionA] = blendedColor;
            }

            foreach (var stepB in gradientB.Steps)
            {
                var positionB = stepB.NormalizedPosition;
                var colorB = stepB.Color;
                var colorA = gradientA.Sample(positionB);
                var blendedColor = BlendColors(colorA, colorB, blendMode);
                _steps[positionB] = blendedColor;
            }

            var positions = _steps.Keys.ToArray();
            var steps = new List<Gradient.Step>(positions.Length);
            Array.Sort(positions);

            foreach (var p in positions)
            {
                steps.Add( new Gradient.Step()
                               {
                                   Color = _steps[p],
                                   Id = new Guid(),
                                   NormalizedPosition = p,
                               });
            }

            var result = new Gradient()
                             {
                                 Steps =  steps,
                                 Interpolation = Gradient.Interpolations.Linear,
                             };
            
            Result.Value = result;
        }

        private Vector4 BlendColors(Vector4 a, Vector4 b, BlendModes blendMode)
        {
            switch (blendMode)
            {
                case BlendModes.Normal:
                    break;
                
                case BlendModes.Multiply:
                {
                    var r = a * b;
                    r.W = MathUtils.Clamp( r.W, 0, 1);
                    return r;
                }

                case BlendModes.Screen:
                {
                    // var r = a + b;
                    // r.W = MathUtils.Clamp(0, 1, r.W);
                    // return r;
                    break;
                }

                case BlendModes.Add:
                {
                    var r = a + b;
                    r.W = MathUtils.Clamp(r.W, 0, 1);
                    return r;
                }
                    
                
                case BlendModes.Color:
                    
                    break;
                case BlendModes.Mix:
                    return Vector4.Lerp(a, b, 0.5f);
            }
            
            return Vector4.One;
        }
        
        private Dictionary<float, Vector4> _steps = new Dictionary<float, Vector4>(20);

        private enum BlendModes
        {
            Normal,
            Multiply,
            Screen,
            Add,
            Color,
            Mix,
        }
        
        
        [Input(Guid = "AFA38628-B616-4B06-878D-EC554050F2B0")]
        public readonly InputSlot<Gradient> GradientA = new InputSlot<Gradient>();
        
        [Input(Guid = "C1856EF1-BCBE-4377-A910-E8EEF7D963DA")]
        public readonly InputSlot<Gradient> GradientB = new InputSlot<Gradient>();
        
        [Input(Guid = "EDABC753-2CCA-4F8D-8F14-2B25479C2188", MappedType = typeof(BlendModes))]
        public readonly InputSlot<int> BlendMode = new MultiInputSlot<int>();
        
        
    }
    
    
}