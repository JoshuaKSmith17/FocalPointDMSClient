using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows;
using System.Threading.Tasks;

using FocalPointDMSClient.Models.OrmModels;
using FocalPointDMSClient.Models.DataTableBuilders;
using FocalPointDMSClient.Services;


namespace FocalPointDMSClient.Controllers
{
    class CustomerController : IController
    {
        public DataTable BuildTable()
        {
            var factory = (ApiFactory)Application.Current.Properties["apiFactory"];
            IApiServiceStrategy service = factory.GetInstance(EntityType.Customer);

            Task<DbObject[]> customers = service.QueryAllItems();

            var dataTableFactory = (DataTableBuilderFactory)Application.Current.Properties["DataTableBuilderFactory"];
            var tableBuilder = dataTableFactory.GetInstance(EntityType.Customer);
            var dataTable = tableBuilder.BuildTable(customers.Result);

            return dataTable;
        }

        public void UpdateRecord(DbObject item)
        {
            var factory = (ApiFactory)Application.Current.Properties["apiFactory"];
            IApiServiceStrategy service = factory.GetInstance(EntityType.Customer);

            service.PutItem(item);
        }

        public void CreateRecord(DbObject item)
        {
            var factory = (ApiFactory)Application.Current.Properties["apiFactory"];
            IApiServiceStrategy service = factory.GetInstance(EntityType.Customer);

            service.CreateItem(item);
        }

        public void DeleteRecord(DbObject item)
        {
            var factory = (ApiFactory)Application.Current.Properties["apiFactory"];
            IApiServiceStrategy service = factory.GetInstance(EntityType.Customer);

            service.DeleteItem(item);
        }
    }
}
