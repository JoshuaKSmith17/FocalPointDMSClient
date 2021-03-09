using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace FocalPointDMSClient.ViewModels
{
    public interface IGridViewModelStrategy
    {
        public ICollection<DataGridColumn> BuildDataGridColumns();
    }
}
