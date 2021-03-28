using FocalPointDMSClient.Models;
using FocalPointDMSClient.Models.OrmModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

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
        public async void QueryAllItems()
        {
            Client.BaseAddress = new Uri("https://localhost:44345/api/");

            var responseTask = Client.GetAsync("Equipment");
            responseTask.Wait();
            Items = await responseTask.Result.Content.ReadAsAsync<Equipment[]>();
        }

        public DbObject[] GetAllItems()
        {
            return Items;
        }

        public void PutItem(DbObject item)
        {

        }

        public void CreateItem(DbObject item)
        {

        }

        public void DeleteItem(DbObject item)
        {

        }
    }
}
