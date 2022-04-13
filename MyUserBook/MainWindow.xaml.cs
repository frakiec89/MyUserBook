using MyUserBook.Model;
using System;
using System.Linq;
using System.Windows;
namespace MyUserBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btReg_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindows addUserWindows = new AddUserWindows();
            addUserWindows.ShowDialog();

        }

        private void btAut_Click(object sender, RoutedEventArgs e)
        {
            Controller.UserController userController = new Controller.UserController();
            Controller.LogsController logsController = new Controller.LogsController();
            try
            {
                if (userController.Users.Any(x => x.Password == tbPassword.Text && x.Login == tbLogin.Text))
                {
                    var us = userController.Users.Where(x => x.Password == tbPassword.Text && x.Login == tbLogin.Text).First();
                    logsController.AddLog(new Log(us));
                    MessageBox.Show("Авторизация прошла");
                }
                else
                {
                    logsController.AddLog(new Log(tbLogin.Text, tbPassword.Text));
                    MessageBox.Show("Авторизация не прошла");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
