using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using MonitorigProcess.Config;
using MonitorigProcess.CounterItem;
using MonitorigProcess.Data;
using MonitorigProcess.Helper;
using MonitoringProcess.CounterItem;
using MonitoringProcess.Data;

namespace MonitorigProcess
{
    public class PCManager
    {
        //RAM 크기 가져오는 함수, 8GB, 16GB....
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);

        private long totalPhysicalMemoryMB;
        private Dictionary<int, ProcessPerformance> mapProcessPerformance;
        public PCPerformance pcPerformance { get; private set; }

        public List<float> FreeSpaceCurrentValues { get; set; }

        /// <summary>
        /// 내부 필드 초기화만 함, PCManager 생성 후 InitProcessMonitor 호출하여 프로세스 지정해야 함
        /// </summary>
        public PCManager()
        {
            mapProcessPerformance = new Dictionary<int, ProcessPerformance>();
            pcPerformance = new PCPerformance();
            FreeSpaceCurrentValues = new List<float>();

            long ramSizeKB = 0;
            GetPhysicallyInstalledSystemMemory(out ramSizeKB);
            totalPhysicalMemoryMB = ramSizeKB / 1024;
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
            pcPerformance = new PCPerformance();
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
            try
            {
                return mapProcessPerformance[process.Id];
            }
            catch (Exception)
            {
                throw new Exception("측정정보가 없습니다.");
            }
        }

        public ProcessPerformance GetProcessSet(int pid)
        {
            try
            {
                return mapProcessPerformance[pid];
            }
            catch (Exception)
            {
                throw new Exception("측정정보가 없습니다.");
            }
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

            resultSnapshot.totalCpuResult = new ResultSnapshot.ResultValues(
                pcPerformance.TotalCpuUsage.GetMinValue(),
                pcPerformance.TotalCpuUsage.GetMaxValue(),
                pcPerformance.TotalCpuUsage.GetAverage());

            resultSnapshot.totalMemoryResult = new ResultSnapshot.ResultValues(
                totalPhysicalMemoryMB - pcPerformance.MemoryUsageMB.GetMaxValue(),
                totalPhysicalMemoryMB - pcPerformance.MemoryUsageMB.GetMinValue(),
                totalPhysicalMemoryMB - pcPerformance.MemoryUsageMB.GetAverage());

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
            foreach (Counter item in pcPerformance.FreeDiskSpaceCounters)
            {
                FreeSpaceCurrentValues.Add(item.GetNextValue());
            }
            return FreeSpaceCurrentValues;
        }

        public float GetTotalCPUUsage(DateTime timeStamp)
        {
            return pcPerformance.TotalCpuUsage.GetNextValue(timeStamp);
        }

        public float GetTotalMemoryUsage(DateTime timeStamp)
        {
            return totalPhysicalMemoryMB - pcPerformance.MemoryUsageMB.GetNextValue(timeStamp);
        }

        /// <summary>
        /// 1. 호출 시점에 측정하는 전체 카운터로 측정
        /// 2. Log
        /// 3. 임계값 조사 및 WarnData Buffer에 저장
        /// 측정 값을 담은 MeasureDataDto를
        /// </summary>
        /// <returns></returns>
        public MeasureDataDto MeasureData()
        {
            DateTime timeStamp = DateTime.Now;
            MeasureDataDto dto = new MeasureDataDto(timeStamp);

            //PID로 프로세스 마다 측정하고 값 담기
            foreach (KeyValuePair<int, ProcessPerformance> processCounters in mapProcessPerformance)
            {
                Dictionary<string, float> values = new Dictionary<string, float>();
                foreach (Counter counter in processCounters.Value)
                {
                    //GetNextValue에 timeStamp가 입력되면 Worst를 기록한다.
                    //모든 프로세스의 카운터가 Worst를 기록하게 되며,
                    //Worst 저장 할 필요가 없는 카운터도 Worst 확인 연산을 하게되어 성능 하락 요인이 된다.
                    values[counter.CounterName] = counter.GetNextValue(timeStamp);
                }
                dto.ProcessMeasureInfo[processCounters.Key] = values;
            }

            foreach (Counter counter in pcPerformance.FreeDiskSpaceCounters)
            {
                dto.DiskFreeSpacePercent[counter.CounterName] = counter.GetNextValue();
            }

            dto.PcPerformanceInfo[pcPerformance.TotalCpuUsage.CounterName] = pcPerformance.TotalCpuUsage.GetNextValue(timeStamp);

            dto.PcPerformanceInfo[pcPerformance.MemoryUsageMB.CounterName] = pcPerformance.MemoryUsageMB.GetNextValue(timeStamp);

            return dto;
        }

    }
}
