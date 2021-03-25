using System.Data;
using System.Windows;

using FocalPointDMSClient.Models;
using FocalPointDMSClient.Models.OrmModels;
using FocalPointDMSClient.Services;

namespace FocalPointDMSClient.Models.DataTableBuilders
{
    public class EquipmentDataTableBuilder : IDataTableBuilder
    {
        DataTable DataTable;
        public EntityType EntityType => EntityType.Equipment;
        public EquipmentDataTableBuilder()
        {
            this.DataTable = new DataTable();
        }
        public DataTable BuildTable()
        {
            var factory = (ApiFactory)Application.Current.Properties["apiFactory"];
            IApiServiceStrategy service = factory.GetInstance(EntityType.Equipment);
            service.QueryAllItems();
            var items = (Equipment[])service.GetAllItems();

            DataColumn dataColumn;
            DataRow dataRow;

            dataColumn = new DataColumn();
            dataColumn.DataType = System.Type.GetType("System.Int64");
            dataColumn.ColumnName = "id";
            dataColumn.ReadOnly = true;
            DataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = System.Type.GetType("System.String");
            dataColumn.ColumnName = "Make";
            dataColumn.ReadOnly = true;
            DataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = System.Type.GetType("System.String");
            dataColumn.ColumnName = "Model";
            dataColumn.ReadOnly = true;
            DataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn();
            dataColumn.DataType = System.Type.GetType("System.String");
            dataColumn.ColumnName = "Serial Number";
            dataColumn.ReadOnly = true;
            DataTable.Columns.Add(dataColumn);

            foreach (var equipment in items)
            {
                dataRow = DataTable.NewRow();
                dataRow["id"] = equipment.Id;
                dataRow["Make"] = equipment.Make;
                dataRow["Model"] = equipment.Model;
                dataRow["Serial Number"] = equipment.SerialNumber;
                DataTable.Rows.Add(dataRow);
            }

            return DataTable;
        }
    }
}
