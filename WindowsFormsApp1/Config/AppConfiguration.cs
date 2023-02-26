using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Config
{
    public static class AppConfiguration
    {
        public static readonly string logRootDirectory =
            ConfigurationManager.AppSettings["LogRootDirectory"];

        public static readonly string reportDirectory = 
            ConfigurationManager.AppSettings["reportDirectory"];

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
    }
}
