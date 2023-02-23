using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Data
{
    public class ResultSnapshot
    {
        public class ResultValues
        {
            public float minValue { get; }
            public float maxValue { get; }
            public double average { get; }

            public ResultValues(float minValue, float maxValue, double average)
            {
                this.minValue = minValue;
                this.maxValue = maxValue;
                this.average = average;
            }
        }

        public ResultSnapshot()
        {
            this.mapResult = new Dictionary<int, Dictionary<string, ResultValues>>();
        }

        public Dictionary<int, Dictionary<string, ResultValues>> mapResult { get; set; }
    }
}
