using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Data;

namespace WindowsFormsApp1.CounterItem
{
    public class WorstList
    {
        private readonly int timeReserve = 10;
        private readonly int worstCount = 5;
        public int PID { get; set; }
        public ResourceType type { get; set; }

        public event EventHandler<DataEventArgs> updateEvent;

        public SortedDictionary<float, List<DateTime>> list { get; }

        public WorstList()
        {          
            //내림차순 정렬 위해
            list = new SortedDictionary<float, List<DateTime>>(Comparer<float>.Create((x,y)=>y.CompareTo(x)));
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
                    list.Remove(list.First().Key);
                }
                OnRaiseUpdateEvent(new DataEventArgs(this));
            }
        }

        private void OnRaiseUpdateEvent(DataEventArgs e)
        {
            var eventHandler = updateEvent;
            if(eventHandler != null)
            {
                eventHandler(this, e);
            }
        }
    }
}
