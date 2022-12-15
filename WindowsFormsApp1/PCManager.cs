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
        private Dictionary<string, Counter> mapProcessProcessorTime;
        private Dictionary<string, Counter> mapProcessWrokingSet;
        private Dictionary<string, Counter> mapProcessThreadCount;
        private Dictionary<string, Counter> mapProcessHandleCount;

        /// <summary>
        /// 내부 필드 초기화만 함, PCManager 생성 후 InitProcessMonitor 호출하여 프로세스 지정해야 함
        /// </summary>
        public PCManager()
        {
            mapProcessProcessorTime = new Dictionary<string, Counter>();
            mapProcessWrokingSet = new Dictionary<string, Counter>();
            mapProcessThreadCount = new Dictionary<string, Counter>();
            mapProcessHandleCount = new Dictionary<string, Counter>();
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
                mapProcessProcessorTime.Add(processName, new Counter("Process", "% Processor Time", processName));
                mapProcessWrokingSet.Add(processName, new Counter("Process", "Working Set - Private", processName));
                mapProcessThreadCount.Add(processName, new Counter("Process", "Thread Count", processName));
                mapProcessHandleCount.Add(processName, new Counter("Process", "Handle Count", processName));
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
                mapProcessProcessorTime.Add(procName, new Counter("Process", "% Processor Time", procName));
                mapProcessWrokingSet.Add(procName, new Counter("Process", "Working Set - Private", procName));
                mapProcessThreadCount.Add(procName, new Counter("Process", "Thread Count", procName));
                mapProcessHandleCount.Add(procName, new Counter("Process", "Handle Count", procName));
            }
        }

        // pid로부터 instance 이름 얻기
        //https://stackoverflow.com/questions/9115436/performance-counter-by-process-id-instead-of-name
        public string GetProcessInstanceName(int pid, string processName)
        {
            PerformanceCounterCategory cat = new PerformanceCounterCategory("Process");

            IEnumerable<string> instances = cat.GetInstanceNames().Where(str => str.Contains(processName));
            foreach (string instance in instances)
            {

                using (PerformanceCounter cnt = new PerformanceCounter("Process", "ID Process", instance, true))
                {
                    int val = (int)cnt.RawValue;
                    if (val == pid)
                    {
                        return instance;
                    }
                }
            }
            throw new Exception("Could not find performance counter");
        }

        public float GetProcessCPUUsage(string processName, DateTime timeStamp)
        {
            if(mapProcessProcessorTime.ContainsKey(processName) is false)
            {
                return -1f;
            }
            return mapProcessProcessorTime[processName].GetNextValue(timeStamp);
        }

        public float GetProcessMemoryUsage(string processName, DateTime timeStamp)
        {
            if (mapProcessWrokingSet.ContainsKey(processName) is false)
            {
                return -1f;
            }
            return mapProcessWrokingSet[processName].GetNextValue(timeStamp);
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

        public WorstList GetProcessCPUWorst(string processName)
        {
            return mapProcessProcessorTime[processName].worstList;
        }

        public WorstList GetProcessMemoryWorst(string processName)
        {
            return mapProcessWrokingSet[processName].worstList;
        }

        
    }
}
