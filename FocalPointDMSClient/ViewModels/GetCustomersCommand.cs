using FocalPointDMSClient.Models;
using FocalPointDMSClient.Services;
using System;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace FocalPointDMSClient.ViewModels
{
    public class GetCustomersCommand : ICommand
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
            ApiFactory apiFactory = (ApiFactory) Application.Current.Resources["apiFactory"];
            IApiServiceStrategy service = apiFactory.GetCustomerStrategy();
            service.QueryAllItems();
            var customers = (Customer[]) service.GetAllItems();
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

            mainViewModel.StatusTextOutput += customers.Length + " Customers Loaded\n";


        }

    }
}
