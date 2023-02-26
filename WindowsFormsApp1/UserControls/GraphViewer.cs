using ScottPlot;
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
using WindowsFormsApp1.Config;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Graph;

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
                    //treeview의 node는 보여주는 이름은 xml 확장자 제거
                    //node의 키값(Name)은 .xml 확장자 포함. 즉 파일 이름 그대로를 Name으로 함
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

            OverviewDto dto = ReportXmlHandler.getReportOverviewInfo(selectedNode.Name);

            if (dto == null)
            {
                MessageBox.Show($"프로그램 오류로 인해 Report 기록을 불러오지 못했습니다. ");
                return;
            }

            GraphOverview dataOverview = new GraphOverview(dto);
            tconGraph.TabPages["tpOverview"].Controls.Add(dataOverview);
            

        }
    }
}
