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
        public WorstList worstList { get; set; }

        public ProcessCPUCounter(string processName)
        {
            performanceCounter = new PerformanceCounter("Process", "% Processor Time", processName);
            worstList = new WorstList();
        }

    }
}
