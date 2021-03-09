using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Net.Http;
using FocalPointDMSClient.Models;

namespace FocalPointDMSClient.Services
{
    public class FocalPointDmsApi
    {
        public HttpClient Client { get; set; }
        public FocalPointDmsApi()
        {
            Client = new HttpClient();
        }
        public async ValueTask<Customer[]> GetCustomers()
        {
            Client.BaseAddress = new Uri("https://localhost:44345/api/");

            var responseTask = Client.GetAsync("Customers");
            responseTask.Wait();
            var results = await responseTask.Result.Content.ReadAsAsync<Customer[]>();
            return results;
        }

        public async ValueTask<Equipment[]> GetEquipment()
        {
            Client.BaseAddress = new Uri("https://localhost:44345/api/");

            var responseTask = Client.GetAsync("Equipment");
            responseTask.Wait();
            var results = await responseTask.Result.Content.ReadAsAsync<Equipment[]>();
            return results;
        }
    }
}
