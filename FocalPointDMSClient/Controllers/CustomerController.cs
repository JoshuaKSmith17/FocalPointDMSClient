using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;

using FocalPointDMSClient.Models;
using FocalPointDMSClient.Services;


namespace FocalPointDMSClient.Controllers
{
    class CustomerController
    {
        DataTable DataTable;
        public CustomerController(DataTable dataTable)
        {
            this.DataTable = dataTable;
            dataTable.Clear();
        }
        public DataTable BuildTable()
        {
            var factory = (ApiFactory) Application.Current.Resources["apiFactory"];
            IApiServiceStrategy service = factory.GetCustomerStrategy();
            service.QueryAllItems();
            var customers = (Customer[]) service.GetAllItems();

            DataTable = new DataTable();

            DataColumn dataColumn;
            DataRow dataRow;

            dataColumn = new DataColumn();
            dataColumn.DataType = System.Type.GetType("System.Int64");
            dataColumn.ColumnName = "id";
            dataColumn.ReadOnly = true;
            DataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = System.Type.GetType("System.String");
            dataColumn.ColumnName = "Name";
            dataColumn.ReadOnly = true;
            DataTable.Columns.Add(dataColumn);

            foreach (var customer in customers)
            {
                dataRow = DataTable.NewRow();
                dataRow["id"] = customer.Id;
                dataRow["Name"] = customer.Name;
                DataTable.Rows.Add(dataRow);
            }

            return DataTable;
        }
    }
}
