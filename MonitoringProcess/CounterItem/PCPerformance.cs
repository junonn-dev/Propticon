using MonitorigProcess.CounterItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringProcess.CounterItem
{
    public class PCPerformance
    {
        public Counter FreeDiskSpace { get; }

        public PCPerformance(string diskName)
        {
            FreeDiskSpace = new Counter("LogicalDisk", "% Free Space", diskName);
        }
    }
}
