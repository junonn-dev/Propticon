using System;

namespace WindowsFormsApp1
{
    struct Record<T> where T : struct
    {
        T value;
        DateTime recordTime;
    }
}