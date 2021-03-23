using System;
using System.Collections.Generic;
using System.Text;

namespace FocalPointDMSClient.Models.OrmModels
{
    public class Equipment : IDbObject
    {
        public long Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }

    }
}
