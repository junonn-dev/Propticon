using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using MonitorigProcess.Config;
using MonitorigProcess.Data;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace MonitorigProcess.Repository
{
    public static class ReportRepository
    {
        #region XPathDefinition
        public static readonly string xpRoot = "MonitoringInfo";
        public static readonly string xpStart = "Start";
        public static readonly string xpEnd = "WillEnd";
        public static readonly string xpStop = "StoppedAt";
        public static readonly string xpProcessCount = "ProcessCount";
        public static readonly string xpProcesses = "Processes";
        public static readonly string xpProcess = "Process";
        public static readonly string xpProcessName = "Name";
        public static readonly string xpPID = "PID";
        
        public static readonly string xpCPU = "CPU";
        public static readonly string xpMemory = "Memory";
        public static readonly string xpThread = "Thread";
        public static readonly string xpHandle = "Handle";
        
        public static readonly string xpMin = "Min";
        public static readonly string xpMax = "Max";
        public static readonly string xpAverage = "Average";
        #endregion

        private static string GetReportFileDircetory(DateTime startTime)
        {
            return AppConfiguration.logRootDirectory + startTime.ToString(AppConfiguration.logPartialDirectoryFormat) + "\\";
        }

        private static string GetReportFilePath(DateTime startTime)
        {
            return GetReportFileDircetory(startTime) + startTime.ToString(AppConfiguration.reportFileFormat) + ".xml";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startTime">xml 확장자 포함하지 않은 초단위 문자열</param>
        /// <returns></returns>
        private static string GetReportFileDircetory(string startTime)
        {
            return AppConfiguration.logRootDirectory + startTime + "\\";
        }

        /// <summary>
        /// xml 확장자 포함한 report 파일 전체 경로
        /// </summary>
        /// <param name="startTime">xml 확장자 포함하지 않은 초단위 문자열</param>
        /// <returns></returns>
        private static string GetReportFilePath(string startTime)
        {
            return GetReportFileDircetory(startTime) + DateTime.ParseExact(startTime, AppConfiguration.logPartialDirectoryFormat,CultureInfo.CurrentCulture).ToString(AppConfiguration.reportFileFormat) +".xml";
        }

        /// <summary>
        /// 호출한 시점의 측정 결과를 xml파일로 저장한다.
        /// </summary>
        /// <param name="startTime">측정 시작 시간</param>
        /// <param name="endTime">측정 종료 예정 시간</param>
        /// <param name="stopTime">실제 측정 종료된 시간</param>
        /// <param name="processes">측정한 프로세스 목록</param>
        /// <param name="processCount">측정한 프로세스 개수</param>
        /// <param name="resultSnapshot">한 시점에 측정 결과의 snapshot을 찍은 것</param>
        public static void CreateReport(DateTime startTime, DateTime endTime, DateTime stopTime, StProcess[] processes, int processCount, ResultSnapshot resultSnapshot)
        {
            XDocument xdoc = new XDocument(new XDeclaration("1.0", "UTF-8", null));

            XElement root = new XElement(xpRoot);
            xdoc.Add(root);

            XElement start = new XElement(xpStart, startTime.ToString(AppConfiguration.xmlDateTimeFormat));
            root.Add(start);

            XElement end = new XElement(xpEnd, endTime.ToString(AppConfiguration.xmlDateTimeFormat));
            root.Add(end);

            XElement stop = new XElement(xpStop, stopTime.ToString(AppConfiguration.xmlDateTimeFormat));
            root.Add(stop);

            XElement procCount = new XElement(xpProcessCount, processCount.ToString());
            root.Add(procCount);

            XElement xmlProcsesses = new XElement(xpProcesses);

            for(int i = 0; i < processCount; i++)
            {
                StProcess checkingProcess = processes[i];
                XElement xmlProcess = new XElement(xpProcess);

                XElement xmlName = new XElement(xpProcessName, checkingProcess.InstanceName);
                xmlProcess.Add(xmlName);

                XElement xmlPid = new XElement(xpPID, checkingProcess.Pid.ToString());
                xmlProcess.Add(xmlPid);

                {
                    ResultSnapshot.ResultValues checkingResult = 
                        resultSnapshot.mapResult[checkingProcess.Pid][AppConfiguration.processCPU];
                    XElement xmlCpu = new XElement(xpCPU,
                        new XElement(xpMin, checkingResult.minValue),
                        new XElement(xpMax, checkingResult.maxValue),
                        new XElement(xpAverage, checkingResult.average));

                    xmlProcess.Add(xmlCpu);
                }

                {
                    ResultSnapshot.ResultValues checkingResult =
                         resultSnapshot.mapResult[checkingProcess.Pid][AppConfiguration.processMemory];
                    XElement xmlMemory = new XElement(xpMemory,
                        new XElement(xpMin, checkingResult.minValue),
                        new XElement(xpMax, checkingResult.maxValue),
                        new XElement(xpAverage, checkingResult.average));

                    xmlProcess.Add(xmlMemory);
                }

                {
                    ResultSnapshot.ResultValues checkingResult =
                         resultSnapshot.mapResult[checkingProcess.Pid][AppConfiguration.processThread];
                    XElement xmlThread = new XElement(xpThread,
                        new XElement(xpMin, checkingResult.minValue),
                        new XElement(xpMax, checkingResult.maxValue),
                        new XElement(xpAverage, checkingResult.average));

                    xmlProcess.Add(xmlThread);
                }

                {
                    ResultSnapshot.ResultValues checkingResult =
                         resultSnapshot.mapResult[checkingProcess.Pid][AppConfiguration.processHandle];
                    XElement xmlHandle = new XElement(xpHandle,
                        new XElement(xpMin, checkingResult.minValue),
                        new XElement(xpMax, checkingResult.maxValue),
                        new XElement(xpAverage, checkingResult.average));

                    xmlProcess.Add(xmlHandle);
                }

                xmlProcsesses.Add(xmlProcess);
            }

            root.Add(xmlProcsesses);

            Directory.CreateDirectory(GetReportFileDircetory(startTime));
            xdoc.Save(GetReportFilePath(startTime));
        }

        /// <summary>
        /// Report 파일(xml)과 Log 파일(csv)를 파싱하여 GraphViewr에 사용할 Data Transfer Object를 반환함
        /// </summary>
        /// <param name="startTime">.xml이 포함되지 않은 report 파일 이름</param>
        /// <returns></returns>
        public static GraphViewerDto GetGraphViewerInfo(string startTime)
        {
            if (string.IsNullOrEmpty(startTime))
            {
                return null;
            }

            string reportFilePath = GetReportFilePath(startTime);

            if (!File.Exists(reportFilePath))
            {
                return null;
            }

            GraphViewerDto graphViewerDto = new GraphViewerDto();
            try
            {
                //xml parsing start
                XDocument xdoc = XDocument.Load(reportFilePath);
                XElement result = xdoc.Root;

                DateTime start = DateTime.ParseExact(result.Element(xpStart).Value, AppConfiguration.xmlDateTimeFormat, CultureInfo.CurrentCulture);
                DateTime end = DateTime.ParseExact(result.Element(xpEnd).Value, AppConfiguration.xmlDateTimeFormat, CultureInfo.CurrentCulture);
                DateTime stop = DateTime.ParseExact(result.Element(xpStop).Value, AppConfiguration.xmlDateTimeFormat, CultureInfo.CurrentCulture);

                TimeSpan total = stop - start;
                StringBuilder sb = new StringBuilder();
                sb.Append(total.Days > 0 ? total.ToString() + "d " : "")
                        .Append(total.Hours.ToString()).Append("h ")
                        .Append(total.Minutes.ToString()).Append("m ")
                        .Append(total.Seconds.ToString()).Append("s");

                graphViewerDto.totalTime = sb.ToString();
                graphViewerDto.startTime = start.ToString();
                graphViewerDto.stopTime = stop.ToString();
                graphViewerDto.processCount = result.Element(xpProcessCount).Value;
                graphViewerDto.reportFileName = startTime;

                graphViewerDto.mostCpuUsedProcess =
                    (from xElem in result.Element(xpProcesses).Elements(xpProcess)
                     group xElem.Element(xpProcessName).Value
                     by double.Parse(xElem.Element(xpCPU).Element(xpAverage).Value)
                     into xElemGroup
                     orderby xElemGroup.Key descending
                     select xElemGroup).First().First();

                graphViewerDto.mostMemoryUsedProcess =
                    (from xElem in result.Element(xpProcesses).Elements(xpProcess)
                     group xElem.Element(xpProcessName).Value
                     by double.Parse(xElem.Element(xpMemory).Element(xpAverage).Value)
                     into xElemGroup
                     orderby xElemGroup.Key descending
                     select xElemGroup).First().First();

            }
            catch(Exception e)
            {
                return null;
            }

            //csv parsing start
            LogRepository logParser;
            try
            {
                logParser = new LogRepository(reportFilePath, startTime);
            }
            catch
            {
                return null;
            }
            var data = logParser.GetHoursLog(DateTime.Parse(graphViewerDto.startTime), DateTime.Parse(graphViewerDto.stopTime));

            double[] xData = data.Item1.Select(time => time.ToOADate()).ToArray();
            Dictionary<string, Dictionary<string, List<float>>> yData = data.Item2;
            string[] counterNames = logParser.GetCounterNames();
            int counterCount = logParser.GetCounterCount();

            graphViewerDto.xData = xData;
            graphViewerDto.yData = yData;
            graphViewerDto.counterNames = counterNames;
            graphViewerDto.counterCount = counterCount;

            return graphViewerDto;
        }

    }
}
