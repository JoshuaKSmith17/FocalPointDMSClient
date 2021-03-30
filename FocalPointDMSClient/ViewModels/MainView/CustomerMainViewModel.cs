using System;
using System.Collections.Generic;
using System.Text;

using FocalPointDMSClient.Models.OrmModels;

namespace FocalPointDMSClient.ViewModels.MainView
{
    class CustomerMainViewModel : MainViewModel
    {
        public CustomerMainViewModel() : base()
        {
            RecordDetailCommand = new GetCustomerCommand();
            RecordDeleteCommand = new DeleteCustomerCommand();
            RecordAddCommand = new NewCustomerCommand();
            EntityType = EntityType.Customer;
        }
    }
}
