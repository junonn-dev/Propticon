using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using MonitorigProcess.Config;

namespace MonitorigProcess.Repository
{
    class LogRepository
    {

        private string[] processCounterNames = new string[32];
        private string[] processNames = new string[32];
        private string[] pcCounterNames = new string[64];
        private int processCounterCount = 0;
        private int processCount = 0;
        private int pcCounterCount = 0;
        private string startTime;

        public LogRepository(DateTime startTime)
        {
            InitCountersInfoFromReport(GetReportPath(startTime));
        }

        /// <summary>
        /// LogParser의 생성 주기 : 
        /// 생성자를 통해 주입된 startTime에 해당하는 한 객체만 생성한다.
        /// 한 LogParser 객체가 여러 Report를 다뤄주지 않는다.
        /// </summary>
        /// <param name="reportFilePath">.xml을 포함한 report 파일 전체 경로</param>
        /// <param name="startTime">.xml을 포함하지 않은 시작 시간 문자열</param>
        public LogRepository(string reportFilePath, string startTime)
        {
            this.startTime = startTime;
            InitCountersInfoFromReport(reportFilePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportFilePath">.xml을 포함한 report 파일의 전체 경로</param>
        /// <exception cref="FileNotFoundException"></exception>
        private void InitCountersInfoFromReport(string reportFilePath)
        {
            if (!File.Exists(reportFilePath))
            {
                throw new FileNotFoundException();
            }

            XElement xElem = XElement.Load(reportFilePath);

            IEnumerable<XElement> processes = xElem.Element(ReportRepository.xpProcesses).Elements(ReportRepository.xpProcess);
            processCount = processes.Count();

            for(int i=0;i<processCount;i++)
            {
                processNames[i] = processes.ElementAt(i).Element(ReportRepository.xpProcessName).Value;
            }

            processCounterCount = AppConfiguration.processCounterNames.Count;
            pcCounterCount = AppConfiguration.pcCounterNames.Count;

            for (int i=0; i< processCounterCount; i++)
            {
                processCounterNames[i] = AppConfiguration.processCounterNames[i];
            }
            for (int i = 0; i < pcCounterCount; i++)
            {
                pcCounterNames[i] = AppConfiguration.pcCounterNames[i];
            }
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
                if (!processCounterNames.Contains(counterAndProcess[0]))
                {
                    processCounterNames[processCounterCount] = counterAndProcess[0];
                    processCounterCount++;
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
            return AppConfiguration.logRootDirectory + dateTime.ToString(AppConfiguration.logPartialDirectoryFormat) + dateTime.ToString(AppConfiguration.reportFileFormat) + ".xml";
        }

        private string GetLogPath(DateTime dateTime)
        {
            return AppConfiguration.logRootDirectory + startTime + "\\" + dateTime.ToString(AppConfiguration.logFilenameFormat)+".csv";
        }

        private void GetOneHourLog(DateTime dateTime, ref List<DateTime> times, 
            ref Dictionary<string, Dictionary<string, List<float>>> processCounterValues, ref Dictionary<string, List<float>> pcCounterValues)
        {
            string filePath = GetLogPath(dateTime);

            if (!File.Exists(filePath))
            {
                return;
            }

            StreamReader sr = null;
            try
            {
                sr = new StreamReader(filePath);
            }
            catch
            {
                return;
            }
            string readLine = sr.ReadLine();    //첫 헤더 제거           

            //bool readStarted = false;
            readLine = sr.ReadLine();   //값 읽기 시작
            //여기부터 로그 양식에 종속되는 부분, 로그 양식에 따라 수정 해야함
            while (!String.IsNullOrEmpty(readLine) )
            {
                string[] values = readLine.Trim(',').Split(',');
                char[] trim = { '[', ']' };
                //로그에서 hh가 아니라 HH로 포맷 지정해야 check time을 제대로 확인 가능함.
                DateTime checkTime = DateTime.Parse(values[0].Trim(trim));  

                times.Add(checkTime);
                int valuesIndex = 1;
                for (int i = 0; i < processCount; i++)
                {
                    string processName = processNames.ElementAt(i);
                    for (int j = 0; j < processCounterCount; j++)
                    {
                        float valueToInsert = float.Parse(values[valuesIndex]);
                        valuesIndex++;
                        processCounterValues[processNames[i]][processCounterNames[j]].Add(valueToInsert);
                    }
                }
                for (int i = 0; i < pcCounterCount; i++)
                {
                    pcCounterValues[pcCounterNames[i]].Add(float.Parse(values[valuesIndex]));
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
        /// y축 1 : 프로세스이름 -> 카운터이름 -> 측정 값 순으로 매핑
        /// y축 2 : 카운터이름 -> 측정 값 순 매핑 (프로세스에 종속되지 않는 카운터)
        /// </returns>
        public Tuple<List<DateTime>, Dictionary<string, Dictionary<string, List<float>>>, Dictionary<string, List<float>>> GetHoursLog(DateTime startTime, DateTime stopTime)
        {
            List<DateTime> times = new List<DateTime>();
            Dictionary<string, Dictionary<string, List<float>>> processCounterValues
            = new Dictionary<string, Dictionary<string, List<float>>>();
            Dictionary<string, List<float>> pcCounterValues = new Dictionary<string, List<float>>();

            for (int i = 0; i < processCount; i++)
            {
                //process이름으로 키값 생성
                processCounterValues.Add(processNames[i], new Dictionary<string, List<float>>());
                for (int j = 0; j < processCounterCount; j++)
                {
                    //생성된 process 이름으로 검색하여, 카운터이름 키값 생성
                    processCounterValues[processNames[i]].Add(processCounterNames[j], new List<float>());
                }
                for (int j = 0; j < pcCounterCount; j++)
                {
                    //프로세스에 종속되지 않는 카운터에 대한 맵 초기화
                    pcCounterValues[pcCounterNames[j]] = new List<float>();
                }
            }

            //시작, 종료 잘못 입력한 경우
            if (startTime >= stopTime)
            {
                return new Tuple<List<DateTime>, Dictionary<string, Dictionary<string, List<float>>>, Dictionary<string, List<float>>>(times, processCounterValues, pcCounterValues);
            }

            DateTime dateTime = startTime;
            
            //230314 디렉토리기반 로그 정책으로 변경하면, stop 조건 안따져도, 디렉토리 내의 파일만 search하면 된다.
            while(dateTime<stopTime)
            {
                GetOneHourLog(dateTime, ref times, ref processCounterValues, ref pcCounterValues);
                //dateTime은 가장 처음에 startTime과 동일하게 들어가서
                //log의 초기 시작점을 찾아야 한다.
                //GetOneHourLog에 첫 1회 이용된 이후 dateTime은 분, 초가 초기화되어,
                //시간단위로 생성된 로그파일에 접근한다.
                dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 0, 0);
                dateTime = dateTime.AddHours(1);
            }
            
            return new Tuple<List<DateTime>, Dictionary<string, Dictionary<string, List<float>>>, Dictionary<string, List<float>>>(times, processCounterValues, pcCounterValues);
        }

        public string[] GetProcessCounterNames()
        {
            return processCounterNames;
        }
        public int GetProcessCounterCount()
        {
            return processCounterCount;
        }

        public string[] GetPCCounterNames()
        {
            return pcCounterNames;
        }
        public int GetPCCounterCount()
        {
            return pcCounterCount;
        }

    }
}
