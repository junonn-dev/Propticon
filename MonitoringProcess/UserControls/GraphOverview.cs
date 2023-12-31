﻿using ScottPlot;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MonitorigProcess.Data;
using ScottPlot.Plottable;

namespace MonitorigProcess.UserControls
{
    public partial class GraphOverview : UserControl
    {
        public GraphViewerDto dto { get; }
        private List<FormsPlot> formsPlots = new List<FormsPlot>();
        private Dictionary<string, List<IPlottable>> processPlotMap = new Dictionary<string, List<IPlottable>>();

        public GraphOverview(GraphViewerDto dto) 
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
                CreateCheckboxes();
            }
        }

        private void FormsPlot_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        //생성자에서 받아온 dto의 정보로 그래프를 그린다.
        private void LoadPlots()
        {
            if (dto == null)
            {
                MessageBox.Show($"프로그램 오류로 인해 Report 기록을 불러오지 못했습니다. ");
                return;
            }
            
            //counter 수에 맞게 테이블 준비
            for (int i = 0; i < dto.processCounterCount; i++)
            {
                FormsPlot formsPlot = new FormsPlot();
                formsPlot.BackColor = System.Drawing.Color.Transparent;
                formsPlot.Name = dto.processCounterNames[i];   //여기서 Name이 이 컨트롤의 key값이 됨
                formsPlot.Configuration.LockVerticalAxis = true;
                formsPlot.MouseWheel += FormsPlot_MouseWheel;
                formsPlot.Margin = new Padding(0);
                formsPlot.Width = 340;
                formsPlot.Height = 200;

                formsPlot.Plot.Grid(false);
                formsPlot.Plot.Title(dto.processCounterNames[i]);
                formsPlot.Plot.XAxis.DateTimeFormat(true);
                double[] manualTick = { 0, 50, 100 };
                string[] manualLabel = { "0", "50", "100" };
                formsPlot.Plot.YAxis.ManualTickPositions(manualTick, manualLabel);
                formsPlot.Plot.SetAxisLimitsY(-5, 105);
                if(dto.xData.Length == 0)
                {
                    MessageBox.Show($"측정된 데이터를 불러오지 못했습니다.");
                    return;
                }
                double xMin = dto.xData.Min();
                double xMax = dto.xData.Max();
                formsPlot.Plot.SetAxisLimitsX(xMin, xMax);
                formsPlot.Plot.SetOuterViewLimits(xMin, xMax, -5, 105);

                this.flowLayoutPanel1.Controls.Add(formsPlot);
                formsPlots.Add(formsPlot);
            }

            //logParser에서 받아온 데이터를 프로세스마다 counter 그래프에 입력
            foreach (var item in dto.yDataProcessPerformance)
            {
                string instanceName = item.Key;
                processPlotMap[instanceName] = new List<IPlottable>();

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
                        SignalPlotXY signalPlot = plot.Plot.AddSignalXY(dto.xData, ys);
                        processPlotMap[instanceName].Add(signalPlot);
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

        private void CreateCheckboxes()
        {
            foreach (var item in processPlotMap)
            {
                SignalPlotXY plot = item.Value.FirstOrDefault() as SignalPlotXY;               
                this.listViewProcessList.Items.Add(item.Key, item.Key, "");
                var listViewItem = this.listViewProcessList.Items[item.Key];
                listViewItem.Checked = true;
                listViewItem.ForeColor = plot.LineColor;
                listViewProcessList.ItemChecked += ListViewProcessList_ItemChecked;
            }
        }

        private void ListViewProcessList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            processPlotMap[e.Item.Text].ForEach(plot => plot.IsVisible = e.Item.Checked);
            formsPlots.ForEach(plot => plot.Refresh());
        }

        private void CheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            processPlotMap[checkBox.Text].ForEach(plot => plot.IsVisible = checkBox.Checked);
            
            formsPlots.ForEach(plot => plot.Refresh());
        }
    }
}
