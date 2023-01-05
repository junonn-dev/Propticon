using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WindowsFormsApp1.Config
{
    static class MonInfoGenerator
    {
        public static void CreateMonStartInfo(DateTime startTime, DateTime endTime, IEnumerable<Process> processes)
        {
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
                xmlProcess.AppendChild(xmlName);

                XmlNode xmlPid = xdoc.CreateElement("PID");
                xmlName.InnerText = 
            }
            // Employee#1001
            XmlNode emp1 = xdoc.CreateElement("Start");

            XmlNode name1 = xdoc.CreateElement("Name");
            name1.InnerText = "Tim";
            emp1.AppendChild(name1);

            XmlNode dept1 = xdoc.CreateElement("Dept");
            dept1.InnerText = "Sales";
            emp1.AppendChild(dept1);

            root.AppendChild(emp1);

            // Employee#1002
            var emp2 = xdoc.CreateElement("Employee");
            var attr2 = xdoc.CreateAttribute("Id");
            attr2.Value = "1002";
            emp2.Attributes.Append(attr2);

            var name2 = xdoc.CreateElement("Name");
            name2.InnerText = "John";
            emp2.AppendChild(name2);

            XmlNode dept2 = xdoc.CreateElement("Dept");
            dept2.InnerText = "HR";
            emp2.AppendChild(dept2);

            root.AppendChild(emp2);

            // XML 파일 저장
            xdoc.Save(@"C:\Temp\Emp.xml");
        }
    }
}
