using FocalPointDMSClient.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FocalPointDMSClient.Services
{
    class CustomerServices : IApiServiceStrategy
    {
        public HttpClient Client { get; set; }
        public Customer[] Items { get; set; }
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

        public IDbObject[] GetAllItems()
        {
            return Items;
        }
    }
}
