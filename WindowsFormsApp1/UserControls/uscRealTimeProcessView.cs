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

        public uscRealTimeProcessView(Measure form, int PID, string processName) : this()
        {
            form.measureEvents[PID] = HandleLogEvent;
            lblPid.Text = PID.ToString();
            lblProcessName.Text = processName;

            dgvStatistics.ColumnCount = 4;
            dgvStatistics.ColumnHeadersVisible = true;
            dgvStatistics.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStatistics.AllowUserToAddRows = false;
            dgvStatistics.AllowUserToDeleteRows = false;
            dgvStatistics.AllowUserToOrderColumns = true;
            dgvStatistics.AllowDrop = false;
            dgvStatistics.AllowUserToResizeColumns = false;
            dgvStatistics.AllowUserToResizeRows = false;
            dgvStatistics.ReadOnly = true;
            dgvStatistics.Columns[0].Name = "counter";
            dgvStatistics.Columns[1].Name = "min";
            dgvStatistics.Columns[2].Name = "max";
            dgvStatistics.Columns[3].Name = "avg";

            dgvStatistics.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvStatistics.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvStatistics.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvStatistics.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            string rowDefault = "-";
            string[] row1 = new string[] { "cpu", rowDefault, rowDefault, rowDefault };
            string[] row2 = new string[] { "mem", rowDefault, rowDefault, rowDefault };
            string[] row3 = new string[] { "thread", rowDefault, rowDefault, rowDefault };
            string[] row4 = new string[] { "handle", rowDefault, rowDefault, rowDefault };

            dgvStatistics.Rows.Add(row1);
            dgvStatistics.Rows.Add(row2);
            dgvStatistics.Rows.Add(row3);
            dgvStatistics.Rows.Add(row4);

        }

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

            dgvStatistics.Rows[0].Cells[1].Value = e.processSet.processorTimeCounter.GetMinValue().ToString();
            dgvStatistics.Rows[0].Cells[2].Value = e.processSet.processorTimeCounter.GetMaxValue().ToString();
            dgvStatistics.Rows[0].Cells[3].Value = Math.Round(e.processSet.processorTimeCounter.GetAverage(),3).ToString();

            dgvStatistics.Rows[1].Cells[1].Value = e.processSet.workingSetCounter.GetMinValue().ToString();
            dgvStatistics.Rows[1].Cells[2].Value = e.processSet.workingSetCounter.GetMaxValue().ToString();
            dgvStatistics.Rows[1].Cells[3].Value = Math.Round(e.processSet.workingSetCounter.GetAverage(),3).ToString();

            dgvStatistics.Rows[2].Cells[1].Value = e.processSet.threadCountCounter.GetMinValue().ToString();
            dgvStatistics.Rows[2].Cells[2].Value = e.processSet.threadCountCounter.GetMaxValue().ToString();
            dgvStatistics.Rows[2].Cells[3].Value = Math.Round(e.processSet.threadCountCounter.GetAverage()).ToString();

            dgvStatistics.Rows[3].Cells[1].Value = e.processSet.handleCountCounter.GetMinValue().ToString();
            dgvStatistics.Rows[3].Cells[2].Value = e.processSet.handleCountCounter.GetMaxValue().ToString();
            dgvStatistics.Rows[3].Cells[3].Value = Math.Round(e.processSet.handleCountCounter.GetAverage()).ToString();
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
