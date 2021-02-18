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

namespace FocalPointDMSClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public FocalPointDmsApi focalPointDmsApi;

        public MainWindow()
        {
            InitializeComponent();
            focalPointDmsApi = new FocalPointDmsApi();
            
    }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Customer> customersView = new ObservableCollection<Customer>();

            focalPointDmsApi = new FocalPointDmsApi();
                
            var customers = focalPointDmsApi.GetCustomers().Result;

            foreach (var customer in customers)
            {
                customersView.Add(customer);
            }

            ViewDataGrid.DataContext = customersView;

            TestBox.Text = "Customers Loaded";



        }
    }
}
