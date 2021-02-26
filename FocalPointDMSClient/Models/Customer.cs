using System;
using System.Collections.Generic;
using System.Text;

namespace FocalPointDMSClient.Models
{
    public class Customer : IDbObject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

    }
}
