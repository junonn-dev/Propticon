using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CounterItem
{
    class ProcessCPUCounter : Counter
    {
        public float minValue { get; set; }
        public float maxValue { get; set; }
        public float average { get; set; }
        public int MyProperty { get; set; }
        public ProcessCPUCounter(string processName)
        {
            performanceCounter = new PerformanceCounter("Process", "% Processor Time", processName);
        }
    }
}
