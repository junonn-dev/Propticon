using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.Xml.XPath;
using WindowsFormsApp1.Helper;

namespace WindowsFormsApp1.Config
{
    class MonInfoXml
    {
        private string infoFilePath = "";
        private IEnumerable<Process> processes;

        public MonInfoXml(string infoFileName)
        {
            infoFilePath = Logger.GetInstance().GetBaseLogPath()
                + infoFileName
                + "\\" + infoFileName
                + ".xml";
        }

        public void CreateMonStartInfo(DateTime startTime, DateTime endTime, IEnumerable<Process> processes)
        {
            this.processes = processes;
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

            foreach (var process in processes)
            {
                if (process == null)
                {
                    continue;
                }
                XmlNode xmlProcess = xdoc.CreateElement("Process");

                XmlNode xmlName = xdoc.CreateElement("Name");
                xmlName.InnerText = process.ProcessName;

                XmlNode xmlPid = xdoc.CreateElement("PID");
                xmlName.InnerText = process.Id.ToString();

                xmlProcess.AppendChild(xmlName);
                xmlProcess.AppendChild(xmlPid);

                xmlProcsesses.AppendChild(xmlProcess);
            }

            root.AppendChild(xmlProcsesses);

            xdoc.Save(infoFilePath);
        }

        public void EditStopTime(DateTime stopTime)
        {
            if (string.IsNullOrEmpty(infoFilePath))
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

        public List<string> GetInstanceNames()
        {
            List<string> instanceNames = new List<string>();

            if(processes == null)
            {
                return instanceNames;
            }
            foreach (var item in this.processes)
            {
                string instanceName = InstanceNameConvertor.GetProcessInstanceName(item.Id, item.ProcessName);
                instanceNames.Add(instanceName);
            }
            return instanceNames;
        }
    }
}
