using System;
using MonitorigProcess.CounterItem;

namespace MonitorigProcess.Data
{
    public class DataEventArgs : EventArgs
    {
        public string message { get; set; }

        public ProcessPerformance processSet { get; set; }


        public DataEventArgs(string message, ProcessPerformance processSet)
        {
            this.message = message;
            this.processSet = processSet;
        }


    }
}
