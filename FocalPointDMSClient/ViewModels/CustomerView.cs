using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace FocalPointDMSClient.ViewModels
{
    class CustomerView : IGridViewModelStrategy
    {
        public ICollection<DataGridColumn> BuildDataGridColumns()
        {
            List<DataGridColumn> dataGridColumns = new List<DataGridColumn>();

            DataGridTextColumn dataGridColumn = new DataGridTextColumn();
            dataGridColumn.Header = "ID";
            dataGridColumn.Binding = new Binding("Id");
            dataGridColumns.Add(dataGridColumn);

            dataGridColumn = new DataGridTextColumn();
            dataGridColumn.Header = "Name";
            dataGridColumn.Binding = new Binding("Name");
            dataGridColumns.Add(dataGridColumn);

            return dataGridColumns;
        }
    }
}
