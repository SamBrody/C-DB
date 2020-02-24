using CSharpDB;
using CSharpDB.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CSharpProjCore.View
{
    /// <summary>
    /// Interaction logic for AuthorizationWin.xaml
    /// </summary>
    public partial class AuthorizationWin : Window
    {
        DBCContext db = new DBCContext();
        public AuthorizationWin()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void buttonEnter_Click(object sender, RoutedEventArgs e)
        {
            Autoriz();            
        }

        private void Autoriz()
        {
            string login = textBoxLogin.Text;
            string password = passwordBoxPassword.Password;
            if (login.Length > 0)
            {
                if (password.Length > 0)
                {
                    var authoriz = from p in db.Users
                                   where p.Login == login
                                   && p.Password == password
                                   select p;
                    if (authoriz.Count() > 0)
                    {
                        MessageBox.Show("Авторизация прошла успешно!");
                        string username = login;
                        MainWindow mainWindow = new MainWindow(login);
                        mainWindow.Show();

                        this.Close();
                    }
                    else MessageBox.Show("Логин или пароль введены не правильно!");
                }
                else MessageBox.Show("Введите Пароль!");
            }
            else MessageBox.Show("Введите Логин!");
        }

        private void buttonEnterGuest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы вошли как Гость!");
            string login = "Гость";
            MainWindow mainWindow = new MainWindow(login);
            mainWindow.Show();

            this.Close();
        }

        private void buttonRegis_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWin registrationWin = new RegistrationWin();
            registrationWin.Show();

            this.Close();
        }
    }
}
