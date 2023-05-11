using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonitorigProcess.CounterItem;
using MonitorigProcess.Data;
using MonitorigProcess.Helper;
using MonitorigProcess.UserControls;
using static MonitorigProcess.Program;
using System.IO;
using MonitorigProcess.Repository;
using MonitoringProcess.Data;
using MonitoringProcess.CounterItem;
using System.ComponentModel;
using MonitoringProcess.Forms;
using MonitorigProcess.Config;

namespace MonitorigProcess
{

    public partial class Measure : UserControl
    {
        //static class Constants
        //{
        //    public const int maxconfig = 10;
        //}
        #region 
        private int iThreadTime = 2000;  // Thread 주기
        public bool bLoopState { get; set; }  // while문 Loop 여부

        private bool bCheck = false;
        private bool bMonitorStart = false;
        private bool bStartTimeSet = false;

        private readonly string strPath = AppConfiguration.iniPath;

        private PerformanceCounter cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total"); // Total Processor의 정보
        private PerformanceCounter ram = new PerformanceCounter("Memory", "Available MBytes"); // Total Memory 사용량 mb 정보

        //private string process_name;  // 현재 Program의 Process Name
        //        private PerformanceCounter[] prcess_cpu = new PerformanceCounter[Constants.maxconfig];
        //private PerformanceCounter[] prcess_mem = new PerformanceCounter[Constants.maxconfig];

        List<PerformanceCounter> lpfCounter = new List<PerformanceCounter>();  // 논리 프로세서의 Process 정보를 저장

        private Process[] pProcess = new Process[Constants.maxconfig];  // 선택된 프로세스 정보
        #endregion

        

        string message;
        int iSelected;
        public int iProcessMaxCnt = 0;
        Process[] allProc = Process.GetProcesses();    //시스템의 모든 프로세스 정보 출력

        DateTime dtStartDate;
        DateTime dtEndDate;
        
        public StProcess[] sProcess = new StProcess[Constants.maxconfig];
        StProcess sProcessTemp;
        IniFile ini;
        Logger logger;
        StringBuilder sb = new StringBuilder();
        PCManager PCM = new PCManager();
        Thread selectcputhread;
        private int processViewSelectedPid = 0;


        public Measure()
        {
            InitializeComponent();

            dateTimePickerEndDate.Value = DateTime.Now;
        }

        protected override void OnLoad(EventArgs e)
        {
            //Measure가 Form이 아닌 UserControl이므로 
            //개발 중 UserControl을 Form에서 사용하면 Design Time에 UserControl 객체가 생성됨
            //Design Time에 실행될 필요 없으며, 파일을 직접 다루기 때문에 오류 발생
            //Design Time에는 실행되지 않도록 함
            if (!DesignMode)
            {
                ini = new IniFile();

                validateConfig();
                readConfig();

                //logger 객체에서 프로세스 정보를 얻기 위해 Form 주소를 알려준다.
                logger = Logger.GetInstance(this);

                InitListView();
                UpdateListView();
                InitSelectedListView();

                processMonitoredList.DataSource = Bindings.selectedProcesses;
                processMonitoredList.DisplayMember = "Name";
            }
            processDetailView.InitView(this);
            totalResourceView.InitView(this, true);

            UpdateSelectedProcessBinding();
            base.OnLoad(e);
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            bLoopState = false;
            if(selectcputhread != null)
            {
                selectcputhread.Join();
            }
            base.OnHandleDestroyed(e);
        }

        // Process List 초기화
        private void InitListView()
        {
            listView1.View = View.Details;
            columnHeader1.Text = "No";
            columnHeader2.Text = "PID";
            columnHeader3.Text = "ProcessName";

            //listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //ListView.ColumnHeaderCollection cc = listView1.Columns;
            //for(int i=0; i<cc.Count; i++)
            //{
            //    int colWidth = TextRenderer.MeasureText(cc[i].Text, listView1.Font).Width + 10;
            //    if(colWidth > cc[i].Width)
            //    {
            //        cc[i].Width = colWidth;
            //    }
            //}

            listViewSelectedProcess.View = View.Details;
            columnHeader4.Text = "PID";
            columnHeader5.Text = "ProcessName";

            //listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //ListView.ColumnHeaderCollection cclist2 = listView2.Columns;
            //for (int i = 0; i < cclist2.Count; i++)
            //{
            //    int colWidth = TextRenderer.MeasureText(cclist2[i].Text, listView2.Font).Width + 10;
            //    if (colWidth > cclist2[i].Width)
            //    {
            //        cclist2[i].Width = colWidth;
            //    }
            //}
        }

        private void validateConfig()
        {
            string strsection1 = "Config";
            string strsection2 = "Config-pid";
            string strkey = "";
            List<StProcess> stProcesses = new List<StProcess>();
            if (!File.Exists(strPath))
            {
                FileStream fs =  File.Create(strPath);
                fs.Close();
                return;
            }
            ini.Load(strPath);
            for (int i = 0; i < Constants.maxconfig; i++)
            {
                strkey = Convert.ToString(i);
                string processName = ini[strsection1][strkey].ToString();
                int pid = ini[strsection2][strkey].ToInt();

                Process process = null;
                try
                {
                    process = Process.GetProcessById(pid);

                }
                catch (Exception e)
                {
                    //pid로 Process 얻어오지 못할 경우 = pid가 실행중이 아닌 경우
                    //예외 발생하고, 아래 진행 없이 loop 진행
                    continue;
                }
                StProcess tempProcess = new StProcess();
                tempProcess.Pid = pid;
                tempProcess.ProcessName = processName;
                stProcesses.Add(tempProcess);
            }

            for (int i = 0; i < Constants.maxconfig; i++)
            {
                strkey = Convert.ToString(i);
                if (i >= stProcesses.Count)
                {
                    ini[strsection1][strkey] = "";
                    ini[strsection2][strkey] = 0;
                }
                else
                {
                    ini[strsection1][strkey] = stProcesses[i].ProcessName;
                    ini[strsection2][strkey] = stProcesses[i].Pid.ToString();
                }
            }
            ini.Save(strPath);
        }

        private void readConfig()
        {
            string strsection1;
            string strsection2;
            string strkey;

            strsection1 = "Config";
            strsection2 = "Config-pid";
            ini.Load(strPath);
            for (int i = 0; i < Constants.maxconfig; i++)
            {
                strkey = Convert.ToString(i);
                sProcess[i].ProcessName = ini[strsection1][strkey].ToString();
                sProcess[i].Pid = ini[strsection2][strkey].ToInt();

                if (String.IsNullOrEmpty(sProcess[i].ProcessName) == false)
                {
                    iProcessMaxCnt++;   // 모니터개수 카운트
                }
            }
        }
        private void writeConfig()
        {
            string strsection1;
            string strsection2;
            string strkey;
            StringBuilder sb = new StringBuilder();

            strsection1 = "Config";
            strsection2 = "Config-pid";
            for (int i = 0; i < Constants.maxconfig; i++)
            {
                strkey = Convert.ToString(i);
                ini[strsection1][strkey] = sProcess[i].ProcessName;
                ini[strsection2][strkey] = sProcess[i].Pid.ToString();
            }
            ini.Save(strPath);
        }
        private void checkProcessId(string strPrcsName, int pId)
        {
            for (int i = 0; i < iProcessMaxCnt; i++)
            {
                if (strPrcsName == sProcess[i].ProcessName)
                {
                    sProcess[i].Pid = pId;
                }
            }
        }

        private async void initialMonitorProcess()
        {
            lblStartDateInfo.Text = "Monitoring Stop";
            lblEndDateInfo.Text = "";
            bMonitorStart = false;
            bLoopState = false;
            bStartTimeSet = false;

            this.BtnMonitorStart.Enabled = false;
            this.BtnMonitorEnd.Enabled = false;
            await Task.Run(() => SleepForButtonAsync());
            this.BtnMonitorStart.Enabled = true;
            this.BtnMonitorEnd.Enabled = true;
        }

        private void UpdateListView()
        {
            int i = 0;
            allProc = Process.GetProcesses();
            listView1.BeginUpdate();
            listView1.Items.Clear();
            foreach (Process p in allProc)
            {
                i++;
                ListViewItem lvi = new ListViewItem(Convert.ToString(i));
                lvi.SubItems.Add(Convert.ToString(p.Id));
                lvi.SubItems.Add(p.ProcessName);
                listView1.Items.Add(lvi);
                //PID는 ReadConfig할 때 가져오기 때문에 주석처리. 230102 CUS
                //checkProcessId(p.ProcessName, p.Id);
            }
            listView1.EndUpdate();
        }

        private void InitSelectedListView()
        {
            listViewSelectedProcess.Items.Clear();
            listViewSelectedProcess.BeginUpdate();
            for (int i = 0; i < iProcessMaxCnt; i++)
            {
                ListViewItem lvi = new ListViewItem(Convert.ToString(sProcess[i].Pid));
                lvi.SubItems.Add(sProcess[i].ProcessName);
                listViewSelectedProcess.Items.Add(lvi);
            }
            listViewSelectedProcess.EndUpdate();
        }

        private void InsertSelectedListView()
        {
            // PID 정합성 체크 필요.
            if (iSelected < 0)
                return;

            if (string.IsNullOrEmpty(sProcessTemp.ProcessName))
            {
                return;
            }
            // 현재 List 같은 것은 예외처리.
            if (listViewSelectedProcess.Items.Count != 0)
            {
                for (int i = 0; i < listViewSelectedProcess.Items.Count; i++)
                {
                    //if (sProcessTemp.ProcessName == listView2.Items[i].SubItems[1].Text)
                    //{
                    //    return;
                    //}

                    //pid는 같고 processName은 다른 경우 => readConfig에서 확인하므로 여기 도달하지 않음
                    //pid는 다르고 processName은 같은 경우 => listView2에 추가하는 것이 맞음
                    //pid도 같고 processName도 같은 경우 => 여기 예외처리의 목적
                    if (sProcessTemp.Pid == int.Parse(listViewSelectedProcess.Items[i].SubItems[0].Text)
                        && sProcessTemp.ProcessName == listViewSelectedProcess.Items[i].SubItems[1].Text)
                    {
                        return;
                    }

                }
            }

            sProcess[iProcessMaxCnt] = sProcessTemp;
            //pProcess[iProcessMaxCnt] = Process.GetProcessesByName(sProcessTemp.ProcessName);
            //Process processbyName = Process.GetProcessesByName(sProcessTemp.ProcessName);
            //pProcess[iProcessMaxCnt] = Process.GetProcessById(sProcessTemp.Pid);

            listViewSelectedProcess.BeginUpdate();
            ListViewItem lvi = new ListViewItem(Convert.ToString(sProcess[iProcessMaxCnt].Pid));
            //lvi.SubItems.Add(Convert.ToString(allProc[iPid].Id));
            lvi.SubItems.Add(sProcess[iProcessMaxCnt].ProcessName);
            listViewSelectedProcess.Items.Add(lvi);
            listViewSelectedProcess.EndUpdate();
            //listView2.Refresh();
            iProcessMaxCnt++;   // 모니터개수 카운트

            writeConfig();
        }

        private void RemoveSelectedListView()
        {
            if (listViewSelectedProcess.Items.Count > 0)
            {
                foreach (ListViewItem row in listViewSelectedProcess.SelectedItems)
                {
                    int SelectRow = listViewSelectedProcess.SelectedItems[0].Index;
                    string strtemp = listViewSelectedProcess.Items[SelectRow].SubItems[1].Text;// == sProcess[])
                    listViewSelectedProcess.Items.Remove(row);
                }

                for (int i = 0; i < Constants.maxconfig; i++)
                {
                    if (i < listViewSelectedProcess.Items.Count)
                    {
                        sProcess[i].Pid = Convert.ToInt32(listViewSelectedProcess.Items[i].SubItems[0].Text);
                        sProcess[i].ProcessName = listViewSelectedProcess.Items[i].SubItems[1].Text;
                    }
                    else
                    {
                        sProcess[i].Pid = 0;
                        sProcess[i].ProcessName = "";
                    }
                }
                iProcessMaxCnt = listViewSelectedProcess.Items.Count;

                writeConfig();
            }
        }

        // listview process 항목 정리
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            UpdateListView();
        }

        // listview 선택된 process add
        private void BtnApply_Click(object sender, EventArgs e)
        {
            if (bMonitorStart)
            {
                MessageBox.Show("Monitor Start 상태에서 Add 불가!!!\nMonitor Stop 후 진행하세요");
                return;
            }

            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("선택된 프로세스가 없습니다!");
                return;
            }

            if (iProcessMaxCnt >= Constants.maxconfig)
            {
                MessageBox.Show($"모니터링 최대개수는 {Constants.maxconfig}개입니다!!!");
                return;
            }
            InsertSelectedListView();
        }

        // listview 선택된 process remove
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (bMonitorStart)
            {
                MessageBox.Show("Monitor Start 상태에서 Del 불가!!!\nMonitor Stop 후 진행하세요");
                return;
            }

            if (listViewSelectedProcess.SelectedItems.Count == 0)
            {
                MessageBox.Show("선택된 프로세스가 없습니다!");
                return;
            }

            RemoveSelectedListView();
        }

        // listview 선택된 process monitoring start
        private void BtnMonitorStart_Click(object sender, EventArgs e)
        {
            // 0. Interlock
            if (bMonitorStart)
            {
                MessageBox.Show("Start 상태입니다");
                return;
            }

            // 1. Interlock
            if (iProcessMaxCnt <= 0)
            {
                MessageBox.Show("선택된 프로세스가 없습니다!");
                return;
            }

            // 현재 Program의 Process Name
            for (int i = 0; i < iProcessMaxCnt; i++)
            {
                try
                {
                    pProcess[i] = Process.GetProcessById(sProcess[i].Pid);// Process.GetProcessById(sProcessTemp.Pid);
                    sProcess[i].InstanceName = InstanceNameConvertor.GetProcessInstanceName(
                        sProcess[i].Pid, sProcess[i].ProcessName);
                }
                catch
                {
                    MessageBox.Show("실행중이지 않은 프로세스가 있습니다. \n" +
                        $"PID : {sProcess[i].Pid}, 프로세스명 : {sProcess[i].ProcessName}");
                    return;
                }
            }

            bMonitorStart = true;
            bLoopState = true;

            dtStartDate = DateTime.Now;
            lblStartDateInfo.Text = dtStartDate.ToString();

            if (dtEndDate.CompareTo(DateTime.Now) > 0)
            {
                lblEndDateInfo.Text = dtEndDate.ToString();
            }
            else
            {
                lblEndDateInfo.Text = "종료 미지정. 시작 + 1Hr 설정";
                dtEndDate = DateTime.Now.AddHours(1);
            }

            UpdateSelectedProcessBinding();
            processViewSelectedPid = Bindings.selectedProcesses[0].Id;
            processDetailView.SetPidText(processViewSelectedPid);

            OnMonitoringStart(new EventArgs());
            Thread.Sleep(1000);  // Thread 대기 Time
            SelectProcessThread();  // 선택 Process CPU 사용량 Check Thread
        }

        // text 변경시 listview 해당 문자열 찾기
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            message = textBox1.Text;
            int i = 0;
            listView1.Items.Clear();
            listView1.BeginUpdate();
            foreach (Process p in allProc)
            {
                i++;
                ListViewItem lvi = new ListViewItem(Convert.ToString(i));
                if (p.ProcessName.Contains(message))
                {
                    lvi.SubItems.Add(Convert.ToString(p.Id));
                    lvi.SubItems.Add(p.ProcessName);
                    listView1.Items.Add(lvi);
                }
            }
            listView1.EndUpdate();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                int iSelectRow = listView1.SelectedItems[0].Index;
                iSelected = iSelectRow;
                sProcessTemp.Pid = Convert.ToInt32(listView1.FocusedItem.SubItems[1].Text);
                sProcessTemp.ProcessName = listView1.FocusedItem.SubItems[2].Text;
            }
        }
        // Thread Function
        private void TotalPerformanceCheckThread()
        {
            Thread cpuCheck = new Thread(fCpuCheck);

            cpuCheck.Start();
        }

        // Thread
        private void fCpuCheck()
        {
            /*  필요 없고
            List<PerformanceCounter> lpCpu = new List<PerformanceCounter>();

            foreach (Process item in Process.GetProcesses())
            {
                lpCpu.Add(new PerformanceCounter("Process", "% Processor Time", item.ProcessName));
            }

            foreach (PerformanceCounter item in lpCpu)
            {
                //Log(enLogLevel.Info, $"Process Name : {item.CounterName}, CPU Counter : {item.NextValue()}");
            }
            */
            while (bLoopState)
            {
                if (bCheck)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append($"Total : {string.Format("{0:N2}", cpu.NextValue())}%");

                    for (int i = 0; i < Environment.ProcessorCount; i++)
                    {
                        if (lpfCounter[i] != null)
                        {
                            sb.Append($", CPU {i} : {string.Format("{0:N2}", lpfCounter[i].NextValue())}%");
                        }
                    }

                    Log(enLogLevel.Info, sb.ToString());

                    this.Invoke(new Action(delegate ()
                    {
                        Log(enLogLevel.Info, sb.ToString());
                    }));
                    /* Log Function 안으로 invoke 다 묶음
                    */
                }
                Thread.Sleep(iThreadTime);
            }
        }
        // List Select 값이 변경 될 경우 Process를 새로 등록
        //private void lboxProcessName_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // Process를 변경
        //    prcess_cpu = new PerformanceCounter("Process", "% Processor Time", lboxProcessName.SelectedItem.ToString());
        //}

        // 선택 Process Thread (Program 시작 시 실행)
        private async void SelectProcessThread()
        {
            Task selectcputhread = Task.Run((Action)fSelectProcess);
            await selectcputhread;
            initialMonitorProcess();
            while (logger != null && logger.IsWorking())
            {
                Thread.Sleep(iThreadTime);
            }
            ReportRepository.CreateReport(dtStartDate, dtEndDate, DateTime.Now, sProcess, iProcessMaxCnt, PCM.GetResultSnapshot(pProcess, iProcessMaxCnt));
        }

        private bool checkDateTime(DateTime dtTime)
        {
            //현재일보다 설정일이 빠르면
            if (dtTime.CompareTo(DateTime.Now) > 0)
            {
                return false;
            }
            //현재일보다 설정일이 느리면
            return true;
        }
        private void fSelectProcess()
        {
            PCM.InitProcessMonitor(pProcess);

            // 시작 하면 Program이 죽을 때 까지 계속 체크
            while (bLoopState)
            {
                fMonitorAllProcess();
                //Task.Run((Action)fMonitorAllProcess);
                Thread.Sleep(iThreadTime);  // Thread 대기 Time
                if (checkDateTime(dtEndDate))
                {
                    break;
                }
            }
        }

        #region Log Viewer 

        // Log Level을 지정 할 Enum (44강 Tree View 참조)
        enum enLogLevel
        {
            Info,
            Warning,
            Error,
        }

        private void Log(enLogLevel eLevel, string LogDesc)
        {
            this.Invoke(new Action(delegate ()
            {
                DateTime dTime = DateTime.Now;
                string LogInfo = $"{dTime:yyyy-MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}";
                //lboxLog.Items.Insert(0, LogInfo);
            }));
        }

        private void Log(DateTime dTime, enLogLevel eLevel, string LogDesc)
        {
            this.Invoke(new Action(delegate ()
            {
                string LogInfo = $"{dTime:yyyy-MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}";
                //lboxLog.Items.Insert(0, LogInfo);
            }));
        }

        // List Box Control 추가
        private void Log(ListBox lbox, enLogLevel eLevel, string LogDesc)
        {
            this.Invoke(new Action(delegate ()
            {
                DateTime dTime = DateTime.Now;
                string LogInfo = $"{dTime:yyyy-MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}";
                lbox.Items.Insert(0, LogInfo);
            }));
        }

        #endregion

        private void dateTimePickerEndDate_ValueChanged(object sender, EventArgs e)
        {
            dtEndDate = dateTimePickerEndDate.Value;
        }

        private void ClearListView(ListView ClearList)
        {
            if (ClearList.Items.Count != 0)
            {
                for (int i = 0; ClearList.Items.Count > 0; i++)
                {
                    ClearList.Items.RemoveAt(0);
                    if (i > 300) break;
                }
            }
        }

        private void BtnListClear_Click(object sender, EventArgs e)
        {
            if (bMonitorStart)
            {
                MessageBox.Show("Monitor Start 상태에서 List Clear 불가!!!\nMonitor Stop 후 진행하세요");
                return;
            }
            ClearListView(listViewSelectedProcess);

            for (int i = 0; i < Constants.maxconfig; i++)
            {
                sProcess[i].Pid = 0;
                sProcess[i].ProcessName = "";
            }
            writeConfig();
            iProcessMaxCnt = 0;
        }

        private void BtnMonitorEnd_Click(object sender, EventArgs e)
        {
            lblStartDateInfo.Text = "";
            lblEndDateInfo.Text = "";
            initialMonitorProcess();
        }

        private void fMonitorAllProcess()
        {
            DateTime dTime = DateTime.Now;
            if (!bStartTimeSet)
            {
                dtStartDate = dTime;
                bStartTimeSet = true;
            }
            sb.Append($"[{dTime:yyyy/MM/dd HH:mm:ss.FFF}],");

            var totalCpuUsage = PCM.GetTotalCPUUsage(dTime);
            var totalMemoryUsage = PCM.GetTotalMemoryUsage(dTime);

            for (int i = 0; i < iProcessMaxCnt; i++)
            {
                var cpuUsage = PCM.GetProcessCPUUsage(pProcess[i], dTime);
                var memoryUsage = PCM.GetProcessMemoryUsage(pProcess[i], dTime);
                var threadCount = PCM.GetProcessThreadCount(pProcess[i]);
                var handleCount = PCM.GetProcessHandleCount(pProcess[i]);
                var gdiCount = PCM.GetProcessGdiCount(pProcess[i]);
                
                memoryUsage /= 1024*1024;    //memory megabyte 변환

                sb.Append(cpuUsage.ToString()).Append(",")
                    .Append(memoryUsage.ToString()).Append(",")
                    .Append(threadCount.ToString()).Append(",")
                    .Append(handleCount.ToString()).Append(",")
                    .Append(gdiCount.ToString()).Append(",");

                string message = $"{dTime:yyyy-MM-dd HH:mm:ss.fff} {sProcess[i].InstanceName} - cpu (%): {Math.Round(cpuUsage,3).ToString()}, mem (MB): {Math.Round(memoryUsage,3).ToString()}, thread (cnt): {threadCount.ToString()}, handle (cnt): {handleCount.ToString()}, GDI (cnt): {gdiCount.ToString()}";

                if(pProcess[i].Id == processViewSelectedPid)
                {
                    ProcessPerformance processSet = PCM.GetProcessSet(processViewSelectedPid);
                    OnRaiseProcessMeasureEvent(processViewSelectedPid, new ProcessMeasureEventArgs(message, processSet));
                }
            }

            sb.Append(totalCpuUsage.ToString()).Append(",")
                .Append(totalMemoryUsage.ToString()).Append(",");

            var freeSpaces = PCM.GetFreeDiskSpace();
            foreach (var item in freeSpaces)
            {
                sb.Append(item.ToString()).Append(",");
            }
            string pcPerfMessage = $"{dTime:yyyy-MM-dd HH:mm:ss.fff} - total_cpu (%): {Math.Round(totalCpuUsage, 3)}, total_mem (MB): {Math.Round(totalMemoryUsage, 3)}";
            OnRaisePCMeasureEvent(new PCMeasureEventArgs(pcPerfMessage, freeSpaces,PCM.pcPerformance));

            logger.Log(sb.ToString(), dTime);
            sb.Clear();
        }

        #region For TabControl Handling
        //https://stackoverflow.com/questions/2237927/is-there-any-way-to-create-indexed-events-in-c-sharp-or-some-workaround

        //public event EventHandler<DataEventArgs> measureEvent;
        public EventHandler<ProcessMeasureEventArgs> processMeasureEvents;

        private void OnRaiseProcessMeasureEvent(int PID, ProcessMeasureEventArgs e)
        {
            processMeasureEvents?.BeginInvoke(this, e,null,null);
        }
        
        private void processMonitoredList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedProcess selectedProcess = (SelectedProcess)processMonitoredList.SelectedItem;
            if(selectedProcess is null)
            {
                return;
            }
            processViewSelectedPid = selectedProcess.Id;

            totalResourceView.Visible = false;
            processDetailView.Visible = true;
            try
            {
                processDetailView.ShowInformation(processViewSelectedPid, PCM.GetProcessSet(processViewSelectedPid));
            }
            catch (Exception exception)
            {
                return;
            }

        }       

        #endregion

        private void btnGraphViewer_Click(object sender, EventArgs e)
        {
            Forms.GraphViewer graphViewer;
            if (string.IsNullOrWhiteSpace(lblStartDateInfo.Text))
            {
                graphViewer = new Forms.GraphViewer(DateTime.Now);
            }
            else
            {
                graphViewer = new Forms.GraphViewer(DateTime.Parse(lblStartDateInfo.Text));
            }
            
            graphViewer.Show();
        }

        private void SleepForButtonAsync()
        {
            Thread.Sleep(4000);
        }

        #region disk spaces event
        public EventHandler<PCMeasureEventArgs> pcMeasureEvent;

        private void OnRaisePCMeasureEvent(PCMeasureEventArgs e)
        {
            pcMeasureEvent?.Invoke(this, e);
        }
        #endregion

        #region Monitoring Start Event
        public EventHandler<EventArgs> monitoringStartEvent;

        private void OnMonitoringStart(EventArgs e)
        {
            monitoringStartEvent?.Invoke(this, e);
        }


        #endregion

        private void totalViewButton_Click(object sender, EventArgs e)
        {
            totalResourceView.Visible = true;
            processDetailView.Visible = false;
        }

        #region Favorite
        private void buttonFavorite_Click(object sender, EventArgs e)
        {
            if (IsMirrored)
            {
                MessageBox.Show("모니터링 중 즐겨찾기 접근 불가합니다.");
            }
            UpdateSelectedProcessBinding();    //Favorite창에서도 Selected Process 보여줘야 하므로 진입 전에 BindingList Update
            FavoriteForm form = new FavoriteForm();
            form.selectedProcessSaveEvent += LoadSelectedProcessBinding;
            form.ShowDialog();
        }

        private void UpdateSelectedProcessBinding()
        {
            Bindings.selectedProcesses.Clear();
            for (int i = 0; i < iProcessMaxCnt; i++)
            {
                StProcess process = sProcess[i];
                Bindings.selectedProcesses.Add(new SelectedProcess(process.Pid, process.ProcessName, process.InstanceName));
            }
        }

        public void LoadSelectedProcessBinding(object sender, EventArgs e)
        {
            listViewSelectedProcess.Invoke(new Action(delegate ()
            {
                listViewSelectedProcess.Items.Clear();
                foreach (SelectedProcess item in Bindings.selectedProcesses)
                {
                    listViewSelectedProcess.Items.Add(new ListViewItem(new string[] { item.Id.ToString(), item.Name }));
                }
            }));
        }
        #endregion

    }
}
