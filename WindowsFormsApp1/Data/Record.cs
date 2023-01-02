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
        public float value;
        public DateTime recordTime;
    }
}