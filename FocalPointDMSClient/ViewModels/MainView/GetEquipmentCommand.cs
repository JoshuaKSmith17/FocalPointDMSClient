using System;
using System.Windows;
using System.Windows.Input;

using FocalPointDMSClient.Controllers;
using FocalPointDMSClient.Models.OrmModels;
using FocalPointDMSClient.ViewModels.MainView.EquipmentVm;

namespace FocalPointDMSClient.ViewModels.MainView
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
            var oldViewModel = (MainViewModel)Application.Current.Properties["mainViewModel"];
            oldViewModel.MainDataTable = null;

            var mainViewModel = new EquipmentMainViewModel();
            Application.Current.Properties["mainViewModel"] = mainViewModel;

            var controller = new QueryController(EntityType.Equipment);
            mainViewModel.MainDataTable = controller.GetAllRecords();

            oldViewModel.IsActiveViewModel = false;
            mainViewModel.StatusTextOutput = mainViewModel.MainDataTable.Rows.Count + " Equipment Items Loaded\n" +
                                                mainViewModel.StatusTextOutput;

        }
    }
}
