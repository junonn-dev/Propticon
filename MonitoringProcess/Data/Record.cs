using System;

namespace MonitorigProcess
{
    public enum ResourceType
    {
        Default,
        CPU,
        Memory
    };

    struct Record 
    {
        public float value;
        public DateTime recordTime;
    }
}