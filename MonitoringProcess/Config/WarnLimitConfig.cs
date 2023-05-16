using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringProcess.Config
{
    public static class WarnLimitConfig
    {
        public static bool WarnDetectionMode = false;
        public static int TotalCpuUsageLimit = 90;
        public static int TotalMemoryUsageLimit = 90;
        public static int DiskSpaceLimit = 90;
        public static int ProcessCpuLimit = 90;
        public static int ProcessMemoryLimit = 10000;
        public static int ProcessThreadLimit = 10000;
        public static int ProcessHandleLimit = 10000;
        public static int ProcessGdiLimit = 50000;
    }
}
