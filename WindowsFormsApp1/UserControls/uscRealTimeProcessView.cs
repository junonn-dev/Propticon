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
using static System.Windows.Forms.ListView;

namespace WindowsFormsApp1.UserControls
{
    public partial class uscRealTimeProcessView : UserControl
    {
        public uscRealTimeProcessView()
        {
            InitializeComponent();
            lviewWorstList.Items.Clear();
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
            lboxRealTimeLog.Invoke(new Action(delegate () { 
                lboxRealTimeLog.Items.Insert(0, e.message); 
                if(lboxRealTimeLog.Items.Count >20)
                    lboxRealTimeLog.Items.RemoveAt(20); 
            }));

            lviewWorstList.Invoke(new Action(delegate ()
            {
                parseWorstList(e.processSet.processorTimeCounter.worstList.list, "CPU Usage");
                parseWorstList(e.processSet.workingSetCounter.worstList.list, "Memory Usage");
            }));
        }

        private void parseWorstList(SortedDictionary<float, List<DateTime>> map, string groupName)
        {
            //받아온 worstList를 deep copy하는 이유
            //스레드 주기 짧아지면 참조한 worst list가 업데이트됨
            // -> 아래 foreach에서 list 내용 변경으로 exception 발생
            //여기에서 받아온 list의 상태를 복사함
            int listSize = map.Count;
            var list = new KeyValuePair<float, List<DateTime>>[listSize];
            map.CopyTo(list, 0);

            int id = 1;
            foreach (KeyValuePair<float, List<DateTime>> item in list)
            {
                string itemKey = groupName + id;
                if (!lviewWorstList.Items.ContainsKey(itemKey))
                {
                    lviewWorstList.Items.Add(itemKey, id.ToString(), "");
                    lviewWorstList.Items[itemKey].SubItems.Add("");
                    lviewWorstList.Items[itemKey].SubItems.Add("");
                    lviewWorstList.Items[itemKey].Group = lviewWorstList.Groups[groupName];
                }

                id++;
                string strValue = item.Key.ToString();                
                lviewWorstList.Items[itemKey].SubItems[1].Text = strValue;

                List<DateTime> times = item.Value;
                lviewWorstList.Items[itemKey].SubItems[2].Text
                    = times[0].ToString();
            }
            
        }
    }
}
