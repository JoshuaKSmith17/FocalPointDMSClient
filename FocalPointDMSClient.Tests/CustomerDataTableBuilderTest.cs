using System.Data;
using NUnit.Framework;

using FocalPointDMSClient.Models.OrmModels;
using FocalPointDMSClient.Models.DataTableBuilders;

namespace FocalPointDMSClient.Tests
{
    public class CustomerDataTableBuilderTest
    {
        private CustomerDataTableBuilder _customerDataTableBuilder;
        private Customer[] _customers;

        [SetUp]
        public void Setup()
        {
            _customers = new Customer[1];
            _customers[0] = new Customer();
            _customerDataTableBuilder = new CustomerDataTableBuilder();

        }

        [TestCase("Name")]
        [TestCase("Address")]
        [TestCase("City")]
        [TestCase("State")]
        public void IsEmptyCustomerDataTable(string fieldName)
        {
            var result = _customerDataTableBuilder.BuildTable(_customers).Rows[0][fieldName].ToString().Equals("");

            Assert.IsTrue(result, "The DataTable is not empty");
        }

        [TestCase("id")]
        [TestCase("Zip Code")]
        public void IsEmptyCustomerDataTableNums(string fieldName)
        {
            var result = _customerDataTableBuilder.BuildTable(_customers).Rows[0][fieldName].ToString().Equals("0");

            Assert.IsTrue(result, "The DataTable is not empty");
        }
    }
}