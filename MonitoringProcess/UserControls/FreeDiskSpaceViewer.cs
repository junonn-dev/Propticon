using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot;
using MonitorigProcess;

namespace MonitoringProcess.UserControls
{
    public partial class FreeDiskSpaceViewer : UserControl
    {
        public FreeDiskSpaceViewer()
        {
            InitializeComponent();
        }

        private FreeDiskSpaceViewer(Measure form)
        {
            form.measureEvents[PID] = HandleLogEvent;
        }

        public void HandleLogEvent(object sender, DataEventArgs e)
        {

        }

    }
}
