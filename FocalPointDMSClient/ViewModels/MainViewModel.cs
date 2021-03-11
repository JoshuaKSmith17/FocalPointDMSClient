using System;
using System.Data;
using System.Windows;
using System.Collections.Generic;
using System.Text;
using FocalPointDMSClient.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FocalPointDMSClient.Services;

namespace FocalPointDMSClient.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<IDbObject> MainDataView { get; set; }
        public DataTable MainDataTable { get; set; }
        public ICommand GetCustomersCommand;

        public MainViewModel()
        {
            MainDataView = new ObservableCollection<IDbObject>();
            MainDataTable = new DataTable();
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
            MainViewModel mainViewModel = (MainViewModel)Application.Current.Resources["mainViewModel"];
            DataColumn dataColumn;
            DataRow dataRow;

            dataColumn = new DataColumn();
            dataColumn.DataType = System.Type.GetType("System.Int32");
            dataColumn.ColumnName = "id";
            dataColumn.ReadOnly = true;
            mainViewModel.MainDataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = System.Type.GetType("string");
            dataColumn.ColumnName = "Name";
            dataColumn.ReadOnly = true;
            mainViewModel.MainDataTable.Columns.Add(dataColumn);

            foreach (var customer in customers)
            {
                dataRow = mainViewModel.MainDataTable.NewRow();
                dataRow["id"] = customer.Id;
                dataRow["Name"] = customer.Name;
                mainViewModel.MainDataTable.Rows.Add(dataRow);
            }

            

        }

    }
}
