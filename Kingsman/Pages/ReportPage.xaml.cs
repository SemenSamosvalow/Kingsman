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

namespace Kingsman.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        public ReportPage()
        {
            InitializeComponent();
            GetListClientService();
            GetListOrders();
        }

        private void GetListClientService()
        {
            LvClientService.ItemsSource = ClassHelper.EF.Context.ClientService.ToList();
        }
        private void GetListOrders()
        {
            LvOrders.ItemsSource = ClassHelper.EF.Context.Order.ToList();
        }
        private void BtnOrders_Click(object sender, RoutedEventArgs e)
        {
            LvClientService.Visibility = Visibility.Visible;
            LvOrders.Visibility = Visibility.Visible;
        }

        private void BtnClientService_Click(object sender, RoutedEventArgs e)
        {
            LvOrders.Visibility = Visibility.Hidden;
            LvClientService.Visibility = Visibility.Visible;

        }
    }
}
