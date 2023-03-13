using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CounterItem
{
    class ProcessThreadCountCounter : Counter
    {
        public ProcessThreadCountCounter(string processName)
        {
            performanceCounter = new PerformanceCounter("Process", "Thread Count", processName);
        }
    }
}
