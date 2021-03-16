using FocalPointDMSClient.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FocalPointDMSClient.Services
{
    public interface IApiServiceStrategy
    {
        public void QueryAllItems();
        public IDbObject[] GetAllItems();
    }
}
