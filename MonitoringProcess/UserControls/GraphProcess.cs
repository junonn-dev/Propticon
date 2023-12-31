﻿using ScottPlot;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using MonitorigProcess.Data;
using System.Linq;
using System.Drawing;
using MonitorigProcess.Config;

namespace MonitorigProcess.UserControls
{
    public partial class GraphProcess : UserControl
    {
        private GraphViewerDto dto;
        public GraphProcess(GraphViewerDto dto)
        {
            InitializeComponent();
            this.dto = dto;
            LoadPlots();
        }

        private void FormsPlot_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        /// <summary>
        /// plot의 공통 속성 지정
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="name"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        private FormsPlot GetCommonPlot(int width, int height, string name, string title)
        {
            FormsPlot formsPlot = new FormsPlot();
            formsPlot.BackColor = System.Drawing.Color.Transparent;
            formsPlot.Name = name;//여기서 Name이 이 컨트롤의 key값이 됨

            formsPlot.Configuration.LockVerticalAxis = true;
            formsPlot.MouseWheel += FormsPlot_MouseWheel;
            formsPlot.Margin = new Padding(0);
            formsPlot.Width = width;
            formsPlot.Height = height;

            //formsPlot.Plot.Grid(true);
            formsPlot.Plot.Title(title);
            formsPlot.Plot.XAxis.DateTimeFormat(true);
            return formsPlot;
        }

        private void LoadPlots()
        {
            if(dto == null || dto.xData.Length ==0)
            {
                return;
            }
            tabControl.Multiline = true;

            
            foreach (KeyValuePair<string, Dictionary<string, List<float>>> process in dto.yDataProcessPerformance)
            {
                //프로세스 이름으로 탭 생성
                string processName = process.Key;
                
                //tabPage 속에 FlowLayoutPanel 
                //FlowLayoutPanel 속에 그래프들 들어감
                TabPage tabPage = new TabPage();
                tabPage.Margin = new Padding(0);
                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.Dock = DockStyle.Fill;
                flp.Margin = new Padding(0);
                flp.AutoScroll = true;
                tabControl.TabPages.Add(processName, processName);
                tabControl.TabPages[processName].BackColor = Color.White;
                tabControl.TabPages[processName].Controls.Add(flp);

                //counter 수에 맞게 plot 생성하여 탭 페이지에 추가
                for (int i = 0; i < dto.processCounterCount; i++)
                {
                    FormsPlot formsPlot = GetCommonPlot(350, 200, dto.processCounterNames[i], dto.processCounterNames[i]);

                    flp.Controls.Add(formsPlot);
                }

                process.Value[AppConfiguration.processMemory].Select(y => (double)y / (1024 * 1024));
                foreach (KeyValuePair<string, List<float>> counter in process.Value)
                {
                    string counterName = counter.Key;

                    double[] values = counter.Value.Select(x => Math.Round(x,3)).ToArray();

                    FormsPlot plot = (FormsPlot)flp.Controls[counterName];

                    //Plot의 outer limit 지정을 위한 연산
                    DateTime xMin = DateTime.FromOADate(dto.xData.Min());
                    DateTime xMax = DateTime.FromOADate(dto.xData.Max());
                    double offsetX= xMax.Subtract(xMin).TotalSeconds * 0.05;
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
