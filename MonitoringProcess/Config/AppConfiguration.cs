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

        public static readonly List<string> pcCounterNames 
            = new List<string>(new PerformanceCounterCategory("LogicalDisk").GetInstanceNames().TakeWhile(str => str.Contains(":")));

    }
}
