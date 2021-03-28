using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FocalPointDMSClient.ViewModels.CustomerDetailViewModel;

namespace FocalPointDMSClient.Views
{
    /// <summary>
    /// Interaction logic for CustomerDetail.xaml
    /// </summary>
    public partial class CustomerDetail : Window
    {
        public CustomerDetail(CustomerDetailVm viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;            
        }
    }
}
