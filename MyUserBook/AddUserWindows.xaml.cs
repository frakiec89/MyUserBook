using System;
using System.Windows;


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
            Controller.UserController userController = new Controller.UserController();     
            try
            {
                userController.AddUser(tbLogin.Text, tbPassword.Text);
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
