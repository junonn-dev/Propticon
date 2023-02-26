using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Config;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Graph;

namespace WindowsFormsApp1.UserControls
{
    public partial class GraphOverview : UserControl
    {
        public OverviewDto dto { get; }

        public GraphOverview(OverviewDto dto) 
        {
            InitializeComponent();
            this.Dock= DockStyle.Fill;
            this.Margin = new Padding(0);

            this.dto = dto;
            lblTotalTime.Text = dto.totalTime;
            lblProcess.Text = dto.processCount;
            lblMostCpuUsed.Text = dto.mostCpuUsedProcess;
            lblMostMemoryUsed.Text = dto.mostMemoryUsedProcess;

            if (!DesignMode)
            {
                LoadPlots();
            }
        }

        private void FormsPlot_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void LoadPlots()
        {
            if (dto == null)
            {
                MessageBox.Show($"프로그램 오류로 인해 Report 기록을 불러오지 못했습니다. ");
                return;
            }

            LogParser logParser;
            try
            {
                logParser = new LogParser(DateTime.Parse(dto.startTime));
            }
            catch
            {
                MessageBox.Show($"Report 기록을 불러오지 못했습니다. " +
                    $"\n{AppConfiguration.reportDirectory + dto.reportFileName}");
                return;
            }

            var data = logParser.GetHoursLog(DateTime.Parse(dto.startTime), DateTime.Parse(dto.stopTime));
            double[] xs = data.Item1.Select(time => time.ToOADate()).ToArray();

            Dictionary<string, Dictionary<string, List<float>>> yData = data.Item2;

            //counter 수에 맞게 테이블 준비
            string[] counterNames = logParser.GetCounterNames();
            int counterCount = logParser.GetCounterCount();
            for (int i = 0; i < counterCount; i++)
            {
                FormsPlot formsPlot = new FormsPlot();
                formsPlot.BackColor = System.Drawing.Color.Transparent;
                formsPlot.Name = counterNames[i];   //여기서 Name이 이 컨트롤의 key값이 됨
                //formsPlot.Configuration.LockVerticalAxis = true;
                formsPlot.MouseWheel += FormsPlot_MouseWheel;
                formsPlot.Margin = new Padding(0);
                formsPlot.Width = 360;
                formsPlot.Height = 210;

                formsPlot.Plot.Grid(false);
                formsPlot.Plot.Title(counterNames[i]);
                formsPlot.Plot.XAxis.DateTimeFormat(true);
                double[] manualTick = { 0, 50, 100 };
                string[] manualLabel = { "0", "50", "100" };
                formsPlot.Plot.YAxis.ManualTickPositions(manualTick, manualLabel);
                formsPlot.Plot.SetAxisLimitsY(-5, 105);

                this.flowLayoutPanel1.Controls.Add(formsPlot);
            }

            //logParser에서 받아온 데이터를 프로세스마다 counter 그래프에 입력
            foreach (var item in yData)
            {
                string insanceName = item.Key;

                Dictionary<string, List<float>> counters = item.Value;
                foreach (var counter in counters)
                {
                    string counterName = counter.Key;
                    float maxValue = counter.Value.Max();
                    float minValue = counter.Value.Min();
                    float range = maxValue - minValue;

                    double[] ys;
                    if (range == 0)
                    {
                        ys = counter.Value.Select(x => (double)0).ToArray();
                    }
                    else
                    {
                        ys = counter.Value.Select(x => ((double)x - minValue) / range * 100).ToArray();
                    }

                    FormsPlot plot = (FormsPlot)flowLayoutPanel1.Controls.Find(counterName, false)[0];
                    
                    try
                    {
                        plot.Plot.AddSignalXY(xs, ys);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("그래프 생성에 실패했습니다.");
                        return;
                    }
                    plot.Refresh();
                }
            }
        }

    }
}
