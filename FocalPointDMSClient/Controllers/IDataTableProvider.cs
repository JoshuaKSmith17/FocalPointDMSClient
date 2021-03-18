using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using FocalPointDMSClient.Models.OrmModels;

namespace FocalPointDMSClient.Controllers
{
    interface IDataTableProvider
    {
        EntityType EntityType { get; }
        DataTable BuildTable();
    }
}
