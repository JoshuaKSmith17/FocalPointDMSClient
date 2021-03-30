using FocalPointDMSClient.Models;
using FocalPointDMSClient.Models.OrmModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FocalPointDMSClient.Services
{
    public interface IApiServiceStrategy
    {
        EntityType EntityType { get; }
        public Task<DbObject[]> QueryAllItems();
        public DbObject[] GetAllItems();

        public void PutItem(DbObject item);
        public void CreateItem(DbObject item);
        public void DeleteItem(DbObject item);
    }
}
