using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public AddClientWindow()
        {
            InitializeComponent();

            CmbGenderClient.ItemsSource = ClassHelper.EF.Context.Gender.ToList();
            CmbGenderClient.DisplayMemberPath = "GenderName";
            CmbGenderClient.SelectedIndex = 0;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLNameClient.Text))
            {
                MessageBox.Show("Поле Фамилия не заполнено");
                return;
            }

            if (string.IsNullOrWhiteSpace(TbFNameClient.Text))
            {
                MessageBox.Show("Поле Имя не заполнено");
                return;
            }
            if (string.IsNullOrWhiteSpace(TbPhoneClient.Text))
            {
                MessageBox.Show("Поле Телефон не заполнено");
                return;
            }
            if (string.IsNullOrWhiteSpace(TbLogInClient.Text))
            {
                MessageBox.Show("Заполните логин");
                return;
            }
            if (string.IsNullOrWhiteSpace(PbPswClient.Password))
            {
                MessageBox.Show("Заполните пароль");
                return;
            }

            DB.Clients newClients = new DB.Clients();

            newClients.LastName = TbLNameClient.Text;
            newClients.FirstName = TbFNameClient.Text;
            if (TbPatronymicClient.Text != string.Empty)
            {
                newClients.Patronymic = TbPatronymicClient.Text;
            }
            newClients.GenderCode = (CmbGenderClient.SelectedItem as DB.Gender).Id;
            newClients.Birthday = Convert.ToDateTime(TbBirtdayClient.Text);
            newClients.LogIn = TbLogInClient.Text;
            newClients.Password = PbPswClient.Password;
            newClients.Phone = TbPhoneClient.Text;

            ClassHelper.EF.Context.Clients.Add(newClients);

            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Клиент успешно добавлен!");


        }
    }
}
