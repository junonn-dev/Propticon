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
using static MonitorigProcess.Program;
using System.IO;
using MonitorigProcess.Repository;
using MonitoringProcess.Data;
using MonitoringProcess.Forms;
using MonitorigProcess.Config;
using System.Linq;
using System.ComponentModel;
using MonitoringProcess.Config;

namespace MonitorigProcess
{

    public partial class Measure : UserControl
    {
        #region 
        private int iThreadTime = 2000;  // Thread 주기
        public bool bLoopState { get; set; }  // while문 Loop 여부

        private bool bCheck = false;
        private bool bMonitorStart = false;
        private bool bStartTimeSet = false;

        private readonly string strPath = AppConfiguration.iniPath;

        private PerformanceCounter cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total"); // Total Processor의 정보
        private PerformanceCounter ram = new PerformanceCounter("Memory", "Available MBytes"); // Total Memory 사용량 mb 정보

        List<PerformanceCounter> lpfCounter = new List<PerformanceCounter>();  // 논리 프로세서의 Process 정보를 저장

        private Process[] pProcess = new Process[Constants.maxconfig];  // 선택된 프로세스 정보
        #endregion

        string message;
        int iSelected;
        Process[] allProc = Process.GetProcesses();    //시스템의 모든 프로세스 정보 출력

        DateTime dtStartDate;
        DateTime dtEndDate;
        
        //public StProcess[] sProcess = new StProcess[Constants.maxconfig];
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
            }
            processDetailView.InitView(this);
            totalResourceView.InitView(this, true);
            freeDiskSpaceViewer1.SubscribeEvent(this);

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

            listViewSelectedProcess.View = View.Details;
            columnHeader4.Text = "PID";
            columnHeader5.Text = "ProcessName";
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
                //PID가 실행중이지만 프로세스 이름이 같은 경우
                if(process.ProcessName != processName)
                {
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
            ini.Load(strPath);
            
            for (int i = 0; i < ini[Constants.iniConfigSection].Count; i++)
            {
                //strkey = Convert.ToString(i);
                int pid = ini[Constants.iniConfigPidSection][i.ToString()].ToInt();
                if (pid == 0)
                {
                    //v1.2.0 버전까지는 ini파일에 최대 프로세스 개수만큼 값을 0으로 다 저장함
                    //v1.2.0 이하 버전 호환을 위한 예외처리
                    break;
                }
                   
                string processName = ini[Constants.iniConfigSection][i.ToString()].ToString();
                string instanceName = Helper.InstanceNameConvertor.GetProcessInstanceName(pid, processName);
                Bindings.selectedProcesses.Add(new SelectedProcess(pid, processName, instanceName));
            }
        }
        private void writeConfig()
        {
            string strkey;
            ini.Load(strPath);
            ini[Constants.iniConfigSection].Clear();
            ini[Constants.iniConfigPidSection].Clear();
            for (int i = 0; i < Bindings.selectedProcesses.Count; i++)
            {
                strkey = Convert.ToString(i);
                ini[Constants.iniConfigSection][strkey] = Bindings.selectedProcesses[i].Name;
                ini[Constants.iniConfigPidSection][strkey] = Bindings.selectedProcesses[i].Id;
            }
            ini.Save(strPath);
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
            }
            listView1.EndUpdate();
        }

        //초기화 과정에서 readConfig에서 Bindings.selectedProcesses에 초기화를 마친 후 
        //Bindings.selectedProcesses로부터 ListView를 초기화함
        //더 효율적인 방법은 SelectedProcess를 ListBox로 Databinding하는 것
        private void InitSelectedListView()
        {
            listViewSelectedProcess.Items.Clear();
            listViewSelectedProcess.BeginUpdate();
            for (int i = 0; i < Bindings.selectedProcesses.Count; i++)
            {
                listViewSelectedProcess.Items.Add(
                    new ListViewItem(new string[] { Bindings.selectedProcesses[i].Id.ToString(), Bindings.selectedProcesses[i].Name }));
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

            int pid = sProcessTemp.Pid;
            string processName = sProcessTemp.ProcessName;
            Bindings.selectedProcesses.Add(new SelectedProcess(pid, processName, Helper.InstanceNameConvertor.GetProcessInstanceName(pid, processName)));

            listViewSelectedProcess.BeginUpdate();
            listViewSelectedProcess.Items.Add(new ListViewItem(new string[] { sProcessTemp.Pid.ToString(), sProcessTemp.ProcessName }));
            listViewSelectedProcess.EndUpdate();

            writeConfig();
        }

        private void RemoveSelectedListView()
        {
            if (listViewSelectedProcess.Items.Count > 0)
            {
                HashSet<int> toDeletePid = new HashSet<int>();
                foreach (ListViewItem row in listViewSelectedProcess.SelectedItems)
                {
                    //row.Text가 첫 column을 지칭하고(Pid), column명으로 가져올 방법을 몰라서 그냥 row.Text를 쓴다만,
                    //column 순서 변경되면 수정해야 하므로 매우 안좋은 코드
                    toDeletePid.Add(Convert.ToInt32(row.Text));
                    listViewSelectedProcess.Items.Remove(row);
                }

                Bindings.selectedProcesses = new BindingList<SelectedProcess>(Bindings.selectedProcesses
                    .Where(selectedProcess => !toDeletePid.Contains(selectedProcess.Id)).ToList());

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

            if (Bindings.selectedProcesses.Count >= Constants.maxconfig)
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
            if (Bindings.selectedProcesses.Count <= 0)
            {
                MessageBox.Show("선택된 프로세스가 없습니다!");
                return;
            }

            for (int i = 0; i < Bindings.selectedProcesses.Count; i++)
            {
                SelectedProcess toCheck = Bindings.selectedProcesses[i];
                try
                {
                    pProcess[i] = Process.GetProcessById(toCheck.Id);
                }
                catch
                {
                    MessageBox.Show("실행중이지 않은 프로세스가 있습니다. \n" +
                        $"PID : {toCheck.Id}, 프로세스명 : {toCheck.Name}");
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

            processMonitoredList.DataSource = Bindings.selectedProcesses;
            processMonitoredList.DisplayMember = "Name";
            processMonitoredList.SelectedIndex = 0;

            processViewSelectedPid = Bindings.selectedProcesses[0].Id;
            processDetailView.SetPidText(processViewSelectedPid);

            OnMonitoringStart(new EventArgs());
            //Thread.Sleep(1000);  // Thread 대기 Time => 없어도 될 것 같은데?
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
                }
                Thread.Sleep(iThreadTime);
            }
        }

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

            //CreateReport에 Bindings.selectedProcesses 참조를 넣어도 되지만,
            //CreateReport 진행하는 중 Bindings.selectedProcesses의 내용 변경이 일어날 수 있지 않을까?
            //그래서 List에 카피를 진행했다. 그런데 List로 Copy 중에도 Bindings.selectedProcesses가 변경된다면?  
            //Bindings.SelectedProcess에 lock이 필요한가?
            List<SelectedProcess> selectedProcessList = new List<SelectedProcess>();
            foreach (SelectedProcess selectedProcess in Bindings.selectedProcesses)
            {
                selectedProcessList.Add(selectedProcess);
            }

            ReportRepository.CreateReport(dtStartDate, dtEndDate, DateTime.Now, selectedProcessList, PCM.GetResultSnapshot(pProcess, Bindings.selectedProcesses.Count));
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

            Bindings.selectedProcesses.Clear();
            writeConfig();
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

            bool warnFlag = false;
            for (int i = 0; i < Bindings.selectedProcesses.Count; i++)
            {
                var cpuUsage = PCM.GetProcessCPUUsage(pProcess[i], dTime);
                var memoryUsage = PCM.GetProcessMemoryUsage(pProcess[i], dTime) /( 1024 * 1024 );  //memory megabyte 변환
                var threadCount = PCM.GetProcessThreadCount(pProcess[i]);
                var handleCount = PCM.GetProcessHandleCount(pProcess[i]);
                var gdiCount = PCM.GetProcessGdiCount(pProcess[i]);

                if(warnFlag == false && ((cpuUsage >= WarnLimitConfig.ProcessCpuLimit) 
                    || (memoryUsage >= WarnLimitConfig.ProcessMemoryLimit)
                    || (threadCount >= WarnLimitConfig.ProcessThreadLimit)
                    || (handleCount >= WarnLimitConfig.ProcessHandleLimit)
                    || (gdiCount >= WarnLimitConfig.ProcessGDILimit)))
                {
                    warnFlag = true;
                }

                sb.Append(cpuUsage.ToString()).Append(",")
                    .Append(memoryUsage.ToString()).Append(",")
                    .Append(threadCount.ToString()).Append(",")
                    .Append(handleCount.ToString()).Append(",")
                    .Append(gdiCount.ToString()).Append(",");

                if(pProcess[i].Id == processViewSelectedPid)
                {
                    string message = $"{dTime:yyyy-MM-dd HH:mm:ss.fff} {Bindings.selectedProcesses[i].InstanceName} - cpu (%): {Math.Round(cpuUsage, 3).ToString()}, mem (MB): {Math.Round(memoryUsage, 3).ToString()}, thread (cnt): {threadCount.ToString()}, handle (cnt): {handleCount.ToString()}, GDI (cnt): {gdiCount.ToString()}";
                    ProcessPerformance processSet = PCM.GetProcessSet(processViewSelectedPid);
                    OnRaiseProcessMeasureEvent(processViewSelectedPid, new ProcessMeasureEventArgs(message, processSet));
                }
            }

            var totalCpuUsage = PCM.GetTotalCPUUsage(dTime);
            var totalMemoryUsage = PCM.GetTotalMemoryUsage(dTime);

            sb.Append(totalCpuUsage.ToString()).Append(",")
                .Append(totalMemoryUsage.ToString()).Append(",");

            var freeSpaces = PCM.GetFreeDiskSpace();
            foreach (var item in freeSpaces)
            {
                if(warnFlag == false && (item >= WarnLimitConfig.DiskSpaceLimit))
                {
                    warnFlag = true;
                }
                sb.Append(item.ToString()).Append(",");
            }


            if (warnFlag == false && (totalCpuUsage >= WarnLimitConfig.TotalCpuUsageLimit)
                || (totalMemoryUsage >= WarnLimitConfig.TotalMemoryUsageLimit))
            {
                warnFlag = true;
            }

            string pcPerfMessage = $"{dTime:yyyy-MM-dd HH:mm:ss.fff} - total_cpu (%): {Math.Round(totalCpuUsage, 3)}, total_mem (MB): {Math.Round(totalMemoryUsage, 3)}";
            OnRaisePCMeasureEvent(new PCMeasureEventArgs(pcPerfMessage, freeSpaces,PCM.pcPerformance));

            logger.Log(sb.ToString(), dTime);
            sb.Clear();

            if(warnFlag == true)
            {

            }
        }

        #region For TabControl Handling
        //https://stackoverflow.com/questions/2237927/is-there-any-way-to-create-indexed-events-in-c-sharp-or-some-workaround
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

        #region PC Measure event
        public event EventHandler<PCMeasureEventArgs> pcMeasureEvent;

        private void OnRaisePCMeasureEvent(PCMeasureEventArgs e)
        {
            pcMeasureEvent?.Invoke(this, e);
        }
        #endregion

        #region Monitoring Start Event
        public event EventHandler<EventArgs> monitoringStartEvent;

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
            if (bMonitorStart)
            {
                MessageBox.Show("모니터링 종료 후 즐겨찾기 접근 가능합니다.");
                return;
            }
            FavoriteForm form = new FavoriteForm();
            form.selectedProcessSaveEvent += LoadSelectedProcessBinding;
            form.ShowDialog();
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
