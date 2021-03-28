using FocalPointDMSClient.Models;
using FocalPointDMSClient.Models.OrmModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace FocalPointDMSClient.Services
{
    class CustomerServices : IApiServiceStrategy
    {
        HttpClient Client;
        Customer[] Items;
        public EntityType EntityType => EntityType.Customer;
        public CustomerServices()
        {
            Client = new HttpClient();
        }
        public async void QueryAllItems()
        {
            Client.BaseAddress = new Uri("https://localhost:44345/api/");

            var responseTask = Client.GetAsync("Customers");
            responseTask.Wait();
            Items = await responseTask.Result.Content.ReadAsAsync<Customer[]>();
            
        }

        public async void PutItem(DbObject item)
        {
            Client.BaseAddress = new Uri("https://localhost:44345/api/");

            var output = JsonConvert.SerializeObject(item);
            var buffer = System.Text.Encoding.UTF8.GetBytes(output);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var responseTask = await Client.PutAsync("Customers/" + item.Id, byteContent);
        }

        public async void CreateItem(DbObject item)
        {
            Client.BaseAddress = new Uri("https://localhost:44345/api/");

            var output = JsonConvert.SerializeObject(item);
            var buffer = System.Text.Encoding.UTF8.GetBytes(output);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var responseTask = await Client.PostAsync("Customers/", byteContent);
        }

        public async void DeleteItem(DbObject item)
        {
            Client.BaseAddress = new Uri("https://localhost:44345/api/");

            var responseTask = await Client.DeleteAsync("Customers/" + item.Id);
        }

        public DbObject[] GetAllItems()
        {
            return Items;
        }
    }
}
