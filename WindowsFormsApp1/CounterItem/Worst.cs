using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CounterItem
{
    class Worst
    {
        public int worstCount { get; }

        private List<Record> list;

        public Worst(int worstCount)
        {
            this.worstCount = worstCount;
        }

        public Record GetLastRecord()
        {
            return list.Last();
        }

        public void AddData(Record record)
        {
            if (list.Count < worstCount)
            {
                list.Add(record);
                return;
            }

            if(GetLastRecord().value )
        }
    }
}
