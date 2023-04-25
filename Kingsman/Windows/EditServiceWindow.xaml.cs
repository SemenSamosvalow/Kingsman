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
using System.Windows.Shapes;

namespace Kingsman.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditServiceWindow.xaml
    /// </summary>
    public partial class EditServiceWindow : Window
    {

        DB.Service editService = null;
        private bool isEdit = false;

        public EditServiceWindow()
        {
            InitializeComponent();
            isEdit = false;
        }
        public EditServiceWindow(DB.Service service)
        {
            InitializeComponent();

            isEdit = true;

            editService = service;

            // Заполнение типа услуги

            CmbTypeService.ItemsSource = ClassHelper.EF.Context.Category.ToList();
            CmbTypeService.DisplayMemberPath = "NameOfCategory";

            // выгрузка изображения 
            //ImgImageService.Source = new BitmapImage(new Uri(service.Image));

            // заполнение полей
            TbNameService.Text = service.NameOfService;
            TbDiscService.Text = service.Description;
            TbPriceService.Text = Convert.ToString(service.Cost);

            // заполнение типа услуги
            CmbTypeService.SelectedItem = ClassHelper.EF.Context.Category.Where(i => i.Id == service.CategoryId).FirstOrDefault();

        }
        private void BtnEditService_Click(object sender, RoutedEventArgs e)
        {
            editService.NameOfService = TbNameService.Text;
            editService.Description = TbDiscService.Text;
            editService.Cost = Convert.ToDecimal(TbPriceService.Text);
            editService.CategoryId = (CmbTypeService.SelectedItem as DB.Category).Id;

            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Данные успешно сохранны");

            this.Close();
        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
