using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Data
{
    public class OverviewDto
    {
        public string reportFileName { get; set; }
        public string totalTime { get; set; }
        public string startTime { get; set; }
        public string stopTime { get; set; }
        public string processCount { get; set; }

        public string mostCpuUsedProcess { get; set; }
        public string mostMemoryUsedProcess { get; set; }

    }
}
