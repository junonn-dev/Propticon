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

        //public void SetWorstUpdateEventHandler(WorstList worstList)
        //{
        //    worstList.updateEvent += HandleWorstUpdateEvent;
        //}

        public void HandleLogEvent(object sender, DataEventArgs e)
        {
            lboxRealTimeLog.Invoke(new Action(delegate () { lboxRealTimeLog.Items.Insert(0, e.message); }));

            lviewWorstList.Invoke(new Action(delegate ()
            {
                SortedDictionary<float, List<DateTime>> list = e.processSet.processorTimeCounter.worstList.list;
                int id = 1;
                lviewWorstList.Items.Clear();

                foreach (KeyValuePair<float, List<DateTime>> item in list)
                {
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Text = id.ToString();
                    id++;
                    string strValue = item.Key.ToString();
                    string strId = id.ToString();

                    lvItem.SubItems.Add(strValue);                   
                    lvItem.Group = lviewWorstList.Groups["CPU Usage"];

                    List<DateTime> times = item.Value;
                    foreach (DateTime dt in times)
                    {
                        lvItem.SubItems.Add(dt.ToString());
                    }
                    lviewWorstList.Items.Add(lvItem);
                }

                list = e.processSet.workingSetCounter.worstList.list;
                id = 1;
                foreach (KeyValuePair<float, List<DateTime>> item in list)
                {
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Text = id.ToString();
                    id++;
                    string strValue = item.Key.ToString();
                    string strId = id.ToString();

                    lvItem.SubItems.Add(strValue);
                    lvItem.Group = lviewWorstList.Groups["Memory Usage"];

                    List<DateTime> times = item.Value;
                    foreach (DateTime dt in times)
                    {
                        lvItem.SubItems.Add(dt.ToString());
                    }
                    lviewWorstList.Items.Add(lvItem);
                }
            }));
            
        }

    }
}
