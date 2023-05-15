using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringProcess.Config
{
    public static class WarnLimitConfig
    {
        public static float TotalCpuUsageLimit { get; set; }
        public static float TotalMemoryUsageLimit { get; set; }
        public static float DiskSpaceLimit { get; set; }
        public static float ProcessCpuLimit { get; set; }
        public static float ProcessMemoryLimit { get; set; }
        public static int ProcessThreadLimit { get; set; }
        public static int ProcessHandleLimit { get; set; }
        public static int ProcessGDILimit { get; set; }
    }
}
