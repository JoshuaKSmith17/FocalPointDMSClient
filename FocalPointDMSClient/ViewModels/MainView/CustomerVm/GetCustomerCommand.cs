﻿using System;
using System.Windows;
using System.Windows.Input;

using FocalPointDMSClient.Models.EntityConverters;
using FocalPointDMSClient.ViewModels.CustomerDetailViewModel;
using FocalPointDMSClient.Views;

namespace FocalPointDMSClient.ViewModels.MainView.CustomerVm
{
    class GetCustomerCommand : ICommand
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

            CustomerDetailVm viewModel = new CustomerDetailVm(customer);
            CustomerDetail customerDetail = new CustomerDetail(viewModel);
            customerDetail.Show();
        }
    }
}
