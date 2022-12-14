using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Data;

namespace WindowsFormsApp1.UserControls
{
    public partial class uscRealTimeProcessView : UserControl
    {
        public uscRealTimeProcessView()
        {
            InitializeComponent();
        }

        public uscRealTimeProcessView(EventHandler<DataEventArgs> eventSender) : this()
        {
            eventSender += HandleEvent;
        }

        private void HandleEvent(object sender, DataEventArgs e)
        {
            lboxRealTimeLog.Items.Insert(0, e.message);

            //TODO : Worst List 표현
        }
    }
}
