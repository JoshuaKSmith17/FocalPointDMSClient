using FocalPointDMSClient.Models.OrmModels;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FocalPointDMSClient.Services
{
    public class RepairOrderServices : IApiServiceStrategy
    {
        HttpClient Client;
        RepairOrder[] Items;
        public EntityType EntityType => EntityType.RepairOrder;

        public RepairOrderServices()
        {
            Client = new HttpClient();
        }

        public async Task<DbObject[]> QueryAllItems()
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> PutItem(DbObject item)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> CreateItem(DbObject item)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponseMessage> DeleteItem(DbObject item)
        {
            throw new NotImplementedException();
        }

        public DbObject[] GetAllItems()
        {
            return Items;
        }
    }
}
