using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Helper;

namespace WindowsFormsApp1.Config
{
    public static class ReportXmlHandler
    {
        //private static IEnumerable<Process> processes;
        private static readonly string reportDirectory = ConfigurationManager.AppSettings["reportDirectory"];
        private static readonly string reportFileFormat = ConfigurationManager.AppSettings["reportFileFormat"];
        private static readonly string xmlDateTimeFormat = ConfigurationManager.AppSettings["xmlDateTimeFormat"];

        #region XPathDefinition
        private static readonly string xpRoot = "MonitoringInfo";
        private static readonly string xpStart = "Start";
        private static readonly string xpEnd = "WillEnd";
        private static readonly string xpStop = "StoppedAt";
        private static readonly string xpProcessCount = "ProcessCount";
        private static readonly string xpProcesses = "Processes";
        private static readonly string xpProcess = "Process";
        private static readonly string xpProcessName = "Name";
        private static readonly string xpPID = "PID";

        //카운터 항목은 응집도 높히는 방향으로 가야함
        private static readonly string xpCPU = "CPU";
        private static readonly string xpMemory = "Memory";
        private static readonly string xpThread = "Thread";
        private static readonly string xpHandle = "Handle";

        private static readonly string xpMin = "Min";
        private static readonly string xpMax = "Max";
        private static readonly string xpAverage = "Average";
        #endregion


        /// <summary>
        /// xml 파일 생성 요청 시 XmlDocument를 반환해준다.
        /// 반환한 XmlDocument는 생성 요청한 주체가 메모리에 가지고 있다가
        /// 모니터링 종료 시 EditStopTime의 파라미터로 전달하여 StopTime을 기록한다.
        /// 최종적으로 SaveXmlDocument을 호출하여 xml 파일을 생성한다.
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="processes"></param>
        /// <param name="processCount"></param>
        /// <returns></returns>
        public static XmlDocument CreateMonStartInfo(DateTime startTime, DateTime endTime, StProcess[] processes, int processCount)
        {
            Directory.CreateDirectory(reportDirectory);

            XmlDocument xdoc = new XmlDocument();

            XmlNode root = xdoc.CreateElement(xpRoot);
            xdoc.AppendChild(root);

            XmlNode start = xdoc.CreateElement(xpStart);
            start.InnerText = startTime.ToString(xmlDateTimeFormat);
            root.AppendChild(start);

            XmlNode end = xdoc.CreateElement(xpEnd);
            end.InnerText = endTime.ToString(xmlDateTimeFormat);
            root.AppendChild(end);

            XmlNode stop = xdoc.CreateElement(xpEnd);
            root.AppendChild(stop);

            XmlNode procCount = xdoc.CreateElement(xpProcessCount);
            procCount.InnerText = processCount.ToString();
            root.AppendChild(procCount);

            XmlNode xmlProcsesses = xdoc.CreateElement(xpProcesses);

            for(int i = 0; i < processCount; i++)
            {
                XmlNode xmlProcess = xdoc.CreateElement(xpProcess);

                XmlNode xmlName = xdoc.CreateElement(xpProcessName);
                xmlName.InnerText = processes[i].InstanceName;
                xmlProcess.AppendChild(xmlName);

                XmlNode xmlPid = xdoc.CreateElement(xpPID);
                xmlPid.InnerText = processes[i].Pid.ToString();
                xmlProcess.AppendChild(xmlPid);

                {
                    XmlNode xmlCpu = xdoc.CreateElement(xpCPU);

                    XmlNode xmlMin = xdoc.CreateElement(xpMin);
                    XmlNode xmlMax = xdoc.CreateElement(xpMax);
                    XmlNode xmlAvg = xdoc.CreateElement(xpAverage);

                    xmlCpu.AppendChild(xmlMin);
                    xmlCpu.AppendChild(xmlMax);
                    xmlCpu.AppendChild(xmlAvg);

                    xmlProcess.AppendChild(xmlCpu);
                }

                {
                    XmlNode xmlMemory = xdoc.CreateElement(xpMemory);

                    XmlNode xmlMin = xdoc.CreateElement(xpMin);
                    XmlNode xmlMax = xdoc.CreateElement(xpMax);
                    XmlNode xmlAvg = xdoc.CreateElement(xpAverage);

                    xmlMemory.AppendChild(xmlMin);
                    xmlMemory.AppendChild(xmlMax);
                    xmlMemory.AppendChild(xmlAvg);

                    xmlProcess.AppendChild(xmlMemory);
                }

                {
                    XmlNode xmlThread = xdoc.CreateElement(xpThread);

                    XmlNode xmlMin = xdoc.CreateElement(xpMin);
                    XmlNode xmlMax = xdoc.CreateElement(xpMax);
                    XmlNode xmlAvg = xdoc.CreateElement(xpAverage);

                    xmlThread.AppendChild(xmlMin);
                    xmlThread.AppendChild(xmlMax);
                    xmlThread.AppendChild(xmlAvg);

                    xmlProcess.AppendChild(xmlThread);
                }

                {
                    XmlNode xmlHandle = xdoc.CreateElement(xpHandle);

                    XmlNode xmlMin = xdoc.CreateElement(xpMin);
                    XmlNode xmlMax = xdoc.CreateElement(xpMax);
                    XmlNode xmlAvg = xdoc.CreateElement(xpAverage);

                    xmlHandle.AppendChild(xmlMin);
                    xmlHandle.AppendChild(xmlMax);
                    xmlHandle.AppendChild(xmlAvg);

                    xmlProcess.AppendChild(xmlHandle);
                }

                xmlProcsesses.AppendChild(xmlProcess);
            }

            root.AppendChild(xmlProcsesses);

            return xdoc;
        }

        public static void HandleMonitoringEnd(XmlDocument xdoc, DateTime startTime, DateTime stopTime, )
        {
            if (xdoc == null)
            {
                return;
            }
            EditStopTime(xdoc, stopTime);
            SaveXmlDocument(xdoc, startTime);
        }

        private static void EditStopTime(XmlDocument xdoc,DateTime stopTime)
        {
            XPathNavigator nav = xdoc.CreateNavigator();

            nav.SelectSingleNode("//MonitoringInfo//Stop").SetValue(stopTime.ToString(xmlDateTimeFormat));

            //XmlWriter wr = XmlWriter.Create(infoFilePath);
            //nav.WriteSubtree(wr);         
        }

        private static void SaveXmlDocument(XmlDocument xdoc, DateTime startTime)
        {
            string infoFilePath = reportDirectory + startTime.ToString(reportFileFormat) + ".xml";

            xdoc.Save(infoFilePath);
        }

        public static OverviewDto getReportOverviewInfo(string filename)
        {

            if (string.IsNullOrEmpty(filename))
            {
                throw new FileLoadException("잘못된 요청입니다.");
            }

            string infoFilePath = reportDirectory + filename;

            if (!File.Exists(infoFilePath))
            {
                throw new FileLoadException("선택한 Report를 찾을 수 없습니다.");
            }

            OverviewDto overviewDto = new OverviewDto();
            try
            {
                XDocument xdoc = XDocument.Load(infoFilePath);
                XElement result = xdoc.Root;
                DateTime start = DateTime.Parse(result.Attribute(xpStart).Value);
                DateTime end = DateTime.Parse(result.Attribute(xpEnd).Value);
                DateTime stop = DateTime.Parse(result.Attribute(xpStop).Value);

                TimeSpan total = stop - start;
                StringBuilder sb = new StringBuilder();
                sb.Append(total.Days > 0 ? total.ToString() + "d " : "")
                        .Append(total.Hours.ToString()).Append("h ")
                        .Append(total.Minutes.ToString()).Append("m");

                overviewDto.totalTime = sb.ToString();
                overviewDto.startTime = start.ToString();
                overviewDto.endTime = end.ToString();
                overviewDto.processCount = result.Attribute(xpProcessCount).Value;


            }
            catch(Exception e)
            {
                throw new XmlException("선택한 Report를 읽어오는데 실패했습니다.");
            }
           
            return overviewDto;
        }

    }
}
