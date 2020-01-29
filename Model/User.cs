using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CSharpDB.Model
{
    public class User : INotifyPropertyChanged 
    {
        private int iduser;
        private string login;
        private string password;
        private int idrole;
        private Role role;
        private UserProfile userprofile;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public int IDUser 
        {
            get { return iduser; }
            set
            {
                iduser = value;
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
        public int IDRole
        {
            get { return idrole; }
            set
            {
                idrole = value;
                OnPropertyChanged("IDRole");
            }
        }
        [DefaultValue("student")]
        public virtual Role Role
        {
            get { return role; }
            set
            {
                role = value;
                OnPropertyChanged("Role");
            }
        }

        public UserProfile UserProfile 
        {
            get { return userprofile; }
            set
            {
                userprofile = value;
                OnPropertyChanged("UserProfile");
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
