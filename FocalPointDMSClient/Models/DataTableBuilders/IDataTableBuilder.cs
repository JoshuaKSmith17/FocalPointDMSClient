using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using FocalPointDMSClient.Models.OrmModels;

namespace FocalPointDMSClient.Models.DataTableBuilders
{
    interface IDataTableBuilder
    {
        EntityType EntityType { get; }
        DataTable BuildTable();
    }
}
