using Kingsman.Pages;
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

namespace Kingsman
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (ClassHelper.UserDataClass.Staff.Position == "Портной")
            {
                BtnStaff.Visibility = Visibility.Collapsed;
                TbStaff.Visibility = Visibility.Collapsed;
                BtnReport.Visibility = Visibility.Collapsed;
                TbReport.Visibility = Visibility.Collapsed;
            }
            else if (ClassHelper.UserDataClass.Staff.Position == "Продавец")
            {
                BtnStaff.Visibility = Visibility.Collapsed;
                TbStaff.Visibility= Visibility.Collapsed;
                BtnReport.Visibility = Visibility.Collapsed;
                TbReport.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnService_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.ServicePage());

            //ServiceFrame.Content = new ServicePage();

        }
        private void BtnCart_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.CartPage());
        }

        private void Btn_Clients_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.ClientsPage());
        }

        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.ReportPage());
        }

        private void BtnStaff_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Pages.StaffPage());

        }
    }

}
