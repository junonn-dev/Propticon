using MonitoringProcess.CounterItem;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace MonitorigProcess.CounterItem
{
    public class ProcessPerformance : IEnumerable<Counter>
    {
        public int pid { get; set; }    
        public string processName { get; set; }     //chrome
        public string instanceName { get; set; }    //chrome#n
        public ProcessCpuCounter processorTimeCounter { get; }
        public Counter workingSetCounter { get; }
        public Counter handleCountCounter { get; }
        public Counter threadCountCounter { get; }
        public GdiCounter gdiCountCounter { get; }

        public ProcessPerformance(int pid, string processName, string instanceName)
        {
            this.pid = pid;
            this.processName = processName;
            this.instanceName = instanceName;
            processorTimeCounter = new ProcessCpuCounter("Process", "% Processor Time", processName);
            workingSetCounter = new Counter("Process", "Working Set - Private", processName);
            threadCountCounter = new Counter("Process", "Thread Count", processName);
            handleCountCounter = new Counter("Process", "Handle Count", processName);
            gdiCountCounter = new GdiCounter(pid, "GDI Object");
            
        }

        //성능 카운터 추가시 여기도 추가 필수
        public IEnumerator<Counter> GetEnumerator()
        {
            yield return processorTimeCounter;
            yield return workingSetCounter;
            yield return threadCountCounter;
            yield return handleCountCounter;
            yield return gdiCountCounter;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
