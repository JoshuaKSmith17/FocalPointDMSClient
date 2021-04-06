using FocalPointDMSClient.Models;
using FocalPointDMSClient.Models.OrmModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace FocalPointDMSClient.Services
{
    public class EquipmentServices : IApiServiceStrategy
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

        public async Task<HttpResponseMessage> PutItem(DbObject item)
        {
            Client.BaseAddress = new Uri("https://localhost:44345/api/");

            var output = JsonConvert.SerializeObject(item);
            var buffer = System.Text.Encoding.UTF8.GetBytes(output);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var responseTask = await Client.PutAsync("Equipment/" + item.Id, byteContent);

            return responseTask;
        }

        public async Task<HttpResponseMessage> CreateItem(DbObject item)
        {
            Client.BaseAddress = new Uri("https://localhost:44345/api/");

            var output = JsonConvert.SerializeObject(item);
            var buffer = System.Text.Encoding.UTF8.GetBytes(output);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var responseTask = await Client.PostAsync("Equipment/", byteContent);

            return responseTask;
        }

        public async Task<HttpResponseMessage> DeleteItem(DbObject item)
        {
            Client.BaseAddress = new Uri("https://localhost:44345/api/");

            var responseTask = await Client.DeleteAsync("Equipment/" + item.Id);

            return responseTask;
        }

        public DbObject[] GetAllItems()
        {
            return Items;
        }
    }
}
