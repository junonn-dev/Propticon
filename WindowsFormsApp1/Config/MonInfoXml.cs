using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Helper;

namespace WindowsFormsApp1.Config
{
    public static class MonInfoXml
    {
        private static string infoFilePath = "";
        private static IEnumerable<Process> processes;

        public static void CreateMonStartInfo(DateTime startTime, DateTime endTime, StProcess[] processes, int processCount)
        {
            //this.processes = processes;
            infoFilePath = ConfigurationManager.AppSettings["reportDirectory"] + startTime.ToString(ConfigurationManager.AppSettings["reportFileFormat"]) +".xml";
            if (File.Exists(infoFilePath))
            {
                return;
            }
            XmlDocument xdoc = new XmlDocument();

            // 루트노드
            XmlNode root = xdoc.CreateElement("MonitoringInfo");
            xdoc.AppendChild(root);

            XmlNode start = xdoc.CreateElement("Start");
            start.InnerText = startTime.ToString("yyyy-MM-dd HH-mm-ss");
            root.AppendChild(start);

            XmlNode end = xdoc.CreateElement("End");
            end.InnerText = endTime.ToString("yyyy-MM-dd HH-mm-ss");
            root.AppendChild(end);

            XmlNode stop = xdoc.CreateElement("Stop");
            root.AppendChild(end);

            XmlNode xmlProcsesses = xdoc.CreateElement("Processes");

            for(int i = 0; i < processCount; i++)
            {
                XmlNode xmlProcess = xdoc.CreateElement("Process");

                XmlNode xmlName = xdoc.CreateElement("Name");
                xmlName.InnerText = processes[i].InstanceName;

                XmlNode xmlPid = xdoc.CreateElement("PID");
                xmlName.InnerText = processes[i].Pid.ToString();

                xmlProcess.AppendChild(xmlName);
                xmlProcess.AppendChild(xmlPid);

                xmlProcsesses.AppendChild(xmlProcess);
            }

            root.AppendChild(xmlProcsesses);

            xdoc.Save(infoFilePath);
        }

        public static void EditStopTime(DateTime stopTime)
        {
            if (string.IsNullOrEmpty(infoFilePath))
            {
                return;
            }

            if (!File.Exists(infoFilePath))
            {
                return;
            }

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(infoFilePath);

            XPathNavigator nav = xdoc.CreateNavigator();
            XPathNodeIterator node = nav.Select("/MonitoringInfo/Stop");
            node.Current.SetValue(stopTime.ToString("yyyy-MM-dd HH-mm-ss"));

            XmlWriter wr = XmlWriter.Create(infoFilePath);
            nav.WriteSubtree(wr);
        }
    }
}
