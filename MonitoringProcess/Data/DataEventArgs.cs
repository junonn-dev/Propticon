using System;
using MonitorigProcess.CounterItem;

namespace MonitorigProcess.Data
{
    public class DataEventArgs : EventArgs
    {
        public string message { get; set; }

        public ProcessSet processSet { get; set; }


        public DataEventArgs(string message, ProcessSet processSet)
        {
            this.message = message;
            this.processSet = processSet;
        }


    }
}
