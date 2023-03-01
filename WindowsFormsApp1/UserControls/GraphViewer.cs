using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Config;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Repository;

namespace WindowsFormsApp1.UserControls
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
                if (!Directory.Exists(AppConfiguration.reportDirectory))
                {
                    return;
                }
                DirectoryInfo info = new DirectoryInfo(AppConfiguration.reportDirectory);
                FileInfo[] xmlFiles = info.GetFiles("*.xml");
                TreeNode[] nodes = new TreeNode[xmlFiles.Length];
                for (int i = 0; i < nodes.Length; i++)
                {
                    //treeview의 node에서 보여주는 이름은 xml 확장자 제거된 이름
                    //node의 키값(Name)은 .xml 확장자 포함. 즉 파일 이름 그대로를 Name으로 함
                    string showName = xmlFiles[i].Name.Substring(0, xmlFiles[i].Name.Length - 4);
                    TreeNode newNode = new TreeNode(showName);
                    newNode.Name = xmlFiles[i].Name;
                    nodes[i] = newNode;
                    treeView1.Nodes.Add(newNode);
                }
                //TreeNode root = new TreeNode("Reports", nodes);
                //treeView1.Nodes.AddRange(new TreeNode[] { root });
            }
            
        }
        
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedNode = e.Node;

            GraphViewerDto dto = ReportRepository.GetGraphViewerInfo(selectedNode.Name);

            if (dto == null)
            {
                MessageBox.Show($"프로그램 오류로 인해 Report 기록을 불러오지 못했습니다. ");
                return;
            }

            GraphOverview graphOverview = new GraphOverview(dto);
            tconGraph.TabPages["tpOverview"].Controls.Add(graphOverview);

            GraphProcess graphProcess = new GraphProcess(dto);
            tconGraph.TabPages["tpProcess"].Controls.Add(graphProcess);

            GraphMetrics graphMetrics = new GraphMetrics(dto);
            tconGraph.TabPages["tpMetrics"].Controls.Add(graphMetrics);
        }
    }
}
