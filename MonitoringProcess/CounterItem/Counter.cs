using MonitorigProcess.Config;
using System;
using System.Diagnostics;

namespace MonitorigProcess.CounterItem
{
    public class Counter
    {
        private float minValue;
        private float maxValue;
        private double average;
        private long recordCount;
        public WorstList worstList { get; private set; }
        public string CounterName { get; private set; }
        private bool isFirstCheck;

        protected PerformanceCounter performanceCounter;

        /// <summary>
        /// GetNextValue 직접 Override하여 측정할 경우 생성 
        /// </summary>
        /// <param name="pid">상속받은 객체 내에서 프로세스 정보를 알 기 위해 입력</param>
        /// <param name="counterName"></param>
        /// <param name="recordWorstAscd"></param>
        protected Counter(int pid, string counterName, bool recordWorstAscd = false)
        {
            worstList = new WorstList(recordWorstAscd);
            minValue = float.MaxValue;
            maxValue = 0;
            CounterName = counterName;
            isFirstCheck = true;
        } 

        /// <summary>
        /// Windows Performance Counter 전용 카운터
        /// </summary>
        /// <param name="category"></param>
        /// <param name="counter"></param>
        /// <param name="instance"></param>
        /// <param name="recordWorstAscd"></param>
        public Counter(string category, string counter, string instance = "", bool recordWorstAscd = false)
        {
            worstList = new WorstList(recordWorstAscd);
            minValue = float.MaxValue;
            maxValue = 0;
            CounterName = counter;
            isFirstCheck = true;
            try
            {
                if (string.IsNullOrEmpty(instance))
                {
                    performanceCounter = new PerformanceCounter(category, counter);
                }
                else
                {
                    performanceCounter = new PerformanceCounter(category, counter, instance);
                }
            }
            catch
            {
                performanceCounter = new PerformanceCounter();
            }
        }

        /// <summary>
        /// Counter 측정 값을 얻어서 통계값을 계산한 후 측정값을 반환
        /// </summary>
        /// <returns></returns>
        public virtual float GetNextValue()
        {
            float value = -2f;
            try
            {
                value = performanceCounter.NextValue();
            }
            catch
            {
                //monitoring 중간 프로세스 종료되면 -2 return
                return value;
            }
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
        protected void CheckStatisticValue(float value)
        {
            if(isFirstCheck && value == 0)
            {
                isFirstCheck = false;
                return;
            }
            isFirstCheck = false;
            //Average계산과 RecordCount 증가 순서 주의,
            //RcordCount 증가 전에 Average 계산 하도록 구현됨 
            average = (double)((average * recordCount + value)) / (recordCount + 1); 
            
            recordCount++;

            if(value == 0)
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
