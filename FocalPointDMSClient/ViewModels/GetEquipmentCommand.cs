﻿using System;
using System.Windows;
using System.Windows.Input;

using FocalPointDMSClient.Controllers;
using FocalPointDMSClient.Models.OrmModels;

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
            var mainViewModel = (MainViewModel) Application.Current.Properties["mainViewModel"];
            var factory = (ControllerFactory) Application.Current.Properties["controllerFactory"];
            IDataTableProvider controller = factory.GetInstance(EntityType.Equipment);
            mainViewModel.MainDataTable = controller.BuildTable();
            mainViewModel.StatusTextOutput += mainViewModel.MainDataTable.Rows.Count + " Equipment Items Loaded\n";

        }
    }
}
