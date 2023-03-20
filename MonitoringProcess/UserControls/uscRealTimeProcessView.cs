using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MonitorigProcess.Data;

namespace MonitorigProcess.UserControls
{
    public partial class uscRealTimeProcessView : UserControl
    {
        private string cpuGroupName = "CPU Usage";
        private string memoryGroupName = "Memory Usage";

        public uscRealTimeProcessView()
        {
            InitializeComponent();
            lviewWorstList.Items.Clear();
        }

        public uscRealTimeProcessView(Measure form, int PID, string processName) : this()
        {
            form.processMeasureEvents[PID] = HandleLogEvent;
            lblPid.Text = PID.ToString();

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
            string[] row1 = new string[] { "CPU Usage", rowDefault, rowDefault, rowDefault };
            string[] row2 = new string[] { "Memory(MB)", rowDefault, rowDefault, rowDefault };
            string[] row3 = new string[] { "Thread", rowDefault, rowDefault, rowDefault };
            string[] row4 = new string[] { "Handle", rowDefault, rowDefault, rowDefault };
            string[] row5 = new string[] { "GDI Object", rowDefault, rowDefault, rowDefault };

            dgvStatistics.Rows.Add(row1);
            dgvStatistics.Rows.Add(row2);
            dgvStatistics.Rows.Add(row3);
            dgvStatistics.Rows.Add(row4);
            dgvStatistics.Rows.Add(row5);


        }

        public void HandleLogEvent(object sender, ProcessMeasureEventArgs e)
        {
            lboxRealTimeLog.Invoke(new Action(delegate () { 
                lboxRealTimeLog.Items.Insert(0, e.message); 
                if(lboxRealTimeLog.Items.Count >20)
                    lboxRealTimeLog.Items.RemoveAt(20); 
            }));

            lviewWorstList.Invoke(new Action(delegate ()
            {
                parseWorstList(e.processSet.processorTimeCounter.worstList.list, cpuGroupName);
                parseWorstList(e.processSet.workingSetCounter.worstList.list, memoryGroupName);
            }));

            var cpuMin = e.processSet.processorTimeCounter.GetMinValue();
            if(cpuMin != float.MaxValue)
            {
                dgvStatistics.Rows[0].Cells[1].Value = Math.Round(e.processSet.processorTimeCounter.GetMinValue(), 3).ToString();
            }
            dgvStatistics.Rows[0].Cells[2].Value = Math.Round(e.processSet.processorTimeCounter.GetMaxValue(),3).ToString();
            dgvStatistics.Rows[0].Cells[3].Value = Math.Round(e.processSet.processorTimeCounter.GetAverage(),3).ToString();

            dgvStatistics.Rows[1].Cells[1].Value = Math.Round(e.processSet.workingSetCounter.GetMinValue() / (1024 * 1024),3).ToString();
            dgvStatistics.Rows[1].Cells[2].Value = Math.Round(e.processSet.workingSetCounter.GetMaxValue() / (1024 * 1024), 3).ToString();
            dgvStatistics.Rows[1].Cells[3].Value = Math.Round(e.processSet.workingSetCounter.GetAverage() / (1024 * 1024), 3).ToString();

            dgvStatistics.Rows[2].Cells[1].Value = e.processSet.threadCountCounter.GetMinValue().ToString();
            dgvStatistics.Rows[2].Cells[2].Value = e.processSet.threadCountCounter.GetMaxValue().ToString();
            dgvStatistics.Rows[2].Cells[3].Value = Math.Round(e.processSet.threadCountCounter.GetAverage()).ToString();

            dgvStatistics.Rows[3].Cells[1].Value = e.processSet.handleCountCounter.GetMinValue().ToString();
            dgvStatistics.Rows[3].Cells[2].Value = e.processSet.handleCountCounter.GetMaxValue().ToString();
            dgvStatistics.Rows[3].Cells[3].Value = Math.Round(e.processSet.handleCountCounter.GetAverage()).ToString();

            var gdiMin = e.processSet.gdiCountCounter.GetMinValue();
            if (gdiMin != float.MaxValue)
            {
                dgvStatistics.Rows[4].Cells[1].Value = e.processSet.gdiCountCounter.GetMinValue().ToString();
            }
            dgvStatistics.Rows[4].Cells[2].Value = e.processSet.gdiCountCounter.GetMaxValue().ToString();
            dgvStatistics.Rows[4].Cells[3].Value = Math.Round(e.processSet.gdiCountCounter.GetAverage()).ToString();


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
                string strValue = "";
                if (groupName == cpuGroupName)
                {
                    strValue = Math.Round(item.Key, 3).ToString();
                }
                else if(groupName == memoryGroupName)
                {
                    strValue = Math.Round(item.Key/(1024*1024), 3).ToString();
                }
                lviewWorstList.Items[itemKey].SubItems[1].Text = strValue;

                List<DateTime> times = item.Value;
                lviewWorstList.Items[itemKey].SubItems[2].Text
                    = times[0].ToString();
            }
            
        }
    }
}
