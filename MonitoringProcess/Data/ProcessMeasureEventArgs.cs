using System;
using MonitorigProcess.CounterItem;
using MonitoringProcess.CounterItem;

namespace MonitorigProcess.Data
{
    public class ProcessMeasureEventArgs : EventArgs
    {
        public string message { get; set; }

        public ProcessPerformance processSet { get; set; }

        public ProcessMeasureEventArgs(string message, ProcessPerformance processSet)
        {
            this.message = message;
            this.processSet = processSet;
        }


    }
}
