using FocalPointDMSClient.Services;
using System;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace FocalPointDMSClient.ViewModels
{
    public class GetCustomersCommand : ICommand
    {
        FocalPointDmsApi focalPointDmsApi;
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
