using System.Data;
using System.Windows;

using FocalPointDMSClient.Models;
using FocalPointDMSClient.Models.OrmModels;
using FocalPointDMSClient.Services;


namespace FocalPointDMSClient.Controllers
{
    class CustomerController : IDataTableProvider
    {
        DataTable DataTable;

        public CustomerController()
        {
            DataTable = new DataTable();
        }
        public DataTable BuildTable()
        {
            var factory = (ApiFactory) Application.Current.Properties["apiFactory"];
            IApiServiceStrategy service = factory.GetInstance(Models.OrmModels.EntityType.Customer);
            service.QueryAllItems();
            var customers = (Customer[]) service.GetAllItems();


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
