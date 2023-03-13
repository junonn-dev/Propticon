namespace MonitorigProcess.CounterItem
{
    public class ProcessSet
    {
        public int pid { get; set; }    
        public string processName { get; set; }     //chrome
        public string instanceName { get; set; }    //chrome#n
        public Counter processorTimeCounter { get; }
        public Counter workingSetCounter { get; }
        public Counter handleCountCounter { get; }
        public Counter threadCountCounter { get; }
        public Counter gdiCountCounter { get; set; }

        public ProcessSet(int pid, string processName, string instanceName)
        {
            this.pid = pid;
            this.processName = processName;
            this.instanceName = instanceName;
            processorTimeCounter = new Counter("Process", "% Processor Time", processName);
            workingSetCounter = new Counter("Process", "Working Set - Private", processName);
            threadCountCounter = new Counter("Process", "Thread Count", processName);
            handleCountCounter = new Counter("Process", "Handle Count", processName);
            
        }
    }
}
