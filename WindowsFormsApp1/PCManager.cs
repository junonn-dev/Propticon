using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class PCManager
    {
        private PerformanceCounter pcMemoryAvailableBytes;
        private PerformanceCounter pcCPUProcessorTime;
        private static Dictionary<string, PerformanceCounter> mapProcessProcessorTime;
        private static Dictionary<string, PerformanceCounter> mapProcessWrokingSet;
        private static Dictionary<string, PerformanceCounter> mapProcessThreadCount;
        private static Dictionary<string, PerformanceCounter> mapProcessHandleCount;


        /// <summary>
        /// 내부 필드 초기화만 함, PCManager 생성 후 InitProcessMonitor 호출하여 프로세스 지정해야 함
        /// </summary>
        public PCManager()
        {
            pcMemoryAvailableBytes = new PerformanceCounter("Memory", "Available MBytes");
            pcCPUProcessorTime = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            mapProcessProcessorTime = new Dictionary<string, PerformanceCounter>();
            mapProcessWrokingSet = new Dictionary<string, PerformanceCounter>();
            mapProcessThreadCount = new Dictionary<string, PerformanceCounter>();
            mapProcessHandleCount = new Dictionary<string, PerformanceCounter>();
        }

        /// <summary>
        /// PCManager 초기화 시 프로세스 지정도 같이 함.
        /// </summary>
        /// <param name="processNames"></param>
        public PCManager(IEnumerable<string> processNames) : this()
        {
            InitProcessMonitor(processNames);
        }

        public void InitProcessMonitor(IEnumerable<string> processNames)
        {
            mapProcessProcessorTime.Clear();
            mapProcessWrokingSet.Clear();
            mapProcessThreadCount.Clear();
            mapProcessHandleCount.Clear();

            foreach (string processName in processNames)
            {
                if (string.IsNullOrEmpty(processName))
                {
                    continue;
                }
                mapProcessProcessorTime.Add(processName, new PerformanceCounter("Process", "% Processor Time", processName));
                mapProcessWrokingSet.Add(processName, new PerformanceCounter("Process", "Working Set - Private", processName));
                mapProcessThreadCount.Add(processName, new PerformanceCounter("Process", "Thread Count", processName));
                mapProcessHandleCount.Add(processName, new PerformanceCounter("Process", "Handle Count", processName));
            }
        }

        public void InitProcessMonitor(IEnumerable<Process> processes)
        {
            mapProcessProcessorTime.Clear();
            mapProcessWrokingSet.Clear();
            mapProcessThreadCount.Clear();
            mapProcessHandleCount.Clear();

            foreach (Process process in processes)
            {
                if (process is null)
                {
                    continue;
                }
                string procName = process.ProcessName;
                mapProcessProcessorTime.Add(procName, new PerformanceCounter("Process", "% Processor Time", procName));
                mapProcessWrokingSet.Add(procName, new PerformanceCounter("Process", "Working Set - Private", procName));
                mapProcessThreadCount.Add(procName, new PerformanceCounter("Process", "Thread Count", procName));
                mapProcessHandleCount.Add(procName, new PerformanceCounter("Process", "Handle Count", procName));
            }
        }

        public float GetProcessCPUUsage(string processName)
        {
            if(mapProcessProcessorTime.ContainsKey(processName) is false)
            {
                return -1f;
            }
            PerformanceCounter pc = mapProcessProcessorTime[processName];
            return pc.NextValue();
        }

        public float GetProcessMemoryUsage(string processName)
        {
            if (mapProcessWrokingSet.ContainsKey(processName) is false)
            {
                return -1f;
            }
            PerformanceCounter pc = mapProcessWrokingSet[processName];
            return pc.NextValue();
        }

        public int GetProcessThreadCount(string processName)
        {
            if (mapProcessThreadCount.ContainsKey(processName) is false)
            {
                return -1;
            }
            PerformanceCounter pc = mapProcessThreadCount[processName];
            return (int)pc.NextValue();
        }

        public int GetProcessHandleCount(string processName)
        {
            if (mapProcessHandleCount.ContainsKey(processName) is false)
            {
                return -1;
            }
            PerformanceCounter pc = mapProcessHandleCount[processName];
            return (int)pc.NextValue();
        }

        public float GetMemoryAvailableBytes()
        {
            return pcMemoryAvailableBytes.NextValue();
        }

        public float GetCPUProcessorTime()
        {
            return pcCPUProcessorTime.NextValue();
        }
    }
}
