using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using FocalPointDMSClient.Models.OrmModels;

namespace FocalPointDMSClient.Models.EntityConverters
{
    class CustomerConverter
    {
        private DataRowView DataRow;

        public CustomerConverter(DataRowView dataRow)
        {
            DataRow = dataRow;
        }

        public Customer Convert()
        {
            Customer customer = new Customer();

            customer.Id = (long)DataRow["Id"];
            customer.Name = (string)DataRow["Name"];
            customer.Address = (string)DataRow["Address"];
            customer.City = (string)DataRow["City"];
            customer.State = (string)DataRow["State"];
            customer.ZipCode = (int)DataRow["Zip Code"];

            return customer;
        }
    }
}
