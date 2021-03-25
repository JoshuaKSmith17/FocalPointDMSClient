using System;
using System.Windows;
using System.Windows.Input;

using FocalPointDMSClient.Models.DataTableBuilders;
using FocalPointDMSClient.Models.OrmModels;

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
            var mainViewModel = (MainViewModel) Application.Current.Properties["mainViewModel"];
            var factory = (DataTableBuilderFactory) Application.Current.Properties["DataTableBuilderFactory"];
            var controller = factory.GetInstance(EntityType.Customer);
            mainViewModel.MainDataTable = controller.BuildTable();
            mainViewModel.StatusTextOutput += mainViewModel.MainDataTable.Rows.Count + " Customers Loaded\n";
        }
    }
}
