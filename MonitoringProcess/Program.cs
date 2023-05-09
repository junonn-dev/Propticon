using System;
using System.Windows.Forms;
using MonitorigProcess.Forms;

namespace MonitorigProcess
{
    static class Program
    {
        public static class Constants
        {
            public const int maxconfig = 30;
        }
        //#region 
        //private int iThreadTime = 2000;  // Thread 주기
        //private bool bLoopState = true;  // while문 Loop 여부

        //private bool bCheck = false;
        //private string strPath;

        //private PerformanceCounter cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total"); // Total Processor의 정보
        //private PerformanceCounter ram = new PerformanceCounter("Memory", "Available MBytes"); // Total Memory 사용량 mb 정보

        ////private string process_name;  // 현재 Program의 Process Name
        //private PerformanceCounter prcess_cpu;

        //List<PerformanceCounter> lpfCounter = new List<PerformanceCounter>();  // 논리 프로세서의 Process 정보를 저장
        //#endregion

        //string message;
        //int iSelected;
        //int iProcessMaxCnt = 0;
        //Process[] allProc = Process.GetProcesses();    //시스템의 모든 프로세스 정보 출력
        //struct StProcess
        //{
        //    public int Pid;
        //    public string ProcessName;
        //};
        //StProcess[] sProcess = new StProcess[Constants.maxconfig];
        //StProcess sProcessTemp;
        //IniFile ini;

        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LayoutForm());
            //Application.Run(new GraphViewer());
        }
    }
}
