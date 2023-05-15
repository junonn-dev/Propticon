using MonitorigProcess.Config;
using MonitoringProcess.Config;
using MonitoringProcess.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MonitoringProcess.Repository
{
    public class WarnDataRepository
    {
        public List<MeasureDataDto> WarnDataList { get; set; }
        private string warnDataWriteDirectory;
        private string warnDataCopyFilePath;
        private Thread fileWriteThread;
        private bool isThreadRunning;

        public WarnDataRepository(DateTime startTime)
        {
            WarnDataList = new List<MeasureDataDto>();

            //C:\Logs\시작날짜\WarnData\WarnData_warn발생날짜.xml
            warnDataWriteDirectory = AppConfiguration.logRootDirectory + startTime.ToString(AppConfiguration.logPartialDirectoryFormat) + "\\WarnData\\";

            //C:\Logs\WarnData.xml
            warnDataCopyFilePath = AppConfiguration.logRootDirectory + "WarnData.xml";
            fileWriteThread = new Thread(WriteAllReservedWarnData);
        }

        public void AddWarnData(MeasureDataDto dto)
        {
            lock (WarnDataList)
            {
                WarnDataList.Add(dto);
            }
        } 

        public void startThread()
        {
            isThreadRunning = true;
            fileWriteThread.Start();
        }

        private void WriteAllReservedWarnData()
        {
            while (isThreadRunning)
            {
                DateTime warnCheckTime = DateTime.Now;
                //짝수 분 이고 2초 이전일 때
                if((warnCheckTime.Minute & 1) == 0 && ( warnCheckTime.Second<=2))
                {
                    //warndata 없으면 1분 대기
                    if( WarnDataList.Count > 0)
                    {
                        XDocument xdoc = new XDocument(new XDeclaration("1.0", "UTF-8", null));

                        XElement root = new XElement("WarnData");
                        xdoc.Add(root);

                        XElement totalCpuUsageLimit = new XElement("TotalCpuUsageLimit", WarnLimitConfig.TotalCpuUsageLimit);
                        root.Add(totalCpuUsageLimit);

                        XElement totalMemoryUsageLimit = new XElement("TotalMemoryUsageLimit", WarnLimitConfig.TotalMemoryUsageLimit);
                        root.Add(totalMemoryUsageLimit);

                        XElement diskSpaceLimit = new XElement("DiskSpaceLimit", WarnLimitConfig.DiskSpaceLimit);
                        root.Add(diskSpaceLimit);

                        XElement processCpuLimit = new XElement("ProcessCpuLimit", WarnLimitConfig.ProcessCpuLimit);
                        root.Add(processCpuLimit);

                        XElement processMemoryLimit = new XElement("ProcessMemoryLimit", WarnLimitConfig.ProcessMemoryLimit);
                        root.Add(processMemoryLimit);

                        XElement processThreadLimit = new XElement("ProcessThreadLimit", WarnLimitConfig.ProcessThreadLimit);
                        root.Add(processThreadLimit);

                        XElement processHandleLimit = new XElement("ProcessHandleLimit", WarnLimitConfig.ProcessHandleLimit);
                        root.Add(processHandleLimit);

                        XElement processGdiLimit = new XElement("ProcessGdiLimit", WarnLimitConfig.ProcessGdiLimit);
                        root.Add(processGdiLimit);

                        XElement warningList = new XElement("WarningList");
                        root.Add(warningList);

                        lock (WarnDataList)
                        {
                            foreach (MeasureDataDto warnData in WarnDataList)
                            {
                                XElement warning = new XElement("Warning");
                                warningList.Add(warning);

                                XElement time = new XElement("Time", warnData.MeasureTime);
                                warning.Add(time);

                                //PC 성능 관련, Total CPU, TotalMemory ...
                                var pcPerfElements = from KeyValuePair<string, float> data
                                                        in warnData.PcPerformanceInfo
                                                     select new XElement(data.Key, data.Value);
                                foreach (XElement item in pcPerfElements)
                                {
                                    warning.Add(item);
                                }

                                //Disk Space
                                XElement diskSpace = new XElement("DiskSpace");

                                var diskSpaceElements = from KeyValuePair<string, float> data
                                                        in warnData.DiskFreeSpacePercent
                                                        select new XElement(data.Key, data.Value);
                                foreach (XElement item in diskSpaceElements)
                                {
                                    diskSpace.Add(item);
                                }
                                warning.Add(diskSpace);

                                //Process별 성능
                                XElement processList = new XElement("ProcessList");
                                warning.Add(processList);

                                foreach (var processData in warnData.ProcessMeasureInfo)
                                {
                                    XElement process = new XElement("Process");
                                    processList.Add(process);

                                    SelectedProcess selectedProcess = processData.Key;
                                    XElement name = new XElement("Name", selectedProcess.Name);
                                    process.Add(name);

                                    XElement pid = new XElement("PID", selectedProcess.Id);
                                    process.Add(pid);

                                    var processes = from KeyValuePair<string, float> data
                                                    in processData.Value
                                                    select new XElement(data.Key, data.Value);
                                    foreach (XElement item in processes)
                                    {
                                        process.Add(item);
                                    }
                                }
                            }

                            WarnDataList.Clear();
                        }
                        Directory.CreateDirectory(warnDataWriteDirectory);
                        string wirteFilePath = warnDataWriteDirectory + "WarnData_" + warnCheckTime.ToString(AppConfiguration.warnDataFileFormat) + ".xml";
                        xdoc.Save(wirteFilePath);
                        File.Copy(wirteFilePath, warnDataCopyFilePath, true);
                    }
                    
                    // 61초 대기
                    Thread.Sleep(61000);
                }
                //1초마다 분 변경 대기
                Thread.Sleep(1000);
            }
        }

        //Flush 진행 시, 2n 분 상관 없이 종료. 측정 마지막 2분은 알람 발생하지 않게됨
        public void StopWriting()
        {
            isThreadRunning = false;
        }

        private void WriteAndCopyWarnDataXml()
        {
            
        }
    }
}
