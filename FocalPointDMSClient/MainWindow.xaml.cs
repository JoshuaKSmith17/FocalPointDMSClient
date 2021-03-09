using FocalPointDMSClient.Services;
using FocalPointDMSClient.ViewModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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

        private void GetEquipmentButton_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.MainDataView.Clear();
            ViewDataGrid.Columns.Clear();

            focalPointDmsApi = new FocalPointDmsApi();
            var equipments = focalPointDmsApi.GetEquipment().Result;

            foreach (var equipment in equipments)
            {
                mainViewModel.MainDataView.Add(equipment);
            }

            EquipmentView equipmentView = new EquipmentView(); 
            ICollection<DataGridColumn> dataGridColumns = equipmentView.BuildDataGridColumns();

            foreach (var dataGridColumn in dataGridColumns)
            {
                ViewDataGrid.Columns.Add(dataGridColumn);
            }

            ViewDataGrid.ItemsSource = mainViewModel.MainDataView;
            TestBox.Text = mainViewModel.MainDataView.Count + " Equipment Items Loaded";
        }
    }
}
