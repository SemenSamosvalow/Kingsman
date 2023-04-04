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
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();

            CmbGedner.ItemsSource = ClassHelper.EF.Context.Gender.ToList();
            CmbGedner.DisplayMemberPath = "GenderName";
            CmbGedner.SelectedIndex= 0;
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TBLastName.Text))
            {
                MessageBox.Show("Поле Фамилия не заполнено");
                return;
            }

            if (string.IsNullOrWhiteSpace(TBFirstName.Text))
            {
                MessageBox.Show("Поле Имя не заполнено");
                return;
            }
            if (string.IsNullOrWhiteSpace(TBPhone.Text))
            {
                MessageBox.Show("Поле Телефон не заполнено");
                return;
            }
            if (string.IsNullOrWhiteSpace(TBLogin.Text))
            {
                MessageBox.Show("Заполните логин");
                return;
            }
            if (string.IsNullOrWhiteSpace(PBPassword.Password))
            {
                MessageBox.Show("Заполните пароль");
                return;
            }



            DB.Client addClient = new DB.Client();
            addClient.Login = TBLogin.Text;
            addClient.Password = PBPassword.Password;
            addClient.LastName = TBLastName.Text;
            addClient.FirstName= TBFirstName.Text;
            if (TBPatronymic.Text != string.Empty)
            {
                addClient.Patronymic = TBPatronymic.Text;
            }
            addClient.Phone= TBPhone.Text;
            addClient.GenderCode = (CmbGedner.SelectedItem as DB.Gender).GenderName;
            addClient.Birthday =  Convert.ToDateTime(TBBirtday.Text);

            ClassHelper.EF.Context.Client.Add(addClient);

            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Пользователь успешно добавлен");



        }
    }
}
