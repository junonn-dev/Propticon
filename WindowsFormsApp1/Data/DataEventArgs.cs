using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CounterItem;

namespace WindowsFormsApp1.Data
{
    public class DataEventArgs
    {
        public string message { get; set; }
        public WorstList cpuWorst { get; set; }
        public WorstList memoryWorst { get; set; }

        public DataEventArgs(string message)
        {
            this.message = message;
        }

        public DataEventArgs(WorstList cpuWorst)
        {
            this.message = message;
            this.worstList= worstList;

        }
    }
}
