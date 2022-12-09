using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class MeasureItem<T> where T : struct
    {
        private PerformanceCounter performanceCounter;

        public T minValue { get; set; }
        public T maxValue { get; set; }


    }
}
