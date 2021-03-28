using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

using FocalPointDMSClient.ViewModels.CustomerDetailViewModel;
using FocalPointDMSClient.Views;
using FocalPointDMSClient.Models.OrmModels;

namespace FocalPointDMSClient.ViewModels.MainView
{
    class NewCustomerCommand : ICommand
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

            CustomerDetailVm viewModel = new CustomerDetailVm(new Customer());
            CustomerDetail customerDetail = new CustomerDetail(viewModel);
            customerDetail.Show();


        }
    }
}
