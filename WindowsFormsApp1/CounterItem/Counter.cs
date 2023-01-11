﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CounterItem
{
    public class Counter
    {
        private float minValue;
        private float maxValue;
        private double average;
        private long recordCount;
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
        private void CheckStatisticValue(float value)
        {
            //Average계산과 RecordCount 증가 순서 주의,
            //RcordCount 증가 전에 Average 계산 하도록 구현됨 
            average = (double)((average * recordCount + value)) / (recordCount + 1); 
            
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