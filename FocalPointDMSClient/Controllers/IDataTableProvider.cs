using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FocalPointDMSClient.Controllers
{
    interface IDataTableProvider
    {
        public DataTable BuildTable();
    }
}
