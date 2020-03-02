using CSharpProjCore.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDB.Model
{
    public class Role : INotifyPropertyChanged
    {
        private int idRole;
        private string roleName;
        private ICollection<User> users;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDRole
        {
            get { return idRole; }
            set
            {
                idRole = value;
                OnPropertyChanged("IDRole");
            }
        }
        [Required]
        public string RoleName
        {
            get { return roleName; }
            set
            {
                roleName = value;
                OnPropertyChanged("RoleName");
            }
        }
        public virtual ICollection<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged("Users");
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
