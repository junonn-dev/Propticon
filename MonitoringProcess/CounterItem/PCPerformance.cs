using MonitorigProcess.Config;
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
        public List<Counter> FreeDiskSpaceCounters { get; private set; }
        public Counter TotalCpuUsage { get; }
        public Counter AvailableMemoryMBytes { get; }

        public PCPerformance()
        {
            FreeDiskSpaceCounters = new List<Counter>();
            //PC의 disk를 가져와서 각 Disk이름에 해당하는 PCPerformance를 초기화 (ex. C:, D:)
            IEnumerable<string> disks = AppConfiguration.diskNames;
            foreach (var item in disks)
            {
                FreeDiskSpaceCounters.Add(new Counter("LogicalDisk", "% Free Space", item));
            }

            TotalCpuUsage = new Counter("Processor", "% Processor Time", "_Total");
            AvailableMemoryMBytes = new Counter("Memory", "Available MBytes", 
                recordWorstAscd: true);
        }
    }
}
