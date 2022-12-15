using System;

namespace WindowsFormsApp1
{
    public enum ResourceType
    {
        Default,
        CPU,
        Memory
    };

    struct Record 
    {
        public dynamic value;
        public DateTime recordTime;
    }
}