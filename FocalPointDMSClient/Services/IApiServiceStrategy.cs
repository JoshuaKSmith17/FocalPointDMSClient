using FocalPointDMSClient.Models;
using FocalPointDMSClient.Models.OrmModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FocalPointDMSClient.Services
{
    public interface IApiServiceStrategy
    {
        EntityType EntityType { get; }
        public void QueryAllItems();
        public IDbObject[] GetAllItems();

        public void PutItem(IDbObject item);
    }
}
