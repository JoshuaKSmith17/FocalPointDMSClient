using System.Data;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using FocalPointDMSClient.Models.OrmModels;

namespace FocalPointDMSClient.ViewModels.MainView
{
    class MainViewModel : INotifyPropertyChanged
    {
        private DataTable dataTable;
        private string statusTextOutput;
        private DataRowView selectedItemRow;
        public event PropertyChangedEventHandler PropertyChanged;
        public EntityType EntityType { get; set; }
        public ICommand GetCustomersCommand { get; set; }
        public ICommand GetEquipmentCommand { get; set; }
        public ICommand RecordDetailCommand { get; set; }
        public ICommand RecordDeleteCommand { get; set; }
        public ICommand RecordAddCommand { get; set; }

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

        public DataRowView SelectedItemRow
        {
            get { return selectedItemRow; }
            set
            {
                if (selectedItemRow != value)
                {
                    selectedItemRow = value;
                    OnPropertyChanged();
                    //StatusTextOutput += selectedItemRow.Row["Name"] + "\n";
                }
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
            RecordDetailCommand = new GetCustomerCommand();
            RecordDeleteCommand = new DeleteCustomerCommand();
            RecordAddCommand = new NewCustomerCommand();
            StatusTextOutput = new string("");
            EntityType = EntityType.Customer;
        }

    }
}
