using CSharpDB.Context;
using CSharpDB.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows;
using System.Collections.ObjectModel;
using CSharpProjCore.Model;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Security;

namespace CSharpProjCore.ViewModel
{
    public class AuthorizationViewModel : BaseViewModel
    {
        DBCContext db;
        //RelayCommand loginCommand;
        ObservableCollection<User> users;

        private string login;

        public AuthorizationViewModel()
        {
            db = new DBCContext();
            db.Users.Load();
            Users = db.Users.Local.ToObservableCollection();
        }

        public ObservableCollection<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }

        //public RelayCommand LoginCommand
        //{
        //    get
        //    {
        //        return loginCommand ??
        //          (loginCommand = new RelayCommand((o) =>
        //          {
        //              db = new DBCContext();
        //              string login_ = Login;
        //              string password_ = o as string;
        //              if (login_.Length > 0)
        //              {
        //                  if (password_.Length > 0)
        //                  {
        //                      var authoriz = (from p in db.Users
        //                                      where p.Login == login_
        //                                     && p.Password == password_
        //                                      select p);
        //                      if (authoriz.Count() > 0)
        //                      {
        //                          MessageBox.Show("Авторизация прошла успешно!");
        //                          string username = login_;  
        //                      }
        //                      else MessageBox.Show("Логин или пароль введены не правильно!");
        //                  }
        //                  else MessageBox.Show("Введите Пароль!");
        //              }
        //              else MessageBox.Show("Введите Логин!");
        //          }));
        //    }
        //}

        public string Login
        {
            get {return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        private SecureString _password;
        public SecureString PasswordSecureString
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
    }
}
