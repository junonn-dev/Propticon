using MonitoringProcess.CounterItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringProcess.Data
{
    public class PCMeasureEventArgs : EventArgs
    {
        public string Message { get; set; }
        public List<float> FreeDiskSpaceValues { get; set; }
        public PCPerformance PcPerformanceSet { get; set; }

        public PCMeasureEventArgs(string message, List<float> freeDiskSpaceValues, PCPerformance pCPerformance)
        {
            this.Message = message;
            FreeDiskSpaceValues = freeDiskSpaceValues;
            this.PcPerformanceSet = pCPerformance;
        }
    }
}
