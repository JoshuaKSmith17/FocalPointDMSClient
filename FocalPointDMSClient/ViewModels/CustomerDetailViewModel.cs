using System;
using System.Data;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using FocalPointDMSClient.Models.OrmModels;


namespace FocalPointDMSClient.ViewModels
{
    public class CustomerDetailViewModel : INotifyPropertyChanged
    {
        private Customer customer;
        public Action CloseAction { get; set; }
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

        public CustomerDetailViewModel(Customer customer)
        {
            this.Customer = customer;
            UpdateCustomerCommand = new UpdateCustomerCommand();
        }
    }
}
