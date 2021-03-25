using System;
using System.Windows;
using System.Windows.Input;

using FocalPointDMSClient.Models.DataTableBuilders;
using FocalPointDMSClient.Models.OrmModels;
using FocalPointDMSClient.Controllers;

namespace FocalPointDMSClient.ViewModels
{
    class UpdateCustomerCommand : ICommand
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

            var input = (Customer)parameter;
            CustomerController controller = new CustomerController();
            controller.UpdateRecord(input);            

            var viewModel = (MainViewModel)Application.Current.Properties["mainViewModel"];
            viewModel.MainDataTable = controller.BuildTable();
            viewModel.StatusTextOutput += viewModel.MainDataTable.Rows.Count + " Customers Loaded\n";
        }
    }
}
