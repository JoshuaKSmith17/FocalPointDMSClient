using System;
using System.Windows;
using System.Windows.Input;

using FocalPointDMSClient.Controllers;

namespace FocalPointDMSClient.ViewModels
{
    public class GetCustomersCommand : ICommand
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
            MainViewModel mainViewModel = (MainViewModel)Application.Current.Resources["mainViewModel"];
            CustomerController controller = new CustomerController(mainViewModel.MainDataTable);
            mainViewModel.MainDataTable = controller.BuildTable();
            mainViewModel.StatusTextOutput += mainViewModel.MainDataTable.Rows.Count + " Customers Loaded\n";

        }

    }
}
