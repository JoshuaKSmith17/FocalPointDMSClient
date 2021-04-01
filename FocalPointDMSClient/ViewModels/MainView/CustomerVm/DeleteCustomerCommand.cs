using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

using FocalPointDMSClient.Controllers;
using FocalPointDMSClient.Models.EntityConverters;
using FocalPointDMSClient.Models.OrmModels;

namespace FocalPointDMSClient.ViewModels.MainView.CustomerVm
{
    class DeleteCustomerCommand : ICommand
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
            var customerConverter = new CustomerConverter(mainViewModel.SelectedItemRow);

            var customer = customerConverter.Convert();

            CustomerController controller = new CustomerController(EntityType.Customer);
            controller.DeleteRecord(customer);
        }
    }
}
