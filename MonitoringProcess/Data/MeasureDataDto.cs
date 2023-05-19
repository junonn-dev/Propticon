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
        public Dictionary<SelectedProcess, Dictionary<string, float>> ProcessMeasureInfo { get; set; }
        public Dictionary<string, float> DiskSpacePercent { get; set; }
        public Dictionary<string, float> PcPerformanceInfo { get; set; }

        public MeasureDataDto(DateTime measureTime)
        {
            MeasureTime = measureTime;
            ProcessMeasureInfo = new Dictionary<SelectedProcess, Dictionary<string, float>>();
            DiskSpacePercent = new Dictionary<string, float>();
            PcPerformanceInfo = new Dictionary<string, float>();
        }
    }
}
