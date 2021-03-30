using System.Data;
using System.Windows;

using FocalPointDMSClient.Models.OrmModels;
using FocalPointDMSClient.Services;


namespace FocalPointDMSClient.Models.DataTableBuilders
{
    public class CustomerDataTableBuilder : IDataTableBuilder
    {
        DataTable DataTable;
        public EntityType EntityType => EntityType.Customer;

        public CustomerDataTableBuilder()
        {
            DataTable = new DataTable();
        }
        public DataTable BuildTable(DbObject[] items)
        {
            var customers = (Customer[])items;

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

            dataColumn = new DataColumn();
            dataColumn.DataType = System.Type.GetType("System.String");
            dataColumn.ColumnName = "Address";
            dataColumn.ReadOnly = true;
            DataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = System.Type.GetType("System.String");
            dataColumn.ColumnName = "City";
            dataColumn.ReadOnly = true;
            DataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = System.Type.GetType("System.String");
            dataColumn.ColumnName = "State";
            dataColumn.ReadOnly = true;
            DataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = System.Type.GetType("System.Int32");
            dataColumn.ColumnName = "Zip Code";
            dataColumn.ReadOnly = true;
            DataTable.Columns.Add(dataColumn);

            foreach (var customer in customers)
            {
                dataRow = DataTable.NewRow();
                dataRow["id"] = customer.Id;
                dataRow["Name"] = customer.Name;                
                dataRow["Address"] = customer.Address; 
                dataRow["City"] = customer.City; 
                dataRow["State"] = customer.State;
                dataRow["Zip Code"] = customer.ZipCode;
                DataTable.Rows.Add(dataRow);
            }

            return DataTable;
        }


    }
}
