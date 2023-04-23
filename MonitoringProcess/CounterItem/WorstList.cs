using System;
using System.Collections.Generic;
using System.Linq;

namespace MonitorigProcess.CounterItem
{
    public class WorstList
    {
        private readonly int timeReserve = 10;
        private readonly int worstCount = 5;

        public SortedDictionary<float, List<DateTime>> list { get; }

        public WorstList(bool recordWorstAscd)
        {          
            if(recordWorstAscd is true)
            {
                //SortedDictionary의 Default 정렬 순서는 Ascending
                list = new SortedDictionary<float, List<DateTime>>();
            }
            else
            {
                //내림차순 정렬 위해
                list = new SortedDictionary<float, List<DateTime>>(Comparer<float>.Create((x, y) => y.CompareTo(x)));
            }
        }

        public void CheckRecord(float value, DateTime timeStamp)
        {
            if(value == 0)
            {
                return;
            }
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

            var minValue = list.Last().Key;
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
                    list.Remove(list.Last().Key);
                }
            }
        }
    }
}
