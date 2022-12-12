using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CounterItem
{
    class Counter
    {
        public float minValue { get; set; }
        public float maxValue { get; set; }
        public double average { get; set; }
        public long recordCount { get; set; }
        public WorstList worstList { get; set; }

        private PerformanceCounter performanceCounter;

        public Counter(string category, string counter, string instance)
        {
            performanceCounter = new PerformanceCounter(category, counter, instance);
            worstList = new WorstList();
            minValue = float.MaxValue;
            maxValue = float.MinValue;
        }

        /// <summary>
        /// Counter 측정 값을 얻어서 통계값을 계산한 후 측정값을 반환
        /// </summary>
        /// <returns></returns>
        public float GetNextValue()
        {
            float value = performanceCounter.NextValue();
            CheckStatisticValue(value);
            return value;
        }

        /// <summary>
        /// Counter 측정 값을 얻어서 통계값을 계산하고, 입력된 시간에 대해 worst 기록을 함
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public float GetNextValue(DateTime timeStamp)
        {
            var value = GetNextValue();
            worstList.CheckRecord(value, timeStamp);
            return value;
        }

        /// <summary>
        /// 평균과 최솟값과 최댓값을 업데이트함
        /// </summary>
        /// <param name="value"></param>
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
