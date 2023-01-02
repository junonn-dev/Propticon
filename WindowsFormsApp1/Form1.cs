using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApp1.CounterItem;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.UserControls;
using static WindowsFormsApp1.Program;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //static class Constants
        //{
        //    public const int maxconfig = 10;
        //}
        #region 
        private int iThreadTime = 2000;  // Thread 주기
        private bool bLoopState = false;  // while문 Loop 여부

        private bool bCheck = false;
        private bool bMonitorStart = false;

        private string strPath;

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
        int iProcessMaxCnt = 0;
        Process[] allProc = Process.GetProcesses();    //시스템의 모든 프로세스 정보 출력

        DateTime dtStartDate;
        DateTime dtEndDate;
        struct StProcess
        {
            public int Pid;
            public string ProcessName;
        };

        StProcess[] sProcess = new StProcess[Constants.maxconfig];
        StProcess sProcessTemp;
        IniFile ini;
        Logger logger = Logger.GetInstance();
        StringBuilder sb = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        StringBuilder filename = new StringBuilder();
        PCManager[] pcManger = new PCManager[Constants.maxconfig];//.GetInstance(processNames);
        PCManager PCM = new PCManager();
        public Form1()
        {
            //strPath = System.Reflection.Assembly.GetExecutingAssembly().Location;   //@"\MonitorProcess.ini";
            strPath = "..\\..\\..\\MonitorProcess.ini";
            //logger.SetFileName("MonTest.csv");
            ini = new IniFile();
            validateConfig();
            readConfig();
            //strPath = "C:\\MonitorProcess.ini";

            InitializeComponent();
            InitListView();
            UpdateListView();
            InitSelectedListView();
            InitTabControl();
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

            listView2.View = View.Details;
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

        private void initialMonitorProcess()
        {
            lblStartDateInfo.Text = "Monitoring Stop";
            lblEndDateInfo.Text = "";
            bMonitorStart = false;
            bLoopState = false;
        }

        private void UpdateListView()
        {
            int i = 0;
            listView1.BeginUpdate();
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
            listView2.Items.Clear();
            listView2.BeginUpdate();
            for (int i = 0; i < iProcessMaxCnt; i++)
            {
                ListViewItem lvi = new ListViewItem(Convert.ToString(sProcess[i].Pid));
                lvi.SubItems.Add(sProcess[i].ProcessName);
                listView2.Items.Add(lvi);
            }
            listView2.EndUpdate();
        }

        private void InsertSelectedListView()
        {
            // PID 정합성 체크 필요.
            if (iSelected < 0)
                return;

            // 현재 List 같은 것은 예외처리.
            if (listView2.Items.Count != 0)
            {
                for (int i = 0; i < listView2.Items.Count; i++)
                {
                    //if (sProcessTemp.ProcessName == listView2.Items[i].SubItems[1].Text)
                    //{
                    //    return;
                    //}

                    //pid는 같고 processName은 다른 경우 => readConfig에서 확인하므로 여기 도달하지 않음
                    //pid는 다르고 processName은 같은 경우 => listView2에 추가하는 것이 맞음
                    //pid도 같고 processName도 같은 경우 => 여기 예외처리의 목적
                    if (sProcessTemp.Pid == int.Parse(listView2.Items[i].SubItems[0].Text)
                        && sProcessTemp.ProcessName == listView2.Items[i].SubItems[1].Text)
                    {
                        return;
                    }

                }
            }

            sProcess[iProcessMaxCnt] = sProcessTemp;
            //pProcess[iProcessMaxCnt] = Process.GetProcessesByName(sProcessTemp.ProcessName);
            //Process processbyName = Process.GetProcessesByName(sProcessTemp.ProcessName);
            //pProcess[iProcessMaxCnt] = Process.GetProcessById(sProcessTemp.Pid);

            listView2.BeginUpdate();
            ListViewItem lvi = new ListViewItem(Convert.ToString(sProcess[iProcessMaxCnt].Pid));
            //lvi.SubItems.Add(Convert.ToString(allProc[iPid].Id));
            lvi.SubItems.Add(sProcess[iProcessMaxCnt].ProcessName);
            listView2.Items.Add(lvi);
            listView2.EndUpdate();
            //listView2.Refresh();
            iProcessMaxCnt++;   // 모니터개수 카운트
            sProcessTemp.Pid = 0;
            sProcessTemp.ProcessName = "";

            writeConfig();
        }

        private void RemoveSelectedListView()
        {
            if (listView2.Items.Count > 0)
            {
                foreach (ListViewItem row in listView2.SelectedItems)
                {
                    int SelectRow = listView2.SelectedItems[0].Index;
                    string strtemp = listView2.Items[SelectRow].SubItems[1].Text;// == sProcess[])
                    listView2.Items.Remove(row);
                }

                for (int i = 0; i < Constants.maxconfig; i++)
                {
                    if (i < listView2.Items.Count)
                    {
                        sProcess[i].Pid = Convert.ToInt32(listView2.Items[i].SubItems[0].Text);
                        sProcess[i].ProcessName = listView2.Items[i].SubItems[1].Text;
                    }
                    else
                    {
                        sProcess[i].Pid = 0;
                        sProcess[i].ProcessName = "";
                    }
                }
                iProcessMaxCnt = listView2.Items.Count;

                writeConfig();
            }
        }

        // listview process 항목 정리
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
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
            if (iProcessMaxCnt > 9)
            {
                MessageBox.Show("모니터링 최대개수는 10개입니다!!!");
                return;
            }
            InsertSelectedListView();

            //tabControl1.TabPages.Add((tabControl1.TabPages.Count + 1).ToString());
            if (iProcessMaxCnt > 1)
            {
                tabControl1.TabPages.Add(sProcess[iProcessMaxCnt - 1].Pid.ToString());
            }

            foreach (ListViewItem item in listView1.SelectedItems)
            {
                AddProcessTab(int.Parse(item.SubItems[1].Text));
            }

        }

        // listview 선택된 process remove
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (bMonitorStart)
            {
                MessageBox.Show("Monitor Start 상태에서 Del 불가!!!\nMonitor Stop 후 진행하세요");
                return;
            }

            if (listView2.SelectedItems.Count == 0)
            {
                MessageBox.Show("선택된 프로세스가 없습니다!");
                return;
            }

            foreach (ListViewItem item in listView2.SelectedItems)
            {
                DeleteProcessTab(int.Parse(item.SubItems[0].Text));
            }

            RemoveSelectedListView();

            if (tabControl1.TabPages.Count > 1)
            {
                tabControl1.TabPages.Remove(tabControl1.TabPages[tabControl1.TabPages.Count - 1]);
            }


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

            lblStartDateInfo.Text = DateTime.Now.ToString();

            if (dtEndDate.CompareTo(DateTime.Now) > 0)
            {
                lblEndDateInfo.Text = dtEndDate.ToString();
            }
            else
            {
                lblEndDateInfo.Text = "종료 미지정. 시작 + 1Hr 설정";
                dtEndDate = DateTime.Now.AddHours(1);
            }

            Thread.Sleep(1000);  // Thread 대기 Time
            SelectProcessThread();  // 선택 Process CPU 사용량 Check Thread

            //bCheck = true;
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
        private void SelectProcessThread()
        {
            Thread selectcputhread = new Thread(fSelectProcess);

            selectcputhread.Start();
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

            // pcManger[i].GetInstance()
            // 시작 하면 Program이 죽을 때 까지 계속 체크
            while (bLoopState)
            {
                fMonitorAllProcess();
                //Task.Run((Action)fMonitorAllProcess);
                Thread.Sleep(iThreadTime);  // Thread 대기 Time
                if (checkDateTime(dtEndDate))
                {
                    initialMonitorProcess();
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
                lboxLog.Items.Insert(0, LogInfo);
            }));
        }

        private void Log(DateTime dTime, enLogLevel eLevel, string LogDesc)
        {
            this.Invoke(new Action(delegate ()
            {
                string LogInfo = $"{dTime:yyyy-MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}";
                lboxLog.Items.Insert(0, LogInfo);
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

        private void dateTimePickerStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

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
            ClearListView(listView2);

            for (int i = 0; i < Constants.maxconfig; i++)
            {
                sProcess[i].Pid = 0;
                sProcess[i].ProcessName = "";
            }
            writeConfig();
            iProcessMaxCnt = 0;

            DeleteAllTabControl();
        }

        private void BtnMonitorEnd_Click(object sender, EventArgs e)
        {
            initialMonitorProcess();
            lblStartDateInfo.Text = "";
            lblEndDateInfo.Text = "";
        }

        private void fMonitorAllProcess()
        {
            DateTime dTime = DateTime.Now;
            sb.Append($"[{dTime:yyyy/MM/dd hh:mm:ss.FFF}],");
            for (int i = 0; i < iProcessMaxCnt; i++)
            {
                // -mm 분당 추가 되는 파일 테스트 용도 (추후 삭제 필요함)
                string strfilename = filename.Append(DateTime.Now.ToString("yyyy-MM-dd-HH")).Append(".csv").ToString();
                //if (!logger.GetFileExist(filename.ToString()))

                if (!logger.GetFileExist(strfilename))
                {
                    //logger.SetFileName(filename.ToString());
                    // 파일이 생성되어있는상태에서 SetFileName 진행을 안하면... logger sw 생성이 안돼서 exception 발생되네...
                    // 파일 존재여부로 하면 안되겄는데ㅠ
                    logger.SetFileName(strfilename);

                    sb2.Append("Time").Append(",");
                    for (int j = 0; j < iProcessMaxCnt; j++)
                    {
                        sb2
                        .Append("cpu_" + pProcess[j].ProcessName).Append(",")
                        .Append("mem_" + pProcess[j].ProcessName).Append("(KB),")
                        .Append("thread_" + pProcess[j].ProcessName).Append(",")
                        .Append("handle_" + pProcess[j].ProcessName).Append(",");
                    }
                    logger.WriteLog(sb2.ToString());
                    sb2.Clear();
                }
                else
                {
                    logger.SetFileName(strfilename);
                }
                strfilename = null;
                filename.Clear();

                var cpuUsage = PCM.GetProcessCPUUsage(pProcess[i], dTime);
                var memoryUsage = PCM.GetProcessMemoryUsage(pProcess[i], dTime);
                var threadCount = PCM.GetProcessThreadCount(pProcess[i]);
                var handleCount = PCM.GetProcessHandleCount(pProcess[i]);

                memoryUsage /= 1024;    //memory kilobyte 변환

                // 4줄로...
                //Log(lboxProcessLog, enLogLevel.Info, $"{pProcess[i].ProcessName} cpu: {cpuUsage.ToString()} %");
                //Log(lboxProcessLog, enLogLevel.Info, $"{pProcess[i].ProcessName} mem: {memoryUsage.ToString()} %");
                //Log(lboxProcessLog, enLogLevel.Info, $"{pProcess[i].ProcessName} threadCnt: {threadCount.ToString()} cnt");
                //Log(lboxProcessLog, enLogLevel.Info, $"{pProcess[i].ProcessName} HandleCnt: {handleCount.ToString()} cnt");

                // 한줄로...
                Log(lboxProcessLog, enLogLevel.Info, $"{pProcess[i].ProcessName} cpu (%): {cpuUsage.ToString()} mem (KB): {memoryUsage.ToString()} thread (cnt): {threadCount.ToString()} handle (cnt): {handleCount.ToString()}");
                //Log(listBox1, enLogLevel.Info, $"{pProcess[i].ProcessName} cpu (%): {cpuUsage.ToString()} mem (%): {memoryUsage.ToString()} thread (cnt): {threadCount.ToString()} handle (cnt): {handleCount.ToString()}");

                sb.Append(cpuUsage.ToString()).Append(",")
                    .Append(memoryUsage.ToString()).Append(",")
                    .Append(threadCount.ToString()).Append(",")
                    .Append(handleCount.ToString()).Append(",");

                string message = $"{dTime:yyyy-MM-dd hh:mm:ss.fff} [{enLogLevel.Info.ToString()}] {pProcess[i].ProcessName} cpu (%): {cpuUsage.ToString()} mem (KB): {memoryUsage.ToString()} thread (cnt): {threadCount.ToString()} handle (cnt): {handleCount.ToString()}";
                ProcessSet processSet = PCM.GetProcessSet(pProcess[i]);

                DataEventArgs args = new DataEventArgs(message, processSet);
                OnRaiseMeasureEvent(pProcess[i].Id, args);
            }
            string strData = sb.ToString();
            logger.WriteLog(sb.ToString());
            sb.Clear();
        }

        #region For TabControl Handling
        //https://stackoverflow.com/questions/2237927/is-there-any-way-to-create-indexed-events-in-c-sharp-or-some-workaround

        //public event EventHandler<DataEventArgs> measureEvent;
        public Dictionary<int, EventHandler<DataEventArgs>> measureEvents = new Dictionary<int, EventHandler<DataEventArgs>>();


        private void OnRaiseMeasureEvent(int PID, DataEventArgs e)
        {

            EventHandler<DataEventArgs> eventHandler = measureEvents[PID];

            if (eventHandler != null)
            {
                eventHandler(this, e);
                //var task = Task.Run(() => eventHandler(this, e));
                //await task;
            }
        }

        private void AddProcessTab(int PID)
        {
            string strPID = PID.ToString();
            if (tconProcessTab.TabPages.ContainsKey(strPID))
            {
                return;
            }
            tconProcessTab.TabPages.Add(strPID, strPID);

            measureEvents[PID] = null;
            uscRealTimeProcessView tempUserControl = new uscRealTimeProcessView(this, PID);
            tempUserControl.Dock = DockStyle.Fill;

            tconProcessTab.TabPages[strPID].Controls.Add(tempUserControl);
        }

        private void DeleteProcessTab(int PID)
        {
            if (!tconProcessTab.TabPages.ContainsKey(PID.ToString()))
            {
                return;
            }
            tconProcessTab.TabPages.RemoveByKey(PID.ToString());
            measureEvents.Remove(PID);
        }

        private void InitTabControl()
        {
            for (int i = 0; i < iProcessMaxCnt; i++)
            {
                AddProcessTab(sProcess[i].Pid);
            }
        }

        private void DeleteAllTabControl()
        {
            tconProcessTab.TabPages.Clear();
        }
        #endregion


    }

}
