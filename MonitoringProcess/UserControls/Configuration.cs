using MonitorigProcess;
using MonitorigProcess.Config;
using MonitoringProcess.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MonitorigProcess.Program;

namespace MonitoringProcess.UserControls
{
    public partial class Configuration : UserControl
    {
        private Measure monitorCheckReference;
        public Configuration()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            loadSavedConfig();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            loadSavedConfig();
        }

        public void setMonitorCheckReference(Measure measure)
        {
            this.monitorCheckReference = measure;
        }

        private void loadSavedConfig()
        {
            if (!File.Exists(AppConfiguration.iniPath))
            {
                FileStream fs = File.Create(AppConfiguration.iniPath);
                fs.Close();
            }

            IniFile ini = new IniFile();
            ini.Load(AppConfiguration.iniPath);

            var options = ini[Constants.iniOptions];
            if(options.Values.Count!=0)
            {
                WarnLimitConfig.WarnDetectionMode = options["WarnDetectionMode"].ToBool();
                WarnLimitConfig.TotalCpuUsageLimit = options["TotalCpuUsageLimit"].ToInt();
                WarnLimitConfig.TotalMemoryUsageLimit = options["TotalMemoryUsageLimit"].ToInt();
                WarnLimitConfig.DiskSpaceLimit = options["DiskSpaceLimit"].ToInt();
                WarnLimitConfig.ProcessCpuLimit = options["ProcessCpuLimit"].ToInt();
                WarnLimitConfig.ProcessMemoryLimit = options["ProcessMemoryLimit"].ToInt();
                WarnLimitConfig.ProcessThreadLimit = options["ProcessThreadLimit"].ToInt();
                WarnLimitConfig.ProcessHandleLimit = options["ProcessHandleLimit"].ToInt();
                WarnLimitConfig.ProcessGdiLimit = options["ProcessGdiLimit"].ToInt();
            }

            checkBoxDetectionMode.Checked = WarnLimitConfig.WarnDetectionMode;
            this.textBoxTotalCpuLimit.Text = WarnLimitConfig.TotalCpuUsageLimit.ToString();
            this.textBoxTotalMemoryLimit.Text = WarnLimitConfig.TotalMemoryUsageLimit.ToString();
            this.textBoxDiskSpace.Text = WarnLimitConfig.DiskSpaceLimit.ToString();
            this.textBoxProcessCPULimit.Text = WarnLimitConfig.ProcessCpuLimit.ToString();
            this.textBoxProcessMemoryLimit.Text = WarnLimitConfig.ProcessMemoryLimit.ToString();
            this.textBoxProcessThreadLimit.Text = WarnLimitConfig.ProcessThreadLimit.ToString();
            this.textBoxProcessHandleLimit.Text = WarnLimitConfig.ProcessHandleLimit.ToString();
            this.textBoxProcessGDILimit.Text = WarnLimitConfig.ProcessGdiLimit.ToString();
        }

        private void textBoxes_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (string.IsNullOrEmpty(textbox.Text))
            {
                return;
            }
            string text = string.Concat(textbox.Text.Where(ch => (ch >= '0' && ch <= '9')));

            if (string.IsNullOrEmpty(textbox.Text))
            {
                return;
            }

            int inputValue = 0;
            try
            {
                inputValue = Convert.ToInt32(text);
            }
            catch
            {
                textbox.Text = "";
                return;
            }

            switch (textbox.TabIndex)
            {
                case 1: 
                case 2: 
                case 3: 
                case 4:
                    if(inputValue>100)
                    {
                        inputValue = 100;
                    }
                    break;

                case 5:
                case 6:
                case 7:
                case 8:
                    if (inputValue > 9999999)
                    {
                        inputValue = 9999999;
                    }
                    break;
                default:
                    break;
            }
            textbox.Text = inputValue.ToString();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            loadSavedConfig();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //모니터링 끝난 직후, 측정 스레드는 종료되지 않은 상태에서
            //저장 클릭 시 여기 체크 로직을 통과할 수 있다.
            //그렇게 되면 DetectionMode 변경에 따라 측정 스레드에서 예외가 발생할 수 있다.
            if(monitorCheckReference.bLoopState == true)
            {
                MessageBox.Show("모니터링 중 변경할 수 없습니다.");
                return;
            }
            try
            {
                WarnLimitConfig.WarnDetectionMode = checkBoxDetectionMode.Checked;
                WarnLimitConfig.TotalCpuUsageLimit = Convert.ToInt32(textBoxTotalCpuLimit.Text);
                WarnLimitConfig.TotalMemoryUsageLimit = Convert.ToInt32(textBoxTotalMemoryLimit.Text);
                WarnLimitConfig.DiskSpaceLimit = Convert.ToInt32(textBoxDiskSpace.Text);
                WarnLimitConfig.ProcessCpuLimit = Convert.ToInt32(textBoxProcessCPULimit.Text);
                WarnLimitConfig.ProcessMemoryLimit = Convert.ToInt32(textBoxProcessMemoryLimit.Text);
                WarnLimitConfig.ProcessThreadLimit = Convert.ToInt32(textBoxProcessThreadLimit.Text);
                WarnLimitConfig.ProcessHandleLimit = Convert.ToInt32(textBoxProcessHandleLimit.Text);
                WarnLimitConfig.ProcessGdiLimit = Convert.ToInt32(textBoxProcessGDILimit.Text);
            }
            catch
            {
                MessageBox.Show("저장에 실패했습니다.");
                return;
            }

            IniFile ini = new IniFile();
            ini.Load(AppConfiguration.iniPath);

            var options = ini[Constants.iniOptions];
            options["WarnDetectionMode"] = WarnLimitConfig.WarnDetectionMode;
            options["TotalCpuUsageLimit"] = WarnLimitConfig.TotalCpuUsageLimit.ToString();
            options["TotalMemoryUsageLimit"] = WarnLimitConfig.TotalMemoryUsageLimit.ToString();
            options["DiskSpaceLimit"] = WarnLimitConfig.DiskSpaceLimit.ToString();
            options["ProcessCpuLimit"] = WarnLimitConfig.ProcessCpuLimit.ToString();
            options["ProcessMemoryLimit"] = WarnLimitConfig.ProcessMemoryLimit.ToString();
            options["ProcessThreadLimit"] = WarnLimitConfig.ProcessThreadLimit.ToString();
            options["ProcessHandleLimit"] = WarnLimitConfig.ProcessHandleLimit.ToString();
            options["ProcessGdiLimit"] = WarnLimitConfig.ProcessGdiLimit.ToString();

            ini.Save(AppConfiguration.iniPath);

            MessageBox.Show("저장했습니다.");
        }
    }
}
