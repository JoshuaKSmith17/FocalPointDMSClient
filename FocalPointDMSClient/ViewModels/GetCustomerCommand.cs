using System;
using System.Windows;
using System.Windows.Input;

using FocalPointDMSClient.Models.OrmModels;
using FocalPointDMSClient.Views;

namespace FocalPointDMSClient.ViewModels
{
    class GetCustomerCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            var mainViewModel = (MainViewModel) Application.Current.Properties["mainViewModel"];
            var selectedRow = mainViewModel.SelectedItemRow;

            Customer customer = new Customer();
            customer.Id = (long) selectedRow["Id"];
            customer.Name = (string) selectedRow["Name"];

            CustomerDetailViewModel viewModel = new CustomerDetailViewModel(customer);
            CustomerDetail customerDetail = new CustomerDetail();
            customerDetail.DataContext = viewModel;
            customerDetail.Show();
        }
    }
}
