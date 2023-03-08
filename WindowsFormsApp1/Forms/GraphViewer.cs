using ScottPlot;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Repository;

namespace WindowsFormsApp1.Forms
{
    public partial class GraphViewer : Form
    {
        public GraphViewer()
        {
            InitializeComponent();
        }

        public GraphViewer(DateTime startTime) : this()
        {
            dtpStart.Value = startTime;
            dtpEnd.Value = startTime.AddHours(1);
        }

        private void FormsPlot_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LogRepository logParser;
            try
            {
                //임시 예외처리
                logParser = new LogRepository(dtpStart.Value);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("${filePath} 파일이 존재하지 않습니다.");
                return;
            }
            var data = logParser.GetHoursLog(dtpStart.Value, dtpEnd.Value);
            double[] xs = data.Item1.Select(time => time.ToOADate()).ToArray();

            Dictionary<string, Dictionary<string, List<float>>> yData = data.Item2;

            //counter 수에 맞게 테이블 준비
            string[] counterNames = logParser.GetCounterNames();
            int counterCount = logParser.GetCounterCount();
            for (int i = 0; i < counterCount; i++)
            {
                this.tlpViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent));
                FormsPlot formsPlot = new FormsPlot();
                formsPlot.BackColor = System.Drawing.Color.Transparent;
                formsPlot.Location = new System.Drawing.Point(3, 3);
                formsPlot.Dock = DockStyle.Fill;
                formsPlot.Name = counterNames[i];
                formsPlot.Plot.Title(counterNames[i]);
                formsPlot.Plot.XLabel("Time");
                formsPlot.Plot.XAxis.DateTimeFormat(true);
                formsPlot.Configuration.LockVerticalAxis = true;
                formsPlot.MouseWheel += FormsPlot_MouseWheel;
                tlpViewer.Controls.Add(formsPlot, 0, i);
            }

            //logParser에서 받아온 데이터를 프로세스마다 counter 그래프에 입력
            foreach (var item in yData)
            {
                string insanceName = item.Key;

                Dictionary<string, List<float>> counters = item.Value;
                foreach (var counter in counters)
                {
                    string counterName = counter.Key;
                    double[] ys = counter.Value.Select(x => (double)x).ToArray();
                    FormsPlot plot = (FormsPlot)tlpViewer.Controls.Find(counterName, false)[0];
                    plot.Plot.AddSignalXY(xs, ys);
                    plot.Refresh();
                }
            }

        }
    }
}
