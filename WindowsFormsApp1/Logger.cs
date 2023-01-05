using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Logger
    {
        //TODO : Log Path 결정, 경로 인식 방법, 이름 규칙
        private static readonly string baseLogPath = "C:\\Logs\\";
        private static StreamWriter sw;

        //Singleton
        //싱글톤 사용은 제약이 많을 듯, 수정 예정
        private Logger() {
            if (!Directory.Exists(baseLogPath))
            {
                Directory.CreateDirectory(baseLogPath);
            }
        }
        private static Logger instance = null;
        public static Logger GetInstance()
        {
            if(instance is null)
            {              
                //sw = new StreamWriter(baseLogPath, true);
                instance = new Logger();
            }
            return instance;
        }

        public bool GetFileExist(string fileName)
        {
            if (File.Exists(baseLogPath + fileName))
                return true;

            return false;
        }

        //개발용 api
        //Logger 객체 사용 시 반드시 SetFileName 지정해야 함
        //지정된 파일 이름으로 baseLogPath에 하나의 파일만 생성됨
        //파일 경로 규칙 생성 후 별도 파일이름 지정 없이 Logger 객체 사용할 수 있도록 바꾸는 것이 좋을 듯
        internal void SetFileName(string fileName)
        {
            //if (GetFileExist(fileName))
            //    return;

            if(!ReferenceEquals(sw, null))
            {
                sw.Close();
            }
            //sw = new StreamWriter(baseLogPath + fileName,true,Encoding.Unicode);
            sw = new StreamWriter(baseLogPath + fileName,true,Encoding.GetEncoding("utf-8"));
        }

        public void WriteLog(string log)
        {
            try
            {
                //DateTime dTime = DateTime.Now;
                //string LogInfo = $"{dTime:yyyy/MM/dd hh:mm:ss,} {log}";
                sw.WriteLine(log);
                sw.Flush();
            }
            catch
            {
                sw.WriteLine("Log Exception occured.");
            }
        }

        public string GetBaseLogPath()
        {
            return baseLogPath;
        }
    }
}
