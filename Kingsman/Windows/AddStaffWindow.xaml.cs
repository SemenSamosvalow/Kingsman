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
    /// Логика взаимодействия для AddStaffWindow.xaml
    /// </summary>
    public partial class AddStaffWindow : Window
    {
        public AddStaffWindow()
        {
            InitializeComponent();
        }

        private void BtnAddStaff_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLNameStaff.Text))
            {
                MessageBox.Show("Поле Фамилия не заполнено");
                return;
            }

            if (string.IsNullOrWhiteSpace(TbFNameStaff.Text))
            {
                MessageBox.Show("Поле Имя не заполнено");
                return;
            }
            if (string.IsNullOrWhiteSpace(TbPhoneStaff.Text))
            {
                MessageBox.Show("Поле Телефон не заполнено");
                return;
            }
            if (string.IsNullOrWhiteSpace(TbLogInStaff.Text))
            {
                MessageBox.Show("Заполните логин");
                return;
            }
            if (string.IsNullOrWhiteSpace(PbPswStaff.Password))
            {
                MessageBox.Show("Заполните пароль");
                return;
            }

            DB.Staff newStaff = new DB.Staff();

            newStaff.LastName = TbLNameStaff.Text;
            newStaff.FirstName = TbLNameStaff.Text;
            if (TbPatronymicStaff.Text != string.Empty)
            {
                newStaff.Patronymic = TbPatronymicStaff.Text;
            }
            newStaff.LogIn = TbLNameStaff.Text;
            newStaff.Password = PbPswStaff.Password;
            newStaff.Phone = TbLNameStaff.Text;

            ClassHelper.EF.Context.Staff.Add(newStaff);

            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Клиент успешно добавлен!");

        }
    }
}
