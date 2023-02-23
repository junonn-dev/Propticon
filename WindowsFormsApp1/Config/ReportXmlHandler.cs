﻿using System;
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
        private static readonly string reportDirectory = ConfigurationManager.AppSettings["reportDirectory"];
        private static readonly string reportFileFormat = ConfigurationManager.AppSettings["reportFileFormat"];
        private static readonly string xmlDateTimeFormat = ConfigurationManager.AppSettings["xmlDateTimeFormat"];
        private static readonly string processCPU = ConfigurationManager.AppSettings["processCPU"];
        private static readonly string processMemory = ConfigurationManager.AppSettings["processMemory"];
        private static readonly string processThread = ConfigurationManager.AppSettings["processThread"];
        private static readonly string processHandle = ConfigurationManager.AppSettings["processHandle"];

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
            Directory.CreateDirectory(reportDirectory);

            XDocument xdoc = new XDocument(new XDeclaration("1.0", "UTF-8", null));

            XElement root = new XElement(xpRoot);
            xdoc.Add(root);

            XElement start = new XElement(xpStart, startTime.ToString(xmlDateTimeFormat));
            root.Add(start);

            XElement end = new XElement(xpEnd, endTime.ToString(xmlDateTimeFormat));
            root.Add(end);

            XElement stop = new XElement(xpStop, stopTime.ToString(xmlDateTimeFormat));
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
                        resultSnapshot.mapResult[checkingProcess.Pid][processCPU];
                    XElement xmlCpu = new XElement(xpCPU,
                        new XElement(xpMin, checkingResult.minValue),
                        new XElement(xpMax, checkingResult.maxValue),
                        new XElement(xpAverage, checkingResult.average));

                    xmlProcess.Add(xmlCpu);
                }

                {
                    ResultSnapshot.ResultValues checkingResult =
                         resultSnapshot.mapResult[checkingProcess.Pid][processMemory];
                    XElement xmlMemory = new XElement(xpMemory,
                        new XElement(xpMin, checkingResult.minValue),
                        new XElement(xpMax, checkingResult.maxValue),
                        new XElement(xpAverage, checkingResult.average));

                    xmlProcess.Add(xmlMemory);
                }

                {
                    ResultSnapshot.ResultValues checkingResult =
                         resultSnapshot.mapResult[checkingProcess.Pid][processThread];
                    XElement xmlThread = new XElement(xpThread,
                        new XElement(xpMin, checkingResult.minValue),
                        new XElement(xpMax, checkingResult.maxValue),
                        new XElement(xpAverage, checkingResult.average));

                    xmlProcess.Add(xmlThread);
                }

                {
                    ResultSnapshot.ResultValues checkingResult =
                         resultSnapshot.mapResult[checkingProcess.Pid][processHandle];
                    XElement xmlHandle = new XElement(xpHandle,
                        new XElement(xpMin, checkingResult.minValue),
                        new XElement(xpMax, checkingResult.maxValue),
                        new XElement(xpAverage, checkingResult.average));

                    xmlProcess.Add(xmlHandle);
                }

                xmlProcsesses.Add(xmlProcess);
            }

            root.Add(xmlProcsesses);

            string infoFilePath = reportDirectory + startTime.ToString(reportFileFormat) + ".xml";
            xdoc.Save(infoFilePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static OverviewDto getReportOverviewInfo(string filename)
        {

            if (string.IsNullOrEmpty(filename))
            {
                return null;
            }

            string infoFilePath = reportDirectory + filename;

            if (!File.Exists(infoFilePath))
            {
                return null;
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
                return null;
            }
           
            return overviewDto;
        }

    }
}
