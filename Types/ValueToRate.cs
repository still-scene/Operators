using System;
using System.Globalization;
using T3.Core;
using T3.Core.Logging;
using T3.Core.Operator;
using T3.Core.Operator.Attributes;
using T3.Core.Operator.Slots;

namespace T3.Operators.Types.Id_8171c2f5_96df_41f6_884c_dbd004ae8a17
{
    public class ValueToRate : Instance<ValueToRate>
    {
        [Output(Guid = "c21800d0-ee83-43f6-8f1c-9cee2e495056")]
        public readonly Slot<float> Result = new Slot<float>();

        public ValueToRate()
        {
            Result.UpdateAction = Update;
        }

        /**
         * 0   1/3  2/3   3/3
         * |----|----|----|
         */
        private void Update(EvaluationContext context)
        {
            var v = Value.GetValue(context);

            var rates = Rates.GetValue(context);
            if (string.IsNullOrEmpty(rates))
                return;

            var lines = rates.Split('\n');
            var stepCount = lines.Length;
            //var index = (int)((v - 1f / stepCount) * stepCount);
            var index = (int)((stepCount*v).Clamp(0,stepCount));
            if (index < 0 || index >= stepCount)
                return;

            var str = lines[index];
            float result = 0;
            try
            {
                result = float.Parse(str, CultureInfo.InvariantCulture.NumberFormat);
            }
            catch (Exception e)
            {
                Log.Warning("Failed to convert number:" + e.Message);
            }

            Result.Value = result;
        }

        [Input(Guid = "4f2dad75-0f45-498a-9a1a-7571dc9f0b09")]
        public readonly InputSlot<float> Value = new InputSlot<float>();

        [Input(Guid = "1AD90698-0D84-488B-B969-4D727E173AFF")]
        public readonly InputSlot<string> Rates = new InputSlot<string>();
    }
}