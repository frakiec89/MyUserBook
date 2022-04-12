using MyUserBook.BD;
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

namespace MyUserBook
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindows.xaml
    /// </summary>
    public partial class AddUserWindows : Window
    {
        public AddUserWindows()
        {
            InitializeComponent();
        }

        private void btAddUser_Click(object sender, RoutedEventArgs e)
        {
            using MyContext myContext = new MyContext();
            try
            {
               User user = new User();
               user.Password = tbPassword.Text;
               user.Login = tbLogin.Text;

                myContext.Add(user);
                myContext.SaveChanges();
                MessageBox.Show("Пользователь  добавлен");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
