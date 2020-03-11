using CSharpDB;
using CSharpDB.Context;
using CSharpProjCore.Model;
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
        DBCContext db = new DBCContext();
        #region Constructor
        public AuthorizationWin()
        {
            InitializeComponent();
            this.DataContext = this.Resources["authorizationViewModel"];
            CheckUserExist();
        }
        #endregion

        #region Methods
        private void CheckUserExist()
        {
            var user_ = (from l in db.Users
                             //where l.Login == textBoxLogin.Text && l.Password == passwordBoxPassword.Password
                         select l.IDUser).ToList();
            for (int i = 0; i < user_.Count; i++)
            {
                var userProf = (from l in db.UserProfiles
                                where l.IDUser == user_[i]
                                select l);
                int b = userProf.Count();
                if (b == 0)
                {
                    User user = db.Users.Find(user_[i]);
                    if (user != null)
                    {
                        db.Users.Remove(user);
                        db.SaveChanges();
                    }
                }
            }
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
                        MessageBox.Show("Авторизация прошла успешно!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                        string username = login;
                        MainWindow mainWindow = new MainWindow(login);
                        mainWindow.Show();

                        this.Close();
                    }
                    else MessageBox.Show("Такого пользователя не существует/логин или пароль введены не правильно!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else MessageBox.Show("Введите Пароль!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else MessageBox.Show("Введите Логин!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        #endregion

        #region Events
        private void buttonEnter_Click(object sender, RoutedEventArgs e)
        {            
            Autoriz();            
        }

        private void buttonEnterGuest_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы вошли как Гость!", "", MessageBoxButton.OK, MessageBoxImage.Information);
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
        #endregion
    }
}
