using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MonitorigProcess.CounterItem;
using MonitorigProcess.Data;
using MonitoringProcess.Data;
using MonitoringProcess.Helper;

namespace MonitorigProcess.UserControls
{
    public partial class uscRealTimeProcessView : UserControl
    {
        private readonly string cpuGroupName = "CPU Usage";
        private readonly string memoryGroupName = "Memory Usage";
        private readonly string rowDefault = "-";
        public uscRealTimeProcessView()
        {
            InitializeComponent();
            lviewWorstList.Items.Clear();
        }

        public void InitView(Measure form, bool isTotalViewOption = false )
        {
            if (isTotalViewOption)
            {
                form.monitoringStartEvent += InitStatisticsView;
                form.monitoringStartEvent += InitWorstListView;
                label2.Visible = true;
                
                form.pcMeasureEvent += HandlePcPerformanceLogEvent; //pc Performance를 위한 키값은 -1
                label2.Text = "Total Processor : ";
                lblPid.Text = Environment.ProcessorCount.ToString();

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

                string[] row1 = new string[] { "CPU Usage", rowDefault, rowDefault, rowDefault };
                string[] row2 = new string[] { "Memory(MB)", rowDefault, rowDefault, rowDefault };

                dgvStatistics.Rows.Add(row1);
                dgvStatistics.Rows.Add(row2);
            }
            else
            {
                form.monitoringStartEvent += InitStatisticsView;
                form.monitoringStartEvent += InitWorstListView;
                form.processMeasureEvents += HandleLogEvent;

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
        }

        private void InitStatisticsView(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvStatistics.Rows)
            {
                for(int i = 1; i < row.Cells.Count; i++)
                {
                    row.Cells[i].Value = rowDefault;
                }
            }
        }

        public void InitWorstListView(object sender, EventArgs e)
        {
            lviewWorstList.Items.Clear();
        }

        public void HandlePcPerformanceLogEvent(object sender, PCMeasureEventArgs e)
        {
            lboxRealTimeLog.Invoke(new Action(delegate () {
                lboxRealTimeLog.Items.Insert(0, e.Message);
                if (lboxRealTimeLog.Items.Count > 20)
                    lboxRealTimeLog.Items.RemoveAt(20);
            }));

            //available MByte를 측정하기 때문에, 사용중인 메모리량은
            //전체 물리메모리 - available MBytes로 계산함.
            long memMB = TotalPhysicalMemory.GetMBValue();
            var newMemoryWorst = new SortedDictionary<float, List<DateTime>>(Comparer<float>.Create((x, y) => y.CompareTo(x)));
            var availableMBWorst = e.PcPerformanceSet.AvailableMemoryMBytes.worstList.list;
            foreach (KeyValuePair<float, List<DateTime>> item in availableMBWorst)
            {
                float prevKey = item.Key;
                float newKey = memMB - item.Key;

                newMemoryWorst.Add(newKey, item.Value);
            }

            lviewWorstList.Invoke(new Action(delegate ()
            {
                parseWorstList(e.PcPerformanceSet.TotalCpuUsage.worstList.list, cpuGroupName);
                parseWorstList(newMemoryWorst, memoryGroupName, true);
            }));


            var cpuCounter = e.PcPerformanceSet.TotalCpuUsage;
            var availableMemoryCounter = e.PcPerformanceSet.AvailableMemoryMBytes;

            var cpuMin = cpuCounter.GetMinValue();
            if (cpuMin != float.MaxValue)
            {
                dgvStatistics.Rows[0].Cells[1].Value = Math.Round(cpuMin, 3).ToString();
            }
            dgvStatistics.Rows[0].Cells[2].Value = Math.Round(cpuCounter.GetMaxValue(), 3).ToString();
            dgvStatistics.Rows[0].Cells[3].Value = Math.Round(cpuCounter.GetAverage(), 3).ToString();

            dgvStatistics.Rows[1].Cells[1].Value = Math.Round((memMB - availableMemoryCounter.GetMaxValue()), 3).ToString();
            dgvStatistics.Rows[1].Cells[2].Value = Math.Round((memMB - availableMemoryCounter.GetMinValue()), 3).ToString();
            dgvStatistics.Rows[1].Cells[3].Value = Math.Round((memMB - availableMemoryCounter.GetAverage()), 3).ToString();
            
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

            var memMin = e.processSet.workingSetCounter.GetMinValue();
            if (memMin != float.MaxValue)
            {
                dgvStatistics.Rows[1].Cells[1].Value = Math.Round(e.processSet.workingSetCounter.GetMinValue() / (1024 * 1024), 3).ToString();
            }
            dgvStatistics.Rows[1].Cells[2].Value = Math.Round(e.processSet.workingSetCounter.GetMaxValue() / (1024 * 1024), 3).ToString();
            dgvStatistics.Rows[1].Cells[3].Value = Math.Round(e.processSet.workingSetCounter.GetAverage() / (1024 * 1024), 3).ToString();

            var threadMin = e.processSet.threadCountCounter.GetMinValue();
            if (threadMin != float.MaxValue)
            {
                dgvStatistics.Rows[2].Cells[1].Value = Math.Round(threadMin, 3).ToString();
            }
            dgvStatistics.Rows[2].Cells[2].Value = e.processSet.threadCountCounter.GetMaxValue().ToString();
            dgvStatistics.Rows[2].Cells[3].Value = Math.Round(e.processSet.threadCountCounter.GetAverage()).ToString();

            var handleMin = e.processSet.handleCountCounter.GetMinValue();
            if (handleMin != float.MaxValue)
            {
                dgvStatistics.Rows[3].Cells[1].Value = Math.Round(handleMin, 3).ToString();
            }
            dgvStatistics.Rows[3].Cells[2].Value = e.processSet.handleCountCounter.GetMaxValue().ToString();
            dgvStatistics.Rows[3].Cells[3].Value = Math.Round(e.processSet.handleCountCounter.GetAverage()).ToString();

            var gdiMin = e.processSet.gdiCountCounter.GetMinValue();
            if (gdiMin != float.MaxValue)
            {
                dgvStatistics.Rows[4].Cells[1].Value = gdiMin.ToString();
            }
            dgvStatistics.Rows[4].Cells[2].Value = e.processSet.gdiCountCounter.GetMaxValue().ToString();
            dgvStatistics.Rows[4].Cells[3].Value = Math.Round(e.processSet.gdiCountCounter.GetAverage()).ToString();


        }

        private void parseWorstList(SortedDictionary<float, List<DateTime>> map, string groupName, bool isMemoryMB = false)
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
                    strValue = isMemoryMB==true? Math.Round(item.Key, 3).ToString() : Math.Round(item.Key/(1024*1024), 3).ToString();
                }
                lviewWorstList.Items[itemKey].SubItems[1].Text = strValue;

                List<DateTime> times = item.Value;
                lviewWorstList.Items[itemKey].SubItems[2].Text
                    = times[0].ToString();
            }
        }        

        public void ShowInformation(int pid, ProcessPerformance processPerformance)
        {
            this.lblPid.Text = pid.ToString();

            InitWorstListView(null,null);

            parseWorstList(processPerformance.processorTimeCounter.worstList.list, cpuGroupName);
            parseWorstList(processPerformance.workingSetCounter.worstList.list, memoryGroupName);

            var cpuMin = processPerformance.processorTimeCounter.GetMinValue();
            if (cpuMin != float.MaxValue)
            {
                dgvStatistics.Rows[0].Cells[1].Value = Math.Round(processPerformance.processorTimeCounter.GetMinValue(), 3).ToString();
            }
            else
            {
                dgvStatistics.Rows[0].Cells[1].Value = rowDefault;
            }
            dgvStatistics.Rows[0].Cells[2].Value = Math.Round(processPerformance.processorTimeCounter.GetMaxValue(), 3).ToString();
            dgvStatistics.Rows[0].Cells[3].Value = Math.Round(processPerformance.processorTimeCounter.GetAverage(), 3).ToString();

            var memMin = processPerformance.workingSetCounter.GetMinValue();
            if (memMin != float.MaxValue)
            {
                dgvStatistics.Rows[1].Cells[1].Value = Math.Round(processPerformance.workingSetCounter.GetMinValue() / (1024 * 1024), 3).ToString();
            }
            else
            {
                dgvStatistics.Rows[1].Cells[1].Value = rowDefault;
            }
            dgvStatistics.Rows[1].Cells[2].Value = Math.Round(processPerformance.workingSetCounter.GetMaxValue() / (1024 * 1024), 3).ToString();
            dgvStatistics.Rows[1].Cells[3].Value = Math.Round(processPerformance.workingSetCounter.GetAverage() / (1024 * 1024), 3).ToString();

            var threadMin = processPerformance.threadCountCounter.GetMinValue();
            if (threadMin != float.MaxValue)
            {
                dgvStatistics.Rows[2].Cells[1].Value = Math.Round(threadMin, 3).ToString();
            }
            else
            {
                dgvStatistics.Rows[2].Cells[1].Value = rowDefault;
            }
            dgvStatistics.Rows[2].Cells[2].Value = processPerformance.threadCountCounter.GetMaxValue().ToString();
            dgvStatistics.Rows[2].Cells[3].Value = Math.Round(processPerformance.threadCountCounter.GetAverage()).ToString();

            var handleMin = processPerformance.handleCountCounter.GetMinValue();
            if (handleMin != float.MaxValue)
            {
                dgvStatistics.Rows[3].Cells[1].Value = Math.Round(handleMin, 3).ToString();
            }
            else
            {
                dgvStatistics.Rows[3].Cells[1].Value = rowDefault;
            }
            dgvStatistics.Rows[3].Cells[2].Value = processPerformance.handleCountCounter.GetMaxValue().ToString();
            dgvStatistics.Rows[3].Cells[3].Value = Math.Round(processPerformance.handleCountCounter.GetAverage()).ToString();

            var gdiMin = processPerformance.gdiCountCounter.GetMinValue();
            if (gdiMin != float.MaxValue)
            {
                dgvStatistics.Rows[4].Cells[1].Value = gdiMin.ToString();
            }
            else
            {
                dgvStatistics.Rows[4].Cells[1].Value = rowDefault;
            }
            dgvStatistics.Rows[4].Cells[2].Value = processPerformance.gdiCountCounter.GetMaxValue().ToString();
            dgvStatistics.Rows[4].Cells[3].Value = Math.Round(processPerformance.gdiCountCounter.GetAverage()).ToString();
        }

        public void SetPidText(int pid)
        {
            this.lblPid.Text = pid.ToString();
        }
    }
}
