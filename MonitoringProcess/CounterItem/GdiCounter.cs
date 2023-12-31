﻿using MonitorigProcess.CounterItem;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringProcess.CounterItem
{
    public class GdiCounter : Counter
    {
        //Process의 GDI 객체 개수 반환
        //hProcess는 프로세스의 핸들 번호,  
        [DllImport("User32")]
        private extern static int GetGuiResources(IntPtr hProcess, int uiFlags);

        private Process process; 

        public GdiCounter(int pid, string counterName, bool recordWorstAscd = false) : base(pid, counterName, recordWorstAscd)
        {
            process = Process.GetProcessById(pid);
        }

        public override float GetNextValue()
        {
            float value = 0;
            try
            {
                value = GetGuiResources(process.Handle, 0);
            }
            catch
            {
                return value;
            }
            CheckStatisticValue(value);
            return value;
        }      
    }
}
