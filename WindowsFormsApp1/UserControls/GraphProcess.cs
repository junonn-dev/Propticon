using ScottPlot;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using System.Linq;

namespace WindowsFormsApp1.UserControls
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

            //formsPlot.Configuration.LockVerticalAxis = true;
            formsPlot.MouseWheel += FormsPlot_MouseWheel;
            formsPlot.Margin = new Padding(0);
            formsPlot.Width = width;
            formsPlot.Height = height;

            formsPlot.Plot.Grid(false);
            formsPlot.Plot.Title(title);
            formsPlot.Plot.XAxis.DateTimeFormat(true);
            return formsPlot;
        }
        private void LoadPlots()
        {
            if(dto == null)
            {
                return;
            }
            foreach (KeyValuePair<string, Dictionary<string, List<float>>> process in dto.yData)
            {
                //프로세스 이름으로 탭 생성
                string processName = process.Key;
                guna2TabControl1.TabPages.Add(processName);
                guna2TabControl1.TabPages[processName] Add(new FlowLayoutPanel())

                //counter 수에 맞게 plot 생성하여 탭 페이지에 추가
                for (int i = 0; i < dto.counterCount; i++)
                {
                    FormsPlot formsPlot = GetCommonPlot(360, 210, dto.counterNames[i], dto.counterNames[i]);

                    this.guna2TabControl1.TabPages[processName].Controls.Add(formsPlot);
                }

                foreach (KeyValuePair<string, List<float>> counter in process.Value)
                {
                    string counterName = counter.Key;

                    double[] values = counter.Value.Select(x => (double)x).ToArray();

                    FormsPlot plot = (FormsPlot)guna2TabControl1.TabPages[processName].Controls.Find(counterName, false)[0];

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
