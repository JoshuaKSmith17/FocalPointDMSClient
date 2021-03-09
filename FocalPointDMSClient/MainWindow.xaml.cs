using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Collections.ObjectModel;
using FocalPointDMSClient.Services;
using FocalPointDMSClient.Models;
using FocalPointDMSClient.ViewModels;

namespace FocalPointDMSClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public FocalPointDmsApi focalPointDmsApi;
        public MainViewModel mainViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            mainViewModel = new MainViewModel();
            DataContext = mainViewModel;
            
    }

        private void GetCustomersButton_Click(object sender, RoutedEventArgs e)
        {

            mainViewModel.MainDataView.Clear();            
            ViewDataGrid.Columns.Clear();            

            focalPointDmsApi = new FocalPointDmsApi();
            var customers = focalPointDmsApi.GetCustomers().Result;

            foreach (var customer in customers)
            {
                mainViewModel.MainDataView.Add(customer);
            }

            CustomerView customerView = new CustomerView();
            ICollection<DataGridColumn> dataGridColumns = customerView.BuildDataGridColumns();

            foreach (var dataGridColumn in dataGridColumns)
            {
                ViewDataGrid.Columns.Add(dataGridColumn);
            }

            ViewDataGrid.ItemsSource = mainViewModel.MainDataView;
            TestBox.Text = mainViewModel.MainDataView.Count + " Customers Loaded";

        }
    }
}
