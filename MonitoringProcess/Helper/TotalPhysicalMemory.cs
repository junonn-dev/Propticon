using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringProcess.Helper
{
    public static class TotalPhysicalMemory
    {
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);

        public static long GetMBValue()
        {
            long memKB = 0;
            GetPhysicallyInstalledSystemMemory(out memKB);

            return memKB / 1024;
        }
    }
}
