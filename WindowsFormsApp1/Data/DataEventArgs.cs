﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CounterItem;

namespace WindowsFormsApp1.Data
{
    public class DataEventArgs : EventArgs
    {
        public string message { get; set; }
        //public WorstList worstList { get; set; }
        public WorstList memoryWorst { get; set; }
        public WorstList cpuWorst { get; set; }

        public DataEventArgs(string message, WorstList cpuWorst, WorstList memoryWorst)
        {
            this.message = message;
            this.cpuWorst = cpuWorst;
            this.memoryWorst = memoryWorst;
        }
    }
}
