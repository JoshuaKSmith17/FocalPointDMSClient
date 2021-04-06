using System;
using System.Collections.Generic;
using System.Text;

namespace FocalPointDMSClient.Models.OrmModels
{
    public class RepairOrder
    {
        public long Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletedData { get; set; }
        public List<RepairOrderLineItem> RepairOrderLineItems { get; set; }
    }
}
