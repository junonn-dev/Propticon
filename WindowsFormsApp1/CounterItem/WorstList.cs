using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CounterItem
{
    class WorstList
    {
        private readonly int timeReserve = 10;
        private readonly int worstCount = 5;

        private SortedDictionary<dynamic, List<DateTime>> list;

        public WorstList()
        {
            list = new SortedDictionary<dynamic, List<DateTime>>();
        }

        public void CheckRecord(Record record)
        {
            if (list.Count < worstCount)
            {
                if (!list.ContainsKey(record.value))
                {
                    list[record.value] = new List<DateTime>(timeReserve);
                }
                else if(list[record.value].Count < timeReserve)
                {
                    list[record.value].Add(record.recordTime);
                }               
                return;
            }

            var minValue = list.First().Key;
            if (minValue > record.value)
            {
                return;
            }
            else if(minValue == record.value)
            {
                list[minValue].Add(record.recordTime);
            }
            else
            {
                if (!list.ContainsKey(record.value))
                {
                    list[record.value] = new List<DateTime>(timeReserve);
                }
                else if (list[record.value].Count < timeReserve)
                {
                    list[record.value].Add(record.recordTime);
                }
                
                if(list.Count>= worstCount)
                {
                    list.Remove(list.First().Key);
                }
            }


        }
    }
}
