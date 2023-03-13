using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MonitorigProcess.Helper
{
    static class InstanceNameConvertor
    {
        // pid로부터 instance 이름 얻기
        //https://stackoverflow.com/questions/9115436/performance-counter-by-process-id-instead-of-name
        public static string GetProcessInstanceName(int pid, string processName)
        {
            PerformanceCounterCategory cat = new PerformanceCounterCategory("Process");

            IEnumerable<string> instances = cat.GetInstanceNames().Where(str => str.Contains(processName));
            foreach (string instance in instances)
            {
                using (PerformanceCounter cnt = new PerformanceCounter("Process", "ID Process", instance, true))
                {
                    int val = (int)cnt.RawValue;
                    if (val == pid)
                    {
                        return instance;
                    }
                }
            }
            throw new Exception("Could not find performance counter");
        }
    }
}
