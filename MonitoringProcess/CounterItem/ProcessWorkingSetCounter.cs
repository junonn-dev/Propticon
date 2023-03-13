using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CounterItem
{
    class ProcessWorkingSetCounter : Counter
    {
        public WorstList worstList { get; set; }

        public ProcessWorkingSetCounter(string processName)
        {
            performanceCounter = new PerformanceCounter("Process", "Working Set - Private", processName);
            worstList = new WorstList();
        }
    }
}
