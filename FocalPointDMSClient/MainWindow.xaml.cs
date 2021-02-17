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
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44345/api/");

                var responseTask = client.GetAsync("Customers");
                responseTask.Wait();

                var results = responseTask.Result.Content.ReadAsAsync<Customer[]>();
                results.Wait();

                var customers = results.Result;

                TestBox.Text = "";

                foreach (var customer in customers)
                {
                    TestBox.Text += customer.Name + "\n";
                }
                
                
            }
        }
    }
}
