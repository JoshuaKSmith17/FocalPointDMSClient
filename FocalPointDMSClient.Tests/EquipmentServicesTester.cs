using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Net;

using FocalPointDMSClient.Services;
using FocalPointDMSClient.Models.OrmModels;


namespace FocalPointDMSClient.Tests
{
    class EquipmentServicesTester
    {
        private IApiServiceStrategy _service;
        private Equipment _equipment;
        private Equipment _emptyEquipment;

        [SetUp]
        public void SetUp()
        {
            _service = new EquipmentServices();
            _emptyEquipment = new Equipment();
            _equipment = new Equipment();
            _equipment.Id = 1;
            _equipment.Make = "Test";
            _equipment.Model = "Test";
            _equipment.SerialNumber = "Test";
        }

        [Test]
        public void ValidEquipmentServicesTest()
        {
            var equipmentItems = _service.QueryAllItems().Result;
            var result = equipmentItems.Length != 0 || equipmentItems != null;

            Assert.IsTrue(result, "The array is empty");
        }

        [Test]
        public void EmptyEquipmentServicesPutTest()
        {
            var result = _service.PutItem(_emptyEquipment).Result.StatusCode == HttpStatusCode.NotFound;

            Assert.IsTrue(result, "The response code is invalid");
        }

        [Test]
        public void EquipmentServicesPutTest()
        {
            var result = _service.PutItem(_equipment).Result.StatusCode == HttpStatusCode.NoContent;

            Assert.IsTrue(result, "The item was not created");
        }
    }


}
