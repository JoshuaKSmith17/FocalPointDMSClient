using System;
using System.Collections.Generic;
using System.Text;

namespace FocalPointDMSClient.Services
{
    class ApiFactory
    {        
        public IApiServiceStrategy GetCustomerStrategy()
        {
            return new CustomerServices();
        }

        public IApiServiceStrategy GetEquipmentStrategy()
        {
            return new EquipmentService();
        }
    }
}
