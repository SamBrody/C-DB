using CSharpDB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSharpProjCore.Model
{
    public class User : INotifyPropertyChanged
    {
        private int idUser;
        private string login;
        private string password;
        private UserProfile userProfile;
        private int idRole;
        private Role role;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDUser
        {
            get { return idUser; }
            set
            {
                idUser = value;
                OnPropertyChanged("IDUser");
            }
        }
        [Required]
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        [Required]
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public virtual UserProfile UserProfile
        {
            get { return userProfile; }
            set
            {
                userProfile = value;
                OnPropertyChanged("UserProfile");
            }
        }

        public int IDRole
        {
            get { return idRole; }
            set
            {
                idRole = value;
                OnPropertyChanged("IDRole");
            }
        }
        public virtual Role Role
        {
            get { return role; }
            set
            {
                role = value;
                OnPropertyChanged("Role");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
