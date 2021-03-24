using System;
using System.Windows;
using System.Windows.Input;

using FocalPointDMSClient.Models.EntityConverters;
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
            var customerConverter = new CustomerConverter(mainViewModel.SelectedItemRow);

            var customer = customerConverter.Convert();

            CustomerDetailViewModel viewModel = new CustomerDetailViewModel(customer);
            CustomerDetail customerDetail = new CustomerDetail();
            customerDetail.DataContext = viewModel;
            customerDetail.Show();
        }
    }
}
