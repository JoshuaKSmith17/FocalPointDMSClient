using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Windows;
using System.Net;


using FocalPointDMSClient.Services;
using FocalPointDMSClient.Models.OrmModels;

namespace FocalPointDMSClient.Tests
{
    class CustomerServicesTest
    {
        private IApiServiceStrategy _service;
        private Customer _customer;
        private Customer _emptyCustomer;
        [SetUp]
        public void SetUp()
        {
            _service = new CustomerServices();
            _emptyCustomer = new Customer();
            _customer = new Customer()
            {
                Id = 1,
                Name = "Test",
                Address = "Test",
                City = "Test",
                State = "Test",
                ZipCode = 1

            };

        }

        [Test]
        public void ValidCustomerServicesTest()
        {
            var customers = _service.QueryAllItems().Result;
            var result = customers.Length != 0 || customers != null;

            Assert.IsTrue(result, "The array is empty");
        }
        public void EmptyCustomerServicesPutTest()
        {
            var result = _service.PutItem(_emptyCustomer).Result.StatusCode == HttpStatusCode.NotFound;

            Assert.IsTrue(result, "The response code is invalid");
        }

        [Test]
        public void CustomerServicesPutTest()
        {
            var result = _service.PutItem(_customer).Result.StatusCode == HttpStatusCode.NoContent;

            Assert.IsTrue(result, "The item was not created");
        }
    }
}
