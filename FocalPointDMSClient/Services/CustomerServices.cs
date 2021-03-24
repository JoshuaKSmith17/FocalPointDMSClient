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

        public async void PutItem(IDbObject item)
        {
            Client.BaseAddress = new Uri("https://localhost:44345/api/");

            var output = JsonConvert.SerializeObject(item);
            var buffer = System.Text.Encoding.UTF8.GetBytes(output);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var responseTask = await Client.PostAsync("Customer", byteContent);
        }

        public IDbObject[] GetAllItems()
        {
            return Items;
        }
    }
}
