using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.CounterItem;

namespace WindowsFormsApp1.UserControls
{
    public partial class uscRealTimeProcessView : UserControl
    {
        public uscRealTimeProcessView()
        {
            InitializeComponent();
            testNum = 0;
        }

        public uscRealTimeProcessView(Form1 form, int PID) : this()
        {
            form.measureEvents[PID] = HandleLogEvent;
        }

        //public void SetWorstUpdateEventHandler(WorstList worstList)
        //{
        //    worstList.updateEvent += HandleWorstUpdateEvent;
        //}

        public void HandleLogEvent(object sender, DataEventArgs e)
        {
            lboxRealTimeLog.Invoke(new Action(delegate () { lboxRealTimeLog.Items.Insert(0, e.message); }));
                
            //TODO : Worst List 표현

        }

        public int testNum { get; set; }
        public void HandleCPUWorstUpdateEvent(object sender, DataEventArgs e)
        {
            testNum++;
            var testgroup = lviewWorstList.Groups[0].Items.Add(testNum.ToString());


            SortedDictionary<float, List<DateTime>> list = e.worstList.list;
            int id = 1;
            var group = lviewWorstList.Groups["CPU Usage"];
            foreach (KeyValuePair<float, List<DateTime>> item in list)
            {
                string strValue = item.Key.ToString();
                string strId = id.ToString();
                id++;
                group.Items.Add(strId, strId, strId);
                group.Items[strId].SubItems.Add(strValue);

                var times = item.Value;
                for(int i=0;i<times.Count;i++)
                {
                    group.Items[strId].SubItems.Add(times[i].ToString());
                }
            }
            
        }

        public void HandleMemoryWorstUpdateEvent(object sender, DataEventArgs e)
        {

        }
    }
}
