using System.ComponentModel;

namespace MonitoringProcess.Data
{
    public class SelectedProcess : INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }
        public string Name { get; set; }
        public string InstanceName { get; set; }

        public SelectedProcess(int id, string name, string instanceName)
        {
            this._id = id;
            this.Name = name;
            this.InstanceName = instanceName;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
