using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Windows;


using FocalPointDMSClient.Services;
using FocalPointDMSClient.Models.OrmModels;

namespace FocalPointDMSClient.Tests
{
    class CustomerServicesTest
    {
        private IApiServiceStrategy _service;
        [SetUp]
        public void SetUp()
        {
            _service = new CustomerServices();
        }

        [Test]
        public void ValidCustomerServicesTest()
        {
            var customers = _service.QueryAllItems().Result;
            var result = customers.Length != 0 || customers != null;

            Assert.IsTrue(result, "The array is empty");
        }
    }
}
