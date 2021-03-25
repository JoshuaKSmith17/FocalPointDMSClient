using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows;

using FocalPointDMSClient.Models.OrmModels;
using FocalPointDMSClient.Models.DataTableBuilders;
using FocalPointDMSClient.Services;


namespace FocalPointDMSClient.Controllers
{
    class CustomerController : IController
    {
        public DataTable BuildTable()
        {
            var factory = (DataTableBuilderFactory)Application.Current.Properties["DataTableBuilderFactory"];
            var tableBuilder = factory.GetInstance(EntityType.Customer);

            var dataTable = tableBuilder.BuildTable();
            return dataTable;
        }

        public void UpdateRecord(DbObject item)
        {
            var factory = (ApiFactory)Application.Current.Properties["apiFactory"];
            IApiServiceStrategy service = factory.GetInstance(EntityType.Customer);

            service.PutItem(item);
        }
    }
}
