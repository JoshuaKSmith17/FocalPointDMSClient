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
            Client.BaseAddress = new Uri("https://localhost:44345/api/");

            var responseTask = Client.GetAsync("RepairOrders");
            responseTask.Wait();
            Items = await responseTask.Result.Content.ReadAsAsync<RepairOrder[]>();
            return Items;
        }

        public async Task<HttpResponseMessage> PutItem(DbObject item)
        {
            Client.BaseAddress = new Uri("https://localhost:44345/api/");

            var output = JsonConvert.SerializeObject(item);
            var buffer = System.Text.Encoding.UTF8.GetBytes(output);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var responseTask = await Client.PutAsync("RepairOrders/" + item.Id, byteContent);

            return responseTask;
        }

        public async Task<HttpResponseMessage> CreateItem(DbObject item)
        {
            Client.BaseAddress = new Uri("https://localhost:44345/api/");

            var output = JsonConvert.SerializeObject(item);
            var buffer = System.Text.Encoding.UTF8.GetBytes(output);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var responseTask = await Client.PostAsync("RepairOrders/", byteContent);

            return responseTask;
        }

        public async Task<HttpResponseMessage> DeleteItem(DbObject item)
        {
            Client.BaseAddress = new Uri("https://localhost:44345/api/");

            var responseTask = await Client.DeleteAsync("RepairOrders/" + item.Id);

            return responseTask;
        }

        public DbObject[] GetAllItems()
        {
            return Items;
        }
    }
}
