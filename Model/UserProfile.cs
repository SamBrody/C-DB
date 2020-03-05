using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CSharpProjCore.Model;

namespace CSharpDB.Model
{
    public class UserProfile : INotifyPropertyChanged
    {
        private int idUser;
        private string firstName;
        private string lastName;
        private ICollection<TestResults> testResults;
        private User user;

        [Key]
        //[ForeignKey("User")]
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
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        [Required]
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public virtual ICollection<TestResults> TestResults
        {
            get { return testResults; }
            set
            {
                testResults = value;
                OnPropertyChanged("TestResults");
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
