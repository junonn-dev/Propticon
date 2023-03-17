using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MonitorigProcess.Config;
using MonitorigProcess.Data;
using MonitorigProcess.Repository;

namespace MonitorigProcess.UserControls
{
    public partial class GraphViewer : UserControl
    {
        
        private TreeNode selectedNode;

        public GraphViewer()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!DesignMode)
            {
                RefreshReportList();
            }
        }

        private void RefreshReportList()
        {
            if (!Directory.Exists(AppConfiguration.logRootDirectory))
            {
                return;
            }
            treeView1.Nodes.Clear();
            DirectoryInfo info = new DirectoryInfo(AppConfiguration.logRootDirectory);
            DateTime temp = new DateTime();
            IEnumerable<DirectoryInfo> reportPathes = info.GetDirectories().TakeWhile(dir=> DateTime.TryParseExact(dir.Name, AppConfiguration.logPartialDirectoryFormat, CultureInfo.CurrentCulture, DateTimeStyles.None, out temp));
            //FileInfo[] xmlFiles = info.GetFiles("*.xml");
            TreeNode[] nodes = new TreeNode[reportPathes.Count()];
            for (int i = 0; i < nodes.Length; i++)
            {
                //treeview의 node에서 보여주는 이름은 xml 확장자 제거된 이름
                //node의 키값(Name)은 .xml 확장자 포함. 즉 파일 이름 그대로를 Name으로 함
                string showName = reportPathes.ElementAt(i).Name;
                TreeNode newNode = new TreeNode(showName);
                newNode.Name = reportPathes.ElementAt(i).Name;
                nodes[i] = newNode;
                treeView1.Nodes.Add(newNode);
            }
            //TreeNode root = new TreeNode("Reports", nodes);
            //treeView1.Nodes.AddRange(new TreeNode[] { root });
        }

        private void normalButton1_Click(object sender, EventArgs e)
        {
            RefreshReportList();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            selectedNode = e.Node;

            GraphViewerDto dto = ReportRepository.GetGraphViewerInfo(selectedNode.Name);

            if (dto == null)
            {
                MessageBox.Show($"프로그램 오류로 인해 Report 기록을 불러오지 못했습니다. ");
                return;
            }
            if (dto.xData.Length == 0)
            {
                MessageBox.Show($"측정된 데이터를 불러오지 못했습니다.");
                return;
            }

            tconGraph.TabPages["tpOverview"].Controls.Clear();
            GraphOverview graphOverview = new GraphOverview(dto);
            tconGraph.TabPages["tpOverview"].Controls.Add(graphOverview);

            tconGraph.TabPages["tpProcess"].Controls.Clear();
            GraphProcess graphProcess = new GraphProcess(dto);
            tconGraph.TabPages["tpProcess"].Controls.Add(graphProcess);

            tconGraph.TabPages["tpMetrics"].Controls.Clear();
            GraphMetrics graphMetrics = new GraphMetrics(dto);
            tconGraph.TabPages["tpMetrics"].Controls.Add(graphMetrics);
        }

        private void normalButton2_Click(object sender, EventArgs e)
        {
            //SelectedNode 없는 경우
            if (treeView1.SelectedNode == null)
            {
                return;
            }
            string toDelete = treeView1.SelectedNode.Name;
            
            if (string.IsNullOrEmpty(toDelete))
            {
                return;
            }

            if (MessageBox.Show($"{toDelete} 측정 기록을 삭제하시겠습니까?", "측정 기록 삭제", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            //위 messagebox확인에서 yes를 선택한 경우만 아래의 삭제 진행
            try
            {
                
                Directory.Delete(AppConfiguration.logRootDirectory + toDelete, true);
            }
            catch(Exception exception)
            {
                MessageBox.Show("측정 기록 삭제에 실패했습니다.");
                return;
            }
            MessageBox.Show($"{toDelete} 측정 기록을 삭제하였습니다.");

            tconGraph.TabPages["tpOverview"].Controls.Clear();
            tconGraph.TabPages["tpProcess"].Controls.Clear();
            tconGraph.TabPages["tpMetrics"].Controls.Clear();
            RefreshReportList();

        }
    }
}
