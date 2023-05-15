using MonitoringProcess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonitoringProcess.Repository
{
    public class WarnDataRepository
    {
        public List<MeasureDataDto> WarnDataList { get; set; }
        private string warnDataWriteDirectory;
        private string warnDataCopyDirectory;
        private Thread fileWriteThread;

        public WarnDataRepository(string directory)
        {
            WarnDataList = new List<MeasureDataDto>();
            warnDataCopyDirectory = directory;
            fileWriteThread = new Thread(WriteAllReservedWarnData);
        }

        public void AddWarnData(MeasureDataDto dto)
        {
            WarnDataList.Add(dto);
        } 

        public void WriteAllReservedWarnData()
        {
            while (true)
            {
                //짝수 분 이면
                if((DateTime.Now.Minute & 1) == 0)
                {

                }
                Thread.Sleep(1000);
            }
        }

        //Flush 진행 시, 2n 분 상관 없이 copy 
        public void FlushListAndStopWriting()
        {
            
        }

        public void CopyFile()
        {

        }
    }
}
