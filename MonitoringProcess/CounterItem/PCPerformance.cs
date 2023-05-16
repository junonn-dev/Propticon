using MonitorigProcess.Config;
using MonitorigProcess.CounterItem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringProcess.CounterItem
{
    public class PCPerformance : IEnumerable<Counter>
    {
        public List<Counter> FreeDiskSpaceCounters { get; private set; }
        public Counter TotalCpuUsage { get; }
        public TotalMemoryUsageCounter MemoryUsageMB { get; }

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
            MemoryUsageMB = new TotalMemoryUsageCounter("Memory", "Available MBytes");
        }

        public IEnumerator<Counter> GetEnumerator()
        {
            foreach (Counter item in FreeDiskSpaceCounters)
            {
                yield return item;
            }
            yield return TotalCpuUsage;
            yield return MemoryUsageMB;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
