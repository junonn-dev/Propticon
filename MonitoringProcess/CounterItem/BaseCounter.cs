using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringProcess.CounterItem
{
    //Deprecated : Counter클래스로 통일하여 추상화 
    public abstract class BaseCounter
    {
        protected float minValue = float.MaxValue;
        protected float maxValue;
        protected double average;
        protected long recordCount;

        public abstract float GetNextValue();

        protected void CheckStatisticValue(float value)
        {
            //Average계산과 RecordCount 증가 순서 주의,
            //RcordCount 증가 전에 Average 계산 하도록 구현됨 
            average = (double)((average * recordCount + value)) / (recordCount + 1);

            recordCount++;

            if (value == 0)
            {
                return;
            }

            if (minValue > value)
            {
                minValue = value;
            }

            if (maxValue < value)
            {
                maxValue = value;
            }
        }
        public float GetMinValue()
        {
            return minValue;
        }
        public float GetMaxValue()
        {
            return maxValue;
        }
        public double GetAverage()
        {
            return average;
        }
    }
}
