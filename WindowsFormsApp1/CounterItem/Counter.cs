using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CounterItem
{
    abstract class Counter
    {
        public float minValue { get; set; }
        public float maxValue { get; set; }
        public double average { get; set; }
        public long recordCount { get; set; }

        protected PerformanceCounter performanceCounter;

        protected Counter()
        {
            minValue = float.MaxValue;
            maxValue = float.MinValue;
        }

        public virtual float GetNextValue()
        {
            float value = performanceCounter.NextValue();
            CheckStatisticValue(value);
            return value;
        }

        private void CheckStatisticValue(float value)
        {
            //Average계산과 RecordCount 증가 순서 주의,
            //RcordCount 증가 전에 Average 계산 하도록 구현됨 
            average = average * ((double)recordCount / recordCount + 1) + (double)value / recordCount + 1;
            recordCount++;

            if (minValue > value)
            {
                minValue = value;
            }

            else if (maxValue < value)
            {
                maxValue = value;
            }
        }

    }
}
