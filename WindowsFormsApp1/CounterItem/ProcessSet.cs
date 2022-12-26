using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CounterItem
{
    public class ProcessSet
    {
        public Counter processorTimeCounter { get; }
        public Counter workingSetCounter { get; }
        public Counter handleCountCounter { get; }
        public Counter threadCountCounter { get; }

        public ProcessSet(string processName)
        {
            processorTimeCounter = new Counter("Process", "% Processor Time", processName);
            workingSetCounter = new Counter("Process", "Working Set - Private", processName);
            threadCountCounter = new Counter("Process", "Thread Count", processName);
            handleCountCounter = new Counter("Process", "Handle Count", processName);
        }
    }
}
