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
using MonitorigProcess.CounterItem;
using MonitorigProcess.Data;
using MonitorigProcess.Config;

namespace MonitorigProcess.UserControls
{
    public partial class GraphMetrics : GraphBase
    {
        public GraphMetrics(GraphViewerDto dto)
        {
            InitializeComponent();

            this.dto = dto;
            LoadPlots();
        }

        private void LoadPlots()
        {
            if (dto == null || dto.xData.Length == 0)
            {
                return;
            }

            for(int i=0;i<dto.processCounterCount;i++)
            {
                string counterName = dto.processCounterNames[i];
                //카운터 이름으로 탭 생성
                //tabPage 속에 FlowLayoutPanel 
                //FlowLayoutPanel 속에 그래프들 들어감
                TabPage tabPage = new TabPage();
                tabPage.Margin = new Padding(0);
                
                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.Dock = DockStyle.Fill;
                flp.Margin = new Padding(0);
                guna2TabControl1.TabPages.Add(counterName, counterName);
                guna2TabControl1.TabPages[counterName].BackColor = Color.White;
                guna2TabControl1.TabPages[counterName].Controls.Add(flp);

                int processCount = 0;
                try
                {
                    processCount = Int32.Parse(dto.processCount);
                }
                catch
                {
                    return;
                }

                //프로세스 수에 맞게 plot 생성하여 탭 페이지에 추가
                foreach (KeyValuePair<string, Dictionary<string, List<float>>> process in dto.yDataProcessPerformance)
                {
                    process.Value[AppConfiguration.processMemory].Select(y => (double)y / (1024 * 1024));
                    string processName = process.Key;

                    FormsPlot formsPlot = GetCommonPlot(210, 170, processName, processName);

                    flp.Controls.Add(formsPlot);
                    flp.AutoScroll = true;

                    Dictionary<string, List<float>> counters = process.Value;
                    if (!counters.ContainsKey(counterName))
                    {
                        continue;
                    }

                    double[] values = counters[counterName].Select(x => (double)x).ToArray();

                    FormsPlot plot = (FormsPlot)flp.Controls[processName];

                    //Plot의 outer limit 지정을 위한 연산
                    DateTime xMin = DateTime.FromOADate(dto.xData.Min());
                    DateTime xMax = DateTime.FromOADate(dto.xData.Max());
                    double offsetX = xMax.Subtract(xMin).TotalSeconds * 0.05;
                    xMin = xMin.Subtract(TimeSpan.FromSeconds(offsetX));
                    xMax = xMax.Add(TimeSpan.FromSeconds(offsetX));

                    double yMin = values.Min();
                    double yMax = values.Max();
                    double offsetY = (yMax - yMin) * 0.05;

                    plot.Plot.SetOuterViewLimits(xMin.ToOADate(), xMax.ToOADate(), yMin - offsetY, yMax + offsetY);
                    try
                    {
                        plot.Plot.AddSignalXY(dto.xData, values);
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
