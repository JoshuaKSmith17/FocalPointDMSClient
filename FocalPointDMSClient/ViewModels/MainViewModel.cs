using System;
using System.Collections.Generic;
using System.Text;
using FocalPointDMSClient.Models;
using System.Collections.ObjectModel;

namespace FocalPointDMSClient.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Customer> MainDataView { get; set; }

        public MainViewModel()
        {
            MainDataView = new ObservableCollection<Customer>();
        }
    }
}
