using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using MonitorigProcess.Config;
using MonitorigProcess.Data;
using MonitoringProcess.Data;

namespace MonitorigProcess
{
    public class Logger
    {
        private static readonly string baseLogPath = AppConfiguration.logRootDirectory; /*"C:\\Logs\\";*/ 
        private static string fileName;
        private static StreamWriter streamWriter;
        private static Queue<KeyValuePair<DateTime, string>> buffer;
        private static readonly int threadPeriod = 1000;
        private static Measure mainFormReference;
        private readonly string logFilenameFormat = AppConfiguration.logFilenameFormat;
        private readonly string logPartialDirectoryFormat = AppConfiguration.logPartialDirectoryFormat;
        private readonly string logExtensionFormat = ".csv";
        bool isWriting;
        //private readonly IEnumerable<string> disks;

        //Singleton
        private Logger() {
            if (!Directory.Exists(baseLogPath))
            {
                Directory.CreateDirectory(baseLogPath);
            }
            
            //PC의 disk를 가져와서 각 Disk이름에 해당하는 PCPerformance를 초기화 (ex. C:, D:)
            //disks = new PerformanceCounterCategory("LogicalDisk").GetInstanceNames().TakeWhile(str => str.Contains(":"));

            fileName = DateTime.Now.ToString(logFilenameFormat) +"_"+ logExtensionFormat;
            isWriting = false;

            //임시 객체 초기화
            streamWriter = StreamWriter.Null;
            StartLogWriteThread();
        }
        private static Logger instance = null;
        public static Logger GetInstance(Measure form)
        {
            if(instance is null)
            {
                mainFormReference = form;
                buffer = new Queue<KeyValuePair<DateTime, string>>();
                instance = new Logger();
            }
            return instance;
        }

        public void Log(string log, DateTime logTime)
        {
            lock (buffer)
            {
                buffer.Enqueue(new KeyValuePair<DateTime, string>(logTime, log));
            }

        }

        private void WriteLog()
        {
            //int emptyTolerance = 0;

            string logFileName = "";
            string log = "";
            string logDirectory = "";
            //bool isBufferEmpty = true;

            while (true)
            {
                lock (buffer)
                {

                    //버퍼에 하나 이상 들어왔을 때
                    if (buffer.Count != 0)
                    {
                        //모니터링 초기 진입 시점
                        if (isWriting == false)
                        {
                            isWriting = true;
                            logDirectory = baseLogPath + buffer.Peek().Key.ToString(logPartialDirectoryFormat)+"\\";
                            if (!Directory.Exists(logDirectory))
                            {
                                Directory.CreateDirectory(logDirectory);
                            }
                        }

                        lock (streamWriter)
                        {
                            while (buffer.Count != 0)
                            {
                                KeyValuePair<DateTime, string> pair = buffer.Dequeue();
                                logFileName = pair.Key.ToString(logFilenameFormat) + logExtensionFormat;
                                log = pair.Value;

                                //시간이 다른 로그 발생 시, 기존 writer는 close, 새 writer 생성
                                if (fileName != logFileName)
                                {
                                    fileName = logFileName;
                                    try
                                    {
                                        streamWriter.Close();
                                    }
                                    catch
                                    {

                                    }

                                    streamWriter = new StreamWriter(logDirectory + fileName, true, Encoding.GetEncoding("utf-8"));
                                    streamWriter.WriteLine(GetCurrentLogHeader());
                                }

                                //close 된 sw는 여기 올 수 없게 끔
                                streamWriter.WriteLine(log);
                                streamWriter.Flush();
                            }
                        }
                    }
                }
                Thread.Sleep(threadPeriod);

                //monitoring 종료 직후 buffer에 남아있는 로그 확인
                //로그가 남아있다면 종료처리하지 않고 loop 재시작
                if (isWriting)  //안 쓰고 있을 때 buffer lock 반복 방지
                {
                    lock (buffer)
                    {
                        if (mainFormReference.bLoopState == false && buffer.Count == 0)
                        {
                            fileName = "closed";
                            streamWriter.Close();
                            isWriting = false;
                        }
                    }
                }
            }
        }
        

        private void StartLogWriteThread()
        {
            Thread logWriteThread = new Thread(WriteLog);
            logWriteThread.IsBackground = true;
            logWriteThread.Start();
        }

        private string GetCurrentLogHeader()
        {
            var selectedProcess = Bindings.selectedProcesses;
            StringBuilder sb = new StringBuilder();
            sb.Append("Time").Append(",");
            for (int j = 0; j < Bindings.selectedProcesses.Count; j++)
            {
                sb
                .Append("cpu_" + selectedProcess[j].InstanceName).Append(",")
                .Append("mem_" + selectedProcess[j].InstanceName).Append(",")
                .Append("thread_" + selectedProcess[j].InstanceName).Append(",")
                .Append("handle_" + selectedProcess[j].InstanceName).Append(",")
                .Append("gdi_" + selectedProcess[j].InstanceName).Append(",");
            }
            sb.Append("cpu_total").Append(",")
                .Append("mem_total").Append(",");

            List<string> disks = AppConfiguration.diskNames;
            foreach (var item in disks)
            {
                sb.Append(item).Append(",");
            }
            
            return sb.ToString();
        }

        public bool IsWorking()
        {
            return this.isWriting;
        }
    }
}
