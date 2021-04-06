using FocalPointDMSClient.Models;
using FocalPointDMSClient.Models.OrmModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FocalPointDMSClient.Services
{
    public interface IApiServiceStrategy
    {
        EntityType EntityType { get; }
        public Task<DbObject[]> QueryAllItems();
        public DbObject[] GetAllItems();

        public Task<HttpResponseMessage> PutItem(DbObject item);
        public Task<HttpResponseMessage> CreateItem(DbObject item);
        public Task<HttpResponseMessage> DeleteItem(DbObject item);
    }
}
