using MonitorigProcess.Config;
using System;
using System.Diagnostics;

namespace MonitorigProcess.CounterItem
{
    public class ProcessCpuCounter : Counter
    {
        public ProcessCpuCounter(string category, string counter, string instance = "", bool recordWorstAscd = false) : base(category, counter, instance, recordWorstAscd)
        {
        }

        /// <summary>
        /// Counter 측정 값을 얻어서 통계값을 계산한 후 측정값을 반환
        /// </summary>
        /// <returns></returns>
        public override float GetNextValue()
        {
            float value = -2f;
            try
            {
                value = performanceCounter.NextValue()/Environment.ProcessorCount;
            }
            catch
            {
                //monitoring 중간 프로세스 종료되면 -2 return
                return value;
            }
            CheckStatisticValue(value);
            return value;
        }
    }
}
