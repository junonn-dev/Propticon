using System.Collections.Generic;

namespace MonitorigProcess.Data
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
        public Dictionary<string, Dictionary<string, List<float>>> yDataProcessPerformance { get; set; }
        public Dictionary<string, List<float>> yDataPCPerformance { get; set; }
        public string[] processCounterNames { get; set; }
        public int processCounterCount { get; set; }

        public string[] pcCounterNames { get; set; }
        public int pcCounterCount { get; set; }

    }
}
