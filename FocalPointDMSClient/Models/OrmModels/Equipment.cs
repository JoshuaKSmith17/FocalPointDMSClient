using System;
using System.Collections.Generic;
using System.Text;

namespace FocalPointDMSClient.Models.OrmModels
{
    public class Equipment : DbObject
    {

        public string Make { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }

    }
}
