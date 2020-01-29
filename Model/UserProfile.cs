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
    public class UserProfile : INotifyPropertyChanged
    {
        private int iduser;
        private string firstname;
        private string middlename;
        private string lastname;
        private int idgroup;
        private Group group;
        private Test test;
        private User user;

        [Key]
        [ForeignKey("User")]
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
        public string FirstName
        {
            get { return firstname; }
            set
            {
                firstname = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string MiddleName
        {
            get { return middlename; }
            set
            {
                middlename = value;
                OnPropertyChanged("MiddleName");
            }
        }
        [Required]
        public string LastName 
        {
            get { return lastname; }
            set
            {
                lastname = value;
                OnPropertyChanged("LastName");
            }
        }

        public int IDGroup
        {
            get { return idgroup; }
            set
            {
                idgroup = value;
                OnPropertyChanged("IDGroup");
            }
        }
        public virtual Group Group
        {
            get { return group; }
            set
            {
                group = value;
                OnPropertyChanged("Group");
            }
        }

        public virtual Test Test 
        {
            get { return test; }
            set
            {
                test = value;
                OnPropertyChanged("Test");
            }
        }
        public User User 
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
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
