using FocalPointDMSClient.Services;
using FocalPointDMSClient.ViewModels;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Threading;

using FocalPointDMSClient.ViewModels.MainView;
using System.Threading.Tasks;

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

        private async void GetCustomersButton_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel mainViewModel = (MainViewModel)Application.Current.Properties["mainViewModel"];
            DataContext = await GetUpdatedViewModel(mainViewModel);
            
        }

        async Task<MainViewModel> GetUpdatedViewModel(MainViewModel mainViewModel)
        {
            bool exitCondition = true;
            while (exitCondition)
            {
                if (mainViewModel.IsActiveViewModel == false)
                {
                    return (MainViewModel)Application.Current.Properties["mainViewModel"];
                }
                await Task.Delay(25);
            }
            return (MainViewModel)Application.Current.Properties["mainViewModel"];
        }
    }
}
