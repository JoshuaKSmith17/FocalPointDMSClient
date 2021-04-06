using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FocalPointDMSClient.Models.OrmModels
{
    public class Equipment : DbObject
    {

        public string Make { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }

        public Equipment()
        {

        }

        public Equipment(DataRowView dataRow)
        {
            Id = (long)dataRow["Id"];
            Make = (string)dataRow["Make"];
            Model = (string)dataRow["Model"];
            SerialNumber = (string)dataRow["Serial Number"];
        }
    }
}
