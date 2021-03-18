using FocalPointDMSClient.Models;
using FocalPointDMSClient.Models.OrmModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FocalPointDMSClient.Services
{
    class EquipmentService : IApiServiceStrategy
    {
        HttpClient Client;
        Equipment[] Items;
        public EntityType EntityType => EntityType.Equipment;

        public EquipmentService()
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

        public IDbObject[] GetAllItems()
        {
            return Items;
        }
    }
}
