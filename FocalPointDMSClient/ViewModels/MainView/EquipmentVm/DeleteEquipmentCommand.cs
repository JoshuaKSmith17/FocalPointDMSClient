using System;
using System.Windows;
using System.Windows.Input;

using FocalPointDMSClient.Controllers;
using FocalPointDMSClient.Models.EntityConverters;
using FocalPointDMSClient.Models.OrmModels;

namespace FocalPointDMSClient.ViewModels.MainView.EquipmentVm
{
    class DeleteEquipmentCommand : ICommand
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

            var customer = new Equipment(mainViewModel.SelectedItemRow);

            QueryController controller = new QueryController(EntityType.Equipment);
            controller.DeleteRecord(customer);
        }
    }
}

