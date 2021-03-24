using FocalPointDMSClient.Services;
using FocalPointDMSClient.ViewModels;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace FocalPointDMSClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = Application.Current.Properties["mainViewModel"];
        }
    }
}
