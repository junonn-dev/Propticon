using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WindowsFormsApp1.Graph
{
    class LogParser
    {
        private List<DateTime> times = new List<DateTime>();
        private Dictionary<string, Dictionary<string, List<float>>> counterValues
        = new Dictionary<string, Dictionary<string, List<float>>>();

        private string[] counterNames = new string[64];
        private string[] processNames = new string[64];
        private int counterCount = 0;
        private int processCount = 0;

        /// <summary>
        /// 한 측정의 start 
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public LogParser(DateTime startTime, DateTime endTime)
        {

        }

        private void InitCounters(string filePath)
        {
            if (!File.Exists(filePath))
            {
                System.Windows.Forms.MessageBox.Show("${filePath} 파일이 존재하지 않습니다.");
                return;
            }

            StreamReader sr = new StreamReader(filePath);
            String readLine = sr.ReadLine();
            //마지막 콤마 남아있음 trim해야함
            List<String> columns = readLine.Trim(',').Split(',').ToList();
            columns.RemoveAt(0);

            foreach (var column in columns)
            {
                var counterAndProcess = column.Split('_');
                if (!counterNames.Contains(counterAndProcess[0]))
                {
                    counterNames[counterCount] = counterAndProcess[0];
                    counterCount++;
                }
                if (!processNames.Contains(counterAndProcess[1]))
                {
                    processNames[processCount] = counterAndProcess[1];
                    processCount++;
                }
            }

            for (int i = 0; i < processCount; i++)
            {
                //process이름으로 키값 생성
                counterValues.Add(processNames[i], new Dictionary<string, List<float>>());
                for (int j = 0; j < counterCount; j++)
                {
                    //생성된 process 이름으로 검색하여, 카운터이름 키값 생성
                    counterValues[processNames[i]].Add(counterNames[j], new List<float>());
                }
            }
            sr.Close();
        }
        private string GetLogPath(DateTime dateTime)
        {
            string fileName = dateTime.ToString("yyyy-MM-dd-HH") + ".csv";
            string baseLogPath = Logger.GetInstance().GetBaseLogPath();
            return baseLogPath + fileName;
        }

        public Tuple<List<DateTime>, Dictionary<string, Dictionary<string, List<float>>>> GetOneHourLog(DateTime dateTime)
        {
            string filePath = GetLogPath(dateTime);
            
            if (!File.Exists(filePath))
            {
                return new Tuple<List<DateTime>, Dictionary<string, Dictionary<string, List<float>>>>(times, counterValues);
            }

            StreamReader sr = new StreamReader(filePath);
            String readLine = sr.ReadLine();
            //마지막 콤마 남아있음 trim해야함
            List<String> columns = readLine.Trim(',').Split(',').ToList();
            columns.RemoveAt(0);

            foreach (var column in columns)
            {
                var counterAndProcess = column.Split('_');
                if (!counterNames.Contains(counterAndProcess[0]))
                {
                    counterNames[counterCount] = counterAndProcess[0];
                    counterCount++;
                }
                if (!processNames.Contains(counterAndProcess[1]))
                {
                    processNames[processCount] = counterAndProcess[1];
                    processCount++;
                }
            }

            for (int i = 0; i < processCount; i++)
            {
                //process이름으로 키값 생성
                counterValues.Add(processNames[i], new Dictionary<string, List<float>>());
                for (int j = 0; j < counterCount; j++)
                {
                    //생성된 process 이름으로 검색하여, 카운터이름 키값 생성
                    counterValues[processNames[i]].Add(counterNames[j], new List<float>());
                }
            }

            readLine = sr.ReadLine();
            while (!String.IsNullOrEmpty(readLine))
            {
                var values = readLine.Trim(',').Split(',');
                char[] trim = { '[', ']' };
                times.Add(DateTime.Parse(values[0].Trim(trim)));
                int valuesIndex = 1;
                for (int i = 0; i < processCount; i++)
                {
                    string processName = processNames.ElementAt(i);
                    for (int j = 0; j < counterCount; j++)
                    {
                        float valueToInsert = float.Parse(values[valuesIndex]);
                        valuesIndex++;
                        counterValues[processNames[i]][counterNames[j]].Add(valueToInsert);
                    }
                }
                readLine = sr.ReadLine();
            }
            sr.Close();

            return new Tuple<List<DateTime>, Dictionary<string, Dictionary<string, List<float>>>>(times, counterValues);
        }

        public Tuple<List<DateTime>, Dictionary<string, Dictionary<string, List<float>>>> GetHoursLog(DateTime startTime, DateTime endTime)
        {
            string filePath = GetLogPath(startTime);
            List<DateTime> times = new List<DateTime>();
            Dictionary<string, Dictionary<string, List<float>>> counterValues
            = new Dictionary<string, Dictionary<string, List<float>>>();

            

            return new Tuple<List<DateTime>, Dictionary<string, Dictionary<string, List<float>>>>(times, counterValues);
        }
    }
}
