using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CounterItem;
using WindowsFormsApp1.Helper;

namespace WindowsFormsApp1
{
    public class PCManager
    {
        private Dictionary<int, ProcessSet> mapProcessSet;

        /// <summary>
        /// 내부 필드 초기화만 함, PCManager 생성 후 InitProcessMonitor 호출하여 프로세스 지정해야 함
        /// </summary>
        public PCManager()
        {
            mapProcessSet = new Dictionary<int, ProcessSet>();
        }

        /// <summary>
        /// PCManager 초기화 시 프로세스 지정도 같이 함.
        /// </summary>
        /// <param name="processNames"></param>
        public PCManager(IEnumerable<Process> processNames) : this()
        {
            InitProcessMonitor(processNames);
        }

        public void InitProcessMonitor(IEnumerable<Process> processes)
        {
            foreach (Process process in processes)
            {            
                if (process is null)
                {
                    continue;
                }

                string instanceName = "";
                try
                {
                    instanceName = InstanceNameConvertor.GetProcessInstanceName(process.Id, process.ProcessName);
                }
                catch
                {
                    continue;
                }

                if (!mapProcessSet.ContainsKey(process.Id))
                {
                    mapProcessSet.Add(process.Id, 
                        new ProcessSet(process.Id, process.ProcessName, instanceName));
                }
            }

            //monitor start/stop 번복 시 map 정보가 바뀜
            //processes에 기존에 있던 process가 삭제되어 들어오면
            //그 process의 processSet은 map에 계속 남아있게됨.
            //아래 코드는 선택된 process가 아닌 것을 제거하는 시도(미완성, 230102) 
            //아래를 주석처리하면 한 번 측정된 프로세스 정보는 프로그램 종료 전까지 map 메모리에 남음.
            //foreach (KeyValuePair<string, ProcessSet> processSet in mapProcessSet)
            //{
            //    if (!processIds.Contains(processSet.Key))
            //    {
            //        mapProcessSet.Remove(processSet.Key);
            //    }
            //}
        }

        public float GetProcessCPUUsage(Process process, DateTime timeStamp)
        {
            if(mapProcessSet.ContainsKey(process.Id) is false)
            {
                return -1f;
            }
            return mapProcessSet[process.Id].processorTimeCounter.GetNextValue(timeStamp);
        }

        public float GetProcessMemoryUsage(Process process, DateTime timeStamp)
        {
            if (mapProcessSet.ContainsKey(process.Id) is false)
            {
                return -1f;
            }
            return mapProcessSet[process.Id].workingSetCounter.GetNextValue(timeStamp);
        }

        public int GetProcessThreadCount(Process process)
        {
            if (mapProcessSet.ContainsKey(process.Id) is false)
            {
                return -1;
            }
            return (int)mapProcessSet[process.Id].threadCountCounter.GetNextValue();
        }

        public int GetProcessHandleCount(Process process)
        {
            if (mapProcessSet.ContainsKey(process.Id) is false)
            {
                return -1;
            }
            return (int)mapProcessSet[process.Id].handleCountCounter.GetNextValue();
        }

        //public WorstList GetProcessCPUWorst(string processName)
        //{
        //    return mapProcessSet[processName].processorTimeCounter.worstList;
        //}

        //public WorstList GetProcessMemoryWorst(string processName)
        //{
        //    return mapProcessSet[processName].workingSetCounter.worstList;
        //}

        public ProcessSet GetProcessSet(Process process)
        {
            return mapProcessSet[process.Id];
        }

        
    }
}
