using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using FocalPointDMSClient.Models.OrmModels;


namespace FocalPointDMSClient.ViewModels.CustomerDetailViewModel
{
    public class CustomerDetailVm : INotifyPropertyChanged
    {
        private Customer customer;
        public ICommand UpdateCustomerCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Customer Customer
        {
            get { return customer; }
            set
            {
                customer = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public CustomerDetailVm(Customer customer)
        {
            Customer = customer;
            UpdateCustomerCommand = new UpdateCustomerCommand();
        }
    }
}
