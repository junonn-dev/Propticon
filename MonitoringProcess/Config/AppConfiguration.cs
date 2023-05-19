using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;

namespace MonitorigProcess.Config
{
    public static class AppConfiguration
    {
        public static readonly string logRootDirectory =
            ConfigurationManager.AppSettings["LogRootDirectory"];

        public static readonly string logPartialDirectoryFormat =
            ConfigurationManager.AppSettings["logPartialDirectoryFormat"];

        public static readonly string logFilenameFormat =
           ConfigurationManager.AppSettings["logFilenameFormat"];

        public static readonly string reportFileFormat = 
            ConfigurationManager.AppSettings["reportFileFormat"];

        public static readonly string xmlDateTimeFormat = 
            ConfigurationManager.AppSettings["xmlDateTimeFormat"];

        public static readonly string warnDataFileFormat =
            ConfigurationManager.AppSettings["warnDataFileFormat"];

        public static readonly string warnDataTimeRecordFormat =
            ConfigurationManager.AppSettings["warnDataTimeRecordFormat"];
        
        public static readonly string totalCPU =
            ConfigurationManager.AppSettings["totalCPU"];

        public static readonly string totalMemory =
            ConfigurationManager.AppSettings["totalMemory"];

        public static readonly string diskSpace =
           ConfigurationManager.AppSettings["diskSpace"];

        public static readonly string processCPU = 
            ConfigurationManager.AppSettings["processCPU"];

        public static readonly string processMemory = 
            ConfigurationManager.AppSettings["processMemory"];

        public static readonly string processThread = 
            ConfigurationManager.AppSettings["processThread"];

        public static readonly string processHandle = 
            ConfigurationManager.AppSettings["processHandle"];

        public static readonly string processGDI =
            ConfigurationManager.AppSettings["processGDI"];

        public static readonly List<string> processCounterNames = new List<string>
        {
            ConfigurationManager.AppSettings["processCPU"],
            ConfigurationManager.AppSettings["processMemory"],
            ConfigurationManager.AppSettings["processThread"],
            ConfigurationManager.AppSettings["processHandle"],
            ConfigurationManager.AppSettings["processGDI"],
        };

        //disk 이름만 관리
        public static readonly List<string> diskNames = new List<string>(new PerformanceCounterCategory("LogicalDisk").GetInstanceNames().Where(str => str.Contains(":")));

        //not-process-counter인 전체 리스트를 포함
        public static readonly List<string> pcCounterNames 
            = new List<string>(diskNames);

        public static readonly string iniPath = System.Windows.Forms.Application.StartupPath + "\\MonitorProcess.ini";

    }
}
