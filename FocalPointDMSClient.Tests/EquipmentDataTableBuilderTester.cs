using NUnit.Framework;

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

        [TestCase("id")]
        public void IsEmptyEquipmentDataTableNums(string fieldName)
        {
            var result = _equipmentDataTableBuilder.BuildTable(_equipments)
                .Rows[0][fieldName].ToString().Equals("0");

            Assert.IsTrue(result, "The DataTable is not empty");
        }

        [TestCase("Make")]
        [TestCase("Model")]
        [TestCase("Serial Number")]
        public void NonEmptyEquipmentDataTable(string fieldName)
        {
            var result = _equipmentDataTableBuilder.BuildTable(_equipments)
                .Rows[1][fieldName].ToString().Equals("Test");

            Assert.IsTrue(result, "The DataTable value is incorrect");
        }

        [TestCase("id")]
        public void NonEmptyEquipmentDataTableNums(string fieldName)
        {
            var result = _equipmentDataTableBuilder.BuildTable(_equipments)
                .Rows[1][fieldName].ToString().Equals("1");

            Assert.IsTrue(result, "The DataTable value is incorrect");
        }
    }
}
