using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringProcess.Data
{
    public class PCMeasureEventArgs : EventArgs
    {
        public List<float> FreeDiskSpaceValues { get; set; }

        public PCMeasureEventArgs(List<float> freeDiskSpaceValues)
        {
            FreeDiskSpaceValues = freeDiskSpaceValues;
        }
    }
}
