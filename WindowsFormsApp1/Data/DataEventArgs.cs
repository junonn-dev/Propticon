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
        public WorstList worstList { get; set; }

        public DataEventArgs(string message, WorstList worstList)
        {
            this.message = message;
            this.worstList = worstList;
        }
    }
}
