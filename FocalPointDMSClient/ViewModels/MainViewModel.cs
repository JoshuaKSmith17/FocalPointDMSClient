﻿using System;
using System.Data;
using System.Windows;
using System.Collections.Generic;
using System.Text;
using FocalPointDMSClient.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FocalPointDMSClient.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FocalPointDMSClient.ViewModels
{
    class MainViewModel : INotifyPropertyChanged    
    {
        private DataTable dataTable;
        private string statusTextOutput;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand GetCustomersCommand { get; set; }
        public DataTable MainDataTable 
        { 
            get { return dataTable; } 
            set
            {
                dataTable = value;
                OnPropertyChanged();
            }
        }

        public string StatusTextOutput
        {
            get { return statusTextOutput; }
            set
            {
                statusTextOutput = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public MainViewModel()
        {
            MainDataTable = new DataTable();
            GetCustomersCommand = new GetCustomersCommand();
            StatusTextOutput = new string("");
        }
    }
}
