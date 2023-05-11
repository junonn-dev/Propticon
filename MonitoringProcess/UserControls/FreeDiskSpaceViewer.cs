using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot;
using MonitorigProcess;
using MonitorigProcess.Data;
using MonitoringProcess.Data;
using MonitorigProcess.Config;
using System.Diagnostics;
using System.IO;
using ScottPlot.Plottable;
using MonitorigProcess.UserControls.resources;

namespace MonitoringProcess.UserControls
{
    public partial class FreeDiskSpaceViewer : UserControl
    {
        private List<double> diskTotalSizes = new List<double>();
        private List<PiePlot> pies = new List<PiePlot>();

        public FreeDiskSpaceViewer()
        {
            InitializeComponent();
        }
        public FreeDiskSpaceViewer(Measure form) : this()
        {
            form.pcMeasureEvent += HandleLogEvent;
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!DesignMode)
            {
                base.OnLoad(e);
                LoadPlots();
            }
        }

        private void LoadPlots()
        {
            foreach (string diskName in AppConfiguration.diskNames)
            {
                FormsPlot formsPlot = new FormsPlot();
                formsPlot.BackColor = System.Drawing.Color.Transparent;
                formsPlot.Name = diskName;   //여기서 Name이 이 컨트롤의 key값이 됨
                formsPlot.Configuration.LockVerticalAxis = true;
                formsPlot.Configuration.LockHorizontalAxis = true;
                formsPlot.Width = 120;
                formsPlot.Height = 120;
                //formsPlot.Margin = new Padding(5);
                
                var drive = DriveInfo.GetDrives().FirstOrDefault(d => d.Name.Contains(diskName));
                //GB 단위
                double totalSize = (double)drive.TotalSize/(1024*1024*1024);
                double freeSpace = (double)drive.AvailableFreeSpace/ (1024 * 1024*1024);
                double usedSpace = totalSize - freeSpace;
                double[] values = { usedSpace, freeSpace };
                diskTotalSizes.Add(totalSize);

                //각 디스크에 해당하는 Pie준비해서 List<PiePlot>에 추가
                PiePlot pie = formsPlot.Plot.AddPie(values);
                double percent = Math.Round(usedSpace / totalSize * 100, 1);
                pie.DonutLabel = percent.ToString() + "%";
                var colors = GetSliceFillColors(percent);
                pie.SliceFillColors = colors;
                pie.CenterFont.Color = colors[0];

                pie.DonutSize = .66;
                pie.CenterFont.Size = 17f;
                pie.ShowLabels = true;
                pie.Size = .7;
                pies.Add(pie);

                var fontColor = Color.Black;
                this.flowLayoutPanel1.Controls.Add(formsPlot);
                
                //title을 왼쪽정렬 하고 싶다.
                formsPlot.Plot.Title(diskName+"\0\0\0\0\0\0\0\0\0", color:fontColor);
                formsPlot.Plot.XAxis.Label(Math.Round(usedSpace, 1) +"/"+ Math.Round(totalSize, 1) + "(GB)", size: 10, color: fontColor);
                formsPlot.Refresh();
            }
        }

        public void HandleLogEvent(object sender, PCMeasureEventArgs e)
        {
            //TODO: AppConfiguration.diskNames 기준으로 모든 순서가 정렬되어야 함
            // => 이 순서를 i로 인식해서 사용
            //앱 전체에서 순서가 동일해야 하는 제약이 생기는데, 더 좋은 방법?
            //i가 범위를 벗어나지 않는다고 확신할 수 있는가?
            for (int i = 0; i< AppConfiguration.diskNames.Count;i++)
            {
                string diskName = AppConfiguration.diskNames[i];
                FormsPlot formsPlot = (FormsPlot)this.flowLayoutPanel1.Controls[diskName];

                double totalSize = diskTotalSizes[i];
                //Free Disk Space = FreeDiskSpace(%) * diskTotalSize /100
                double freeSpace = e.FreeDiskSpaceValues[i] * diskTotalSizes[i] / 100;
                double usedSpace = totalSize - freeSpace;
                double percent = Math.Round(usedSpace / totalSize * 100, 1);
                var colors = GetSliceFillColors(percent);

                pies[i].Values[0] = usedSpace;
                pies[i].Values[1] = freeSpace;
                pies[i].DonutLabel = percent.ToString() + "%";
                pies[i].SliceFillColors = colors;
                pies[i].CenterFont.Color = colors[0];
                formsPlot.Plot.XAxis.Label(Math.Round(usedSpace, 1) + " / " + Math.Round(totalSize, 1) + "(GB)", size: 10);
                formsPlot.Invoke(new Action(delegate () { formsPlot.Render(); }));
            }
        }

        private Color[] GetSliceFillColors(double diskUsagePercent)
        {
            Color originColor = Color.FromArgb((int)GlobalBrandColor.BrandColor2);
            
            if (diskUsagePercent>=80 && diskUsagePercent < 90)
            {
                originColor = Color.Orange;
            }

            else if (diskUsagePercent >= 90)
            {
                originColor = Color.Red;
            }

            var colorBold = Color.FromArgb((int)ColorAlphaValue.Alpha10, originColor);
            var colorLight = Color.FromArgb((int)ColorAlphaValue.Alpha04, originColor);
            return new Color[] { colorBold, colorLight };

        }

    }
}
