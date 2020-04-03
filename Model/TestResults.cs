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
    public class TestResults : INotifyPropertyChanged
    {
        private int idTestResults;
        private DateTime date;
        private int idTest;
        private Test test;
        //private int idGrade;
        //private Grade grade;
        private string grade;
        private int idUserProfile;
        private UserProfile userProfile;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDTestResults
        {
            get { return idTestResults; }
            set
            {
                idTestResults = value;
                OnPropertyChanged("IDTestResults");
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

        public int IDTest
        {
            get { return idTest; }
            set
            {
                idTest = value;
                OnPropertyChanged("IDTest");
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

        //public int IDGrade
        //{
        //    get { return idGrade; }
        //    set
        //    {
        //        idGrade = value;
        //        OnPropertyChanged("IDGrade");
        //    }
        //}
        //public virtual Grade Grade
        //{
        //    get { return grade; }
        //    set
        //    {
        //        grade = value;
        //        OnPropertyChanged("Grade");
        //    }
        //}

        public string Grade
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
            get { return idUserProfile; }
            set
            {
                idUserProfile = value;
                OnPropertyChanged("IDUserProfile");
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


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
