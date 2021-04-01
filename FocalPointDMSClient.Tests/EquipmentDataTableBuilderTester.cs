﻿using NUnit.Framework;

using FocalPointDMSClient.Models.OrmModels;
using FocalPointDMSClient.Models.DataTableBuilders;

namespace FocalPointDMSClient.Tests
{
    class EquipmentDataTableBuilderTester
    {
        private EquipmentDataTableBuilder _equipmentDataTableBuilder;
        private Equipment[] _equipments;

        [SetUp]
        public void Setup()
        {
            _equipments = new Equipment[2];
            _equipments[0] = new Equipment();
            _equipments[1] = new Equipment()
            {
                Id = 1,
                Make = "Test",
                Model = "Test",
                SerialNumber = "Test"
            };

            _equipmentDataTableBuilder = new EquipmentDataTableBuilder();
        }

        [TestCase("Make")]
        [TestCase("Model")]
        [TestCase("Serial Number")]
        public void IsEmptyEquipmentDataTable(string fieldName)
        {
            var result = _equipmentDataTableBuilder.BuildTable(_equipments)
                .Rows[0][fieldName].ToString().Equals("");

            Assert.IsTrue(result, "The DataTable is not empty");
        }
    }
}
