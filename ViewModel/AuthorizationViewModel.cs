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
