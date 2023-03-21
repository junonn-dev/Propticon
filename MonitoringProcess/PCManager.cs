using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using MonitorigProcess.Config;
using MonitorigProcess.CounterItem;
using MonitorigProcess.Data;
using MonitorigProcess.Helper;
using MonitoringProcess.CounterItem;

namespace MonitorigProcess
{
    public class PCManager
    {
        private Dictionary<int, ProcessPerformance> mapProcessPerformance;
        private Dictionary<string, PCPerformance> mapPCPerformance;

        public List<float> FreeSpaceCurrentValues { get; set; }

        /// <summary>
        /// 내부 필드 초기화만 함, PCManager 생성 후 InitProcessMonitor 호출하여 프로세스 지정해야 함
        /// </summary>
        public PCManager()
        {
            mapProcessPerformance = new Dictionary<int, ProcessPerformance>();
            mapPCPerformance = new Dictionary<string, PCPerformance>();
            FreeSpaceCurrentValues = new List<float>();

            //PC의 disk를 가져와서 각 Disk이름에 해당하는 PCPerformance를 초기화 (ex. C:, D:)
            IEnumerable<string> disks = AppConfiguration.diskNames;
            foreach (var item in disks)
            {
                mapPCPerformance[item] = new PCPerformance(item);
            }            
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
            mapProcessPerformance.Clear();
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

                if (!mapProcessPerformance.ContainsKey(process.Id))
                {
                    mapProcessPerformance.Add(process.Id, 
                        new ProcessPerformance(process.Id, process.ProcessName, instanceName));
                }
            }
        }

        public float GetProcessCPUUsage(Process process, DateTime timeStamp)
        {
            if(mapProcessPerformance.ContainsKey(process.Id) is false)
            {
                return -1f;
            }
            return mapProcessPerformance[process.Id].processorTimeCounter.GetNextValue(timeStamp);
        }

        public float GetProcessMemoryUsage(Process process, DateTime timeStamp)
        {
            if (mapProcessPerformance.ContainsKey(process.Id) is false)
            {
                return -1f;
            }
            return mapProcessPerformance[process.Id].workingSetCounter.GetNextValue(timeStamp);
        }

        public int GetProcessThreadCount(Process process)
        {
            if (mapProcessPerformance.ContainsKey(process.Id) is false)
            {
                return -1;
            }
            return (int)mapProcessPerformance[process.Id].threadCountCounter.GetNextValue();
        }

        public int GetProcessHandleCount(Process process)
        {
            if (mapProcessPerformance.ContainsKey(process.Id) is false)
            {
                return -1;
            }
            return (int)mapProcessPerformance[process.Id].handleCountCounter.GetNextValue();
        }

        public ProcessPerformance GetProcessSet(Process process)
        {
            return mapProcessPerformance[process.Id];
        }

        //map에 현재 측정중인 프로세스 정보만 담겨있으면 processes 주입 필요 없는데,
        //map에 미사용 프로세스 해제가 안된 상태라 processes 가져와야 함
        public ResultSnapshot GetResultSnapshot(IEnumerable<Process> processes, int processCount)
        {
            ResultSnapshot resultSnapshot = new ResultSnapshot();
            for(int i=0;i<processCount;i++)
            {
                int pid = processes.ElementAt(i).Id;
                var processPerformance = mapProcessPerformance[pid];

                resultSnapshot.mapResult[pid] = new Dictionary<string, ResultSnapshot.ResultValues>();

                string processCPU = ConfigurationManager.AppSettings["processCPU"];
                resultSnapshot.mapResult[pid][processCPU] = new ResultSnapshot.ResultValues(
                    processPerformance.processorTimeCounter.GetMinValue(),
                    processPerformance.processorTimeCounter.GetMaxValue(),
                    processPerformance.processorTimeCounter.GetAverage());

                string processMemory= ConfigurationManager.AppSettings["processMemory"];
                resultSnapshot.mapResult[pid][processMemory] = new ResultSnapshot.ResultValues(
                    processPerformance.workingSetCounter.GetMinValue(),
                    processPerformance.workingSetCounter.GetMaxValue(),
                    processPerformance.workingSetCounter.GetAverage());

                string processThread = ConfigurationManager.AppSettings["processThread"];
                resultSnapshot.mapResult[pid][processThread] = new ResultSnapshot.ResultValues(
                    processPerformance.threadCountCounter.GetMinValue(),
                    processPerformance.threadCountCounter.GetMaxValue(),
                    processPerformance.threadCountCounter.GetAverage());

                string processHandle = ConfigurationManager.AppSettings["processHandle"];
                resultSnapshot.mapResult[pid][processHandle] = new ResultSnapshot.ResultValues(
                    processPerformance.handleCountCounter.GetMinValue(),
                    processPerformance.handleCountCounter.GetMaxValue(),
                    processPerformance.handleCountCounter.GetAverage());

                string processGDI = AppConfiguration.processGDI;
                resultSnapshot.mapResult[pid][processGDI] = new ResultSnapshot.ResultValues(
                    processPerformance.gdiCountCounter.GetMinValue(),
                    processPerformance.gdiCountCounter.GetMaxValue(),
                    processPerformance.gdiCountCounter.GetAverage());
            }

            return resultSnapshot;
        }

        public int GetProcessGdiCount(Process process)
        {
            if (mapProcessPerformance.ContainsKey(process.Id) is false)
            {
                return -1;
            }
            return (int)mapProcessPerformance[process.Id].gdiCountCounter.GetNextValue();
        }

        public List<float> GetFreeDiskSpace()
        {
            FreeSpaceCurrentValues.Clear();
            foreach (var item in mapPCPerformance)
            {
                FreeSpaceCurrentValues.Add(item.Value.FreeDiskSpace.GetNextValue());
            }
            return FreeSpaceCurrentValues;
        }

    }
}
