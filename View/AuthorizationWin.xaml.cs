using CSharpDB;
using CSharpDB.Context;
using CSharpProjCore.ViewModel;
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
        public AuthorizationWin()
        {
            InitializeComponent();
            this.DataContext = this.Resources["authorizationViewModel"];
        }

        private void buttonEnter_Click(object sender, RoutedEventArgs e)
        {
            Autoriz();
        }

        private void Autoriz()
        {
            DBCContext db = new DBCContext();
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
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();

                        this.Close();
                    }
                    else MessageBox.Show("Логин или пароль введены не правильно!");
                }
                else MessageBox.Show("Введите Пароль!");
            }
            else MessageBox.Show("Введите Логин!");
        }
    }
}
