using System;
using System.Windows;
using System.Windows.Input;

using FocalPointDMSClient.Controllers;
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
            CustomerDetailViewModel viewModel = new CustomerDetailViewModel();
            CustomerDetail customerDetail = new CustomerDetail();
            customerDetail.Show();
            //var mainViewModel = (MainViewModel)Application.Current.Properties["mainViewModel"];
            //var factory = (ControllerFactory)Application.Current.Properties["controllerFactory"];
            //var controller = factory.GetInstance(EntityType.Customer);
            //mainViewModel.MainDataTable = controller.BuildTable();
            //mainViewModel.StatusTextOutput += mainViewModel.MainDataTable.Rows.Count + " Customers Loaded\n";

        }
    }
}
