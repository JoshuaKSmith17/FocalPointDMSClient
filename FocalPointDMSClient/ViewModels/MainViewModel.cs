using System;
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
    public class MainViewModel : INotifyPropertyChanged    
    {
        private DataTable dataTable;
        public event PropertyChangedEventHandler PropertyChanged;
        public DataTable MainDataTable 
        { 
            get { return dataTable; } 
            set
            {
                dataTable = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand GetCustomersCommand { get; set; }

        public MainViewModel()
        {
            MainDataTable = new DataTable();
            GetCustomersCommand = new GetCustomersCommand();
        }
    }
    
    class GetCustomersCommand : ICommand
    {
        public FocalPointDmsApi focalPointDmsApi;
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
            focalPointDmsApi = new FocalPointDmsApi();
            var customers = focalPointDmsApi.GetCustomers().Result;
            DataTable dataTable = new DataTable();

            DataColumn dataColumn;
            DataRow dataRow;

            dataColumn = new DataColumn();
            dataColumn.DataType = System.Type.GetType("System.Int64");
            dataColumn.ColumnName = "id";
            dataColumn.ReadOnly = true;
            dataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = System.Type.GetType("System.String");
            dataColumn.ColumnName = "Name";
            dataColumn.ReadOnly = true;
            dataTable.Columns.Add(dataColumn);

            foreach (var customer in customers)
            {
                dataRow = dataTable.NewRow();
                dataRow["id"] = customer.Id;
                dataRow["Name"] = customer.Name;
                dataTable.Rows.Add(dataRow);
            }

            MainViewModel mainViewModel = (MainViewModel)Application.Current.Resources["mainViewModel"];
            mainViewModel.MainDataTable = dataTable;


        }

    }
}
