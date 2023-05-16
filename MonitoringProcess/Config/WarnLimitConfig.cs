using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringProcess.Config
{
    public static class WarnLimitConfig
    {
        public static float TotalCpuUsageLimit = 20;
        public static float TotalMemoryUsageLimit = 50;
        public static float DiskSpaceLimit = 90;
        public static float ProcessCpuLimit = 40;
        public static float ProcessMemoryLimit = 4000;
        public static int ProcessThreadLimit = 1000;
        public static int ProcessHandleLimit = 1000;
        public static int ProcessGdiLimit = 50000;
    }
}
