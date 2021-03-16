﻿using FocalPointDMSClient.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FocalPointDMSClient.Services
{
    class EquipmentService : IApiServiceStrategy
    {
        public HttpClient Client { get; set; }
        public Equipment[] Items { get; set; }

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