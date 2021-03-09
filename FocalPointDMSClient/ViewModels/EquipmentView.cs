using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace FocalPointDMSClient.ViewModels
{
    class EquipmentView : IGridViewModelStrategy
    {
        public ICollection<DataGridColumn> BuildDataGridColumns()
        {
            List<DataGridColumn> dataGridColumns = new List<DataGridColumn>();

            DataGridTextColumn dataGridColumn = new DataGridTextColumn();
            dataGridColumn.Header = "ID";
            dataGridColumn.Binding = new Binding("Id");
            dataGridColumns.Add(dataGridColumn);

            dataGridColumn = new DataGridTextColumn();
            dataGridColumn.Header = "Make";
            dataGridColumn.Binding = new Binding("Make");
            dataGridColumns.Add(dataGridColumn);

            dataGridColumn = new DataGridTextColumn();
            dataGridColumn.Header = "Model";
            dataGridColumn.Binding = new Binding("Model");
            dataGridColumns.Add(dataGridColumn);

            dataGridColumn = new DataGridTextColumn();
            dataGridColumn.Header = "Serial Number";
            dataGridColumn.Binding = new Binding("SerialNumber");
            dataGridColumns.Add(dataGridColumn);

            return dataGridColumns;
        }
    }
}
