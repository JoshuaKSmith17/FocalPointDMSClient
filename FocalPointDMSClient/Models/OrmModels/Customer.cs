using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FocalPointDMSClient.Models.OrmModels
{
    public class Customer : DbObject
    {

        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        public Customer()
        {

        }

        public Customer(DataRowView dataRow)
        {
                Customer customer = new Customer();

                Id = (long)dataRow["Id"];
                Name = (string)dataRow["Name"];
                Address = (string)dataRow["Address"];
                City = (string)dataRow["City"];
                State = (string)dataRow["State"];
                ZipCode = (int)dataRow["Zip Code"];         
        }

    }
}
