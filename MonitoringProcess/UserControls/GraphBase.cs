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
using MonitorigProcess.Data;

namespace MonitorigProcess.UserControls
{
    public partial class GraphBase : UserControl
    {
        protected GraphViewerDto dto;
        protected GraphBase()
        {
            //InitializeComponent();
        }

        protected void FormsPlot_MouseWheel(object sender, MouseEventArgs e)
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
        protected FormsPlot GetCommonPlot(int width, int height, string name, string title)
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
    }
}
