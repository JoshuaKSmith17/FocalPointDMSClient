using System;
using System.Collections.Generic;
using System.Text;

namespace FocalPointDMSClient.Services
{
    public class ApiFactory
    {        
        public IApiServiceStrategy GetCustomerStrategy()
        {
            return new CustomerServices();
        }
    }
}
