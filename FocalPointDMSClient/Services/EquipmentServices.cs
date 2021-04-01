using FocalPointDMSClient.Models;
using FocalPointDMSClient.Models.OrmModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FocalPointDMSClient.Services
{
    class EquipmentServices : IApiServiceStrategy
    {
        HttpClient Client;
        Equipment[] Items;
        public EntityType EntityType => EntityType.Equipment;

        public EquipmentServices()
        {
            Client = new HttpClient();
        }
        public async Task<DbObject[]> QueryAllItems()
        {
            Client.BaseAddress = new Uri("https://localhost:44345/api/");

            var responseTask = Client.GetAsync("Equipment");
            responseTask.Wait();
            Items = await responseTask.Result.Content.ReadAsAsync<Equipment[]>();
            return Items;
        }

        public DbObject[] GetAllItems()
        {
            return Items;
        }

        public void PutItem(DbObject item)
        {
            throw new NotImplementedException();
        }

        public void CreateItem(DbObject item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(DbObject item)
        {
            throw new NotImplementedException();
        }
    }
}
