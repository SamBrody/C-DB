using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace CSharpDB.Model
{
    public enum Grade 
    {
        five = 5,
        four = 4,
        three = 3,
        two = 2
    }
    public class Test : INotifyPropertyChanged
    {
        private int idtest;
        private DateTime date;
        private Grade grade;
        private int iduserprofile;
        private UserProfile userprofile;
        private ICollection<QuestionList> questionlists;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDTest 
        {
            get { return idtest; }
            set
            {
                idtest = value;
                OnPropertyChanged("IDTest");
            }
        }
        public DateTime Date 
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }
        public Grade Grade 
        {
            get { return grade; }
            set
            {
                grade = value;
                OnPropertyChanged("Grade");
            }
        }

        public int IDUserProfile
        {
            get { return iduserprofile; }
            set
            {
                iduserprofile = value;
                OnPropertyChanged("IDUserProfile");
            }
        }
        public virtual UserProfile UserProfile 
        {
            get { return userprofile; }
            set
            {
                userprofile = value;
                OnPropertyChanged("UserProfile");
            }
        }
        public virtual ICollection<QuestionList> QuestionLists
        {
            get { return questionlists; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
