using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsFormsApp1.Data;

namespace WindowsFormsApp1
{
    public class Logger
    {
        //TODO : Log Path 결정, 경로 인식 방법, 이름 규칙
        private static readonly string baseLogPath = "C:\\Logs\\";
        private static string fileName;
        private static StreamWriter sw;
        private static Queue<KeyValuePair<DateTime, string>> buffer;
        private static readonly int threadPeriod = 2000;
        private static Form1 mainFormReference;
        private readonly string dateTimeFormat = "yyyy-MM-dd-HH";
        private readonly string logExtensionFormat = ".csv";

        //Singleton
        private Logger() {
            if (!Directory.Exists(baseLogPath))
            {
                Directory.CreateDirectory(baseLogPath);
            }
            fileName = DateTime.Now.ToString(dateTimeFormat) +"_"+ logExtensionFormat;

            //임시 객체 초기화
            sw = StreamWriter.Null;
            StartLogWriteThread();
        }
        private static Logger instance = null;
        public static Logger GetInstance(Form1 form)
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
            int emptyTolerance = 0;
            bool isWriting = true;

            while (true)
            {
                string logFileName = "";
                string log = "";
                bool isBufferEmpty = true;
                string logTime = "";

                lock (buffer)
                {
                    if (buffer.Count != 0)
                    {
                        KeyValuePair<DateTime, string> pair = buffer.Dequeue();
                        logTime = pair.Key.ToString();
                        logFileName = pair.Key.ToString(dateTimeFormat) + logExtensionFormat;
                        log = pair.Value;
                        isBufferEmpty = false;
                        emptyTolerance = 0;
                        isWriting = true;
                    }
                }

                lock (sw)
                {
                    if (isBufferEmpty)
                    {
                        if (isWriting && emptyTolerance > 5)
                        {
                            fileName += "closed";
                            try
                            {
                                sw.Close();
                            }
                            catch
                            {
                                //sw close 시도했을 때 이미 close 되었거나 예외 발생하면 그냥 넘어감
                            }
                            isWriting = false;
                        }
                        else
                        {
                            emptyTolerance++;
                        }
                        Thread.Sleep(threadPeriod);                           
                        continue;
                    }

                    //시간이 다른 로그 발생 시, 기존 writer는 close, 새 writer 생성
                    if (fileName != logFileName)
                    {
                        fileName = logFileName;
                        try
                        {
                            sw.Close();
                        }
                        catch
                        {

                        }

                        sw = new StreamWriter(baseLogPath + fileName, true, Encoding.GetEncoding("utf-8"));
                        sw.WriteLine(GetCurrentLogHeader());
                    }

                    //close 된 sw는 여기 올 수 없게 끔
                    sw.WriteLine(log);
                    sw.Flush();
                }
                Thread.Sleep(threadPeriod);
            }
        }

        private void StartLogWriteThread()
        {
            Thread logWriteThread = new Thread(WriteLog);
            logWriteThread.Start();
        }

        private string GetCurrentLogHeader()
        {
            StProcess[] sProcess = mainFormReference.sProcess;
            int iProcessMaxCnt = mainFormReference.iProcessMaxCnt;
            StringBuilder sb = new StringBuilder();
            sb.Append("Time").Append(",");
            for (int j = 0; j < iProcessMaxCnt; j++)
            {
                sb
                .Append("cpu_" + sProcess[j].InstanceName).Append(",")
                .Append("mem_" + sProcess[j].InstanceName).Append(",")
                .Append("thread_" + sProcess[j].InstanceName).Append(",")
                .Append("handle_" + sProcess[j].InstanceName).Append(",");
            }
            return sb.ToString();
        }


        public static string GetBaseLogPath()
        {
            return baseLogPath;
        }
    }
}
