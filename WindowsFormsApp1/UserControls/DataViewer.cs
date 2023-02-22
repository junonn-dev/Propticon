using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.UserControls
{
    public partial class DataViewer : UserControl
    {
        private readonly string reportDirectory = ConfigurationManager.AppSettings["reportDirectory"];
        private TreeNode selectedNode;

        public DataViewer()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!DesignMode)
            {
                if (!Directory.Exists(reportDirectory))
                {
                    return;
                }
                DirectoryInfo info = new DirectoryInfo(reportDirectory);
                FileInfo[] xmlFiles = info.GetFiles("*.xml");
                TreeNode[] nodes = new TreeNode[xmlFiles.Length];
                for (int i = 0; i < nodes.Length; i++)
                {
                    string showName = xmlFiles[i].Name.Substring(0, xmlFiles[i].Name.Length - 4);
                    TreeNode newNode = new TreeNode(showName);
                    newNode.Name = xmlFiles[i].Name;
                    nodes[i] = newNode;

                }
                TreeNode root = new TreeNode("Reports", nodes);
                treeView1.Nodes.AddRange(new TreeNode[] { root });
            }
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedNode = e.Node;

            LogParser logParser;
            try
            {
                //임시 예외처리
                logParser = new LogParser(dtpStart.Value);
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
            tconGraph.TabPages["tpOverview"].Controls.Add()
        }
    }
}
