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
        }

        public uscRealTimeProcessView(Form1 form, int PID) : this()
        {
            form.measureEvents[PID] = HandleLogEvent;
        }

        public void SetWorstUpdateEventHandler(WorstList worstList)
        {
            worstList.updateEvent += HandleWorstUpdateEvent;
        }

        private void HandleLogEvent(object sender, DataEventArgs e)
        {
            lboxRealTimeLog.Invoke(new Action(delegate () { lboxRealTimeLog.Items.Insert(0, e.message); }));
                
            //TODO : Worst List 표현

        }

        private void HandleWorstUpdateEvent(object sender, DataEventArgs e)
        {
            SortedDictionary<float, List<DateTime>> list = e.cpuWorstList.list;
            foreach (KeyValuePair<float, List<DateTime>> item in list)
            {
                lviewWorstList.Items.Insert(0, item.Key.ToString());
                foreach (DateTime time in item.Value)
                {
                    //lviewWorstList.Items[0].

                }
            }
            while (list.Count > 0)
            {
                //list

            }
        }
    }
}
