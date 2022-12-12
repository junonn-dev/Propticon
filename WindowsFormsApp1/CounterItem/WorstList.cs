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

        private SortedDictionary<float, List<DateTime>> list;

        public WorstList()
        {
            list = new SortedDictionary<float, List<DateTime>>();
        }

        public void CheckRecord(float value, DateTime timeStamp)
        {
            if (list.Count < worstCount)
            {
                if (!list.ContainsKey(value))
                {
                    list[value] = new List<DateTime>(timeReserve);
                }
                if(list[value].Count < timeReserve)
                {
                    list[value].Add(timeStamp);
                }               
                return;
            }

            var minValue = list.First().Key;
            if (minValue > value)
            {
                return;
            }
            else
            {
                if (!list.ContainsKey(value))
                {
                    list[value] = new List<DateTime>(timeReserve);
                }
                if (list[value].Count < timeReserve)
                {
                    list[value].Add(timeStamp);
                }
                
                if(list.Count> worstCount)
                {
                    list.Remove(list.First().Key);
                }
            }


        }
    }
}
