using System.Data;
using NUnit.Framework;

using FocalPointDMSClient.Models.OrmModels;
using FocalPointDMSClient.Models.DataTableBuilders;

namespace FocalPointDMSClient.Tests
{
    public class EmptyCustomerDataTableBuilderTest
    {
        private CustomerDataTableBuilder _customerDataTableBuilder;
        private Customer[] _customers;

        [SetUp]
        public void Setup()
        {
            _customers = new Customer[2];
            _customers[0] = new Customer();
            _customers[1] = new Customer() 
            {    
                Id = 1,
                Name = "Test",
                Address = "Test",
                City = "Test",
                State = "Test",
                ZipCode = 1 
            };

            _customerDataTableBuilder = new CustomerDataTableBuilder();

        }

        [TestCase("Name")]
        [TestCase("Address")]
        [TestCase("City")]
        [TestCase("State")]
        public void IsEmptyCustomerDataTable(string fieldName)
        {
            var result = _customerDataTableBuilder.BuildTable(_customers)
                .Rows[0][fieldName].ToString().Equals("");

            Assert.IsTrue(result, "The DataTable is not empty");
        }

        [TestCase("id")]
        [TestCase("Zip Code")]
        public void IsEmptyCustomerDataTableNums(string fieldName)
        {
            var result = _customerDataTableBuilder.BuildTable(_customers)
                .Rows[0][fieldName].ToString().Equals("0");

            Assert.IsTrue(result, "The DataTable is not empty");
        }

        [TestCase("Name")]
        [TestCase("Address")]
        [TestCase("City")]
        [TestCase("State")]
        public void NonEmptyCustomerDataTable(string fieldName)
        {
            var result = _customerDataTableBuilder.BuildTable(_customers)
                .Rows[1][fieldName].ToString().Equals("Test");

            Assert.IsTrue(result, "The DataTable values are incorrect.");
        }

        [TestCase("id")]
        [TestCase("Zip Code")]
        public void NonEmptyCustomerDataTableNums(string fieldName)
        {
            var result = _customerDataTableBuilder.BuildTable(_customers)
                .Rows[1][fieldName].ToString().Equals("1");

            Assert.IsTrue(result, "The DataTable values are incorrect");
        }
    }
}