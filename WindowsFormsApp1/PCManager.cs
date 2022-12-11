using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CounterItem;

namespace WindowsFormsApp1
{
    class PCManager
    {
        private static Dictionary<string, ProcessCPUCounter> mapProcessProcessorTime;
        private static Dictionary<string, ProcessWorkingSetCounter> mapProcessWrokingSet;
        private static Dictionary<string, ProcessThreadCountCounter> mapProcessThreadCount;
        private static Dictionary<string, ProcessHandleCountCounter> mapProcessHandleCount;

        /// <summary>
        /// 내부 필드 초기화만 함, PCManager 생성 후 InitProcessMonitor 호출하여 프로세스 지정해야 함
        /// </summary>
        public PCManager()
        {
            mapProcessProcessorTime = new Dictionary<string, ProcessCPUCounter>();
            mapProcessWrokingSet = new Dictionary<string, ProcessWorkingSetCounter>();
            mapProcessThreadCount = new Dictionary<string, ProcessThreadCountCounter>();
            mapProcessHandleCount = new Dictionary<string, ProcessHandleCountCounter>();
        }

        /// <summary>
        /// PCManager 초기화 시 프로세스 지정도 같이 함.
        /// </summary>
        /// <param name="processNames"></param>
        public PCManager(IEnumerable<string> processNames) : this()
        {
            InitProcessMonitor(processNames);
        }

        public PCManager(IEnumerable<Process> processNames) : this()
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
                mapProcessProcessorTime.Add(processName, new ProcessCPUCounter(processName));
                mapProcessWrokingSet.Add(processName, new ProcessWorkingSetCounter(processName));
                mapProcessThreadCount.Add(processName, new ProcessThreadCountCounter(processName));
                mapProcessHandleCount.Add(processName, new ProcessHandleCountCounter(processName));
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
                mapProcessProcessorTime.Add(procName, new ProcessCPUCounter(procName));
                mapProcessWrokingSet.Add(procName, new ProcessWorkingSetCounter(procName));
                mapProcessThreadCount.Add(procName, new ProcessThreadCountCounter(procName));
                mapProcessHandleCount.Add(procName, new ProcessHandleCountCounter(procName));
            }
        }

        public float GetProcessCPUUsage(string processName)
        {
            if(mapProcessProcessorTime.ContainsKey(processName) is false)
            {
                return -1f;
            }
            return mapProcessProcessorTime[processName].GetNextValue();
        }

        public float GetProcessMemoryUsage(string processName)
        {
            if (mapProcessWrokingSet.ContainsKey(processName) is false)
            {
                return -1f;
            }
            return mapProcessWrokingSet[processName].GetNextValue();
        }

        public int GetProcessThreadCount(string processName)
        {
            if (mapProcessThreadCount.ContainsKey(processName) is false)
            {
                return -1;
            }
            return (int)mapProcessThreadCount[processName].GetNextValue();
        }

        public int GetProcessHandleCount(string processName)
        {
            if (mapProcessHandleCount.ContainsKey(processName) is false)
            {
                return -1;
            }
            return (int)mapProcessHandleCount[processName].GetNextValue();
        }

    }
}
