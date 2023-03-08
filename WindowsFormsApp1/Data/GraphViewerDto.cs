using System.Collections.Generic;

namespace WindowsFormsApp1.Data
{
    public class GraphViewerDto
    {
        public string reportFileName { get; set; }
        public string totalTime { get; set; }
        public string startTime { get; set; }
        public string stopTime { get; set; }
        public string processCount { get; set; }

        public string mostCpuUsedProcess { get; set; }
        public string mostMemoryUsedProcess { get; set; }

        public double[] xData { get; set; }
        /// <summary>
        /// Map 탐색 순서 : processName -> counterName -> value 
        /// </summary>
        public Dictionary<string, Dictionary<string, List<float>>> yData { get; set; }
        public string[] counterNames { get; set; }
        public int counterCount { get; set; }

    }
}
