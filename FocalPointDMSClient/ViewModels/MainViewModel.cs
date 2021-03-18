using System.Data;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FocalPointDMSClient.ViewModels
{
    class MainViewModel : INotifyPropertyChanged    
    {
        private DataTable dataTable;
        private string statusTextOutput;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand GetCustomersCommand { get; set; }
        public ICommand GetEquipmentCommand { get; set; }
        public ICommand GetCustomerCommand { get; set; }
        public DataTable MainDataTable 
        { 
            get { return dataTable; } 
            set
            {
                dataTable = value;
                OnPropertyChanged();
            }
        }

        public string StatusTextOutput
        {
            get { return statusTextOutput; }
            set
            {
                statusTextOutput = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public MainViewModel()
        {
            MainDataTable = new DataTable();
            GetCustomersCommand = new GetCustomersCommand();
            GetEquipmentCommand = new GetEquipmentCommand();
            GetCustomerCommand = new GetCustomerCommand();
            StatusTextOutput = new string("");
        }
    }
}
