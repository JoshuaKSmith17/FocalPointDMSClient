using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FocalPointDMSClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.Properties["mainViewModel"] = new ViewModels.MainView.CustomerVm.CustomerMainViewModel();
            this.Properties["apiFactory"] = new Services.ApiFactory();
            this.Properties["DataTableBuilderFactory"] = new Models.DataTableBuilders.DataTableBuilderFactory();


        }
    }
}
