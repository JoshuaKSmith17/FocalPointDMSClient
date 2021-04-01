using System;
using System.Windows;
using System.Windows.Input;

using FocalPointDMSClient.Models.DataTableBuilders;
using FocalPointDMSClient.Models.OrmModels;
using FocalPointDMSClient.ViewModels.MainView;
using FocalPointDMSClient.ViewModels.MainView.CustomerVm;
using FocalPointDMSClient.Controllers;

namespace FocalPointDMSClient.ViewModels.MainView
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
            var oldViewModel = (MainViewModel)Application.Current.Properties["mainViewModel"];
            oldViewModel.MainDataTable = null;

            var mainViewModel = new CustomerMainViewModel();
            Application.Current.Properties["mainViewModel"] =  mainViewModel;

            var factory = (DataTableBuilderFactory) Application.Current.Properties["DataTableBuilderFactory"];
            var controller = new QueryController(EntityType.Customer);
            mainViewModel.MainDataTable = controller.GetAllRecords();

            oldViewModel.IsActiveViewModel = false;
            mainViewModel.StatusTextOutput += mainViewModel.MainDataTable.Rows.Count + " Customers Loaded\n";
        }
    }
}
