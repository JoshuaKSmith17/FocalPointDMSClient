﻿using System;
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
            ViewModels.MainViewModel mainViewModel = new ViewModels.MainViewModel();
            Application.Current.Resources["mainViewModel"] = mainViewModel;

            Services.ApiFactory apiFactory = new Services.ApiFactory();
            Application.Current.Resources["apiFactory"] = apiFactory;

        }
    }
}
