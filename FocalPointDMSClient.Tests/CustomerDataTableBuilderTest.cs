using System.Data;
using NUnit.Framework;

using FocalPointDMSClient.Models.OrmModels;
using FocalPointDMSClient.Models.DataTableBuilders;

namespace FocalPointDMSClient.Tests
{
    public class CustomerDataTableBuilderTest
    {
        private CustomerDataTableBuilder _customerDataTableBuilder;
        Customer[] _customers;

        [SetUp]
        public void Setup()
        {

            _customers = new Customer[1];
            _customers[0] = new Customer();
            _customerDataTableBuilder = new CustomerDataTableBuilder();
        }

        [Test]
        public void Test1()
        {
            var result = new DataTable() == _customerDataTableBuilder.BuildTable(_customers);

            Assert.IsTrue(result, "The DataTable is not empty");
        }
    }
}