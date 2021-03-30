using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

using FocalPointDMSClient.Models.OrmModels;

namespace FocalPointDMSClient.ViewModels.MainView.CustomerVm
{
    class CustomerMainViewModel : MainViewModel
    {
        public CustomerMainViewModel() : base()
        {
            RecordDetailCommand = new GetCustomerCommand();
            RecordDeleteCommand = new DeleteCustomerCommand();
            RecordAddCommand = new NewCustomerCommand();
            EntityType = EntityType.Customer;

            // Sets the MainViewModel application property to this particular instance.
            Application.Current.Properties["MainViewModel"] = this;
        }
    }
}
