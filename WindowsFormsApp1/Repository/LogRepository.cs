using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using WindowsFormsApp1.Config;

namespace WindowsFormsApp1.Repository
{
    class LogRepository
    {
        //private List<DateTime> times = new List<DateTime>();
        //private Dictionary<string, Dictionary<string, List<float>>> counterValues
        //= new Dictionary<string, Dictionary<string, List<float>>>();

        private string[] counterNames = new string[64];
        private string[] processNames = new string[64];
        private int counterCount = 0;
        private int processCount = 0;
        
        /// <summary>
        /// LogParser의 생성 주기 : 
        /// 생성자를 통해 주입된 startTime에 해당하는 한 객체만 생성한다.
        /// 한 LogParser 객체가 여러 Report를 다뤄주지 않는다.
        /// </summary>
        public LogRepository(DateTime startTime)
        {
            InitCountersInfoFromReport(GetReportPath(startTime));
        }

        public LogRepository(string reportXml)
        {
            InitCountersInfoFromReport(AppConfiguration.reportDirectory + reportXml);
        }

        private void InitCountersInfoFromReport(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            XElement xElem = XElement.Load(filePath);

            IEnumerable<XElement> processes = xElem.Element(ReportRepository.xpProcesses).Elements(ReportRepository.xpProcess);
            processCount = processes.Count();

            for(int i=0;i<processCount;i++)
            {
                processNames[i] = processes.ElementAt(i).Element(ReportRepository.xpProcessName).Value;
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
            return AppConfiguration.reportDirectory + dateTime.ToString(AppConfiguration.reportFileFormat) + ".xml";
        }

        private string GetLogPath(DateTime dateTime)
        {
            return AppConfiguration.logRootDirectory + dateTime.ToString("yyyy-MM-dd-HH") + ".csv";
        }

        private void GetOneHourLog(DateTime dateTime, ref List<DateTime> times, 
            ref Dictionary<string, Dictionary<string, List<float>>> counterValues)
        {
            string filePath = GetLogPath(dateTime);

            if (!File.Exists(filePath))
            {
                return;
            }

            StreamReader sr = new StreamReader(filePath);
            string readLine = sr.ReadLine();    //첫 헤더 제거           

            readLine = sr.ReadLine();   //값 읽기 시작
            //여기부터 로그 양식에 종속되는 부분, 로그 양식에 따라 수정 해야함
            while (!String.IsNullOrEmpty(readLine) )
            {
                if(readLine[0] != '[')
                {
                    readLine = sr.ReadLine();
                    continue;
                }
                string[] values = readLine.Trim(',').Split(',');
                char[] trim = { '[', ']' };
                //로그에서 hh가 아니라 HH로 포맷 지정해야 check time을 제대로 확인 가능함.
                DateTime checkTime = DateTime.Parse(values[0].Trim(trim));  
                if (checkTime < dateTime)
                {
                    readLine = sr.ReadLine();
                    continue;
                }
                times.Add(checkTime);
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
            
            while(dateTime<stopTime)
            {
                GetOneHourLog(dateTime, ref times, ref counterValues);
                //dateTime은 가장 처음에 startTime과 동일하게 들어가서
                //log의 초기 시작점을 찾아야 한다.
                //GetOneHourLog에 첫 1회 이용된 이후 dateTime은 분, 초가 초기화되어,
                //시간단위로 생성된 로그파일에 접근한다.
                dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 0, 0);
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
