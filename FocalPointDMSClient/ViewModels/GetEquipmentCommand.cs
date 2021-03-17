using System;
using System.Windows;
using System.Windows.Input;

using FocalPointDMSClient.Controllers;

namespace FocalPointDMSClient.ViewModels
{
    class GetEquipmentCommand : ICommand
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
            var mainViewModel = (MainViewModel)Application.Current.Properties["mainViewModel"];
            var controller = new EquipmentController();
            mainViewModel.MainDataTable = controller.BuildTable();
            mainViewModel.StatusTextOutput += mainViewModel.MainDataTable.Rows.Count + " Equipment Items Loaded\n";

        }
    }
}
