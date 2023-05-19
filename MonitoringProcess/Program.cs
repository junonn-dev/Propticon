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
            public const string iniConfigSection = "Config";
            public const string iniConfigPidSection = "Config-pid";
            public const string iniOptions = "Options";
        }
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
