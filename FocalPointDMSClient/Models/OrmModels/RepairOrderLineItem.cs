using System;
using System.Collections.Generic;
using System.Text;

namespace FocalPointDMSClient.Models.OrmModels
{
    public class RepairOrderLineItem
    {
        public long Id { get; set; }
        public string WorkPerformed { get; set; }
        public Equipment Equipment { get; set; }
    }
}
