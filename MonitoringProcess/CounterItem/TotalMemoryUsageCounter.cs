using MonitorigProcess.CounterItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringProcess.CounterItem
{
    public class TotalMemoryUsageCounter : Counter
    {
        //RAM 크기 가져오는 함수, 8GB, 16GB....
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);

        private long totalPhysicalMemoryMB;

        public TotalMemoryUsageCounter(string category, string counter, string instance = "", bool recordWorstAscd = false) : base(category, counter, instance, recordWorstAscd)
        {
            long ramSizeKB = 0;
            GetPhysicallyInstalledSystemMemory(out ramSizeKB);
            totalPhysicalMemoryMB = ramSizeKB / 1024;
        }

        public override float GetNextValue()
        {
            float value = -2f;
            try
            {
                //TotalMemoryUsageCounter의 performanceCounter는 Available MBytes로 값을 가져온다.
                //전체 메모리 - Available MBytes로 계산한 값을 반환
                value = totalPhysicalMemoryMB - performanceCounter.NextValue();
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
