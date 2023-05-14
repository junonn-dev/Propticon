using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringProcess.Data
{
    public class MeasureDataDto
    {
        public DateTime MeasureTime { get; set; }
        // map 탐색 순서 : PID -> 카운터 이름 -> 측정 값
        public Dictionary<int, Dictionary<string, float>> ProcessMeasureInfo { get; set; }
        public Dictionary<string, float> DiskFreeSpacePercent { get; set; }
        public Dictionary<string, List<float>> PcPerformanceInfo { get; set; }

        public MeasureDataDto(DateTime measureTime)
        {
            MeasureTime = measureTime;
            ProcessMeasureInfo = new Dictionary<int, Dictionary<string, float>>();
            DiskFreeSpacePercent = new Dictionary<string, float>();
            PcPerformanceInfo = new Dictionary<string, List<float>>();
        }
    }
}
