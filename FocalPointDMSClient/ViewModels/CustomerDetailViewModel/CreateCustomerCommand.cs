﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows;

using FocalPointDMSClient.Models.OrmModels;
using FocalPointDMSClient.Controllers;
using FocalPointDMSClient.ViewModels.MainView;


namespace FocalPointDMSClient.ViewModels.CustomerDetailViewModel
{
    class CreateCustomerCommand : ICommand
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
            QueryController controller = new QueryController(EntityType.Customer);
            controller.CreateRecord(input);

            var viewModel = (MainViewModel)Application.Current.Properties["mainViewModel"];
            viewModel.MainDataTable = controller.GetAllRecords();
            viewModel.StatusTextOutput += viewModel.MainDataTable.Rows.Count + " Customers Loaded\n";
        }
    }
}
