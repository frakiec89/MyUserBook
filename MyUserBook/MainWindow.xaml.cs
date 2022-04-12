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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            using MyContext  myContext = new MyContext();
            try
            {
                if (myContext.Users.Any(x => x.Password == tbPassword.Text && x.Login == tbLogin.Text))
                {
                    var us = myContext.Users.Where(x => x.Password == tbPassword.Text && x.Login == tbLogin.Text).First();
                    myContext.Logs.Add( new Log(us));
                    myContext.SaveChanges();
                    MessageBox.Show("Авторизация прошла");
                }
                else
                {
                    myContext.Logs.Add(new Log(tbLogin.Text , tbPassword.Text));
                    myContext.SaveChanges();
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
