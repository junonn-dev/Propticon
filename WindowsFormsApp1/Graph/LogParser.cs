using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using WindowsFormsApp1.Config;

namespace WindowsFormsApp1.Graph
{
    class LogParser
    {
        //private List<DateTime> times = new List<DateTime>();
        //private Dictionary<string, Dictionary<string, List<float>>> counterValues
        //= new Dictionary<string, Dictionary<string, List<float>>>();

        private string[] counterNames = new string[64];
        private string[] processNames = new string[64];
        private int counterCount = 0;
        private int processCount = 0;

        private static readonly string baseLogPath = ConfigurationManager.AppSettings["LogRootDirectory"];
        private static readonly string reportFileFormat = ConfigurationManager.AppSettings["reportFileFormat"];

        
        /// <summary>
        /// LogParser의 생성 주기
        /// 생성자를 통해 주입된 startTime에 해당하는 한 객체만 생성한다.
        /// 한 LogParser 객체가 여러 Report를 다뤄주지 않는다.
        /// </summary>
        public LogParser(DateTime startTime)
        {
            InitCountersInfoFromReport(GetReportPath(startTime));
        }

        public LogParser(string filename)
        {
            InitCountersInfoFromReport(baseLogPath + filename);
        }

        private void InitCountersInfoFromReport(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            XElement xElem = XElement.Load(filePath);

            IEnumerable<XElement> processes = xElem.Elements(ReportXmlHandler.xpProcess);
            processCount = processes.Count();

            for(int i=0;i<processCount;i++)
            {
                processNames[i] = processes.ElementAt(i).Element(ReportXmlHandler.xpProcessName).Value;
            }

            //카운터 확장 시 수정해야 하는 부분
            counterCount = 4;   
            counterNames[0] = ConfigurationManager.AppSettings["processCPU"];
            counterNames[1] = ConfigurationManager.AppSettings["processMemory"];
            counterNames[2] = ConfigurationManager.AppSettings["processThread"];
            counterNames[3] = ConfigurationManager.AppSettings["processHandle"];
        }

        //deprecated
        private void InitCountersInfoFromCSV(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
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

            sr.Close();
        }

        private string GetReportPath(DateTime dateTime)
        {
            return baseLogPath + dateTime.ToString(reportFileFormat) + ".xml";
        }

        private string GetLogPath(DateTime dateTime)
        {
            return baseLogPath + dateTime.ToString("yyyy-MM-dd-HH") + ".csv";
        }

        private Tuple<List<DateTime>, 
            Dictionary<string, Dictionary<string, List<float>>>> 
            GetOneHourLog(DateTime dateTime, ref List<DateTime> times, 
            ref Dictionary<string, Dictionary<string, List<float>>> counterValues)
        {
            string filePath = GetLogPath(dateTime);

            if (!File.Exists(filePath))
            {
                return new Tuple<List<DateTime>, Dictionary<string, Dictionary<string, List<float>>>>(times, counterValues);
            }

            StreamReader sr = new StreamReader(filePath);
            string readLine = sr.ReadLine();    //첫 헤더 제거           

            readLine = sr.ReadLine();   //값 읽기 시작
            //여기부터 로그 양식에 종속되는 부분, 로그 양식 바뀌면 로직 고려해야함
            while (!String.IsNullOrEmpty(readLine) && readLine[0] !='[' )
            {
                string[] values = readLine.Trim(',').Split(',');
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="stopTime"></param>
        /// <returns>
        /// x축과 y축을 표현할 값들을 Tuple로 반환
        /// x축 : 시간값
        /// y축 : 프로세스이름 -> 카운터이름 -> 측정 값 순으로 매핑
        /// </returns>
        public Tuple<List<DateTime>, Dictionary<string, Dictionary<string, List<float>>>> GetHoursLog(DateTime startTime, DateTime stopTime)
        {
            List<DateTime> times = new List<DateTime>();
            Dictionary<string, Dictionary<string, List<float>>> counterValues
            = new Dictionary<string, Dictionary<string, List<float>>>();

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

            //시작, 종료 잘못 입력한 경우
            if (startTime >= stopTime)
            {
                return new Tuple<List<DateTime>, Dictionary<string, Dictionary<string, List<float>>>>(times, counterValues);
            }

            DateTime dateTime = startTime;
            while(!(dateTime.Year == stopTime.Year
                    && dateTime.Month == stopTime.Month
                    && dateTime.Day == stopTime.Day
                    && dateTime.Hour == stopTime.Hour))
            {
                GetOneHourLog(dateTime, ref times, ref counterValues);
                dateTime = dateTime.AddHours(1);
            }
            
            return new Tuple<List<DateTime>, Dictionary<string, Dictionary<string, List<float>>>>(times, counterValues);
        }

        public string[] GetCounterNames()
        {
            return counterNames;
        }
        public int GetCounterCount()
        {
            return counterCount;
        }
    }
}
