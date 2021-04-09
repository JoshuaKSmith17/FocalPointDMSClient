using NUnit.Framework;
using System;
using System.Net;

using FocalPointDMSClient.Services;
using FocalPointDMSClient.Models.OrmModels;

namespace FocalPointDMSClient.Tests
{
    class RepairOrderServicesTester
    {
        private IApiServiceStrategy _service;
        private RepairOrder _repairOrder;
        private RepairOrder _emptyRepairOrder;

        [SetUp]
        public void SetUp()
        {
            _service = new RepairOrderServices();
            _emptyRepairOrder = new RepairOrder();
            _repairOrder = new RepairOrder()
            {
                Id = 1,
                StartDate = DateTime.Today,
                CompletedData = DateTime.Today
            };
        }

        [Test]
        public void ValidRepairOrderServicesTest()
        {
            var repairOrders = _service.QueryAllItems().Result;
            var result = repairOrders.Length != 0 || repairOrders != null;

            Assert.IsTrue(result, "The array is empty");
        }

        [Test]
        public void EmptyRepairOrderServicesPutTest()
        {
            var result = _service.PutItem(_emptyRepairOrder).Result.StatusCode == HttpStatusCode.NotFound;

            Assert.IsTrue(result, "The response code is invalid");
        }

        [Test]
        public void RepairOrderServicesPutTest()
        {
            var result = _service.PutItem(_repairOrder).Result.StatusCode == HttpStatusCode.NoContent;

            Assert.IsTrue(result, "The item was not created");
        }

    }
}
